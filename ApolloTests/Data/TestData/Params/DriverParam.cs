using HitachiQA.Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using static ApolloTests.Data.TestData.Params.VehicleParam;

namespace ApolloTests.Data.TestData.Params
{
    public class DriverParam
    {
        public RiskObject.DriverObject Object;

        public RiskObject Risk { get; set; }

        public DriverQuentionAnswerParam DriverQuentionAnswerParam { get; set; }
            = new DriverQuentionAnswerParam();

        public DriverParam(JObject driverObject)
        {
            var obj = driverObject.ToObject<RiskObject.DriverObject>();
            obj.NullGuard();
            Object = obj;
            this.Risk = new RiskObject(ref Object);
        }

        public DriverParam()
        {
            Object = new RiskObject.DriverObject();
            this.Risk = new RiskObject(ref Object);
        }

        public void LoadJObject(JObject driverObject)
        {
            Object =  driverObject.ToObject<RiskObject.DriverObject>()?? throw new Exception();
        }    

        public class RiskObject
        {
            public RiskObject(ref DriverObject driver)
            {
                this.driver = driver;
            }

            public int riskTypeId { get; set; } = 2;

            public OutputMetadata outputMetadata { get; set; } = new OutputMetadata();

            public DriverObject driver { get; set; }

            public class DriverObject
            {
                public Person person { get; set; } = new Person();

                public DateTime dateOfBirth { get; set; } = new DateTime(1965, 10, 26, 04, 00, 00);

                public string stateProvinceId { get; set; } = "@GoverningStateId";

                public StateProvince stateProvince { get; set; } = new StateProvince();

                public string licenseNo { get; set; } = "@LicenseNumber";

                public int statusId { get; set; } = 0;

                public JObject ToJObject()
                {
                    return JObject.FromObject(this);
                }

                public class PrimaryName
                {
                    public string given { get; set; } = "Miguel";

                    public string? middle { get; set; }

                    public string surName { get; set; } = "Acosta";

                    public string? suffix { get; set; }
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

            public class OutputMetadata
            {
                public DriverHistory DriverHistory { get; set; } = new DriverHistory();

                public List<QuestionResponse> QuestionResponses { get; set; } = new List<QuestionResponse>();
            }

            public class DriverHistory
            {
                public int id { get; set; }

                public List<Incident> accidents { get; set; } = new List<Incident>();

                public List<Incident> violations { get; set; } = new List<Incident>();

                public List<Incident> convictions { get; set; } = new List<Incident>();

                public class Incident
                {
                    public DateTime date { get; set; }

                    public string? reason { get; set; }

                    public string? state { get; set; }

                    public string? notes { get; set; }

                    public string? description { get; set; }

                    public string? wasRecklessDriving { get; set; }
                }
            }

            public class QuestionResponse
            {
                public int questionId { get; set; }

                public int questionType { get; set; }

                public string? questionAlias { get; set; }

                public int sectionId { get; set; }

                public object? response { get; set; }

                public bool isHidden { get; set; }
            }

            public override string ToString()
            {
                return JObject.FromObject(this).ToString();
            }
        }
    }
}