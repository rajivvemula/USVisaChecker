using ApolloTests.Data.Entities;
using HitachiQA.Helpers;
using Newtonsoft.Json.Linq;
using Polly;
using System;
using System.Diagnostics;
using System.Linq;

namespace ApolloTests.Data.Entity
{
    public class Tether:BaseEntity
    {
        public Tether(int Id)
        {
            this.Id = Id;
            Load();
        }

        public Tether(long Id)
        {
            this.Id = Id;
            Load();
        }

        public void Load()
        {
            var props = SQL.executeQuery($"SELECT * FROM [tether].[Tether] WHERE Id = {Id}")[0];

            foreach (var prop in props)
            {
                try
                {
                    if (prop.Key == "Id")
                    {
                        continue;
                    }
                    this.GetType().GetProperty(prop.Key)?.SetValue(this, prop.Value is DBNull ? null : prop.Value);
                }
                catch (Exception)
                {
                    Log.Critical("Property Key: " + prop.Key + " Property Value: " + prop.Value ?? "null");
                    throw;
                }
            }
        }

        public T? GetProperty<T>(string key)
        {
            var prop = this.GetType().GetProperty(key);
            prop.NullGuard(key);
            return (T?)prop.GetValue(this, null);

        }

        public void SetProperty(string propertyName, object value)
        {
            SQL.executeQuery($"UPDATE [tether].[Tether] SET {propertyName}=@value WHERE Id = {this.Id} ", ("@value", value));
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

        public void waitForTetherStatus(string statusCode, bool waitForNotInStatus = false)
        {
            var sw = Stopwatch.StartNew();

            var wait = Polly.Policy.HandleResult<bool>(false)
                .WaitAndRetry(30, _ => TimeSpan.FromSeconds(1));
            var success = wait.Execute(() =>
            {
                if (waitForNotInStatus)
                    return this.TetherStatusCode != statusCode;
                else
                    return this.TetherStatusCode == statusCode;

            });
            sw.Stop();
            Log.Debug($"seconds until Tether {(waitForNotInStatus ? "was out of" : "was in")} {statusCode} status: {sw.Elapsed.TotalSeconds}");

            if (!success)
                throw new TimeoutException($"Timeout waiting for tether Status {(waitForNotInStatus ? "to be out of" : "to be in")} {statusCode} current status: {this.TetherStatusCode}");



        }
        public void waitForTetherProperty(string propName, object? value, bool waitForValueNotEqual)
        {
            var sw = Stopwatch.StartNew();

            var wait = Polly.Policy.HandleResult<bool>(false)
                .WaitAndRetry(30, _ => TimeSpan.FromSeconds(1));
            object? result=null;
            var success = wait.Execute(() =>
            {
                this.Load();
                result = this.GetProperty<object>(propName);
                if(waitForValueNotEqual)
                {
                    return result != value;
                }
                else
                {
                    return result == value;
                }

            });
            sw.Stop();
            Log.Debug($"seconds until {propName} {(waitForValueNotEqual ? "was not" : "was")} {value} status: {sw.Elapsed.TotalSeconds}");

            if (!success)
                throw new TimeoutException($"Timeout waiting for tether {propName} {(waitForValueNotEqual ? "to be out of" : "to be")} {value} current status: {result}");



        }

      

        public readonly long Id;

        public string TetherStatusCode => SQL.executeQuery(@$"SELECT TST.Code
                                                      FROM [tether].[TetherApplicationRatableObject] TAR
                                                      LEFT JOIN [tether].[TetherStatusType] TST on TAR.TetherStatusTypeId = TST.Id
                                                      WHERE TAR.TetherId={Id}
                                                        ")[0]["Code"];
        public List<Dictionary<string, dynamic>> BillingSchedule => SQL.executeQuery(@$"SELECT BAAP.TetherId, AB.Id as ArrangementBillId, AB.*  
                                                            FROM [billing].[BillingAccountArrangementPolicy] BAAP
                                                            LEFT JOIN billing.ArrangementBill AB on AB.BillingAccountArrangementId = BAAP.BillingAccountArrangementId
                                                            where BAAP.TetherId={this.Id}");
        public List<Dictionary<string, dynamic>> EventHistory => SQL.executeQuery(@$"SELECT ET.[Name] as EventTypeName, TH.* 
                                                                                    FROM [tether].[TetherHistory] TH
                                                                                    LEFT JOIN tether.TetherHistoryEventType ET on TH.EventTypeId=ET.Id 
                                                                                    where TetherId ={this.Id}");
        private int _LineId { get; set; }

        public int LineId
        {
            get { return _LineId; }
            private set
            {
                _LineId = value;
            }
        }

        public int SubLineId { get; set; }

        public long NamedInsuredId { get; set; }

        public long InsuredId { get; set; }

        public long CarrierId { get; set; }

        public long AgencyId { get; set; }

        public long BillingAccountId { get; set; }

        public long? MailingAddressId { get; set; }

        public long? PhysicalAddressId { get; set; }

        public int? GoverningStateId { get; set; }

        public long? AgentId { get; set; }

        private long _CurrentApplicationId { get; set; }

        public long CurrentApplicationId
        {
            get { return _CurrentApplicationId; }
            private set
            {
                _CurrentApplicationId = value;
            }
        }

        private long? _CurrentRatableObjectId { get; set; }

        public long? CurrentRatableObjectId
        {
            get { return _CurrentRatableObjectId; }
            private set
            {
                _CurrentRatableObjectId = value;
            }
        }

        public Policy CurrentPolicy => new Policy(CurrentRatableObjectId ?? throw new ArgumentNullException());

        public DateTimeOffset EffectiveDate { get; set; }

        public DateTimeOffset ExpirationDate { get; set; }

        public string? ApplicationNumber { get; set; }

        public string? PolicyNumber { get; set; }

        public DateTimeOffset? FirstIssuedDate { get; set; }

        public DateTimeOffset? PolicyCancellationDate { get; set; }

        public DateTimeOffset? PolicyCancellationEffectiveDate { get; set; }

        public bool IsIneligible { get; set; }

        public DateTimeOffset InsertDateTime { get; set; }

        public string? InsertedBy { get; set; }

        public long InsertedByPersonId { get; set; }

        public DateTimeOffset? UpdateDateTime { get; set; }

        public DateTimeOffset? CurrentApplicationExpirationDate { get; set; }

        public string? UpdatedBy { get; set; }

        public long? UpdatedByPersonId { get; set; }

        public int? SourceSystemId { get; set; }

        public string? SourceSystemKey { get; set; }

        public int StatusId { get; set; }

        public int? ClientOffset { get; set; }

        public int? TermId { get; set; }

        public Int64? RootTetherId { get; set; }

        public DateTimeOffset? PolicyCancellationMailingDate { get; set; }

        public DateTimeOffset? PolicyPendingCancellationMailingDate { get; set; }

        public DateTimeOffset? PolicyReinstatementDate { get; set; }

        public bool IsManualRenewalReview { get; set; }

        public bool NonRenew { get; set; }

        public DateTimeOffset? PolicyNonRenewalNoticeMailingDate { get; set; }

    }
}