using ApolloTests.Data.EntityBuilder.Entities;
using ApolloTests.Data.EntityBuilder;
using ApolloTests.Data.Entities.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApolloTests.Data.Entities.Risk
{
    public class LocationRisk : RiskBase

    {
        public LocationRisk(CosmosContext context) : base(context) { }
        public LocationRisk() { }
        public LocationRisk(bool loadDefaults)
        {
            if(loadDefaults)
                LoadDefaults();
            
        }
        public void LoadDefaults()
        {
            RiskTypeId = (int)RiskTypeEnum.Location;
            OutputMetadata = new OutputMetadataLocation();
            Location = new Location()
            {
                Id = "00000000-0000-0000-0000-000000000000",
                RiskId = 0,
                RiskTypeId = 4,
                SequenceNumber = 0
            };

        }
        [JsonProperty("location")]
        public virtual new Location Location { get; set; }

        [JsonConverter(typeof(ConcreteTypeConverter<OutputMetadataLocation>))]
        public override IOutputMetadata OutputMetadata { get; set; }

    }

    public class OutputMetadataLocation : IOutputMetadata
    {
        [StateChange("LocationRisk.QuestionAnswers", "LocationRisk.Location")]
        public List<QuestionResponse> QuestionResponses { get; set; } = new List<QuestionResponse>();

    }
}
