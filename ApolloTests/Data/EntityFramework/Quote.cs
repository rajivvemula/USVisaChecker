using ApolloTests.Data.Entities;
using ApolloTests.Data.EntityFramework.Context;
using ApolloTests.Data.EntityFramework.Coverage;
using HitachiQA.Helpers;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using static ApolloTests.Data.Entity.Policy;

namespace ApolloTests.Data.EntityFramework
{
    public class Quote : BaseEntity
    {
        public CosmosContext Context { get; }
        public SQLContext ContextSQL { get; }
        public Quote(CosmosContext context)
        {
            Context = context;
            ContextSQL = context.SQLContext;
            //localSQL = sql;

        }
        [Key]
        public string id { get; set; }
        [Required]
        public string Discriminator { get; set; }
        public long Id { get; set; }
        public string ApplicationNumber { get; set; }
        public long TetherId { get; set; }
        public string ApplicationStatusValue { get; set; }
        public List<long> AddressIds { get; set; }
        public long _ts { get; set; }



        public JObject GetAPIObj()
        {
            return RestAPI.GET($"/quote/{this.Id}") ?? throw new Exception("GetAPIObj returned null");
        }

        public dynamic GetProperty(String propertyName)
        {
            throw new NotImplementedException();
        }

        [NotMapped]
        public dynamic? this[String propertyName]
        {
            get
            {
                var method = this.GetType().GetProperty(propertyName);
                if (method != null)
                {
                    return method.GetGetMethod()?.Invoke(this, null);
                }
                else
                {
                    return GetProperty(propertyName);
                }
            }
        }

        public static Quote GetLatestQuote(CosmosContext context)
        {
            return context.Quotes.OrderByDescending(it=> it._ts).First(quote => ! (new[] { "Issued", "Expired", "Canceled" }.Contains(quote.ApplicationStatusValue)));
        }

        public static Quote GetLatestIssuedQuote(SQLContext context)
        {
            return context.Tether.OrderByDescending(it=> it.Id).Last(it=> it.TetherStatusCode=="ISSUED").CurrentQuote;
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
            var paymentAmount = SummaryResponse?["ratingResponses"]?.Select(it => it["fullTermPremium"]?.Value<int>()).Max() / 12;
            paymentAmount.NullGuard();
            var body = new JObject()
            {
                { "amount", paymentAmount+1 },
                { "checkDate", DateTime.Now},
                { "entityId", this.Tether.Id },
                { "entityTypeId", 15000},
                { "tetherId", this.Tether.Id },
                { "isAppliedToCollections", null},
                { "memo", "113456"},
                { "paymentMethodTypeId", 4}
            };
            var response = RestAPI.POST("payment", body);

            if (response?.isSuccess != true)
            {
                throw Functions.HandleFailure(response);
            }
            try
            {
                this.Tether.waitForTetherStatus("ISSUED");
            }
            catch (Exception)
            {
                Log.Error("Summary Response:");
                Log.Error(SummaryResponse);
                throw;
            }
            this.ContextSQL.Entry(this.Tether).Reload();
            var policy = Tether.CurrentPolicy ?? throw new Exception("PurchaseThis returned null");
            Log.Debug($"Purchased PolicyId: {policy.Id}");
            return policy;
        }



        public JObject ReferToUnderwriting()
        {
            var response = RestAPI.POST($"/quote/{Id}/referToUnderwriting", "\"Testing\"");

            this.Tether.waitForTetherStatus("REFERRED");

            return response ?? throw new Exception("ReferToUnderwriting returned null");
        }

        public JObject GenerateProposal()
        {
            var response = RestAPI.POST($"/quote/{Id}/proposal", null);
            this.Tether.waitForTetherStatus("QUOTED");

            return response ?? throw new Exception("GenerateProposal returned null");
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
            return response ?? throw new Exception("CreateEndorsementHeader returned null");

        }

        public Tether.Tether Tether => ContextSQL.Tether.First(tether => tether.Id == TetherId);

