using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ApolloTests.Data.EntityBuilder.QuestionAnswers.QuestionAnswer;

namespace ApolloTests.Data.EntityBuilder.QuestionAnswers
{
    public class RiskAnswers : AnswersBase
    {
        #region Driver
        public QuestionAnswer ExcludeDriver { get; set; } = new QuestionAnswer(Alias.ExcludeDriver, "false");

        public QuestionAnswer AccidentOrViolation { get; set; } = new QuestionAnswer(Alias.AccidentOrViolation, "false");

        public QuestionAnswer IL_DefensiveDriving { get; set; } = new QuestionAnswer(Alias.IL_DefensiveDriving, "true");

        public QuestionAnswer IL_LastYearViolation { get; set; } = new QuestionAnswer(Alias.IL_LastYearViolation, "false");

        public QuestionAnswer IL_Last3YearsLicenseSuspended { get; set; } = new QuestionAnswer(Alias.IL_Last3YearsLicenseSuspended, "false");

        public QuestionAnswer CDL { get; set; } = new QuestionAnswer(Alias.CDL, "0");

        public QuestionAnswer DefensiveDriving { get; set; } = new QuestionAnswer(Alias.DefensiveDriving, "false");

        
        #endregion

        #region Vehicle
        [HydratorAttr(typeof(HydratorUtil), "CurrentEntity", AsJsonStr =true)]
        public QuestionAnswer Vehicles { get; set; } = new QuestionAnswer(Alias.Vehicles, "TBD");
        [HydratorAttr("ClassCode")]
        public QuestionAnswer DefaultVehicleClassCode { get; set; } = new QuestionAnswer(Alias.DefaultVehicleClassCode, "TBD", true);
        [HydratorAttr("StateCode")]
        public QuestionAnswer VehicleParkingAddrsIn { get; set; } = new QuestionAnswer(Alias.VehicleParkingAddrsIn, "TBD", true);
        [HydratorAttr("StateCode")]
        public QuestionAnswer TrailerParkingAddrsIn { get; set; } = new QuestionAnswer(Alias.TrailerParkingAddrsIn, "TBD", true);

        public QuestionAnswer PlowingSnow { get; set; } = new QuestionAnswer(Alias.PlowingSnow, "false");

        public QuestionAnswer TransportTours { get; set; } = new QuestionAnswer(Alias.TransportTours, "false");

        public QuestionAnswer VehicleOwnedLeasedFinanced { get; set; } = new QuestionAnswer(Alias.VehicleOwnedLeasedFinanced, "Owned");

        public QuestionAnswer VehicleTitleOwner { get; set; } = new QuestionAnswer(Alias.VehicleTitleOwner, "Business");

        public QuestionAnswer VehicleOwner1BusinessName { get; set; } = new QuestionAnswer(Alias.VehicleOwner1BusinessName, "Miguel Acosta");

        public QuestionAnswer VehicleTitleOwnerIndividual { get; set; } = new QuestionAnswer(Alias.VehicleTitleOwnerIndividual, "Myself");

        public QuestionAnswer VehicleDiffState { get; set; } = new QuestionAnswer(Alias.VehicleDiffState, "false");

        public QuestionAnswer VehicleUse { get; set; } = new QuestionAnswer(Alias.VehicleUse, "Delivery/Catering");

        public QuestionAnswer VehicleUseRetail { get; set; } = new QuestionAnswer(Alias.VehicleUseRetail, "Delivery/Catering");

        public QuestionAnswer GoodsOrMaterialsRetail { get; set; } = new QuestionAnswer(Alias.GoodsOrMaterialsRetail, "true");

        public QuestionAnswer GoodsOrMaterialsBlueCollar { get; set; } = new QuestionAnswer(Alias.GoodsOrMaterialsBlueCollar, "true");

        public QuestionAnswer TrailerOwner1BusinessName { get; set; } = new QuestionAnswer(Alias.TrailerOwner1BusinessName, "Miguel Acosta");

        public QuestionAnswer TrailerOwnedFinancedLeased { get; set; } = new QuestionAnswer(Alias.TrailerOwnedFinancedLeased, "Owned");

        public QuestionAnswer TrailerDiffState { get; set; } = new QuestionAnswer(Alias.TrailerDiffState, "false");

        public QuestionAnswer TrailerTitleOwner { get; set; } = new QuestionAnswer(Alias.TrailerTitleOwner, "Business");

