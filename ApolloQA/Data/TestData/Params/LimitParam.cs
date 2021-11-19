using ApolloQA.Data.Entity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace ApolloQA.Data.TestData.Params
{
    public class LimitParam
    {
        public LimitParam()
        {
        }

        public LimitParam(string coverageTypeName) : this(new CoverageType(coverageTypeName))
        {
        }

        public LimitParam(CoverageType coverageType)
        {
            Log.Debug("Limit Param: " + coverageType.Name);

            switch (coverageType.Name)
            {
                case CoverageType.BIPD:
                    AddBIPD(coverageType);
                    break;

                case CoverageType.MEDICAL_PAYMENTS:
                    AddMedicalPayments(coverageType);
                    break;

                case CoverageType.COLLISION:
                    AddCollision(coverageType);
                    break;

                case CoverageType.COMPREHENSIVE:
                    AddComprehensive(coverageType);
                    break;

                case CoverageType.UNDERINSURED_MOTORIST:
                    AddVehicleUnderinsuredMotorists(coverageType);
                    break;

                case CoverageType.UNINSURED_MOTORIST:
                    AddVehicleUninsuredMotorists(coverageType);
                    break;

                case CoverageType.CARGO:
                    AddCargo(coverageType);
                    break;

                case CoverageType.RENTAL_REIMBURSEMENT:
                    AddRentalReimbursement(coverageType);

                    break;

                case CoverageType.IN_TOW:
                    AddInTow(coverageType);
                    break;

                case CoverageType.TRAILER_INTERCHANGE:
                    AddTrailerInterchange(coverageType);
                    break;

                default:
                    throw new NotImplementedException($"Coverage Type: {coverageType.Name} has not been implemented");
            }
        }

        public CoverageType.Limit Object { get; set; }

        public string CoverageName => Object.GetCoverageType().Name;

        public CoverageType CoverageType => Object.GetCoverageType();

        public PolicyCoverageQuestionAnswerParam PolicyCoverageQuestionAnswerParam { get; set; }
            = new PolicyCoverageQuestionAnswerParam();

        private void AddBIPD(CoverageType coverageType)
        {
            Object = new CoverageType.Limit(
                        coverageType: coverageType,
                        selectedDeductibleName: "Deductible",
                        selectedDeductibles: new List<int>(),
                        selectedLimitName: "Combined Single Limit",
                        selectedLimits: new List<int>() { 100000 },
                        questionResponses: null
                        );
        }

        private void AddMedicalPayments(CoverageType coverageType)
        {
            Object = new CoverageType.Limit(
                      coverageType: coverageType,
                      selectedDeductibleName: null,
                      selectedDeductibles: new List<int>(),
                      selectedLimitName: "Combined Single Limit",
                      selectedLimits: new List<int>() { 1000 },
                      questionResponses: null
                      );
        }

        private void AddCollision(CoverageType coverageType)
        {
            Object = new CoverageType.Limit(
                      coverageType: coverageType,
                      selectedDeductibleName: "Deductible",
                      selectedDeductibles: new List<int>() { 1000 },
                      selectedLimitName: null,
                      selectedLimits: new List<int>(),
                      questionResponses: new JArray()
                      );
        }

        private void AddComprehensive(CoverageType coverageType)
        {
            Object = new CoverageType.Limit(
                        coverageType: coverageType,
                        selectedDeductibleName: "Deductible",
                        selectedDeductibles: new List<int>() { 1000 },
                        selectedLimitName: null,
                        selectedLimits: new List<int>(),
                        questionResponses: new JArray()
                        );
        }

        private void AddVehicleUnderinsuredMotorists(CoverageType coverageType)
        {
            Object = new CoverageType.Limit(
                        coverageType: coverageType,
                        selectedDeductibleName: null,
                        selectedLimitName: "Combined Single Limit",
                        selectedLimits: new List<int>() { 100000 },
                        selectedDeductibles: new List<int>(),
                        questionResponses: null
                        );
        }

        private void AddVehicleUninsuredMotorists(CoverageType coverageType)
        {
            Object = new CoverageType.Limit(
                        coverageType: coverageType,
                        selectedDeductibleName: null,
                        selectedDeductibles: new List<int>(),
                        selectedLimitName: "Combined Single Limit",
                        selectedLimits: new List<int>() { 100000 },
                        questionResponses: null
                        );
        }

        private void AddCargo(CoverageType coverageType)
        {
            Object = new CoverageType.Limit(
                        coverageType: coverageType,
                        selectedDeductibleName: "Deductible",
                        selectedDeductibles: new List<int>() { 1000 },
                        selectedLimitName: "Combined Single Limit",
                        selectedLimits: new List<int>() { 100000 },
                        questionResponses: null
                        );
        }

        private void AddRentalReimbursement(CoverageType coverageType)
        {
            Object = new CoverageType.Limit(
                        coverageType: coverageType,
                        selectedDeductibleName: null,
                        selectedDeductibles: new List<int>(),
                        selectedLimitName: "Options",
                        selectedLimits: new List<int>() { 30, 30, 900 },
                        questionResponses: null
                        );
        }

        private void AddInTow(CoverageType coverageType)
        {
            Object = new CoverageType.Limit(
                        coverageType: coverageType,
                        selectedDeductibleName: "Deductible",
                        selectedDeductibles: new List<int>() { 1000 },
                        selectedLimitName: "Combined Single Limit",
                        selectedLimits: new List<int>() { 100000 },
                        questionResponses: null
                        );
        }

        private void AddTrailerInterchange(CoverageType coverageType)
        {
            Object = new CoverageType.Limit(
                        coverageType: coverageType,
                        selectedDeductibleName: "Deductible",
                        selectedDeductibles: new List<int>() { 1000, 1000 },
                        selectedLimitName: "Combined Single Limit",
                        selectedLimits: new List<int>() { 50000 },
                        questionResponses: null
                        );
        }

        public JObject ToJObject()
        {
            return JObject.FromObject(this);
        }
    }
}