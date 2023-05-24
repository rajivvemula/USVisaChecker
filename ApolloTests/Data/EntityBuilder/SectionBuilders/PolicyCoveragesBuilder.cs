using ApolloTests.Data.Entities.Coverage;
using ApolloTests.Data.Entities.Enums;
using HitachiQA.Helpers;
using Newtonsoft.Json.Linq;

namespace ApolloTests.Data.EntityBuilder.SectionBuilders
{
    public class PolicyCoveragesBuilder : List<Limit>, IBuilder
    {
        public Section Section => Section.PolicyCoverages;
        public QuoteBuilder Builder { get; }

        public HydratorUtil Hydrator => Builder.Hydrator;

        public PolicyCoveragesBuilder(QuoteBuilder builder)
        {
            Builder = builder;

            //default coverages in each LOB is different but the send strategy is the same
            switch(builder.Line.LineEnum)
            {
                case LineEnum.CommercialAuto:
                    this.AddBIPD();
                    if(builder.State=="MI")
                    {
                        this.Find(it => it.CoverageType.TypeName == CoverageType.BIPD).SelectedLimits[0] = 510000;
                    }

                    break;
                case LineEnum.BusinessOwner:
                    this.AddEmployeeDishonesty();
                    this.AddDamageToPremisesRentedToYou();
                    this.AddGeneralLiability();
                    break;
            }

        }

        public void Add(CoverageType coverageType)
        {
            this.Setter(coverageType);
        }
        public void Add(string coverageType)
        {
            this.Setter(coverageType);
        }

        public JToken RunSendStrategy(Data.Entities.Quote Quote)
        {
            Builder.Hydrator.CurrentSection = Section;
            Builder.Hydrator.CurrentEntity = null;

            var body = new JArray();
            foreach (var limit in this)
            {

                if (!limit.CoverageType.isVehicleLevel)
                {
                    Builder.Hydrator.CurrentEntity = limit;
                    Builder.Hydrator.CurrentAnswers = limit.QuestionAnswers;
                    Hydrator.Hydrate(limit);
                    body.Add(JObject.FromObject(limit.ToJObject()));
                }
            }

            var response = (JObject?)Builder.RestAPI.POST($"quote/{Quote.Id}/limits", body);
            response.NullGuard();
            return response;
        }

        public void BIPD_SplitLimit(int BI_PerPerson = 100000, int BI_perOccurrence = 300000, int PD_perOccurrence = 500000)
        {
            var limit = Find(it => it.CoverageType.TypeName == CoverageType.BIPD);

            if (limit == null)
            {
                this.AddBIPD();
            }

            this[0].SelectedLimitName = "Split Limit";
            this[0].SelectedLimits = new List<int> { BI_PerPerson, BI_perOccurrence, PD_perOccurrence };
        }
    }
}
