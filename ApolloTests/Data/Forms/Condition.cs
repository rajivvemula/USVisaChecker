using HitachiQA.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ApolloTests.Data.EntityBuilder;
using ApolloTests.Data.Entities.Context;
using ApolloTests.Data.Entities.Coverage;
using ApolloTests.Data.Entities.Tether;
using ApolloTests.Data.Entities;
using static Polly.RetrySyntax;
namespace ApolloTests.Data.Form
{
    public class Condition:BaseEntity
    {
        public String? stateCode;
        public List<string> coverageTypes;
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
            this.coverageTypes = coverageTypes == null ? new List<string>(): coverageTypes;
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
        /// <para> this function iterates through all valid policies in order to find one that matches this object's properties </para>
        /// <para> this function will attempt 3 times to retrieve/generate a policy before failing </para>
        /// </summary>
        /// <returns>Policy that matches all the properties in the object context</returns>
        public Entities.Policy GetValidPolicy(bool useNewEntitiesOnly, IObjectContainer OC)
        {
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
            var retry = Polly.Policy
                .Handle<Exception>()
                .WaitAndRetry(3, attempt=>TimeSpan.FromSeconds(1));
            
            return retry.Execute(() =>
            {
                if (useNewEntitiesOnly)
                {
                    var policy = FindPolicyForThis(OC, true);
                    return policy == null ? this.CreatePolicyForThis(OC) : policy;
                }
                else
                {
                    return FindPolicyForThis(OC, false);
                }
            });
        }

