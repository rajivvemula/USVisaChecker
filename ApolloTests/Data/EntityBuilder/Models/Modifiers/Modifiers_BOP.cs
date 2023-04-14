using ApolloTests.Data.EntityBuilder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ApolloTests.Data.EntityBuilder.Models.Modifiers
{
    public class Modifiers_BOP
    {
        public const string BUILDINGFEATURES = "BUILDINGFEATURES";
        public const string LOCATION = "LOCATION";
        public const string FINANCIALSTABILITY = "FINANCIALSTABILITY";
        public const string EMPLOYEES = "EMPLOYEES";
        public const string LOSSEXPERIENCE = "LOSSEXPERIENCE";
        public const string MANAGEMENT = "MANAGEMENT";
        public const string PREMISESEQUIPMENT = "PREMISESEQUIPMENT";
        public const string PROTECTION = "PROTECTION";
        public const string TOTAL = "TOTAL";



        public ScheduleModifiers scheduleModifiers { get; set; } = new ScheduleModifiers();


        public bool shouldApplyPreferredTrucking { get; set; } = false;

        public class ScheduleModifiers
        {
            public Modifier BUILDINGFEATURES { get; set; } = new Modifier(Modifiers_BOP.BUILDINGFEATURES);
            public Modifier LOCATION { get; set; } = new Modifier(Modifiers_BOP.LOCATION);
            public Modifier MANAGEMENT { get; set; } = new Modifier(Modifiers_BOP.MANAGEMENT);
            public Modifier EMPLOYEES { get; set; } = new Modifier(Modifiers_BOP.EMPLOYEES);
            public Modifier FINANCIALSTABILITY { get; set; } = new Modifier(Modifiers_BOP.FINANCIALSTABILITY);
            public Modifier LOSSEXPERIENCE { get; set; } = new Modifier(Modifiers_BOP.LOSSEXPERIENCE);
            public Modifier PREMISESEQUIPMENT { get; set; } = new Modifier(Modifiers_BOP.PREMISESEQUIPMENT);
            public Modifier PROTECTION { get; set; } = new Modifier(Modifiers_BOP.PROTECTION);

            public Modifier TOTAL { get; set; } = new Modifier(Modifiers_BOP.TOTAL);


            public void Add(string scheduleModifier, decimal UWJudgementFactor)
            {
                switch (scheduleModifier)
                {
                    case Modifiers_BOP.BUILDINGFEATURES:
                        BUILDINGFEATURES.Add(UWJudgementFactor);
                        break;
                    case Modifiers_BOP.LOCATION:
                        LOCATION.Add(UWJudgementFactor);
                        break;
                    case Modifiers_BOP.MANAGEMENT:
                        MANAGEMENT.Add(UWJudgementFactor);
                        break;
                    case Modifiers_BOP.EMPLOYEES:
                        EMPLOYEES.Add(UWJudgementFactor);
                        break;
                    case Modifiers_BOP.FINANCIALSTABILITY:
                        FINANCIALSTABILITY.Add(UWJudgementFactor);
                        break;
                    case Modifiers_BOP.LOSSEXPERIENCE:
                        LOSSEXPERIENCE.Add(UWJudgementFactor);
                        break;
                    case Modifiers_BOP.PREMISESEQUIPMENT:
                        PREMISESEQUIPMENT.Add(UWJudgementFactor);
                        break;
                    case Modifiers_BOP.PROTECTION:
                        PROTECTION.Add(UWJudgementFactor);
                        break;
                    case Modifiers_BOP.TOTAL:
                        TOTAL.Add(UWJudgementFactor);
                        break;
                    default:
                        throw new ArgumentException("Invalid modifier specified.");
                }
            }

        }
    }
}
