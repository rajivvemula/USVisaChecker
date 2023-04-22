using System.ComponentModel.DataAnnotations;
using ApolloTests.Data.Entities.Context;
using HitachiQA.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using ApolloTests.Data.EntityBuilder;
using ApolloTests.Data.EntityBuilder.Entities;
using ApolloTests.Data.Entities.Risk;
using ApolloTests.Data.Entities.Coverage;

namespace ApolloTests.Data.Entities
{

    public class Quote : BaseEntityEF
    {

        public Quote(CosmosContext context) : base(context)
        {

        }
        public Quote()
        {
            LineId = 0;
            SubLineId = 0;
            TermId = 1;
            AgencyId = 2;
            CarrierId = 3;
            ProducerId = 5;
            ClientOffset = -8;
            Addresses = new List<JObject>();
            AddressIds = new List<long>();
            IndustryClassTaxonomyId = 0;
            QuestionResponses = new List<QuestionResponse>();
            BusinessInformation = new BusinessInformation();
            DecidedValueFactor = new DecidedValueFactor();
        }
        [Key]
        [JsonIgnore]
        public string id { get; set; }

        [Required]
        [JsonIgnore]
        public string Discriminator { get; set; }

        [JsonIgnore]
        public long _ts { get; set; }

        [JsonProperty("id")]
        public new long? Id { get; set; }

        [JsonProperty("lineId")]
        [HydratorAttr("LineId")]
        public long LineId { get; set; }

        [JsonProperty("lineName")]
        [NotMapped]
        public object LineName { get; set; }

        [JsonProperty("line")]
        [NotMapped]
        public object Line { get; set; }

        [JsonProperty("storyboardId")]
        public long? StoryboardId { get; set; }

        [JsonProperty("subLine")]
        [NotMapped]
        public object SubLine { get; set; }

        [JsonProperty("subLineId")]
        [HydratorAttr("SubLineId")]
        public long SubLineId { get; set; }

        [JsonProperty("applicationNumber")]
        public string ApplicationNumber { get; set; }

        [JsonProperty("termId")]
        public long TermId { get; set; }

        [JsonProperty("applicationStatusValue")]
        public string ApplicationStatusValue { get; set; }

        [NotMapped]
        [JsonProperty("applicationStatus")]
        public object ApplicationStatus { get; set; }

        [JsonIgnore]
        [ListenForChanges]
        public virtual long? ApplicationStatusKey { get; set; }

        [NotMapped]
        [JsonProperty("agency")]
        public object Agency { get; set; }

        [JsonProperty("agencyId")]
        public long AgencyId { get; set; }

        [JsonProperty("carrierId")]
        public long CarrierId { get; set; }

        [JsonProperty("producerId")]
        public long? ProducerId { get; set; }

        [JsonProperty("tetherId")]
        public long? TetherId { get; set; }

        [NotMapped]
        [JsonProperty("isEndorsement")]
        public object IsEndorsement { get; set; }

        [NotMapped]
        [JsonProperty("isDraft")]
        public object IsDraft { get; set; }

        [NotMapped]
        [JsonProperty("isDraftEndorsement")]
        public object IsDraftEndorsement { get; set; }

        [NotMapped]
        [JsonProperty("isDraftRenewal")]
        public object IsDraftRenewal { get; set; }

        [NotMapped]
        [JsonProperty("isIssued")]
        public object IsIssued { get; set; }

        [JsonProperty("ratableObjectEffectiveDate")]
        [HydratorAttr("EffectiveDate")]
        public DateTimeOffset RatableObjectEffectiveDate { get; set; }

        [JsonProperty("ratableObjectExpirationDate")]
        [HydratorAttr("ExpirationDate")]
        public DateTimeOffset RatableObjectExpirationDate { get; set; }

        [JsonProperty("clientOffset")]
        public long ClientOffset { get; set; }

        [JsonProperty("lastSectionId")]
        public long? LastSectionId { get; set; }

