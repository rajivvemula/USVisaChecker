using ApolloQA.Data.Entity;
using ApolloQA.Source.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
        private static List<dynamic> policies = Cosmos.GetQuery("RatableObject", "SELECT * FROM c WHERE c.RatableObjectStatusValue = \"Issued\" and c.StatusId < 3 ORDER BY c.Id DESC").ToList();

        private static List<dynamic> quotes = Cosmos.GetQuery("Application", $"SELECT * FROM c WHERE c.Id in ( {string.Join(", ",policies.Select(it=>it["ApplicationId"]))} ) ORDER BY c.Id DESC").ToList();



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
        public Policy GetValidPolicy()
        {
            Log.Info($"Policy count: {policies.Count}");
            Log.Info($"Quote  count: {quotes.Count}");

            //1.) for each valid RatableObject (Policy) in the system (issued and not archived)
            //2.)    var policyOBJ is the cosmos object of the policy in context
            foreach (var policyOBJ in policies)
            {
                //3.)   let match = true  (will be set to false on any mismatch with the policy in context and this object's properties)
                var match = true;

                //4.)    initialize the policy and quote objects usign the cosmos objects
                var policy = new Policy(policyOBJ);
                var quote = new Quote(quotes.FirstOrDefault(quote => quote["Id"].ToObject<long>() == policy.GetProperty("ApplicationId").ToObject<long>()));


                //5.)    if StateCode was provided and if the governing state from the policy is not equal to the StateCode provided turn flag off and continue to the next iteration (policy)
                if (!string.IsNullOrWhiteSpace(this.stateCode) && this.stateCode != quote.GoverningStateCode)
                {
                    match = false;
                    if(!match)
                    {
                        continue;
                    }
                }
                //6.)    if < PropertyName > was provided, call Check<PropertyName> function sending in the match object by reference
                if (this.coverageTypes != null && this.coverageTypes.Any())
                {
                    this.CheckCoverageTypes(ref match, quote);
                    if (!match)
                    {
                        continue;
                    }
                }
                //6.)    if < PropertyName > was provided, call Check<PropertyName> function sending in the match object by reference
                if (this.questionResponses != null && this.questionResponses.Any())
                {
                    this.CheckQuestionResponses(ref match, quote);
                    if (!match)
                    {
                        continue;
                    }
                }
                //6.)    if < PropertyName > was provided, call Check<PropertyName> function sending in the match object by reference
                if (this.splitLimitBIPD)
                {
                    this.CheckSplitLimitBIPD(ref match, quote);
                    if (!match)
                    {
                        continue;
                    }
                }
                //6.)    if < PropertyName > was provided, call Check<PropertyName> function sending in the match object by reference
                if (this.endorsement)
                {
                    this.checkEndorsement(ref match, policy);
                    if (!match)
                    {
                        continue;
                    }
                }
                //6.)    if < PropertyName > was provided, call Check<PropertyName> function sending in the match object by reference
                if (this.materializedBillToday)
                {
                    this.checkMaterializedBillToday(ref match, policy);
                    if (!match)
                    {
                        continue;
                    }
                }
                //6.)    if < PropertyName > was provided, call Check<PropertyName> function sending in the match object by reference
                if (this.canceled)
                {
                    this.checkCanceled(ref match, policy);
                    if (!match)
                    {
                        continue;
                    }
                }
                //6.)    if < PropertyName > was provided, call Check<PropertyName> function sending in the match object by reference
                if (this.vehicle != null)
                {
                    this.checkVehicleProperties(ref match, quote);
                    if (!match)
                    {
                        continue;
                    }
                }
                //6.)    finally, if the match flag is still true, return the policy in context
                if (match)
                {
                    return policy;
                }

            }
            //return this.CreateQuoteForThis();
            throw new NotImplementedException($"No policy was found in the system for {this} \nFunction to create quote for given condition needs to be implemented");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Policy CreateQuoteForThis()
        {
            var quote = Functions.GetQuotedQuoteThroughAPI(stateCode);
            var policy = quote.PurchaseThis();


            /*if (this.questionResponses != null && this.questionResponses.Any())
            {
                foreach(var questionResponse in questionResponses)
                {
                    quote.GetQuestionResponse(questionResponse.Key);

                }
            }*/
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

        private List<string> supportedStates = new List<string>()
        {
            "IL", "SC", "CA", "GA", "MO", "IN", "TN"
        };

        






    }
}
