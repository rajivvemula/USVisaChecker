using ApolloTests.Data.Entities.Context;
using ApolloTests.Data.EntityBuilder.Entities;
using ApolloTests.Data.EntityBuilder.QuestionAnswers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApolloTests.Data.Entities.Coverage
{
    public class Limit 
    {

        [JsonProperty("selectedDeductibleName")]
        public string? SelectedDeductibleName { get; set; }

        [JsonProperty("selectedDeductibles")]
        public List<int>? SelectedDeductibles { get; set; }

        [JsonProperty("selectedLimitName")]
        public string? SelectedLimitName { get; set; }

        [JsonProperty("selectedLimits")]
        public List<int>? SelectedLimits { get; set; }

        [JsonIgnore]
        [NotMapped]
        public CoverageType CoverageType { get; set; }

        [JsonProperty("coverageTypeId")]
        public long? CoverageTypeId { get; set; }

        [JsonProperty("questionResponses")]
        public List<QuestionResponse> QuestionResponses { get; set; }

        [JsonProperty("riskId")]
        public long? RiskId { get; set; }

        [JsonProperty("riskCoverages")]
        public virtual List<Limit> RiskCoverages { get; set; }

        [JsonIgnore]
        [NotMapped]
        public LimitAnswers? QuestionAnswers { get; set; }

        public Limit(CoverageType coverageType)
        {
            CoverageType= coverageType;
            CoverageTypeId = coverageType.Id;
            RiskId = 0;
        }

        public Limit(long coverageTypeId)
        {
            CoverageTypeId = coverageTypeId;
            RiskId = 0;
        }
        public Limit() { 
            RiskId= 0;
        }

        public CoverageType GetCoverageType()
        {
            return CoverageType;
        }

        public object GetQuestionResponse(string questionAlias)
        {

            var questionResponse = QuestionResponses?.FirstOrDefault(it => it.QuestionAlias == questionAlias);

            if (questionResponse == null)
            {
                Log.Debug($"{questionAlias}returned null");
                return null;
            }
            else
            {
                Log.Debug($"{questionAlias} returned {questionResponse.Response ?? "response is null"}");
                return questionResponse.Response;
            }
        }
    }
}
