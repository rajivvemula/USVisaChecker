using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json.Linq;
using ApolloQA.Source.Helpers;
using ApolloQA.Data.Entity.Question;
using ApolloQA.Data.Rating;

namespace ApolloQA.Data.Entity
{
    public class Quote
    {
        public readonly long Id;

        public Quote(int Id) {
            this.Id = Id;
        }
        public Quote(long Id)
        {
            this.Id = Id;
        }
        public Quote(string property, int value)
        {
            this.Id = (int)Cosmos.GetQuery("Application", $"SELECT * FROM c Where c.{property}={value} ORDER BY c._ts DESC OFFSET 0 LIMIT 1").ElementAt(0)["Id"];

        }
        public Quote(string property, string value)
        {
            this.Id = (int)Cosmos.GetQuery("Application", $"SELECT * FROM c Where c.{property}='{value}' ORDER BY c._ts DESC OFFSET 0 LIMIT 1").ElementAt(0)["Id"];

        }
        public Quote(JObject quoteProps)
        {
            this.Id = quoteProps["Id"].ToObject<long>();
            this._properties = quoteProps;
        }
        private JObject _properties = null;

        public Quote CacheProps()
        {
            this._properties =  Cosmos.GetQuery("Application", $"SELECT * FROM c WHERE c.Id = {this.Id} OFFSET 0 LIMIT 1").ElementAt(0);

            return this;
        }
        public dynamic GetProperties()
        {
            if (_properties != null)
            {
                return _properties;
            }
            return Cosmos.GetQuery("Application", $"SELECT * FROM c WHERE c.Id = {this.Id} OFFSET 0 LIMIT 1").ElementAt(0);
        }
        public dynamic GetProperty(String propertyName)
        {
            var property = this.GetProperties()[propertyName];
            return property;
        }
        public dynamic this[String propertyName]
        {
            get
            {
                var method = this.GetType().GetProperty(propertyName);
                if (method != null)
                {
                    return method.GetGetMethod().Invoke(this, null);
                }
                else
                {
                    return GetProperty(propertyName);
                }
            }
        }


        public static Quote GetLatestQuote()
        {
            return new Quote((int)Cosmos.GetQuery("Application", "SELECT * FROM c WHERE c.ApplicationStatusValue  NOT IN (\"Issued\", \"Expired\", \"Cancelled\") ORDER BY c._ts DESC OFFSET 0 LIMIT 1").ElementAt(0)["Id"]);
        }


        public static Quote GetLatestIssuedQuote()
        {
            return new Quote((int)Cosmos.GetQuery("Application", "SELECT * FROM c WHERE c.ApplicationStatusValue = \"Quoted\" ORDER BY c._ts DESC OFFSET 0 LIMIT 1").ElementAt(0)["Id"]);
        }

        public static int GetNCFRequest(long tetherID)
        {
            return  Cosmos.GetQuery("NcfRequest", $"SELECT * FROM c WHERE c.TetherId = {tetherID} ORDER BY c._ts DESC OFFSET 0 LIMIT 1").ElementAt(0)["Id"];
        }

        public static string GetNCFRResponse(long requestID)
        {
            return Cosmos.GetQuery("NcfResponse", $"SELECT * FROM c WHERE c.RequestId = {requestID} ORDER BY c._ts DESC OFFSET 0 LIMIT 1").ElementAt(0)["RawScore"];
        }



        public Policy PurchaseThis()
        {
            var body = new JObject()
            {
                { "amount", 100 },
                { "checkDate", DateTime.Now},
                { "entityId", this.Tether.Id },
                { "entityTypeId", 15000},
                { "isAppliedToCollections", null},
                { "memo", "113456"},
                { "partyId", this.Organization.Id},
                { "paymentMethodTypeId", 4}
            };
            var response = RestAPI.POST("payment", body);

            if(response.isSuccess!=true)
            {
                throw Functions.handleFailure(response);
            }

            return GetCurrentRatableObject();

        }


        public Tether Tether
        {
            get
            {
                return new Tether(this.GetProperty("TetherId").ToObject<long>());
            }
        }

        private Policy _currentRatableObject;
        public Policy GetCurrentRatableObject()
        {
            if(_currentRatableObject == null)
            {
                var ratableObjectId = Tether.GetTether(this.Id).CurrentRatableObjectId;
                if(ratableObjectId == null)
                {
                    return null;
                }
                _currentRatableObject = new Policy(ratableObjectId?? throw new ArgumentNullException());
            }
            return _currentRatableObject;
        }

        public Policy? GetRatableObject()
        {
            var ratableObjectId = SQL.executeQuery($"SELECT RatableObjectId FROM tether.TetherApplicationRatableObject where ApplicationId = {this.Id}")[0]["RatableObjectId"];
            return ratableObjectId is DBNull ? null : new Policy(ratableObjectId);
        }


