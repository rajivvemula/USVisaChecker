using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ApolloTests.Data.EntityBuilder.QuestionAnswers.QuestionAnswer;

namespace ApolloTests.Data.EntityBuilder.QuestionAnswers.PartyAnswers
{
    public class PartyAnswers_CA : AnswersBase
    {
        //typeID=3=blanket
        public QuestionAnswer AdditionalInterests { get; set; } = new QuestionAnswer(Alias.AdditionalInterests, "{\"additionalInterestTypeId\":3}");
        public QuestionAnswer AdditionalInterestName { get; set; } = new QuestionAnswer(Alias.AdditionalInterestName, "Addnl Interest Name Aut");
        //[HydratorAttr(true)]
        public QuestionAnswer AdditionalInterestAddress { get; set; } = new QuestionAnswer(Alias.AdditionalInterestAddress, "{\"line1\":\"81 N 13th St\",\"line2\":null,\"minorMunicipality\":null,\"majorMunicipality\":\"Prospect Park\",\"postalCode\":\"07508\",\"addressTypeId\":300,\"addressType\":{\"code\":\"LOCATION\",\"name\":\"Location\",\"description\":null,\"timeFrom\":\"1901-01-01T00:00:00.000Z\",\"timeTo\":\"2999-01-01T00:00:00.000Z\",\"statusId\":0,\"updateDateTime\":\"2021-05-05T03:53:36.930Z\",\"updatedBy\":\"bbadmin\",\"updatedByPersonId\":null,\"insertDateTime\":\"2021-04-14T23:52:01.286Z\",\"insertedBy\":\"bbadmin\",\"insertedByPersonId\":-1,\"id\":300,\"resource\":\"LookupResource\"},\"stateProvinceId\":200,\"stateProvince\":{\"code\":\"NJ\",\"name\":\"New Jersey\",\"description\":null,\"statusId\":0,\"updatedBy\":null,\"updatedByPersonId\":null,\"insertDateTime\":\"0001-01-01T00:00:00.000Z\",\"insertedBy\":null,\"insertedByPersonId\":0,\"id\":200,\"resource\":\"StateProvinceResource\"},\"countryId\":0,\"country\":{\"code\":\"USA\",\"name\":\"United States\",\"description\":null,\"statusId\":0,\"updatedBy\":null,\"updatedByPersonId\":null,\"insertDateTime\":\"0001-01-01T00:00:00.000Z\",\"insertedBy\":null,\"insertedByPersonId\":0,\"id\":0,\"resource\":\"CountryResource\"},\"countyName\":\"Passaic\",\"countyFips\":\"34031\",\"smartyStreetDocumentId\":17410,\"smartyStreetDocumentIndex\":0,\"logicId\":null,\"version\":null,\"statusId\":0,\"updatedBy\":null,\"updatedByPersonId\":null,\"insertDateTime\":\"0001-01-01T00:00:00.000Z\",\"insertedBy\":null,\"insertedByPersonId\":0,\"resource\":\"AddressResource\"}");
        public QuestionAnswer AdditionalInterestCertificateHolderNotice { get; set; } = new QuestionAnswer(Alias.AdditionalInterestCertificateHolderNotice, "true");

    }
}
