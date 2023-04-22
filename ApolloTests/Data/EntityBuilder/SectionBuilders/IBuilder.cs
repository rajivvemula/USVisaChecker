using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace ApolloTests.Data.EntityBuilder.SectionBuilders
{
    public interface IBuilder
    {
        [JsonIgnore]
        public QuoteBuilder Builder { get; }

        [JsonIgnore]
        public HydratorUtil Hydrator { get; }

        [JsonIgnore]
        public Section Section { get; }
        
        public JToken RunSendStrategy(Data.Entities.Quote Quote);
       
    }

}