        public IEnumerable<CoverageType> getCoverageTypes(Vehicle risk)
        {
            
            var coverages = this.GetProperty("SelectedCoverages");

            foreach(var coverage in coverages)
            {
                var coverageType = new CoverageType((int)coverage.CoverageTypeId);

                if(coverageType.isVehicleLevel)
                {
                    foreach(var riskEntry in coverage.RiskCoverages)
                    {
                        if (riskEntry.RiskId == risk.RiskId)
                        {
                            yield return coverageType;
                        }
                    }
                }
                else
                {
                    yield return coverageType;
                }

            }

        }

        public IEnumerable<CoverageType.Limit> getLimits(Vehicle risk)
        {

            var coverages = this.GetProperty("SelectedCoverages");

            foreach (var coverage in coverages)
            {
                var coverageType = new CoverageType((int)coverage.CoverageTypeId);

                if (coverageType.isVehicleLevel)
                {
                    foreach (var riskEntry in coverage.RiskCoverages)
                    {
                        if (riskEntry.RiskId == risk.RiskId)
                        {
                            var limit  = new CoverageType.Limit(coverageType,
                                                    riskEntry.SelectedDeductibleName.ToObject<string?>(),
                                                    riskEntry.SelectedDeductibles.ToObject<List<int>>(),
                                                    riskEntry.SelectedLimitName.ToObject<string?>(),
                                                    riskEntry.SelectedLimits.ToObject<List<int>>(),
                                                    (JArray)riskEntry.QuestionResponses
                                                    );
                            yield return limit;
                        }
                    }
                }
                else
                {
                    var limit = new CoverageType.Limit(coverageType,
                                                    coverage.SelectedDeductibleName.ToObject<string?>(),
                                                    coverage.SelectedDeductibles.ToObject<List<int>>(),
                                                    coverage.SelectedLimitName.ToObject<string?>(),
                                                    coverage.SelectedLimits.ToObject<List<int>>(),
                                                    (JArray)coverage.QuestionResponses
                                                    );
                    yield return limit;
                }

            }

        }
        public dynamic GetVehicleTypeRisk()
        {
            int riskTypeId = 1;

            return RestAPI.GET($"/quote/{this.Id}/risktype/{riskTypeId}");
        }
        public List<Vehicle> GetVehicles()
        {
            return ((JArray)GetVehicleTypeRisk().risks).Select(risk => risk).ToList<dynamic>().Select(risk => new Vehicle(risk.risk.id.ToObject<int>())).ToList<Vehicle>();
        }
        public dynamic GetDriverTypeRisk()
        {
            int riskTypeId = 2;

            return RestAPI.GET($"/quote/{this.Id}/risktype/{riskTypeId}");
        }
        public List<Driver> GetDrivers()
        {
            return ((JArray)GetDriverTypeRisk().risks).Select(risk => risk).ToList<dynamic>().Select(risk => new Driver(risk.risk.id.ToObject<int>())).ToList<Driver>();
        }

        public dynamic GetSectionQuestions(string sectionName)
        {
            var sectionId = this.Storyboard.GetSection(sectionName).Id;
            return RestAPI.GET($"/quote/{this.Id}/sections/{sectionId}/questions");
        }

        public dynamic GetQuestionResponse(string alias)
        {
            foreach(var response in this.GetProperty("QuestionResponses"))
            {
                if(response.questionAlias==alias)
                {
                    return ((JValue)response.response)?.Value;
                }
            }
            return null;
        }
        public dynamic SetQuestionResponse(string alias)
        {
            foreach (var response in this.GetProperty("QuestionResponses"))
            {
                if (response.questionAlias == alias)
                {
                    return ((JValue)response.response)?.Value;
                }
            }
            return null;
        }
        public JObject PostSummary()
        {
            var response = RestAPI.POST($"quote/{this.Id}/summary", "");
            return response;
        }

        public Address PhysicalAddress
        {
            get
            {
                return new Address(((JToken)this["PhysicalAddressId"]).ToObject<long>());
            }
        }
        public int GoverningStateId
        {
            get
            {
                return int.Parse(this["GoverningStateId"]);
            }
        }

        public string GoverningStateCode
        {
            get
            {
                return PhysicalAddress.StateCode;
            }
        }

        private String _ApplicationNumber { get; set; }
        public String ApplicationNumber
        {
            get
            {
                return _ApplicationNumber ??= GetProperty("ApplicationNumber");
            }
        } 

        private Organization _organization { get; set; }
        public Organization Organization
        {

            get
            {
                return _organization ??= new Organization((int)this.GetProperty("InsuredId"));               
            }
        }

        public Question.Storyboard Storyboard
        {
            get
            {
                //Log.Debug($"Get Storyboard for Quote ID: {this.Id}");
                return new Question.Storyboard(this.GetProperty("StoryboardId").ToObject<int>());
            }
        }

