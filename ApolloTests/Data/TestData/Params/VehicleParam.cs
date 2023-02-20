using ApolloTests.Data.Entity;
using HitachiQA.Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace ApolloTests.Data.TestData.Params
{
    public class VehicleParam
    {
        public RiskObject.VehicleObject Object;

        public RiskObject Risk { get; set; }

        public VehicleQuentionAnswerParam VehicleQuentionAnswerParam { get; set; }
            = new VehicleQuentionAnswerParam();

        public List<LimitParam> LimitParams { get; set; }

        public VehicleParam()
        {
            Object = new RiskObject.VehicleObject();
            Risk = new RiskObject(ref this.Object);
            LimitParams = new List<LimitParam>();
        }

        public VehicleParam(JObject vehicleObject)
        {
            this.LoadJObject(vehicleObject);
            this.Object.NullGuard();
            Risk = new RiskObject(ref this.Object);
            LimitParams = new List<LimitParam>();
        }

        public void LoadJObject(JObject vehicleObject)
        {
            var obj = vehicleObject.ToObject<RiskObject.VehicleObject>();
            obj.NullGuard();
            Object = obj;
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

        

        public class RiskObject
        {

            public RiskObject(ref VehicleObject vehicle)
            {
                this.vehicle = vehicle;
            }

            public int riskTypeId { get; set; } = 1;
            public string classCode { get; set; } = "@ClassCode";

            public OutputMetadata outputMetadata { get; set; } = new OutputMetadata();

            public VehicleObject vehicle {get; set;}

            public class VehicleObject
            {
                public string id { get; set; } = "00000000-0000-0000-0000-000000000000";

                public int riskId { get; set; } = 0;

                public int? typeId { get; set; } = null;

                public bool isVinTelligence { get; set; } = true;

                public int yearOfManufacture { get; set; } = 2020;

                public string make { get; set; } = "Honda";

                public string model { get; set; } = "Accord";

                public string vinNumber { get; set; } = "@VinNumber";

                public string trim { get; set; } = "Sedan 4D LE";

                public int bodyCategoryTypeId { get; set; } = 1;

                public int bodySubCategoryTypeId { get; set; } = 1;

                public string grossVehicleWeight { get; set; } = "5000";

                public string costNew { get; set; } = "19545";

                public string? statedAmount { get; set; } = null;

                public bool useStatedAmount { get; set; } = false;

                public int? estimatedCurrentValue { get; set; } = null;

                public string calculatedValue { get; set; } = "7000";

                public string underwriterValue { get; set; } = "";

                public bool? antitheft { get; set; } = null;

                public bool? safetyFeatures { get; set; } = null;

                public int? inspectionCount { get; set; } = null;

                public int? totalBASICViolationWeight { get; set; } = null;

                public decimal? outOfServiceViolationRatio { get; set; } = null;

                public object? isVinDataVariance { get; set; } = null;

                public object? preVinRateRank { get; set; } = null;

                public int vinRateRank { get; set; } = 1;

                public JObject ToJObject()
                {
                    return JObject.FromObject(this);
                }

                public override string ToString()
                {
                    return JObject.FromObject(this).ToString();
                }
            }

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