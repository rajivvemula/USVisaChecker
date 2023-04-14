using ApolloTests.Data.EntityBuilder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ApolloTests.Data.EntityBuilder.Models.Modifiers
{
    public class Modifiers_CA
    {
        public const string SAFETYORGANIZATION = "SAFETYORGANIZATION";
        public const string CLASSIFICATION = "CLASSIFICATION";
        public const string MANAGEMENT = "MANAGEMENT";
        public const string EMPLOYEES = "EMPLOYEES";
        public const string EQUIPMENT = "EQUIPMENT";
        public const string TOTAL = "TOTAL";
        public const string ExperienceModifier = "EXPERIENCE";



        public ScheduleModifiers scheduleModifiers { get; set; } = new ScheduleModifiers();

        public Modifier experienceModifier { get; set; } = new Modifier(ExperienceModifier);

        public bool shouldApplyPreferredTrucking { get; set; } = false;

        public class ScheduleModifiers
        {
            public Modifier SAFETYORGANIZATION { get; set; } = new Modifier(Modifiers_CA.SAFETYORGANIZATION);

            public Modifier CLASSIFICATION { get; set; } = new Modifier(Modifiers_CA.CLASSIFICATION);

            public Modifier MANAGEMENT { get; set; } = new Modifier(Modifiers_CA.MANAGEMENT);

            public Modifier EMPLOYEES { get; set; } = new Modifier(Modifiers_CA.EMPLOYEES);

            public Modifier EQUIPMENT { get; set; } = new Modifier(Modifiers_CA.EQUIPMENT);

            public Modifier TOTAL { get; set; } = new Modifier(Modifiers_CA.TOTAL);

            public void Add(string scheduleModifier, decimal UWJudgementFactor)
            {
                switch (scheduleModifier)
                {
                    case Modifiers_CA.SAFETYORGANIZATION:
                        SAFETYORGANIZATION.Add(UWJudgementFactor);
                        break;
                    case Modifiers_CA.CLASSIFICATION:
                        CLASSIFICATION.Add(UWJudgementFactor);
                        break;
                    case Modifiers_CA.MANAGEMENT:
                        MANAGEMENT.Add(UWJudgementFactor);
                        break;
                    case Modifiers_CA.EMPLOYEES:
                        EMPLOYEES.Add(UWJudgementFactor);
                        break;
                    case Modifiers_CA.EQUIPMENT:
                        EQUIPMENT.Add(UWJudgementFactor);
                        break;
                    case Modifiers_CA.TOTAL:
                        TOTAL.Add(UWJudgementFactor);
                        break;
                    default:
                        throw new ArgumentException("Invalid modifier specified.");
                }
            }

        }
    }
}
