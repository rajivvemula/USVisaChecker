using ApolloTests.Data.Entities;
using ApolloTests.Data.Entity;
using HitachiQA.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using Quote = ApolloTests.Data.Entity.Quote;
using static ApolloTests.Data.Entity.Policy;
using DocumentFormat.OpenXml.Presentation;
using ApolloTests.Data.EntityBuilder;
using ApolloTests.Data.EntityBuilder.SectionBuilders;

namespace ApolloTests.Data.Form
{
    public class Condition:BaseEntity
    {
        public String? stateCode;
        public List<Entity.CoverageType>? coverageTypes;
        //Key=alias value=response
        public Dictionary<string, string>? questionResponses;
        public Boolean splitLimitBIPD;
        public Boolean endorsement;
        public Boolean issuedEndorsement;
        public Boolean materializedBillToday;
        public Boolean canceled;
        public Boolean canceledFuture;
        public Boolean reinstated;
        public Boolean rescindedCancelation;
        public Dictionary<string, string>? vehicle;
        public List<string>? recipients;
        private Form? _form = null;
        public Form Form {
            get { 
            _form.NullGuard(); return _form;
            } 
            set { 
            this._form= value;
            } }

        public Condition() { }
        

        /**
         * used by Data.Forms.Form.cs to parse the conditions from Data.Forms.Form.json for each specific form
         */
        [JsonConstructor]
        public Condition(String stateCode, List<string> coverageTypes, Dictionary<string, string> questionResponses, Boolean splitLimitBIPD, Boolean endorsement, Boolean issuedEndorsement, Boolean materializedBillToday,Boolean canceled, Boolean canceledFuture, Boolean reinstated, Boolean rescindedCancelation, Dictionary<string, string> vehicle)
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
            this.canceledFuture = canceledFuture;
            this.issuedEndorsement = issuedEndorsement;
            this.rescindedCancelation = rescindedCancelation;
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
                var policy = FindPolicyForThis();
                if (policy != null)
                {
                    return policy;
                }
            }
            
            return this.CreatePolicyForThis();