        [NotMapped]
        public List<Limit> SelectedCoverages => ((JArray)this.GetProperty("SelectedCoverages"))
                                                            ?.ToObject<List<Limit>>()
                                                            ?.Where(it => it.selectedDeductibleName != null || it.selectedLimitName != null || (it.riskCoverages?.Any() ?? false))
                                                            ?.OrderBy(it => it.GetCoverageType().SortOrder).ToList().ToList()
                                                            ?? throw new NullReferenceException("SelectedCoverages returned null")
                                                            ;

        public IEnumerable<CoverageType> getCoverageTypes(Entity.Vehicle risk)
        {
            throw new NotImplementedException("Needs implementation for entity framework");
            //foreach (var limit in SelectedCoverages)
            //{
            //    var coverageType = limit.GetCoverageType();

            //    if (coverageType.isVehicleLevel)
            //    {
            //        foreach (var riskEntry in limit?.riskCoverages ?? throw new Exception("RiskCoverages returned null"))
            //        {
            //            if (riskEntry.riskId == risk.RiskId)
            //            {
            //                yield return coverageType;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        yield return coverageType;
            //    }
            //}
        }

        //public List<Limit> getLimits()
        //{
        //    return this.SelectedCoverages;
        //}

        public IEnumerable<Limit> getLimits(Entity.Vehicle risk)
        {
            throw new NotImplementedException("Needs implementation for entity framework");

            //foreach (var limit in SelectedCoverages)
            //{
            //    var coverageType = limit.GetCoverageType();

            //    if (coverageType.isVehicleLevel)
            //    {
            //        foreach (var riskEntry in limit.riskCoverages ?? throw new Exception("Limit.riskcoverages returned null"))
            //        {
            //            if (riskEntry.riskId == risk.RiskId)
            //            {
            //                yield return limit;
            //            }
            //        }
            //    }
            //    else if (!(risk.IsNonPowered() && coverageType.IsNonPoweredVehicle_Unapplicable()))
            //    {
            //        yield return limit;
            //    }
            //}
        }

        public dynamic GetVehicleTypeRisk()
        {
            int riskTypeId = 1;

            return RestAPI.GET($"/quote/{this.Id}/risktype/{riskTypeId}") ?? throw new Exception("GetVehicleTypeRisk returned null 2");
        }

        public List<Entity.Vehicle> GetVehicles()
        {
            try
            {
                return ((JArray)GetVehicleTypeRisk().risks).Select(risk => risk).ToList<dynamic>().Select(risk => new Entity.Vehicle(risk.risk.id.ToObject<string>())).ToList();
            }
            catch (Exception)
            {
                Log.Error(GetVehicleTypeRisk().risks);
                throw;
            }
        }

        public JObject GetDriverTypeRisk()
        {
            int riskTypeId = 2;
            return RestAPI.GET($"/quote/{this.Id}/risktype/{riskTypeId}") ?? throw new Exception("GetDriverTypeRisk returned null 2");
        }

        public List<Entity.Driver> GetDrivers()
        {
            return ((JArray?)GetDriverTypeRisk()["risks"] ?? throw new NullReferenceException()).Select(risk => risk).ToList<dynamic>().Select(risk => new Entity.Driver(risk.risk.id.ToObject<int>())).ToList<Entity.Driver>();
        }

        public dynamic GetSectionQuestions(string sectionName)
        {
            var sectionId = this.Storyboard.GetSection(sectionName).Id;
            return RestAPI.GET($"/quote/{this.Id}/sections/{sectionId}/questions")?["questionDefinitions"] ?? throw new Exception("GetSectionQuestions returned null");
        }

        public dynamic GetCoverageQuestions(string coverageTypeName)
        {
            var limits = (JArray?)RestAPI.GET($"/quote/{this.Id}/policy/limits");
            limits.NullGuard(nameof(limits));
            var limit = limits.First(it => it["coverageTypeName"]?.ToString() == coverageTypeName);
            return limit?["configuration"]?["questions"] ?? throw new KeyNotFoundException("limit.configuration.questions");
        }

