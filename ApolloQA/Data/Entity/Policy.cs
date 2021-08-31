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
        public enum EntityStatusEnum
        {
            Active = 0,
            Deleted = 1,
            Draft = 2,
            Archive = 3
        }
        public readonly long Id;

        public readonly int EntityTypeId = 100;
        public Policy(int Id)
        {
            this.Id = Id;

        }
        public Policy(long Id)
        {
            this.Id = Id;

        }
        public Policy(JObject policyProps)
        {
            this.Id = policyProps["Id"].ToObject<long>();
            this._properties = policyProps;
        }
        private JObject _properties = null;
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
            if(_properties !=null)
            {
                return _properties;
            }
            return Cosmos.GetQuery("RatableObject", $"SELECT * FROM c WHERE c.Id = {this.Id} OFFSET 0 LIMIT 1").ElementAt(0);
        }
        public dynamic GetProperty(String propertyName)
        {
            var property = this.GetProperties()[propertyName];
            return property;
        }

        public static Policy GetLatestPolicy()
        {
            return new Policy((int)Cosmos.GetQuery("RatableObject", "SELECT * FROM c WHERE c.RatableObjectStatusValue = \"Issued\" ORDER BY c._ts DESC OFFSET 0 LIMIT 1").ElementAt(0)["Id"]);
        }


        public static Policy GetLatestCancelledPolicy()
        {
            return new Policy((int)Cosmos.GetQuery("RatableObject", "SELECT * FROM c WHERE c.RatableObjectStatusValue = \"Cancelled\" ORDER BY c._ts DESC OFFSET 0 LIMIT 1").ElementAt(0)["Id"]);
        }

        public static Policy GetClaimPolicy()
        {
            return new Policy((int)Cosmos.GetQuery("RatableObject", "SELECT * FROM c WHERE c.RatableObjectStatusValue = \"Issued\" OFFSET 0 LIMIT 1").ElementAt(0)["Id"]);
        }

        public static Policy GetLatestAuthTransaction()
        {
            return new Policy((int)Cosmos.GetQuery("AuthorizeNetTransaction", "SELECT * FROM c WHERE c.RatableObjectStatusValue = \"Issued\" OFFSET 0 LIMIT 1").ElementAt(0)["Id"]);
        }


        public Quote GetQuote()
        {
            return new Quote(GetProperties()["ApplicationId"].ToObject<int>());
        }
        public dynamic GetVehicleTypeRisk()
        {
            return this.GetQuote().GetVehicleTypeRisk();
        }
        public List<Vehicle> GetVehicles()
        {
            return this.GetQuote().GetVehicles();
        }
        public List<Quote> GetDraftEndorsements()
        {
            var endorsements = SQL.executeQuery(@"SELECT *
                               FROM[tether].[TetherApplicationRatableObject] 
                               where TetherId = @TetherId AND StatusId=@StatusId; ", ("@TetherId", Tether.Id), ("@StatusId", EntityStatusEnum.Draft)  );


            try
            {
                return endorsements.Select(it => new Quote(it["ApplicationId"])).ToList();
            }
            catch(Exception ex)
            {
                Log.Debug($"PolicyId: {this.Id} TetherId: {Tether.Id}  failed to GetEndorsements");
                endorsements.ForEach(it => Log.Debug($"{{ {it} }},"));

                throw ex;
            }
        }




        public Tether Tether
        {
            get
            {
                return new Tether(this.GetProperty("TetherId").ToObject<long>());
            }
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

        public DateTime? CancellationDate
        {
            get
            {
                var cancellationDate = this.GetProperty("CancellationDate");
               
                return cancellationDate ?? Convert.ToDateTime((string)cancellationDate);
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

        public int RatingPackageID
        {
            get
            {

                //return (String)this["SelectedRatingPackageId"]["RatingPackageID"];
                return int.Parse((String)this.GetProperty("SelectedRatingPackageId"));
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