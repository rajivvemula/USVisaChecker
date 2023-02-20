using ApolloTests.Data.TestData.Params;
using ApolloTests.Data.TestData;
using ApolloTests.Data.TestData;
using HitachiQA.Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ApolloTests.Data.Entities;

namespace ApolloTests.Data.TestData
{
    /// <summary>
    /// Class used to hydrate (load) answer objects given the default object
    /// </summary>
    public class AnswersHydrator : BaseEntity
    {
        public static JArray Operations(Entity.Quote quote, QuentionAnswerParamBase quoteQuentionAnswerParam)
            => new Hydratable(quote, "Operations", quoteQuentionAnswerParam).GetHydrated();

        public static JArray Vehicles(Entity.Quote quote, JObject vehicle, QuentionAnswerParamBase vehicleQuentionAnswerParam)
            => new Hydratable(quote, vehicle, "Vehicles", vehicleQuentionAnswerParam).GetHydrated();

        public static JArray Drivers(Entity.Quote quote, JObject driver, QuentionAnswerParamBase driverQuentionAnswerParam)
            => new Hydratable(quote, driver, "Drivers", driverQuentionAnswerParam).GetHydrated();

        public static JArray PolicyCoverages(Entity.Quote quote, JObject limitParam, QuentionAnswerParamBase policyCoverageQuentionAnswerParam)
            => new Hydratable(quote, limitParam, "Policy Coverages", policyCoverageQuentionAnswerParam).GetHydrated();

        /// <summary>
        /// Private inner class denoting a hydratable entity or section (e.g. Operations, Vehicles, Drivers)
        /// </summary>
        private class Hydratable : BaseEntity
        {
            /// <summary>
            /// Specific quote where the section lives
            /// </summary>
            public Entity.Quote quote;

            /// <summary>
            /// To store all possible questions within the specific section
            /// </summary>
            public JArray sectionQuestions;

            public Entity.Question.Section section;

            public string sectionName;

            private readonly QuentionAnswerParamBase _quentionAnswerParam;

            private Dictionary<string, JObject> entities = new Dictionary<string, JObject>();

            //constructor
            public Hydratable(Entity.Quote quote, string sectionName, QuentionAnswerParamBase quentionAnswerParam)
            {
                //load properties
                this.quote = quote;
                this.sectionName = sectionName;
                _quentionAnswerParam = quentionAnswerParam;

                //section Object
                try
                {
                    //attempt to get the section object from the quote's story board
                    section = quote.Storyboard.GetSection(sectionName);
                }
                catch (Exception ex)
                {
                    Log.Critical($"quoteId: {quote.Id} did not have sectionName: {sectionName}");
                    throw ex;
                }

                if (sectionName != "Policy Coverages")
                {
                    //section questions instance for specified quote
                    sectionQuestions = quote.GetSectionQuestions(sectionName);
                }
            }

            public Hydratable(Entity.Quote quote, JObject entity, string sectionName, QuentionAnswerParamBase quentionAnswerParam)
                : this(quote, sectionName, quentionAnswerParam)
            {
                //sections like Vehice & Drive require the actual Vehicle/Driver object to be sent as one of the answers.
                //we will store this entity in entities
                entities.Add(sectionName, entity);

                if (sectionName == "Policy Coverages")
                {
                    var limitParam = entities["Policy Coverages"];

                    sectionQuestions = quote.GetCoverageQuestions(limitParam["CoverageName"].ToString());
                }
            }

            public JArray GetHydrated()
            {
                //this will be the hydrated answers object to be sent to apollo
                var result = new JArray();

                var currentAnswersState = new JArray();

                //since this process is very chatty,
                //passing the result & state object by reference
                //This is to allow the same objects to be used across the functions
                GetSectionAnswers(ref result, ref currentAnswersState, sectionQuestions);

                if (sectionName == "Policy Coverages")
                {
                    return result;
                }

                JArray CurrentSectionQuestions;
                int counter = 0;
                do
                {
                    CurrentSectionQuestions = StateChange(quote, currentAnswersState);
                    GetSectionAnswers(ref result, ref currentAnswersState, CurrentSectionQuestions);
                    counter++;
                } while (counter < 10 && CurrentSectionQuestions.Where(it => (bool)it["isHidden"] == false).Count() > 1);

                return result;
            }

            /// <summary>
            /// <br/> This function will maintain two objects<br/>
            /// <br/> result: will be the final object to be sent, this one will contain valid answers only <br/>
            /// <br/> currentAnswersState:  state object updated in real time in order to sent to statechange <br/>
            /// <br/> state change will return any new questions that need to be answered
            /// </summary>
            /// <param name="result"></param>
            /// <param name="currentAnswersState"></param>
            /// <param name="sectionQuestions"></param>
            private void GetSectionAnswers(ref JArray result, ref JArray currentAnswersState, JArray sectionQuestions)
            {
                //iterate through all possible questions within the specific section
                foreach (JObject question in sectionQuestions)
                {
                    var answer = GetAnswer(question);

                    bool newResult = result.Where(it => it["questionId"].ToObject<int>() == answer["questionId"].ToObject<int>()).Count() == 0;

                    if (((JValue)answer["response"]).Value != null)
                    {
                        var toRemoveStateObject = currentAnswersState.Where(it => it["questionId"].ToObject<int>() == answer["questionId"].ToObject<int>());
                        var toRemoveResultObject = result.Where(it => it["questionId"].ToObject<int>() == answer["questionId"].ToObject<int>());

                        foreach (var removable in toRemoveStateObject.ToList())
                        {
                            if (!currentAnswersState.Remove(removable))
                            {
                                throw new Exception($"Failed to remove answer {removable} from {currentAnswersState}");
                            }
                        }
                        foreach (var removable in toRemoveResultObject.ToList())
                        {
                            if (!result.Remove(removable))
                            {
                                throw new Exception($"Failed to remove answer {removable} from {result}");
                            }
                        }

                        result.Add(answer);
                        currentAnswersState.Add(answer);
                    }
                    else if (newResult)
                    {
                        result.Add(answer);
                        currentAnswersState.Add(answer);
                    }
                }
            }

