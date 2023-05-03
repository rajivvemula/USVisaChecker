using ApolloTests.Data.EntityBuilder.Entities;
using ApolloTests.Data.Entities.Context;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApolloTests.Data.EntityBuilder;

namespace ApolloTests.Data.Entities.Risk
{
    public class BuildingRisk : RiskBase
    {
        public BuildingRisk(CosmosContext context) : base(context) { }

        public BuildingRisk(QuoteBuilder builder, bool loadDefaults = true) : base(builder)
        {
            if (loadDefaults)
                LoadDefaults();
        }
        public BuildingRisk() { }

        public void LoadDefaults()
        {
            RiskTypeId = (int)RiskTypeEnum.Building;
            OutputMetadata = new OutputMetadataBuilding();
            Building = new Building()
            {
                Id = "00000000-0000-0000-0000-000000000000",
                RiskId = 0,
                SequenceNumber = 0,
                LocationRiskId = -1,
                Description = "Automation API Building",
                UserBuildingGroupId = -1,
                UserBuildingOccupancyId = 5,
                UwClassCodeOverride = true,
                UwBuildingGroupIdOverride = true,
                UwBuildingOccupancyIdOverride = true
            };
        }

        [JsonProperty("building")]
        public override Building Building { get; set; }

        [JsonConverter(typeof(ConcreteTypeConverter<OutputMetadataBuilding>))]
        public override IOutputMetadata OutputMetadata { get; set; } = new OutputMetadataBuilding();


        [JsonProperty("userClassCode")]
        [NotMapped]
        public string? UserClassCode => Building.UserClassCodeValue;

        [JsonProperty("userBuildingOccupancyId")]
        [NotMapped]
        public int? UserBuildingOccupancyId => Building.UserBuildingOccupancyId;

        [JsonProperty("userBuildingGroupId")]
        [NotMapped]
        public int? UserBuildingGroupId => Building.UserBuildingGroupId;

        [JsonProperty("uwClassCodeOverride")]
        [NotMapped]
        public bool? UwClassCodeOverride => Building.UwClassCodeOverride;

        [JsonProperty("uwBuildingGroupIdOverride")]
        [NotMapped]
        public bool? UwBuildingGroupIdOverride => Building.UwBuildingGroupIdOverride;

        [JsonProperty("uwBuildingOccupancyIdOverride")]
        [NotMapped]
        public bool? UwBuildingOccupancyIdOverride => Building.UwBuildingOccupancyIdOverride;
    }
    public class OutputMetadataBuilding : IOutputMetadata
    {
        public List<QuestionResponse> QuestionResponses { get; set; } = new List<QuestionResponse>();

    }
}
