using ApolloTests.Data.EntityBuilder.Models;
using HitachiQA.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace ApolloTests.Data.EntityBuilder.SectionBuilders.CA
{
    public class PolicyAddnlIntrestBuilder : List<Party>, IBuilder
    {
        public Section Section => Section.PolicyAddlInterest;
        public QuoteBuilder Builder { get; }

        public HydratorUtil Hydrator => Builder.Hydrator;

        public PolicyAddnlIntrestBuilder(QuoteBuilder Builder)
        {
            this.Builder = Builder;
            var party = new Party();
            party.additionalInterestTypeId = 3;
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
                        Add(new Party() { additionalInterestTypeId = 3 });
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
                Builder.Hydrator.CurrentAnswers = party.QuestionAnswers;

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
