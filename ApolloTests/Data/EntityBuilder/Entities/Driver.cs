using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApolloTests.Data.EntityBuilder.Models;
using Newtonsoft.Json;

namespace ApolloTests.Data.EntityBuilder.Entities
{
    public class Driver : IRiskEntity, IEntityBase
    {
        [JsonIgnore]
        public IOutputMetadata OutputMetadata { get; set; } = new OutputMetadataDriver();

        [JsonIgnore]
        public RiskType RiskType => RiskType.Driver;

        [JsonIgnore]
        private Risk Risk { get; }

        public Risk GetRisk() => Risk;

        public Driver(Risk risk)
        {
            this.Risk= risk;
        }

        public Person person { get; set; } = new Person();

        public DateTime dateOfBirth { get; set; } = new DateTime(1965, 10, 26, 04, 00, 00);

        [HydratorAttr("GoverningStateId")]
        public long? stateProvinceId { get; set; }

        public StateProvince stateProvince { get; set; } = new StateProvince();

        [HydratorAttr("LicenseNumber")]
        public string licenseNo { get; set; } = string.Empty;

        public int statusId { get; set; } = 0;


        public class PrimaryName
        {
            public string given { get; set; } = "Miguel";

            public string middle { get; set; } = string.Empty;

            public string surName { get; set; } = "Acosta";

            public string suffix { get; set; } = string.Empty;
        }

        public class Person
        {
            public PrimaryName primaryName { get; set; } = new PrimaryName();
        }

        public class StateProvince
        {
            [HydratorAttr("StateCode")]
            public string? code { get; set; } 
        }

        public class OutputMetadataDriver : IOutputMetadata
        {
            public List<QuestionResponse> QuestionResponses { get; set; } = new List<QuestionResponse>();
            public DriverHistory DriverHistory { get; set; } = new DriverHistory();

        }

        public class DriverHistory
        {
            public int id { get; set; }

            public List<Incident> accidents { get; set; } = new List<Incident>();

            public List<Incident> violations { get; set; } = new List<Incident>();

            public List<Incident> convictions { get; set; } = new List<Incident>();

            public class Incident
            {
                public DateTime date { get; set; }

                public string? reason { get; set; }

                public string? state { get; set; }

                public string? notes { get; set; }

                public string? description { get; set; }

                public string? wasRecklessDriving { get; set; }
            }
        }

    }


}