        //[HydratorAttr(true)]
        public QuestionAnswer TrailerOwner1Address { get; set; } = new QuestionAnswer(Alias.TrailerOwner1Address, "{\"line1\":\"81 N 13th St\",\"line2\":null,\"minorMunicipality\":null,\"majorMunicipality\":\"Prospect Park\",\"postalCode\":\"07508\",\"addressTypeId\":300,\"addressType\":{\"code\":\"LOCATION\",\"name\":\"Location\",\"description\":null,\"timeFrom\":\"1901-01-01T00:00:00.000Z\",\"timeTo\":\"2999-01-01T00:00:00.000Z\",\"statusId\":0,\"updateDateTime\":\"2021-05-05T03:53:36.930Z\",\"updatedBy\":\"bbadmin\",\"updatedByPersonId\":null,\"insertDateTime\":\"2021-04-14T23:52:01.286Z\",\"insertedBy\":\"bbadmin\",\"insertedByPersonId\":-1,\"id\":300,\"resource\":\"LookupResource\"},\"stateProvinceId\":200,\"stateProvince\":{\"code\":\"NJ\",\"name\":\"New Jersey\",\"description\":null,\"statusId\":0,\"updatedBy\":null,\"updatedByPersonId\":null,\"insertDateTime\":\"0001-01-01T00:00:00.000Z\",\"insertedBy\":null,\"insertedByPersonId\":0,\"id\":200,\"resource\":\"StateProvinceResource\"},\"countryId\":0,\"country\":{\"code\":\"USA\",\"name\":\"United States\",\"description\":null,\"statusId\":0,\"updatedBy\":null,\"updatedByPersonId\":null,\"insertDateTime\":\"0001-01-01T00:00:00.000Z\",\"insertedBy\":null,\"insertedByPersonId\":0,\"id\":0,\"resource\":\"CountryResource\"},\"countyName\":\"Passaic\",\"countyFips\":\"34031\",\"smartyStreetDocumentId\":17410,\"smartyStreetDocumentIndex\":0,\"logicId\":null,\"version\":null,\"statusId\":0,\"updatedBy\":null,\"updatedByPersonId\":null,\"insertDateTime\":\"0001-01-01T00:00:00.000Z\",\"insertedBy\":null,\"insertedByPersonId\":0,\"resource\":\"AddressResource\"}");

        //[HydratorAttr(true)]
        public QuestionAnswer VehicleOwner1Address { get; set; } = new QuestionAnswer(Alias.VehicleOwner1Address, "{\"line1\":\"81 N 13th St\",\"line2\":null,\"minorMunicipality\":null,\"majorMunicipality\":\"Prospect Park\",\"postalCode\":\"07508\",\"addressTypeId\":300,\"addressType\":{\"code\":\"LOCATION\",\"name\":\"Location\",\"description\":null,\"timeFrom\":\"1901-01-01T00:00:00.000Z\",\"timeTo\":\"2999-01-01T00:00:00.000Z\",\"statusId\":0,\"updateDateTime\":\"2021-05-05T03:53:36.930Z\",\"updatedBy\":\"bbadmin\",\"updatedByPersonId\":null,\"insertDateTime\":\"2021-04-14T23:52:01.286Z\",\"insertedBy\":\"bbadmin\",\"insertedByPersonId\":-1,\"id\":300,\"resource\":\"LookupResource\"},\"stateProvinceId\":200,\"stateProvince\":{\"code\":\"NJ\",\"name\":\"New Jersey\",\"description\":null,\"statusId\":0,\"updatedBy\":null,\"updatedByPersonId\":null,\"insertDateTime\":\"0001-01-01T00:00:00.000Z\",\"insertedBy\":null,\"insertedByPersonId\":0,\"id\":200,\"resource\":\"StateProvinceResource\"},\"countryId\":0,\"country\":{\"code\":\"USA\",\"name\":\"United States\",\"description\":null,\"statusId\":0,\"updatedBy\":null,\"updatedByPersonId\":null,\"insertDateTime\":\"0001-01-01T00:00:00.000Z\",\"insertedBy\":null,\"insertedByPersonId\":0,\"id\":0,\"resource\":\"CountryResource\"},\"countyName\":\"Passaic\",\"countyFips\":\"34031\",\"smartyStreetDocumentId\":17410,\"smartyStreetDocumentIndex\":0,\"logicId\":null,\"version\":null,\"statusId\":0,\"updatedBy\":null,\"updatedByPersonId\":null,\"insertDateTime\":\"0001-01-01T00:00:00.000Z\",\"insertedBy\":null,\"insertedByPersonId\":0,\"resource\":\"AddressResource\"}");

        public QuestionAnswer VehicleLienholder1FirstName { get; set; } = new QuestionAnswer(Alias.VehicleLienholder1FirstName, "Lien Holder first name AUT");

