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
        public string SelectedDeductibleName { get; set; }

        [JsonProperty("selectedDeductibles")]
        public List<int> SelectedDeductibles { get; set; }

        [JsonProperty("selectedLimitName")]
        public string SelectedLimitName { get; set; }

        [JsonProperty("selectedLimits")]
        public List<int> SelectedLimits { get; set; }

        [JsonIgnore]
        [NotMapped]
        public CoverageType CoverageType { get; set; }

        [JsonProperty("coverageTypeId")]
        public long CoverageTypeId { get; set; }

        [JsonProperty("questionResponses")]
        public List<QuestionResponse> QuestionResponses { get; set; }

        [JsonProperty("riskId")]
        public long? RiskId { get; set; }

        [JsonProperty("riskCoverages")]
        public List<Limit> RiskCoverages { get; set; }

        [JsonIgnore]
        [NotMapped]
        public LimitAnswers QuestionAnswers { get; set; }

        public Limit(CoverageType coverageType, string selectedDeductibleName, List<int> selectedDeductibles,
            string selectedLimitName, List<int> selectedLimits, List<QuestionResponse> questionResponses,
            long? riskId = null, List<Limit> riskCoverages = null
            )
        {
            CoverageType = coverageType;
            CoverageTypeId = coverageType.Id;
            SelectedDeductibleName = selectedDeductibleName;
            SelectedDeductibles = selectedDeductibles;
            SelectedLimitName = selectedLimitName;
            SelectedLimits = selectedLimits;
            QuestionResponses = questionResponses ?? new List<QuestionResponse>();
            RiskId = riskId;
            RiskCoverages = riskCoverages ?? new List<Limit>();
            QuestionAnswers = new();
        }
        [JsonConstructor]
        public Limit(long coverageTypeId, string selectedDeductibleName, List<int> selectedDeductibles,
                   string selectedLimitName, List<int> selectedLimits, List<QuestionResponse> questionResponses,
                   long? riskId = null, List<Limit> riskCoverages = null
                   )
        {
            CoverageTypeId = coverageTypeId;
            SelectedDeductibleName = selectedDeductibleName;
            SelectedDeductibles = selectedDeductibles;
            SelectedLimitName = selectedLimitName;
            SelectedLimits = selectedLimits;
            QuestionResponses = questionResponses ?? new List<QuestionResponse>();
            RiskId = riskId;
            RiskCoverages = riskCoverages ?? new List<Limit>();
            QuestionAnswers = new();
        }

        public Limit(long coverageTypeId)
        {
            CoverageTypeId = coverageTypeId;
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
