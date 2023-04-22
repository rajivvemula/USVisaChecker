using ApolloTests.Data.Entities.Context;
using Newtonsoft.Json;


namespace ApolloTests.Data.Entities.Risk
{
    public class Location: BaseEntityEF
    {
        public Location(CosmosContext ctx) : base(ctx)
        {

        }
        public Location()
        {

        }
        [JsonProperty("id")]
        public new string Id { get; set; }

        [JsonIgnore]
        public int? AddressId { get; set; }

        [JsonIgnore]
        public bool? IsRatableType { get; set; }

        [JsonIgnore]
        public string? LogicId { get; set; }

        [JsonProperty("riskId")]
        public int RiskId { get; set; }

        [JsonProperty("riskTypeId")]
        public int RiskTypeId { get; set; }

        [JsonProperty("sequenceNumber")]
        public int SequenceNumber { get; set; }

        [JsonIgnore]
        public string? Version { get; set; }
    }

}
