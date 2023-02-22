using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace ApolloTests.Data.TestData.Params
{
    public class AdditionalInterestsParam
    {
        public AdditionalInterestsParam()
        {
            Object = new AdditionalInterestsObject();
        }

        public AdditionalInterestsAnswerParam AdditionalInterestsAnswerParam { get; set; }=new AdditionalInterestsAnswerParam();
        public AdditionalInterestsObject Object { get; set; }

        public class AdditionalInterestsObject
        {

            [JsonProperty("id")]
            public int id { get; set; } = 0;

            [JsonProperty("partyTypeId")]
            public int partyTypeId { get; set; } = 1;

            [JsonProperty("partyId")]
            public int partyId { get; set; } = 0;

            [JsonProperty("questionResponses")]
            public List<QuestionResponse> questionResponses { get; set; } = new List<QuestionResponse>() {};

            public JObject ToJObject()
            {
                return JObject.FromObject(this);
            }

            public override string ToString()
            {
                return JObject.FromObject(this).ToString();
            }

            public class QuestionResponse
            {
                public int questionId { get; set; }

                public int questionType { get; set; }

                public string questionAlias { get; set; }

                public int sectionId { get; set; }

                public object response { get; set; }

                public bool isHidden { get; set; }

                public bool isDisabled { get; set; }
            }
        }
    }
}