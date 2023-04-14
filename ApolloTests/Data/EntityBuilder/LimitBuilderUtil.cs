using ApolloTests.Data.Entity;
using ApolloTests.Data.EntityBuilder.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApolloTests.Data.EntityBuilder
{
    public static class LimitBuilder
    {
        public static void RemoveLimit(this List<Limit> limits, CoverageType coverage) => limits.RemoveLimit(coverage.Name);
        public static void RemoveLimit(this List<Limit> limits, string coverageName)
        {
            limits.RemoveAll(limit => limit.GetCoverageType().Name == coverageName);
        }
        public static Limit? Getter(this List<Limit> limits, string coverageName) => limits.Find(c => c.GetCoverageType().Name == coverageName);

        public static void Setter(this List<Limit> limits, CoverageType coverageType, bool value = true) => limits.Setter(coverageType.Name, value);

        public static void Setter(this List<Limit> limits, string coverageName, bool value = true)
        {
            if (value)
            {
                if (limits.Any(it => it.coverageType.Name == coverageName))
                {
                    throw new InvalidOperationException($"Limit already exists with Coverage Type {coverageName}");
                }
                switch (coverageName)
                {
                    case CoverageType.BIPD:
                        limits.AddBIPD();
                        break;
                    case CoverageType.MEDICAL_PAYMENTS:
                        limits.AddMedicalPayments();
                        break;
                    case CoverageType.COLLISION:
                        limits.AddCollision();
                        break;
                    case CoverageType.COMPREHENSIVE:
                        limits.AddComprehensive();
                        break;
                    case CoverageType.UNDERINSURED_MOTORIST:
                        limits.AddVehicleUnderinsuredMotorists();
                        break;
                    case CoverageType.UNINSURED_MOTORIST:
                        limits.AddVehicleUninsuredMotorists();
                        break;
                    case CoverageType.CARGO:
                        limits.AddCargo();
                        break;
                    case CoverageType.RENTAL_REIMBURSEMENT:
                        limits.AddRentalReimbursement();
                        break;
                    case CoverageType.IN_TOW:
                        limits.AddInTow();
                        break;
                    case CoverageType.TRAILER_INTERCHANGE:
                        limits.AddTrailerInterchange();
                        break;
                    case CoverageType.UNINSURED_UNDERINSURED_BI:
                        limits.AddUninsuredUnderinsuredBI();
                        break;
                    case CoverageType.UNINSURED_MOTORIST_BI:
                        limits.AddUninsuredMotoristBI();
                        break;
                    case CoverageType.UNINSURED_MOTORIST_PD:
                        limits.AddUninsuredMotoristPD();
                        break;
                    case CoverageType.UNINSURED_BIPD:
                        limits.AddUninsuredMotoristBIPD();
                        break;
                    case CoverageType.UNINSURED_UNDERINSURED_BIPD:
                        limits.AddUninsuredUnderinsurredBIPD();
                        break;
                    case CoverageType.UNDERINSURED_MOTORIST_BI:
                        limits.AddUnderinsurredBI();
                        break;
                    case CoverageType.PERSONAL_INJURY_PROTECTION:
                        limits.AddPersonalInjuryProtection();
                        break;
                    case CoverageType.DAMAGE_TO_PREMISES_RENTED_TO_YOU:
                        limits.AddDamageToPremisesRentedToYou();
                        break;
                    case CoverageType.GENERAL_LIABILITY:
                        limits.AddGeneralLiability();
                        break;
                    case CoverageType.EMPLOYEE_DISHONESTY:
                        limits.AddEmployeeDishonesty();
                        break;
                    default:
                        throw new NotImplementedException($"Coverage Type: {coverageName} has not been implemented");
                }
            }
            else
            {
                limits.RemoveLimit(coverageName);
            }
        }

        #region Commercial Auto
        public static void AddBIPD(this List<Limit> limits)
        {
            limits.Add(new Limit(
                        coverageType: new CoverageType(CoverageType.BIPD),
                        selectedDeductibleName: "Deductible",
                        selectedDeductibles: new List<int>(),
                        selectedLimitName: "Combined Single Limit",
                        selectedLimits: new List<int>() { 100000 },
                        questionResponses: null
                        ));
        }

        public static void AddMedicalPayments(this List<Limit> limits)
        {
            limits.Add(new Limit(
                      coverageType: new CoverageType(CoverageType.MEDICAL_PAYMENTS),
                      selectedDeductibleName: null,
                      selectedDeductibles: new List<int>(),
                      selectedLimitName: "Combined Single Limit",
                      selectedLimits: new List<int>() { 1000 },
                      questionResponses: null
                      ));
        }

        public static void AddCollision(this List<Limit> limits)
        {
            limits.Add(new Limit(
                      coverageType: new CoverageType(CoverageType.COLLISION),
                      selectedDeductibleName: "Deductible",
                      selectedDeductibles: new List<int>() { 1000 },
                      selectedLimitName: null,
                      selectedLimits: new List<int>(),
                      questionResponses: new()
                      ));
        }

        public static void AddComprehensive(this List<Limit> limits)
        {
            limits.Add(new Limit(
                        coverageType: new CoverageType(CoverageType.COMPREHENSIVE),
                        selectedDeductibleName: "Deductible",
                        selectedDeductibles: new List<int>() { 1000 },
                        selectedLimitName: null,
                        selectedLimits: new List<int>(),
                        questionResponses: new()
                        ));
        }

        public static void AddVehicleUnderinsuredMotorists(this List<Limit> limits)
        {
            limits.Add(new Limit(
                        coverageType: new CoverageType(CoverageType.UNDERINSURED_MOTORIST),
                        selectedDeductibleName: null,
                        selectedLimitName: "Combined Single Limit",
                        selectedLimits: new List<int>() { 100000 },
                        selectedDeductibles: new List<int>(),
                        questionResponses: null
                        ));
        }

        public static void AddVehicleUninsuredMotorists(this List<Limit> limits)
        {
            limits.Add(new Limit(
                        coverageType: new CoverageType(CoverageType.UNINSURED_MOTORIST),
                        selectedDeductibleName: null,
                        selectedDeductibles: new List<int>(),
                        selectedLimitName: "Combined Single Limit",
                        selectedLimits: new List<int>() { 100000 },
                        questionResponses: null
                        ));
        }
        public static void AddUninsuredUnderinsuredBI(this List<Limit> limits)
        {
            limits.Add(new Limit(
                        coverageType: new CoverageType(CoverageType.UNINSURED_UNDERINSURED_BI),
                        selectedDeductibleName: null,
                        selectedDeductibles: new List<int>(),
                        selectedLimitName: "Combined Single Limit",
                        selectedLimits: new List<int>() { 100000 },
                        questionResponses: null
                        ));
        }

        public static void AddCargo(this List<Limit> limits)
        {
            limits.Add(new Limit(
                        coverageType: new CoverageType(CoverageType.CARGO),
                        selectedDeductibleName: "Deductible",
                        selectedDeductibles: new List<int>() { 1000 },
                        selectedLimitName: "Combined Single Limit",
                        selectedLimits: new List<int>() { 100000 },
                        questionResponses: null
                        ));
        }

        public static void AddRentalReimbursement(this List<Limit> limits)
        {
            limits.Add(new Limit(
                        coverageType: new CoverageType(CoverageType.RENTAL_REIMBURSEMENT),
                        selectedDeductibleName: null,
                        selectedDeductibles: new List<int>(),
                        selectedLimitName: "Options",
                        selectedLimits: new List<int>() { 30, 30, 900 },
                        questionResponses: null
                        ));
        }

        public static void AddInTow(this List<Limit> limits)
        {
            limits.Add(new Limit(
                        coverageType: new CoverageType(CoverageType.IN_TOW),
                        selectedDeductibleName: "Deductible",
                        selectedDeductibles: new List<int>() { 1000 },
                        selectedLimitName: "Combined Single Limit",
                        selectedLimits: new List<int>() { 100000 },
                        questionResponses: null
                        ));
        }

        public static void AddTrailerInterchange(this List<Limit> limits)
        {
            limits.Add(new Limit(
                        coverageType: new CoverageType(CoverageType.TRAILER_INTERCHANGE),
                        selectedDeductibleName: "Deductible",
                        selectedDeductibles: new List<int>() { 1000, 1000 },
                        selectedLimitName: "Combined Single Limit",
                        selectedLimits: new List<int>() { 50000 },
                        questionResponses: null
                        ));
        }
        public static void AddUninsuredMotoristBIPD(this List<Limit> limits)
        {
            limits.Add(new Limit(
                         coverageType: new CoverageType(CoverageType.UNINSURED_BIPD),
                         selectedDeductibleName: null,
                         selectedDeductibles: new List<int>(),
                         selectedLimitName: "Combined Single Limit",
                         selectedLimits: new List<int>() { 100000 },
                         questionResponses: null
                         ));
        }

        public static void AddUninsuredMotoristPD(this List<Limit> limits)
        {
            limits.Add(new Limit(
                         coverageType: new CoverageType(CoverageType.UNINSURED_MOTORIST_PD),
                         selectedDeductibleName: null,
                         selectedDeductibles: new List<int>(),
                         selectedLimitName: "Combined Single Limit",
                         selectedLimits: new List<int>() { 100000 },
                         questionResponses: null
                         ));
        }

        public static void AddUninsuredMotoristBI(this List<Limit> limits)
        {
            limits.Add(new Limit(
                        coverageType: new CoverageType(CoverageType.UNINSURED_MOTORIST_BI),
                        selectedDeductibleName: null,
                        selectedDeductibles: new List<int>(),
                        selectedLimitName: "Combined Single Limit",
                        selectedLimits: new List<int>() { 100000 },
                        questionResponses: null
                        ));
        }
        public static void AddUninsuredUnderinsurredBIPD(this List<Limit> limits)
        {
            limits.Add(new Limit(
                        coverageType: new CoverageType(CoverageType.UNINSURED_UNDERINSURED_BIPD),
                        selectedDeductibleName: null,
                        selectedDeductibles: new List<int>(),
                        selectedLimitName: "Combined Single Limit",
                        selectedLimits: new List<int>() { 100000 },
                        questionResponses: null
                        ));
        }
        public static void AddUnderinsurredBI(this List<Limit> limits)
        {
            limits.Add(new Limit(
                        coverageType: new CoverageType(CoverageType.UNDERINSURED_MOTORIST_BI),
                        selectedDeductibleName: null,
                        selectedDeductibles: new List<int>(),
                        selectedLimitName: "Combined Single Limit",
                        selectedLimits: new List<int>() { 100000 },
                        questionResponses: null
                        ));
        }
        public static void AddPersonalInjuryProtection(this List<Limit> limits)
        {
            limits.Add(new Limit(
                        coverageType: new CoverageType(CoverageType.PERSONAL_INJURY_PROTECTION),
                        selectedDeductibleName: null,
                        selectedDeductibles: new List<int>(),
                        selectedLimitName: "Personal Injury Protection Limit",
                        selectedLimits: new List<int>() { 2500 },
                        questionResponses: null
                        ));
        }
        #endregion

        #region BOP / GL

        public static void AddDamageToPremisesRentedToYou(this List<Limit> limits)
        {
            limits.Add(new Limit(
                       coverageType: new CoverageType(CoverageType.DAMAGE_TO_PREMISES_RENTED_TO_YOU),
                       selectedDeductibleName: null,
                       selectedDeductibles: new List<int>(),
                       selectedLimitName: "Limit",
                       selectedLimits: new List<int>() { 50000 },
                       questionResponses: null
                       ));
        }
        public static void AddGeneralLiability(this List<Limit> limits)
        {
            limits.Add(new Limit(
                       coverageType: new CoverageType(CoverageType.GENERAL_LIABILITY),
                       selectedDeductibleName: "Deductible",
                       selectedDeductibles: new List<int>() { 1000 },
                       selectedLimitName: "Limits",
                       selectedLimits: new List<int>() { 300000, 600000, 600000 },
                       questionResponses: null
                       ));

        }
        public static void AddEmployeeDishonesty(this List<Limit> limits)
        {
            limits.Add(new Limit(
                      coverageType: new CoverageType(CoverageType.EMPLOYEE_DISHONESTY),
                      selectedDeductibleName: null,
                      selectedDeductibles: new List<int>() ,
                      selectedLimitName: "Limit",
                      selectedLimits: new List<int>() { 10000},
                      questionResponses: null
                      ));
        }

        #endregion
    }
}
