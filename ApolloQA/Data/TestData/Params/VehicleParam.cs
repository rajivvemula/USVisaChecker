using ApolloQA.Data.Entity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace ApolloQA.Data.TestData.Params
{
    public class VehicleParam
    {
        public VehicleObject Object { get; set; }

        public RiskObject Risk { get; set; } = new RiskObject();

        public VehicleQuentionAnswerParam VehicleQuentionAnswerParam { get; set; }
            = new VehicleQuentionAnswerParam();

        public List<LimitParam> LimitParams { get; set; }

        public VehicleParam()
        {
            Object = new VehicleObject();
            LimitParams = new List<LimitParam>();
        }

        public VehicleParam(JObject vehicleObject)
        {
            this.LoadJObject(vehicleObject);
            LimitParams = new List<LimitParam>();
        }

        public void LoadJObject(JObject vehicleObject)
        {
            Object = vehicleObject.ToObject<VehicleObject>();
        }

        public bool AddCollision
        {
            get
            {
                string COVERAGE_NAME = "Collision";

                return LimitParams.Find(c => c.CoverageName == COVERAGE_NAME) != null;
            }

            set
            {
                string COVERAGE_NAME = "Collision";

                if (value)
                {
                    LimitParams.Add(new LimitParam(new CoverageType(COVERAGE_NAME)));
                }
                else
                {
                    LimitParams.RemoveAll(c => c.CoverageName == COVERAGE_NAME);
                }
            }
        }

        public int CollisionDeductible
        {
            get
            {
                var limit = LimitParams.Find(it => it.CoverageName == "Collision");
                return limit.Object.selectedDeductibles[0];
            }
            set
            {
                var limit = LimitParams.Find(it => it.CoverageName == "Collision");
                limit.Object.selectedDeductibles = new List<int> { value };
            }
        }

        public bool AddComprehensive
        {
            get
            {
                string COVERAGE_NAME = "Comprehensive";

                return LimitParams.Find(c => c.CoverageName == COVERAGE_NAME) != null;
            }

            set
            {
                string COVERAGE_NAME = "Comprehensive";

                if (value)
                {
                    LimitParams.Add(new LimitParam(new CoverageType(COVERAGE_NAME)));
                }
                else
                {
                    LimitParams.RemoveAll(c => c.CoverageName == COVERAGE_NAME);
                }
            }
        }

        public int ComprehensiveDeductible
        {
            get
            {
                var limit = LimitParams.Find(it => it.CoverageName == "Comprehensive");
                return limit.Object.selectedDeductibles[0];
            }
            set
            {
                var limit = LimitParams.Find(it => it.CoverageName == "Comprehensive");
                limit.Object.selectedDeductibles = new List<int> { value };
            }
        }

        public class VehicleObject
        {
            public int id { get; set; }

            public string riskPartyId { get; set; } = "@OrganizationPartyId";

            public int riskId { get; set; } = 0;

            public int typeId { get; set; } = 5;

            public bool isVinTelligence { get; set; } = false;

            public int yearOfManufacture { get; set; } = 2020;

            public string make { get; set; } = "Honda";

            public string model { get; set; } = "Accord";

            public string vinNumber { get; set; } = "@VinNumber";

            public String trim { get; set; } = null;

            public String notes { get; set; } = null;

            public string classCode { get; set; } = "@ClassCode";

            public int bodyCategoryTypeId { get; set; } = 1;

            public int bodySubCategoryTypeId { get; set; } = 1;

            public string grossVehicleWeight { get; set; } = "5000";

            public string additionalModifications { get; set; } = "none";

            public string statedAmount { get; set; } = "5000";

            public int estimatedCurrentValue { get; set; } = 10000;

            public bool? antitheft { get; set; } = null;

            public bool? safetyFeatures { get; set; } = null;

            public int? inspectionCount { get; set; } = null;

            public bool isNonPoweredVehicle { get; set; } = false;

            public int? totalBASICViolationWeight { get; set; } = null;

            public decimal? outOfServiceViolationRatio { get; set; } = null;

            public JObject ToJObject()
            {
                return JObject.FromObject(this);
            }

            public override string ToString()
            {
                return JObject.FromObject(this).ToString();
            }
        }

        public class RiskObject
        {
            public string riskId { get; set; } = "@VehicleRiskId";

            public int riskType { get; set; } = 1;

            public string vehicleClassCode { get; set; } = "@ClassCode";

            public OutputMetadata outputMetadata { get; set; } = new OutputMetadata();

            public class OutputMetadata
            {
                public VehicleLocation VehicleLocation { get; set; } = new VehicleLocation();

                public string VehicleClassCode { get; set; } = "@ClassCode";

                public List<QuestionRespons> QuestionResponses { get; set; } = new List<QuestionRespons>();
            }

            public class VehicleLocation
            {
                public string locationId { get; set; } = "@PhysicalAddressId";

                public override string ToString()
                {
                    return JObject.FromObject(this).ToString();
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

                public override string ToString()
                {
                    return JObject.FromObject(this).ToString();
                }
            }

            public override string ToString()
            {
                return JObject.FromObject(this).ToString();
            }
        }
    }
}