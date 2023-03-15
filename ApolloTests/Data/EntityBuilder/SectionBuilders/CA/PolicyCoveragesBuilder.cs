using ApolloTests.Data.Entity;
using ApolloTests.Data.EntityBuilder.Entities;

using HitachiQA.Helpers;
using Newtonsoft.Json.Linq;

namespace ApolloTests.Data.EntityBuilder.SectionBuilders.CA
{
    public class PolicyCoveragesBuilder : List<Limit>, IBuilder
    {
        public Section Section => Section.PolicyCoverages;
        public QuoteBuilder Builder { get; }

        public HydratorUtil Hydrator => Builder.Hydrator;

        public PolicyCoveragesBuilder(QuoteBuilder builder)
        {
            this.Builder = builder;
            this.AddBIPD();

        }

     
        public void Add(CoverageType coverageType)
        {
            this.Setter(coverageType);
        }
        public void BIPD_SplitLimit(int BI_PerPerson = 100000, int BI_perOccurrence = 300000, int PD_perOccurrence = 500000)
        {
            var limit = this.Find(it => it.coverageType.Name == CoverageType.BIPD);

            if (limit == null)
            {
                this.AddBIPD();
            }
            
            this[0].selectedLimitName = "Split Limit";
            this[0].selectedLimits = new List<int> { BI_PerPerson, BI_perOccurrence, PD_perOccurrence };
        }

        public JToken RunSendStrategy(Entity.Quote Quote)
        {
            Builder.Hydrator.CurrentSection = Section;
            Builder.Hydrator.CurrentEntity = null;

            var body = new JArray();
            foreach (var limit in this)
            {
                if (!limit.coverageType.isVehicleLevel)
                {
                    Builder.Hydrator.CurrentAnswers = limit.QuestionAnswers;
                    Hydrator.Hydrate(limit);
                    body.Add(JObject.FromObject(limit.ToJObject()));
                }
            }

            var response = (JObject?)this.Builder.RestAPI.POST($"quote/{Quote.Id}/limits", body);
            response.NullGuard();
            return response;
        }
    }
}
