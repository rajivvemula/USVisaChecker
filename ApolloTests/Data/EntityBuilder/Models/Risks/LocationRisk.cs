using ApolloTests.Data.EntityBuilder.Entities;
using ApolloTests.Data.EntityBuilder.QuestionAnswers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApolloTests.Data.EntityBuilder.Models.Risks
{
    public class LocationRisk : Risk
    {
        public LocationRisk() : base(RiskType.Location)
        {

        }

        [JsonProperty("location")]
        public Location Location => SectionEntity?.RiskType == RiskType.Location ? (Location)SectionEntity : throw new InvalidOperationException(SectionEntity?.RiskType.ToString());

        public override IOutputMetadata outputMetadata { get; set; } = new OutputMetadataLocation();       

    }

    public class OutputMetadataLocation : IOutputMetadata
    {
        [StateChange("LocationRisk.QuestionAnswers", "LocationRisk.Location")]
        public List<QuestionResponse> QuestionResponses { get; set; } = new List<QuestionResponse>();

    }
}
