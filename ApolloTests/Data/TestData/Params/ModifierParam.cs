using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace ApolloTests.Data.TestData.Params
{
    public class ModifierParam
    {
        public ModifierParam()
        {
            Object = new ModifierObject();
        }

        public ModifierObject Object { get; set; }

        public class ModifierObject
        {
            public const string SAFETYORGANIZATION = "SAFETYORGANIZATION";
            public const string CLASSIFICATION = "CLASSIFICATION";
            public const string MANAGEMENT = "MANAGEMENT";
            public const string EMPLOYEES = "EMPLOYEES";
            public const string EQUIPMENT = "EQUIPMENT";
            public const string TOTAL = "TOTAL";
            public const string ExperienceModifier = "EXPERIENCE";



            public ScheduleModifiers scheduleModifiers { get; set; } = new ScheduleModifiers();

            public Modifier experienceModifier { get; set; } = new Modifier(ModifierObject.ExperienceModifier);

            public bool shouldApplyPreferredTrucking { get; set; }

            public class ScheduleModifiers
            {
                public Modifier SAFETYORGANIZATION { get; set; } = new Modifier(ModifierObject.SAFETYORGANIZATION);

                public Modifier CLASSIFICATION { get; set; } = new Modifier(ModifierObject.CLASSIFICATION);

                public Modifier MANAGEMENT { get; set; } = new Modifier(ModifierObject.MANAGEMENT);

                public Modifier EMPLOYEES { get; set; } = new Modifier(ModifierObject.EMPLOYEES);

                public Modifier EQUIPMENT { get; set; } = new Modifier(ModifierObject.EQUIPMENT);

                public Modifier TOTAL { get; set; } = new Modifier(ModifierObject.TOTAL);

                public enum ScheduleModifierType
                {
                    SafetyOrganization,

                    Classification,

                    Management,

                    Employees,

                    Equipment
                }

                public void Add(ScheduleModifierType scheduleModifier, decimal UWJudgementFactor)
                {
                    switch (scheduleModifier)
                    {
                        case ScheduleModifierType.SafetyOrganization:
                            SAFETYORGANIZATION.Add(UWJudgementFactor);
                            break;

                        case ScheduleModifierType.Classification:
                            CLASSIFICATION.Add(UWJudgementFactor);
                            break;

                        case ScheduleModifierType.Management:
                            MANAGEMENT.Add(UWJudgementFactor);
                            break;

                        case ScheduleModifierType.Employees:
                            EMPLOYEES.Add(UWJudgementFactor);
                            break;

                        case ScheduleModifierType.Equipment:
                            EQUIPMENT.Add(UWJudgementFactor);
                            break;

                    }
                }
            }


            public class Modifier
            {
                public Modifier(string modifierCode)
                {
                    id=$"@Quote.{modifierCode}_Id";
                    this.ratingModifierId = $"@Quote.GetRatingModifierId(\"{modifierCode}\")";
                }
                public string id { get; set; } 

                public string applicationId { get; set; } = "@ApplicationId";

                public JObject? ratingModifierCategorySubtypeCode { get; set; }

                public string ratingModifierId { get; set; }

                public List<JObject> actionResults { get; set; } = new List<JObject>();

                public decimal totalActionResultPercentage { get; set; } = 0;

                public decimal adjustmentPercentage { get; set; }

                public JObject? adjustmentJustification { get; set; }

                public decimal totalPercentage { get; set; } = 0;

                public decimal totalFactor { get; set; } = 0;

                public void Add(decimal UWJudgementFactor)
                {
                    adjustmentPercentage = UWJudgementFactor;
                }
            }

            public JObject ToJObject()
            {
                return JObject.FromObject(this);
            }

            public override string ToString()
            {
                return JObject.FromObject(this).ToString();
            }
        }
    }
}