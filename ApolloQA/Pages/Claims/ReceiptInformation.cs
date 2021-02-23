using ApolloQA.Source.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages
{
    class ReceiptInformation
    {
        public static Element FirstPartyButton = new Element("//mat-radio-button//*[contains(text(), ' First Party ')]");
        public static Element ThirdPartyButton = new Element("//mat-radio-button//*[contains(text(), ' Third Party ')]");
        public static Element BodilyInjuryButton = new Element("//mat-radio-button//*[contains(text(), ' Bodily Injury ')]");
        public static Element PropertyDamageButton = new Element("//mat-radio-button//*[contains(text(), ' Property Damage ')]");
        public static Element HowReceivedDropdown = new Element("//mat-select[@name='receivedTypeId']");
        public static Element FirstNameInput = new Element("//input[@name='firstName']");
        public static Element LastNameInput = new Element("//input[@name='lastName']");
        public static Element PhoneNumberInput = new Element("//input[@name='phone']");
        public static Element EmailInput = new Element("//input[@name='personEmail']");
        public static Element StreetAddress1Input = new Element("//input[@name='line1']");
        public static Element CityInput = new Element("//input[@name='city']");
        public static Element StateDropdown = new Element("//mat-select[@name='state']");
        public static Element ZipInput = new Element("//input[@name='postalCode']");
        public static Element SameAsReportedButton = new Element("//mat-checkbox[@name='copyPrimaryContact']");
        public static Element SameAsPrimaryButton = new Element("//mat-checkbox[@name='copyClaimant']");
    }
}
