using ApolloTests.Data.Entities.Context;
using HitachiQA.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Polly;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ApolloTests.Data.Entities
{
    public class Policy : BaseEntityEF
    {
        public Policy(CosmosContext context) : base(context) { }

        [Key]
        public string id { get; set; }
        public string ApplicationNumber { get; set; }
        public long TetherId { get; set; }
        public long ApplicationId { get; set; }
        public Quote Quote => this.ContextCosmos.Quotes.First(it => it.Id == ApplicationId);
        public Tether.Tether Tether => this.ContextSQL.Tether.First(it => it.Id == TetherId);
        public long _ts { get; set; }

        [Required]
        public string Discriminator { get; set; }

        [NotMapped]
        public int EntityTypeId => 100;



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

            if(DateTime.Parse(cancelPolicyObject.policyCancellationEffectiveDate)<DateTime.Now)
            {
                var cancelJobId = SQL.executeQuery("select * from system.job where [Name]='CancelPolicies';")[0]["Id"];
                RunRatableObjectManagementFunction($"jobtrigger/{cancelJobId}");
                Tether.waitForTetherStatus("CANCELLED");
            }
            

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
        public dynamic Reinstate(ReinstatePolicyObject reinstateObject)
        {
            var response = RestAPI.POST($"/policy/{Id}/reinstate", reinstateObject.ToJObject());
            if (reinstateObject.reinstatementDate < DateTime.Now)
            {
                Tether.waitForTetherStatus("ISSUED");
            }
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
            
            return this.ContextCosmos.Quotes.First(it=> it.Id== response.Value<long>("Id"));
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
            return this.Quote.GetRisksByType(RiskTypeEnum.Vehicle);
        }

        public List<Quote> GetDraftEndorsements()
        {
            try
            {
                var appIds = this.Tether.TetherApplicationRatableObjects.OrderBy(it => it.Id).Where(it => it.StatusId == (int)EntityStatusEnum.Draft);
                return appIds.Select(it=>  this.ContextCosmos.Quotes.First(quote => quote.Id == it.ApplicationId)).ToList();
            }
            catch (Exception)
            {
                Log.Debug($"PolicyId: {this.Id} TetherId: {Tether.Id}  failed to GetEndorsements");

                throw;
            }
        }

        public string PolicyNumber { get; set; }

        public DateTimeOffset TimeFrom { get; set; }

        public DateTimeOffset TimeTo { get; set; }

        public string LatestRatingResponseGroupId { get; set; }

        [NotMapped]
        public JArray? RatingGroup => RestAPI.GET($"/rating/group/{LatestRatingResponseGroupId}");

        public bool? AccidentPreventionCredit => throw new NotImplementedException("might need rating factor model");

        public String CoveredAutos => throw new NotImplementedException("might need rating factor model");
        public String? MotorCarrierFiling => throw new NotImplementedException("might need rating factor model");

        public String BillingType => throw new NotImplementedException("might need rating factor model");

        public int? SelectedRatingPackageId { get; set; }

        public String PaymentPlan => throw new NotImplementedException("might need rating factor model");

        public String isEft => throw new NotImplementedException("might need rating factor model");

        public int? RadiusOfOperation => throw new NotImplementedException("might need metadata model");

        public class CancelPolicyObject
        {
            public CancellationReason cancelDenyReasonTypeId { get; set; }

            /// <summary>
            /// Use yyyy-MM-dd format
            /// </summary>
            public string policyCancellationEffectiveDate { get; set; } = DateTime.Now.AddDays(2).ToString("O");

            public CancellationInitiatedBy cancellationInitiatedBy { get; set; }

            public string? cancellationUnderwriterReason { get; set; } = "Testing";

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
