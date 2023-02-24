using ApolloTests.Data.TestData;
using ApolloTests.Data.Entities;
using ApolloTests.Data.Entity;
using HitachiQA.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using Quote = ApolloTests.Data.Entity.Quote;
using static ApolloTests.Data.Entity.Policy;
using DocumentFormat.OpenXml.Presentation;

namespace ApolloTests.Data.Form
{
    public class Condition:BaseEntity
    {
        public String stateCode;
        public List<Entity.CoverageType> coverageTypes;
        //Key=alias value=response
        public Dictionary<string, string> questionResponses;
        public Boolean splitLimitBIPD;
        public Boolean endorsement;
        public Boolean materializedBillToday;
        public Boolean canceled;
        public Boolean canceledFuture;
        public Boolean reinstated;
        public Dictionary<string, string> vehicle;
        public List<string> recipients;

        public Condition() { }
        

        /**
         * used by Data.Forms.Form.cs to parse the conditions from Data.Forms.Form.json for each specific form
         */
        [JsonConstructor]
        public Condition(String stateCode, List<string> coverageTypes, Dictionary<string, string> questionResponses, Boolean splitLimitBIPD, Boolean endorsement, Boolean materializedBillToday,Boolean canceled, Boolean canceledFuture, Boolean reinstated, Dictionary<string, string> vehicle)
        {
            this.stateCode = stateCode?.ToUpper();
            this.coverageTypes = coverageTypes == null ? new List<CoverageType>(): coverageTypes.Select(it => new CoverageType(it)).ToList();
            this.questionResponses = questionResponses;
            this.splitLimitBIPD = splitLimitBIPD;
            this.endorsement = endorsement;
            this.materializedBillToday = materializedBillToday;
            this.canceled = canceled;
            this.vehicle = vehicle;
            this.reinstated = reinstated;
        }
        

        /// <summary>
        /// this function iterates through all valid policies in order to find one that matches this object's properties
        /// </summary>
        /// <returns>Policy that matches all the properties in the object context</returns>
        /**
         *  1.) for each valid RatableObject (Policy) in the system (issued and not archived)
         *  2.)    var policyOBJ is the cosmos object of the policy in context
         *  3.)    let match = true  (will be set to false on any mismatch with the policy in context and this object's properties)
         *  4.)    initialize the policy and quote objects usign the cosmos objects
         *  
         *  5.)    if StateCode was provided and if the governing state from the policy is not equal to the StateCode provided turn flag off and continue to the next iteration (policy)
         *  6.)    if <PropertyName> was provided, call Check<PropertyName> function sending in the match object by reference 
         *         note: ref keyword sends in the object's memory location rather than the value, 
         *         meaning that if it match=false; occurs on the called function, the value of match in GetValidPolicy() will also change to false
         *         
         *  7.)    finally, if the match flag is still true, return the policy in context
         *         note:it means we have a policy that matches all of the properties in this object
         *  
         *  
         *  
         *  
         */
        public Policy GetValidPolicy(bool createNewQuote = false)
        {
            if(!createNewQuote)
            {
                var policy = findPolicyForThis();
                if (policy != null)
                {
                    return policy;
                }
            }

            return this.CreateQuoteForThis();

            throw new NotImplementedException($"No policy was found in the system for {this} \nFunction to create quote for given condition needs to be implemented");
        }

