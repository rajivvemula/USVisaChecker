using System;
using System.Collections.Generic;

using System.Globalization;
using ApolloTests.Data.Entity;
using ApolloTests.Data.EntityBuilder.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace ApolloTests.Data.EntityBuilder.Models
{

    public class QuoteCreate
    {
        [JsonProperty("id")]
        public object? Id { get; set; } = null;

        [JsonProperty("lineId")]
        [HydratorAttr("LineId")]
        public long LineId { get; set; }

        [JsonProperty("lineName")]
        public object? LineName { get; set; }

        [JsonProperty("line")]
        public object? Line { get; set; }

        [JsonProperty("subLine")]
        public object? SubLine { get; set; }

        [JsonProperty("subLineId")]
        [HydratorAttr("SubLineId")]
        public long SubLineId { get; set; }

        [JsonProperty("applicationNumber")]
        public object? ApplicationNumber { get; set; }

        [JsonProperty("termId")]
        public long TermId { get; set; } = 1;

        [JsonProperty("applicationStatusValue")]
        public object? ApplicationStatusValue { get; set; }

        [JsonProperty("applicationStatus")]
        public object? ApplicationStatus { get; set; }

        [JsonProperty("agency")]
        public object? Agency { get; set; }

        [JsonProperty("agencyId")]
        public long AgencyId { get; set; } = 2;

        [JsonProperty("carrierId")]
        public long CarrierId { get; set; } = 3;

        [JsonProperty("producerId")]
        public long ProducerId { get; set; } = 5;

        [JsonProperty("tetherId")]
        public object? TetherId { get; set; }

        [JsonProperty("isEndorsement")]
        public object? IsEndorsement { get; set; }

        [JsonProperty("isDraft")]
        public object? IsDraft { get; set; }

        [JsonProperty("isDraftEndorsement")]
        public object? IsDraftEndorsement { get; set; }

        [JsonProperty("isDraftRenewal")]
        public object? IsDraftRenewal { get; set; }

        [JsonProperty("isIssued")]
        public object? IsIssued { get; set; }

        [JsonProperty("ratableObjectEffectiveDate")]
        [HydratorAttr("EffectiveDate")]
        public DateTimeOffset RatableObjectEffectiveDate { get; set; }

        [JsonProperty("ratableObjectExpirationDate")]
        [HydratorAttr("ExpirationDate")]
        public DateTimeOffset RatableObjectExpirationDate { get; set; }

        [JsonProperty("clientOffset")]
        public long ClientOffset { get; set; } = -8;

        [JsonProperty("lastSectionId")]
        public object? LastSectionId { get; set; }

        [JsonProperty("addresses")]
        [HydratorAttr(new[] { "AddressObject" })]
        public List<JObject> Addresses { get; set; } = new() {  };

        [JsonProperty("addressIds")]
        public List<object> AddressIds { get; set; } = new();

        [JsonProperty("governingStateId")]
        public object? GoverningStateId { get; set; }

        [JsonProperty("keywordId")]
        [HydratorAttr("KeywordId")]
        public string? KeywordId { get; set; }

        [JsonProperty("keyword")]
        public object? Keyword { get; set; }

        [JsonProperty("industryClassTaxonomyId")]
        [HydratorAttr("IndustryClassTaxonomyId")]

        public long IndustryClassTaxonomyId { get; set; }


        [JsonProperty("industryClassTaxonomyClassName")]
        [HydratorAttr("IndustryClassTaxonomyClassName")]
        public string? IndustryClassTaxonomyClassName { get; set; }

        public bool ShouldSerializeIndustryClassTaxonomyId() => this.LineId == 7;
        public bool ShouldSerializeIndustryClassTaxonomyClassName() => this.LineId == 7;

        [JsonProperty("industryTypeId")]
        public object? IndustryTypeId { get; set; }

        [JsonProperty("industryTypeName")]
        public object? IndustryTypeName { get; set; }

        [JsonProperty("industryTypeCode")]
        public object? IndustryTypeCode { get; set; }

        [JsonProperty("subIndustryTypeId")]
        public object? SubIndustryTypeId { get; set; }

        [JsonProperty("subIndustryTypeName")]
        public object? SubIndustryTypeName { get; set; }

        [JsonProperty("subIndustryTypeCode")]
        public object? SubIndustryTypeCode { get; set; }

        [JsonProperty("questionResponses")]
        public JArray QuestionResponses { get; set; } = new();

        [JsonProperty("businessInformation")]
        public BusinessInformation BusinessInformation { get; set; } = new BusinessInformation();

        [JsonProperty("decidedValueFactor")]
        public DecidedValueFactor DecidedValueFactor { get; set; } = new();
    }

    public partial class BusinessInformation
    {
        [JsonProperty("name")]
        [HydratorAttr("OrganizationName")]
        public string? Name { get; set; }

        [JsonProperty("alternateName")]
        public object? AlternateName { get; set; }

        [JsonProperty("partyId")]
        public object? PartyId { get; set; }

        [JsonProperty("organizationTypeId")]
        public object? OrganizationTypeId { get; set; }

        [JsonProperty("keywordId")]
        [HydratorAttr("KeywordId")]
        public string? KeywordId { get; set; }

        [JsonProperty("industryTypeId")]
        public object? IndustryTypeId { get; set; }

        [JsonProperty("subIndustryTypeId")]
        public object? SubIndustryTypeId { get; set; }

        [JsonProperty("industryClassTaxonomyId")]
        public object? IndustryClassTaxonomyId { get; set; }

        [JsonProperty("businessTypeEntityId")]
        public long BusinessTypeEntityId { get; set; } = 1;

        [JsonProperty("businessSubTypeId")]
        public object? BusinessSubTypeId { get; set; }

        [JsonProperty("yearBusinessStarted")]
        public string YearBusinessStarted { get; set; } = "2021";

        [JsonProperty("yearOwnershipStarted")]
        public string YearOwnershipStarted { get; set; } = "2021";

        [JsonProperty("taxTypeId")]
        public long TaxTypeId { get; set; } = 0;

        [JsonProperty("taxId")]
        public string TaxId { get; set; } = "34-5678974";

        [JsonProperty("dba")]
        public object? Dba { get; set; }

        [JsonProperty("description")]
        public object? Description { get; set; }

        [JsonProperty("businessPhoneNumber")]
        public string BusinessPhoneNumber { get; set; } = "2017999999";

        [JsonProperty("businessPhoneExt")]
        public object? BusinessPhoneExt { get; set; }

        [JsonProperty("businessWebsite")]
        public string BusinessWebsite { get; set; } = "biberk.com";

        [JsonProperty("businessEmail")]
        public string BusinessEmail { get; set; } = "automation@biberk.com";

        [JsonProperty("decidedValue")]
        public string? DecidedValue { get; set; }

        [JsonProperty("industryTypeIdUserValue")]
        public long? IndustryTypeIdUserValue { get; set; }

        [JsonProperty("uwOverride")]
        public bool UwOverride { get; set; } = false;

        [JsonProperty("phones")]
        public List<Phone> Phones { get; set; } = new List<Phone>() { new Phone() };

        [JsonProperty("sites")]
        public List<Site> Sites { get; set; } = new List<Site> { new Site() };
    }

    public partial class Phone
    {
        [JsonProperty("number")]
        public string Number { get; set; } = "2017999999";

        [JsonProperty("extension")]
        public object? Extension { get; set; }

        [JsonProperty("phoneTypeId")]
        public long PhoneTypeId { get; set; } = 0;
    }

    public partial class Site
    {
        [JsonProperty("address")]
        public object? Address { get; set; }

        [JsonProperty("internetTypeId")]
        public long InternetTypeId { get; set; } = 2;
    }

    public partial class DecidedValueFactor
    {
        [JsonProperty("decidedValue")]
        public object? DecidedValue { get; set; }

        [JsonProperty("inheritedValue")]
        public object? InheritedValue { get; set; }

        [JsonProperty("derivedValue")]
        public object? DerivedValue { get; set; }

        [JsonProperty("userValue")]
        public object? UserValue { get; set; }

        [JsonProperty("uwOverride")]
        public bool UwOverride { get; set; } = false;
    }

    
}
