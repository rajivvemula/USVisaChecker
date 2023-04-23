using Polly;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using DocumentFormat.OpenXml.InkML;
using ApolloTests.Data.Entities.Context;

namespace ApolloTests.Data.Entities.Tether
{

    [Table("Tether", Schema = "tether")]
    public class Tether : BaseEntityEF
    {
        public Tether(SQLContext context) : base(context) { }

        public int LineId { get; set; }

        public int SubLineId { get; set; }

        public long? NamedInsuredId { get; set; }

        public long? InsuredId { get; set; }

        public long CarrierId { get; set; }

        public long AgencyId { get; set; }

        public long? BillingAccountId { get; set; }

        public int? GoverningStateId { get; set; }

        public long? AgentId { get; set; }

        public long CurrentApplicationId { get; set; }

        public Quote CurrentQuote => this.ContextCosmos.Quotes.First(it=> it.Id == CurrentApplicationId);

        public DateTimeOffset? CurrentApplicationExpirationDate { get; set; }

        public long? CurrentRatableObjectId { get; set; }

        public Policy CurrentPolicy => this.ContextCosmos.Policies.First(it => it.Id == CurrentRatableObjectId);

        public DateTimeOffset EffectiveDate { get; set; }

        public DateTimeOffset ExpirationDate { get; set; }

        public int? ClientOffset { get; set; }

        public string? ApplicationNumber { get; set; }

        public string? PolicyNumber { get; set; }

        [ListenForChanges]
        public virtual int? TermId { get; set; }

        public long? RootTetherId { get; set; }

        public DateTimeOffset? FirstIssuedDate { get; set; }

        public DateTimeOffset? PolicyCancellationDate { get; set; }

        [ListenForChanges]
        public virtual DateTimeOffset? PolicyCancellationEffectiveDate { get; set; }

        public DateTimeOffset? PolicyCancellationMailingDate { get; set; }

        public DateTimeOffset? PolicyPendingCancellationMailingDate { get; set; }

        public DateTimeOffset? PolicyReinstatementDate { get; set; }

        public bool IsIneligible { get; set; }

        public bool IsManualRenewalReview { get; set; }

        public bool NonRenew { get; set; }

        public DateTimeOffset? PolicyNonRenewalNoticeMailingDate { get; set; }

        public DateTimeOffset InsertDateTime { get; set; }

        public string InsertedBy { get; set; }

        public long InsertedByPersonId { get; set; }

        public DateTimeOffset? UpdateDateTime { get; set; }

        public string UpdatedBy { get; set; }

        public long? UpdatedByPersonId { get; set; }

        public int? SourceSystemId { get; set; }

        public string? SourceSystemKey { get; set; }

        public int StatusId { get; set; }

        public virtual List<TetherApplicationRatableObject> TetherApplicationRatableObjects { get; set; }


        public string TetherStatusCode => this.TetherApplicationRatableObjects.Last().TetherStatusType.ToString();
        public void waitForTetherStatus(string statusCode, bool waitForNotInStatus = false)
        {
            this.WaitForProperty("TetherStatusCode", statusCode, waitForNotInStatus);
        }
        public static Tether GetLatestTether(SQLContext context)
        {
            return context.Tether.OrderBy(it=> it.Id).Last(it => it.PolicyNumber != null);
        }
        public static Tether GetPastTether(SQLContext context)
        {
            return context.Tether.OrderBy(it => it.Id).Last(it => it.PolicyNumber != null && it.EffectiveDate < DateTimeOffset.Now);

        }

        public static Tether GetTether(SQLContext context, long tetherId)
        {
            try
            {
                return context.Tether.First(it => it.Id == tetherId);
            }
            catch (Exception)
            {
                Log.Critical($"Error retrieving Tether");
                throw;
            }
          
        }
       
    }

}
