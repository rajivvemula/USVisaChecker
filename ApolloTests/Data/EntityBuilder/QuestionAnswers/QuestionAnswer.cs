namespace ApolloTests.Data.EntityBuilder.QuestionAnswers
{
    /// <summary>
    /// This is a CUSTOM class is used to store answers for a given question (this is used to build the model to be sent) <br/>
    /// THIS IS NOT THE MODEL
    /// </summary>
    public class QuestionAnswer
    {
        public readonly string _alias;

        public string? _response;
        public bool PopulateWhenHidden { get; set; } = false;
        public bool AsJsonStr { get; set; } = false;
        public string? variableName { get; set; }
        public Type? targetType { get; set; }
        public QuestionAnswer(string alias, string? response)
        {
            _alias = alias;
            _response = response;
        }
        public QuestionAnswer(string alias, string? response, bool populateWhenHidden)
        {
            _alias = alias;
            _response = response;
            PopulateWhenHidden = populateWhenHidden;
        }

        public static class Alias
        {
            #region Operations CA

            public const string VehicleRadius   = "VehicleRadius";

            public const string FineArt   = "FineArt";

            public const string Haul   = "Haul";

            public const string Chains   = "Chains";

            public const string ResidentialMoving   = "ResidentialMoving";

            public const string Biohazard   = "Biohazard";

            public const string TeamDriving   = "TeamDriving";

            public const string TravelToMexico   = "TravelToMexico";

            public const string ClaimCount   = "ClaimCount";

            public const string IL_Authority   = "IL-Authority";

            public const string SC_Authority   = "SC-Authority";

            public const string KS_Authority   = "KS-Authority";

            public const string NE_Authority   = "NE-Authority";

            public const string OK_Authority   = "OK-Authority";

            public const string OR_Authority   = "OR-Authority";

            public const string CT_Authority   = "CT-Authority";

            public const string CO_Authority   = "CO-Authority";

            public const string BorrowVehicles   = "BorrowVehicles";

            public const string USDOT   = "USDOT";

            public const string USDOTNumber   = "USDOT#";

            public const string UseOwnerOperators   = "UseOwnerOperators";

            public const string OnCall   = "OnCall";

            public const string PartyBus   = "PartyBus";

            public const string DayCare   = "DayCare";

            public const string VehicleSellOrLease   = "VehicleSellOrLease";

            public const string Salvage   = "Salvage";

            public const string ServiceAccess   = "ServiceAccess";

            public const string Ammonia   = "Ammonia";

            public const string Poison   = "Poison";

            public const string Radioactive   = "Radioactive";

            public const string EmergencyResponse   = "EmergencyResponse";

            public const string CaliOperatingAuth   = "CaliOperatingAuth";

            public const string CaliCarrierNumber   = "CaliCarrier#";

            public const string PUC   = "PUC";

            public const string NonOwnedGoods   = "NonOwnedGoods";

            public const string stringerchangeAgreements   = "stringerchangeAgreements";

            public const string MotorCarrierFiling   = "MotorCarrierFiling";

            public const string TXAuth   = "TXAuth";

            public const string OwnerOperatorsPendingVehicles   = "OwnerOperatorsPendingVehicles";

            public const string OwnerOperatorsPendingVehiclesCost   = "OwnerOperatorsPendingVehiclesCost";

            public const string OwnerOperatorsBorrowCost   = "OwnerOperatorsBorrowCost";

            public const string HoldHarmlessAgreements   = "HoldHarmlessAgreements";

            public const string HoldHarmlessRequireCerts   = "HoldHarmlessRequireCerts";

            public const string FmscaOperating   = "FmscaOperating";

            public const string FmscaOperatingTypes   = "FmscaOperatingTypes";

            public const string TrailerInterchangeAgreements   = "TrailerInterchangeAgreements";

            public const string HaulIntermodal   = "HaulIntermodal";

            public const string DynamicVehicleMoratorium   = "DynamicVehicleMoratorium";

            public const string SubmitProofOfInsuranceClaimsHistory   = "SubmitProofOfInsuranceClaimsHistory";

            public const string TowingAssistance = "TowingAssistance";

            public const string VehicleInventory = "VehicleInventory";

            public const string RentVehicles = "RentVehicles";

            public const string EscortConstruction = "EscortConstruction";

            public const string HaulAnyHazardous = "HaulAnyHazardous";

            public const string EnterCustomerHome = "EnterCustomerHome";

            public const string Amazon = "Amazon";

            public const string ServicesProvide = "ServicesProvide";

            public const string NJ_VehicleComm = "NJ-VehicleComm";


            #endregion Operations

            #region Vehicles

            public const string Vehicles   = "Vehicles";

            public const string DefaultVehicleClassCode   = "DefaultVehicleClassCode";

            public const string VehicleParkingAddrsIn   = "VehicleParkingAddrsIn";

            public const string TrailerParkingAddrsIn   = "TrailerParkingAddrsIn";

            public const string PlowingSnow   = "PlowingSnow";

            public const string TransportTours   = "TransportTours";

            public const string VehicleOwnedLeasedFinanced   = "VehicleOwnedLeasedFinanced";

            public const string VehicleTitleOwner   = "VehicleTitleOwner";

            public const string VehicleOwner1BusinessName   = "VehicleOwner1BusinessName";

            public const string VehicleTitleOwnerIndividual   = "VehicleTitleOwnerIndividual";

            public const string VehicleDiffState   = "VehicleDiffState";

            public const string VehicleUse   = "VehicleUse";

            public const string VehicleUseRetail   = "VehicleUseRetail";

            public const string GoodsOrMaterialsRetail   = "GoodsOrMaterialsRetail";

            public const string GoodsOrMaterialsBlueCollar   = "GoodsOrMaterialsBlueCollar";

            public const string TrailerOwnedFinancedLeased   = "TrailerOwnedFinancedLeased";

            public const string TrailerDiffState   = "TrailerDiffState";

            public const string TrailerTitleOwner   = "TrailerTitleOwner";

            public const string VehicleOwner1Address   = "VehicleOwner1Address";

            public const string TrailerOwner1BusinessName   = "TrailerOwner1BusinessName";

            public const string TrailerOwner1Address   = "TrailerOwner1Address";
            public const string VehicleLienholder1FirstName   = "VehicleLienholder1FirstName";
            public const string VehicleLienholder1Address   = "VehicleLienholder1Address";

            public const string VehicleLessorName   = "VehicleLessorName";

            public const string VehicleLessorAddress   = "VehicleLessorAddress";

            public const string VehicleSeatCount   = "VehicleSeatCount";

            public const string Landfills = "Landfills";

            public const string TaxiMeterSingle = "TaxiMeterSingle";

            public const string Outpatient = "Outpatient";

            #endregion Vehicles

            #region Drivers

            public const string ExcludeDriver   = "ExcludeDriver";

            public const string AccidentOrViolation   = "AccidentOrViolation";

            public const string IL_DefensiveDriving   = "IL-DefensiveDriving";

            public const string IL_LastYearViolation   = "IL-LastYearViolation";

            public const string IL_Last3YearsLicenseSuspended   = "IL-Last3YearsLicenseSuspended";

            public const string CDL   = "CDL";

            public const string DefensiveDriving   = "DefensiveDriving";

            #endregion Drivers

            #region Policy Coverage

            #region Cargo Coverage

            public const string IncludeCargoTheftCoverage   = "IncludeCargoTheftCoverage";

            public const string IncludeCargoNamedPerilsCoverage   = "IncludeCargoNamedPerilsCoverage";

            public const string IncludeEarnedFreightCoverage   = "IncludeEarnedFreightCoverage";

            #endregion Cargo Coverage

            #region Rental Reimbursement

            public const string RentalDowntimeIncluded   = "RentalDowntimeIncluded";

            #endregion Rental Reimbursement

            #region In-Tow

            public const string CustomerCargoCoverage   = "CustomerCargoCoverage";

            #endregion In-Tow

            #endregion Policy Coverage

            #region Additional Interest
            public const string AdditionalInterestContactUpdated   = "AdditionalInterestContactUpdated";
            public const string AdditionalInterests   = "AdditionalInterests";
            public const string AdditionalInterestName   = "AdditionalInterestName";
            public const string AdditionalInterestAddress   = "AdditionalInterestAddress";
            public const string AdditionalInterestCertificateHolderNotice   = "AdditionalInterestCertificateHolderNotice";
            public const string AdditionalInterestsBuilding   = "AdditionalInterestsBuilding";


            #endregion Additional Interest CA


            #region Prior Claims
            public const string DateOfLoss   = "DateOfLoss";
            public const string ClaimDesc   = "ClaimDesc";
            public const string EstimatedCost   = "EstimatedCost";

            #endregion Prior Claims


            #region Locations & buildings
            public const string BuildingLocationAddress   = "BuildingLocationAddress";
            public const string Buildings   = "Buildings";
            public const string CarbonMonoxideDetector   = "CarbonMonoxideDetector";
            public const string SmokeFireDetector   = "SmokeFireDetector";
            public const string BusinessOccupiedUnits   = "BusinessOccupiedUnits";
            public const string CondoTownAssociationName   = "CondoTownAssociationName";
            public const string CondoCoopUnitNumber   = "CondoCoopUnitNumber";
            public const string IsOrgACoop   = "IsOrgACoop";
            public const string CommercialOccupantPercent   = "CommercialOccupantPercent";
            public const string InsuranceTrusteeName   = "InsuranceTrusteeName";
            public const string UCIOActAssociation   = "UCIOActAssociation";
            public const string AssociationCreated1Jan1991   = "AssociationCreated1Jan1991";
            public const string AssociationCreated29Oct1990   = "AssociationCreated29Oct1990";
            public const string AssociationCreated7Aug1985   = "AssociationCreated7Aug1985";
            public const string AssociationCreated1Jan1984   = "AssociationCreated1Jan1984";
            public const string AssociationCreated1Jul1991   = "AssociationCreated1Jul1991";
            public const string AssociationCreated1Jun1994   = "AssociationCreated1Jun1994";
            public const string AssociationCreated28Sep1983   = "AssociationCreated28Sep1983";
            public const string AssociationCreated1Oct1986   = "AssociationCreated1Oct1986";
            public const string AssociationCreated1Jul1900   = "AssociationCreated1Jul1900";
            public const string CarWashFullServeBayNumber   = "CarWashFullServeBayNumber";
            public const string BylawsConformCurrentStateAct   = "BylawsConformCurrentStateAct";
            public const string StudentUnitRentPercent   = "StudentUnitRentPercent";
            public const string CarWashSelfServeBayNumber   = "CarWashSelfServeBayNumber";
            public const string BuildingIncludeApartments   = "BuildingIncludeApartments";
            public const string SemiAnnualFireSystemDuctContractNotRestaurant   = "SemiAnnualFireSystemDuctContractNotRestaurant";
            public const string DanceCoverAlcoholKitchClosedNotRestaurant   = "DanceCoverAlcoholKitchClosedNotRestaurant";
            public const string SemiAnnualFireSystemDuctContractRestaurant   = "SemiAnnualFireSystemDuctContractRestaurant";
            public const string BarAlcoholOnPremise   = "BarAlcoholOnPremise";
            public const string DanceCoverAlcoholKitchClosedRestaurant   = "DanceCoverAlcoholKitchClosedRestaurant";
            public const string PremisePoolHotTub   = "PremisePoolHotTub";
            public const string BusinessTenantOccupyNumber1   = "BusinessTenantOccupyNumber1";
            public const string CoverageEntireBuilding   = "CoverageEntireBuilding";
            public const string BuildingSqFt   = "BuildingSqFt";
            public const string BusinessSqFt   = "BusinessSqFt";
            public const string BuildingFinancialInterest   = "BuildingFinancialInterest";
            public const string HurricaneResistGlass   = "HurricaneResistGlass";
            public const string GuestRoomNumber   = "GuestRoomNumber";
            public const string AvgDailyRate   = "AvgDailyRate";
            public const string GrossSales12MonthExcludeGuestRooms   = "GrossSales12MonthExcludeGuestRooms";
            public const string PlaygroundAreas   = "PlaygroundAreas";
            public const string BuildingPoolNumber   = "BuildingPoolNumber";
            public const string GuestRoomEntrancesOnExterior   = "GuestRoomEntrancesOnExterior";
            public const string BuildingStoriesNumber   = "BuildingStoriesNumber";
            public const string BuildingYearBuilt   = "BuildingYearBuilt";
            public const string RoofUpdated25Years   = "RoofUpdated25Years";
            public const string BuildingConstructed   = "BuildingConstructed";
            public const string BuildingOccupiedConstructed   = "BuildingOccupiedConstructed";
            public const string BuildingResidentUnitNumber   = "BuildingResidentUnitNumber";
            public const string PropertyLeadAbatement   = "PropertyLeadAbatement";
            public const string LeadCertificateType   = "LeadCertificateType";
            public const string BuildingRegisteredMDDeptofEng   = "BuildingRegisteredMDDeptofEng";
            public const string UnitsObtainedLeadControlNumber   = "UnitsObtainedLeadControlNumber";
            public const string UnitsObtainedLeadComplianceNumber   = "UnitsObtainedLeadComplianceNumber";
            public const string CookingGreaseSmokeVapors   = "CookingGreaseSmokeVapors";
            public const string ClosedHealthCode5Years   = "ClosedHealthCode5Years";
            #endregion Locations & buildings

            #region Tools
            public const string ToolDesc   = "ToolDesc";
            public const string Manufacturer   = "Manufacturer";
            public const string ModelNumber   = "ModelNumber";
            public const string ToolReplacementCost   = "ToolReplacementCost";

            #endregion

            #region Operations BOP/GL
            public const string EmpContractorServices   = "EmpContractorServices";
            public const string EmpSubContractServices   = "EmpSubContractServices";
            public const string ProfYrsOfExperience   = "ProfYrsOfExperience";
            public const string EmployeePayroll   = "EmployeePayroll";
            public const string ECommerceRevenue   = "ECommerceRevenue";
            public const string CremationRevenue   = "CremationRevenue";
            public const string AlcoholSales1   = "AlcoholSales1";
            public const string TireSales1   = "TireSales1";
            public const string PhysicalWork   = "PhysicalWork";
            public const string FollowupEmpPayroll1   = "FollowupEmpPayroll1";
            public const string ExcavationSales   = "ExcavationSales";
            public const string DeliverInstallProducts   = "DeliverInstallProducts";
            public const string ComputerInstall   = "ComputerInstall";
            public const string Misconduct   = "Misconduct";
            public const string MisconductExplanation   = "MisconductExplanation";
            public const string MinorEmployees   = "MinorEmployees";
            public const string GrossRevenue   = "GrossRevenue";
            public const string HiredToFilmEventsDesc   = "HiredToFilmEventsDesc";
            public const string VehiclesNotBusOwned   = "VehiclesNotBusOwned";
            public const string ServiceList   = "ServiceList";
            public const string DirectImport   = "DirectImport";
            public const string SprinklerGasRefineHospNurse   = "SprinklerGasRefineHospNurse";
            public const string PhysicalWorkOthers   = "PhysicalWorkOthers";
            public const string RoofingNY   = "RoofingNY";
            public const string NewConstruction   = "NewConstruction";
            public const string RoofingCovers   = "RoofingCovers";
            public const string DustCollection   = "DustCollection";
            public const string ServiceLaundryMachines   = "ServiceLaundryMachines";
            public const string SprayPainting   = "SprayPainting";
            public const string GreaseSmokeVapors   = "GreaseSmokeVapors";
            public const string PaintingProtection   = "PaintingProtection";
            public const string TreeTrimming   = "TreeTrimming";
            public const string ClosedDueToHealthViolations   = "ClosedDueToHealthViolations";
            public const string ClosedDueToHealthViolationsDesc   = "ClosedDueToHealthViolationsDesc";
            public const string RepairSportsVehicles   = "RepairSportsVehicles";
            public const string ModRacingVehicles   = "ModRacingVehicles";
            public const string CustomerAlcohol   = "CustomerAlcohol";
            public const string AlcoholTraining   = "AlcoholTraining";
            public const string ExcavationMiningTunneling   = "ExcavationMiningTunneling";
            public const string Open24Hours   = "Open24Hours";
            public const string AttendantPresent   = "AttendantPresent";
            public const string RoofingThreeStories   = "RoofingThreeStories";
            public const string PressureWashingThreeStories   = "PressureWashingThreeStories";
            public const string StaffingServices   = "StaffingServices";
            public const string CustomerWaivers   = "CustomerWaivers";
            public const string AllowChildrenEvents   = "AllowChildrenEvents";
            public const string ProductsOwnLabelDesc   = "ProductsOwnLabelDesc";
            public const string ProductsFirearmsAdult   = "ProductsFirearmsAdult";
            public const string BurglarAlarms   = "BurglarAlarms";
            public const string ChildCare   = "ChildCare";
            public const string BurglarAlarmsFireExtElevators   = "BurglarAlarmsFireExtElevators";
            public const string BurglarAlarmsFireExt   = "BurglarAlarmsFireExt";
            public const string WebsiteProducts   = "WebsiteProducts";
            public const string Equipment50k   = "Equipment50k";
            public const string InternetSalesDesc   = "InternetSalesDesc";
            public const string EquipmentCostDesc   = "EquipmentCostDesc";
            public const string PetroleumSystemsWork   = "PetroleumSystemsWork";
            public const string InstallationDesc   = "InstallationDesc";
            public const string WarehouseOpsDesc   = "WarehouseOpsDesc";
            public const string NewResidentialConstruct   = "NewResidentialConstruct";
            public const string InvolvedOps   = "InvolvedOps";
            public const string HeavyConstruct   = "HeavyConstruct";
            public const string ThirdPartyBackgroundChecks   = "ThirdPartyBackgroundChecks";
            public const string ClassicVehiclesWork   = "ClassicVehiclesWork";
            public const string SnowRemovalPlows   = "SnowRemovalPlows";
            public const string GuidedTours   = "GuidedTours";
            public const string ChildCareOvernight   = "ChildCareOvernight";
            public const string FoodCarts   = "FoodCarts";
            public const string NumberVehicleSnowRemoval   = "NumberVehicleSnowRemoval";
            public const string SnowRemovalPublic   = "SnowRemovalPublic";
            public const string BartendingServices   = "BartendingServices";
            public const string LiveEntertainmentServices   = "LiveEntertainmentServices";
            public const string PermitServices   = "PermitServices";
            public const string DaycareMaxChildren   = "DaycareMaxChildren";
            public const string ResidentialPercent   = "ResidentialPercent";
            public const string CommercialPercent   = "CommercialPercent";
            public const string IndustrialPercent   = "IndustrialPercent";
            public const string CaregiversPerChild   = "CaregiversPerChild";
            public const string NumberFoodCarts   = "NumberFoodCarts";
            public const string RoofingCondosTownTracts   = "RoofingCondosTownTracts";
            public const string DaycareDisabilities   = "DaycareDisabilities";
            public const string SocialworkAlcoholism   = "SocialworkAlcoholism";
            public const string DaycareAnimals   = "DaycareAnimals";
            public const string DaycareAnimalsDesc   = "DaycareAnimalsDesc";
            public const string SetupTables   = "SetupTables";
            public const string DaycareSwimming   = "DaycareSwimming";
            public const string HotTarDesc   = "HotTarDesc";
            public const string SprayPaintingVehicles   = "SprayPaintingVehicles";
            public const string SaaSWebApp   = "SaaSWebApp";
            public const string MagorityCommercialClients   = "MagorityCommercialClients";
            public const string DaycareLicensed   = "DaycareLicensed";
            public const string LicenseRevokeSuspend   = "LicenseRevokeSuspend";
            public const string LicenseRevokeSuspendDesc   = "LicenseRevokeSuspendDesc";
            public const string Cryptocurrencies   = "Cryptocurrencies";
            public const string AlarmsVehicles   = "AlarmsVehicles";
            public const string SpaServicesPrivateRes   = "SpaServicesPrivateRes";
            public const string PatrolServices   = "PatrolServices";
            public const string SoftwareMilitaryAeroOil   = "SoftwareMilitaryAeroOil";
            public const string AlarmDispatch   = "AlarmDispatch";
            public const string TanningBooths   = "TanningBooths";
            public const string ExteriorInsulation   = "ExteriorInsulation";
            public const string Saunas   = "Saunas";
            public const string TangibleGoods   = "TangibleGoods";
            public const string OvernightLodging   = "OvernightLodging";
            public const string OvernightLodgingDesc   = "OvernightLodgingDesc";
            public const string IndustrialWorkDesc   = "IndustrialWorkDesc";
            public const string InsulationOtherMats   = "InsulationOtherMats";
            public const string PropertyDesignConstInstall   = "PropertyDesignConstInstall";
            public const string InsulationOtherMatDesc   = "InsulationOtherMatDesc";
            public const string ConcreteWalls   = "ConcreteWalls";
            public const string AlcoholComplimentary   = "AlcoholComplimentary";
            public const string SalvageOps   = "SalvageOps";
            public const string HardwareComponents   = "HardwareComponents";
            public const string SalvageOpsDesc   = "SalvageOpsDesc";
            public const string NumberPools   = "NumberPools";
            public const string RestorationContracting   = "RestorationContracting";
            public const string SpaWaiver   = "SpaWaiver";
            public const string MaterialRemoval   = "MaterialRemoval";
            public const string TobaccoSales   = "TobaccoSales";
            public const string SaltwaterChamber   = "SaltwaterChamber";
            public const string ManageFifteenPercentOwn   = "ManageFifteenPercentOwn";
            public const string ManageFifteenPercentOwnDesc   = "ManageFifteenPercentOwnDesc";
            public const string ManageConstructProject   = "ManageConstructProject";
            public const string PropertyType   = "PropertyType";
            public const string InsuranceInspector   = "InsuranceInspector";
            public const string InsuranceInspectorDesc   = "InsuranceInspectorDesc";
            public const string PropertyDeveloper   = "PropertyDeveloper";
            public const string Evictions   = "Evictions";
            public const string SnowRemoval   = "SnowRemoval";
            public const string ServiceWork   = "ServiceWork";
            public const string ProductsPackingMats   = "ProductsPackingMats";
            public const string NumberProperties   = "NumberProperties";
            public const string EquipmentRentalShredTrade   = "EquipmentRentalShredTrade";
            public const string StorageService   = "StorageService";
            public const string FreightForwarder   = "FreightForwarder";
            public const string JunkRemoval   = "JunkRemoval";
            public const string VehicleTransport   = "VehicleTransport";
            public const string FirearmLicense   = "FirearmLicense";
            public const string SubcontractAgreement1   = "SubcontractAgreement1";
            public const string CertificateAgreement   = "CertificateAgreement";
            public const string SubcontractorSimilarWork   = "SubcontractorSimilarWork";
            public const string OtherServicesDesc   = "OtherServicesDesc";
            public const string ConsignmentMerch   = "ConsignmentMerch";
            public const string ExteriorCleaning   = "ExteriorCleaning";
            public const string JewelryInventoryValue   = "JewelryInventoryValue";
            public const string InternetSales   = "InternetSales";
            public const string EquipmentRental   = "EquipmentRental";
            public const string PhysicalLocation   = "PhysicalLocation";
            public const string WarehouseOps   = "WarehouseOps";
            public const string LongTermRentPercent   = "LongTermRentPercent";
            public const string ResidentialWorkPercent   = "ResidentialWorkPercent";
            public const string ConstructionCleanup   = "ConstructionCleanup";
            public const string Open24   = "Open24";
            public const string PropertyLiabilityClaim3Year   = "PropertyLiabilityClaim3Year";
            public const string CurrentPropertyGeneralLiability   = "CurrentPropertyGeneralLiability";
            public const string AssaultBatteryExclusion   = "AssaultBatteryExclusion";
            public const string PetGroomerPolicyAcknowledgment   = "PetGroomerPolicyAcknowledgment";
            #endregion
        }
    }
}