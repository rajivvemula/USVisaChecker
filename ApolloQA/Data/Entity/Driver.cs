using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json.Linq;
using ApolloQA.Source.Driver;
using ApolloQA.Source.Helpers;
using System.IO;

namespace ApolloQA.Data.Entity
{
    public class Driver
    {
        public readonly long Id;

        public Driver(int Id)
        {
            this.Id = Id;

        }
        public Driver(long Id)
        {
            this.Id = Id;

        }

        public dynamic this[String propertyName] { get { return this.GetProperty(propertyName); }
        }
        public dynamic GetProperty(String propertyName)
        {
            var property = this.GetProperties()[propertyName];
            return property is DBNull ? null : property;
        }
        public Dictionary<String, dynamic> GetProperties()
        {
            return SQL.executeQuery(@"SELECT Driver.*, State.Code as StateCode 
                                    FROM [risk].[Driver] Driver 
                                    LEFT JOIN location.StateProvince State on State.Id = Driver.StateProvinceId
                                    where Driver.Id = @Id;", (("@Id", $"{this.Id}")))[0];
        }
        public void SetProperties(params (String key, dynamic value)[] fields)
        {
            var fieldMap = new Dictionary<String, dynamic>();
            String keyValue = "";
            for (int i = 0; i < fields.Length; i++)
            {
                keyValue += $" {fields[i].key} = @{fields[i].key}";

                fieldMap.Add($"@{fields[i].key}", fields[i].value);
            }

            fieldMap.Add("@Id", $"{this.Id}");

            SQL.executeQuery($"UPDATE risk.Driver SET {keyValue} where Id=@Id;", fieldMap.Select(field => (field.Key, field.Value)).ToArray())    ;

        }

        private long? _RiskId { get; set; }
        public long RiskId
        {
            get
            {
                if(_RiskId == null)
                {
                    _RiskId = this.GetProperty("RiskId");
                }
                return (long)_RiskId;
            }
        }
        public long PersonId
        {
            get
            {
                return this.GetProperty("PersonId");
            }
        }
        public DateTimeOffset DateOfBirth
        {
            get
            {
                return this.GetProperty("DateOfBirth");
            }
        }
        public int Age
        {
            get
            {
                int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
                int dob = int.Parse(DateOfBirth.ToString("yyyyMMdd"));
                int age = (now - dob) / 10000;

                return age;
            }
        }
        public string LicenseNo
        {
            get
            {
                return this.GetProperty("LicenseNo");
            }
        }
        public DateTimeOffset LicenseExpirationDate
        {
            get
            {
                return this.GetProperty("LicenseExpirationDate");
            }
        }

        public dynamic GetQuestionResponse(Quote quote, string alias)
        {
            var risks = (JArray)quote.GetProperty("Risks");
            var risk = risks.FirstOrDefault(it => it["RiskId"].ToObject<long>() == this.RiskId);

            foreach (JObject response in risk["OutputMetaDataEntity"]["QuestionResponses"])
            {
                if (response["QuestionAlias"].ToString() == alias)
                {
                    return ((JValue)response["Response"]).Value;
                }
            }
            return null;
        }

        public List<Incident> GetAccidents(Quote quote)
        {
            var result = new List<Incident>();

            var risk = ((JArray)quote.GetProperty("Risks")).FirstOrDefault(it => it["RiskId"].ToObject<long>() == this.RiskId);

            var incidents = (JArray)risk["OutputMetaDataEntity"]["DriverHistory"]["Accidents"];


            foreach(var incident in incidents)
            {
                result.Add(new Incident
                                (
                                    "Accident",
                                    incident["Date"].ToObject<DateTimeOffset>(),
                                    incident["State"].ToString(),
                                    incident["Reason"].ToString(), 
                                    this
                                )
                            );
            }
            return result;
        }
        public List<Incident> GetViolations(Quote quote)
        {
            var result = new List<Incident>();

            var risk = ((JArray)quote.GetProperty("Risks")).FirstOrDefault(it => it["RiskId"].ToObject<long>() == this.RiskId);

            var incidents = (JArray)risk["OutputMetaDataEntity"]["DriverHistory"]["Violations"];


            foreach (var incident in incidents)
            {
                result.Add(new Incident
                                (
                                    "Violation",
                                    incident["Date"].ToObject<DateTimeOffset>(),
                                    incident["State"].ToString(),
                                    incident["Reason"].ToString(),
                                    this
                                )
                            );
            }
            return result;
        }
        public List<Incident> GetConvictions(Quote quote)
        {
            var result = new List<Incident>();

            var risk = ((JArray)quote.GetProperty("Risks")).FirstOrDefault(it => it["RiskId"].ToObject<long>() == this.RiskId);

            var incidents = (JArray)risk["OutputMetaDataEntity"]["DriverHistory"]["Convictions"];


            foreach (var incident in incidents)
            {
                result.Add(new Incident
                                (
                                    "Conviction",
                                    incident["Date"].ToObject<DateTimeOffset>(),
                                    incident["State"].ToString(),
                                    incident["Reason"].ToString(),
                                    this
                                )
                            );
            }
            return result;
        }
        public int GetPoints(Quote quote, string DriverRatingPlan)
        {
            int resultPoints = 0;
            List<Dictionary<string, string>> DR2 = Functions.parseCSV(Path.Join(Setup.SourceDir, "/Data/RatingManual/DR.2.csv"));

            var year = 365;
            var three_years = year * 3;
            var five_years = year * 5;


            foreach (var violation in GetViolations(quote))
            {
                
                if((DateTime.Now - violation.Date).TotalDays< three_years)
                {
                    var row = DR2.Find(it => it["Criteria for Rating"] == "Violations");

                    resultPoints += int.Parse(row[DriverRatingPlan]);
                }
            }

            foreach (var accident in GetAccidents(quote))
            {
                if(accident.ReasonCode == "ANANF")
                {
                    continue;
                }

                if ((DateTime.Now - accident.Date).TotalDays < three_years)
                {
                    var row = DR2.Find(it => it["Criteria for Rating"] == "Chargeable Accidents");

                    resultPoints += int.Parse(row[DriverRatingPlan]);
                }
            }
           
            foreach (var conviction in GetConvictions(quote))
            {
                Dictionary<string, string> row = null;
                if ((DateTime.Now - conviction.Date).TotalDays < year)
                {
                    row = DR2.Find(it => it["Criteria for Rating"] == "Conviction: in past 1 year");
                }
                else if ((DateTime.Now - conviction.Date).TotalDays < three_years)
                {                    
                    row = DR2.Find(it => it["Criteria for Rating"] == "Conviction: in 2nd or 3rd past year");
                }
                else if ((DateTime.Now - conviction.Date).TotalDays < five_years)
                {
                    row = DR2.Find(it => it["Criteria for Rating"] == "Conviction: in 4th or 5th past year");
                }
                if(row == null)
                {
                    throw new Exception("Conviction row was not found in DR.2");
                }
                resultPoints += int.Parse(row[DriverRatingPlan]);

            }

           
            if (this.GetProperty("StateCode") != quote.GoverningStateCode)
            {
                var row = DR2.Find(it => it["Criteria for Rating"] == "Drivers license State different than state of applicant or policyholder address");

                resultPoints += int.Parse(row[DriverRatingPlan]);
            }
            
            if(quote.GetQuestionResponse("CDL") is var CDL && CDL!= null && (string)CDL!="0")
            {
                Dictionary<string, string> row = null;

                if (CDL == "1")
                {
                    row = DR2.Find(it => it["Criteria for Rating"] == "CDL Experience: Less than 1 Year");
                }
                else if (CDL == "2")
                {
                    row = DR2.Find(it => it["Criteria for Rating"] == "CDL Experience: 1 to 2 Years");
                }

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






        public class Incident
        {
            public string Type { get; }
            public DateTimeOffset Date { get;  }
            public string StateCode { get;  }
            public string ReasonCode { get;  }
            public Driver Driver { get;}

            public Incident(string type, DateTimeOffset date, string stateCode, string reasonCode)
            {
                this.Type = type;
                this.Date = date;
                this.StateCode = stateCode;
                this.ReasonCode = reasonCode;
            }
            public Incident(string type, DateTimeOffset date, string stateCode, string reasonCode, Driver driver)
            {
                this.Type = type;
                this.Date = date;
                this.StateCode = stateCode;
                this.ReasonCode = reasonCode;
                this.Driver = driver;
            }
        }


    }
}
