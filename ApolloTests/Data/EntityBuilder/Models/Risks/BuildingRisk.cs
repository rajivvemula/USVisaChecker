using ApolloTests.Data.EntityBuilder.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApolloTests.Data.EntityBuilder.Models.Risks
{
    public class BuildingRisk : Risk
    {
        public BuildingRisk() : base(RiskType.Building)
        {

        }
        [JsonProperty("id")]
        public int Id { get; set; } = 0;

        [JsonProperty("tetherId")]
        public int TetherId { get; set; } = 0;

        [JsonProperty("building")]
        public Building Building => SectionEntity?.RiskType == RiskType.Building ? (Building)SectionEntity : throw new InvalidOperationException();

        public override IOutputMetadata outputMetadata { get; set; } = new OutputMetadataBuilding();

        [JsonProperty("riskTypeId")]
        public int RiskTypeId { get; set; } = 3;

        //[JsonProperty("decidedBuildingGroupId")]
        //public int DecidedBuildingGroupId => Building.UserBuildingGroupId;

        //[JsonProperty("decidedBuildingOccupancyId")]
        //public int DecidedBuildingOccupancyId => Building.UserBuildingOccupancyId;

        //[JsonProperty("decidedClassCode")]
        //public string? DecidedClassCode => Building.UserClassCodeValue;


        [JsonProperty("userClassCode")]
        public string? UserClassCode => Building.UserClassCodeValue;

        [JsonProperty("userBuildingOccupancyId")]
        public int UserBuildingOccupancyId => Building.UserBuildingOccupancyId;

        [JsonProperty("userBuildingGroupId")]
        public int UserBuildingGroupId => Building.UserBuildingGroupId;

        [JsonProperty("uwClassCodeOverride")]
        public bool UwClassCodeOverride => Building.UwClassCodeOverride;

        [JsonProperty("uwBuildingGroupIdOverride")]
        public bool UwBuildingGroupIdOverride => Building.UwBuildingGroupIdOverride;

        [JsonProperty("uwBuildingOccupancyIdOverride")]
        public bool UwBuildingOccupancyIdOverride => Building.UwBuildingOccupancyIdOverride;
    }

    public class OutputMetadataBuilding : IOutputMetadata
    {
        public List<QuestionResponse> QuestionResponses { get; set; } = new List<QuestionResponse>();

    }
}
