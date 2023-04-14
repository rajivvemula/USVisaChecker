using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ApolloTests.Data.EntityBuilder.QuestionAnswers.QuestionAnswer;

namespace ApolloTests.Data.EntityBuilder.QuestionAnswers
{
    public class OperationsAnswers : AnswersBase
    {
        #region CA
        public QuestionAnswer VehicleRadius { get; set; } = new QuestionAnswer(Alias.VehicleRadius, "50");

        public QuestionAnswer FineArt { get; set; } = new QuestionAnswer(Alias.FineArt, "false");

        public QuestionAnswer Haul { get; set; } = new QuestionAnswer(Alias.Haul, "[\"General Freight\"]");

        public QuestionAnswer Chains { get; set; } = new QuestionAnswer(Alias.Chains, "false");

        public QuestionAnswer ResidentialMoving { get; set; } = new QuestionAnswer(Alias.ResidentialMoving, "false");

        public QuestionAnswer Biohazard { get; set; } = new QuestionAnswer(Alias.Biohazard, "false");

        public QuestionAnswer TeamDriving { get; set; } = new QuestionAnswer(Alias.TeamDriving, "false");

        public QuestionAnswer TravelToMexico { get; set; } = new QuestionAnswer(Alias.TravelToMexico, "false");

        public QuestionAnswer ClaimCount { get; set; } = new QuestionAnswer(Alias.ClaimCount, "0");

        public QuestionAnswer IL_Authority { get; set; } = new QuestionAnswer(Alias.IL_Authority, "false");

        public QuestionAnswer SC_Authority { get; set; } = new QuestionAnswer(Alias.SC_Authority, "false");

        public QuestionAnswer KS_Authority { get; set; } = new QuestionAnswer(Alias.KS_Authority, "false");

        public QuestionAnswer NE_Authority { get; set; } = new QuestionAnswer(Alias.NE_Authority, "false");

        public QuestionAnswer OK_Authority { get; set; } = new QuestionAnswer(Alias.OK_Authority, "false");

        public QuestionAnswer OR_Authority { get; set; } = new QuestionAnswer(Alias.OR_Authority, "false");

        public QuestionAnswer CT_Authority { get; set; } = new QuestionAnswer(Alias.CT_Authority, "false");

        public QuestionAnswer CO_Authority { get; set; } = new QuestionAnswer(Alias.CO_Authority, "false");

        public QuestionAnswer BorrowVehicles { get; set; } = new QuestionAnswer(Alias.BorrowVehicles, "false");

        public QuestionAnswer USDOT { get; set; } = new QuestionAnswer(Alias.USDOT, "false");

        public QuestionAnswer USDOTNumber { get; set; } = new QuestionAnswer(Alias.USDOTNumber, "545167");

        public QuestionAnswer UseOwnerOperators { get; set; } = new QuestionAnswer(Alias.UseOwnerOperators, "false");

        public QuestionAnswer OnCall { get; set; } = new QuestionAnswer(Alias.OnCall, "false");

        public QuestionAnswer PartyBus { get; set; } = new QuestionAnswer(Alias.PartyBus, "false");

        public QuestionAnswer DayCare { get; set; } = new QuestionAnswer(Alias.DayCare, "false");

        public QuestionAnswer VehicleSellOrLease { get; set; } = new QuestionAnswer(Alias.VehicleSellOrLease, "false");

        public QuestionAnswer Salvage { get; set; } = new QuestionAnswer(Alias.Salvage, "No we only provide towing or roadside assistance services");

        public QuestionAnswer ServiceAccess { get; set; } = new QuestionAnswer(Alias.ServiceAccess, "Both on demand and pre-arranged");

        public QuestionAnswer Ammonia { get; set; } = new QuestionAnswer(Alias.Ammonia, "false");

        public QuestionAnswer Poison { get; set; } = new QuestionAnswer(Alias.Poison, "false");

        public QuestionAnswer Radioactive { get; set; } = new QuestionAnswer(Alias.Radioactive, "false");

