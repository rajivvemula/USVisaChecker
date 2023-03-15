using ApolloTests.Data.EntityBuilder.Models;
using DocumentFormat.OpenXml.Wordprocessing;
using HitachiQA.Helpers;
using Newtonsoft.Json.Linq;

namespace ApolloTests.Data.EntityBuilder.SectionBuilders.CA
{
    public class ModifiersBuilder : Modifiers, IBuilder
    {
        public Section Section => Section.Modifiers;

        public QuoteBuilder Builder { get; }

        public HydratorUtil Hydrator => Builder.Hydrator;

        public ModifiersBuilder(QuoteBuilder builder)
        {
            Builder = builder;
        }

        public JToken RunSendStrategy(Entity.Quote quote)
        {
            Hydrator.CurrentSection = Section;
            Hydrator.CurrentEntity = null;
            Hydrator.CurrentAnswers = null;
            Hydrator.Hydrate(this);
            var body = this.ToJObject();
            var response = (JObject?)Builder.RestAPI.PATCH($"/quote/{quote.Id}", body);
            response.NullGuard();

            return response;

        }
    }
}
