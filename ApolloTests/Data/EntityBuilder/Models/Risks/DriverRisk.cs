using ApolloTests.Data.EntityBuilder.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApolloTests.Data.EntityBuilder.Models.Risks
{
    public class DriverRisk : Risk
    {
        public DriverRisk() : base(RiskType.Driver)
        {

        }

        [JsonProperty("driver")]
        public Driver Driver => SectionEntity?.RiskType == RiskType.Driver ? (Driver)SectionEntity : throw new InvalidOperationException();

        public override IOutputMetadata outputMetadata { get; set; } = new OutputMetadataDriver();

        //public bool ShouldSerializeDriver() => SectionEntity?.RiskType == RiskType.Driver;
       
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
