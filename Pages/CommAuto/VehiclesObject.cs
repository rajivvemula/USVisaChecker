using System;
using System.Collections.Generic;
using System.Text;

namespace BiBerkLOB.Pages.CommAuto
{
    public class VehiclesObject
    {
        public VehiclesObject() { }

        public string VehiclesHeader { get; set; } = "";
        public string VehicleYrMkMdl { get; set; } = "";
        public string VINQuestion { get; set; } = "";
        public string VIN { get; set; } = "";
        public string ParkingAddress { get; set; } = "";
        public int VehicleWorth { get; set; } = 0;
        public string GrossWeight { get; set; } = "";
        public string EscortTrucks { get; set; } = "";
        public string Haul { get; set; } = "";
        public string ForHire { get; set; } = "";
        public string DeliverGoods { get; set; } = "";
        public string FoodTruck {get; set; } = "";
        public string HowUsed {get; set; } = "";
        public string AutoRepo {get; set; } = "";
        public string FareBox {get; set; } = "";
        public string Seatbelt {get; set; } = "";
        public string Commuter {get; set; } = "";
        public string PassengersSeat {get; set; } = "";
        public string Routes {get; set; } = "";
        public string ClientLocation { get; set; } = "";
        public string Outpatient { get; set; } = "";
        public string Camps { get; set; } = "";
        public string AirportShuttle { get; set; } = "";
        public string Tours { get; set; } = "";
        public int TrailerWorth { get; set; } = 0;
        public string TrailerAddress { get; set; } = "";
        public string NoVIN { get; set; } = "";
        public string TypeInsure { get; set; } = "";
        public string Year { get; set; } = "";
        public string Make { get; set; } = "";
        public string Model { get; set; } = "";
        //ex: "$500 Comprehensive Deductible / $500 Collision Deductible"
        public string CoverageDetails { get; set; } = "";
        public string PlowingSnow { get; set; } = "";

        public bool IsTrailer => TrailerWorth != 0 || !string.IsNullOrEmpty(TrailerAddress);
    }
}
