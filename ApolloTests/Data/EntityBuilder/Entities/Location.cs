using ApolloTests.Data.EntityBuilder.Models.Risks;
using Newtonsoft.Json;

namespace ApolloTests.Data.EntityBuilder.Entities
{
    public class Location : IRiskEntity, IEntityBase
    {

        Risk? IRiskEntity.Risk { get; set; }

        public Location(Risk risk)
        {
            ((IRiskEntity)this).SetRisk(risk);
        }
        public Location() { }
        [JsonIgnore]
        public RiskType RiskType => RiskType.Location;


        [JsonProperty("id")]
        public string Id { get; set; } = "00000000-0000-0000-0000-000000000000";

        [JsonProperty("riskId")]
        public int RiskId { get; set; } = 0;

        [JsonProperty("riskTypeId")]
        public int RiskTypeId { get; set; } = 4;

        [JsonProperty("sequenceNumber")]
        public int SequenceNumber { get; set; } = 0;

    }
}
