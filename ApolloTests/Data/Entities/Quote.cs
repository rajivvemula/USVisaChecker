using HitachiQA.Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using HitachiQA.Helpers;
using ApolloTests.Data.Entity.Question;
using ApolloTests.Data.Rating;
using Newtonsoft.Json;
using static ApolloTests.Data.Entity.Policy;
using ApolloTests.Data.Entities;

namespace ApolloTests.Data.Entity
{
    public class Quote:BaseEntity
    {
        public readonly long Id;

        public Quote(int Id)
        {
            this.Id = Id;
        }
        [JsonConstructor]
        public Quote(long Id)
        {
            this.Id = Id;
        }

        public Quote(string property, int value)
        {
            this.Id = (int)Cosmos.GetQuery("Application", $"SELECT * FROM c Where c.{property}={value} ORDER BY c._ts DESC OFFSET 0 LIMIT 1").Result.ElementAt(0)["Id"];
        }

        public Quote(string property, string value)
        {
            this.Id = (int)Cosmos.GetQuery("Application", $"SELECT * FROM c Where c.{property}='{value}' ORDER BY c._ts DESC OFFSET 0 LIMIT 1").Result.ElementAt(0)["Id"];
        }

        public Quote(JObject quoteProps)
        {
            this.Id = quoteProps["Id"].ToObject<long>();
            this._properties = quoteProps;
        }

        private JObject _properties = null;

        private JObject _APIObj = null;

        public Quote CacheProps()
        {
            this._properties = Cosmos.GetQuery("Application", $"SELECT * FROM c WHERE c.Id = {this.Id} OFFSET 0 LIMIT 1").Result.ElementAt(0);
            this._APIObj = RestAPI.GET($"/quote/{this.Id}");
            return this;
        }

        public JObject GetAPIObj()
        {
            if (_APIObj != null)
            {
                return _APIObj;
            }
            return RestAPI.GET($"/quote/{this.Id}");
        }

        public dynamic GetProperties()
        {
            if (_properties != null)
            {
                return _properties;
            }
            return Cosmos.GetQuery("Application", $"SELECT * FROM c WHERE c.Id = {this.Id} OFFSET 0 LIMIT 1").Result.ElementAt(0);
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
            return new Quote((int)GetCosmosService().GetQuery("Application", "SELECT * FROM c WHERE c.ApplicationStatusValue  NOT IN (\"Issued\", \"Expired\", \"Cancelled\") ORDER BY c._ts DESC OFFSET 0 LIMIT 1").Result.ElementAt(0)["Id"]);
        }

        public static Quote GetLatestIssuedQuote()
        {
            return new Quote((int)GetCosmosService().GetQuery("Application", "SELECT * FROM c WHERE c.ApplicationStatusValue = \"Quoted\" ORDER BY c._ts DESC OFFSET 0 LIMIT 1").Result.ElementAt(0)["Id"]);
        }

        public static int GetNCFRequest(long tetherID)
        {
            return GetCosmosService().GetQuery("NcfRequest", $"SELECT * FROM c WHERE c.TetherId = {tetherID} ORDER BY c._ts DESC OFFSET 0 LIMIT 1").Result.ElementAt(0)["Id"];
        }

        public static string GetNCFRResponse(long requestID)
        {
            return GetCosmosService().GetQuery("NcfResponse", $"SELECT * FROM c WHERE c.RequestId = {requestID} ORDER BY c._ts DESC OFFSET 0 LIMIT 1").Result.ElementAt(0)["RawScore"];
        }

        public Policy PurchaseThis()
        {
            var body = new JObject()
            {
                { "amount", 10000 },
                { "checkDate", DateTime.Now},
                { "entityId", this.Tether.Id },
                { "entityTypeId", 15000},
                { "tetherId", this.Tether.Id },
                { "isAppliedToCollections", null},
                { "memo", "113456"},
                { "paymentMethodTypeId", 4}
            };
            var response = RestAPI.POST("payment", body);

            if (response.isSuccess != true)
            {
                throw Functions.handleFailure(response);
            }

            return GetCurrentRatableObject();
        }

        public JObject ReferToUnderwriting()
        {
            var response = RestAPI.POST($"/quote/{Id}/referToUnderwriting", "\"Testing\"");

            return response;
        }

        public JObject GenerateProposal()
        {
            var response = RestAPI.POST($"/quote/{Id}/proposal", null);

            return response;
        }

        public dynamic CreateEndorsementHeader(long policyId)
        {
            var endorseObject = new
            {
                number = "001",
                label = "Endorsement Label",
                effectiveDate = this.Tether.EffectiveDate.AddDays(2).ToString("O"),
                reasonForChangeId = ReasonForChangeEndorsement.AgencyInitiated,
                uwReasonsForChange = ""
            };

            var response = RestAPI.PUT($"/policy/{policyId}/endorsement/{Id}", JObject.FromObject(endorseObject));
            return response;

        }

