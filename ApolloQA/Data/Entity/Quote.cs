﻿using System;
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
        public readonly int Id;

        public Quote(int Id) {
            this.Id = Id;
        }
        public Quote(string property,  int value)
        {
            this.Id = (int)Cosmos.GetQuery("Application", $"SELECT * FROM c Where c.{property}={value} ORDER BY c._ts DESC OFFSET 0 LIMIT 1").Result[0]["Id"];

        }
        public Quote(string property, string value)
        {
            this.Id = (int)Cosmos.GetQuery("Application", $"SELECT * FROM c Where c.{property}='{value}' ORDER BY c._ts DESC OFFSET 0 LIMIT 1").Result[0]["Id"];

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
            return new Quote((int)Cosmos.GetQuery("Application", "SELECT * FROM c WHERE c.ApplicationStatusValue  NOT IN (\"Issued\", \"Expired\", \"Cancelled\") ORDER BY c._ts DESC OFFSET 0 LIMIT 1").Result[0]["Id"]);
        }

        public dynamic GetProperties()
        {
            return RestAPI.GET($"/quote/{this.Id}");
        }
        public dynamic GetProperty(String propertyName)
        {
            var property = this.GetProperties()[propertyName];
            return property == null ? "" : property;
        }


        private Policy _currentRatableObject;
        public Policy GetCurrentRatableObject()
        {
            if(_currentRatableObject == null)
            {
                _currentRatableObject= new Policy(Tether.GetTether(this.Id).CurrentRatableObjectId);
            }
            return _currentRatableObject;
        }


        public IEnumerable<CoverageType> getCoverageTypes(Vehicle risk)
        {
            
            var coverages = this.GetProperty("selectedCoverages");

            foreach(var coverage in coverages)
            {
                var coverageType = new CoverageType((int)coverage.coverageTypeId);

                if(coverageType.isVehicleLevel)
                {
                    foreach(var riskEntry in coverage.riskCoverages)
                    {
                        if (riskEntry.riskId == risk.RiskId)
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

            var coverages = this.GetProperty("selectedCoverages");

            foreach (var coverage in coverages)
            {
                var coverageType = new CoverageType((int)coverage.coverageTypeId);

                if (coverageType.isVehicleLevel)
                {
                    foreach (var riskEntry in coverage.riskCoverages)
                    {
                        if (riskEntry.riskId == risk.RiskId)
                        {
                            var limit  = new CoverageType.Limit(coverageType,
                                                    riskEntry.selectedDeductibleName.ToObject<string?>(),
                                                    riskEntry.selectedDeductibles.ToObject<List<int>>(),
                                                    riskEntry.selectedLimitName.ToObject<string?>(),
                                                    riskEntry.selectedLimits.ToObject<List<int>>(),
                                                    (JArray)riskEntry.questionResponses
                                                    );
                            yield return limit;
                        }
                    }
                }
                else
                {
                    var limit = new CoverageType.Limit(coverageType,
                                                    coverage.selectedDeductibleName.ToObject<string?>(),
                                                    coverage.selectedDeductibles.ToObject<List<int>>(),
                                                    coverage.selectedLimitName.ToObject<string?>(),
                                                    coverage.selectedLimits.ToObject<List<int>>(),
                                                    (JArray)coverage.questionResponses
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
            foreach(var response in this.GetProperty("questionResponses"))
            {
                if(response.questionAlias==alias)
                {
                    return ((JValue)response.response)?.Value;
                }
            }
            return null;
        }


        public Address PhysicalAddress
        {
            get
            {
                return new Address(((JToken)this["physicalAddressId"]).ToObject<long>());
            }
        }
        public int GoverningStateId
        {
            get
            {
                return int.Parse(this["governingStateId"]);
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
                return _ApplicationNumber ??= GetProperty("applicationNumber");
            }
        } 
        public Organization Organization
        {

            get
            {
                return new Organization((int)this.GetProperty("insuredId"));               
            }
        }

        public Question.Storyboard Storyboard
        {
            get
            {
                //Log.Debug($"Get Storyboard for Quote ID: {this.Id}");
                int storyBoardId = Cosmos.GetQuery("Application", $"SELECT * FROM c WHERE c.Id = {this.Id}").Result[0]["StoryboardId"];
                return new Question.Storyboard(storyBoardId);
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
                    _ScheduleModifiers = this.GetProperty("scheduleModifiers");

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
                return ((decimal?)this.GetProperty("experienceModifier")["adjustmentPercentage"])??0;
            }
        }
    }
}
