using static ApolloTests.Data.TestData.QuestionAnswer;

namespace ApolloTests.Data.TestData.Params
{
    public class VehicleQuentionAnswerParam : QuentionAnswerParamBase
    {
        public QuestionAnswer Vehicles { get; set; } = new QuestionAnswer(Alias.Vehicles, "@SectionEntity");
        public QuestionAnswer DefaultVehicleClassCode { get; set; } = new QuestionAnswer(Alias.DefaultVehicleClassCode, "TBD", true);
        public QuestionAnswer VehicleParkingAddrsIn { get; set; } = new QuestionAnswer(Alias.VehicleParkingAddrsIn, "TBD", true);
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

        public QuestionAnswer TrailerOwner1Address { get; set; } = new QuestionAnswer(Alias.TrailerOwner1Address, "JSON{\"line1\":\"81 N 13th St\",\"line2\":null,\"minorMunicipality\":null,\"majorMunicipality\":\"Prospect Park\",\"postalCode\":\"07508\",\"addressTypeId\":300,\"addressType\":{\"code\":\"LOCATION\",\"name\":\"Location\",\"description\":null,\"timeFrom\":\"1901-01-01T00:00:00.000Z\",\"timeTo\":\"2999-01-01T00:00:00.000Z\",\"statusId\":0,\"updateDateTime\":\"2021-05-05T03:53:36.930Z\",\"updatedBy\":\"bbadmin\",\"updatedByPersonId\":null,\"insertDateTime\":\"2021-04-14T23:52:01.286Z\",\"insertedBy\":\"bbadmin\",\"insertedByPersonId\":-1,\"id\":300,\"resource\":\"LookupResource\"},\"stateProvinceId\":200,\"stateProvince\":{\"code\":\"NJ\",\"name\":\"New Jersey\",\"description\":null,\"statusId\":0,\"updatedBy\":null,\"updatedByPersonId\":null,\"insertDateTime\":\"0001-01-01T00:00:00.000Z\",\"insertedBy\":null,\"insertedByPersonId\":0,\"id\":200,\"resource\":\"StateProvinceResource\"},\"countryId\":0,\"country\":{\"code\":\"USA\",\"name\":\"United States\",\"description\":null,\"statusId\":0,\"updatedBy\":null,\"updatedByPersonId\":null,\"insertDateTime\":\"0001-01-01T00:00:00.000Z\",\"insertedBy\":null,\"insertedByPersonId\":0,\"id\":0,\"resource\":\"CountryResource\"},\"countyName\":\"Passaic\",\"countyFips\":\"34031\",\"smartyStreetDocumentId\":17410,\"smartyStreetDocumentIndex\":0,\"logicId\":null,\"version\":null,\"statusId\":0,\"updatedBy\":null,\"updatedByPersonId\":null,\"insertDateTime\":\"0001-01-01T00:00:00.000Z\",\"insertedBy\":null,\"insertedByPersonId\":0,\"resource\":\"AddressResource\"}");

        public QuestionAnswer VehicleOwner1Address { get; set; } = new QuestionAnswer(Alias.VehicleOwner1Address, "JSON{\"line1\":\"81 N 13th St\",\"line2\":null,\"minorMunicipality\":null,\"majorMunicipality\":\"Prospect Park\",\"postalCode\":\"07508\",\"addressTypeId\":300,\"addressType\":{\"code\":\"LOCATION\",\"name\":\"Location\",\"description\":null,\"timeFrom\":\"1901-01-01T00:00:00.000Z\",\"timeTo\":\"2999-01-01T00:00:00.000Z\",\"statusId\":0,\"updateDateTime\":\"2021-05-05T03:53:36.930Z\",\"updatedBy\":\"bbadmin\",\"updatedByPersonId\":null,\"insertDateTime\":\"2021-04-14T23:52:01.286Z\",\"insertedBy\":\"bbadmin\",\"insertedByPersonId\":-1,\"id\":300,\"resource\":\"LookupResource\"},\"stateProvinceId\":200,\"stateProvince\":{\"code\":\"NJ\",\"name\":\"New Jersey\",\"description\":null,\"statusId\":0,\"updatedBy\":null,\"updatedByPersonId\":null,\"insertDateTime\":\"0001-01-01T00:00:00.000Z\",\"insertedBy\":null,\"insertedByPersonId\":0,\"id\":200,\"resource\":\"StateProvinceResource\"},\"countryId\":0,\"country\":{\"code\":\"USA\",\"name\":\"United States\",\"description\":null,\"statusId\":0,\"updatedBy\":null,\"updatedByPersonId\":null,\"insertDateTime\":\"0001-01-01T00:00:00.000Z\",\"insertedBy\":null,\"insertedByPersonId\":0,\"id\":0,\"resource\":\"CountryResource\"},\"countyName\":\"Passaic\",\"countyFips\":\"34031\",\"smartyStreetDocumentId\":17410,\"smartyStreetDocumentIndex\":0,\"logicId\":null,\"version\":null,\"statusId\":0,\"updatedBy\":null,\"updatedByPersonId\":null,\"insertDateTime\":\"0001-01-01T00:00:00.000Z\",\"insertedBy\":null,\"insertedByPersonId\":0,\"resource\":\"AddressResource\"}");
        