        //[HydratorAttr(true)]
        public QuestionAnswer VehicleLienholder1Address { get; set; } = new QuestionAnswer(Alias.VehicleLienholder1Address, "{\"line1\":\"81 N 13th St\",\"line2\":null,\"minorMunicipality\":null,\"majorMunicipality\":\"Prospect Park\",\"postalCode\":\"07508\",\"addressTypeId\":300,\"addressType\":{\"code\":\"LOCATION\",\"name\":\"Location\",\"description\":null,\"timeFrom\":\"1901-01-01T00:00:00.000Z\",\"timeTo\":\"2999-01-01T00:00:00.000Z\",\"statusId\":0,\"updateDateTime\":\"2021-05-05T03:53:36.930Z\",\"updatedBy\":\"bbadmin\",\"updatedByPersonId\":null,\"insertDateTime\":\"2021-04-14T23:52:01.286Z\",\"insertedBy\":\"bbadmin\",\"insertedByPersonId\":-1,\"id\":300,\"resource\":\"LookupResource\"},\"stateProvinceId\":200,\"stateProvince\":{\"code\":\"NJ\",\"name\":\"New Jersey\",\"description\":null,\"statusId\":0,\"updatedBy\":null,\"updatedByPersonId\":null,\"insertDateTime\":\"0001-01-01T00:00:00.000Z\",\"insertedBy\":null,\"insertedByPersonId\":0,\"id\":200,\"resource\":\"StateProvinceResource\"},\"countryId\":0,\"country\":{\"code\":\"USA\",\"name\":\"United States\",\"description\":null,\"statusId\":0,\"updatedBy\":null,\"updatedByPersonId\":null,\"insertDateTime\":\"0001-01-01T00:00:00.000Z\",\"insertedBy\":null,\"insertedByPersonId\":0,\"id\":0,\"resource\":\"CountryResource\"},\"countyName\":\"Passaic\",\"countyFips\":\"34031\",\"smartyStreetDocumentId\":17410,\"smartyStreetDocumentIndex\":0,\"logicId\":null,\"version\":null,\"statusId\":0,\"updatedBy\":null,\"updatedByPersonId\":null,\"insertDateTime\":\"0001-01-01T00:00:00.000Z\",\"insertedBy\":null,\"insertedByPersonId\":0,\"resource\":\"AddressResource\"}");

        public QuestionAnswer VehicleLessorName { get; set; } = new QuestionAnswer(Alias.VehicleLessorName, "Vehicle lessor name AUT");

        //[HydratorAttr(true)]
        public QuestionAnswer VehicleLessorAddress { get; set; } = new QuestionAnswer(Alias.VehicleLessorAddress, "{\"line1\":\"81 N 13th St\",\"line2\":null,\"minorMunicipality\":null,\"majorMunicipality\":\"Prospect Park\",\"postalCode\":\"07508\",\"addressTypeId\":300,\"addressType\":{\"code\":\"LOCATION\",\"name\":\"Location\",\"description\":null,\"timeFrom\":\"1901-01-01T00:00:00.000Z\",\"timeTo\":\"2999-01-01T00:00:00.000Z\",\"statusId\":0,\"updateDateTime\":\"2021-05-05T03:53:36.930Z\",\"updatedBy\":\"bbadmin\",\"updatedByPersonId\":null,\"insertDateTime\":\"2021-04-14T23:52:01.286Z\",\"insertedBy\":\"bbadmin\",\"insertedByPersonId\":-1,\"id\":300,\"resource\":\"LookupResource\"},\"stateProvinceId\":200,\"stateProvince\":{\"code\":\"NJ\",\"name\":\"New Jersey\",\"description\":null,\"statusId\":0,\"updatedBy\":null,\"updatedByPersonId\":null,\"insertDateTime\":\"0001-01-01T00:00:00.000Z\",\"insertedBy\":null,\"insertedByPersonId\":0,\"id\":200,\"resource\":\"StateProvinceResource\"},\"countryId\":0,\"country\":{\"code\":\"USA\",\"name\":\"United States\",\"description\":null,\"statusId\":0,\"updatedBy\":null,\"updatedByPersonId\":null,\"insertDateTime\":\"0001-01-01T00:00:00.000Z\",\"insertedBy\":null,\"insertedByPersonId\":0,\"id\":0,\"resource\":\"CountryResource\"},\"countyName\":\"Passaic\",\"countyFips\":\"34031\",\"smartyStreetDocumentId\":17410,\"smartyStreetDocumentIndex\":0,\"logicId\":null,\"version\":null,\"statusId\":0,\"updatedBy\":null,\"updatedByPersonId\":null,\"insertDateTime\":\"0001-01-01T00:00:00.000Z\",\"insertedBy\":null,\"insertedByPersonId\":0,\"resource\":\"AddressResource\"}");

