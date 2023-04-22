using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApolloTests.Data.EntityBuilder.Entities
{
    public class QuestionResponse 
    {
        [JsonProperty("id")]
        [NotMapped]
        public int? Id { 
            get { return QuestionId; } 
            set { QuestionId = value; } 
        }
        private bool? _requiresAnswer = false;
        [JsonProperty("requiresAnswer")]
        public bool? RequiresAnswer { 
            get { return this._requiresAnswer??false || (this?.Question?.RequiresAnswer ?? false); } 
            set { this._requiresAnswer = value; } 
        }
        [JsonProperty("questionId")]
        public int? QuestionId { get; set; }

        [JsonProperty("questionType")]
        public int? QuestionType { get; set; }

        [JsonProperty("alias")]
        public string? Alias
        {
            get { return QuestionAlias; }
            set { QuestionAlias = value; }
        }
        
        [JsonProperty("questionAlias")]
        public string? QuestionAlias { get; set; }

        [JsonProperty("sectionId")]
        public long? SectionId { get; set; }

        [JsonProperty("response")]
        public string? Response { get; set; }

        [JsonProperty("isHidden")]
        public bool? IsHidden { get; set; }

        [JsonProperty("isDisabled")]
        public bool? IsDisabled { get; set; }

        [JsonProperty("question")]
        public Question? Question { get; set; } = null;
    }

    public class Question
    {
        [JsonProperty("questionText")]
        public string? QuestionText { get; set; }

        [JsonProperty("markdown")]
        [NotMapped]
        public object? Markdown { get; set; }

        [JsonProperty("questionType")]
        public int? QuestionType { get; set; }

        [JsonProperty("condition")]
        public string? Condition { get; set; }

        [JsonProperty("alias")]
        public string? Alias { get; set; }

        [JsonProperty("requiresAnswer")]
        public bool? RequiresAnswer { get; set; }

        [JsonProperty("isDisabled")]
        public bool? IsDisabled { get; set; }

        [JsonProperty("isHidden")]
        public bool? IsHidden { get; set; }

        [JsonProperty("possibleAnswers")]
        [NotMapped]
        public List<object>? PossibleAnswers { get; set; }

        [JsonProperty("questionGroupId")]
        public long? QuestionGroupId { get; set; }

        [JsonProperty("questionGroupName")]
        public string? QuestionGroupName { get; set; }
    }
}
