using ApolloQA.Source.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages
{
    class Quote_Additional_Interests_Page
    {
        public static Element AddlInterestTypeDropdown = new Element("//mat-select[@formcontrolname='additionalInterestTypeId']");
        public static Element PartyTypeIndividualButton = new Element("//mat-radio-button[//*[contains(text(), 'Individual')]]");
        public static Element PartyTypeOrgButton = new Element("//mat-radio-button //*[contains(text(), 'Organization')]");
        public static Element IndividFirstNameInput = new Element("//input[@name='firstName']");
        public static Element IndividMiddleNameInput = new Element("//input[@name='middleName']");
        public static Element IndividLastNameInput = new Element("//input[@name='lastName']");
        public static Element IndividSuffixNameInput = new Element("//input[@name='suffix']");
        public static Element OrgNameInput = new Element("//input[@data-placeholder='Organization Name']");
        public static Element OrgAltNameInput = new Element("//input[@name='altName']");
        public static Element Address1Input = new Element("//input[@name='line1']");
        public static Element Address2Input = new Element("//input[@name='line2']");
        public static Element CityInput = new Element("//input[@name='city']");
        public static Element StateDropdown = new Element("//mat-select[@name='state']");
        public static Element ZipInput = new Element("//input[@name='postalCode']");
        public static Element VerifyAddressButton = new Element("//button[contains(text(), 'Verify Address')]");
        public static Element PhoneInput = new Element("//input[@formcontrolname='phone']");
        public static Element EmailInput = new Element("//input[@name='email']");
        public static Element DescriptionInput = new Element("//textarea[@name='description']");

    }
}
