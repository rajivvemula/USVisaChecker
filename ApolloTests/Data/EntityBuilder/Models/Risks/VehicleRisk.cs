using ApolloTests.Data.EntityBuilder.Entities;
using HitachiQA.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApolloTests.Data.EntityBuilder.Models.Risks
{
    public class VehicleRisk : Risk
    {
        public VehicleRisk() : base(RiskType.Vehicle)
        {

        }

        [JsonProperty("vehicle")]
        public Vehicle Vehicle => SectionEntity?.RiskType == RiskType.Vehicle ? (Vehicle)SectionEntity : throw new InvalidOperationException();

        [HydratorAttr("ClassCode")]
        public string? classCode { get; set; }

        public override IOutputMetadata outputMetadata { get; set; } = new OutputMetadataVehicle();


        //public bool ShouldSerializeVehicle() => SectionEntity?.RiskType == RiskType.Vehicle;
        //public bool ShouldSerializeclassCode() => SectionEntity?.RiskType == RiskType.Vehicle;

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
                return limit?.selectedDeductibles?[0] ?? 0;
            }
            set
            {
                string COVERAGE_NAME = "Collision";
                var limit = RiskLimits.Getter(COVERAGE_NAME);
                limit.NullGuard();
                limit.selectedDeductibles = new List<int> { value };
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
                return limit.selectedDeductibles[0];
            }
            set
            {
                string COVERAGE_NAME = "Comprehensive";
                var limit = RiskLimits.Getter(COVERAGE_NAME);
                limit.NullGuard();
                limit.selectedDeductibles = new List<int> { value };
            }
        }


        public class OutputMetadataVehicle : IOutputMetadata
        {
            public List<QuestionResponse> QuestionResponses { get; set; } = new List<QuestionResponse>();
            public VehicleLocation VehicleLocation { get; set; } = new VehicleLocation();

            [HydratorAttr("ClassCode")]
            public string? VehicleClassCode { get; set; }
        }

        public class VehicleLocation : IEntityBase
        {
            [HydratorAttr("PhysicalAddressId")]
            public string? locationId { get; set; }
        }
    }
}