            /// <summary>
            /// <br/> given a quesiton object,
            /// <br/> this function will retrieve it's default answer using the alias property
            /// <br/> then return an answer object
            /// </summary>
            /// <param name="question">desc</param>
            /// <returns></returns>
            private JObject GetAnswer(JObject question)
            {
                String alias = null;

                //because quote sections & state change responses have different alias property
                //we will use any of the two
                if (question.ContainsKey("alias"))
                {
                    alias = question["alias"]?.ToString();
                }
                else if (question.ContainsKey("questionAlias"))
                {
                    alias = question["questionAlias"]?.ToString();
                }

                if (string.IsNullOrWhiteSpace(alias))
                {
                    throw new Exception($"Null/Blank alias for question: {question}");
                }

                var obj = new JObject();

                //because quote sections & state change responses have different Id property
                //we will use any of the two
                if (question.ContainsKey("id"))
                {
                    obj.Add("questionId", question["id"].ToObject<long>());
                    obj.Add("questionType", question["questionType"].ToObject<int>());
                }
                else
                {
                    obj.Add("questionId", question["questionId"].ToObject<long>());
                    obj.Add("questionType", (int)SQL.executeQuery($"SELECT QuestionType  FROM [question].[QuestionDefinition] where Id = {question["questionId"]};")[0]["QuestionType"]);
                }

                obj.Add("isHidden", question["isHidden"].ToObject<bool>());
                obj.Add("sectionId", section.Id);
                obj.Add("questionAlias", alias);

                //attempt to get the default answer using the question's alias

                var answer = _quentionAnswerParam.GetAnswer(alias);
                var response = answer._response;

                //we are only going to answer questions that are not hidden in the UI
                // or flagged PopulateWhenHidden=true
                if (!string.IsNullOrWhiteSpace(response) && (!(bool)obj["isHidden"] || answer.PopulateWhenHidden))
                {
                    //if the answer happens to be @SectionEntity
                    //this means we're refering to the section's corresponding object within entities
                    // check if it's a string
                    if (response is string && response == "@SectionEntity")
                    {
                        try
                        {
                            obj.Add("response", entities[sectionName].ToString(Newtonsoft.Json.Formatting.None));
                        }
                        catch (Exception ex)
                        {
                            Log.Critical($"Hydrator - adding entity for Section: {sectionName} error, Entities: {entities}");
                            throw ex;
                        }
                    }
                    //if the response is a string and it starts with JSON,
                    //then it means that we want to add it as is. a JSON string and not parse it iinto a json object
                    else if (response is string && ((string)response).StartsWith("JSON"))
                    {
                        //JSON start of the string is just an identifier,
                        //we will remove this
                        obj.Add("response", ((string)response).Replace("JSON", ""));
                    }
                    //else, whatever object it is will be converted into a Json object
                    //integers, booleans, arrays or even nested Json objects
                    else
                    {
                        obj.Add("response", JToken.FromObject(response));
                    }
                    return obj;
                }
                else
                {
                    obj.Add("response", null);

                    //because isHidden might change to false on certain quesitons depending on previous answers
                    //
                    //we should send a /questionresponse/statechanges call to Apollo,
                    //
                    //it would return whether the question is now required or not
                    //
                }
                return obj;
            }

            /// <summary>
            /// Using the current answers, this function returns new questions that might've been enabled for answering
            /// </summary>
            /// <param name="quote"></param>
            /// <param name="CurrentAnswers"></param>
            private JArray StateChange(Entity.Quote quote, JArray CurrentAnswers)
            {
                var body = new JObject()
                {
                    {"entityType", 4500 },
                    {"id", quote.Id },
                    {"otherResponses", CurrentAnswers },
                    {"entityContext", new JObject() }
                };

                if (sectionName == "Vehicles")
                {
                    var vehicle = entities[sectionName];
                    body["entityContext"] = new JObject()
                                            {
                                                { "ApplicationRisk", new JObject()
                                                    {
                                                        { "outputMetadata", new JObject()
                                                            {
                                                                {"VehicleDriverLocation", new JObject()
                                                                        {
                                                                        { "locationId", quote.PrimaryAddress.Id }
                                                                    }
                                                                }
                                                            }
                                                        },
                                                        { "riskId", vehicle["riskId"] },
                                                        { "riskType", 1 },
                                                        { "timeFrom", DateTime.Now.ToString("O") },
                                                    }
                                                },
                                                {"Vehicle", vehicle }
                                            };
                }

                dynamic response;
                try
                {
                    response = RestAPI.POST("/questionresponse/questionstatechanges", body);
                }
                catch
                {
                    Thread.Sleep(1000);
                    response = RestAPI.POST("/questionresponse/questionstatechanges", body);
                }

                return response;
            }
        }
    }
}