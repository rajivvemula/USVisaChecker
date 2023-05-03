using ApolloTests.Data.EntityBuilder.Entities;
using ApolloTests.Data.Entities.Context;
using HitachiQA.Helpers;
using LivingDoc.Dtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApolloTests.Data.EntityBuilder;

namespace ApolloTests.Data.Entities.Risk
{
    public class DriverRisk : RiskBase 

    {
        public DriverRisk(CosmosContext context) : base(context) {}

        public DriverRisk(QuoteBuilder builder, bool loadDefaults=true): base(builder)
        {
            if (loadDefaults)
                LoadDefaults();
            
        }
        public DriverRisk() { }
        public void LoadDefaults()
        {
            RiskTypeId = (int)RiskTypeEnum.Driver;
            OutputMetadata = new OutputMetadataDriver()
            {
                DriverHistory = new DriverHistory(),
                QuestionResponses = new List<QuestionResponse>()

            };

            Driver = new Driver()
            {
                id = "00000000-0000-0000-0000-000000000000",
                Person = new Person()
                {
                    PrimaryName = new PrimaryName()
                    {
                        Given = "Miguel",
                        Middle = string.Empty,
                        Surname = "Acosta",
                        Suffix = string.Empty,
                        StatusId = 0
                    },
                    StatusId=0
                },

                DateOfBirth = new DateTime(1965, 10, 26, 04, 00, 00),
                StateProvince = new Entities.Location.StateProvince(),
                LicenseNo = string.Empty,
                StatusId = 0
               // DriverHistory = new DriverHistory()
            };
        }

        [JsonProperty("driver")]
        public override Driver Driver { get; set; }

        [JsonConverter(typeof(ConcreteTypeConverter<OutputMetadataDriver>))]
        public override IOutputMetadata OutputMetadata { get; set; }

        public bool ShouldSerializeClassCode() => false;

        public int GetPoints(Quote quote, string DriverRatingPlan)
        {
            int resultPoints = 0;
            List<Dictionary<string, string>> DR2 = Functions.ParseCSV(".\\Data\\RatingManual\\DR.2.csv");

            var year = 365;
            var three_years = year * 3;
            var five_years = year * 5;
            var outputMetadata = ((OutputMetadataDriver)OutputMetadata);
            var driverHistory = outputMetadata.DriverHistory;

            foreach (var violation in driverHistory.Violations)
            {

                if ((DateTime.Now - violation.Date).TotalDays < three_years)
                {
                    var row = DR2.Find(it => it["Criteria for Rating"] == "Violations");

                    resultPoints += int.Parse(row?[DriverRatingPlan] ?? throw new NullReferenceException());
                }
            }

            foreach (var accident in driverHistory.Accidents)
            {
                if (accident.Reason == "ANANF")
                {
                    continue;
                }

                if ((DateTime.Now - accident.Date).TotalDays < three_years)
                {
                    var row = DR2.Find(it => it["Criteria for Rating"] == "Chargeable Accidents");

                    resultPoints += int.Parse(row?[DriverRatingPlan] ?? throw new Exception());
                }
            }

            foreach (var conviction in driverHistory.Convictions)
            {
                Dictionary<string, string>? row = null;
                if ((DateTime.Now - conviction.Date).TotalDays < year)
                {
                    row = DR2.Find(it => it?["Criteria for Rating"] == "Conviction: in past 1 year");
                }
                else if ((DateTime.Now - conviction.Date).TotalDays < three_years)
                {
                    row = DR2.Find(it => it?["Criteria for Rating"] == "Conviction: in 2nd or 3rd past year");
                }
                else if ((DateTime.Now - conviction.Date).TotalDays < five_years)
                {
                    row = DR2.Find(it => it?["Criteria for Rating"] == "Conviction: in 4th or 5th past year");
                }
                if (row == null)
                {
                    throw new Exception("Conviction row was not found in DR.2");
                }
                resultPoints += int.Parse(row[DriverRatingPlan]);

            }


            if (this.Driver.StateProvince.Code != quote.GoverningStateCode)
            {
                var row = DR2.First(it => it["Criteria for Rating"] == "Drivers license State different than state of applicant or policyholder address");

                resultPoints += int.Parse(row[DriverRatingPlan]);
            }

            var cdlResponse = outputMetadata.QuestionResponses.FirstOrDefault(it => it.Alias == "CDL").Response;

            if (!string.IsNullOrWhiteSpace(cdlResponse))
            {
                Dictionary<string, string>? row = null;

                if (cdlResponse == "0" || cdlResponse == "1")
                {
                    row = DR2.Find(it => it?["Criteria for Rating"] == "CDL Experience: Less than 1 Year");
                }
                else if (cdlResponse == "2")
                {
                    row = DR2.Find(it => it?["Criteria for Rating"] == "CDL Experience: 1 to 2 Years");
                }
                row.NullGuard();
                resultPoints += int.Parse(row[DriverRatingPlan]);


            }

            //needs implementation
            //
            //Unverifiable MVR 
            //Unreported Driver Accident (points in addition to Chargeable Accident Points) 
            //Unreported Driver Inspection
            //Drivers license from outside United States

            return resultPoints;

        }

    }

    public class OutputMetadataDriver : IOutputMetadata
    {
        public List<QuestionResponse> QuestionResponses { get; set; } 
        public DriverHistory DriverHistory { get; set; }

    }

}
