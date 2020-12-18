using System;
using System.Collections.Generic;
using System.Text;
using ApolloQA.Source.Driver;
using ApolloQA.Source.Helpers;

using System.Linq;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace ApolloQA.Data.Entity
{
    public class Policy
    {
        public readonly int Id;

        public Policy(int Id)
        {
            this.Id = Id;

        }
        public dynamic this[String propertyName]
        {
            get {

                
                var method = this.GetType().GetProperty(propertyName);
                if (method != null)
                {
                    return method.GetGetMethod().Invoke(this,null);

                }
                else
                {
                    return GetProperty(propertyName);
                }
            }
        }

        public dynamic GetProperties()
        {
            return RestAPI.GET($"/policy/{Id}");
        }
        public dynamic GetProperty(String propertyName)
        {
            var property = this.GetProperties()[propertyName];
            return property == null ? "" : property;
        }

        public Quote GetQuote()
        {
            return new Quote(GetProperties()["quoteId"].ToObject<int>());
        }
        public dynamic GetVehicleTypeRisk()
        {
            return this.GetQuote().GetVehicleTypeRisk();
        }
        public List<Vehicle> GetVehicles()
        {
            return this.GetQuote().GetVehicles();
        }
        public JArray getCoverages()
        {
            dynamic body = new JObject();
            body.filters = new JObject();
            body.filters["PolicyId"] = this.Id;
            body.filters["EntityStatusComplexFilter"] = "{\"StatusIds\":[0,2]}";
            body.loadChildren = true;

            return RestAPI.POST("/policy/coverageoutput/search", body)["results"];
        }
        public List<String> getCoverageCodes(Vehicle risk)
        {
            var result = new List<String>();
            foreach(var coverage in this.getCoverages())
            {
                dynamic body = new JObject();
                body.filters = new JObject();
                body.filters["CoverageOutputId"] = coverage["id"];
                var risksAssociated = ((JArray)RestAPI.POST("/policy/CoverageOutputRisk/search", body)["results"]).Select(riskOutput => (int)riskOutput["riskId"]).ToList();
                if(risksAssociated.Contains((int)risk.GetProperty("RiskId")))
                {
                    result.Add((String)coverage["associatedCoverage"]["coverageCode"]);
                }
            }
            return result;

        }
        public List<String> getCoverageCodes()
        {
            return this.getCoverages().Select(coverage => (String)coverage["associatedCoverage"]["coverageCode"]).ToList<String>();

        }


        public Organization Organization
        { 
            
            get
            {
                try
                {
                    return new Organization("PartyId", this.GetProperties().insuredPartyId.Value.ToString());
                }
                catch(Exception exception)
                {
                    throw new Exception($"error constructing Organization with the following params 1=PartyId 2={this.GetProperties()?.insuredPartyId?.Value?.ToString()}");
                }
            }
        }
        
        public Boolean AccidentPreventionCredit
        {
            get
            {
                return (Boolean)this["ratingFactors"]["accidentPreventionCredit"];
            }

        }
        public String CoveredAutos
        {
            get
            {
                return (String)this["metadata"]["CoveredAutos"];
            }
        }
        public String MotorCarrierFiling
        {
            get
            {
                return (String)this["metadata"]["MotorCarrierFiling"];
            }
        }
        public String BillingType
        {
            get
            {
                return (String)this["ratingFactors"]["billingType"];
            }
        }
        public String PaymentPlan
        {
            get
            {
                return (String)this["ratingFactors"]["paymentPlan"];
            }
        }
        public String isEft
        {
            get
            {
                return (String)this["ratingFactors"]["isEft"];
            }

        }
        public int? RadiusOfOperation
        {
            get
            {
                if (int.TryParse((String)this["metadata"]["RadiusOfOperation"], out int result))
                {
                    return result;
                }
                else
                {
                    return null;
                }
                
            }
        }

    }
}