        public QuestionAnswer EmergencyResponse { get; set; } = new QuestionAnswer(Alias.EmergencyResponse, "false");

        public QuestionAnswer CaliOperatingAuth { get; set; } = new QuestionAnswer(Alias.CaliOperatingAuth, "false");

        public QuestionAnswer CaliCarrierNumber { get; set; } = new QuestionAnswer(Alias.CaliCarrierNumber, "765432");

        public QuestionAnswer PUC { get; set; } = new QuestionAnswer(Alias.PUC, "false");

        public QuestionAnswer NonOwnedGoods { get; set; } = new QuestionAnswer(Alias.NonOwnedGoods, "false");

        public QuestionAnswer StringerchangeAgreements { get; set; } = new QuestionAnswer(Alias.stringerchangeAgreements, "false");

        public QuestionAnswer MotorCarrierFiling { get; set; } = new QuestionAnswer(Alias.MotorCarrierFiling, "false");

        public QuestionAnswer TXAuth { get; set; } = new QuestionAnswer(Alias.TXAuth, "false");

        public QuestionAnswer OwnerOperatorsPendingVehicles { get; set; } = new QuestionAnswer(Alias.OwnerOperatorsPendingVehicles, "false");

        public QuestionAnswer OwnerOperatorsPendingVehiclesCost { get; set; } = new QuestionAnswer(Alias.OwnerOperatorsPendingVehiclesCost, "1000");

        public QuestionAnswer OwnerOperatorsBorrowCost { get; set; } = new QuestionAnswer(Alias.OwnerOperatorsBorrowCost, "1000");

        public QuestionAnswer HoldHarmlessAgreements { get; set; } = new QuestionAnswer(Alias.HoldHarmlessAgreements, "false");

        public QuestionAnswer HoldHarmlessRequireCerts { get; set; } = new QuestionAnswer(Alias.HoldHarmlessRequireCerts, "false");

        public QuestionAnswer FmscaOperating { get; set; } = new QuestionAnswer(Alias.FmscaOperating, "false");

        public QuestionAnswer FmscaOperatingTypes { get; set; } = new QuestionAnswer(Alias.FmscaOperatingTypes, "Freight Forwarding");

        public QuestionAnswer TrailerInterchangeAgreements { get; set; } = new QuestionAnswer(Alias.TrailerInterchangeAgreements, "false");

        public QuestionAnswer HaulIntermodal { get; set; } = new QuestionAnswer(Alias.HaulIntermodal, "false");

        public QuestionAnswer DynamicVehicleMoratorium { get; set; } = new QuestionAnswer(Alias.DynamicVehicleMoratorium, "false");

        public QuestionAnswer SubmitProofOfInsuranceClaimsHistory { get; set; } = new QuestionAnswer(Alias.SubmitProofOfInsuranceClaimsHistory, "false");
        #endregion

