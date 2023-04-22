using ApolloTests.Data.EntityBuilder;
using ApolloTests.Data.EntityBuilder.Entities;
using ApolloTests.Data.Entities.Context;
using HitachiQA.Helpers;
using Microsoft.Azure.Cosmos.Core.Collections;
using Newtonsoft.Json;

namespace ApolloTests.Data.Entities.Risk
{
    public class VehicleRisk: RiskBase
    {
        public VehicleRisk(CosmosContext context) : base(context) { }
        public VehicleRisk() { }
        public VehicleRisk(bool loadDefaults)
        {
            if (loadDefaults)
                LoadDefaults();

        }
        public void LoadDefaults()
        {
            RiskTypeId = (int)RiskTypeEnum.Vehicle;
            OutputMetadata = new OutputMetadataVehicle();
            Vehicle = new Vehicle()
            {
                Id = "00000000-0000-0000-0000-000000000000",
                RiskId = 0,
                TypeId = null,
                IsVinTelligence = true,
                YearOfManufacture = 2020,
                Make = "Honda",
                Model = "Accord",
                VinNumber = null,
                Trim = "Sedan 4D LE",
                BodyCategoryTypeId = 1,
                BodySubCategoryTypeId = 1,
                GrossVehicleWeight = "5000",
                CostNewStr = "19545",
                StatedAmount = null,
                UseStatedAmount = false,
                EstimatedCurrentValue = null,
                CalculatedValueStr = "7000",
                UnderwriterValue = "",
                Antitheft = null,
                SafetyFeatures = null,
                InspectionCount = null,
                TotalBASICViolationWeight = null,
                OutOfServiceViolationRatio = null,
                IsVinDataVariance = null,
                VinRateRank = 1
            };
        }

        [JsonProperty("vehicle")]
        public new Vehicle Vehicle { get; set; }

        [JsonConverter(typeof(ConcreteTypeConverter<OutputMetadataVehicle>))]
        public override IOutputMetadata OutputMetadata { get; set; }

        [JsonIgnore]
        public bool AddCollision
        {
            get
            {
                string COVERAGE_NAME = "Collision";
                return RiskLimits.Getter(COVERAGE_NAME) != null;
            }
            set
            {
                string COVERAGE_NAME = "Collision";
                RiskLimits.Setter(COVERAGE_NAME, value);
            }
        }

        [JsonIgnore]
        public int CollisionDeductible
        {
            get
            {
                string COVERAGE_NAME = "Collision";
                var limit = RiskLimits.Getter(COVERAGE_NAME);
                return limit?.SelectedDeductibles?[0] ?? 0;
            }
            set
            {
                string COVERAGE_NAME = "Collision";
                var limit = RiskLimits.Getter(COVERAGE_NAME);
                limit.NullGuard();
                limit.SelectedDeductibles = new List<int> { value };
            }
        }
        [JsonIgnore]
        public bool AddComprehensive
        {
            get
            {
                string COVERAGE_NAME = "Comprehensive";
                return RiskLimits.Getter(COVERAGE_NAME) != null;
            }
            set
            {
                string COVERAGE_NAME = "Comprehensive";
                RiskLimits.Setter(COVERAGE_NAME, value);
            }
        }
        [JsonIgnore]
        public int ComprehensiveDeductible
        {
            get
            {
                string COVERAGE_NAME = "Comprehensive";
                var limit = RiskLimits.Getter(COVERAGE_NAME);
                limit.NullGuard();
                return limit.SelectedDeductibles[0];
            }
            set
            {
                string COVERAGE_NAME = "Comprehensive";
                var limit = RiskLimits.Getter(COVERAGE_NAME);
                limit.NullGuard();
                limit.SelectedDeductibles = new List<int> { value };
            }
        }
    }

    public class OutputMetadataVehicle : IOutputMetadata
    {
        public List<QuestionResponse> QuestionResponses { get; set; } = new List<QuestionResponse>();
        public VehicleLocation VehicleLocation { get; set; } = new VehicleLocation();

        [HydratorAttr("ClassCode")]
        public string? VehicleClassCode { get; set; }
    }

    public class VehicleLocation 
    {
        [HydratorAttr("PhysicalAddressId")]
        [JsonProperty("locationId")]
        public string? LocationId { get; set; }
    }
}