        public Policy? findPolicyForThis()
        {
            
            var conditions = new List<string>();
            var validTetherIds = new List<long>();

            if (string.IsNullOrWhiteSpace(this.stateCode))
            {
                var tetherIds = SQL.executeQuery(@$"SELECT Id as TetherId FROM [tether].[Tether] 
                                where 
                                EffectiveDate <= GETDATE() AND ExpirationDate >= GETDATE() 
                                AND GoverningStateId = 1
                                AND PolicyNumber is not null").Select(it=> (long)it["TetherId"]);
                validTetherIds.AddRange(tetherIds);
            }
            else
            {
                var stateId = SQL.executeQuery(@$"SELECT Id  
                                     FROM [location].[StateProvince]
                                     Where Code='{this.stateCode}';")[0]["Id"];

                var tetherIds = SQL.executeQuery(@$"SELECT Id as TetherId FROM [tether].[Tether] 
                                where 
                                EffectiveDate <= GETDATE() AND ExpirationDate >= GETDATE() 
                                AND GoverningStateId = {stateId}
                                AND PolicyNumber is not null").Select(it => (long)it["TetherId"]);
                validTetherIds.AddRange(tetherIds);

            }

            if (this.coverageTypes != null && this.coverageTypes.Any())
            {
                foreach (var type in this.coverageTypes)
                {
                    conditions.Add($"ARRAY_CONTAINS(c.SelectedCoverages, {{ \"CoverageTypeId\": {type.Id} }}, true) ");
                }

            }
            if (this.questionResponses != null && this.questionResponses.Any())
            {
                foreach (var response in this.questionResponses)
                {
                    var alias = response.Key;
                    var res = response.Value;
                    conditions.Add($"ARRAY_CONTAINS(c.QuestionResponses, {{ \"QuestionAlias\": \"{alias}\", \"Response\": {res} }}, true) ");

                }
            }
            if (this.splitLimitBIPD)
            {
                var type = new CoverageType(CoverageType.BIPD);
                conditions.Add($"ARRAY_CONTAINS(c.SelectedCoverages, {{ \"CoverageTypeId\": {type.Id},  \"SelectedLimitName\": \"Split Limit\"}}, true) ");

            }
            if(this.recipients!=null)
            {
                if(recipients.Contains("ADDITIONALINTEREST"))
                {
                    conditions.Add($"ARRAY_LENGTH(c.AdditionalInterests)>0");
                }

                //load if we need lienholder, lessor or both!
                bool lienHolder = recipients.Contains("LIENHOLDER");
                bool lessor = recipients.Contains("LESSOR");
                bool both = lienHolder && lessor;

                //if lienholder or lessor are needed
                if (lienHolder || lessor)
                {
                    //get all risks that have lienholder or lessor as answer
                    var vehicleQuery = "SELECT VALUE c FROM c JOIN r IN c.QuestionResponses WHERE STARTSWITH(c.id, \"RiskEntity\")  AND c.RiskTypeId = 1  AND r.QuestionAlias = \"VehicleOwnedLeasedFinanced\"  and (r.Response =\"Financed\" or r.Response=\"Leased\")";
                    vehicleQuery+= $"AND c.TetherId in ({string.Join(",", validTetherIds)})";
                    var validRisks = Cosmos.GetQuery("Tether", vehicleQuery).Result.ToObject<List<JObject>>();

                    //to load all resulting valid tethers
                    var tethers = new List<long>();
                   
                    // group all risks with their TetherId
                    // ending with a group for each tether (group is basically a list of risks associated to that tether)
                    var groups = validRisks.GroupBy(risk => risk.Value<long>("TetherId"));
                    foreach(var tetherGroup in groups)
                    {
                        //to store if this tether has financed or leased
                        bool hasFinanced = false;
                        bool hasLeased = false;

                        //iterate through each risk associated to this tether
                        foreach (var risk in tetherGroup)
                        {

                            //grab the response
                            var response = risk.Value<JArray>("QuestionResponses")?.First(it => it.Value<string>("QuestionAlias") == "VehicleOwnedLeasedFinanced").Value<string>("Response")?? throw new ArgumentNullException();
                            
                            //load whether it's financed or leased
                            if (response == "Financed")
                                hasFinanced = true;
                            else if (response == "Leased")
                                hasLeased = true;
                        }

                        //if we need both, then only add if both matchd
                        if (both && hasFinanced && hasLeased)
                            tethers.Add(tetherGroup.Key);
                        //if we need 1, only add that one
                        else if(!both && lienHolder && hasFinanced)
                            tethers.Add(tetherGroup.Key);
                        //if we need 1, only add that one
                        else if (!both && lessor && hasLeased)
                            tethers.Add(tetherGroup.Key);
                    }
                    //finally, remove all previously valid tether that are no longer valid after checking this
                    validTetherIds.RemoveAll(it => !tethers.Contains(it));

                }               

            }
            if (this.endorsement)
            {
                var draftEndorsements = SQL.executeQuery(@$"SELECT Tether.Id as TetherId, TARO.RatableObjectId as draftRatableObject, TARO.ApplicationId as draftApplication 
                                                            FROM [tether].[Tether] Tether
                                                            LEFT JOIN [tether].[TetherApplicationRatableObject] TARO on TARO.TetherId=Tether.Id
                                                            where 
                                                            EffectiveDate <= GETDATE() AND ExpirationDate >= GETDATE() 
                                                            AND Tether.PolicyNumber is not null
                                                            AND TARO.StatusId={(int)EntityStatusEnum.Draft}
                                                            AND RatableObjectId is not null;");


                var tethers = draftEndorsements.Select(it => (long)it["TetherId"]);


                validTetherIds.RemoveAll(it => !tethers.Contains(it));
                
            }
            if (this.materializedBillToday)
            {
                var tethers = MaterializedBills.Select(it => (long)it["TetherId"]);
                validTetherIds.RemoveAll(it => !tethers.Contains(it));

            }
            if (this.canceled)
            {
                var canceled = SQL.executeQuery("SELECT Id as TetherId FROM [tether].[Tether] where EffectiveDate <= GETDATE() AND ExpirationDate >= GETDATE() and PolicyCancellationEffectiveDate < GETDATE();");

                var tethers = canceled.Select(it => (long)it["TetherId"]);

                validTetherIds.RemoveAll(it => !tethers.Contains(it));
            }
            if (this.canceledFuture)
            {
                var canceled = SQL.executeQuery("SELECT Id as TetherId FROM [tether].[Tether] where EffectiveDate <= GETDATE() AND ExpirationDate >= GETDATE() and PolicyCancellationEffectiveDate > GETDATE();");

                var tethers = canceled.Select(it => (long)it["TetherId"]);

                validTetherIds.RemoveAll(it => !tethers.Contains(it));
            }
            if (this.reinstated)
            {
                var reinstated = SQL.executeQuery("SELECT Id as TetherId FROM [tether].[Tether] where EffectiveDate <= GETDATE() AND ExpirationDate >= GETDATE() and PolicyReinstatementDate < GETDATE();");

                var tethers = reinstated.Select(it => (long)it["TetherId"]);

                validTetherIds.RemoveAll(it => !tethers.Contains(it));
            }
            if (this.vehicle != null)
            {
                var vehicleQuery = "SELECT * FROM c where STARTSWITH(c.id, \"RiskEntity\") and c.RiskTypeId= 1";
                var tetherConditions = new List<string>();

                foreach(var prop in this.vehicle)
                {
                    tetherConditions.Add($"Vehile.{prop.Key}={prop.Value}");
                }
                var finalVehicleQuery = $"{vehicleQuery} and {string.Join(" and ", tetherConditions)}";
                var validVehicles = Cosmos.GetQuery("Tether", finalVehicleQuery).Result;
                if (validVehicles == null)
                    validTetherIds = new List<long>();
                else
                {
                    var tethers = validVehicles.Select(it => (long)it["TetherId"]);

                    validTetherIds.RemoveAll(it => !tethers.Contains(it));
                }
            }

            if(validTetherIds.Count > 0)
            {
                conditions.Add($"c.TetherId in ({string.Join(",", validTetherIds)})");
                conditions.Add($"c.ApplicationStatusValue=\"Issued\"");
                var generatedConditionStr = string.Join(" AND ", conditions);
                var applicationQuery = $@"
                    SELECT TOP 1 * FROM c
                    WHERE {generatedConditionStr}
                    ORDER BY c.TetherId DESC";
                Log.Debug(applicationQuery);
                var result = Cosmos.GetQuery("Application", applicationQuery).Result;
                if (result.Any())
                {
                    var quote = new Quote(result[0]);
                    return quote.GetCurrentRatableObject();
                }
            }
            
            return null;
           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Policy CreateQuoteForThis()
        {
            stateCode ??= "IL";
            QuoteParam quoteParam = coverageTypes?.Any() ?? false ? new QuoteParam(stateCode, coverageTypes) : new QuoteParam(stateCode);

            if (this.questionResponses != null)
            {
                foreach (var questionAnswer in this.questionResponses)
                {
                    quoteParam.QuoteQuentionAnswerParam.SetAnswer(questionAnswer.Key, questionAnswer.Value);
                }
            }
            if(stateCode == "MI")
            {
                quoteParam.LimitParam.Limits.Find(it => it.CoverageName == CoverageType.BIPD).SetSelectedLimits(510000);
            }
            if (splitLimitBIPD)
            {
                quoteParam.BIPD_SplitLimit();
            }
            if (this.vehicle != null)
            {
                var vehicleObject = quoteParam.VehicleParam.Vehicles[0].Object;

                foreach (var prop in this.vehicle)
                {
                    vehicleObject.GetType().GetProperty(prop.Key).SetValue(vehicleObject, prop.Value, null);
                }

            }
            if (this.recipients!=null)
            {
                //additional interest is now always added by default
                if (quoteParam.AdditionalInterestParam.NumberOfAdditionalInterest<1)
                {
                    quoteParam.AdditionalInterestParam.NumberOfAdditionalInterest = 1;
                }
                if (recipients.Contains("LIENHOLDER"))
                {
                    quoteParam.VehicleParam.Vehicles[0].VehicleQuentionAnswerParam.VehicleOwnedLeasedFinanced._response = "Financed";
                }
                if (recipients.Contains("LESSOR"))
                {
                    if(recipients.Contains("LIENHOLDER"))
                    {
                        quoteParam.VehicleParam.NumberOfVehicles = 2;
                        quoteParam.VehicleParam.Vehicles[1].VehicleQuentionAnswerParam.VehicleOwnedLeasedFinanced._response = "Leased";
                    }
                    else
                    {
                        quoteParam.VehicleParam.Vehicles[0].VehicleQuentionAnswerParam.VehicleOwnedLeasedFinanced._response = "Leased";
                    }
                }
            }

            var quote = quoteParam.RunThisThroughAPI();
            var policy = quote.PurchaseThis();

            if (this.endorsement)
            {
                var endorsement = policy.CreateDraftPolicyEndorsement();
                if(policy.GetDraftEndorsements().Count ==0)
                {
                    throw new Exception("Endorsement Not Created Yet");
                }
                endorsement.CreateEndorsementHeader(policy.Id);
                endorsement.PostSummary();
                var ratableObject = endorsement.GetRatableObject();
                Log.Debug("RatableObject Id: " + ratableObject?.Id);
            }
            if (this.materializedBillToday)
            {
                var tetherId = policy.Tether.Id;
                var arrangmentBillIds = SQL.executeQuery(@$"SELECT BAAP.TetherId, AB.Id as ArrangementBillId, AB.*  
                                                            FROM [billing].[BillingAccountArrangementPolicy] BAAP
                                                            LEFT JOIN billing.ArrangementBill AB on AB.BillingAccountArrangementId = BAAP.BillingAccountArrangementId
                                                            where BAAP.TetherId={tetherId}");
                var targetArrangementBillId = arrangmentBillIds[0]["ArrangementBillId"];

                
                SQL.executeQuery(@$"update billing.ArrangementBill set TimeFrom = '{DateTime.Now.ToString("O")}', DateMailed='{DateTime.Now.ToString("O")}', UpdateDateTime='{DateTime.Now.AddHours(-2).ToString("O")}'  where Id = {targetArrangementBillId};");

                var logicAppId = SQL.executeQuery("select * from system.job where [Name]='ProcessLateBills';")[0]["Id"];

                SQL.executeQuery(@$"update j set LastRun = GETDATE(), NextRun = DATEADD(SECOND, 5, GETDATE())
                                   from system.job j where Id in ({logicAppId})");
                Thread.Sleep(7000);


             }
            //6.)    if < PropertyName > was provided, call Check<PropertyName> function sending in the match object by reference
            if (this.canceled)
            {
                Thread.Sleep(10000);
                policy.Cancel();
            }

           

            quote.CacheProps();
            policy.CacheProps();
            

            return policy;
        }

        private void CheckCoverageTypes(ref bool match, Quote quote)
        {
            var quoteCoverages = quote.getCoverageTypes(quote.GetVehicles()[0]).Select(it => it.Name);

            
            foreach (var coverage in this.coverageTypes)
            {
                // Log.Debug($"quote Id: {quote.Id} Tether: {quote.Tether.Id} "+string.Join(", ", quoteCoverages));
                if (!quoteCoverages.Contains(coverage.Name))
                {
                    match = false;
                }
            }
        }

        private void CheckQuestionResponses(ref bool match, Quote quote)
        {
            foreach (var questionResponse in this.questionResponses)
            {
                var response = quote.GetQuestionResponse(questionResponse.Key);
                
                if (response == null || response != questionResponse.Value)
                {
                    match = false;
                }
            }
        }

        private void CheckSplitLimitBIPD(ref bool match, Quote quote)
        {
            //speed can be improved by:
            //saving loading all policies and quotes with static variables
            //
            var quoteLimits = quote.getLimits(quote.GetVehicles()[0]);

            //Log.Debug(quoteLimits.Select(it => it.GetCoverageType().Name));
            var bipdLimit = quoteLimits.FirstOrDefault(it => it.GetCoverageType().Name == "Bodily Injury Property Damage (BIPD)");

            if(bipdLimit == null || bipdLimit.selectedLimitName != "Split Limit" || bipdLimit.selectedLimits.Count!=3)
            {
                match = false;
            }

            
            
        }
        public void checkEndorsement(ref bool match, Policy policy)
        {
            var draftEndorsements = policy.GetDraftEndorsements();

            if (draftEndorsements.Any())
            {
                if( draftEndorsements.Last().GetRatableObject() == null)
                {
                    match = false;
                }

            }
            else
            {
                match = false;
            }

        }

        /// <summary>
        /// this static variable holds all the valid Tether Objects that have a materialized bill for today
        /// </summary>
        private static List<Dictionary<string, dynamic>> MaterializedBills = GetSQLService().executeQuery($@"SELECT BAAP.TetherId, AB.*  
                                            FROM [billing].[BillingAccountArrangementPolicy] BAAP
                                            LEFT JOIN billing.ArrangementBill AB on AB.BillingAccountArrangementId = BAAP.BillingAccountArrangementId
                                            WHERE CONVERT(VARCHAR(10),AB.BillStatusUpdateDateTime ,110) = CONVERT(VARCHAR(10),GETDATE(),110)
                                            AND CONVERT(VARCHAR(10),AB.DateMailed ,110) = CONVERT(VARCHAR(10),GETDATE(),110)
                                            ORDER BY BAAP.TetherId DESC
                                            ;");
        public void checkMaterializedBillToday(ref bool match, Policy policy)
        {
            var tetherId = policy.Tether.Id;

            if(MaterializedBills.FirstOrDefault(row=> (long)row["TetherId"] == tetherId) == null)
            {
                match = false;

            }

        }
        public void checkCanceled(ref bool match, Policy policy)
        {
            if(policy.CancellationDate == null)
            {
                match = false;
            }
        }
        public void checkVehicleProperties(ref bool match, Quote quote)
        {
            var vehicles = quote.GetVehicles();
            
            if (vehicles.Any())
            {
                foreach (var property in this.vehicle)
                {
                    //propMethod represents a genetic reference to the property in the vehicle class to be invoked later with any vehicle instance
                    var propMethod = vehicles[0].GetType().GetProperty(property.Key);
                    foreach (var vehicle in vehicles)
                    {
                       var propertyValue = propMethod.GetGetMethod().Invoke(vehicle, null);
                        if((propertyValue is string ? (string)propertyValue : propertyValue?.ToString()) == property.Value)
                        {
                            return;
                        }
                    }
                }
            }
            else 
            { 
              match = false; 
            }
            match = false;
        }

        public override string ToString()
        {
            string result = "";
            
            if(stateCode != null)
            {
                result += $"\nCondition: stateCode: {stateCode}; ";
            }
            if (coverageTypes != null && coverageTypes.Any())
            {
                result += $"\nCondition: coverageTypes: [{string.Join(", ", coverageTypes)}]; ";
            }
            if(questionResponses != null && questionResponses.Any())
            {
                result += $"\nCondition: questionResponses: {string.Join(", ", questionResponses.Select(it => $"{it.Key}, {it.Value}").ToList())}";
            }
            if (splitLimitBIPD)
            {
                result += $"\nCondition: splitLimitBIPD";
            }
            if (endorsement)
            {
                result += $"\nCondition: endorsement";
            }
            if (this.materializedBillToday)
            {
                result += $"\nCondition: materializedBillToday";
            }
            if (this.canceled)
            {
                result += $"\nCondition: canceled";
            }
            if (vehicle != null)
            {
                result += $"\nCondition: questionResponses: {string.Join(", ", vehicle.Select(it => $"{it.Key}, {it.Value}").ToList())}";
            }
            

            return result.Trim(' ').Trim(';');
        }

        public bool Equals(Condition condition)
        {
            if (condition == null)
            {
                return false;
            }
            var thisObj = JObject.FromObject(this);
            var otherObj = JObject.FromObject(condition);

            return JToken.DeepEquals(thisObj, otherObj);
        }





    }
}
