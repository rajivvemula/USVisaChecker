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
        private bool _requiresAnswer = false;
        [JsonProperty("requiresAnswer")]
        public bool RequiresAnswer { 
            get { return this._requiresAnswer || (this?.Question?.RequiresAnswer ?? false); } 
            set { this._requiresAnswer = value; } 
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

        public long sectionId { get; set; }

        public object? response { get; set; }

        public bool isHidden { get; set; }

        [JsonProperty("question")]
        public Question? Question { get; set; } = null;
    }

    public class Question
    {
        [JsonProperty("questionText")]
        public string? QuestionText { get; set; }

        [JsonProperty("markdown")]
        public object? Markdown { get; set; }

        [JsonProperty("questionType")]
        public int? QuestionType { get; set; }

        [JsonProperty("condition")]
        public string? Condition { get; set; }

        [JsonProperty("alias")]
        public string? Alias { get; set; }

        [JsonProperty("requiresAnswer")]
        public bool RequiresAnswer { get; set; }

        [JsonProperty("isDisabled")]
        public bool? IsDisabled { get; set; }

        [JsonProperty("isHidden")]
        public bool? IsHidden { get; set; }

        [JsonProperty("possibleAnswers")]
        public List<object>? PossibleAnswers { get; set; }

        [JsonProperty("questionGroupId")]
        public object? QuestionGroupId { get; set; }

        [JsonProperty("questionGroupName")]
        public object? QuestionGroupName { get; set; }
    }
}
