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
        public readonly long Id;

        public Policy(int Id)
        {
            this.Id = Id;

        }
        public Policy(long Id)
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
            return Cosmos.GetQuery("RatableObject", $"SELECT * FROM c WHERE c.Id = {this.Id} OFFSET 0 LIMIT 1").Result[0];
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


   
        public Organization Organization
        { 
            
            get
            {
                try
                {
                    return new Organization("PartyId", this.GetProperties().insuredPartyId.Value.ToString());
                }
                catch(Exception ex)
                {
                    throw new Exception($"error constructing Organization with the following params 1=PartyId 2={this.GetProperties()?.insuredPartyId?.Value?.ToString()}");
                }
            }
        }

        public string PolicyNumber
        {
            get
            {
                return GetProperty("PolicyNumber");
            }
        }

        public DateTime TimeFrom
        {
            get
            {
                return Convert.ToDateTime((string)this.GetProperty("TimeFrom"));
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
                return Convert.ToDateTime((string)this.GetProperty("TimeTo"));
            }
            set
            {
                this["TimeTo"] = value.ToString("O");
            }

        }
        public string LatestRatingResponseGroupId
        {
            get
            {
               return this.GetProperty("LatestRatingResponseGroupId");
            }
        }
        public JArray RatingGroup
        {
            get
            {
                return RestAPI.GET($"/rating/group/{LatestRatingResponseGroupId}");
            }
        }
        public Boolean AccidentPreventionCredit
        {
            get
            {
                return (Boolean)this["RatingFactors"]["AccidentPreventionCredit"];
            }

        }
        public String CoveredAutos
        {
            get
            {
                //broken
                return (String)this["RatingFactors"]["CoveredAutos"];
            }
        }
        public String MotorCarrierFiling
        {
            get
            {
                return (String)this["Metadata"]["MotorCarrierFiling"];
            }
        }
        public String BillingType
        {
            get
            {
                //broken
                return (String)this["RatingFactors"]["BillingType"];
            }
        }
        public String PaymentPlan
        {
            get
            {
                //broken
                return (String)this["RatingFactors"]["paymentPlan"];
            }
        }
        public String isEft
        {
            get
            {
                return (String)this["RatingFactors"]["IsEft"];
            }

        }
        public int? RadiusOfOperation
        {
            get
            {
                if (int.TryParse((String)this["Metadata"]["RadiusOfOperation"], out int result))
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
