using ApolloTests.Data.Entity.Question;
using ApolloTests.Data.EntityBuilder.Entities;
using ApolloTests.Data.EntityBuilder.Models;
using ApolloTests.Data.EntityBuilder.QuestionAnswers;
using DocumentFormat.OpenXml.VariantTypes;
using DynamicExpresso;
using HitachiQA.Helpers;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace ApolloTests.Data.EntityBuilder
{
    public class StateChangeAttribute : Attribute
    {
        public string TargetAnswers;
        public string? TargetSectionEntity;
        public StateChangeAttribute(string targetAnswers, string? targetSectionEntity) {
            this.TargetAnswers = targetAnswers;
            this.TargetSectionEntity = targetSectionEntity;
        }
    }
    public static class StateChangesUtil
    {

        private static AnswersBase GetAnswers(HydratorUtil hydratorUtil, PropertyInfo propInfo)
        {
            var att = propInfo.GetAttr();
            if (att != null)
                return hydratorUtil.Interpreter.Eval<AnswersBase>(att.TargetAnswers);
            
            return hydratorUtil.CurrentAnswers ?? throw new NullReferenceException("current answers was null in the interpreter but List<QuestionResponse> found. you can also use HydratorAttr to explicitly point a AnswerBase object");
        }
        private static object? GetEntityInContext(HydratorUtil hydratorUtil, PropertyInfo propInfo)
        {
            var att = propInfo.GetAttr();
            if (att != null)
                return att.TargetSectionEntity == null? null : hydratorUtil.Interpreter.Eval(att.TargetSectionEntity);

            return hydratorUtil.CurrentEntity;
        }
        private static StateChangeAttribute? GetAttr(this PropertyInfo propInfo) => propInfo?.GetCustomAttribute<StateChangeAttribute>();

        public static void Hydrate(this List<QuestionResponse> questionAnswers, HydratorUtil hydrator, PropertyInfo propInfo)
        {
            AnswersBase answers = GetAnswers(hydrator, propInfo);
            object? currentEntity = GetEntityInContext(hydrator, propInfo);
            string sectionName = SectionNames[hydrator.CurrentSection];
            if(sectionName=="Locations")
            {
                sectionName = currentEntity?.GetType() == typeof(Location) ? "Locations" : "Buildings";
            }
            if (hydrator.CurrentSection == Section.PolicyCoverages)
            {
                var limit = (Limit?)currentEntity ?? throw new NullReferenceException();
                var covQ = ((JArray?)hydrator.Quote.GetCoverageQuestions(limit.coverageType.Name))?.ToObject<List<QuestionResponse>>() ?? throw new NullReferenceException();
                questionAnswers.AddRange(covQ);
                questionAnswers.LoadAnswers(hydrator, answers);
                return;
            }

            var questions = ((JArray?)hydrator.Quote.GetSectionQuestions(sectionName))?.ToObject<List<QuestionResponse>>() ?? throw new NullReferenceException();

            
            questionAnswers.AddRange(questions.Where(q=> !questionAnswers.Any(it=>it.questionId==q.questionId)));

            

            questionAnswers.LoadAnswers(hydrator, answers);
            counter = 0;
            questionAnswers.StateChangeUntilHydrated(hydrator, propInfo);

            if (questionAnswers.Any(q=> q.sectionId==0))
            {
                var sectionId = hydrator.Quote.Storyboard.GetSection(sectionName).Id;
                questionAnswers.ForEach(it => it.sectionId = sectionId);
            }

            questionAnswers.CheckForRequiredQuestionsThatAreNull();

        }

        private static void CheckForRequiredQuestionsThatAreNull(this List<QuestionResponse> questionAnswers)
        {
            List<QuestionResponse> RequiredQuestionsThatAreNull = new();

            foreach (var question in questionAnswers)
            {
                if(question.isHidden)
                {
                    continue;
                }
                if ((question.response == null || (question.response is string res && res == string.Empty)) && (question.RequiresAnswer))
                {
                    RequiredQuestionsThatAreNull.Add(question);
                }
                //else if (question.questionType == 70 && question.response is string str && str ==string.Empty)
                //{
                    
                //}
            }

            if (RequiredQuestionsThatAreNull.Any())
            {
                var helperStr = "";
                var aliasesStr = "";
                foreach (var question in RequiredQuestionsThatAreNull)
                {

                    var varName = question.alias?.Replace('-', '_') ?? throw new NullReferenceException($"Alias was null for question {question.Id}");
                    aliasesStr += $"public static string {varName} {{ get; }} = \"{question.alias}\";\n";
                    helperStr += $"public QuestionAnswer {varName} {{ get; set; }} = new QuestionAnswer(Alias.{varName}, null);\n";
                }

                throw new Exception($"required answers answered with null. please use the code below to fill them out \n\n on QuestionAnswers.QuestionAnswer \n{aliasesStr} \n\nunder QuestionAnswers: \n{helperStr}");
            }

        }

        private static void LoadAnswers(this List<QuestionResponse> questionAnswers, HydratorUtil hydrator, AnswersBase Answers, List<QuestionResponse>? stateChange=null)
        {

            List<QuestionResponse> questionsToLoad= new List<QuestionResponse>();

            if (stateChange == null)
            {
               questionsToLoad.AddRange(questionAnswers.Where(q=> !q.isHidden));
            }
            else
            {
                //load state change ids
                var idsToRemove = stateChange.Select(it => it.Id);
                //remove state change from existing
                questionAnswers.RemoveAll(q=> idsToRemove.Contains(q.Id));
                //add state change to questionsToLoad
                questionsToLoad.AddRange(stateChange);
                //add state change to existing
                questionAnswers.AddRange(questionsToLoad);
            }
            foreach (var question in questionsToLoad)
            {
                Answers.NullGuard();
                var builderAnswer = Answers.GetAnswer(question.questionAlias ?? throw new NullReferenceException());
                if(builderAnswer.targetType != null)
                {
                    if(builderAnswer.targetType ==typeof(HydratorUtil))
                    {
                        builderAnswer.variableName.NullGuard("variableName");
                        var targetProp = builderAnswer.targetType.GetProperty(builderAnswer.variableName) ?? throw new NullReferenceException($"property not found: {builderAnswer.variableName} in {builderAnswer.targetType.Name}");
                        question.response = targetProp.GetValue(hydrator, null);
                        hydrator.Hydrate(question.response);
                    }
                    else
                    {
                        throw new NotImplementedException($"{builderAnswer.targetType.Name} not implemented");
                    }
                }
                else if(builderAnswer.variableName!= null)
                {
                    question.response = hydrator.Interpreter.Eval(builderAnswer.variableName);
                }
                else
                {
                    // if question is multi-select type and response is empty
                    // then a null is sent to apollo because the UI fails with an empty string
                    if(question.questionType==70 && builderAnswer._response is string str && str ==string.Empty)
                    {
                        question.response = null;
                    }
                    else
                    {
                        question.response = builderAnswer._response;
                    }
                }

                if(builderAnswer.AsJsonStr)
                {
                    question.response.NullGuard();
                    question.response = JToken.FromObject(question.response).ToString(Newtonsoft.Json.Formatting.None);
                }
            }

        }


        private static int counter = 0;
        private static List<QuestionResponse> StateChangeUntilHydrated(this List<QuestionResponse> questionResponses, HydratorUtil hydrator, PropertyInfo propInfo)
        {
            var quote = hydrator.Quote;
            AnswersBase answers = GetAnswers(hydrator, propInfo);
            var entity = GetEntityInContext(hydrator, propInfo);

            var body = new JObject()
            {
                {"entityType", 4500 },
                {"id", quote.Id },
                {"otherResponses", questionResponses.ToJToken() },
                {"entityContext", new JObject() }
            };

            if (entity != null)
            {
                string entityContextName = entity switch
                {
                    Driver => "Driver",
                    Vehicle=> "Vehicle",
                    Party p => p.PartyTypeId == (int)PartyType.ADDITIONALINTEREST ? "AdditionalInterest": throw new NotImplementedException($"entityContextName not implemented for party type Id: {p.PartyTypeId}"),
                    PriorClaim=> "PriorClaim",
                    Location=> "Location",
                    Building=> "Building",
                    _ => throw new NotImplementedException("Please enter the property key added to this risk api/questionresponse/questionstatechanges request object under entityContext"),
                };

                JObject entityContext = (JObject)(body["entityContext"] ?? throw new NullReferenceException());

                if (entity is IRiskEntity riskEntity)
                {
                    hydrator.Hydrate(riskEntity);
                    entityContext.Add(entityContextName, riskEntity?.ToJToken()?? throw new NullReferenceException());
                    entityContext.Add("ApplicationRisk", new JObject() { { entityContextName.ToLower(), riskEntity?.ToJToken() } });
                }
                else
                {
                    entityContext.Add(entityContextName, entity.ToJToken());
                }
                body.Add("policyLevel", true);


            }
            List<QuestionResponse>? response;
            try
            {
                response = ((JArray?)quote.RestAPI.POST("/questionresponse/questionstatechanges", body))?.ToObject<List<QuestionResponse>>();
            }
            catch
            {
                Thread.Sleep(1000);
                response = ((JArray?)quote.RestAPI.POST("/questionresponse/questionstatechanges", body))?.ToObject<List<QuestionResponse>>();
            }
            response.NullGuard();
            if (response.Any() && IsThereChange(questionResponses, response))
            {
                questionResponses.LoadAnswers(hydrator, answers, response);
                counter++;
                if(counter==10)
                {
                    throw new Exception("went through 20 state changes and it's still returning a quesiton");
                }
                return questionResponses.StateChangeUntilHydrated(hydrator, propInfo);
            }
            else
            {
                return questionResponses;
            }
        }

        private static bool IsThereChange(List<QuestionResponse> existing, List<QuestionResponse> stateChange)
        {
            foreach(QuestionResponse response in stateChange)
            {
                QuestionResponse? matchingResponse = existing.FirstOrDefault(r => r.questionId == response.questionId);

                if (matchingResponse == null || matchingResponse.isHidden != response.isHidden)
                {
                    // there is no question that matches the new state change
                    // or the isHidden is different on the state change
                    return true;
                }
            }

            // No new changes found
            return false;
        }

        private static Dictionary<Section, string> SectionNames = new()
        {
            {Section.Vehicles, "Vehicles" },
            {Section.Drivers, "Drivers"},
            {Section.Operations, "Operations"},
            {Section.PolicyCoverages, "Policy Coverages"},
            {Section.PolicyAddlInterest, "Policy Addl Interests"},
            {Section.PriorClaims, "Prior Claims" },
            {Section.Locations, "Locations" }

        };

    }
}
