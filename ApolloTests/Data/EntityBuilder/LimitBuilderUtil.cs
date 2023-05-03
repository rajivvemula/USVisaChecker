using ApolloTests.Data.EntityBuilder.SectionBuilders;
using ApolloTests.Data.Entities.Coverage;
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
        public static void RemoveLimit(this List<Limit> limits, CoverageType coverage) => limits.RemoveLimit(coverage.TypeName);
        public static void RemoveLimit(this List<Limit> limits, string coverageName)
        {
            limits.RemoveAll(limit => limit.GetCoverageType().TypeName == coverageName);
        }
        public static Limit? Getter(this List<Limit> limits, string coverageName) => limits.Find((Predicate<Limit>)(c => c.GetCoverageType().TypeName == coverageName));
        public static Limit? Getter(this List<Limit> limits, CoverageType coverageType) => limits.Find((Predicate<Limit>)(c => c.GetCoverageType().Id == coverageType.Id));

        public static void Setter(this List<Limit> limits, string coverageName, bool value = true) => Setter(limits, GetCoverageType(limits, coverageName), value);

        public static void Setter(this List<Limit> limits, CoverageType coverageType, bool value = true)
        {
            if (value)
            {
                if (limits.Any(it => it.CoverageType.TypeName == coverageType.TypeName))
                {
                    throw new InvalidOperationException($"Limit already exists with Coverage Type {coverageType.TypeName}");
                }

                
                switch (coverageType.TypeName)
                {
                    case CoverageType.BIPD:
                        limits.AddBIPD(coverageType);
                        break;
                    case CoverageType.MEDICAL_PAYMENTS:
                        limits.AddMedicalPayments(coverageType);
                        break;
                    case CoverageType.COLLISION:
                        limits.AddCollision(coverageType);
                        break;
                    case CoverageType.COMPREHENSIVE:
                        limits.AddComprehensive(coverageType);
                        break;
                    case CoverageType.UNDERINSURED_MOTORIST:
                        limits.AddVehicleUnderinsuredMotorists(coverageType);
                        break;
                    case CoverageType.UNINSURED_MOTORIST:
                        limits.AddVehicleUninsuredMotorists(coverageType);
                        break;
                    case CoverageType.CARGO:
                        limits.AddCargo(coverageType);
                        break;
                    case CoverageType.RENTAL_REIMBURSEMENT:
                        limits.AddRentalReimbursement(coverageType);
                        break;
                    case CoverageType.IN_TOW:
                        limits.AddInTow(coverageType);
                        break;
                    case CoverageType.TRAILER_INTERCHANGE:
                        limits.AddTrailerInterchange(coverageType);
                        break;
                    case CoverageType.UNINSURED_UNDERINSURED_BI:
                        limits.AddUninsuredUnderinsuredBI(coverageType);
                        break;
                    case CoverageType.UNINSURED_MOTORIST_BI:
                        limits.AddUninsuredMotoristBI(coverageType);
                        break;
                    case CoverageType.UNINSURED_MOTORIST_PD:
                        limits.AddUninsuredMotoristPD(coverageType);
                        break;
                    case CoverageType.UNINSURED_BIPD:
                        limits.AddUninsuredMotoristBIPD(coverageType);
                        break;
                    case CoverageType.UNINSURED_UNDERINSURED_BIPD:
                        limits.AddUninsuredUnderinsurredBIPD(coverageType);
                        break;
                    case CoverageType.UNDERINSURED_MOTORIST_BI:
                        limits.AddUnderinsurredBI(coverageType);
                        break;
                    case CoverageType.PERSONAL_INJURY_PROTECTION:
                        limits.AddPersonalInjuryProtection(coverageType);
                        break;
                    case CoverageType.DAMAGE_TO_PREMISES_RENTED_TO_YOU:
                        limits.AddDamageToPremisesRentedToYou(coverageType);
                        break;
                    case CoverageType.GENERAL_LIABILITY:
                        limits.AddGeneralLiability(coverageType);
                        break;
                    case CoverageType.EMPLOYEE_DISHONESTY:
                        limits.AddEmployeeDishonesty(coverageType);
                        break;
                    default:
                        throw new NotImplementedException($"Coverage Type: {coverageType.TypeName} has not been implemented");
                }
            }
            else
            {
                limits.RemoveLimit(coverageType.TypeName);
            }
        }

        private static CoverageType GetCoverageType(this List<Limit> limits, string coverageType)
        {
            IBuilder builder;
            try
            {
                builder = (IBuilder)limits;
            }
            catch(Exception ex)
            {
                throw new Exception("the List<limit> this function was called upon is not an IBuilder thus, a concrete CoverageType must be passed", ex);
            }
            return builder.Builder.SQLContext.CoverageType.First(it => it.TypeName == coverageType);
        }

        #region Commercial Auto
        public static void AddBIPD(this List<Limit> limits, CoverageType cov = null)
        {
            cov ??= limits.GetCoverageType(CoverageType.BIPD);
            limits.Add(new Limit(cov)
                        {
                            SelectedDeductibleName= "Deductible",
                            SelectedDeductibles= new List<int>(),
                            SelectedLimitName= "Combined Single Limit",
                            SelectedLimits= new List<int>() { 100000 },
                            QuestionResponses= null
                        });
        }




        public static void AddMedicalPayments(this List<Limit> limits, CoverageType cov=null)
        {
            cov ??= limits.GetCoverageType(CoverageType.MEDICAL_PAYMENTS);
            limits.Add(new Limit(cov) {
                        SelectedDeductibleName= null,
                        SelectedDeductibles= new List<int>(),
                        SelectedLimitName= "Combined Single Limit",
                        SelectedLimits= new List<int>() { 1000 },
                        QuestionResponses= null
                        });
        }

        public static void AddCollision(this List<Limit> limits, CoverageType cov=null)
        {
            cov ??= limits.GetCoverageType(CoverageType.COLLISION);
            limits.Add(new Limit(cov)
                      {
                      SelectedDeductibleName= "Deductible",
                      SelectedDeductibles= new List<int>() { 1000 },
                      SelectedLimitName= null,
                      SelectedLimits= new List<int>(),
                      QuestionResponses= new()
                      });
        }

        public static void AddComprehensive(this List<Limit> limits, CoverageType cov=null)
        {
            cov ??= limits.GetCoverageType(CoverageType.COMPREHENSIVE);
            limits.Add(new Limit(cov)
                        {
                        SelectedDeductibleName= "Deductible",
                        SelectedDeductibles= new List<int>() { 1000 },
                        SelectedLimitName= null,
                        SelectedLimits= new List<int>(),
                        QuestionResponses= new()
                        });
        }

        public static void AddVehicleUnderinsuredMotorists(this List<Limit> limits, CoverageType cov=null)
        {
            cov ??= limits.GetCoverageType(CoverageType.UNDERINSURED_MOTORIST);
            limits.Add(new Limit(cov)
                        {
                        SelectedDeductibleName= null,
                        SelectedLimitName= "Combined Single Limit",
                        SelectedLimits= new List<int>() { 100000 },
                        SelectedDeductibles= new List<int>(),
                        QuestionResponses= null
                        });
        }

        public static void AddVehicleUninsuredMotorists(this List<Limit> limits, CoverageType cov=null)
        {
            cov ??= limits.GetCoverageType(CoverageType.UNINSURED_MOTORIST);
            limits.Add(new Limit(cov)
                        {
                        SelectedDeductibleName= null,
                        SelectedDeductibles= new List<int>(),
                        SelectedLimitName= "Combined Single Limit",
                        SelectedLimits= new List<int>() { 100000 },
                        QuestionResponses= null
                        });
        }
        public static void AddUninsuredUnderinsuredBI(this List<Limit> limits, CoverageType cov=null)
        {
            cov ??= limits.GetCoverageType(CoverageType.UNINSURED_UNDERINSURED_BI);
            limits.Add(new Limit(cov)
                        {
                        SelectedDeductibleName= null,
                        SelectedDeductibles= new List<int>(),
                        SelectedLimitName= "Combined Single Limit",
                        SelectedLimits= new List<int>() { 100000 },
                        QuestionResponses= null
                        });
        }

        public static void AddCargo(this List<Limit> limits, CoverageType cov=null)
        {
            cov ??= limits.GetCoverageType(CoverageType.CARGO);
            limits.Add(new Limit(cov)
                        {
                        SelectedDeductibleName= "Deductible",
                        SelectedDeductibles= new List<int>() { 1000 },
                        SelectedLimitName= "Combined Single Limit",
                        SelectedLimits= new List<int>() { 100000 },
                        QuestionResponses= null
                        });
        }

        public static void AddRentalReimbursement(this List<Limit> limits, CoverageType cov=null)
        {
            cov ??= limits.GetCoverageType(CoverageType.RENTAL_REIMBURSEMENT);
            limits.Add(new Limit(cov)
                        {
                        SelectedDeductibleName= null,
                        SelectedDeductibles= new List<int>(),
                        SelectedLimitName= "Options",
                        SelectedLimits= new List<int>() { 30, 30, 900 },
                        QuestionResponses= null
                        });
        }

        public static void AddInTow(this List<Limit> limits, CoverageType cov=null)
        {
            cov ??= limits.GetCoverageType(CoverageType.IN_TOW);
            limits.Add(new Limit(cov)
                        {
                        SelectedDeductibleName= "Deductible",
                        SelectedDeductibles= new List<int>() { 1000 },
                        SelectedLimitName= "Combined Single Limit",
                        SelectedLimits= new List<int>() { 100000 },
                        QuestionResponses= null
                        });
        }

        public static void AddTrailerInterchange(this List<Limit> limits, CoverageType cov=null)
        {
            cov ??= limits.GetCoverageType(CoverageType.TRAILER_INTERCHANGE);
            limits.Add(new Limit(cov)
                        {
                        SelectedDeductibleName= "Deductible",
                        SelectedDeductibles= new List<int>() { 1000, 1000 },
                        SelectedLimitName= "Combined Single Limit",
                        SelectedLimits= new List<int>() { 50000 },
                        QuestionResponses= null
                        });
        }
        public static void AddUninsuredMotoristBIPD(this List<Limit> limits, CoverageType cov=null)
        {
            cov ??= limits.GetCoverageType(CoverageType.UNINSURED_UNDERINSURED_BIPD);
            limits.Add(new Limit(cov)
                         {
                         SelectedDeductibleName= null,
                         SelectedDeductibles= new List<int>(),
                         SelectedLimitName= "Combined Single Limit",
                         SelectedLimits= new List<int>() { 100000 },
                         QuestionResponses= null
                         });
        }

        public static void AddUninsuredMotoristPD(this List<Limit> limits, CoverageType cov=null)
        {
            cov ??= limits.GetCoverageType(CoverageType.UNINSURED_MOTORIST_PD);
            limits.Add(new Limit(cov)
                         {
                         SelectedDeductibleName= null,
                         SelectedDeductibles= new List<int>(),
                         SelectedLimitName= "Combined Single Limit",
                         SelectedLimits= new List<int>() { 100000 },
                         QuestionResponses= null
                         });
        }

        public static void AddUninsuredMotoristBI(this List<Limit> limits, CoverageType cov=null)
        {
            cov ??= limits.GetCoverageType(CoverageType.UNINSURED_MOTORIST_BI);
            limits.Add(new Limit(cov)
                        {
                        SelectedDeductibleName= null,
                        SelectedDeductibles= new List<int>(),
                        SelectedLimitName= "Combined Single Limit",
                        SelectedLimits= new List<int>() { 100000 },
                        QuestionResponses= null
                        });
        }
        public static void AddUninsuredUnderinsurredBIPD(this List<Limit> limits, CoverageType cov=null)
        {
            cov ??= limits.GetCoverageType(CoverageType.UNINSURED_UNDERINSURED_BIPD);
            limits.Add(new Limit(cov)
                        {
                        SelectedDeductibleName= null,
                        SelectedDeductibles= new List<int>(),
                        SelectedLimitName= "Combined Single Limit",
                        SelectedLimits= new List<int>() { 100000 },
                        QuestionResponses= null
                        });
        }
        public static void AddUnderinsurredBI(this List<Limit> limits, CoverageType cov=null)
        {
            cov ??= limits.GetCoverageType(CoverageType.UNDERINSURED_MOTORIST_BI);
            limits.Add(new Limit(cov)
                        {
                        SelectedDeductibleName= null,
                        SelectedDeductibles= new List<int>(),
                        SelectedLimitName= "Combined Single Limit",
                        SelectedLimits= new List<int>() { 100000 },
                        QuestionResponses= null
                        });
        }
        public static void AddPersonalInjuryProtection(this List<Limit> limits, CoverageType cov=null)
        {
            cov ??= limits.GetCoverageType(CoverageType.PERSONAL_INJURY_PROTECTION);
            limits.Add(new Limit(cov)
                        {
                        SelectedDeductibleName= null,
                        SelectedDeductibles= new List<int>(),
                        SelectedLimitName= "Personal Injury Protection Limit",
                        SelectedLimits= new List<int>() { 2500 },
                        QuestionResponses= null
                        });
        }

      
        #endregion

        #region BOP / GL

        public static void AddDamageToPremisesRentedToYou(this List<Limit> limits, CoverageType cov=null)
        {
            cov ??= limits.GetCoverageType(CoverageType.DAMAGE_TO_PREMISES_RENTED_TO_YOU);
            limits.Add(new Limit(cov)
                       {
                       SelectedDeductibleName= null,
                       SelectedDeductibles= new List<int>(),
                       SelectedLimitName= "Limit",
                       SelectedLimits= new List<int>() { 50000 },
                       QuestionResponses= null
                       });
        }
        public static void AddGeneralLiability(this List<Limit> limits, CoverageType cov=null)
        {
            cov ??= limits.GetCoverageType(CoverageType.GENERAL_LIABILITY);
            limits.Add(new Limit(cov)
                       {
                       SelectedDeductibleName= "Deductible",
                       SelectedDeductibles= new List<int>() { 1000 },
                       SelectedLimitName= "Limits",
                       SelectedLimits= new List<int>() { 300000, 600000, 600000 },
                       QuestionResponses= null
                       });

        }
        public static void AddEmployeeDishonesty(this List<Limit> limits, CoverageType cov=null)
        {
            cov ??= limits.GetCoverageType(CoverageType.EMPLOYEE_DISHONESTY);
            limits.Add(new Limit(cov)
                      {
                      SelectedDeductibleName= null,
                      SelectedDeductibles= new List<int>() ,
                      SelectedLimitName= "Limit",
                      SelectedLimits= new List<int>() { 10000},
                      QuestionResponses= null
                      });
        }
        #endregion
    }
}
