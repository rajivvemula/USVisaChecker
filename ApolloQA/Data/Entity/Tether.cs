﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApolloQA.Source.Helpers;
namespace ApolloQA.Data.Entity
{
    public class Tether
    {

        public Tether(int Id)
        {
            this.Id = Id;
            load();
        }
        public Tether(long Id)
        {
            this.Id = Id;
            load();
        }

        private void load()
        {
         
            var props = SQL.executeQuery($"SELECT * FROM [tether].[Tether] WHERE Id = {Id}")[0];

            foreach (var prop in props)
            {
                try
                {
                    this.GetType().GetProperty(prop.Key).SetValue(this, prop.Value);
                }
                catch(Exception ex)
                {
                    Log.Critical("Property Key: " + prop.Key + " Property Value: "+ prop.Value??"null");
                    throw ex;
                }
            }
           
        }

        private void SetProperty(string propertyName, object value)
        {
            SQL.executeQuery($"UPDATE [tether].[Tether] SET {propertyName}=@value WHERE Id = {this.Id} ", ("@value", value));

        }

        public static Tether GetLatestTether()
        {
            var tetherCandidates = SQL.executeQuery($"SELECT TOP (1) Id FROM [tether].[Tether] where PolicyNumber is not null order by Id desc;");

            if (tetherCandidates.Any())
            {
                return new Tether(tetherCandidates[0]["Id"]);
            }
            else
            {
                Functions.IssueNewQuoteThroughAPI();
                return GetLatestTether();
            }
        }

        public readonly long Id;

        private int _LineId { get; set; }
        public int LineId {
            get { return _LineId; }
            set {
                    this.SetProperty("LineId", value);
                    _LineId = value;
                } 
        }

        public long NamedInsuredId { get; set; }

        public long CarrierId { get; set; }

        public long? MailingAddressId { get; set; }

        public long? PhysicalAddressId { get; set; }

        public int? GoverningStateId { get; set; }

        public long? AgentId { get; set; }

        private long _CurrentApplicationId { get; set; }
        public long CurrentApplicationId
        {
            get { return _CurrentApplicationId; }
            set
            {
                this.SetProperty("CurrentApplicationId", value);
                _CurrentApplicationId = value;
            }
        }

        private long _CurrentRatableObjectId { get; set; }
        public long CurrentRatableObjectId
        {
            get { return _CurrentRatableObjectId; }
            set
            {
                this.SetProperty("CurrentRatableObjectId", value);
                _CurrentRatableObjectId = value;
            }
        }
        public Policy CurrentPolicy => new Policy(CurrentRatableObjectId);
        

        public DateTime EffectiveDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string ApplicationNumber { get; set; }

        public string PolicyNumber { get; set; }

        public DateTime? FirstIssuedDate { get; set; }

        public DateTime? PolicyCancellationDate { get; set; }

        public DateTime? PolicyCancellationEffectiveDate { get; set; }

        public bool IsIneligible { get; set; }

        public DateTime InsertDateTime { get; set; }

        public string InsertedBy { get; set; }

        public long InsertedByPersonId { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        public string UpdatedBy { get; set; }

        public long? UpdatedByPersonId { get; set; }

        public int SourceSystemId { get; set; }

        public string SourceSystemKey { get; set; }

        public int StatusId { get; set; }

    }
}