        public dynamic? GetQuestionResponse(string alias)
        {
            foreach (JObject response in this.GetProperty("QuestionResponses"))
            {
                if (response?["QuestionAlias"]?.ToString() == alias)
                {
                    return response["Response"]?.ToObject<dynamic>();
                }
            }
            return null;
        }
        [NotMapped]
        public JObject? SummaryResponse = null;

        public JObject PostSummary()
        {
            SummaryResponse = RestAPI.POST($"quote/{this.Id}/summary", "");
            try
            {
                this.Tether.waitForTetherStatus("PRESUBMISSION", true);
            }
            catch (Exception)
            {
                Log.Error(SummaryResponse);
                throw;
            }
            return SummaryResponse ?? throw new Exception("PostSummary returned null");
        }

        public JObject GetSummary()
        {
            var response = RestAPI.GET($"quote/{this.Id}/summary");
            return response ?? throw new Exception("PostSummary returned null");
        }

        [Obsolete("Please use PrimaryAddress instead")]
        public Location.Address PhysicalAddress => PrimaryAddress;

        public Location.Address PrimaryAddress
        {
            get
            {

                if (this.AddressIds.Count == 1)
                {
                    return this.ContextSQL.Address.First(it => it.Id == this.AddressIds[0]);
                }
                else
                {
                    throw new NotImplementedException($"Need to implement handle for multiple addresses current count: {this.AddressIds.Count}");
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
                return PrimaryAddress.StateCode ?? throw new NullReferenceException();
            }
        }

        public string GoverningStateName
        {
            get
            {
                return PrimaryAddress.StateName;
            }
        }


        public Entity.Question.Storyboard Storyboard
        {
            get
            {
                //Log.Debug($"Get Storyboard for Quote ID: {this.Id}");
                return new Entity.Question.Storyboard(this.GetProperty("StoryboardId").ToObject<int>());
            }
        }

        public Policy RatableObject => Tether.CurrentPolicy ?? throw new NullReferenceException("RatableObject returned null");

        public string CoveredAutos
        {
            get
            {
                return this.RatableObject.CoveredAutos;
            }
        }

        public String? MotorCarrierFiling
        {
            get
            {
                return this.RatableObject.MotorCarrierFiling;
            }
        }

        public Boolean? AccidentPreventionCredit
        {
            get
            {
                return this.RatableObject.AccidentPreventionCredit;
            }
        }

        public String BillingType
        {
            get
            {
                return this.RatableObject.BillingType;
            }
        }

        public int RatingPackageId
        {
            get
            {
                return this.RatableObject.RatingPackageID;
            }
        }

        public String PaymentPlan
        {
            get
            {
                return this.RatableObject.PaymentPlan;
            }
        }

        public String isEft
        {
            get
            {
                return this.RatableObject.isEft;
            }
        }

        public int? RadiusOfOperation
        {
            get
            {
                return this.RatableObject.RadiusOfOperation;
            }
        }
        [NotMapped]
        private dynamic? _CAB;

        public dynamic? GetCAB(bool Refresh)
        {
            _CAB = null;
            return GetCAB();
        }

        public dynamic? GetCAB()
        {
            if (_CAB == null)
            {
                string baseURL = Main.Configuration.GetVariable("CAB_BASEURL_SECRETNAME");
                string APIKEY = Main.Configuration.GetVariable("CAB_API_KEY_SECRETNAME");

                var usDot = GetQuestionResponse("USDOT#");
                if (usDot == null)
                {
                    return null;
                }
                var response = RestAPI.GET($"{baseURL}/rest/services/biberk/carrier/checkDOT/{usDot}?key={APIKEY}");
                if (!(bool?)response?.found ?? throw new NullReferenceException())
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
                var basicWeights = ((JArray?)GetCAB()?.BASICWeights);

                if (basicWeights == null)
                {
                    return 0;
                }
                var weights = basicWeights.Select(it => (decimal)(it["baseWeight"] ?? throw new Exception("baseWeight returned null"))).ToList();

                return (int)Math.Floor(weights.Sum());
            }
        }
        [NotMapped]
        public JObject ScheduleModifiers => (JObject?)GetAPIObj()?["scheduleModifiers"] ?? throw new Exception("scheduleModifiers returned null");

        private decimal getScheduleModifier(string modifierName)
        {
            var obj = ScheduleModifiers[modifierName];
            obj.NullGuard();
            decimal percentage = obj["adjustmentPercentage"]?.ToObject<decimal?>() ?? 0;
            foreach (JObject action in obj["actionResults"] ?? throw new NullReferenceException($"scheduleModifier.{modifierName}.actionResults returned null"))
            {
                percentage += action["percentage"]?.ToObject<decimal>() ?? throw new NullReferenceException($"scheduleModifier.{modifierName}.percentage returned null");
            }
            return percentage;
        }

        public long SAFETYORGANIZATION_Id => ScheduleModifiers[nameof(SAFETYORGANIZATION)]?["id"]?.ToObject<long>() ?? throw new NullReferenceException(nameof(SAFETYORGANIZATION));

        public decimal SAFETYORGANIZATION
        {
            get
            {
                return getScheduleModifier(nameof(SAFETYORGANIZATION));
            }
        }

        public long CLASSIFICATION_Id => ScheduleModifiers[nameof(CLASSIFICATION)]?["id"]?.ToObject<long>() ?? throw new NullReferenceException(nameof(CLASSIFICATION));

        public decimal CLASSIFICATION
        {
            get
            {
                return getScheduleModifier(nameof(CLASSIFICATION));
            }
        }

        public long MANAGEMENT_Id => ScheduleModifiers[nameof(MANAGEMENT)]?["id"]?.ToObject<long>() ?? throw new NullReferenceException(nameof(MANAGEMENT));

        public decimal MANAGEMENT
        {
            get
            {
                return getScheduleModifier(nameof(MANAGEMENT));
            }
        }

        public long EMPLOYEES_Id => ScheduleModifiers[nameof(EMPLOYEES)]?["id"]?.ToObject<long>() ?? throw new NullReferenceException(nameof(EMPLOYEES));

        public decimal EMPLOYEES
        {
            get
            {
                return getScheduleModifier(nameof(EMPLOYEES));
            }
        }

        public long EQUIPMENT_Id => ScheduleModifiers[nameof(EQUIPMENT)]?["id"]?.ToObject<long>() ?? throw new NullReferenceException(nameof(EQUIPMENT));

        public decimal EQUIPMENT
        {
            get
            {
                return getScheduleModifier(nameof(EQUIPMENT));
            }
        }

        public long GetModifierId(string modifierName)
        {
            if (modifierName == "EXPERIENCE")
            {
                return GetExperienceModifierObj().Value<long>("id");
            }
            else
            {
                return ScheduleModifiers.Value<JToken>(modifierName)?.Value<long>("id") ?? throw new NullReferenceException(modifierName);
            }
        }

        public long TOTAL_Id => (ScheduleModifiers["TOTAL"]?["id"] ?? throw new Exception("TOTAL_Id returned null")).ToObject<long>();

        public JObject GetExperienceModifierObj() => (JObject?)GetAPIObj()?["experienceModifier"] ?? throw new Exception("GetExperienceModifierObj returned null");

        public long EXPERIENCE_Id => (GetExperienceModifierObj()["id"] ?? throw new Exception("EXPERIENCE_Id returned null")).ToObject<long>();

        public decimal ExperienceModifier
        {
            get
            {
                decimal percentage = GetExperienceModifierObj()["adjustmentPercentage"]?.ToObject<decimal?>() ?? 0;
                foreach (JObject action in GetExperienceModifierObj()?["actionResults"] ?? throw new Exception("actionResults returned null"))
                {
                    percentage += action["percentage"]?.ToObject<decimal?>() ?? throw new Exception("percentage was null");
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
