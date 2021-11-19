using ApolloQA.Data.Entity;
using ApolloQA.Source.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApolloQA.Data.Form
{
    public class Condition
    {
        public String stateCode;
        public List<Entity.CoverageType> coverageTypes;
        //Key=alias value=response
        public Dictionary<string, string> questionResponses;
        public Boolean splitLimitBIPD;
        public Boolean endorsement;
        public Boolean materializedBillToday;
        public Boolean canceled;
        public Dictionary<string, string> vehicle;

        public Condition() { }
        

        /**
         * used by Data.Forms.Form.cs to parse the conditions from Data.Forms.Form.json for each specific form
         */
        [JsonConstructor]
        public Condition(String stateCode, List<string> coverageTypes, Dictionary<string, string> questionResponses, Boolean splitLimitBIPD, Boolean endorsement, Boolean materializedBillToday,Boolean canceled, Dictionary<string, string> vehicle)
        {
            this.stateCode = stateCode?.ToUpper();
            this.coverageTypes = coverageTypes == null ? new List<CoverageType>(): coverageTypes.Select(it => new CoverageType(it)).ToList();
            this.questionResponses = questionResponses;
            this.splitLimitBIPD = splitLimitBIPD;
            this.endorsement = endorsement;
            this.materializedBillToday = materializedBillToday;
            this.canceled = canceled;
            this.vehicle = vehicle;
        }





        /**
         * retrieve all valid policies and all quotes in order to find a matching policy for any condition object
         * note: static because is used across any condition (thus any form)
         */
        private static Entities<Policy> policies = new Entities<Policy>($"./Conditions/{nameof(policies)}.json");

        private static Entities<Quote> quotes = new Entities<Quote>($"./Conditions/{nameof(quotes)}.json");

        public class Entities<T> : List<T>
        {
            public string filePath;

            public Entities(string filePath) : base()
            {
                this.filePath = filePath;
                if(!File.Exists(filePath))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                    File.Create(filePath).Close();
                }
                this.Load();
            }

            public new void Add(T _item)
            {
                base.Add(_item);
                this.Write();
            }

            public void Load()
            {
                var arr = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(filePath));
                if(arr != null && arr.Count > this.Count)
                {
                    var existingIds = this.Select(it => (long)((dynamic)it).Id);

                    foreach (dynamic item in arr)
                    {
                        if(!existingIds.Contains((long)item.Id))
                        {
                            item.CacheProps();
                            base.Add((T)item);
                        }

                    }
                }
            }

            private void Write()
            {
                var mutex = new Mutex(false, "Condition.Entities");
                mutex.WaitOne();
                try
                {
                    File.WriteAllText(this.filePath, JsonConvert.SerializeObject(this.Select(it => new Dictionary<string, long> { { "Id", (long)((dynamic)it).Id } })));
                }
                finally
                {
                    mutex.ReleaseMutex();
                }
            }

           
        }
        
        public void createRelevantPolicies()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            var states = Form.Forms.Select(it => it?.condition?.stateCode).Where(it=> it!=null).Distinct().ToArray();
            //Log.Debug($"states {string.Join(", ", states) }");
            var coverageTypes = new string[] {  CoverageType.BIPD,
                                                CoverageType.COLLISION,
                                                CoverageType.COMPREHENSIVE,
                                                CoverageType.IN_TOW,
                                                CoverageType.RENTAL_REIMBURSEMENT,
                                                CoverageType.TRAILER_INTERCHANGE,
            };
            Parallel.ForEach(states, stateCode =>
                {
                    if(Mutex.TryOpenExisting($"createRelevantPolicies.{stateCode}", out Mutex mutex))
                    {
                        mutex.WaitOne();
                        mutex.ReleaseMutex();
                        return;
                    }
                    else
                    {
                        mutex = new Mutex(false, $"createRelevantPolicies.{stateCode}");
                        mutex.WaitOne();
                    }
                    var quoteParam = new TestData.QuoteParam(stateCode, coverageTypes.Select(it=> new CoverageType(it)).ToList());

                    quoteParam.QuoteQuentionAnswerParam.TXAuth._response = "true";
                    quoteParam.QuoteQuentionAnswerParam.SC_Authority._response = "true";

                    quoteParam.BIPD_SplitLimit();

                    quoteParam.DriverParam.Drivers[0].DriverQuentionAnswerParam.CDL._response = "1";

                    Quote quote;
                    Policy policy;

                    try
                    {
                        quote = quoteParam.RunThisThroughAPI();

                    }
                    catch
                    {
                        quote = quoteParam.RunThisThroughAPI();
                    }

                    try
                    {
                        policy = quote.PurchaseThis();
                    }
                    catch (Exception)
                    {
                        policy = quote.PurchaseThis();

                    }

                    quotes.Add(quote);
                    policies.Add(policy);
                    mutex.ReleaseMutex();
                }
            );
            watch.Stop();
            Log.Debug($"Took: {watch.Elapsed.TotalSeconds} Seconds");
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
        public Policy GetValidPolicy(bool LoadRelevantQuotes = false)
        {
            if(LoadRelevantQuotes)
            {
                createRelevantPolicies();
                policies.Load();
                quotes.Load();
            }

           
            Log.Info($"Policy count: {policies.Count}");
            Log.Info($"Quote  count: {quotes.Count}");
            //1.) for each valid RatableObject (Policy) in the system (issued and not archived)
            //2.)    var policyOBJ is the cosmos object of the policy in context
            foreach (var policy in policies)
            {             
                if(checkIfPolicyMatches(policy))
                {
                    return policy;
                }
            }
            
            return this.CreateQuoteForThis();

            throw new NotImplementedException($"No policy was found in the system for {this} \nFunction to create quote for given condition needs to be implemented");
        }

        public bool checkIfPolicyMatches(Policy policy)
        {
            //3.)   let match = true  (will be set to false on any mismatch with the policy in context and this object's properties)
            var match = true;

            //4.)    initialize the policy and quote objects usign the cosmos objects
            var quote = quotes.FirstOrDefault(quote => quote.Id == policy.GetProperty("ApplicationId").ToObject<long>());


            //5.)    if StateCode was provided and if the governing state from the policy is not equal to the StateCode provided turn flag off and continue to the next iteration (policy)
            if (!string.IsNullOrWhiteSpace(this.stateCode) && this.stateCode != quote.GoverningStateCode)
            {
                match = false;
                return match;

            }
            //6.)    if < PropertyName > was provided, call Check<PropertyName> function sending in the match object by reference
            if (this.coverageTypes != null && this.coverageTypes.Any())
            {
                this.CheckCoverageTypes(ref match, quote);
                if (!match)
                {
                    return match;
                }
            }
            //6.)    if < PropertyName > was provided, call Check<PropertyName> function sending in the match object by reference
            if (this.questionResponses != null && this.questionResponses.Any())
            {
                this.CheckQuestionResponses(ref match, quote);
                if (!match)
                {
                    return match;
                }
            }
            //6.)    if < PropertyName > was provided, call Check<PropertyName> function sending in the match object by reference
            if (this.splitLimitBIPD)
            {
                this.CheckSplitLimitBIPD(ref match, quote);
                if (!match)
                {
                    return match;
                }
            }
            //6.)    if < PropertyName > was provided, call Check<PropertyName> function sending in the match object by reference
            if (this.endorsement)
            {
                this.checkEndorsement(ref match, policy);
                if (!match)
                {
                    return match;
                }
            }
            //6.)    if < PropertyName > was provided, call Check<PropertyName> function sending in the match object by reference
            if (this.materializedBillToday)
            {
                this.checkMaterializedBillToday(ref match, policy);
                if (!match)
                {
                    return match;
                }
            }
            //6.)    if < PropertyName > was provided, call Check<PropertyName> function sending in the match object by reference
            if (this.canceled)
            {
                this.checkCanceled(ref match, policy);
                if (!match)
                {
                    return match;
                }
            }
            //6.)    if < PropertyName > was provided, call Check<PropertyName> function sending in the match object by reference
            if (this.vehicle != null)
            {
                this.checkVehicleProperties(ref match, quote);
                if (!match)
                {
                    return match;
                }
            }
            //6.)    finally, return match which should be true
            return match;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Policy CreateQuoteForThis()
        {
            TestData.QuoteParam quoteParam = coverageTypes.Any() ? new TestData.QuoteParam(stateCode, coverageTypes) : new TestData.QuoteParam(stateCode);

            if(this.questionResponses != null)
            {
                foreach (var questionAnswer in this.questionResponses)
                {
                    quoteParam.QuoteQuentionAnswerParam.SetAnswer(questionAnswer.Key, questionAnswer.Value);
                }
            }
            if(splitLimitBIPD)
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
                Log.Debug("RatableObject Id: " + ratableObject.Id);
            }
            if (this.materializedBillToday)
            {
                throw new NotImplementedException();
            }
            //6.)    if < PropertyName > was provided, call Check<PropertyName> function sending in the match object by reference
            if (this.canceled)
            {
                policy.Cancel();
            }

           

            quote.CacheProps();
            policy.CacheProps();
            quotes.Add(quote);
            policies.Add(policy);

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
        private static List<Dictionary<string, dynamic>> MaterializedBills = SQL.executeQuery($@"SELECT BAAP.TetherId, AB.*  
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
