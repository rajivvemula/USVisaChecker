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
        public static Element dateOfLossField => new Element("//input[@name='dateOfLoss']");
        public static Element timeOFLossField => new Element("//input[@name='timeOfLoss']");
        public static Element howWasNoticeReceivedDropdown => new Element("//mat-select[@name='receivedTypeId']");
        public static Element receivedByPhoneOption => new Element("//mat-option[@value='0']");
        public static Element receivedByEmailOption => new Element("//mat-option[@value='1']");
        public static Element receivedByCarrierPigeonOption => new Element("//mat-option[@value='2']");
        public static Element dateReportedField => new Element("//input[@name='dateReported']");
        public static Element timeReportedField => new Element("//input[@name='timeReported']");
        public static Element relatedToExistingClaimDropdown => new Element("//mat-select[@name='hasRelatedClaim']");
        public static Element policyNumberField => new Element("//*[@class='row'] //input[@name='innerControl']");


        // Reported By

        public static Element reportedFirstNameField => new Element("//input[@name='firstName']");
        public static Element reportedMiddleNameField => new Element("//input[@name='middleName']");
        public static Element reportedLastNameField => new Element("//input[@name='lastName']");
        public static Element reportedSuffixField => new Element("//input[@name='suffix']");
        public static Element reportedEmailField => new Element("//input[@name='email']");
        public static Element ReportedPhoneTypeDropdown => new Element("//mat-select[@name='phoneTypeId']");
        public static Element reportedPhonenumberField => new Element("//*[@class='col col-1'] //input[@name='phone']");
        public static Element reportedPhoneExtensionField => new Element("//*[@class='mat-form-field-infix ng-tns-c183-43'] //input[@name='extension']");
        public static Element reportedAddPhoneNumberButton => new Element("//*[@class='col col-1'] //*[@class='ng-star-inserted'] //button[@class='mat-focus-indicator action mat-flat-button mat-button-base']");


        // Claimant

        public static Element casastropheDropdown => new Element("//mat-select[@name='catastropheTypeId']");
        public static Element descriptionofLossField => new Element("//*[@name='lossDescription']");
        public static Element sameAsReportedCheckbox => new Element("//mat-checkbox[@name='sameAsReportedBy']");
        public static Element claimantFirstNameField => new Element("//*[@class='mat-form-field-infix ng-tns-c183-31'] //input[@name='firstName']");
        public static Element claimantMiddleNameField => new Element("//*[@class='mat-form-field-infix ng-tns-c183-32'] //input[@name='middleName']");
        public static Element claimantLastNameField => new Element("//*[@class='mat-form-field-infix ng-tns-c183-33'] //input[@name='lastName']");
        public static Element claimantSuffixField => new Element("//*[@class='mat-form-field-infix ng-tns-c183-34'] //input[@name='suffix']");
        public static Element claimantEmailField => new Element("//*[@class='mat-form-field-infix ng-tns-c183-35'] //input[@name='email']");
        public static Element claimantAddAddressButton => new Element(By.CssSelector("body > bh-app > mat-sidenav-container > mat-sidenav-content > div > bh-claim > div > bh-fnol-form > form > section:nth-child(5) > section > div:nth-child(2) > div:nth-child(2) > button"));
        public static Element claimantPhoneTypeDropdown => new Element("//*[@class='mat-form-field-infix ng-tns-c183-36'] //mat-select[@name='phoneTypeId']");
        public static Element claimantPhoneNumberField => new Element("//*[@class='mat-form-field-infix ng-tns-c183-38'] //input[@name='phone']");
        public static Element claimantPhoneExtensionField => new Element("//*[@class='mat-form-field-infix ng-tns-c183-43'] //input[@name='extension']");
        public static Element claimantAddPhoneNumberButton => new Element(By.CssSelector("body > bh-app > mat-sidenav-container > mat-sidenav-content > div > bh-claim > div > bh-fnol-form > form > section:nth-child(5) > section > div:nth-child(2) > div:nth-child(4) > button"));


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
        public static Element lossDetailsButton => new Element("//button[@type='submit' and @aria-label='Loss Details']");
    }
}
