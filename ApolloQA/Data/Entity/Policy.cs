﻿using System;
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
            set
            {
                Cosmos.setProperty("RatableObject", $"SELECT * FROM c WHERE c.Id={this.Id}", propertyName, value);
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

        public static Policy GetLatestPolicy()
        {
            return new Policy((int)Cosmos.GetQuery("RatableObject", "SELECT * FROM c WHERE c.RatableObjectStatusValue = \"Issued\" ORDER BY c._ts DESC OFFSET 0 LIMIT 1").Result[0]["Id"]);
        }

        public static Policy GetClaimPolicy()
        {
            return new Policy((int)Cosmos.GetQuery("RatableObject", "SELECT * FROM c WHERE c.RatableObjectStatusValue = \"Issued\" OFFSET 0 LIMIT 1").Result[0]["Id"]);
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

        public string PolicyNumber
        {
            get
            {
                return GetProperty("policyNumber");
            }
        }

        public DateTime TimeFrom
        {
            get
            {
                return Convert.ToDateTime((string)this["timeFrom"]);
            }
            set
            {
                this["TimeFrom"] = value.ToString("O");
            }

        }
        public DateTime TimeTo
        {
            get
            {
                return Convert.ToDateTime((string)this["timeTo"]);
            }
            set
            {
                this["TimeTo"] = value.ToString("O");
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