        private Tether _tether;
        public Tether Tether => _tether ??= new Tether(this.GetProperty("TetherId").ToObject<long>());

        private Policy _currentRatableObject;

        public Policy GetCurrentRatableObject()
        {
            if (_currentRatableObject == null)
            {
                var ratableObjectId = Tether.GetTether(this.Id).CurrentRatableObjectId;
                if (ratableObjectId == null)
                {
                    return null;
                }
                _currentRatableObject = new Policy(ratableObjectId ?? throw new ArgumentNullException());
            }
            return _currentRatableObject;
        }

        public Policy? GetRatableObject()
        {
            var ratableObjectId = SQL.executeQuery($"SELECT RatableObjectId FROM tether.TetherApplicationRatableObject where ApplicationId = {this.Id}")[0]["RatableObjectId"];
            return ratableObjectId is DBNull ? null : new Policy(ratableObjectId);
        }

        public List<CoverageType.Limit> SelectedCoverages => ((JArray)this.GetProperty("SelectedCoverages"))
                                                            .ToObject<List<CoverageType.Limit>>()
                                                            .Where(it => it.selectedDeductibleName != null || it.selectedLimitName != null || (it.riskCoverages?.Any() ?? false))
                                                            .OrderBy(it => it.GetCoverageType().SortOrder).ToList().ToList();

