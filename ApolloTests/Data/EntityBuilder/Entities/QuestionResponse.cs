using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApolloTests.Data.EntityBuilder.Entities
{
    public class QuestionResponse : IEntityBase
    {
        [JsonProperty("id")]
        public int Id { 
            get { return questionId; } 
            set { questionId = value; } 
        }

        public int questionId { get; set; }

        public int questionType { get; set; }

        [JsonProperty("alias")]
        public string? alias
        {
            get { return questionAlias; }
            set { questionAlias = value; }
        }

        public string? questionAlias { get; set; }

        public int sectionId { get; set; }

        public object? response { get; set; }

        public bool isHidden { get; set; }

    }
}
