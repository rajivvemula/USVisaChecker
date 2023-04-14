using ApolloTests.Data.EntityBuilder.Models.Modifiers;
using DocumentFormat.OpenXml.Wordprocessing;
using HitachiQA.Helpers;
using Newtonsoft.Json.Linq;

namespace ApolloTests.Data.EntityBuilder.SectionBuilders.BOP
{
    public class ModifiersBuilder_BOP : Modifiers_BOP, IBuilder
    {
        public Section Section => Section.Modifiers;

        public QuoteBuilder Builder { get; }

        public HydratorUtil Hydrator => Builder.Hydrator;

        public ModifiersBuilder_BOP(QuoteBuilder builder)
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
            //Log.Debug(body);
            var response = (JObject?)Builder.RestAPI.PATCH($"/quote/{quote.Id}", body);
            response.NullGuard();

            return response;

        }
    }
}
