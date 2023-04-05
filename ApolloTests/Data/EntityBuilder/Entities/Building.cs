using ApolloTests.Data.EntityBuilder.Models.Risks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ApolloTests.Data.EntityBuilder.Entities
{
    public class Building : IRiskEntity, IEntityBase
    {
        [JsonIgnore]
        Risk? IRiskEntity.Risk { get; set; }

        public Building(Risk risk)
        {
            ((IRiskEntity)this).SetRisk(risk);
        }
        public Building()
        {
        }
        [JsonIgnore]
        public RiskType RiskType => RiskType.Building;


        [JsonProperty("id")]
        public string Id { get; set; } = "00000000-0000-0000-0000-000000000000";

        [JsonProperty("riskId")]
        public int RiskId { get; set; } = 0;

        [JsonProperty("sequenceNumber")]
        public int SequenceNumber { get; set; } = 0;

        [HydratorAttr("LocationRiskResponse[\"location\"][\"riskId\"]")]
        [JsonProperty("locationRiskId")]
        public int LocationRiskId { get; set; } = -1;

        [HydratorAttr("LocationRiskResponse")]
        [JsonProperty("locationRisk")]
        public JObject? LocationRisk { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; } = "Automation API Building";

        [HydratorAttr("BuildingGroupId")]
        [JsonProperty("userBuildingGroupId")]
        public int UserBuildingGroupId { get; set; } = -1;

        [JsonProperty("userBuildingOccupancyId")]
        public int UserBuildingOccupancyId { get; set; } = 5;

        [HydratorAttr("ClassCode")]
        [JsonProperty("userClassCodeValue")]
        public string? UserClassCodeValue { get; set; }

        [JsonProperty("uwClassCodeOverride")]
        public bool UwClassCodeOverride { get; set; } = true;

        [JsonProperty("uwBuildingGroupIdOverride")]
        public bool UwBuildingGroupIdOverride { get; set; } = true;

        [JsonProperty("uwBuildingOccupancyIdOverride")]
        public bool UwBuildingOccupancyIdOverride { get; set; } = true;

    }
}
