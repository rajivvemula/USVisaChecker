using ApolloTests.Data.EntityBuilder.Entities;
using ApolloTests.Data.EntityBuilder.QuestionAnswers;
using HitachiQA.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace ApolloTests.Data.EntityBuilder.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Risk
    {
        public int? riskTypeId => (int?)SectionEntity?.RiskType;

        [HydratorAttr("ClassCode")]
        public string? classCode { get; set; } 

        public IOutputMetadata outputMetadata => SectionEntity?.OutputMetadata ?? throw new NullReferenceException();

        [JsonProperty("vehicle")]
        public Vehicle Vehicle => SectionEntity?.RiskType == RiskType.Vehicle ? (Vehicle)SectionEntity : throw new InvalidOperationException();

        [JsonProperty("driver")]
        public Driver Driver => SectionEntity?.RiskType == RiskType.Driver ? (Driver)SectionEntity : throw new InvalidOperationException();

        public bool ShouldSerializeDriver()=>SectionEntity?.RiskType==RiskType.Driver;
        public bool ShouldSerializeVehicle() => SectionEntity?.RiskType == RiskType.Vehicle;
        public bool ShouldSerializeclassCode() => SectionEntity?.RiskType == RiskType.Vehicle;


        [JsonIgnore]
        public RiskAnswers QuestionAnswers = new();

        [JsonIgnore]
        public IRiskEntity? SectionEntity { get; set; }

        [JsonIgnore]
        public List<Limit> RiskLimits { get; set; } = new List<Limit>();

        public Risk(RiskType riskType)
        {
            switch (riskType)
            {
                case RiskType.Vehicle:
                    SectionEntity = new Vehicle(this);
                    break;
                case RiskType.Driver:
                    SectionEntity = new Driver(this);
                    break;
            }

        }
        public void LoadEntityObject(JObject riskEntityObject)
        {
            SectionEntity.NullGuard();
            SectionEntity = (IRiskEntity?)riskEntityObject.ToObject(SectionEntity.GetType()) ?? throw new NullReferenceException();
        }

        public override string ToString()
        {
            return JObject.FromObject(this).ToString();
        }

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
                return limit?.selectedDeductibles?[0]??0;
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




    }
    public enum RiskType
    {
        Vehicle = 1,
        Driver = 2,
        Building = 3,
        Location = 4
    }
}
