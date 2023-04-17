using ApolloTests.Data.Entities;
using ApolloTests.Data.EntityFramework.Context;
using HitachiQA.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ApolloTests.Data.Entity.Policy;


namespace ApolloTests.Data.EntityFramework
{
    public class Policy : BaseEntity
    {
        public CosmosContext Context { get; }
        public SQLContext ContextSQL { get; }
        public Policy(CosmosContext context)
        {
            Context = context;
            ContextSQL = context.SQLContext;


        }
        [Key]
        public string id { get; set; }
        public long Id { get; set; }
        public string ApplicationNumber { get; set; }
        public long TetherId { get; set; }
        public long ApplicationId { get; set; }
        public Quote Quote => this.Context.Quotes.First(it => it.Id == ApplicationId);
        public Tether.Tether Tether => this.ContextSQL.Tether.First(it => it.Id == TetherId);
        public long _ts { get; set; }

        [Required]
        public string Discriminator { get; set; }

        public enum EntityStatusEnum
        {
            Active = 0,

            Deleted = 1,

            Draft = 2,

            Archive = 3
        }

        public enum CancellationInitiatedBy
        {
            Insured,

            Carrier,

            System
        }

        public enum CancellationReason
        {
            /// <summary>
            /// Policy cancelled and reissued. - INTERNAL USE ONLY
            /// </summary>
            PolicyCancelledAndReissued = 13,

            /// <summary>
            /// Substantial change in risk which increased risk of loss after policy issued or renewed
            /// </summary>
            SubstantialChangeInRisk = 6,

            /// <summary>
            /// NON-PAYMENT OF PREMIUM
            /// </summary>
            NonPaymentOfPremium = 4,

            /// <summary>
            /// Non-payment of deductible
            /// </summary>
            NonPaymentOfDeductible = 7,

            /// <summary>
            /// Loss or suspension of driver's license
            /// </summary>
            LossOrSuspensionOfDriversLicense = 53,

            /// <summary>
            /// Cancelled by Insured
            /// </summary>
            CancelledByInsured = 23
        }

        public enum ReasonForChangeEndorsement
        {
            CustomerInitiated = 1,

            CarrierInitiated = 2,

            AgencyInitiated = 3,

            Other = 4
        }

        public readonly long PolicyId;

        public readonly int EntityTypeId = 100;

        public Policy(int Id)
        {
            this.PolicyId = Id;
            //Log.Debug("Policy Id: " + Id);
        }
        [JsonConstructor]
        public Policy(long Id)
        {
            this.Id = Id;
            //Log.Debug("Policy Id: " + Id);
        }

        public Policy(JObject policyProps)
        {
            this.Id = policyProps["Id"]?.ToObject<long?>() ?? throw new Exception("Id returned null");
            this._properties = policyProps;
        }

