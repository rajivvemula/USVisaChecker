using ApolloTests.Data.Entity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApolloTests.Data.Entities
{
    public class Limit
    {
        public string? selectedDeductibleName;

        public List<int> selectedDeductibles;

        public string? selectedLimitName;

        public List<int> selectedLimits;

        private CoverageType coverageType;

        public long coverageTypeId => coverageType.Id;

        public JArray? questionResponses;

        public long riskId;

        public List<Limit>? riskCoverages;

        public Limit(CoverageType coverageType,
                    string? selectedDeductibleName,
                    List<int> selectedDeductibles,
                    string? selectedLimitName,
                    List<int> selectedLimits,
                    JArray? questionResponses,
                    long? riskId = null,
                    List<Limit>? riskCoverages = null
                    )
        {
            this.coverageType = coverageType;
            this.selectedDeductibleName = selectedDeductibleName;
            this.selectedDeductibles = selectedDeductibles;
            this.selectedLimitName = selectedLimitName;
            this.selectedLimits = selectedLimits;
            this.questionResponses = questionResponses;
            this.riskId = riskId ?? 0;
            this.riskCoverages = riskCoverages;
        }

        [JsonConstructor]
        public Limit(int coverageTypeId,
                    string? selectedDeductibleName,
                    List<int> selectedDeductibles,
                    string? selectedLimitName,
                    List<int> selectedLimits,
                    JArray? questionResponses,
                    long? riskId = null,
                    List<Limit>? riskCoverages = null
                    )
        {
            this.coverageType = new CoverageType(coverageTypeId);
            this.selectedDeductibleName = selectedDeductibleName;
            this.selectedDeductibles = selectedDeductibles;
            this.selectedLimitName = selectedLimitName;
            this.selectedLimits = selectedLimits;
            this.questionResponses = questionResponses;
            this.riskId = riskId ?? 0;
            this.riskCoverages = riskCoverages;

        }

        public CoverageType GetCoverageType()
        {
            return this.coverageType;
        }

        public object? getQuestionResponse(string questionAlias)
        {
            var questionResponse = questionResponses?.FirstOrDefault(it => it["QuestionAlias"]?.ToString() == questionAlias);

            if (questionResponse == null)
            {
                Log.Debug($"{questionAlias}returned null");
                return null;
            }
            else
            {
                Log.Debug($"{questionAlias} returned {questionResponse?["Response"] ?? "response is null"}");
                return ((JValue?)questionResponse?["Response"])?.Value;
            }
        }

        public override string ToString()
        {
            return JObject.FromObject(this).ToString();
        }
    }
}
