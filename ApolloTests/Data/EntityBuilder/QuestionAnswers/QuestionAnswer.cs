namespace ApolloTests.Data.EntityBuilder.QuestionAnswers
{
    public class QuestionAnswer
    {
        public readonly string _alias;

        public object? _response;
        public bool PopulateWhenHidden { get; set; } = false;
        public bool AsJsonStr { get; set; } = false;
        public string? variableName { get; set; }
        public Type? targetType { get; set; }
        public QuestionAnswer(string alias, object? response)
        {
            _alias = alias;
            _response = response;
        }
        public QuestionAnswer(string alias, object? response, bool populateWhenHidden)
        {
            _alias = alias;
            _response = response;
            PopulateWhenHidden = populateWhenHidden;
        }

        public static class Alias
        {
            #region Operations

            public static string VehicleRadius { get; } = "VehicleRadius";

            public static string FineArt { get; } = "FineArt";

            public static string Haul { get; } = "Haul";

            public static string Chains { get; } = "Chains";

            public static string ResidentialMoving { get; } = "ResidentialMoving";

            public static string Biohazard { get; } = "Biohazard";

            public static string TeamDriving { get; } = "TeamDriving";

            public static string TravelToMexico { get; } = "TravelToMexico";

            public static string ClaimCount { get; } = "ClaimCount";

            public static string IL_Authority { get; } = "IL-Authority";

            public static string SC_Authority { get; } = "SC-Authority";

            public static string KS_Authority { get; } = "KS-Authority";

            public static string NE_Authority { get; } = "NE-Authority";

            public static string OK_Authority { get; } = "OK-Authority";

            public static string OR_Authority { get; } = "OR-Authority";

            public static string CT_Authority { get; } = "CT-Authority";

            public static string CO_Authority { get; } = "CO-Authority";

            public static string BorrowVehicles { get; } = "BorrowVehicles";

            public static string USDOT { get; } = "USDOT";

            public static string USDOTNumber { get; } = "USDOT#";

            public static string UseOwnerOperators { get; } = "UseOwnerOperators";

            public static string OnCall { get; } = "OnCall";

            public static string PartyBus { get; } = "PartyBus";

            public static string DayCare { get; } = "DayCare";

            public static string VehicleSellOrLease { get; } = "VehicleSellOrLease";

            public static string Salvage { get; } = "Salvage";

            public static string ServiceAccess { get; } = "ServiceAccess";

            public static string Ammonia { get; } = "Ammonia";

            public static string Poison { get; } = "Poison";

            public static string Radioactive { get; } = "Radioactive";

            public static string EmergencyResponse { get; } = "EmergencyResponse";

            public static string CaliOperatingAuth { get; } = "CaliOperatingAuth";

            public static string CaliCarrierNumber { get; } = "CaliCarrier#";

            public static string PUC { get; } = "PUC";

            public static string NonOwnedGoods { get; } = "NonOwnedGoods";

            public static string stringerchangeAgreements { get; } = "stringerchangeAgreements";

            public static string MotorCarrierFiling { get; } = "MotorCarrierFiling";

            public static string TXAuth { get; } = "TXAuth";

            public static string OwnerOperatorsPendingVehicles { get; } = "OwnerOperatorsPendingVehicles";

            public static string OwnerOperatorsPendingVehiclesCost { get; } = "OwnerOperatorsPendingVehiclesCost";

            public static string OwnerOperatorsBorrowCost { get; } = "OwnerOperatorsBorrowCost";

            public static string HoldHarmlessAgreements { get; } = "HoldHarmlessAgreements";

            public static string HoldHarmlessRequireCerts { get; } = "HoldHarmlessRequireCerts";

            public static string FmscaOperating { get; } = "FmscaOperating";

            public static string FmscaOperatingTypes { get; } = "FmscaOperatingTypes";

            public static string TrailerInterchangeAgreements { get; } = "TrailerInterchangeAgreements";

            public static string HaulIntermodal { get; } = "HaulIntermodal";

            public static string DynamicVehicleMoratorium { get; } = "DynamicVehicleMoratorium";

            public static string SubmitProofOfInsuranceClaimsHistory { get; } = "SubmitProofOfInsuranceClaimsHistory";

            #endregion Operations

            #region Vehicles

            public static string Vehicles { get; } = "Vehicles";

            public static string DefaultVehicleClassCode { get; } = "DefaultVehicleClassCode";

            public static string VehicleParkingAddrsIn { get; } = "VehicleParkingAddrsIn";

            public static string TrailerParkingAddrsIn { get; } = "TrailerParkingAddrsIn";

            public static string PlowingSnow { get; } = "PlowingSnow";

            public static string TransportTours { get; } = "TransportTours";

            public static string VehicleOwnedLeasedFinanced { get; } = "VehicleOwnedLeasedFinanced";

            public static string VehicleTitleOwner { get; } = "VehicleTitleOwner";

            public static string VehicleOwner1BusinessName { get; } = "VehicleOwner1BusinessName";

            public static string VehicleTitleOwnerIndividual { get; } = "VehicleTitleOwnerIndividual";

            public static string VehicleDiffState { get; } = "VehicleDiffState";

            public static string VehicleUse { get; } = "VehicleUse";

            public static string VehicleUseRetail { get; } = "VehicleUseRetail";

            public static string GoodsOrMaterialsRetail { get; } = "GoodsOrMaterialsRetail";

            public static string GoodsOrMaterialsBlueCollar { get; } = "GoodsOrMaterialsBlueCollar";

            public static string TrailerOwnedFinancedLeased { get; } = "TrailerOwnedFinancedLeased";

            public static string TrailerDiffState { get; } = "TrailerDiffState";

            public static string TrailerTitleOwner { get; } = "TrailerTitleOwner";

            public static string VehicleOwner1Address { get; } = "VehicleOwner1Address";

            public static string TrailerOwner1BusinessName { get; } = "TrailerOwner1BusinessName";

            public static string TrailerOwner1Address { get; } = "TrailerOwner1Address";
            public static string VehicleLienholder1FirstName { get; } = "VehicleLienholder1FirstName";
            public static string VehicleLienholder1Address { get; } = "VehicleLienholder1Address";

            public static string VehicleLessorName { get; } = "VehicleLessorName";

            public static string VehicleLessorAddress { get; } = "VehicleLessorAddress";


            #endregion Vehicles

            #region Drivers

            public static string ExcludeDriver { get; } = "ExcludeDriver";

            public static string AccidentOrViolation { get; } = "AccidentOrViolation";

            public static string IL_DefensiveDriving { get; } = "IL-DefensiveDriving";

            public static string IL_LastYearViolation { get; } = "IL-LastYearViolation";

            public static string IL_Last3YearsLicenseSuspended { get; } = "IL-Last3YearsLicenseSuspended";

            public static string CDL { get; } = "CDL";

            public static string DefensiveDriving { get; } = "DefensiveDriving";

            #endregion Drivers

            #region Policy Coverage

            #region Cargo Coverage

            public static string IncludeCargoTheftCoverage { get; } = "IncludeCargoTheftCoverage";

            public static string IncludeCargoNamedPerilsCoverage { get; } = "IncludeCargoNamedPerilsCoverage";

            public static string IncludeEarnedFreightCoverage { get; } = "IncludeEarnedFreightCoverage";

            #endregion Cargo Coverage

            #region Rental Reimbursement

            public static string RentalDowntimeIncluded { get; } = "RentalDowntimeIncluded";

            #endregion Rental Reimbursement

            #region In-Tow

            public static string CustomerCargoCoverage { get; } = "CustomerCargoCoverage";

            #endregion In-Tow

            #endregion Policy Coverage

            #region Additional Interest
            public static string AdditionalInterestContactUpdated { get; } = "AdditionalInterestContactUpdated";
            public static string AdditionalInterests { get; } = "AdditionalInterests";
            public static string AdditionalInterestName { get; } = "AdditionalInterestName";
            public static string AdditionalInterestAddress { get; } = "AdditionalInterestAddress";
            public static string AdditionalInterestCertificateHolderNotice { get; } = "AdditionalInterestCertificateHolderNotice";

            #endregion Additional Interest


            #region Prior Claims
            public static string DateOfLoss { get; } = "DateOfLoss";
            public static string ClaimDesc { get; } = "ClaimDesc";
            public static string EstimatedCost { get; } = "EstimatedCost";

            #endregion Prior Claims


            #region Locations & buildings
            public static string BuildingLocationAddress { get; } = "BuildingLocationAddress";
            public static string Buildings { get; } = "Buildings";
            public static string CarbonMonoxideDetector { get; } = "CarbonMonoxideDetector";
            public static string SmokeFireDetector { get; } = "SmokeFireDetector";
            public static string BusinessOccupiedUnits { get; } = "BusinessOccupiedUnits";
            public static string CondoTownAssociationName { get; } = "CondoTownAssociationName";
            public static string CondoCoopUnitNumber { get; } = "CondoCoopUnitNumber";
            public static string IsOrgACoop { get; } = "IsOrgACoop";
            public static string CommercialOccupantPercent { get; } = "CommercialOccupantPercent";
            public static string InsuranceTrusteeName { get; } = "InsuranceTrusteeName";
            public static string UCIOActAssociation { get; } = "UCIOActAssociation";
            public static string AssociationCreated1Jan1991 { get; } = "AssociationCreated1Jan1991";
            public static string AssociationCreated29Oct1990 { get; } = "AssociationCreated29Oct1990";
            public static string AssociationCreated7Aug1985 { get; } = "AssociationCreated7Aug1985";
            public static string AssociationCreated1Jan1984 { get; } = "AssociationCreated1Jan1984";
            public static string AssociationCreated1Jul1991 { get; } = "AssociationCreated1Jul1991";
            public static string AssociationCreated1Jun1994 { get; } = "AssociationCreated1Jun1994";
            public static string AssociationCreated28Sep1983 { get; } = "AssociationCreated28Sep1983";
            public static string AssociationCreated1Oct1986 { get; } = "AssociationCreated1Oct1986";
            public static string AssociationCreated1Jul1900 { get; } = "AssociationCreated1Jul1900";
            public static string CarWashFullServeBayNumber { get; } = "CarWashFullServeBayNumber";
            public static string BylawsConformCurrentStateAct { get; } = "BylawsConformCurrentStateAct";
            public static string StudentUnitRentPercent { get; } = "StudentUnitRentPercent";
            public static string CarWashSelfServeBayNumber { get; } = "CarWashSelfServeBayNumber";
            public static string BuildingIncludeApartments { get; } = "BuildingIncludeApartments";
            public static string SemiAnnualFireSystemDuctContractNotRestaurant { get; } = "SemiAnnualFireSystemDuctContractNotRestaurant";
            public static string DanceCoverAlcoholKitchClosedNotRestaurant { get; } = "DanceCoverAlcoholKitchClosedNotRestaurant";
            public static string SemiAnnualFireSystemDuctContractRestaurant { get; } = "SemiAnnualFireSystemDuctContractRestaurant";
            public static string BarAlcoholOnPremise { get; } = "BarAlcoholOnPremise";
            public static string DanceCoverAlcoholKitchClosedRestaurant { get; } = "DanceCoverAlcoholKitchClosedRestaurant";
            public static string PremisePoolHotTub { get; } = "PremisePoolHotTub";
            public static string BusinessTenantOccupyNumber1 { get; } = "BusinessTenantOccupyNumber1";
            public static string CoverageEntireBuilding { get; } = "CoverageEntireBuilding";
            public static string BuildingSqFt { get; } = "BuildingSqFt";
            public static string BusinessSqFt { get; } = "BusinessSqFt";
            public static string BuildingFinancialInterest { get; } = "BuildingFinancialInterest";
            public static string HurricaneResistGlass { get; } = "HurricaneResistGlass";
            public static string GuestRoomNumber { get; } = "GuestRoomNumber";
            public static string AvgDailyRate { get; } = "AvgDailyRate";
            public static string GrossSales12MonthExcludeGuestRooms { get; } = "GrossSales12MonthExcludeGuestRooms";
            public static string PlaygroundAreas { get; } = "PlaygroundAreas";
            public static string BuildingPoolNumber { get; } = "BuildingPoolNumber";
            public static string GuestRoomEntrancesOnExterior { get; } = "GuestRoomEntrancesOnExterior";
            public static string BuildingStoriesNumber { get; } = "BuildingStoriesNumber";
            public static string BuildingYearBuilt { get; } = "BuildingYearBuilt";
            public static string RoofUpdated25Years { get; } = "RoofUpdated25Years";
            public static string BuildingConstructed { get; } = "BuildingConstructed";
            public static string BuildingOccupiedConstructed { get; } = "BuildingOccupiedConstructed";
            public static string BuildingResidentUnitNumber { get; } = "BuildingResidentUnitNumber";
            public static string PropertyLeadAbatement { get; } = "PropertyLeadAbatement";
            public static string LeadCertificateType { get; } = "LeadCertificateType";
            public static string BuildingRegisteredMDDeptofEng { get; } = "BuildingRegisteredMDDeptofEng";
            public static string UnitsObtainedLeadControlNumber { get; } = "UnitsObtainedLeadControlNumber";
            public static string UnitsObtainedLeadComplianceNumber { get; } = "UnitsObtainedLeadComplianceNumber";
            public static string CookingGreaseSmokeVapors { get; } = "CookingGreaseSmokeVapors";
            public static string ClosedHealthCode5Years { get; } = "ClosedHealthCode5Years";
            #endregion Locations & buildings


        }
    }
}