        public QuestionAnswer VehicleSeatCount { get; set; } = new QuestionAnswer(Alias.VehicleSeatCount, "4");

        #endregion

        #region Location & Building
        [HydratorAttr("AddressObject", true)]
        public QuestionAnswer BuildingLocationAddress { get; set; } = new QuestionAnswer(Alias.BuildingLocationAddress, null);

        [HydratorAttr(typeof(HydratorUtil), "CurrentEntity", AsJsonStr = true)]
        public QuestionAnswer Buildings { get; set; } = new QuestionAnswer(Alias.Buildings, null);
        public QuestionAnswer CarbonMonoxideDetector { get; set; } = new QuestionAnswer(Alias.CarbonMonoxideDetector, "true");
        public QuestionAnswer SmokeFireDetector { get; set; } = new QuestionAnswer(Alias.SmokeFireDetector, "true");
        public QuestionAnswer BusinessOccupiedUnits { get; set; } = new QuestionAnswer(Alias.BusinessOccupiedUnits, "true");
        public QuestionAnswer CondoTownAssociationName { get; set; } = new QuestionAnswer(Alias.CondoTownAssociationName, "none");
        public QuestionAnswer CondoCoopUnitNumber { get; set; } = new QuestionAnswer(Alias.CondoCoopUnitNumber, "0");
        public QuestionAnswer IsOrgACoop { get; set; } = new QuestionAnswer(Alias.IsOrgACoop, "false");
        public QuestionAnswer CommercialOccupantPercent { get; set; } = new QuestionAnswer(Alias.CommercialOccupantPercent, "100");
        public QuestionAnswer InsuranceTrusteeName { get; set; } = new QuestionAnswer(Alias.InsuranceTrusteeName, "none");
        public QuestionAnswer UCIOActAssociation { get; set; } = new QuestionAnswer(Alias.UCIOActAssociation, "false");
        public QuestionAnswer AssociationCreated1Jan1991 { get; set; } = new QuestionAnswer(Alias.AssociationCreated1Jan1991, "false");
        public QuestionAnswer AssociationCreated29Oct1990 { get; set; } = new QuestionAnswer(Alias.AssociationCreated29Oct1990, "false");
        public QuestionAnswer AssociationCreated7Aug1985 { get; set; } = new QuestionAnswer(Alias.AssociationCreated7Aug1985, "false");
        public QuestionAnswer AssociationCreated1Jan1984 { get; set; } = new QuestionAnswer(Alias.AssociationCreated1Jan1984, "false");
        public QuestionAnswer AssociationCreated1Jul1991 { get; set; } = new QuestionAnswer(Alias.AssociationCreated1Jul1991, "false");
        public QuestionAnswer AssociationCreated1Jun1994 { get; set; } = new QuestionAnswer(Alias.AssociationCreated1Jun1994, "false");
        public QuestionAnswer AssociationCreated28Sep1983 { get; set; } = new QuestionAnswer(Alias.AssociationCreated28Sep1983, "false");
        public QuestionAnswer AssociationCreated1Oct1986 { get; set; } = new QuestionAnswer(Alias.AssociationCreated1Oct1986, "false");
        public QuestionAnswer AssociationCreated1Jul1900 { get; set; } = new QuestionAnswer(Alias.AssociationCreated1Jul1900, "false");
        public QuestionAnswer CarWashFullServeBayNumber { get; set; } = new QuestionAnswer(Alias.CarWashFullServeBayNumber, "0");
        public QuestionAnswer BylawsConformCurrentStateAct { get; set; } = new QuestionAnswer(Alias.BylawsConformCurrentStateAct, "false");
        public QuestionAnswer StudentUnitRentPercent { get; set; } = new QuestionAnswer(Alias.StudentUnitRentPercent, "0");
        public QuestionAnswer CarWashSelfServeBayNumber { get; set; } = new QuestionAnswer(Alias.CarWashSelfServeBayNumber, "0");
        public QuestionAnswer BuildingIncludeApartments { get; set; } = new QuestionAnswer(Alias.BuildingIncludeApartments, "false");
        public QuestionAnswer SemiAnnualFireSystemDuctContractNotRestaurant { get; set; } = new QuestionAnswer(Alias.SemiAnnualFireSystemDuctContractNotRestaurant, "false");
        public QuestionAnswer DanceCoverAlcoholKitchClosedNotRestaurant { get; set; } = new QuestionAnswer(Alias.DanceCoverAlcoholKitchClosedNotRestaurant, "false");
        public QuestionAnswer SemiAnnualFireSystemDuctContractRestaurant { get; set; } = new QuestionAnswer(Alias.SemiAnnualFireSystemDuctContractRestaurant, "false");
        public QuestionAnswer BarAlcoholOnPremise { get; set; } = new QuestionAnswer(Alias.BarAlcoholOnPremise, "false");
        public QuestionAnswer DanceCoverAlcoholKitchClosedRestaurant { get; set; } = new QuestionAnswer(Alias.DanceCoverAlcoholKitchClosedRestaurant, "false");
        public QuestionAnswer PremisePoolHotTub { get; set; } = new QuestionAnswer(Alias.PremisePoolHotTub, "false");
        public QuestionAnswer BusinessTenantOccupyNumber1 { get; set; } = new QuestionAnswer(Alias.BusinessTenantOccupyNumber1, "1");
        public QuestionAnswer CoverageEntireBuilding { get; set; } = new QuestionAnswer(Alias.CoverageEntireBuilding, "false");
        public QuestionAnswer BuildingSqFt { get; set; } = new QuestionAnswer(Alias.BuildingSqFt, "1000");
        public QuestionAnswer BusinessSqFt { get; set; } = new QuestionAnswer(Alias.BusinessSqFt, "1000");
        public QuestionAnswer BuildingFinancialInterest { get; set; } = new QuestionAnswer(Alias.BuildingFinancialInterest, "OwnUnit");
        public QuestionAnswer HurricaneResistGlass { get; set; } = new QuestionAnswer(Alias.HurricaneResistGlass, "false");
        public QuestionAnswer GuestRoomNumber { get; set; } = new QuestionAnswer(Alias.GuestRoomNumber, "0");
        public QuestionAnswer AvgDailyRate { get; set; } = new QuestionAnswer(Alias.AvgDailyRate, "0");
        public QuestionAnswer GrossSales12MonthExcludeGuestRooms { get; set; } = new QuestionAnswer(Alias.GrossSales12MonthExcludeGuestRooms, "0");
        public QuestionAnswer PlaygroundAreas { get; set; } = new QuestionAnswer(Alias.PlaygroundAreas, "false");
        public QuestionAnswer BuildingPoolNumber { get; set; } = new QuestionAnswer(Alias.BuildingPoolNumber, "0");
        public QuestionAnswer GuestRoomEntrancesOnExterior { get; set; } = new QuestionAnswer(Alias.GuestRoomEntrancesOnExterior, "false");
        public QuestionAnswer BuildingStoriesNumber { get; set; } = new QuestionAnswer(Alias.BuildingStoriesNumber, "1");
        public QuestionAnswer BuildingYearBuilt { get; set; } = new QuestionAnswer(Alias.BuildingYearBuilt, "2015");
        public QuestionAnswer RoofUpdated25Years { get; set; } = new QuestionAnswer(Alias.RoofUpdated25Years, "true");
        public QuestionAnswer BuildingConstructed { get; set; } = new QuestionAnswer(Alias.BuildingConstructed, "Masonry");
        public QuestionAnswer BuildingOccupiedConstructed { get; set; } = new QuestionAnswer(Alias.BuildingOccupiedConstructed, "Masonry");
        public QuestionAnswer BuildingResidentUnitNumber { get; set; } = new QuestionAnswer(Alias.BuildingResidentUnitNumber, "0");
        public QuestionAnswer PropertyLeadAbatement { get; set; } = new QuestionAnswer(Alias.PropertyLeadAbatement, "true");
        public QuestionAnswer LeadCertificateType { get; set; } = new QuestionAnswer(Alias.LeadCertificateType, "LeadHazardFree");
        public QuestionAnswer BuildingRegisteredMDDeptofEng { get; set; } = new QuestionAnswer(Alias.BuildingRegisteredMDDeptofEng, "false");
        public QuestionAnswer UnitsObtainedLeadControlNumber { get; set; } = new QuestionAnswer(Alias.UnitsObtainedLeadControlNumber, "0");
        public QuestionAnswer UnitsObtainedLeadComplianceNumber { get; set; } = new QuestionAnswer(Alias.UnitsObtainedLeadComplianceNumber, "0");
        public QuestionAnswer CookingGreaseSmokeVapors { get; set; } = new QuestionAnswer(Alias.CookingGreaseSmokeVapors, "false");
        public QuestionAnswer ClosedHealthCode5Years { get; set; } = new QuestionAnswer(Alias.ClosedHealthCode5Years, "false");
        #endregion
    }
}
