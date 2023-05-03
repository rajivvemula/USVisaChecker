using ApolloTests.Data.EntityBuilder.Models.Modifiers;
using DocumentFormat.OpenXml.Wordprocessing;
using HitachiQA.Helpers;
using Newtonsoft.Json.Linq;

namespace ApolloTests.Data.EntityBuilder.SectionBuilders.CA
{
    public class ModifiersBuilder_CA : Modifiers_CA, IBuilder
    {
        public Section Section => Section.Modifiers;

        public QuoteBuilder Builder { get; }

        public HydratorUtil Hydrator => Builder.Hydrator;

        public ModifiersBuilder_CA(QuoteBuilder builder)
        {
            Builder = builder;
        }

        public JToken RunSendStrategy(Data.Entities.Quote quote)
        {
            Hydrator.CurrentSection = Section;
            Hydrator.CurrentEntity = null;
            Hydrator.CurrentAnswers = null;
            Hydrator.Hydrate(this);
            var body = this.ToJObject();
            var response = Builder.RestAPI.PATCH($"/quote/{quote.Id}", body);

            return response;

        }
    }
}
