using ApolloTests.Data.EntityBuilder;
using ApolloTests.Data.Entities.Context;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApolloTests.Data.Entities.Risk
{
    public class Vehicle : BaseEntityEF
    {
        public Vehicle(CosmosContext ctx) : base(ctx) { }

        public Vehicle()
        {

        }

        [JsonProperty("id")]
        public new string Id { get; set; }

        [JsonProperty("antitheft")]
        public bool? Antitheft { get; set; }

        [JsonProperty("bodyCategoryTypeId")]
        public int BodyCategoryTypeId { get; set; }

        [JsonProperty("bodySubCategoryTypeId")]
        public int BodySubCategoryTypeId { get; set; }

        [JsonIgnore]
        public int? BusinessUseId { get; set; }

        [JsonIgnore]
        public int? CalculatedValue { get; set; }

        [JsonProperty("calculatedValue")]
        [NotMapped]
        public string? CalculatedValueStr
        {
            get => CalculatedValue.ToString();
            set => CalculatedValue = value == null ? null : int.Parse(value);
        }
        [JsonProperty("underwriterValue")]
        [NotMapped]
        public string? UnderwriterValue { get; set; }

        [JsonIgnore]
        public int? CostNew { get; set; }

        [JsonProperty("costNew")]
        [NotMapped]
        public string? CostNewStr {
            get => CostNew.ToString();
            set => CostNew = value == null ? null : int.Parse(value);
        }

        [JsonProperty("estimatedCurrentValue")]
        public int? EstimatedCurrentValue { get; set; }

        [JsonProperty("grossVehicleWeight")]
        public string GrossVehicleWeight { get; set; }

        [JsonProperty("inspectionCount")]
        public int? InspectionCount { get; set; }

        [JsonProperty("isVinDataVariance")]
        public bool? IsVinDataVariance { get; set; }

        [JsonProperty("isVinTelligence")]
        public bool IsVinTelligence { get; set; }

        [JsonProperty("make")]
        public string Make { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonIgnore]
        public string? Notes { get; set; }

        [JsonProperty("outOfServiceViolationRatio")]
        public decimal? OutOfServiceViolationRatio { get; set; }

        [JsonProperty("riskId")]
        public long RiskId { get; set; }

        [JsonProperty("safetyFeatures")]
        public bool? SafetyFeatures { get; set; }

        [JsonProperty("seatingCapacity")]
        public string? SeatingCapacity { get; set; }

        [JsonIgnore]
        public int? StatedAmount { get; set; }

        [JsonProperty("statedAmount")]
        [NotMapped]
        public string? StatedAmountStr
        {
            get => StatedAmount == null ? "" : StatedAmount.ToString();
            set => StatedAmount = string.IsNullOrWhiteSpace(value) ? null : int.Parse(value);
        }

        [JsonProperty("totalBASICViolationWeight")]
        public int? TotalBASICViolationWeight { get; set; }

        [JsonProperty("trim")]
        public string? Trim { get; set; }

        [JsonProperty("typeId")]
        public int? TypeId { get; set; }

        [JsonIgnore]
        [NotMapped]
        public VehicleTypeEnum? Type => (VehicleTypeEnum)TypeId;

        [JsonIgnore]
        [NotMapped]
        public string? TypeName { get
            {
                if (Type == null) return null;

                return Type switch
                {
                    VehicleTypeEnum.Car => "Car",
                    VehicleTypeEnum.Van => "Van",
                    VehicleTypeEnum.WorkTruck => "Work Truck",
                    VehicleTypeEnum.PPT => "PPT",
                    VehicleTypeEnum.AllOther => "All Other",
                    VehicleTypeEnum.Publics => "Publics",
                    VehicleTypeEnum.Tractor => "Tractor",
                    VehicleTypeEnum.Special => "Special",
                    VehicleTypeEnum.Trailer => "Trailer",
                    VehicleTypeEnum.SemiTrailer => "Semi-Trailer",
                    _ => throw new NotImplementedException(Type.ToString()),
                };
            } 
        }

        [JsonProperty("useStatedAmount")]
        public bool UseStatedAmount { get; set; }

        [JsonProperty("vinNumber")]
        [HydratorAttr("VinNumber")]
        public string VinNumber { get; set; }

        [JsonProperty("vinRateRank")]
        public int? VinRateRank { get; set; }

        [JsonProperty("VinReturnCode")]
        public string? VinReturnCode { get; set; }

        [JsonProperty("yearOfManufacture")]
        public int YearOfManufacture { get; set; }

        [JsonIgnore]
        public VehicleDriverLocation VehicleDriverLocation { get; set; }

        public bool IsNonPowered()
        {
            return new List<int> { (int)VehicleTypeEnum.Trailer, (int)VehicleTypeEnum.SemiTrailer }.Contains(this.TypeId??0);
        }
        public override string ToString() => $"{YearOfManufacture} {Make}{(String.IsNullOrEmpty(Model) ? "" : $" {Model}")}";
        
    }

    public class VehicleDriverLocation
    {
        public int? DriverId { get; set; }

        public int? GaragingLocation { get; set; }

        public long? LocationId { get; set; }

        public int? OperationRadius { get; set; }
    }


}