        public dynamic? this[String propertyName]
        {
            get
            {
                var method = this.GetType().GetProperty(propertyName);
                if (method != null)
                {
                    return method.GetGetMethod()?.Invoke(this, null);
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

        private JObject? _properties = null;
        public Policy CacheProps()
        {
            this._properties = Cosmos.GetQuery("RatableObject", $"SELECT * FROM c WHERE c.Id = {this.Id} OFFSET 0 LIMIT 1").Result.ElementAt(0);
            return this;
        }
        public dynamic GetProperties()
        {
            if (_properties != null)
            {
                return _properties;
            }
            return Cosmos.GetQuery("RatableObject", $"SELECT * FROM c WHERE c.Id = {this.Id} OFFSET 0 LIMIT 1").Result.ElementAt(0);
        }

        public dynamic GetProperty(String propertyName)
        {
            var property = this.GetProperties()[propertyName];
            return property;
        }

        //public static Policy GetLatestPolicy()
        //{
        //    return new Policy((int)Cosmos.GetQuery("RatableObject", "SELECT * FROM c WHERE c.RatableObjectStatusValue = \"Issued\" ORDER BY c._ts DESC OFFSET 0 LIMIT 1").ElementAt(0)["Id"]);
        //}

        //public static Policy GetLatestCancelledPolicy()
        //{
        //    return new Policy((int)Cosmos.GetQuery("RatableObject", "SELECT * FROM c WHERE c.RatableObjectStatusValue = \"Cancelled\" ORDER BY c._ts DESC OFFSET 0 LIMIT 1").ElementAt(0)["Id"]);
        //}

        //public static Policy GetClaimPolicy()
        //{
        //    return new Policy((int)Cosmos.GetQuery("RatableObject", "SELECT * FROM c WHERE c.RatableObjectStatusValue = \"Issued\" OFFSET 0 LIMIT 1").ElementAt(0)["Id"]);
        //}

        public dynamic? Cancel()
        {
            var cancelPolicy = new CancelPolicyObject()
            {
                cancelDenyReasonTypeId = CancellationReason.PolicyCancelledAndReissued,
                cancellationInitiatedBy = CancellationInitiatedBy.Carrier,
                cancellationUnderwriterReason = "Testing"
            };
            return this.Cancel(cancelPolicy);
        }

        public dynamic? Cancel(CancelPolicyObject cancelPolicyObject)
        {
            var response = RestAPI.POST($"/policy/cancelpolicy/{Id}", cancelPolicyObject.ToJObject());
            this.Tether.WaitForProperty("PolicyCancellationEffectiveDate", null, true);

            return response;
        }
        public dynamic Reinstate()
        {
            var reinstatePolicy = new ReinstatePolicyObject()
            {
                reinstatementDate = Tether.PolicyCancellationEffectiveDate ?? throw new NullReferenceException($"tether Id: {this.Tether.Id} Tether.PolicyCancellationEffectiveDate")
            };

            return Reinstate(reinstatePolicy);
        }
        public dynamic Reinstate(ReinstatePolicyObject cancelPolicyObject)
        {
            var response = RestAPI.POST($"/policy/{Id}/reinstate", cancelPolicyObject.ToJObject());

            return response ?? throw new NullReferenceException();
        }
        public dynamic RescindCancelation()
        {
            return RescindCancelation(new RescindPolicyObject());
        }
        public dynamic RescindCancelation(RescindPolicyObject rescindObj)
        {
            var response = RestAPI.POST($"/policy/{Id}/rescindcancel", rescindObj.ToJObject());

            return response ?? throw new NullReferenceException();
        }
        public Quote CreateDraftPolicyEndorsement()
        {
            JObject response = RestAPI.POST($"/policy/{Id}/endorsement/", null);
            
            return this.Context.Quotes.First(it=> it.Id== response.Value<long>("Id"));
        }

        public dynamic? IssueEndorsement()
        {
            var response = RestAPI.POST($"/policy/{Id}/endorsement/issue", null);

            return response;
        }

        //public static policy getlatestauthtransaction()
        //{
        //    return new policy((int)cosmos.getquery("authorizenettransaction", "select * from c where c.ratableobjectstatusvalue = \"issued\" offset 0 limit 1").elementat(0)["id"]);
        //}
        [Obsolete("please use Policy.Quote")]
        public Quote GetQuote()
        {
            return this.Quote;
        }

        public dynamic GetVehicleTypeRisk()
        {
            return this.Quote.GetVehicleTypeRisk();
        }

        public List<Quote> GetDraftEndorsements()
        {
            var endorsements = SQL.executeQuery(@"SELECT *
                               FROM [tether].[TetherApplicationRatableObject]
                               where TetherId = @TetherId AND StatusId=@StatusId; ", ("@TetherId", Tether.Id), ("@StatusId", EntityStatusEnum.Draft));

            try
            {
                var appIds = this.Tether.TetherApplicationRatableObjects.OrderBy(it => it.Id).Where(it => it.StatusId == (int)EntityStatusEnum.Draft);
                return appIds.Select(it=>  this.Context.Quotes.First(quote => quote.Id == it.ApplicationId)).ToList();
            }
            catch (Exception)
            {
                Log.Debug($"PolicyId: {this.Id} TetherId: {Tether.Id}  failed to GetEndorsements");

                throw;
            }
        }

        public string PolicyNumber
        {
            get
            {
                return GetProperty(nameof(PolicyNumber));
            }
        }

        public DateTime TimeFrom
        {
            get
            {
                return Convert.ToDateTime((string)this.GetProperty(nameof(TimeFrom)));
            }
            set
            {
                this[nameof(TimeFrom)] = value.ToString("O");
            }
        }

        public DateTime TimeTo
        {
            get
            {
                return Convert.ToDateTime((string)this.GetProperty(nameof(TimeTo)));
            }
            set
            {
                this[nameof(TimeTo)] = value.ToString("O");
            }
        }

        public DateTime? CancellationDate
        {
            get
            {
                var cancellationDate = this.GetProperty("CancellationDate");

                return cancellationDate ?? Convert.ToDateTime((string?)cancellationDate);
            }
        }

        public string LatestRatingResponseGroupId
        {
            get
            {
                return this.GetProperty(nameof(LatestRatingResponseGroupId));
            }
        }

        //public JArray? RatingGroup
        //{
        //    get
        //    {
        //        return RestAPI.GET($"/rating/group/{LatestRatingResponseGroupId}");
        //    }
        //}

        public bool? AccidentPreventionCredit
        {
            get
            {
                return (bool)(this?["RatingFactors"]?["AccidentPreventionCredit"] ?? false);
            }
        }

        public String CoveredAutos
        {
            get
            {
                //broken
                return (String?)this["RatingFactors"]?["CoveredAutos"] ?? throw new Exception("covered autos returned null");
            }
        }

        public String? MotorCarrierFiling
        {
            get
            {
                return (String?)this["Metadata"]?["MotorCarrierFiling"];
            }
        }

        public String BillingType
        {
            get
            {
                //broken
                return (String?)this["RatingFactors"]?["BillingType"] ?? throw new Exception("RatingFactors.BillingType returned null");
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
                return (String?)this["RatingFactors"]?["paymentPlan"] ?? throw new Exception("RatingFactors.paymentPlan returned null");
            }
        }

        public String isEft
        {
            get
            {
                return (String?)this["RatingFactors"]?["IsEft"] ?? throw new Exception("RatingFactors.IsEft returned null");
            }
        }

        public int? RadiusOfOperation
        {
            get
            {
                if (int.TryParse((String?)this["Metadata"]?["RadiusOfOperation"] ?? throw new Exception("Metadata.RadiusOfOpertion returned null"), out int result))
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
        }

        public class CancelPolicyObject
        {
            public CancellationReason cancelDenyReasonTypeId { get; set; }

            /// <summary>
            /// Use yyyy-MM-dd format
            /// </summary>
            public string policyCancellationEffectiveDate { get; set; } = DateTime.Now.AddDays(2).ToString("O");

            public CancellationInitiatedBy cancellationInitiatedBy { get; set; }

            public string? cancellationUnderwriterReason { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public DateTime? reinstatementDate { get; set; }

            public JObject ToJObject()
            {
                return JObject.FromObject(this);
            }
        }

        public class ReinstatePolicyObject
        {
            public DateTimeOffset reinstatementDate { get; set; }

            public string reinstatementReason = "Reinstate Automated API";
            public JObject ToJObject()
            {
                return JObject.FromObject(this);
            }
        }

        public class RescindPolicyObject
        {
            public string rescindPendingCancellationReason { get; set; } = "Rescind Automated API";

            public JObject ToJObject()
            {
                return JObject.FromObject(this);
            }
        }

    }
}
