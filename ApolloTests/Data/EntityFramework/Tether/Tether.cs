using Polly;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using ApolloTests.Data.Entities;
using Newtonsoft.Json;

namespace ApolloTests.Data.EntityFramework.Tether
{

    [Table("Tether", Schema = "tether")]
    public class Tether : BaseEntity
    {

        [JsonIgnore]
        public ApolloContext Context { get; }
        public Tether(ApolloContext context)
        {
            Context = context;
        }
        public long Id { get; set; }

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

        public DateTimeOffset? CurrentApplicationExpirationDate { get; set; }

        public long? CurrentRatableObjectId { get; set; }

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

        public DateTimeOffset? PolicyCancellationEffectiveDate { get; set; }

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
        public static Tether GetLatestTether()
        {
            var tetherCandidates = GetSQLService().executeQuery($"SELECT TOP (1) Id FROM [tether].[Tether] where PolicyNumber is not null order by Id desc;");

            if (tetherCandidates.Any())
            {
                return new Tether(tetherCandidates[0]["Id"]);
            }
            else
            {
                //Functions.GetQuotedQuoteThroughAPI();
                return GetLatestTether();
            }
        }
        public static Tether GetPastTether()
        {
            var tetherCandidate = GetSQLService().executeQuery($"SELECT TOP (1) Id FROM [tether].[Tether] where PolicyNumber is not null and EffectiveDate < GETDATE() order by Id desc;");

            return new Tether(tetherCandidate[0]["Id"]);
        }

        public static Tether GetTether(long QuoteId)
        {
            var tetherCandidates = GetSQLService().executeQuery(@$"SELECT TOP (1) [tether].[Tether].Id
                                                    FROM [tether].[Tether]
                                                    LEFT JOIN [tether].[TetherApplicationRatableObject] on [tether].[Tether].Id = [tether].[TetherApplicationRatableObject].TetherId
                                                    where CurrentApplicationId = {QuoteId} OR ApplicationId = {QuoteId} ;");

            try
            {
                return new Tether(tetherCandidates[0]["Id"]);
            }
            catch (Exception)
            {
                Log.Critical($"Error retrieving Tether for ApplicationId: {QuoteId}");
                throw;
            }
        }
       
    }

}
