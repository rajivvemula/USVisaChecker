using ApolloTests.Data.EntityBuilder.Entities;
using ApolloTests.Data.EntityBuilder.QuestionAnswers;
using HitachiQA.Helpers;
using Newtonsoft.Json.Linq;

namespace ApolloTests.Data.EntityBuilder.SectionBuilders.CA
{
    public class OperationsBuilder : OperationsAnswers, IBuilder
    {
        public Section Section => Section.Operations;

        public QuoteBuilder Builder { get; }

        public HydratorUtil Hydrator => Builder.Hydrator;

        public OperationsBuilder(QuoteBuilder builder)
        {
            Builder = builder;
        }
        public JToken RunSendStrategy(Entity.Quote quote)
        {
            Hydrator.CurrentSection = Section;
            Hydrator.CurrentAnswers = this;
            Hydrator.CurrentEntity = null;
            var questionAnswers = new List<QuestionResponse>();
            Hydrator.Hydrate(questionAnswers);

            var response = Builder.RestAPI.POST($"quote/{quote.Id}/sections/{quote.Storyboard.GetSection("Operations").Id}/answers", questionAnswers.ToJArray());

            return (JObject?)response ?? throw new NullReferenceException();

        }
    }
}
