using ApolloTests.Data.EntityBuilder.Entities;
using ApolloTests.Data.EntityBuilder.Models;
using ApolloTests.Data.EntityBuilder.QuestionAnswers;
using ApolloTests.Data.Entities.Coverage;
using ApolloTests.Data.Entities.Risk;
using HitachiQA.Helpers;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace ApolloTests.Data.EntityBuilder
{

    public static class StateChangesUtil
    {

        /// 
        /// Hydrate is called on List of question responses to trigger state changes flow
        /// 
        /// optional: 1 & 2 can be manipulated using StateChangeAttribute in this file, read more below this class
        /// 
        /// 1. load answers to be used during the process
        /// 2. load the entity in context (e.g., Vehicle, Location
        /// 3. load expected section name in the storyboard
        /// 4. Handle special cases
        ///     1. Policy coverages does not go through state changes, instead we just answer any question that needs answering and return
        ///     2. Locations section has two possible entities to laod questions from, Locations & Buildings, we determine that by current entity's type
        /// 5. using the Quote, get the initial questions for the current section
        /// 6. Load initial answers
        /// 7. Initiate the StateChange flow which will recursively call itself 
        ///     until either :
        ///         a. counter hits 20, a failure is thrown
        ///         b. No new questions come back, success!
        /// 8. some questions come back with sectionId=0, in that case we set it to the current section.
        /// 9. Assert there are no unanswered required questions
        /// 
        public static void Hydrate(this List<QuestionResponse> questionAnswers, HydratorUtil hydrator, PropertyInfo propInfo)
        {
            AnswersBase answers = GetAnswers(hydrator, propInfo);
            object? currentEntity = GetEntityInContext(hydrator, propInfo);
            string sectionName = SectionNames[hydrator.CurrentSection];

            switch(hydrator.CurrentSection)
            {
                case Section.PolicyCoverages:
                    var limit = (Limit?)currentEntity ?? throw new NullReferenceException();
                    var covQ = ((JArray?)hydrator.Quote.GetCoverageQuestions(limit.CoverageType.TypeName))?.ToObject<List<QuestionResponse>>() ?? throw new NullReferenceException();
                    questionAnswers.AddRange(covQ);
                    questionAnswers.LoadAnswers(hydrator, answers);
                    return;
                case Section.Locations:
                    sectionName = currentEntity?.GetType() == typeof(Location) ? "Locations" : "Buildings";
                    break;
            }
           

            var questions = ((JArray?)hydrator.Quote.GetSectionQuestions(sectionName))?.ToObject<List<QuestionResponse>>() ?? throw new NullReferenceException();

            
            questionAnswers.AddRange(questions.Where(q=> !questionAnswers.Any(it=>it.QuestionId==q.QuestionId)));

            

            questionAnswers.LoadAnswers(hydrator, answers);
            counter = 0;
            questionAnswers.StateChangeUntilHydrated(hydrator, propInfo);

            if (questionAnswers.Any(q=> q.SectionId==0))
            {
                var sectionId = hydrator.Quote.Storyboard.GetSection(sectionName).Id;
                questionAnswers.ForEach(it => it.SectionId = sectionId);
            }

            questionAnswers.CheckForRequiredQuestionsThatAreNull();

        }

        private static void CheckForRequiredQuestionsThatAreNull(this List<QuestionResponse> questionAnswers)
        {
            List<QuestionResponse> RequiredQuestionsThatAreNull = new();

            foreach (var question in questionAnswers)
            {
                if(question.IsHidden??false)
                {
                    continue;
                }
                if ((question.Response == null || (question.Response is string res && res == string.Empty)) && (question.RequiresAnswer??false))
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

                    var varName = question.Alias?.Replace('-', '_') ?? throw new NullReferenceException($"Alias was null for question {question.Id}");
                    aliasesStr += $"public static string {varName} {{ get; }} = \"{question.Alias}\";\n";
                    helperStr += $"public QuestionAnswer {varName} {{ get; set; }} = new QuestionAnswer(Alias.{varName}, null);\n";
                }

                throw new Exception($"required answers answered with null. please use the code below to fill them out \n\n on QuestionAnswers.QuestionAnswer \n{aliasesStr} \n\nunder QuestionAnswers: \n{helperStr}");
            }

        }

        private static void LoadAnswers(this List<QuestionResponse> questionAnswers, HydratorUtil hydrator, AnswersBase Answers, List<QuestionResponse>? stateChange=null)
        {
            // load answers into questionAnswers


            //list to keep track of the question that need to be loaded
            List<QuestionResponse> questionsToLoad= new List<QuestionResponse>();

            //if statechage==null, then this is the initial call. we will just load everything
            if (stateChange == null)
            {
               questionsToLoad.AddRange(questionAnswers.Where(q=> !q.IsHidden??false));
            }
            else
            {
                //load state change ids
                var idsToRemove = stateChange.Select(it => it.Id);
                //remove state change from existing
                questionAnswers.RemoveAll(q=> idsToRemove.Contains(q.Id));
                //add state change to questionsToLoad, so we know to answer them
                questionsToLoad.AddRange(stateChange);
                //add state change to existing
                questionAnswers.AddRange(questionsToLoad);
            }

            //iterate through each quesiton that needs answering and answer them
            foreach (var question in questionsToLoad)
            {
                Answers.NullGuard();
                //getting the answer object (NOT THE MODEL)
                var builderAnswer = Answers.GetAnswer(question.QuestionAlias ?? throw new NullReferenceException());

               

                object response;

                if (builderAnswer.targetType != null)
                {
                    //some question answers have a target type as attribute
                    //
                    // for example Vehicle question, we want to answer with HydratorUtil's CurrentEntity
                    //  [HydratorAttr(typeof(HydratorUtil), "CurrentEntity", AsJsonStr =true)]
                    //
                    if (builderAnswer.targetType ==typeof(HydratorUtil))
                    {
                        builderAnswer.variableName.NullGuard("variableName");
                        var targetProp = builderAnswer.targetType.GetProperty(builderAnswer.variableName) ?? throw new NullReferenceException($"property not found: {builderAnswer.variableName} in {builderAnswer.targetType.Name}");
                        response = targetProp.GetValue(hydrator, null);
                        hydrator.Hydrate(response);
                    }
                    else
                    {
                        throw new NotImplementedException($"{builderAnswer.targetType.Name} not implemented");
                    }
                }
                else if (builderAnswer.variableName!= null)
                {
                    //
                    // Example: 
                    // [HydratorAttr("StateCode")] will load the varialbeName
                    //
                    response = hydrator.Interpreter.Eval(builderAnswer.variableName);
                }
                else
                {
                    // if question is multi-select type and response is empty
                    // then a null is sent to apollo because the UI fails with an empty string
                    if(question.QuestionType==70 && builderAnswer._response is string str && str ==string.Empty)
                    {
                        response = null;
                    }
                    else
                    {
                        response = builderAnswer._response;
                    }
                }

                //if the response needs to be sent as a raw string, then we convert it to it
                if (builderAnswer.AsJsonStr)
                {
                    response.NullGuard();
                    response = JToken.FromObject(response).ToString(Newtonsoft.Json.Formatting.None);
                }

                question.Response = (String)response;


            }

        }


        /// 
        /// 7. Initiate the StateChange flow which will recursively call itself 
        ///     until either :
        ///         a. counter hits 20, a failure is thrown
        ///         b. No new questions come back, success!
        ///         
        ///     1. load answers
        ///     2. load entity in context
        ///     3. create the body to call state changes
        ///         3.1. if there is an entity, load it's property name to be set the JSON body
        ///         3.2. if the entity is a risk, then we have to load the risk model
        ///     4. send state changes request, retry if failed
        ///     5. if any valid questions came back
        ///         5.1. load those question's answers
        ///         5.2. recursively call self
        ///     6. Finally, questionResponses list is fully hydrated
        /// 
        ///



        private static int counter = 0;
        private static void StateChangeUntilHydrated(this List<QuestionResponse> questionResponses, HydratorUtil hydrator, PropertyInfo propInfo)
        {
            //         
            //     1. load answers
            //     2. load entity in context
            //
            var quote = hydrator.Quote;
            AnswersBase answers = GetAnswers(hydrator, propInfo);
            var entity = GetEntityInContext(hydrator, propInfo);

            //
            //     3. create the body to call state changes
            //         3.1. if there is an entity, load it's property name to be set the JSON body
            //         3.2. if the entity is a risk, then we have to load the risk model
            //
            var body = new JObject()
            {
                {"entityType", 4500 },
                {"id", quote.Id },
                {"otherResponses", questionResponses.ToJToken() },
                {"entityContext", new JObject() }
            };

            if (entity != null)
            {
                //
                //     3.1. if there is an entity, load it's property name to be set the JSON body
                //
                string entityContextName = entity switch
                {
                    Driver => "Driver",
                    Vehicle=> "Vehicle",
                    Party p => p.PartyTypeId == (int)PartyType.ADDITIONALINTEREST ? "AdditionalInterest": throw new NotImplementedException($"entityContextName not implemented for party type Id: {p.PartyTypeId}"),
                    PriorClaim=> "PriorClaim",
                    Location=> "Location",
                    Building=> "Building",
                    Tool => "Tool",
                    _ => throw new NotImplementedException("Please enter the property key added to this risk api/questionresponse/questionstatechanges request object under entityContext"),
                };

                JObject entityContext = (JObject)(body["entityContext"] ?? throw new NullReferenceException());

                //
                //     3.2. if the entity is a risk, then we have to load the risk model
                //
                if (entity.IsRiskEntity())
                {
                    hydrator.Hydrate(entity);
                    entityContext.Add(entityContextName, entity?.ToJToken()?? throw new NullReferenceException());
                    entityContext.Add("ApplicationRisk", new JObject() { { entityContextName.ToLower(), entity?.ToJToken() } });
                }
                else
                {
                    entityContext.Add(entityContextName, entity.ToJToken());
                }
                body.Add("policyLevel", true);


            }

            //
            //     4. send state changes request, retry if failed
            //
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

            //
            //     5. if any valid questions came back
            //
            if (response.Any() && response.Any(it => (it.Response==null) || (it.Response is string str && str == string.Empty)))
            {
                //
                //         5.1. load those question's answers
                //
                questionResponses.LoadAnswers(hydrator, answers, response);
                counter++;
                if(counter==20)
                {
                    Log.Debug($"current answers: \n {Log.stringify(questionResponses)} \n current answers end ---");
                    throw new Exception($"went through 20 state changes and it's still returning a quesiton \n {Log.stringify(response)}");
                }

                //
                //         5.2. recursively call self
                // 
                questionResponses.StateChangeUntilHydrated(hydrator, propInfo);
            }
            //
            //     6. Finally, questionResponses list is fully hydrated
            //
            return;
        }


        /// <summary>
        /// if StateChangeAttribute is present, load the answers
        /// </summary>
        /// <param name="hydratorUtil"></param>
        /// <param name="propInfo"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        private static AnswersBase GetAnswers(HydratorUtil hydratorUtil, PropertyInfo propInfo)
        {
            var att = propInfo.GetAttr();
            if (att != null)
                return hydratorUtil.Interpreter.Eval<AnswersBase>(att.TargetAnswers);

            return hydratorUtil.CurrentAnswers ?? throw new NullReferenceException("current answers was null in the interpreter but List<QuestionResponse> found. you can also use HydratorAttr to explicitly point a AnswerBase object");
        }
        /// <summary>
        /// if StateChangeAttribute is present, load the entity
        /// </summary>
        /// <param name="hydratorUtil"></param>
        /// <param name="propInfo"></param>
        /// <returns></returns>
        private static object? GetEntityInContext(HydratorUtil hydratorUtil, PropertyInfo propInfo)
        {
            var att = propInfo.GetAttr();
            if (att != null)
                return att.TargetSectionEntity == null ? null : hydratorUtil.Interpreter.Eval(att.TargetSectionEntity);

            return hydratorUtil.CurrentEntity;
        }
        private static StateChangeAttribute? GetAttr(this PropertyInfo propInfo) => propInfo?.GetCustomAttribute<StateChangeAttribute>();




        private static Dictionary<Section, string> SectionNames = new()
        {
            {Section.Vehicles, "Vehicles" },
            {Section.Drivers, "Drivers"},
            {Section.Operations, "Operations"},
            {Section.PolicyCoverages, "Policy Coverages"},
            {Section.PolicyAddlInterest, "Policy Addl Interests"},
            {Section.AdditionalInterests, "Additional Interests"},
            {Section.PriorClaims, "Prior Claims" },
            {Section.Locations, "Locations" },
            {Section.Tools, "Tools" },

        };

        private static bool IsRiskEntity(this object obj)
        {
            if (   obj is Vehicle
                || obj is Driver 
                || obj is Location 
                || obj is Building)
            {
                return true;
            }
            return false;
        }

    }
    /// <summary>
    /// Sometimes we need to explicitly point to the Answers and Entity to be sent with statechanges <br/>
    /// E.g., for Building, it has location object as a children <br/>
    /// then, it caused an infinite loop because this tool loaded Building instead of Location, thus loading location again <br/> 
    /// <br/>
    /// EXAMPLE: <br/>
    /// <br/>
    /// Given that LocationRisk has been loaded in the Hydrators interpreter, we can do: <br/><br/>
    /// <code>
    ///  [StateChange("LocationRisk.QuestionAnswers", "LocationRisk.Location")]
    ///  public List&lt;QuestionResponse&gt; QuestionResponses { get; set; } = new List&lt;QuestionResponse&gt;();
    /// </code>
    /// </summary>
    public class StateChangeAttribute : Attribute
    {
        public string TargetAnswers;
        public string? TargetSectionEntity;
        public StateChangeAttribute(string targetAnswers, string? targetSectionEntity)
        {
            this.TargetAnswers = targetAnswers;
            this.TargetSectionEntity = targetSectionEntity;
        }
    }
}
