using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using ApolloQA.Data.Entity;
using System.Linq;
using ApolloQA.Source.Helpers;
using System.Threading;

namespace ApolloQA.Data.TestData
{
    //class used to hydrate (load) answer objects given the default object
    public class AnswersHydrator
    {

        //default answers
        //Key=question alias  Value: default answer
        private static Dictionary<string, dynamic> Answers = new Dictionary<string, object>()
        {
            //
            //Operations
            //
            {"VehicleRadius", "50" },
            {"FineArt", false },
            {"Haul", "JSON[\"General Freight\"]" },
            {"Chains", false },
            {"ResidentialMoving", false },
            {"Biohazard",false },
            {"TeamDriving", false },
            {"TravelToMexico", false },
            {"ClaimCount", 0 },
            {"IL-Authority", false },
            {"SC-Authority", false },
            {"KS-Authority", false },
            {"NE-Authority", false },
            {"OK-Authority", false },
            {"OR-Authority", false },
            {"CT-Authority", false },
            {"BorrowVehicles", false },
            {"USDOT", false },
            {"USDOT#", 545167 },

            {"UseOwnerOperators", false },
            {"OnCall", false },
            {"PartyBus", false },
            {"DayCare", false },
            {"VehicleSellOrLease", false },
            {"Salvage", false },
            {"ServiceAccess", "Both on demand and pre-arranged" },
            {"Ammonia", false },
            {"Poison", false },
            {"Radioactive", false},
            {"EmergencyResponse", false },
            {"CaliOperatingAuth", false },
            {"CaliCarrier#", "765432" },
            {"PUC", false },
            {"NonOwnedGoods", false },
            {"TrailerInterchangeAgreements", false },
            {"MotorCarrierFiling", false },
            {"TXAuth", false },
            {"OwnerOperatorsPendingVehicles", false },
            {"OwnerOperatorsPendingVehiclesCost", 1000 },
            {"OwnerOperatorsBorrowCost", 1000 },
            {"HoldHarmlessAgreements", false },
            {"HoldHarmlessRequireCerts", false },
            {"FmscaOperating", false },
            {"FmscaOperatingTypes",  "Freight Forwarding"},
            
            //
            //Vehicles
            //
            {"Vehicles",                    "@SectionEntity" },
            {"TransportTours",              false},
            {"VehicleOwnedLeasedFinanced",  "Owned" },
            {"VehicleTitleOwner",           "Business" },
            {"VehicleOwner1BusinessName",   "Miguel Acosta" },
            {"VehicleTitleOwnerIndividual", "Myself"},
            {"VehicleDiffState",            false },
            {"VehicleUse",                  "Delivery/Catering"    },
            {"GoodsOrMaterialsRetail",      true},
            {"GoodsOrMaterialsBlueCollar",  true },
            {"TrailerOwnedFinancedLeased",   "Owned" },
            {"TrailerDiffState",             false },
            {"TrailerTitleOwner",            "Business" },
            {"VehicleOwner1Address",         "JSON{\"line1\":\"81 N 13th St\",\"line2\":null,\"minorMunicipality\":null,\"majorMunicipality\":\"Prospect Park\",\"postalCode\":\"07508\",\"addressTypeId\":300,\"addressType\":{\"code\":\"LOCATION\",\"name\":\"Location\",\"description\":null,\"timeFrom\":\"1901-01-01T00:00:00.000Z\",\"timeTo\":\"2999-01-01T00:00:00.000Z\",\"statusId\":0,\"updateDateTime\":\"2021-05-05T03:53:36.930Z\",\"updatedBy\":\"bbadmin\",\"updatedByPersonId\":null,\"insertDateTime\":\"2021-04-14T23:52:01.286Z\",\"insertedBy\":\"bbadmin\",\"insertedByPersonId\":-1,\"id\":300,\"resource\":\"LookupResource\"},\"stateProvinceId\":200,\"stateProvince\":{\"code\":\"NJ\",\"name\":\"New Jersey\",\"description\":null,\"statusId\":0,\"updatedBy\":null,\"updatedByPersonId\":null,\"insertDateTime\":\"0001-01-01T00:00:00.000Z\",\"insertedBy\":null,\"insertedByPersonId\":0,\"id\":200,\"resource\":\"StateProvinceResource\"},\"countryId\":0,\"country\":{\"code\":\"USA\",\"name\":\"United States\",\"description\":null,\"statusId\":0,\"updatedBy\":null,\"updatedByPersonId\":null,\"insertDateTime\":\"0001-01-01T00:00:00.000Z\",\"insertedBy\":null,\"insertedByPersonId\":0,\"id\":0,\"resource\":\"CountryResource\"},\"countyName\":\"Passaic\",\"countyFips\":\"34031\",\"smartyStreetDocumentId\":17410,\"smartyStreetDocumentIndex\":0,\"logicId\":null,\"version\":null,\"statusId\":0,\"updatedBy\":null,\"updatedByPersonId\":null,\"insertDateTime\":\"0001-01-01T00:00:00.000Z\",\"insertedBy\":null,\"insertedByPersonId\":0,\"resource\":\"AddressResource\"}"} ,

            //
            //Drivers
            //
            {"ExcludeDriver",                   false},
            {"AccidentOrViolation",             false },
            {"IL-DefensiveDriving",             true },
            {"IL-LastYearViolation",            false },
            {"IL-Last3YearsLicenseSuspended",   false },
            {"CDL",                             "0" },
            {"DefensiveDriving",                false },


        };

