using ApolloTests.Data.EntityBuilder;
using ApolloTests.Data.Entities.Context;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApolloTests.Data.Entities.Risk
{
    public class Building : BaseEntityEF
    {
        public Building(CosmosContext ctx) : base(ctx) { }
        public Building() { }
        //
        // Common properties
        //
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("riskId")]
        public int RiskId { get; set; }

        [JsonProperty("sequenceNumber")]
        public int SequenceNumber { get; set; }

        //
        //
        // Cosmos only properties
        //
        //
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonIgnore]
        public int? BuildingGroupId { get; set; }

        [JsonIgnore]
        public int? BuildingLocationId { get; set; }

        [JsonIgnore]
        public int? BuildingOccupancyId { get; set; }

        [JsonIgnore]
        public string? ClassCode { get; set; }

        [JsonIgnore]
        public string? DefaultClassCode { get; set; }


        [JsonIgnore]
        public bool? IsClassCodeOverride { get; set; }

        [JsonIgnore]
        public int? RiskEntityId { get; set; }



        //
        //
        // RestAPI only properties
        //
        //
        [HydratorAttr("LocationRiskResponse[\"location\"][\"riskId\"]")]
        [JsonProperty("locationRiskId")]
        [NotMapped]
        public int? LocationRiskId { get; set; }

        [HydratorAttr("LocationRiskResponse")]
        [JsonProperty("locationRisk")]
        [NotMapped]
        public JObject? LocationRisk { get; set; }


        [HydratorAttr("BuildingGroupId")]
        [JsonProperty("userBuildingGroupId")]
        [NotMapped]
        public int? UserBuildingGroupId { get; set; }

        [JsonProperty("userBuildingOccupancyId")]
        [NotMapped]
        public int? UserBuildingOccupancyId { get; set; }

        [HydratorAttr("ClassCode")]
        [JsonProperty("userClassCodeValue")]
        [NotMapped]
        public string? UserClassCodeValue { get; set; }

        [JsonProperty("uwClassCodeOverride")]
        [NotMapped]
        public bool? UwClassCodeOverride { get; set; }

        [JsonProperty("uwBuildingGroupIdOverride")]
        [NotMapped]
        public bool? UwBuildingGroupIdOverride { get; set; }

        [JsonProperty("uwBuildingOccupancyIdOverride")]
        [NotMapped]
        public bool? UwBuildingOccupancyIdOverride { get; set; }
    }


}
