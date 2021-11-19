namespace ApolloQA.Data.TestData
{
    public class QuestionAnswer
    {
        public readonly string _alias;

        public string _response;

        public QuestionAnswer(string alias, string response)
        {
            _alias = alias;
            _response = response;
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

            #endregion Operations

            #region Vehicles

            public static string Vehicles { get; } = "Vehicles";

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

            #endregion Vehicles

            #region Drivers

            public static string ExcludeDriver { get; } = "ExcludeDriver";

            public static string AccidentOrViolation { get; } = "AccidentOrViolation";

            public static string IL_DefensiveDriving { get; } = "IL_DefensiveDriving";

            public static string IL_LastYearViolation { get; } = "IL_LastYearViolation";

            public static string IL_Last3YearsLicenseSuspended { get; } = "IL_Last3YearsLicenseSuspended";

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
        }
    }
}