using ApolloTests.Data.Entity;
using ApolloTests.Data.Rating;
using ApolloTests.Data.TestData.Params;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using static ApolloTests.Data.TestData.Params.ModifierParam.ModifierObject.ScheduleModifiers;

namespace ApolloTests.Data.TestData
{
    public class QuoteParam
    {
        public QuoteParam(string state, string algorithmCode)
        {
            State = state;
            ClassCodeKeyword = ClassCodeKeyword.GetUsingAlgorithmCode(algorithmCode, state);
            LimitParam.Limits.Add(new LimitParam(ClassCodeKeyword.coverage ?? new CoverageType("BIPD")));
        }

        public QuoteParam(string state, ClassCodeKeyword classCodeKeyword)
        {
            State = state;
            ClassCodeKeyword = classCodeKeyword;
            LimitParam.Limits.Add(new LimitParam(ClassCodeKeyword.coverage ?? new CoverageType("BIPD")));
        }

        public QuoteParam(string state) : this(state, new CoverageType("BIPD")) { }

        public QuoteParam(string state, CoverageType coverageType) : this(state, new List<CoverageType>() { coverageType }) { }

        public QuoteParam(string state, List<CoverageType> coverageTypes)
        {
            State = state;
            
            foreach (var cov in coverageTypes)
            {
                this.LimitParam.Add(cov);
                switch (cov.Name)
                {
                    case CoverageType.TRAILER_INTERCHANGE:
                        this.VehicleParam.Vehicles[0].Object.grossVehicleWeight = "30000";
                        break;

                    case CoverageType.IN_TOW:
                        this.ClassCodeKeyword ??= ClassCodeKeyword.GetUsingKeywordName("Towing Services");
                        break;

                    case CoverageType.CARGO:
                        this.ClassCodeKeyword ??= ClassCodeKeyword.GetUsingKeywordName("Towing Services");
                        break;

                    case CoverageType.RENTAL_REIMBURSEMENT:
                        this.VehicleParam.Vehicles[0].AddCollision = true;
                        break;

                    default:
                        //this.ClassCodeKeyword ??= ClassCodeKeyword.GetUsingKeywordName("Accounting Services");
                        break;
                }
            }
            this.ClassCodeKeyword ??= ClassCodeKeyword.GetUsingKeywordName("Accounting Services");
        }

        public string State { get; set; } = "IL";

        public ClassCodeKeyword ClassCodeKeyword { get; set; } = null;

        public Organization Organization { get; set; }

        public DateTime RatableObjectEffectiveDate { get; set; } = DateTime.Now.AddDays(1);

        public DateTime RatableObjectExpirationDate { get; set; } = DateTime.Now.AddDays(1).AddYears(1);

        public Vehicle VehicleParam { get; set; } = new Vehicle();

        public Driver DriverParam { get; set; } = new Driver();

        public Limit LimitParam { get; set; } = new Limit();

        public Modifier ModifierParam { get; set; } = new Modifier();

        public QuoteQuentionAnswerParam QuoteQuentionAnswerParam { get; set; } = new QuoteQuentionAnswerParam();

        public AdditionalInterest AdditionalInterestParam { get; set; } = new AdditionalInterest();

        public Entity.Quote RunThisThroughAPI()
        {
            return new Quote(this).GetQuotedQuoteThroughAPI();
        }

        public void BIPD_SplitLimit(int BI_PerPerson = 100000, int BI_perOccurrence = 300000, int PD_perOccurrence = 500000)
        {
            var limit = LimitParam.Limits.Find(it => it.CoverageName == CoverageType.BIPD);

            if (limit == null)
            {
                limit = new LimitParam(CoverageType.BIPD);
                LimitParam.Limits.Add(limit);
            }

            limit.Object.selectedLimitName = "Split Limit";
            limit.Object.selectedLimits = new List<int> { BI_PerPerson, BI_perOccurrence, PD_perOccurrence };
        }

