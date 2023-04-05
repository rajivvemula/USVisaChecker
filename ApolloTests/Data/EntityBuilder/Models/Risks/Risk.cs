using ApolloTests.Data.EntityBuilder.Entities;
using ApolloTests.Data.EntityBuilder.QuestionAnswers;
using HitachiQA.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace ApolloTests.Data.EntityBuilder.Models.Risks
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public abstract class Risk
    {
        public int? riskTypeId => (int?)SectionEntity?.RiskType;

        public abstract IOutputMetadata outputMetadata { get; set; }

        [JsonIgnore]
        public RiskAnswers QuestionAnswers { get; set; } = new();

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
                case RiskType.Location:
                    SectionEntity = new Location(this);
                    break;
                case RiskType.Building:
                    SectionEntity = new Building(this);
                    break;
                default: throw new NotImplementedException();
            }

        }
        public void LoadEntityObject(JObject riskEntityObject)
        {
            SectionEntity.NullGuard();
            SectionEntity = (IRiskEntity?)riskEntityObject.ToObject(SectionEntity.GetType()) ?? throw new NullReferenceException();
            SectionEntity.SetRisk(this);
        }

        public override string ToString()
        {
            return JObject.FromObject(this).ToString();
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
