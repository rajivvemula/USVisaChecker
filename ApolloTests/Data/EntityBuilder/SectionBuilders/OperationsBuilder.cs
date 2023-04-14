using ApolloTests.Data.EntityBuilder.Entities;
using ApolloTests.Data.EntityBuilder.QuestionAnswers;
using HitachiQA.Helpers;
using Newtonsoft.Json.Linq;

namespace ApolloTests.Data.EntityBuilder.SectionBuilders
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
            var sectionId = quote.Storyboard.GetSection("Operations").Id;

            var response = Builder.RestAPI.POST($"quote/{quote.Id}/sections/{sectionId}/answers", questionAnswers.ToJArray());

            return (JObject?)response ?? throw new NullReferenceException();

        }
    }
}
