using ApolloTests.Data.EntityBuilder;
using ApolloTests.Data.Entities.Context;
using ApolloTests.Data.Entities.Location;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApolloTests.Data.Entities.Risk
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Driver : BaseEntityEF
    {
        public Driver(CosmosContext ctx) : base(ctx) { }
        public Driver() { }

        [JsonProperty("id")]
        [NotMapped]
        public string? id { get; set; }

        [JsonIgnore]
        public new long Id { get; set; }

        [JsonProperty("dateOfBirth")]
        public DateTimeOffset DateOfBirth { get; set; }

        [JsonProperty("stateProvinceId")]
        [HydratorAttr("GoverningStateId")]
        public int StateProvinceId { get; set; }

        [JsonIgnore]
        public int DriverTypeId { get; set; }

        [JsonIgnore]
        public bool IsRatableType { get; set; }

        [JsonIgnore]
        public DateTimeOffset? LicenseExpirationDate { get; set; }

        [HydratorAttr("LicenseNumber")]
        [JsonProperty("licenseNo")]
        public string LicenseNo { get; set; }

        [JsonProperty("personId")]
        public int? PersonId { get; set; }

        [JsonProperty("riskId")]
        public int? RiskId { get; set; }

        [JsonProperty("driverHistory")]
        public DriverHistory DriverHistory { get; set; }

        [JsonProperty("stateProvince")]
        [NotMapped]
        public StateProvince StateProvince { get; set; }

        [JsonProperty("person")]
        [NotMapped]
        public Person Person { get; set; }


        [JsonProperty("statusId")]
        [NotMapped]
        public int StatusId { get; set; }

        [NotMapped]
        [JsonIgnore]
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
    }
    public class Person
    {
        [JsonProperty("primaryName")]
        public PrimaryName PrimaryName { get; set; }

        [JsonProperty("statusId")]
        public int StatusId { get; set; }
    }

    public class PrimaryName
    {

        [JsonProperty("given")]
        public string Given { get; set; }

        [JsonProperty("middle")]
        public string Middle { get; set; }

        [JsonProperty("surName")]
        public string Surname { get; set; }

        [JsonProperty("suffix")]
        public string Suffix { get; set; }

        [JsonProperty("statusId")]
        public int StatusId { get; set; }
    }

    public class DriverHistory
    {

        [JsonIgnore]
        public int? CDLExperience { get; set; }

        [JsonIgnore]
        public int? NumberOfInspections { get; set; }


        [JsonProperty("accidents")]
        public List<Incident> Accidents { get; set; } = new();

        [JsonProperty("convictions")]
        public List<Incident> Convictions { get; set; } = new();

        [JsonProperty("violations")]
        public List<Incident> Violations { get; set; } = new();

        public class Incident:BaseEntityEF
        {
            public Incident(CosmosContext ctx):base(ctx)
            {
               
            }
            public Incident() { }
            public Incident(bool loadDefaults)
            {
                LoadDefaults();
            }
            public void LoadDefaults()
            {
                Date = DateTimeOffset.Now.AddMonths(-6);
                Notes = $"Test Automation Incident {Date}";
                Reason = "ANAYF";
                State = "NJ";
            }

            [JsonProperty("incidentId")]
            public int? IncidentId { get; set; }

            [JsonProperty("date")]
            public DateTimeOffset Date { get; set; }

            [JsonProperty("reason")]
            public string Reason { get; set; }

            [JsonProperty("notes")]
            public string Notes { get; set; }

            [JsonProperty("state")]
            public string State { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("wasRecklessDriving")]
            public bool? WasRecklessDriving { get; set; }
        }
    }

}
