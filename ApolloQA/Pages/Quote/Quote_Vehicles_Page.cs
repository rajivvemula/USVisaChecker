using ApolloQA.Source.Driver;

namespace ApolloQA.Pages
{
    class Quote_Vehicles_Page
    {
        public static Element VehicleOwnFinancedLeasedQuestion => new Element("//div[@class='question-text' and contains(text(), 'Is this vehicle:')]");

        // vehicle Owned 
        public static Element OwnedButton => new Element("//mat-radio-button//*[contains(text(), ' Owned ')]");
        public static Element WhoOwnsVehicleQuestion => new Element("//div[@class='question-text' and contains(text(), 'Who owns the vehicle title and registration:')]");
        public static Element BusinessOwnedButton => new Element("//mat-radio-button//*[contains(text(), ' The Business ')]");
        public static Element OneOrMoreOwnersButton => new Element("//mat-radio-button//*[contains(text(), ' One or more of the Business Owner(s) ')]");
        public static Element SomeoneElseOwnsButton => new Element("//mat-radio-button//*[contains(text(), ' Someone else ')]");
        public static Element NameOfOwnerFirstInput = new Element("(//input[@formcontrolname='response'])[1]");
        public static Element NameOfOwnerSecondInput = new Element("(//input[@formcontrolname='response'])[2]");

        // vehicle Financed
        public static Element FinancedButton => new Element("//mat-radio-button//*[contains(text(), ' Financed ')]");
        public static Element NameOfLienholderInput => new Element("//input[@formcontrolname='response']");

        // vehicle Leased
        public static Element LeasedButton => new Element("//mat-radio-button//*[contains(text(), ' Leased ')]");
        public static Element NameOfLessorInput => new Element("//input[@formcontrolname='response']");

        // add address
        public static Element AddAddressButton = new Element("//button[*[contains(text(), ' Add Address ')]]");
        public static Element AddressTypeDropdown = new Element("//mat-select[@name='addressTypeId']");
        public static Element StreetAddressOneInput => new Element("//input[@name='line1']");
        public static Element StreetAddressTwoInput => new Element("//input[@name='line2']");
        public static Element CityInput => new Element("//input[@name='city']");
        public static Element StateDropdown = new Element("//mat-select[@name='state']");
        public static Element ZipInput => new Element("//input[@name='postalCode']");
        public static Element CountryDropdown => new Element("//mat-select[@name='countryId']");

    }
}