        public QuestionAnswer VehicleLienholder1FirstName { get; set; } = new QuestionAnswer(Alias.VehicleLienholder1FirstName, "Lien Holder first name AUT");
        
        public QuestionAnswer VehicleLienholder1Address { get; set; } = new QuestionAnswer(Alias.VehicleLienholder1Address, "JSON{\"line1\":\"81 N 13th St\",\"line2\":null,\"minorMunicipality\":null,\"majorMunicipality\":\"Prospect Park\",\"postalCode\":\"07508\",\"addressTypeId\":300,\"addressType\":{\"code\":\"LOCATION\",\"name\":\"Location\",\"description\":null,\"timeFrom\":\"1901-01-01T00:00:00.000Z\",\"timeTo\":\"2999-01-01T00:00:00.000Z\",\"statusId\":0,\"updateDateTime\":\"2021-05-05T03:53:36.930Z\",\"updatedBy\":\"bbadmin\",\"updatedByPersonId\":null,\"insertDateTime\":\"2021-04-14T23:52:01.286Z\",\"insertedBy\":\"bbadmin\",\"insertedByPersonId\":-1,\"id\":300,\"resource\":\"LookupResource\"},\"stateProvinceId\":200,\"stateProvince\":{\"code\":\"NJ\",\"name\":\"New Jersey\",\"description\":null,\"statusId\":0,\"updatedBy\":null,\"updatedByPersonId\":null,\"insertDateTime\":\"0001-01-01T00:00:00.000Z\",\"insertedBy\":null,\"insertedByPersonId\":0,\"id\":200,\"resource\":\"StateProvinceResource\"},\"countryId\":0,\"country\":{\"code\":\"USA\",\"name\":\"United States\",\"description\":null,\"statusId\":0,\"updatedBy\":null,\"updatedByPersonId\":null,\"insertDateTime\":\"0001-01-01T00:00:00.000Z\",\"insertedBy\":null,\"insertedByPersonId\":0,\"id\":0,\"resource\":\"CountryResource\"},\"countyName\":\"Passaic\",\"countyFips\":\"34031\",\"smartyStreetDocumentId\":17410,\"smartyStreetDocumentIndex\":0,\"logicId\":null,\"version\":null,\"statusId\":0,\"updatedBy\":null,\"updatedByPersonId\":null,\"insertDateTime\":\"0001-01-01T00:00:00.000Z\",\"insertedBy\":null,\"insertedByPersonId\":0,\"resource\":\"AddressResource\"}");
        
        public QuestionAnswer VehicleLessorName { get; set; } = new QuestionAnswer(Alias.VehicleLessorName, "Vehicle lessor name AUT");
       
        public QuestionAnswer VehicleLessorAddress { get; set; } = new QuestionAnswer(Alias.VehicleLessorAddress, "JSON{\"line1\":\"81 N 13th St\",\"line2\":null,\"minorMunicipality\":null,\"majorMunicipality\":\"Prospect Park\",\"postalCode\":\"07508\",\"addressTypeId\":300,\"addressType\":{\"code\":\"LOCATION\",\"name\":\"Location\",\"description\":null,\"timeFrom\":\"1901-01-01T00:00:00.000Z\",\"timeTo\":\"2999-01-01T00:00:00.000Z\",\"statusId\":0,\"updateDateTime\":\"2021-05-05T03:53:36.930Z\",\"updatedBy\":\"bbadmin\",\"updatedByPersonId\":null,\"insertDateTime\":\"2021-04-14T23:52:01.286Z\",\"insertedBy\":\"bbadmin\",\"insertedByPersonId\":-1,\"id\":300,\"resource\":\"LookupResource\"},\"stateProvinceId\":200,\"stateProvince\":{\"code\":\"NJ\",\"name\":\"New Jersey\",\"description\":null,\"statusId\":0,\"updatedBy\":null,\"updatedByPersonId\":null,\"insertDateTime\":\"0001-01-01T00:00:00.000Z\",\"insertedBy\":null,\"insertedByPersonId\":0,\"id\":200,\"resource\":\"StateProvinceResource\"},\"countryId\":0,\"country\":{\"code\":\"USA\",\"name\":\"United States\",\"description\":null,\"statusId\":0,\"updatedBy\":null,\"updatedByPersonId\":null,\"insertDateTime\":\"0001-01-01T00:00:00.000Z\",\"insertedBy\":null,\"insertedByPersonId\":0,\"id\":0,\"resource\":\"CountryResource\"},\"countyName\":\"Passaic\",\"countyFips\":\"34031\",\"smartyStreetDocumentId\":17410,\"smartyStreetDocumentIndex\":0,\"logicId\":null,\"version\":null,\"statusId\":0,\"updatedBy\":null,\"updatedByPersonId\":null,\"insertDateTime\":\"0001-01-01T00:00:00.000Z\",\"insertedBy\":null,\"insertedByPersonId\":0,\"resource\":\"AddressResource\"}");
    }
}