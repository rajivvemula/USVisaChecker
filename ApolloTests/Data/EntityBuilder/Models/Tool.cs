using ApolloTests.Data.EntityBuilder.Entities;
using ApolloTests.Data.EntityBuilder.QuestionAnswers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApolloTests.Data.EntityBuilder.Models
{
    public class Tool
    {
        [JsonProperty("id")]
        public int Id { get; set; } = 0;

        [HydratorAttr("ApplicationId")]
        [JsonProperty("applicationId")]
        public int ApplicationId { get; set; }

        public List<QuestionResponse> QuestionResponses { get; set; } = new List<QuestionResponse>();

        [JsonIgnore]
        public ToolAnswers QuestionAnswers = new();
    }
}
