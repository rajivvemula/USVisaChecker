using ApolloTests.Data.EntityBuilder;
using ApolloTests.Data.EntityBuilder.Entities;
using ApolloTests.Data.EntityBuilder.QuestionAnswers;
using ApolloTests.Data.Entities.Context;
using ApolloTests.Data.Entities.Coverage;
using HitachiQA.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApolloTests.Data.Entities.Risk
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public abstract class RiskBase : BaseEntityEF
    {

        public RiskBase(CosmosContext ctx) : base(ctx) { }
        public RiskBase()
        {
            QuestionAnswers = new();
        }

        [NotMapped]
        [JsonProperty("outputMetadata")]
        public abstract IOutputMetadata OutputMetadata { get; set; }

        [JsonProperty("tetherId")]
        [HydratorAttr("Quote.Tether.Id")]
        public int? TetherId { get; set; }

        [JsonIgnore]
        [NotMapped]
        public RiskAnswers? QuestionAnswers { get; set; }

        [JsonIgnore]
        [NotMapped]
        public List<Limit> RiskLimits { get; set; } = new List<Limit>();

        [JsonIgnore]
        [NotMapped]
        public BaseEntityEF? SectionEntity
        {
            get {

                return (RiskTypeEnum)RiskTypeId switch
                {
                    RiskTypeEnum.Vehicle => Vehicle,
                    RiskTypeEnum.Driver => Driver,
                    RiskTypeEnum.Location => Location,
                    RiskTypeEnum.Building => Building,
                    _ => throw new NotImplementedException(),
                };
            }
            set
            {
                switch ((RiskTypeEnum)RiskTypeId)
                {
                    case RiskTypeEnum.Vehicle:
                        Vehicle = (Vehicle)value;
                        break;
                    case RiskTypeEnum.Driver:
                        Driver = (Driver)value;
                        break;
                    case RiskTypeEnum.Location:
                        Location = (Location)value;
                        break;
                    case RiskTypeEnum.Building:
                        Building = (Building)value;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        [Key]
        [JsonProperty("id")]
        public new long Id { get; set; }


        [JsonIgnore]
        public string? id { get; set; }

        [JsonIgnore]
        public string? Discriminator { get; set; }

        [JsonProperty("building")]
        public virtual Building? Building { get; set; }

        [JsonProperty("location")]
        public virtual Location? Location { get; set; }

        [JsonProperty("vehicle")]
        public virtual Vehicle? Vehicle { get; set; }

        [JsonProperty("driver")]
        public virtual Driver? Driver { get; set; }

        [JsonProperty("classCode")]
        [HydratorAttr("ClassCode")]
        public string? ClassCode { get; set; }

        [JsonProperty("entityId")]
        public int? EntityId { get; set; }

        [JsonProperty("entityTypeId")]
        public int? EntityTypeId { get; set; }

        [JsonProperty("logicId")]
        public string? LogicId { get; set; }

        [JsonProperty("riskTypeId")]
        public int RiskTypeId { get; set; }

        [JsonProperty("sequenceNumber")]
        public int? SequenceNumber { get; set; }

        [JsonProperty("timeFrom")]
        public DateTimeOffset? TimeFrom { get; set; }

        [JsonProperty("timeTo")]
        public DateTimeOffset? TimeTo { get; set; }

 

        [JsonIgnore]
        public Metadata? Metadata { get; set; }

        //needs implementation
        //[JsonProperty("QuestionGroupResponses")]
        //public List<QuestionGroup> QuestionGroupResponses { get; set; }

        [JsonProperty("QuestionResponses")]
        public List<QuestionResponse> QuestionResponses { get; set; }

        [JsonIgnore]
        public int _ts { get; set; }

        public void LoadEntityObject(JObject riskEntityObject)
        {
            SectionEntity = RiskTypeId switch
            {
                (int)RiskTypeEnum.Vehicle => riskEntityObject.ToObject<Vehicle>() ?? throw new NullReferenceException(),
                (int)RiskTypeEnum.Driver => riskEntityObject.ToObject<Driver>() ?? throw new NullReferenceException(),
                (int)RiskTypeEnum.Building => riskEntityObject.ToObject<Building>() ?? throw new NullReferenceException(),
                (int)RiskTypeEnum.Location => riskEntityObject.ToObject<Location>() ?? throw new NullReferenceException(),
                _ => throw new ArgumentException($"Invalid risk type ID: {RiskTypeId}"),
            };
        }
    }
    public class Metadata
    {
        [JsonProperty("userBuildingGroupId")]
        public int? UserBuildingGroupId { get; set; }

        [JsonProperty("userBuildingOccupancyId")]
        public int? UserBuildingOccupancyId { get; set; }

        [JsonProperty("userClassCode")]
        public string? UserClassCode { get; set; }

        [JsonProperty("uwBuildingGroupIdOverride")]
        public bool? UwBuildingGroupIdOverride { get; set; }

        [JsonProperty("uwBuildingOccupancyIdOverride")]
        public bool? UwBuildingOccupancyIdOverride { get; set; }

        [JsonProperty("uwClassCodeOverride")]
        public bool? UwClassCodeOverride { get; set; }
    }
}