        [JsonProperty("addresses")]
        [HydratorAttr(new[] { "AddressObject" })]
        [NotMapped]
        public List<JObject> Addresses { get; set; }

        [JsonProperty("addressIds")]
        public List<long> AddressIds { get; set; }

        [JsonProperty("governingStateId")]
        public long? GoverningStateId { get; set; }

        [JsonProperty("keywordId")]
        [HydratorAttr("KeywordId")]
        public string KeywordId { get; set; }

        [NotMapped]
        [JsonProperty("keyword")]
        public object Keyword { get; set; }

        [JsonProperty("industryClassTaxonomyId")]
        [HydratorAttr("IndustryClassTaxonomyId")]
        public long? IndustryClassTaxonomyId { get; set; }


        [JsonProperty("industryClassTaxonomyClassName")]
        [HydratorAttr("IndustryClassTaxonomyClassName")]
        public string IndustryClassTaxonomyClassName { get; set; }

        public bool ShouldSerializeIndustryClassTaxonomyId() => LineId == 7;
        public bool ShouldSerializeIndustryClassTaxonomyClassName() => LineId == 7;

        [JsonProperty("industryTypeId")]
        public long? IndustryTypeId { get; set; }

        [JsonProperty("industryTypeName")]
        public string IndustryTypeName { get; set; }

        [JsonProperty("industryTypeCode")]
        public string IndustryTypeCode { get; set; }

        [JsonProperty("subIndustryTypeId")]
        public long? SubIndustryTypeId { get; set; }

        [JsonProperty("subIndustryTypeName")]
        public string SubIndustryTypeName { get; set; }

        [JsonProperty("subIndustryTypeCode")]
        public string SubIndustryTypeCode { get; set; }

        [JsonProperty("questionResponses")]
        public List<EntityBuilder.Entities.QuestionResponse> QuestionResponses { get; set; }

        public bool ShouldSerializeQuestionResponses() => false;

        [JsonProperty("businessInformation")]
        public BusinessInformation BusinessInformation { get; set; }

        [JsonProperty("decidedValueFactor")]
        [NotMapped]
        public DecidedValueFactor DecidedValueFactor { get; set; }

        public JObject GetAPIObj()
        {
            return RestAPI.GET($"/quote/{this.Id}") ?? throw new Exception("GetAPIObj returned null");
        }


        [JsonIgnore]
        [NotMapped]
        public Tether.Tether Tether => ContextSQL.Tether.First(tether => tether.Id == TetherId);

        public static Quote GetLatestQuote(CosmosContext context)
        {
            return context.Quotes.OrderByDescending(it => it._ts).First(quote => !new[] { "Issued", "Expired", "Canceled" }.Contains(quote.ApplicationStatusValue));
        }

        public static Quote GetLatestIssuedQuote(SQLContext context)
        {
            return context.Tether.OrderByDescending(it => it.Id).Last(it => it.TetherStatusCode == "ISSUED").CurrentQuote;
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
                { "entityId", Tether.Id },
                { "entityTypeId", 15000},
                { "tetherId", Tether.Id },
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
                Tether.waitForTetherStatus("ISSUED");
            }
            catch (Exception)
            {
                Log.Error("Summary Response:");
                Log.Error(SummaryResponse);
                throw;
            }
            ContextSQL.Entry(Tether).Reload();
            var policy = Tether.CurrentPolicy ?? throw new Exception("PurchaseThis returned null");
            Log.Debug($"Purchased PolicyId: {policy.Id}");
            return policy;
        }



        public JObject ReferToUnderwriting()
        {
            var response = RestAPI.POST($"/quote/{Id}/referToUnderwriting", "\"Testing\"");

            Tether.waitForTetherStatus("REFERRED");

            return response ?? throw new Exception("ReferToUnderwriting returned null");
        }

        public JObject GenerateProposal()
        {
            var response = RestAPI.POST($"/quote/{Id}/proposal", null);
            Tether.waitForTetherStatus("QUOTED");

            return response ?? throw new Exception("GenerateProposal returned null");
        }