        public class AdditionalInterest
        {
            public uint NumberOfAdditionalInterest
            {
                get
                {
                    return (uint)AdditionalInterests.Count;
                }
                set
                {
                    if (NumberOfAdditionalInterest > value)
                    {
                        while (AdditionalInterests.Count != value)
                        {
                            AdditionalInterests.RemoveAt(AdditionalInterests.Count - 1);
                        }
                    }
                    else
                    {
                        while (NumberOfAdditionalInterest != value)
                        {
                            this.Add();
                        }
                    }
                }
            }

            public List<AdditionalInterestsParam> AdditionalInterests { get; set; } = new List<AdditionalInterestsParam>() { new AdditionalInterestsParam() };

            public void Add()
            {
                AdditionalInterests.Add(new AdditionalInterestsParam());
            }
        }

        public class Vehicle
        {
            public uint NumberOfVehicles
            {
                get
                {
                    return (uint)Vehicles.Count;
                }
                set
                {
                    if (NumberOfVehicles > value)
                    {
                        while (Vehicles.Count != value)
                        {
                            Vehicles.RemoveAt(Vehicles.Count - 1);
                        }
                    }
                    else
                    {
                        while (NumberOfVehicles != value)
                        {
                            Vehicles.Add(new VehicleParam());
                        }
                    }
                }
            }

            public int NumberOfTrailers { get; set; }

            public List<VehicleParam> Vehicles { get; set; } = new List<VehicleParam>() { new VehicleParam() };

            public void Add(JObject vehicle)
            {
                Vehicles.Add(new VehicleParam(vehicle));
            }
        }

        public class Driver
        {
            public int NumberOfDrivers
            {
                get
                {
                    return Drivers.Count;
                }
                set
                {
                    if (NumberOfDrivers > value)
                    {
                        while (Drivers.Count != value)
                        {
                            Drivers.RemoveAt(Drivers.Count - 1);
                        }
                    }
                    else
                    {
                        while (NumberOfDrivers != value)
                        {
                            Drivers.Add(new DriverParam());
                        }
                    }
                }
            }

            public List<DriverParam> Drivers { get; set; } = new List<DriverParam>() { new DriverParam() };

            public void Add(JObject driver)
            {
                Drivers.Add(new DriverParam(driver));
            }
        }

        public class Limit
        {
            public List<LimitParam> Limits { get; set; } = new List<LimitParam>();

            public void Add(string coverageType)
            {
                Limits.Add(new LimitParam(coverageType));
            }

            public void Add(CoverageType coverageType)
            {
                Limits.Add(new LimitParam(coverageType));
            }
        }

        public class Modifier
        {
            public ModifierParam Modifiers { get; set; } = new ModifierParam();

            public decimal ExperienceRating { set { Modifiers.Object.experienceModifier.adjustmentPercentage = value; } }

            public decimal SAFETYORGANIZATION { set { Modifiers.Object.scheduleModifiers.SAFETYORGANIZATION.adjustmentPercentage = value; } }

            public decimal CLASSIFICATION { set { Modifiers.Object.scheduleModifiers.CLASSIFICATION.adjustmentPercentage = value; } }

            public decimal MANAGEMENT { set { Modifiers.Object.scheduleModifiers.MANAGEMENT.adjustmentPercentage = value; } }

            public decimal EMPLOYEES { set { Modifiers.Object.scheduleModifiers.EMPLOYEES.adjustmentPercentage = value; } }

            public decimal EQUIPMENT { set { Modifiers.Object.scheduleModifiers.EQUIPMENT.adjustmentPercentage = value; } }

            public void AddScheduleModifier(ScheduleModifierType scheduleModifierType, decimal uwJudgementFactor)
            {
                Modifiers.Object.scheduleModifiers.Add(scheduleModifierType, uwJudgementFactor);
            }

            public void AddExperienceModifier(decimal uwJudgementFactor)
            {
                Modifiers.Object.experienceModifier.Add(uwJudgementFactor);
            }
        }
    }
}