        public string CoveredAutos
        {
            get
            {
                return this.GetCurrentRatableObject().CoveredAutos;
            }
        }

        public String MotorCarrierFiling
        {
            get
            {
                return this.GetCurrentRatableObject().MotorCarrierFiling;
            }
        }
        public Boolean AccidentPreventionCredit
        {
            get
            {
                return this.GetCurrentRatableObject().AccidentPreventionCredit;
            }

        }
        public String BillingType
        {
            get
            {
                return this.GetCurrentRatableObject().BillingType;
            }
        }
        public int RatingPackageId
        {
            get
            {
                return this.GetCurrentRatableObject().RatingPackageID;
            }
        }
        public String PaymentPlan
        {
            get
            {
                return this.GetCurrentRatableObject().PaymentPlan;
            }
        }
        public String isEft
        {
            get
            {
                return this.GetCurrentRatableObject().isEft;
            }

        }
        public int? RadiusOfOperation
        {
            get
            {
                return this.GetCurrentRatableObject().RadiusOfOperation;
            }
        }


        private dynamic _CAB;
        public dynamic GetCAB(bool Refresh)
        {
            _CAB = null;
            return GetCAB();
        }
        public dynamic GetCAB()
        {
            if (_CAB == null)
            {


                string baseURL = Environment.GetEnvironmentVariable(Environment.GetEnvironmentVariable("CAB_BASEURL_SECRETNAME"));
                string APIKEY = Environment.GetEnvironmentVariable(Environment.GetEnvironmentVariable("CAB_API_KEY_SECRETNAME"));

                var usDot = GetQuestionResponse("USDOT#");
                if (usDot == null)
                {
                    return null;
                }
                var response = RestAPI.GET($"{baseURL}/rest/services/biberk/carrier/checkDOT/{usDot}?key={APIKEY}");

                if (!(bool)response.found)
                {
                    Log.Debug("usDot" + usDot + " was returned invalid from CAB");
                    return null;
                }

                _CAB = RestAPI.GET($"{baseURL}/rest/services/biberk/carrier/{usDot}?key={APIKEY}");
            }
             
            return _CAB;


        }

        public int InspectionCount
        {
            get
            {
               return GetCAB()?.events?.inspections?.insp?.tot ?? 0;
            }
        }
        public decimal OutOfServiceViolationRatio
        {
            get
            {
                decimal OOSViolationCount  = (decimal?)GetCAB()?.events?.inspections?.OOS?.tot?.ToObject<decimal>() ?? 0;

                decimal InspectionCount = this.InspectionCount;
                                
                if(GetCAB() ==null)
                {
                    return -2;
                }
                if(InspectionCount ==0)
                {
                    return -1;
                }
                else
                {
                   return Math.Round(OOSViolationCount / InspectionCount, 4, MidpointRounding.AwayFromZero);
                }
            }
        }
        public int TotalBASICViolationWeight
        {
            get
            {
                var basicWeights = ((JArray)GetCAB()?.BASICWeights);

                if(basicWeights == null)
                {
                    return 0;
                }
                var weights = basicWeights.Select(it => (decimal)it["baseWeight"]).ToList();


                return (int)Math.Floor(weights.Sum());

            }
        }

        private JObject _ScheduleModifiers;
        public JObject ScheduleModifiers
        {
            get
            {
                if(_ScheduleModifiers == null)
                {
                    _ScheduleModifiers = RestAPI.GET($"/quote/{this.Id}")["scheduleModifiers"];

                }
                return _ScheduleModifiers;
            }
        }

        public decimal SAFETYORGANIZATION
        {
            get {
                return ((decimal?)ScheduleModifiers["SAFETYORGANIZATION"]["adjustmentPercentage"])??0;
           }
        }
        public decimal CLASSIFICATION
        {
            get
            {
                return ((decimal?)ScheduleModifiers["CLASSIFICATION"]["adjustmentPercentage"]) ?? 0;
            }
        }
        public decimal MANAGEMENT
        {
            get
            {
                return ((decimal?)ScheduleModifiers["MANAGEMENT"]["adjustmentPercentage"])??0;
            }
        }
        public decimal EMPLOYEES
        {
            get
            {
                return ((decimal?)ScheduleModifiers["EMPLOYEES"]["adjustmentPercentage"]) ?? 0;
            }
        }
        
        public decimal EQUIPMENT
        {
            get
            {
                return ((decimal?)ScheduleModifiers["EQUIPMENT"]["adjustmentPercentage"])??0;
            }
        }
        public decimal ExperienceModifier
        {
            get
            {
                return ((decimal?)RestAPI.GET($"/quote/{this.Id}")["experienceModifier"]["adjustmentPercentage"])??0;
            }
        }
    }
}
