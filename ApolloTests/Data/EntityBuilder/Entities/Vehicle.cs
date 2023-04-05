using ApolloTests.Data.EntityBuilder.Models.Risks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace ApolloTests.Data.EntityBuilder.Entities
{
    public class Vehicle : IRiskEntity, IEntityBase
    {
        [JsonIgnore]
        public RiskType RiskType => RiskType.Vehicle;
        [JsonIgnore]
        Risk? IRiskEntity.Risk { get; set; }

        public Vehicle(Risk risk)
        {
            ((IRiskEntity)this).SetRisk(risk);
        }
        public Vehicle() { }
        public string id { get; set; } = "00000000-0000-0000-0000-000000000000";

        public int riskId { get; set; } = 0;

        public int? typeId { get; set; } = null;

        public bool isVinTelligence { get; set; } = true;

        public int yearOfManufacture { get; set; } = 2020;

        public string make { get; set; } = "Honda";

        public string model { get; set; } = "Accord";

        [HydratorAttr("VinNumber")]
        public string? vinNumber { get; set; }

        public string trim { get; set; } = "Sedan 4D LE";

        public int bodyCategoryTypeId { get; set; } = 1;

        public int bodySubCategoryTypeId { get; set; } = 1;

        public string grossVehicleWeight { get; set; } = "5000";

        public string costNew { get; set; } = "19545";

        public string? statedAmount { get; set; } = null;

        public bool useStatedAmount { get; set; } = false;

        public int? estimatedCurrentValue { get; set; } = null;

        public string calculatedValue { get; set; } = "7000";

        public string underwriterValue { get; set; } = "";

        public bool? antitheft { get; set; } = null;

        public bool? safetyFeatures { get; set; } = null;

        public int? inspectionCount { get; set; } = null;

        public int? totalBASICViolationWeight { get; set; } = null;

        public decimal? outOfServiceViolationRatio { get; set; } = null;

        public object? isVinDataVariance { get; set; } = null;

        public object? preVinRateRank { get; set; } = null;

        public int vinRateRank { get; set; } = 1;
       
    }


}