            throw new NotImplementedException($"No policy was found in the system for {this} \nFunction to create quote for given condition needs to be implemented");
        }

        public Policy? FindPolicyForThis()
        {
            
            var conditions = new List<string>();
            var validTetherIds = new List<long>();
            //<app,tether>
            var validAppIds = new Dictionary<long, long>();

            if (string.IsNullOrWhiteSpace(this.stateCode))
            {
                var tethers = SQL.executeQuery(@$"SELECT Id as TetherId, CurrentApplicationId 
                                FROM [tether].[Tether] 
                                where 
                                EffectiveDate <= GETDATE() AND ExpirationDate >= GETDATE() 
                                AND GoverningStateId = 1
                                AND LineId={this.Form.Line.Id}
                                AND PolicyNumber is not null");
                var tetherIds = tethers.Select(it=> (long)it["TetherId"]);
                foreach(var tether in tethers)
                {
                    long tetherId = (long)tether["TetherId"];
                    validAppIds.Add(tetherId, (long)tether["CurrentApplicationId"]);
                    validTetherIds.Add(tetherId);
                }
            }
            else
            {
                var stateId = SQL.executeQuery(@$"SELECT Id  
                                     FROM [location].[StateProvince]
                                     Where Code='{this.stateCode}';")[0]["Id"];

                var tethers = SQL.executeQuery(@$"SELECT Id as TetherId, CurrentApplicationId 
                                FROM [tether].[Tether] 
                                where 
                                EffectiveDate <= GETDATE() AND ExpirationDate >= GETDATE() 
                                AND GoverningStateId = {stateId}
                                AND LineId={this.Form.Line.Id}
                                AND PolicyNumber is not null");

                var tetherIds = tethers.Select(it => (long)it["TetherId"]);
                foreach (var tether in tethers)
                {
                    long tetherId = (long)tether["TetherId"];
                    validAppIds.Add(tetherId, (long)tether["CurrentApplicationId"]);
                    validTetherIds.Add(tetherId);
                }

            }


            if (validTetherIds.Count == 0) { return null; }

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
                    var vehicleQuery = "SELECT VALUE c FROM c JOIN r IN c.QuestionResponses WHERE STARTSWITH(c.id, \"RiskEntity\")  AND c.RiskTypeId = 1 AND c.TimeTo=null AND r.QuestionAlias = \"VehicleOwnedLeasedFinanced\"  and (r.Response =\"Financed\" or r.Response=\"Leased\")";
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

                        var currentApp = new Tether(tetherGroup.Key).CurrentApplicationId;
                        
                        //iterate through each risk associated to this tether
                        foreach (var risk in tetherGroup)
                        {
                            if (risk.Value<long>("EntityId") == currentApp)
                            {
                                //grab the response
                                var response = risk.Value<JArray>("QuestionResponses")?.First(it => it.Value<string>("QuestionAlias") == "VehicleOwnedLeasedFinanced").Value<string>("Response") ?? throw new ArgumentNullException();

                                //load whether it's financed or leased
                                if (response == "Financed")
                                    hasFinanced = true;
                                else if (response == "Leased")
                                    hasLeased = true;
                            }
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
            if(this.issuedEndorsement)
            {
                var result = SQL.executeQuery(@"SELECT distinct *
                                    FROM (
                                      SELECT T.Id as TetherId, TH.RatableObjectId, TH.EventTypeId, ET.Description as EventType,
                                         CASE WHEN TH.RatableObjectId = T.CurrentRatableObjectId THEN 'true' ELSE 'false' END AS [Current]
                                      FROM [tether].[TetherHistory] TH
                                      LEFT JOIN [tether].[Tether] T on TH.TetherId = T.Id
                                      LEFT JOIN tether.[TetherHistoryEventType] ET on ET.Id=TH.EventTypeId
                                      WHERE TH.EventTypeId=4 
                                        AND (SELECT COUNT(distinct RatableObjectId) FROM [tether].[TetherHistory] WHERE TetherId=T.Id AND EventTypeId=4) >1 
                                    ) AS subquery
                                    WHERE [Current] = 'true' -- reference the alias in the outer query
                                    ORDER BY TetherId desc;");
                var tethers = result.Select(it => (long)it["TetherId"]);
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
            if (this.rescindedCancelation)
            {
                var rescinded = SQL.executeQuery(@"SELECT TH2.TetherId, ET.[Name] as EventTypeName
                                                    FROM (
                                                        SELECT TetherId, MAX(Id) as MaxId
                                                        FROM tether.TetherHistory
                                                        GROUP BY TetherId
                                                    ) TH1
                                                    INNER JOIN tether.TetherHistory TH2 on TH1.TetherId = TH2.TetherId and TH1.MaxId = TH2.Id 
                                                    LEFT JOIN tether.TetherHistoryEventType ET on TH2.EventTypeId = ET.Id 
                                                    WHERE TH2.EventTypeId = 20
                                                    order by TH2.TetherId desc");
                var tethers = rescinded.Select(it => (long)it["TetherId"]);
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
                var appIds = validTetherIds.Select(it=> validAppIds[it]);
                conditions.Add($"c.Id in ({string.Join(", ",appIds)})");
                conditions.Add($"c.ApplicationStatusValue=\"Issued\"");
                var generatedConditionStr = string.Join(" AND ", conditions);
                var applicationQuery = $@"
                    SELECT TOP 1 * FROM c
                    WHERE {generatedConditionStr}
                    ORDER BY c.Id DESC";
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
        private Policy CreatePolicyForThis()
        {
            if (this.Form.Line.Id != 7)
            {
                throw new NotImplementedException($"Creating a policy through API for {this.Form.Line.Name} LOB has not been implemented yet");
            }
            stateCode ??= "IL";
            QuoteBuilder quoteBuilder = coverageTypes?.Any() ?? false ? new QuoteBuilder(this.Form.Line, stateCode, coverageTypes) : new QuoteBuilder(this.Form.Line, stateCode);

            if (this.questionResponses != null)
            {
                foreach (var questionAnswer in this.questionResponses)
                {
                    quoteBuilder.Operations.SetAnswer(questionAnswer.Key, questionAnswer.Value);
                    
                }
            }
            if(stateCode == "MI")
            {
                quoteBuilder.PolicyCoverages.First(it => it.GetCoverageType().Name == CoverageType.BIPD).selectedLimits = new List<int>() { 510000 };
            }
            if (splitLimitBIPD)
            {
                quoteBuilder.PolicyCoverages.BIPD_SplitLimit();
            }
            if (this.vehicle != null)
            {
                var vehicleObject = quoteBuilder.Vehicles[0].Vehicle;

                foreach (var prop in this.vehicle)
                {
                    vehicleObject.GetType()?.GetProperty(prop.Key)?.SetValue(vehicleObject, prop.Value, null);
                }

            }
            if (this.recipients!=null)
            {
                //additional interest is now always added by default
                if (quoteBuilder.PolicyAddlInterest.NumberOfParties<1)
                {
                    quoteBuilder.PolicyAddlInterest.NumberOfParties = 1;
                }
                if (recipients.Contains("LIENHOLDER"))
                {
                    quoteBuilder.Vehicles[0].QuestionAnswers.VehicleOwnedLeasedFinanced._response = "Financed";
                }
                if (recipients.Contains("LESSOR"))
                {
                    if(recipients.Contains("LIENHOLDER"))
                    {
                        ((IRiskBuilder)quoteBuilder.Vehicles).NumberOfRisks = 2;
                        quoteBuilder.Vehicles[1].QuestionAnswers.VehicleOwnedLeasedFinanced._response = "Leased";
                    }
                    else
                    {
                        quoteBuilder.Vehicles[0].QuestionAnswers.VehicleOwnedLeasedFinanced._response = "Leased";
                    }
                }
            }

            var quote = quoteBuilder.Build();
            var policy = quote.PurchaseThis();
            Policy? endorsementRatableObject = null;
            Quote? endorsement = null;

            if (this.endorsement || issuedEndorsement)
            {
                Thread.Sleep(4000);
                endorsement = policy.CreateDraftPolicyEndorsement();
                if(policy.GetDraftEndorsements().Count ==0)
                {
                    throw new Exception("Endorsement Not Created Yet");
                }
                endorsement.CreateEndorsementHeader(policy.Id);
                endorsement.PostSummary();
                endorsementRatableObject = endorsement.GetRatableObject();
                Log.Debug("Endorsement RatableObject Id: " + endorsementRatableObject?.Id);
            }
            if (this.issuedEndorsement)
            {
                endorsement.NullGuard();
                endorsementRatableObject.NullGuard(nameof(endorsementRatableObject));
                RestAPI.PATCH($"quote/{endorsement.Id}", new { ApplicationStatus = 4000 });
                endorsementRatableObject.IssueEndorsement();
                endorsementRatableObject.CacheProps();
            }
            if (this.materializedBillToday)
            {
                var tetherId = policy.Tether.Id;
                var arrangmentBillIds = SQL.executeQuery(@$"SELECT BAAP.TetherId, AB.Id as ArrangementBillId, AB.*  
                                                            FROM [billing].[BillingAccountArrangementPolicy] BAAP
                                                            LEFT JOIN billing.ArrangementBill AB on AB.BillingAccountArrangementId = BAAP.BillingAccountArrangementId
                                                            where BAAP.TetherId={tetherId}");
                var targetArrangementBillId = arrangmentBillIds[0]["ArrangementBillId"];

                
                SQL.executeQuery(@$"update billing.ArrangementBill set TimeFrom = GETDATE(), DateMailed=GETDATE(), UpdateDateTime= DATEADD(HOUR, -2, GETDATE())  where Id = {targetArrangementBillId};");

                var logicAppId = SQL.executeQuery("select * from system.job where [Name]='ProcessLateBills';")[0]["Id"];

                RunRatableObjectManagementFunction($"jobtrigger/{logicAppId}");

                //SQL.executeQuery(@$"update j set LastRun = GETDATE(), NextRun = DATEADD(SECOND, 5, GETDATE())
                //                   from system.job j where Id in ({logicAppId})");
                //WAIT FOR JOB TO RUN
                Thread.Sleep(7000);


             }
            //6.)    if < PropertyName > was provided, call Check<PropertyName> function sending in the match object by reference
            if (this.canceled || rescindedCancelation)
            {
                Thread.Sleep(5000);
                policy.Cancel();
            }
            if (rescindedCancelation)
            {
                policy.RescindCancelation();
            }
            if (this.reinstated)
            {
                var cancelPolicy = new CancelPolicyObject()
                {
                    cancelDenyReasonTypeId = CancellationReason.PolicyCancelledAndReissued,
                    cancellationInitiatedBy = CancellationInitiatedBy.Carrier,
                    cancellationUnderwriterReason = "Testing",
                    policyCancellationEffectiveDate = DateTime.Now.AddDays(1).ToString("O")
                };
                Thread.Sleep(5000);
                policy.Cancel(cancelPolicy);
                policy.Tether.Load();
                policy.Tether.SetProperty("PolicyCancellationEffectiveDate", DateTimeOffset.UtcNow.AddDays(-1));
                policy.Tether.SetProperty("EffectiveDate", policy.Tether.EffectiveDate.AddDays(-2));
                policy.Tether.SetProperty("ExpirationDate", policy.Tether.ExpirationDate.AddDays(-2));

                var cancelJobId = SQL.executeQuery("select * from system.job where [Name]='CancelPolicies';")[0]["Id"];

                RunRatableObjectManagementFunction($"jobtrigger/{cancelJobId}");
                //WAIT FOR JOB TO RUN
                Thread.Sleep(5000);

                policy.Tether.waitForTetherStatus("CANCELLED");

                policy.Reinstate();
                policy.Tether.waitForTetherStatus("ISSUED");



            }
            



            quote.CacheProps();
            policy.CacheProps();
            

            return issuedEndorsement? endorsementRatableObject ?? throw new NullReferenceException("endorsementRatableObject"): policy;
        }

        /// <summary>
        /// this static variable holds all the valid Tether Objects that have a materialized bill for today
        /// </summary>
        private static readonly List<Dictionary<string, dynamic>> MaterializedBills = GetSQLService().executeQuery($@"SELECT BAAP.TetherId, AB.*  
                                            FROM [billing].[BillingAccountArrangementPolicy] BAAP
                                            LEFT JOIN billing.ArrangementBill AB on AB.BillingAccountArrangementId = BAAP.BillingAccountArrangementId
                                            WHERE CONVERT(VARCHAR(10),AB.BillStatusUpdateDateTime ,110) = CONVERT(VARCHAR(10),GETDATE(),110)
                                            AND CONVERT(VARCHAR(10),AB.DateMailed ,110) = CONVERT(VARCHAR(10),GETDATE(),110)
                                            ORDER BY BAAP.TetherId DESC
                                            ;");

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
