using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace ApolloQA.Data.TestData.Params
{
    public class DriverParam
    {
        public DriverParam(JObject driverObject)
        {
            Object = driverObject.ToObject<DriverObject>();
        }

        public DriverParam()
        {
            Object = new DriverObject();
        }

        public void LoadJObject(JObject driverObject)
        {
            Object = driverObject.ToObject<DriverObject>();
        }

        public DriverObject Object { get; set; }

        public RiskObject Risk { get; set; } = new RiskObject();

        public DriverQuentionAnswerParam DriverQuentionAnswerParam { get; set; }
            = new DriverQuentionAnswerParam();

        public class DriverObject
        {
            public Person person { get; set; } = new Person();

            public DateTime dateOfBirth { get; set; } = new DateTime(1965, 10, 26, 04, 00, 00);

            public string stateProvinceId { get; set; } = "@GoverningStateId";

            public StateProvince stateProvince { get; set; } = new StateProvince();

            public string licenseNo { get; set; } = "@LicenseNumber";

            public string riskPartyId { get; set; } = "@OrganizationPartyId";

            public int statusId { get; set; } = 0;

            public JObject ToJObject()
            {
                return JObject.FromObject(this);
            }

            public class PrimaryName
            {
                public string given { get; set; } = "Miguel";

                public string middle { get; set; }

                public string surName { get; set; } = "Acosta";

                public string suffix { get; set; }
            }

            public class Person
            {
                public PrimaryName primaryName { get; set; } = new PrimaryName();
            }

            public class StateProvince
            {
                public string code { get; set; } = "@StateCode";
            }

            public override string ToString()
            {
                return JObject.FromObject(this).ToString();
            }
        }

        public class RiskObject
        {
            public string riskId { get; set; } = "@DriverRiskId";

            public int riskType { get; set; } = 2;

            public OutputMetadata outputMetadata { get; set; } = new OutputMetadata();

            public class OutputMetadata
            {
                public DriverHistory DriverHistory { get; set; } = new DriverHistory();

                public List<QuestionRespons> QuestionResponses { get; set; } = new List<QuestionRespons>();
            }

            public class DriverHistory
            {
                public int id { get; set; }

                public object cdlExperience { get; set; }

                public object numberOfInspections { get; set; }

                public List<Incident> accidents { get; set; } = new List<Incident>();

                public List<Incident> violations { get; set; } = new List<Incident>();

                public List<Incident> convictions { get; set; } = new List<Incident>();

                public class Incident
                {
                    public DateTime date { get; set; }

                    public string reason { get; set; }

                    public string state { get; set; }

                    public string notes { get; set; }

                    public string description { get; set; }

                    public string wasRecklessDriving { get; set; }
                }
            }

            public class QuestionRespons
            {
                public int questionId { get; set; }

                public int questionType { get; set; }

                public string questionAlias { get; set; }

                public int sectionId { get; set; }

                public object response { get; set; }

                public bool isHidden { get; set; }
            }
        }
    }
}