        public dynamic CreateEndorsementHeader(long policyId)
        {
            var endorseObject = new
            {
                number = "001",
                label = "Endorsement Label",
                effectiveDate = Tether.EffectiveDate.AddDays(2).ToString("O"),
                reasonForChangeId = ReasonForChangeEndorsement.AgencyInitiated,
                uwReasonsForChange = ""
            };

            var response = RestAPI.PUT($"/policy/{policyId}/endorsement/{Id}", JObject.FromObject(endorseObject));
            return response ?? throw new Exception("CreateEndorsementHeader returned null");

        }

        public List<Limit> SelectedCoverages { get; set; }

        public IEnumerable<Coverage.CoverageType> getCoverageTypes(Vehicle risk)
        {
            foreach (var limit in SelectedCoverages)
            {
                var coverageType = limit.GetCoverageType();

                if (coverageType.isVehicleLevel)
                {
                    foreach (var riskEntry in limit?.RiskCoverages ?? throw new Exception("RiskCoverages returned null"))
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

        public List<Limit> getLimits()
        {
            return this.SelectedCoverages;
        }

        public IEnumerable<Limit> getLimits(Vehicle risk)
        {

            foreach (var limit in SelectedCoverages)
            {
                var coverageType = limit.GetCoverageType();

                if (coverageType.isVehicleLevel)
                {
                    foreach (var riskEntry in limit.RiskCoverages ?? throw new Exception("Limit.riskcoverages returned null"))
                    {
                        if (riskEntry.RiskId == risk.RiskId)
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

            return RestAPI.GET($"/quote/{this.Id}/risktype/{riskTypeId}") ?? throw new Exception("GetVehicleTypeRisk returned null 2");
        }

        public List<VehicleRisk> GetVehicles()
        {
            return ((JArray?)GetVehicleTypeRisk()["risks"] ?? throw new NullReferenceException()).Select(risk => risk.ToObject<VehicleRisk>()).ToList();
        }

        public JObject GetDriverTypeRisk()
        {
            int riskTypeId = 2;
            return RestAPI.GET($"/quote/{this.Id}/risktype/{riskTypeId}") ?? throw new Exception("GetDriverTypeRisk returned null 2");
        }

        public List<Risk.DriverRisk> GetDrivers()
        {

            return ((JArray?)GetDriverTypeRisk()["risks"] ?? throw new NullReferenceException()).Select(risk => risk.ToObject<Risk.DriverRisk>()).ToList();
        }

        public dynamic GetSectionQuestions(string sectionName)
        {
            var sectionId = this.Storyboard.GetSection(sectionName).Id;
            return RestAPI.GET($"/quote/{this.Id}/sections/{sectionId}/questions")?["questionDefinitions"] ?? throw new Exception("GetSectionQuestions returned null");
        }

        public dynamic GetCoverageQuestions(string coverageTypeName)
        {
            try
            {
                var limits = (JArray?)RestAPI.GET($"/quote/{this.Id}/policy/limits");
                limits.NullGuard(nameof(limits));
                var limit = limits.First(it => it["coverageTypeName"]?.ToString() == coverageTypeName);
                return limit?["configuration"]?["questions"] ?? throw new KeyNotFoundException("limit.configuration.questions");
            }
            catch(Exception ex)
            {
                throw new Exception($"error finding coverage quesitons for {coverageTypeName} " +
                    $"\nfrom URI: /quote/{this.Id}/policy/limits" +
                    $"Might be that this coverage hasn't been implemented for state: {GoverningStateName}", ex);
            }
            
        }

        public dynamic? GetQuestionResponse(string alias)
        {
            foreach (QuestionResponse res in this.QuestionResponses)
            {
                if (res.Alias == alias)
                {
                    return res.Response.ToObject<dynamic>();
                }
            }
            return null;
        }
        [JsonIgnore]
        [NotMapped]
        private JObject? SummaryResponse = null;

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

        [JsonIgnore]
        [Obsolete("Please use PrimaryAddress instead")]
        public Location.Address PhysicalAddress => PrimaryAddress;

        [JsonIgnore]
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

        [JsonIgnore]
        public string GoverningStateCode
        {
            get
            {
                return PrimaryAddress.StateCode ?? throw new NullReferenceException();
            }
        }

        [JsonIgnore]
        public string GoverningStateName
        {
            get
            {
                return PrimaryAddress.StateName;
            }
        }

        [JsonIgnore]
        [NotMapped]
        public Quesiton.Storyboard Storyboard => this.ContextSQL.Storyboard.First(it => it.Id == this.StoryboardId);

        [JsonIgnore]
        [NotMapped]
        public Policy RatableObject => ContextCosmos.Policies.OrderByDescending(it => it._ts).First(it => it.ApplicationId == Id);


        [JsonIgnore]
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

        [JsonIgnore]
        public int InspectionCount
        {
            get
            {
                return GetCAB()?.events?.inspections?.insp?.tot ?? 0;
            }
        }

        [JsonIgnore]
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

        [JsonIgnore]
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
        [JsonIgnore]
        public dynamic ScheduleModifiers => (JObject?)GetAPIObj()?["scheduleModifiers"] ?? throw new Exception("scheduleModifiers returned null");

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

        [JsonIgnore]
        public long SAFETYORGANIZATION_Id => ScheduleModifiers[nameof(SAFETYORGANIZATION)]?["id"]?.ToObject<long>() ?? throw new NullReferenceException(nameof(SAFETYORGANIZATION));

        [JsonIgnore]
        public decimal SAFETYORGANIZATION
        {
            get
            {
                return getScheduleModifier(nameof(SAFETYORGANIZATION));
            }
        }

        [JsonIgnore]
        public long CLASSIFICATION_Id => ScheduleModifiers[nameof(CLASSIFICATION)]?["id"]?.ToObject<long>() ?? throw new NullReferenceException(nameof(CLASSIFICATION));

        [JsonIgnore]
        public decimal CLASSIFICATION
        {
            get
            {
                return getScheduleModifier(nameof(CLASSIFICATION));
            }
        }

        [JsonIgnore]
        public long MANAGEMENT_Id => ScheduleModifiers[nameof(MANAGEMENT)]?["id"]?.ToObject<long>() ?? throw new NullReferenceException(nameof(MANAGEMENT));

        [JsonIgnore]
        public decimal MANAGEMENT
        {
            get
            {
                return getScheduleModifier(nameof(MANAGEMENT));
            }
        }

        [JsonIgnore]
        public long EMPLOYEES_Id => ScheduleModifiers[nameof(EMPLOYEES)]?["id"]?.ToObject<long>() ?? throw new NullReferenceException(nameof(EMPLOYEES));

        [JsonIgnore]
        public decimal EMPLOYEES
        {
            get
            {
                return getScheduleModifier(nameof(EMPLOYEES));
            }
        }

        [JsonIgnore]
        public long EQUIPMENT_Id => ScheduleModifiers[nameof(EQUIPMENT)]?["id"]?.ToObject<long>() ?? throw new NullReferenceException(nameof(EQUIPMENT));

        [JsonIgnore]
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

        [JsonIgnore]
        public long TOTAL_Id => (ScheduleModifiers["TOTAL"]?["id"] ?? throw new Exception("TOTAL_Id returned null")).ToObject<long>();

        public JObject GetExperienceModifierObj() => (JObject?)GetAPIObj()?["experienceModifier"] ?? throw new Exception("GetExperienceModifierObj returned null");

        [JsonIgnore]
        public long EXPERIENCE_Id => (GetExperienceModifierObj()["id"] ?? throw new Exception("EXPERIENCE_Id returned null")).ToObject<long>();

        [JsonIgnore]
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

    public partial class BusinessInformation
    {
        public BusinessInformation(ApolloContext _)
        {

        }
        public BusinessInformation()
        {
            BusinessTypeEntityId = 1;
            YearBusinessStarted = "2021";
            YearOwnershipStarted = "2021";
            TaxTypeId = 0;
            TaxId = "34-5678974";
            BusinessPhoneNumber = "2017999999";
            BusinessWebsite = "biberk.com";
            BusinessEmail = "automation@biberk.com";
            UwOverride = false;
            Phones = new List<Phone>() { new Phone() };
            Sites = new List<Site>() { new Site() };
        }
        [JsonProperty("name")]
        [HydratorAttr("OrganizationName")]
        public string Name { get; set; }

        [JsonProperty("alternateName")]
        public string AlternateName { get; set; }

        [JsonProperty("partyId")]
        public long? PartyId { get; set; }

        [JsonProperty("organizationTypeId")]
        public long? OrganizationTypeId { get; set; }

        [JsonProperty("keywordId")]
        [HydratorAttr("KeywordId")]
        public long? KeywordId { get; set; }

        [JsonProperty("industryTypeId")]
        public long? IndustryTypeId { get; set; }

        [JsonProperty("subIndustryTypeId")]
        public long? SubIndustryTypeId { get; set; }

        [JsonProperty("industryClassTaxonomyId")]
        public long? IndustryClassTaxonomyId { get; set; }

        [JsonProperty("businessTypeEntityId")]
        public long? BusinessTypeEntityId { get; set; }

        [JsonProperty("businessSubTypeId")]
        public long? BusinessSubTypeId { get; set; }

        [JsonProperty("yearBusinessStarted")]
        public string YearBusinessStarted { get; set; }

        [JsonProperty("yearOwnershipStarted")]
        public string YearOwnershipStarted { get; set; }

        [JsonProperty("taxTypeId")]
        public long? TaxTypeId { get; set; }

        [JsonProperty("taxId")]
        public string TaxId { get; set; }

        [JsonProperty("dba")]
        public string DBA { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("businessPhoneNumber")]
        public string BusinessPhoneNumber { get; set; }

        [NotMapped]
        [JsonProperty("businessPhoneExt")]
        public object BusinessPhoneExt { get; set; }

        [JsonProperty("businessWebsite")]
        public string BusinessWebsite { get; set; }

        [JsonProperty("businessEmail")]
        public string BusinessEmail { get; set; }

        [JsonProperty("decidedValue")]
        public string DecidedValue { get; set; }

        [JsonProperty("industryTypeIdUserValue")]
        public long? IndustryTypeIdUserValue { get; set; }

        [JsonProperty("uwOverride")]
        public bool? UwOverride { get; set; }

        [JsonProperty("phones")]
        public List<Phone> Phones { get; set; }

        [JsonProperty("sites")]
        public List<Site> Sites { get; set; }
    }

    public partial class Phone
    {
        public Phone(ApolloContext _)
        {

        }
        public Phone()
        {
            Number = "2017900799";
            PhoneTypeId = 0;
        }
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("extension")]
        public string Extension { get; set; }

        [JsonProperty("phoneTypeId")]
        public long? PhoneTypeId { get; set; }
    }

    public partial class Site
    {
        public Site(ApolloContext _)
        {

        }
        public Site()
        {
            InternetTypeId = 2;
        }
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("internetTypeId")]
        public long? InternetTypeId { get; set; }
    }

    public partial class DecidedValueFactor
    {
        public DecidedValueFactor(ApolloContext _)
        {

        }
        public DecidedValueFactor()
        {
            UwOverride = false;
        }
        [JsonProperty("decidedValue")]
        public string DecidedValue { get; set; }

        [JsonProperty("inheritedValue")]
        public string InheritedValue { get; set; }

        [JsonProperty("derivedValue")]
        public string DerivedValue { get; set; }

        [JsonProperty("userValue")]
        public string UserValue { get; set; }

        [JsonProperty("uwOverride")]
        public bool? UwOverride { get; set; }
    }


}