        public IEnumerable<CoverageType> getCoverageTypes(Vehicle risk)
        {
            foreach (var limit in SelectedCoverages)
            {
                var coverageType = limit.GetCoverageType();

                if (coverageType.isVehicleLevel)
                {
                    foreach (var riskEntry in limit.riskCoverages)
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

        public List<CoverageType.Limit> getLimits()
        {
            return this.SelectedCoverages;
        }

        public IEnumerable<CoverageType.Limit> getLimits(Vehicle risk)
        {
            foreach (var limit in SelectedCoverages)
            {
                var coverageType = limit.GetCoverageType();

                if (coverageType.isVehicleLevel)
                {
                    foreach (var riskEntry in limit.riskCoverages)
                    {
                        if (riskEntry.riskId == risk.RiskId)
                        {
                            yield return limit;
                        }
                    }
                }
                else if (!(risk.IsNonPowered() && coverageType.IsNonPoweredVehicle_Unapplicable()))
                {
                    yield return limit;
                }
            }
        }

        public dynamic GetVehicleTypeRisk()
        {
            int riskTypeId = 1;

            if (_properties != null)
            {
                if (_properties[nameof(GetVehicleTypeRisk)] == null)
                {
                    _properties[nameof(GetVehicleTypeRisk)] = RestAPI.GET($"/quote/{this.Id}/risktype/{riskTypeId}");
                }
                return _properties[nameof(GetVehicleTypeRisk)];
            }

            return RestAPI.GET($"/quote/{this.Id}/risktype/{riskTypeId}");
        }

        public List<Vehicle> GetVehicles()
        {
            try
            {
                return ((JArray)GetVehicleTypeRisk().risks).Select(risk => risk).ToList<dynamic>().Select(risk => new Vehicle(risk.risk.id.ToObject<string>())).ToList();
            }
            catch(Exception ex)
            {
                Log.Error(GetVehicleTypeRisk().risks);
                throw;
            }
        }

        public JObject GetDriverTypeRisk()
        {
            int riskTypeId = 2;
            if (_properties != null)
            {
                if (_properties[nameof(GetDriverTypeRisk)] == null)
                {
                    _properties[nameof(GetDriverTypeRisk)] = RestAPI.GET($"/quote/{this.Id}/risktype/{riskTypeId}");
                }
                return (JObject)_properties[nameof(GetDriverTypeRisk)];
            }
            return RestAPI.GET($"/quote/{this.Id}/risktype/{riskTypeId}");
        }

        public List<Driver> GetDrivers()
        {
            return ((JArray)GetDriverTypeRisk()["risks"]).Select(risk => risk).ToList<dynamic>().Select(risk => new Driver(risk.risk.id.ToObject<int>())).ToList<Driver>();
        }

        public dynamic GetSectionQuestions(string sectionName)
        {
            var sectionId = this.Storyboard.GetSection(sectionName).Id;
            return RestAPI.GET($"/quote/{this.Id}/sections/{sectionId}/questions")["questionDefinitions"];
        }

        public dynamic GetCoverageQuestions(string coverageTypeName)
        {
            var limits = (JArray)RestAPI.GET($"/quote/{this.Id}/policy/limits");

            var limit = limits.First(it => it["coverageTypeName"].ToString() == coverageTypeName);
            return limit["configuration"]["questions"];
        }

        public dynamic GetQuestionResponse(string alias)
        {
            foreach (JObject response in this.GetProperty("QuestionResponses"))
            {
                if (response?["QuestionAlias"]?.ToString() == alias)
                {
                    return response["Response"].ToObject<dynamic>();
                }
            }
            return null;
        }

        public JObject PostSummary()
        {
            var response = RestAPI.POST($"quote/{this.Id}/summary", "");
            return response;
        }

        public JObject GetSummary()
        {
            var response = RestAPI.GET($"quote/{this.Id}/summary");
            return response;
        }

        [Obsolete("Please use PrimaryAddress instead")]
        public Address PhysicalAddress => PrimaryAddress;

        public Address PrimaryAddress
        {
            get
            {
                var ids = (JArray)this["AddressIds"];
                if(ids.Count==1)
                {
                    return new Address(ids[0].ToObject<long>());
                }
                else
                {
                    throw new NotImplementedException($"Need to implement handle for multiple addresses current count: {ids.Count}");
                }
             
            }
        }

        public long GoverningStateId
        {
            get
            {
                return (long)this.GetProperty("GoverningStateId");
            }
        }

        public string GoverningStateCode
        {
            get
            {
                return PrimaryAddress.StateCode;
            }
        }

        public string GoverningStateName
        {
            get
            {
                return PrimaryAddress.StateName;
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

        [Obsolete("Information about insured should come from Application.BusinessInformation now")]
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
                decimal OOSViolationCount = (decimal?)GetCAB()?.events?.inspections?.OOS?.tot?.ToObject<decimal>() ?? 0;

                decimal InspectionCount = this.InspectionCount;

                if (GetCAB() == null)
                {
                    return -2;
                }
                if (InspectionCount == 0)
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

                if (basicWeights == null)
                {
                    return 0;
                }
                var weights = basicWeights.Select(it => (decimal)it["baseWeight"]).ToList();

                return (int)Math.Floor(weights.Sum());
            }
        }

        public JObject ScheduleModifiers => (JObject)GetAPIObj()["scheduleModifiers"];

        private decimal getScheduleModifier(string modifierName)
        {
            var obj = ScheduleModifiers[modifierName];
            decimal percentage = obj["adjustmentPercentage"].ToObject<decimal?>() ?? 0;
            foreach (JObject action in obj["actionResults"])
            {
                percentage += action["percentage"].ToObject<decimal>();
            }
            return percentage;
        }

        public long SAFETYORGANIZATION_Id => ScheduleModifiers[nameof(SAFETYORGANIZATION)]["id"].ToObject<long>();

        public decimal SAFETYORGANIZATION
        {
            get
            {
                return getScheduleModifier(nameof(SAFETYORGANIZATION));
            }
        }

        public long CLASSIFICATION_Id => ScheduleModifiers[nameof(CLASSIFICATION)]["id"].ToObject<long>();

        public decimal CLASSIFICATION
        {
            get
            {
                return getScheduleModifier(nameof(CLASSIFICATION));
            }
        }

        public long MANAGEMENT_Id => ScheduleModifiers[nameof(MANAGEMENT)]["id"].ToObject<long>();

        public decimal MANAGEMENT
        {
            get
            {
                return getScheduleModifier(nameof(MANAGEMENT));
            }
        }

        public long EMPLOYEES_Id => ScheduleModifiers[nameof(EMPLOYEES)]["id"].ToObject<long>();

        public decimal EMPLOYEES
        {
            get
            {
                return getScheduleModifier(nameof(EMPLOYEES));
            }
        }

        public long EQUIPMENT_Id => ScheduleModifiers[nameof(EQUIPMENT)]["id"].ToObject<long>();

        public decimal EQUIPMENT
        {
            get
            {
                return getScheduleModifier(nameof(EQUIPMENT));
            }
        }

        public long TOTAL_Id => ScheduleModifiers["TOTAL"]["id"].ToObject<long>();

        public JObject GetExperienceModifierObj() => (JObject)GetAPIObj()["experienceModifier"];

        public long EXPERIENCE_Id => GetExperienceModifierObj()["id"].ToObject<long>();

        public decimal ExperienceModifier
        {
            get
            {
                decimal percentage = GetExperienceModifierObj()["adjustmentPercentage"].ToObject<decimal?>() ?? 0;
                foreach (JObject action in GetExperienceModifierObj()["actionResults"])
                {
                    percentage += action["percentage"].ToObject<decimal>();
                }
                return percentage;
            }
        }

        public long GetRatingModifierId(string ModifierCode)
        {
            try
            {
                return SQL.executeQuery(@$"   SELECT RM.Id
                                  FROM [rating].[RatingModifier] RM
                                  LEFT JOIN [rating].[RatingModifierCategoryType] T on T.Id = RM.RatingModifierCategoryTypeId
                                  LEFT JOIN [rating].[RatingModifierCategorySubtype] subT on subT.Id = RM.RatingModifierCategorySubtypeId
                                  LEFT JOIN location.StateProvince SP on SP.Id = RM.StateProvinceId
                                  Where SP.Code = '{this.GoverningStateCode}' and subT.Code = '{ModifierCode}';")[0]["Id"];
            }
            catch
            {
                Log.Critical($"Error while getting Id for ModifierCode={ModifierCode}");
                throw;
            }
        }
    }
}