using ApolloTests.Data.EntityBuilder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ApolloTests.Data.EntityBuilder.Models
{
    public class Modifiers
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

        public bool shouldApplyPreferredTrucking { get; set; }

        public class ScheduleModifiers
        {
            public Modifier SAFETYORGANIZATION { get; set; } = new Modifier(Modifiers.SAFETYORGANIZATION);

            public Modifier CLASSIFICATION { get; set; } = new Modifier(Modifiers.CLASSIFICATION);

            public Modifier MANAGEMENT { get; set; } = new Modifier(Modifiers.MANAGEMENT);

            public Modifier EMPLOYEES { get; set; } = new Modifier(Modifiers.EMPLOYEES);

            public Modifier EQUIPMENT { get; set; } = new Modifier(Modifiers.EQUIPMENT);

            public Modifier TOTAL { get; set; } = new Modifier(Modifiers.TOTAL);

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
    }
}
