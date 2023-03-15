using ApolloTests.Data.EntityBuilder.Entities;
using ApolloTests.Data.EntityBuilder.QuestionAnswers;
using HitachiQA.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace ApolloTests.Data.EntityBuilder.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Party
    {
        [JsonProperty("id")]
        public int Id { get; set; } = 0;

        [JsonProperty("partyTypeId")]
        public int PartyTypeId { get; set; } = (int)PartyType.ORGANIZATION;

        [JsonProperty("partyId")]
        public int PartyId { get; set; } = 0;

        [JsonProperty("questionResponses")]
        public List<QuestionResponse> QuestionResponses { get; set; } = new List<QuestionResponse>() { };

        public int? additionalInterestTypeId { get; set; }

        public override string ToString()
        {
            return JObject.FromObject(this).ToString();
        }

        [JsonIgnore]
        public PartyAnswers QuestionAnswers = new();
    }

    public enum PartyType
    {
        PERSON = 0,
        ORGANIZATION = 1,
        ADDITIONALINTEREST = 1,
        GROUP = 2,
        DIGITAL = 3,
        INSURED = 4,
        CARRIER = 5,
        AGENCY = 6
    }
}