        public Entities.Policy? FindPolicyForThis(IObjectContainer objectContainer, bool scopeIntoThisRun)
        {
            var cosmosContext = objectContainer.Resolve<CosmosContext>();
            var sqlContext = objectContainer.Resolve<SQLContext>();
            var conditions = new List<string>();
            var validTetherIds = new List<long>();
            //<app,tether>
            var validTether_AppIds = new Dictionary<long, long>();


            long? stateId = string.IsNullOrWhiteSpace(this.stateCode)? null: (long)SQL.executeQuery(@$"SELECT Id  
                                    FROM [location].[StateProvince]
                                    Where Code='{this.stateCode}';")[0]["Id"];

            // the below object looks into the tethers on current term only along with the following conditions
            // - tether not expired
            // - tether was issued
            // - LOB is within current form's LOB
            // - if there's a state in the condition, makes sure tether is from that state 
            var tethers = SQL.executeQuery(@$"
                          select q.RootTetherId, q.Id as TetherId, CurrentApplicationId, q.termId
                        from (
                            select RootTetherId, id, CurrentApplicationId, termid, row_number() over (partition by roottetherid order by termid desc) as rowId
                            from tether.Tether 
                            where FirstIssuedDate is not null
                            AND ExpirationDate >= GETDATE()
                            AND LineId={this.Form.Line.Id}
                            {(stateId==null? "": $"AND GoverningStateId ={stateId}")}
                        ) q
                        where q.rowid = 1
            ");

            foreach (var tether in tethers)
            {
                long tetherId = (long)tether["TetherId"];
                validTether_AppIds.Add(tetherId, (long)tether["CurrentApplicationId"]);
                validTetherIds.Add(tetherId);
            }

            

            
            

            if (validTetherIds.Count == 0) { return null; }

            if(scopeIntoThisRun)
            {
                conditions.Add($"contains(c.BusinessInformation.Name, 'Run:{Main.RunId}-')");
            }
            else
            {
                conditions.Add($"NOT contains(c.BusinessInformation.Name, 'Run:')");
            }

            if (this.coverageTypes != null && this.coverageTypes.Any())
            {
                foreach (var type in this.coverageTypes)
                {
                    var typeId = sqlContext.CoverageType.First(it => it.TypeName == type).Id;
                    conditions.Add($"ARRAY_CONTAINS(c.SelectedCoverages, {{ \"CoverageTypeId\": {typeId} }}, true) ");
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
                var typeId = sqlContext.CoverageType.First(it => it.TypeName == CoverageType.BIPD).Id;
                conditions.Add($"ARRAY_CONTAINS(c.SelectedCoverages, {{ \"CoverageTypeId\": {typeId},  \"SelectedLimitName\": \"Split Limit\"}}, true) ");

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
                    var tetherCandidates = new List<long>();

                    // group all risks with their TetherId
                    // ending with a group for each tether (group is basically a list of risks associated to that tether)
                    var groups = validRisks.GroupBy(risk => risk.Value<long>("TetherId"));
                    foreach(var tetherGroup in groups)
                    {
                        //to store if this tether has financed or leased
                        bool hasFinanced = false;
                        bool hasLeased = false;

                        var currentApp = Tether.GetTether(sqlContext, tetherGroup.Key).CurrentApplicationId;
                        
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
                            tetherCandidates.Add(tetherGroup.Key);
                        //if we need 1, only add that one
                        else if(!both && lienHolder && hasFinanced)
                            tetherCandidates.Add(tetherGroup.Key);
                        //if we need 1, only add that one
                        else if (!both && lessor && hasLeased)
                            tetherCandidates.Add(tetherGroup.Key);
                    }

                    //finally, remove all previously valid tether that are no longer valid after checking this
                    validTetherIds.RemoveAll(it => !tetherCandidates.Contains(it));

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


                var tetherCandidates = draftEndorsements.Select(it => (long)it["TetherId"]);
                validTetherIds.RemoveAll(it => !tetherCandidates.Contains(it));
                
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
                var tetherCandidates = result.Select(it => (long)it["TetherId"]);
                validTetherIds.RemoveAll(it => !tetherCandidates.Contains(it));

            }
            if (this.materializedBillToday)
            {
                var tetherCandidates = MaterializedBills.Select(it => (long)it["TetherId"]);
                validTetherIds.RemoveAll(it => !tetherCandidates.Contains(it));

            }
            if (this.canceled)
            {
                var canceled = SQL.executeQuery("SELECT Id as TetherId FROM [tether].[Tether] where EffectiveDate <= GETDATE() AND ExpirationDate >= GETDATE() and PolicyCancellationEffectiveDate < GETDATE();");

                var tetherCandidates = canceled.Select(it => (long)it["TetherId"]);

                validTetherIds.RemoveAll(it => !tetherCandidates.Contains(it));
            }
            if (this.canceledFuture)
            {
                var canceled = SQL.executeQuery("SELECT Id as TetherId FROM [tether].[Tether] where EffectiveDate <= GETDATE() AND ExpirationDate >= GETDATE() and PolicyCancellationEffectiveDate > GETDATE();");

                var tetherCandidates = canceled.Select(it => (long)it["TetherId"]);

                validTetherIds.RemoveAll(it => !tetherCandidates.Contains(it));
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
                var tetherCandidates = rescinded.Select(it => (long)it["TetherId"]);
                validTetherIds.RemoveAll(it => !tetherCandidates.Contains(it));

            }
            if (this.reinstated)
            {
                var reinstated = SQL.executeQuery("SELECT Id as TetherId FROM [tether].[Tether] where EffectiveDate <= GETDATE() AND ExpirationDate >= GETDATE() and PolicyReinstatementDate < GETDATE();");

                var tetherCandidates = reinstated.Select(it => (long)it["TetherId"]);

                validTetherIds.RemoveAll(it => !tetherCandidates.Contains(it));
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
                    var tetherCandidates = validVehicles.Select(it => (long)it["TetherId"]);

                    validTetherIds.RemoveAll(it => !tetherCandidates.Contains(it));
                }
            }

            if(validTetherIds.Count > 0)
            {
                var appIds = validTetherIds.Select(it=> validTether_AppIds[it]);
                conditions.Add($"c.Id in ({string.Join(", ", appIds)})");
                var generatedConditionStr = string.Join(" AND ", conditions);
                var applicationQuery = $@"
                    SELECT TOP 1 * FROM c
                    WHERE {generatedConditionStr}
                    ORDER BY c._ts DESC";
                //Log.Debug(applicationQuery);

                List<dynamic> result;
                try { 
                    result = Cosmos.GetQuery("Application", applicationQuery).Result;
                }
                catch(Exception ex) {
                    throw new Exception($"error running query: \n{applicationQuery}\n", ex);
                }
                if (result.Any())
                {
                    Log.Debug("Matched Application: " + Log.stringify($"{result[0].Id}={result[0].BusinessInformation.Name}"));
                    long Id = result[0].Id;
                    var quote = cosmosContext.Quotes.First(it => it.Id == Id);
                    return quote.RatableObject;
                }
            }
            
            return null;
           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Entities.Policy CreatePolicyForThis(IObjectContainer objectContainer)
        {
            stateCode ??= "IL";
            QuoteBuilder quoteBuilder = coverageTypes?.Any() ?? false ? new QuoteBuilder(objectContainer, this.Form.Line.LineEnum, stateCode, coverageTypes) : new QuoteBuilder(objectContainer, this.Form.Line.LineEnum, stateCode);

            if (this.questionResponses != null)
            {
                foreach (var questionAnswer in this.questionResponses)
                {
                    quoteBuilder.Operations.SetAnswer(questionAnswer.Key, questionAnswer.Value);
                    
                }
            }
            if(stateCode == "MI")
            {
                quoteBuilder.PolicyCoverages.First(it => it.GetCoverageType().TypeName == CoverageType.BIPD).SelectedLimits = new List<int>() { 510000 };
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
                string[] handledRecipients = new string[] { "INSURED", "LIENHOLDER", "LESSOR", "ADDITIONALINTEREST" };
                var notHandled = recipients.Where(it => !handledRecipients.Contains(it));
                if (notHandled.Any())
                {
                    throw new Exception($"Not Handled recipient {Log.stringify(notHandled)}");
                }

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
                        quoteBuilder.Vehicles.NumberOfRisks = 2;
                        quoteBuilder.Vehicles[1].QuestionAnswers.VehicleOwnedLeasedFinanced._response = "Leased";
                    }
                    else
                    {
                        quoteBuilder.Vehicles[0].QuestionAnswers.VehicleOwnedLeasedFinanced._response = "Leased";
                    }
                }
            }

            var quote = quoteBuilder.Build();
            Entities.Policy policy;
            try
            {
                policy = quote.PurchaseThis();
            }
            catch(Exception)
            {
                quote.PostSummary();
                policy = quote.PurchaseThis();
            }

            Policy endorsementRatableObject = null;
            Quote endorsement = null;

            if (this.endorsement || issuedEndorsement)
            {
                Thread.Sleep(4000);
                endorsement = policy.CreateDraftPolicyEndorsement();
                if(policy.GetDraftEndorsements().Count ==0)
                {
                    throw new Exception($"Endorsement Not Created Yet, policy: {policy.Id}, expected endorsementId: {endorsement.Id}");
                }
                endorsement.CreateEndorsementHeader(policy.Id);
                endorsement.PostSummary();
                endorsementRatableObject = endorsement.RatableObject;
                Log.Debug("Endorsement RatableObject Id: " + endorsementRatableObject?.Id);
            }
            if (this.issuedEndorsement)
            {
                endorsement.NullGuard();
                endorsementRatableObject.NullGuard(nameof(endorsementRatableObject));
                RestAPI.PATCH($"quote/{endorsement.Id}", new { ApplicationStatus = 4000 });
                endorsementRatableObject.IssueEndorsement();
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

                //WAIT FOR JOB TO RUN
                Thread.Sleep(7000);


             }
            //6.)    if < PropertyName > was provided, call Check<PropertyName> function sending in the match object by reference
            if (this.canceled || rescindedCancelation)
            {
                policy.Tether.EffectiveDate = policy.Tether.EffectiveDate.AddDays(-2);
                policy.Tether.ExpirationDate = policy.Tether.ExpirationDate.AddDays(-2);
                policy.Tether.ContextSQL.SaveChanges();
                Thread.Sleep(5000);
                policy.Cancel();
            }
            if(canceledFuture)
            {
                policy.Tether.EffectiveDate = policy.Tether.EffectiveDate.AddDays(-2);
                policy.Tether.ExpirationDate = policy.Tether.ExpirationDate.AddDays(-2);
                policy.Tether.ContextSQL.SaveChanges();

                Thread.Sleep(5000);
                var cancelPolicy = new Entities.Policy.CancelPolicyObject()
                {
                    cancelDenyReasonTypeId = CancellationReason.CancelledByInsured,
                    cancellationInitiatedBy = CancellationInitiatedBy.Carrier,
                    cancellationUnderwriterReason = "Testing",
                    policyCancellationEffectiveDate = DateTime.Now.AddDays(2).ToString("O")
                };
                policy.Cancel(cancelPolicy);

            }
            if (rescindedCancelation)
            {
                policy.RescindCancelation();
            }
            if (this.reinstated)
            {
                var cancelPolicy = new Entities.Policy.CancelPolicyObject()
                {
                    cancelDenyReasonTypeId = CancellationReason.PolicyCancelledAndReissued,
                    cancellationInitiatedBy = CancellationInitiatedBy.Carrier,
                    cancellationUnderwriterReason = "Testing",
                    policyCancellationEffectiveDate = DateTime.Now.AddDays(1).ToString("O")
                };
                Thread.Sleep(5000);
                policy.Cancel(cancelPolicy);
                
                policy.Tether.Reload();
                policy.Tether.PolicyCancellationEffectiveDate = DateTimeOffset.UtcNow.AddDays(-1);
                policy.Tether.EffectiveDate = policy.Tether.EffectiveDate.AddDays(-2);
                policy.Tether.ExpirationDate = policy.Tether.ExpirationDate.AddDays(-2);
                policy.Tether.ContextSQL.SaveChanges();
                policy.TimeFrom = policy.Tether.EffectiveDate;
                policy.TimeTo = policy.Tether.ExpirationDate;

                policy.Reinstate();




            }            

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