        #region BOP/GL
        public QuestionAnswer EmpContractorServices { get; set; } = new QuestionAnswer(Alias.EmpContractorServices, "[\"ProjectManagement\"]");
        public QuestionAnswer EmpSubContractServices { get; set; } = new QuestionAnswer(Alias.EmpSubContractServices, "[\"None\"]");
        public QuestionAnswer ProfYrsOfExperience { get; set; } = new QuestionAnswer(Alias.ProfYrsOfExperience, "4");
        public QuestionAnswer EmployeePayroll { get; set; } = new QuestionAnswer(Alias.EmployeePayroll, "2");
        public QuestionAnswer ECommerceRevenue { get; set; } = new QuestionAnswer(Alias.ECommerceRevenue, "50");
        public QuestionAnswer CremationRevenue { get; set; } = new QuestionAnswer(Alias.CremationRevenue, "25");
        public QuestionAnswer AlcoholSales1 { get; set; } = new QuestionAnswer(Alias.AlcoholSales1, "0");
        public QuestionAnswer TireSales1 { get; set; } = new QuestionAnswer(Alias.TireSales1, "0");
        public QuestionAnswer PhysicalWork { get; set; } = new QuestionAnswer(Alias.PhysicalWork, "false");
        public QuestionAnswer FollowupEmpPayroll1 { get; set; } = new QuestionAnswer(Alias.FollowupEmpPayroll1, "23");
        public QuestionAnswer ExcavationSales { get; set; } = new QuestionAnswer(Alias.ExcavationSales, "25");
        public QuestionAnswer DeliverInstallProducts { get; set; } = new QuestionAnswer(Alias.DeliverInstallProducts, "false");
        public QuestionAnswer ComputerInstall { get; set; } = new QuestionAnswer(Alias.ComputerInstall, "false");
        public QuestionAnswer Misconduct { get; set; } = new QuestionAnswer(Alias.Misconduct, "false");
        public QuestionAnswer MisconductExplanation { get; set; } = new QuestionAnswer(Alias.MisconductExplanation, "None");
        public QuestionAnswer MinorEmployees { get; set; } = new QuestionAnswer(Alias.MinorEmployees, "false");
        public QuestionAnswer GrossRevenue { get; set; } = new QuestionAnswer(Alias.GrossRevenue, "85000");
        public QuestionAnswer HiredToFilmEventsDesc { get; set; } = new QuestionAnswer(Alias.HiredToFilmEventsDesc, "none");
        public QuestionAnswer VehiclesNotBusOwned { get; set; } = new QuestionAnswer(Alias.VehiclesNotBusOwned, "false");
        public QuestionAnswer ServiceList { get; set; } = new QuestionAnswer(Alias.ServiceList, "none");
        public QuestionAnswer DirectImport { get; set; } = new QuestionAnswer(Alias.DirectImport, "false");
        public QuestionAnswer SprinklerGasRefineHospNurse { get; set; } = new QuestionAnswer(Alias.SprinklerGasRefineHospNurse, "false");
        public QuestionAnswer PhysicalWorkOthers { get; set; } = new QuestionAnswer(Alias.PhysicalWorkOthers, "false");
        public QuestionAnswer RoofingNY { get; set; } = new QuestionAnswer(Alias.RoofingNY, "false");
        public QuestionAnswer NewConstruction { get; set; } = new QuestionAnswer(Alias.NewConstruction, "false");
        public QuestionAnswer RoofingCovers { get; set; } = new QuestionAnswer(Alias.RoofingCovers, "true");
        public QuestionAnswer DustCollection { get; set; } = new QuestionAnswer(Alias.DustCollection, "true");
        public QuestionAnswer ServiceLaundryMachines { get; set; } = new QuestionAnswer(Alias.ServiceLaundryMachines, "true");
        public QuestionAnswer SprayPainting { get; set; } = new QuestionAnswer(Alias.SprayPainting, "false");
        public QuestionAnswer GreaseSmokeVapors { get; set; } = new QuestionAnswer(Alias.GreaseSmokeVapors, "false");
        public QuestionAnswer PaintingProtection { get; set; } = new QuestionAnswer(Alias.PaintingProtection, "true");
        public QuestionAnswer TreeTrimming { get; set; } = new QuestionAnswer(Alias.TreeTrimming, "false");
        public QuestionAnswer ClosedDueToHealthViolations { get; set; } = new QuestionAnswer(Alias.ClosedDueToHealthViolations, "false");
        public QuestionAnswer ClosedDueToHealthViolationsDesc { get; set; } = new QuestionAnswer(Alias.ClosedDueToHealthViolationsDesc, "none");
        public QuestionAnswer RepairSportsVehicles { get; set; } = new QuestionAnswer(Alias.RepairSportsVehicles, "false");
        public QuestionAnswer ModRacingVehicles { get; set; } = new QuestionAnswer(Alias.ModRacingVehicles, "false");
        public QuestionAnswer CustomerAlcohol { get; set; } = new QuestionAnswer(Alias.CustomerAlcohol, "false");
        public QuestionAnswer AlcoholTraining { get; set; } = new QuestionAnswer(Alias.AlcoholTraining, "true");
        public QuestionAnswer ExcavationMiningTunneling { get; set; } = new QuestionAnswer(Alias.ExcavationMiningTunneling, "false");
        public QuestionAnswer Open24Hours { get; set; } = new QuestionAnswer(Alias.Open24Hours, "false");
        public QuestionAnswer AttendantPresent { get; set; } = new QuestionAnswer(Alias.AttendantPresent, "true");
        public QuestionAnswer RoofingThreeStories { get; set; } = new QuestionAnswer(Alias.RoofingThreeStories, "false");
        public QuestionAnswer PressureWashingThreeStories { get; set; } = new QuestionAnswer(Alias.PressureWashingThreeStories, "false");
        public QuestionAnswer StaffingServices { get; set; } = new QuestionAnswer(Alias.StaffingServices, "false");
        public QuestionAnswer CustomerWaivers { get; set; } = new QuestionAnswer(Alias.CustomerWaivers, "false");
        public QuestionAnswer AllowChildrenEvents { get; set; } = new QuestionAnswer(Alias.AllowChildrenEvents, "false");
        public QuestionAnswer ProductsOwnLabelDesc { get; set; } = new QuestionAnswer(Alias.ProductsOwnLabelDesc, "none");
        public QuestionAnswer ProductsFirearmsAdult { get; set; } = new QuestionAnswer(Alias.ProductsFirearmsAdult, "[\"None\"]");
        public QuestionAnswer BurglarAlarms { get; set; } = new QuestionAnswer(Alias.BurglarAlarms, "false");
        public QuestionAnswer ChildCare { get; set; } = new QuestionAnswer(Alias.ChildCare, "false");
        public QuestionAnswer BurglarAlarmsFireExtElevators { get; set; } = new QuestionAnswer(Alias.BurglarAlarmsFireExtElevators, "false");
        public QuestionAnswer BurglarAlarmsFireExt { get; set; } = new QuestionAnswer(Alias.BurglarAlarmsFireExt, "false");
        public QuestionAnswer WebsiteProducts { get; set; } = new QuestionAnswer(Alias.WebsiteProducts, "[\"Athletic\"]");
        public QuestionAnswer Equipment50k { get; set; } = new QuestionAnswer(Alias.Equipment50k, "false");
        public QuestionAnswer InternetSalesDesc { get; set; } = new QuestionAnswer(Alias.InternetSalesDesc, "none");
        public QuestionAnswer EquipmentCostDesc { get; set; } = new QuestionAnswer(Alias.EquipmentCostDesc, "none");
        public QuestionAnswer PetroleumSystemsWork { get; set; } = new QuestionAnswer(Alias.PetroleumSystemsWork, "false");
        public QuestionAnswer InstallationDesc { get; set; } = new QuestionAnswer(Alias.InstallationDesc, "none");
        public QuestionAnswer WarehouseOpsDesc { get; set; } = new QuestionAnswer(Alias.WarehouseOpsDesc, "none");
        public QuestionAnswer NewResidentialConstruct { get; set; } = new QuestionAnswer(Alias.NewResidentialConstruct, "false");
        public QuestionAnswer InvolvedOps { get; set; } = new QuestionAnswer(Alias.InvolvedOps, "[\"None\"]");
        public QuestionAnswer HeavyConstruct { get; set; } = new QuestionAnswer(Alias.HeavyConstruct, "[\"None\"]");
        public QuestionAnswer ThirdPartyBackgroundChecks { get; set; } = new QuestionAnswer(Alias.ThirdPartyBackgroundChecks, "true");
        public QuestionAnswer ClassicVehiclesWork { get; set; } = new QuestionAnswer(Alias.ClassicVehiclesWork, "false");
        public QuestionAnswer SnowRemovalPlows { get; set; } = new QuestionAnswer(Alias.SnowRemovalPlows, "false");
        public QuestionAnswer GuidedTours { get; set; } = new QuestionAnswer(Alias.GuidedTours, "false");
        public QuestionAnswer ChildCareOvernight { get; set; } = new QuestionAnswer(Alias.ChildCareOvernight, "false");
        public QuestionAnswer FoodCarts { get; set; } = new QuestionAnswer(Alias.FoodCarts, "false");
        public QuestionAnswer NumberVehicleSnowRemoval { get; set; } = new QuestionAnswer(Alias.NumberVehicleSnowRemoval, "0");
        public QuestionAnswer SnowRemovalPublic { get; set; } = new QuestionAnswer(Alias.SnowRemovalPublic, "false");
        public QuestionAnswer BartendingServices { get; set; } = new QuestionAnswer(Alias.BartendingServices, "false");
        public QuestionAnswer LiveEntertainmentServices { get; set; } = new QuestionAnswer(Alias.LiveEntertainmentServices, "false");
        public QuestionAnswer PermitServices { get; set; } = new QuestionAnswer(Alias.PermitServices, "false");
        public QuestionAnswer DaycareMaxChildren { get; set; } = new QuestionAnswer(Alias.DaycareMaxChildren, "2");
        public QuestionAnswer ResidentialPercent { get; set; } = new QuestionAnswer(Alias.ResidentialPercent, "0");
        public QuestionAnswer CommercialPercent { get; set; } = new QuestionAnswer(Alias.CommercialPercent, "100");
        public QuestionAnswer IndustrialPercent { get; set; } = new QuestionAnswer(Alias.IndustrialPercent, '0');
        public QuestionAnswer CaregiversPerChild { get; set; } = new QuestionAnswer(Alias.CaregiversPerChild, "true");
        public QuestionAnswer NumberFoodCarts { get; set; } = new QuestionAnswer(Alias.NumberFoodCarts, "0");
        public QuestionAnswer RoofingCondosTownTracts { get; set; } = new QuestionAnswer(Alias.RoofingCondosTownTracts, "false");
        public QuestionAnswer DaycareDisabilities { get; set; } = new QuestionAnswer(Alias.DaycareDisabilities, "false");
        public QuestionAnswer SocialworkAlcoholism { get; set; } = new QuestionAnswer(Alias.SocialworkAlcoholism, "false");
        public QuestionAnswer DaycareAnimals { get; set; } = new QuestionAnswer(Alias.DaycareAnimals, "false");
        public QuestionAnswer DaycareAnimalsDesc { get; set; } = new QuestionAnswer(Alias.DaycareAnimalsDesc, "none");
        public QuestionAnswer SetupTables { get; set; } = new QuestionAnswer(Alias.SetupTables, "false");
        public QuestionAnswer DaycareSwimming { get; set; } = new QuestionAnswer(Alias.DaycareSwimming, "false");
        public QuestionAnswer HotTarDesc { get; set; } = new QuestionAnswer(Alias.HotTarDesc, "none");
        public QuestionAnswer SprayPaintingVehicles { get; set; } = new QuestionAnswer(Alias.SprayPaintingVehicles, "false");
        public QuestionAnswer SaaSWebApp { get; set; } = new QuestionAnswer(Alias.SaaSWebApp, "false");
        public QuestionAnswer MagorityCommercialClients { get; set; } = new QuestionAnswer(Alias.MagorityCommercialClients, "false");
        public QuestionAnswer DaycareLicensed { get; set; } = new QuestionAnswer(Alias.DaycareLicensed, "true");
        public QuestionAnswer LicenseRevokeSuspend { get; set; } = new QuestionAnswer(Alias.LicenseRevokeSuspend, "false");
        public QuestionAnswer LicenseRevokeSuspendDesc { get; set; } = new QuestionAnswer(Alias.LicenseRevokeSuspendDesc, "none");
        public QuestionAnswer Cryptocurrencies { get; set; } = new QuestionAnswer(Alias.Cryptocurrencies, "false");
        public QuestionAnswer AlarmsVehicles { get; set; } = new QuestionAnswer(Alias.AlarmsVehicles, "false");
        public QuestionAnswer SpaServicesPrivateRes { get; set; } = new QuestionAnswer(Alias.SpaServicesPrivateRes, "false");
        public QuestionAnswer PatrolServices { get; set; } = new QuestionAnswer(Alias.PatrolServices, "false");
        public QuestionAnswer SoftwareMilitaryAeroOil { get; set; } = new QuestionAnswer(Alias.SoftwareMilitaryAeroOil, "false");
        public QuestionAnswer AlarmDispatch { get; set; } = new QuestionAnswer(Alias.AlarmDispatch, "false");
        public QuestionAnswer TanningBooths { get; set; } = new QuestionAnswer(Alias.TanningBooths, "false");
        public QuestionAnswer ExteriorInsulation { get; set; } = new QuestionAnswer(Alias.ExteriorInsulation, "false");
        public QuestionAnswer Saunas { get; set; } = new QuestionAnswer(Alias.Saunas, "false");
        public QuestionAnswer TangibleGoods { get; set; } = new QuestionAnswer(Alias.TangibleGoods, "false");
        public QuestionAnswer OvernightLodging { get; set; } = new QuestionAnswer(Alias.OvernightLodging, "false");
        public QuestionAnswer OvernightLodgingDesc { get; set; } = new QuestionAnswer(Alias.OvernightLodgingDesc, "false");
        public QuestionAnswer IndustrialWorkDesc { get; set; } = new QuestionAnswer(Alias.IndustrialWorkDesc, "none");
        public QuestionAnswer InsulationOtherMats { get; set; } = new QuestionAnswer(Alias.InsulationOtherMats, "false");
        public QuestionAnswer PropertyDesignConstInstall { get; set; } = new QuestionAnswer(Alias.PropertyDesignConstInstall, "false");
        public QuestionAnswer InsulationOtherMatDesc { get; set; } = new QuestionAnswer(Alias.InsulationOtherMatDesc, "none");
        public QuestionAnswer ConcreteWalls { get; set; } = new QuestionAnswer(Alias.ConcreteWalls, "false");
        public QuestionAnswer AlcoholComplimentary { get; set; } = new QuestionAnswer(Alias.AlcoholComplimentary, "false");
        public QuestionAnswer SalvageOps { get; set; } = new QuestionAnswer(Alias.SalvageOps, "false");
        public QuestionAnswer HardwareComponents { get; set; } = new QuestionAnswer(Alias.HardwareComponents, "false");
        public QuestionAnswer SalvageOpsDesc { get; set; } = new QuestionAnswer(Alias.SalvageOpsDesc, "none");
        public QuestionAnswer NumberPools { get; set; } = new QuestionAnswer(Alias.NumberPools, "1");
        public QuestionAnswer RestorationContracting { get; set; } = new QuestionAnswer(Alias.RestorationContracting, "false");
        public QuestionAnswer SpaWaiver { get; set; } = new QuestionAnswer(Alias.SpaWaiver, "false");
        public QuestionAnswer MaterialRemoval { get; set; } = new QuestionAnswer(Alias.MaterialRemoval, "false");
        public QuestionAnswer TobaccoSales { get; set; } = new QuestionAnswer(Alias.TobaccoSales, "false");
        public QuestionAnswer SaltwaterChamber { get; set; } = new QuestionAnswer(Alias.SaltwaterChamber, "false");
        public QuestionAnswer ManageFifteenPercentOwn { get; set; } = new QuestionAnswer(Alias.ManageFifteenPercentOwn, "false");
        public QuestionAnswer ManageFifteenPercentOwnDesc { get; set; } = new QuestionAnswer(Alias.ManageFifteenPercentOwnDesc, "false");
        public QuestionAnswer ManageConstructProject { get; set; } = new QuestionAnswer(Alias.ManageConstructProject, "false");
        public QuestionAnswer PropertyType { get; set; } = new QuestionAnswer(Alias.PropertyType, "All Residential");
        public QuestionAnswer InsuranceInspector { get; set; } = new QuestionAnswer(Alias.InsuranceInspector, "false");
        public QuestionAnswer InsuranceInspectorDesc { get; set; } = new QuestionAnswer(Alias.InsuranceInspectorDesc, "none");
        public QuestionAnswer PropertyDeveloper { get; set; } = new QuestionAnswer(Alias.PropertyDeveloper, "false");
        public QuestionAnswer Evictions { get; set; } = new QuestionAnswer(Alias.Evictions, "false");
        public QuestionAnswer SnowRemoval { get; set; } = new QuestionAnswer(Alias.SnowRemoval, "false");
        public QuestionAnswer ServiceWork { get; set; } = new QuestionAnswer(Alias.ServiceWork, "[\"None\"]");
        public QuestionAnswer ProductsPackingMats { get; set; } = new QuestionAnswer(Alias.ProductsPackingMats, "false");
        public QuestionAnswer NumberProperties { get; set; } = new QuestionAnswer(Alias.NumberProperties, "0");
        public QuestionAnswer EquipmentRentalShredTrade { get; set; } = new QuestionAnswer(Alias.EquipmentRentalShredTrade, "false");
        public QuestionAnswer StorageService { get; set; } = new QuestionAnswer(Alias.StorageService, "false");
        public QuestionAnswer FreightForwarder { get; set; } = new QuestionAnswer(Alias.FreightForwarder, "false");
        public QuestionAnswer JunkRemoval { get; set; } = new QuestionAnswer(Alias.JunkRemoval, "false");
        public QuestionAnswer VehicleTransport { get; set; } = new QuestionAnswer(Alias.VehicleTransport, "false");
        public QuestionAnswer FirearmLicense { get; set; } = new QuestionAnswer(Alias.FirearmLicense, "true");
        public QuestionAnswer SubcontractAgreement1 { get; set; } = new QuestionAnswer(Alias.SubcontractAgreement1, "true");
        public QuestionAnswer CertificateAgreement { get; set; } = new QuestionAnswer(Alias.CertificateAgreement, "true");
        public QuestionAnswer SubcontractorSimilarWork { get; set; } = new QuestionAnswer(Alias.SubcontractorSimilarWork, "true");
        public QuestionAnswer OtherServicesDesc { get; set; } = new QuestionAnswer(Alias.OtherServicesDesc, "none");
        public QuestionAnswer ConsignmentMerch { get; set; } = new QuestionAnswer(Alias.ConsignmentMerch, "false");
        public QuestionAnswer ExteriorCleaning { get; set; } = new QuestionAnswer(Alias.ExteriorCleaning, "false");
        public QuestionAnswer JewelryInventoryValue { get; set; } = new QuestionAnswer(Alias.JewelryInventoryValue, "0");
        public QuestionAnswer InternetSales { get; set; } = new QuestionAnswer(Alias.InternetSales, "false");
        public QuestionAnswer EquipmentRental { get; set; } = new QuestionAnswer(Alias.EquipmentRental, "false");
        public QuestionAnswer PhysicalLocation { get; set; } = new QuestionAnswer(Alias.PhysicalLocation, "false");
        public QuestionAnswer WarehouseOps { get; set; } = new QuestionAnswer(Alias.WarehouseOps, "false");
        public QuestionAnswer LongTermRentPercent { get; set; } = new QuestionAnswer(Alias.LongTermRentPercent, "25");
        public QuestionAnswer ResidentialWorkPercent { get; set; } = new QuestionAnswer(Alias.ResidentialWorkPercent, "50");
        public QuestionAnswer ConstructionCleanup { get; set; } = new QuestionAnswer(Alias.ConstructionCleanup, "false");
        public QuestionAnswer Open24 { get; set; } = new QuestionAnswer(Alias.Open24, "false");
        public QuestionAnswer PropertyLiabilityClaim3Year { get; set; } = new QuestionAnswer(Alias.PropertyLiabilityClaim3Year, "false");
        public QuestionAnswer CurrentPropertyGeneralLiability { get; set; } = new QuestionAnswer(Alias.CurrentPropertyGeneralLiability, "true");
        public QuestionAnswer AssaultBatteryExclusion { get; set; } = new QuestionAnswer(Alias.AssaultBatteryExclusion, "true");
        public QuestionAnswer PetGroomerPolicyAcknowledgment { get; set; } = new QuestionAnswer(Alias.PetGroomerPolicyAcknowledgment, "true");
        #endregion
    }
}
