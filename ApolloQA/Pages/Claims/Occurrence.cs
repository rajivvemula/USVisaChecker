using ApolloQA.Source.Driver;
using DocumentFormat.OpenXml.Office.CoverPageProps;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages
{
    class Occurrence

        // Occurence
    {
        public static Element relatedToExistingClaimDropdown => new Element("//mat-select[@name='hasRelatedClaim']");
        public static Element policyNumberField => new Element("(//input[@type='text' and @name='innerControl'])[2]");
        public static Element dateOfLossField => new Element("//input[@name='dateOfLoss']");
        public static Element timeOFLossField => new Element("//input[@name='timeOfLoss']");


        // Location

        public static Element LocationDescriptionInput => new Element("//textarea[@formcontrolname='locationDescription']");
        public static Element AddressDropdown => new Element("(//mat-select[@role='combobox'])[3]");
        public static Element StreetAddressOneInput => new Element("//input[@name='line1']");
        public static Element StreetAddressTwoInput => new Element("//input[@name='line2']");
        public static Element CityInput => new Element("//input[@name='city']");
        public static Element StateDropdown => new Element("//mat-select[@name='state']");
        public static Element ZipCodeInput => new Element("//input[@name='postalCode']");
        public static Element VerifyAddressButton => new Element("(//button[contains(text(), ' Verify Address ')]");
        public static Element DescriptionOfLossInput => new Element("//textarea[@name='lossDescription']");
        public static Element CatastropheTypeDropdown => new Element("//mat-select[@name='catastropheTypeId']");

        // Police and Fire 

        public static Element policeInvolvedDropdown => new Element("//mat-select[@name='wasPoliceInvolved']");
        public static Element policeDepartmentNameField => new Element("//input[@name='policeDepartmentName']");
        public static Element policeReportNumberField => new Element("//input[@name='policeReportNumber']");
        public static Element fireInvolvedDropdown => new Element("//mat-select[@name='wasFireDepartmentInvolved']");
        public static Element fireDepartmentNameField => new Element("//input[@name='fireDepartmentName']");
        public static Element fireReportNumberField => new Element("//input[@name='fireReportNumber']");

        //Actions

        public static Element saveButton => new Element("//button[@type='submit' and @aria-label='Submit']");
        public static Element cancelButton => new Element("//button[@type='button'] //*[contains(text(), ' Cancel ')]");
        public static Element AddReceiptInfoButton => new Element("//button//*[contains(text(), ' Add Receipt Information ')]");
        public static Element ContinueAnywayButton => new Element("//button[@aria-label='Close'] //*[contains(text(), 'Continue anyway')]");
        public static Element toastrMessage => new Element("//div[@class='toast-content']/descendant::*");
    }
}
