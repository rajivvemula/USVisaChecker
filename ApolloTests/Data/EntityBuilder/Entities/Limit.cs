using ApolloTests.Data.Entity;
using ApolloTests.Data.EntityBuilder.QuestionAnswers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApolloTests.Data.EntityBuilder.Entities
{
    public class Limit : IEntityBase
    {
        public string? selectedDeductibleName;

        public List<int> selectedDeductibles;

        public string? selectedLimitName;

        public List<int> selectedLimits;

        [JsonIgnore]
        public CoverageType coverageType;

        public long coverageTypeId => coverageType.Id;

        public List<QuestionResponse> questionResponses = new ();

        public long riskId;

        public List<Limit> riskCoverages = new ();

        [JsonIgnore]
        public LimitAnswers QuestionAnswers = new();

        public Limit(CoverageType coverageType,
                    string? selectedDeductibleName,
                    List<int> selectedDeductibles,
                    string? selectedLimitName,
                    List<int> selectedLimits,
                    List<QuestionResponse>? questionResponses,
                    long? riskId = null,
                    List<Limit>? riskCoverages = null
                    )
        {
            this.coverageType = coverageType;
            this.selectedDeductibleName = selectedDeductibleName;
            this.selectedDeductibles = selectedDeductibles;
            this.selectedLimitName = selectedLimitName;
            this.selectedLimits = selectedLimits;
            this.questionResponses = questionResponses?? new List<QuestionResponse>();
            this.riskId = riskId ?? 0;
            this.riskCoverages = riskCoverages?? new List<Limit>();
        }

        [JsonConstructor]
        public Limit(int coverageTypeId,
                    string? selectedDeductibleName,
                    List<int> selectedDeductibles,
                    string? selectedLimitName,
                    List<int> selectedLimits,
                    List<QuestionResponse>? questionResponses,
                    long? riskId = null,
                    List<Limit>? riskCoverages = null
                    )
        {
            coverageType = new CoverageType(coverageTypeId);
            this.selectedDeductibleName = selectedDeductibleName;
            this.selectedDeductibles = selectedDeductibles;
            this.selectedLimitName = selectedLimitName;
            this.selectedLimits = selectedLimits;
            this.questionResponses = questionResponses ?? new List<QuestionResponse>();
            this.riskId = riskId ?? 0;
            this.riskCoverages = riskCoverages ?? new List<Limit>();

        }

        public CoverageType GetCoverageType()
        {
            return coverageType;
        }

        public object? GetQuestionResponse(string questionAlias)
        {

            var questionResponse = questionResponses?.FirstOrDefault(it => it.questionAlias == questionAlias);

            if (questionResponse == null)
            {
                Log.Debug($"{questionAlias}returned null");
                return null;
            }
            else
            {
                Log.Debug($"{questionAlias} returned {questionResponse.response ?? "response is null"}");
                return questionResponse.response;
            }
        }
    }
}
