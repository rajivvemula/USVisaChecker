using ApolloTests.Data.EntityBuilder.Entities;
using HitachiQA.Helpers;
using Newtonsoft.Json.Linq;


namespace ApolloTests.Data.EntityBuilder
{
    public static class StateChangesUtil
    {
        public static void Hydrate(this List<QuestionResponse> questionAnswers, HydratorUtil hydrator)
        {
            string sectionName = SectionNames[hydrator.CurrentSection];
            if (hydrator.CurrentSection == Section.PolicyCoverages)
            {
                var limit = (Limit?)hydrator.CurrentEntity ?? throw new NullReferenceException();
                var covQ = ((JArray?)hydrator.Quote.GetCoverageQuestions(limit.coverageType.Name))?.ToObject<List<QuestionResponse>>() ?? throw new NullReferenceException();
                questionAnswers.AddRange(covQ);
                questionAnswers.LoadAnswers(hydrator);
                return;
            }

            var questions = ((JArray?)hydrator.Quote.GetSectionQuestions(sectionName))?.ToObject<List<QuestionResponse>>() ?? throw new NullReferenceException();
            questionAnswers.AddRange(questions);

            

            questionAnswers.LoadAnswers(hydrator);
            counter = 0;
            questionAnswers.StateChangeUntilHydrated(hydrator);

        }

        private static void LoadAnswers(this List<QuestionResponse> questionAnswers, HydratorUtil hydrator, List<QuestionResponse>? stateChange=null)
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
                hydrator.CurrentAnswers.NullGuard();
                var builderAnswer = hydrator.CurrentAnswers.GetAnswer(question.questionAlias ?? throw new NullReferenceException());
                if(builderAnswer.targetType != null)
                {
                    if(builderAnswer.targetType ==typeof(HydratorUtil))
                    {
                        builderAnswer.variableName.NullGuard("variableName");
                        var targetProp = builderAnswer.targetType.GetProperty(builderAnswer.variableName) ?? throw new NullReferenceException($"property not found: {builderAnswer.variableName}");
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
                    question.response = builderAnswer._response;
                }

                if(builderAnswer.AsJsonStr)
                {
                    question.response.NullGuard();
                    question.response = JToken.FromObject(question.response).ToString(Newtonsoft.Json.Formatting.None);
                }
            }

        }


        private static int counter = 0;
        private static List<QuestionResponse> StateChangeUntilHydrated(this List<QuestionResponse> questionResponses, HydratorUtil hydrator)
        {
            var quote = hydrator.Quote;
            var section = hydrator.CurrentSection;
            var entity = hydrator.CurrentEntity;

            var body = new JObject()
            {
                {"entityType", 4500 },
                {"id", quote.Id },
                {"otherResponses", questionResponses.ToJToken() },
                {"entityContext", new JObject() }
            };

            if (entity != null)
            {
                string entityContextName = section switch
                {
                    Section.Drivers => "Driver",
                    Section.Vehicles => "Vehicle",
                    Section.PolicyAddlInterest => "AdditionalInterest",
                    _ => throw new NotImplementedException("Please enter the property key added to this risk statechange request under entityContext"),
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
                questionResponses.LoadAnswers(hydrator, response);
                counter++;
                if(counter==10)
                {
                    throw new Exception("went through 20 state changes and it's still returning a quesiton");
                }
                return questionResponses.StateChangeUntilHydrated(hydrator);
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

        };

    }
}
