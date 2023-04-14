using ApolloTests.Data.EntityBuilder.Models;
using HitachiQA.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace ApolloTests.Data.EntityBuilder.SectionBuilders
{
    public class PolicyAddnlIntrestBuilder : List<Party>, IBuilder
    {
        public Section Section => Builder.Line.Id == 7 ? Section.PolicyAddlInterest : Section.AdditionalInterests;
        public QuoteBuilder Builder { get; }

        public HydratorUtil Hydrator => Builder.Hydrator;

        public PolicyAddnlIntrestBuilder(QuoteBuilder Builder)
        {
            this.Builder = Builder;
            var party = new Party();
            party.additionalInterestTypeId = Builder.Line.Id == 7 ? 3 : null;
            Add(party);
        }

        [JsonIgnore]
        public uint NumberOfParties
        {
            get
            {
                return (uint)Count;
            }
            set
            {
                if (NumberOfParties > value)
                {
                    while (Count != value)
                    {
                        RemoveAt(Count - 1);
                    }
                }
                else
                {

                    while (NumberOfParties != value)
                    {
                        Add(new Party() { additionalInterestTypeId = Builder.Line.Id == 7 ? 3 : null });
                    }
                }
            }
        }

        public JToken RunSendStrategy(Entity.Quote quote)
        {
            Builder.Hydrator.CurrentSection = Section;

            var finalBody = new JArray();
            foreach (var party in this)
            {
                Builder.Hydrator.CurrentEntity = party;
                //
                // Broke this out because each LOB require different defaults for the same questions
                //
                switch (Builder.Line.LineEnum)
                {
                    case Data.Entities.Lines.BusinessOwner:
                        Builder.Hydrator.CurrentAnswers = party.QuestionAnswers_BOP;
                        break;
                    case Data.Entities.Lines.CommercialAuto:
                        Builder.Hydrator.CurrentAnswers = party.QuestionAnswers_CA;
                        break;
                    default:
                        throw new Exception($"party.questionAnswers needs to be implemented/mapped for {Builder.Line.LineEnum}");
                }

                Hydrator.Hydrate(party);
                finalBody.Add(party.ToJObject());

            }
            var response = Builder.RestAPI.POST($"/quote/{quote.Id}/additionalinterest", finalBody);
            if (response == null)
            {
                throw new NullReferenceException();
            }
            return response;
        }
    }
}