        public static JArray Operations(Entity.Quote quote) => new Hydratable(quote, "Operations").GetHydrated();
        public static JArray Vehicles(Entity.Quote quote, JObject vehicle) => new Hydratable(quote, vehicle, "Vehicles").GetHydrated();
        public static JArray Drivers(Entity.Quote quote, JObject driver) => new Hydratable(quote, driver, "Drivers").GetHydrated();

        //private inner class denoting a hydratable entity or section (e.g. Operations, Vehicles, Drivers)
        private class Hydratable
        {
            //specific quote where the section lives
            public Entity.Quote quote;
            //to store all possible questions within the specific section
            public JArray sectionQuestions;

            public Entity.Question.Section section;
            public string sectionName;
            Dictionary<string, JObject> entities = new Dictionary<string, JObject>();

            //constructor
            public Hydratable(Entity.Quote quote, string sectionName)
            {
                //load properties
                this.quote = quote;
                this.sectionName = sectionName;
                //section Object
                try
                {
                    //attempt to get the section object from the quote's story board
                    this.section = quote.Storyboard.GetSection(sectionName);

                }
                catch (Exception ex)
                {
                    Log.Critical($"quoteId: {quote.Id} did not have sectionName: {sectionName}");
                    throw ex;
                }
                //section questions instance for specified quote
                this.sectionQuestions = quote.GetSectionQuestions(sectionName);
            }


            //this constructor runs (preceding) constructor before running
            public Hydratable(Entity.Quote quote, JObject entity, string sectionName) : this(quote, sectionName)
            {
                //sections like Vehice & Drive require the actual Vehicle/Driver object to be sent as one of the answers.
                //we will store this entity in entities
                entities.Add(sectionName, entity);
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

                JArray CurrentSectionQuestions;
                int counter = 0;
                do
                {
                    CurrentSectionQuestions = StateChange(quote, currentAnswersState);
                    GetSectionAnswers(ref result, ref currentAnswersState, CurrentSectionQuestions);
                    counter++;
                } while (counter<10 && CurrentSectionQuestions.Where(it=>(bool)it["isHidden"] == false).Count()>1);

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

                    if (((JValue)answer["response"]).Value != null && newResult)
                    {
                        result.Add(answer);

                        var toRemove = currentAnswersState.Where(it => it["questionId"].ToObject<int>() == answer["questionId"].ToObject<int>());

                        foreach (var removable in toRemove.ToList())
                        {
                            if (!currentAnswersState.Remove(removable))
                            {
                                throw new Exception($"Failed to remove answer {removable} from {currentAnswersState}");
                            }
                        }

                        currentAnswersState.Add(answer);

                    }
                    else if(currentAnswersState.Where(it => it["questionId"].ToObject<int>() == answer["questionId"].ToObject<int>()).Count() == 0)
                    {
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
                if(question.ContainsKey("alias"))
                {
                    alias = question["alias"]?.ToString();
                }
                else if(question.ContainsKey("questionAlias"))
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


                //we are only going to answer questions that are not hidden in the UI
                if (Answers.ContainsKey(alias) && !(bool)obj["isHidden"])
                {
                    //attempt to get the default answer using the question's alias
                    var response = Answers[alias];

                    //if the answer happens to be @SectionEntity
                    //this means we're refering to the section's corresponding object within entities
                    // check if it's a string
                    if (response is string && response == "@SectionEntity")
                    {
                        try
                        {
                            obj.Add("response", entities[sectionName].ToString());
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
            /// <returns></returns>
            private JArray StateChange(Entity.Quote quote, JArray CurrentAnswers)
            {
              
                var body = new JObject()
                {
                    {"applicationId", quote.Id },
                    {"otherResponses", CurrentAnswers },
                    {"entityContext", new JObject() }
                };

                if(sectionName == "Vehicles")
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
                                                                        { "locationId", quote.PhysicalAddress.Id }
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
                    response = RestAPI.POST("/questionresponse/statechanges", body);
                }
                catch
                {
                    Thread.Sleep(1000);
                    response = RestAPI.POST("/questionresponse/statechanges", body);
                }

               

                return response;
            }
            


        }
    }

    




}
