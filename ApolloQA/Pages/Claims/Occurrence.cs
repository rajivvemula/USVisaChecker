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
        public static Element howWasNoticeReceivedDropdown => new Element("//*[@name='receivedTypeId']");
        public static Element receivedByCarrierPigeonOption => new Element("//mat-option[@value='2'] //*[contains(text(), 'Carrier Pigeon')]");
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
        public static Element ReportedPhoneTypeDropdown => new Element("//*[@class='mat-form-field-infix ng-tns-c217-28'] //mat-select[@name='phoneTypeId']");
        public static Element reportedPhonenumberField => new Element("//*[@class='col col-1'] //input[@name='phone']");
        public static Element reportedPhoneExtensionField => new Element("//input[@name='extension' and @data-placeholder='Extension']");
        public static Element reportedAddPhoneNumberButton => new Element("//button //*[contains(text(), ' Add Phone ')]");


        // Claimant

        public static Element casastropheDropdown => new Element("//mat-select[@name='catastropheTypeId']");
        public static Element descriptionofLossField => new Element("//*[@name='lossDescription']");
        public static Element sameAsReportedCheckbox => new Element("//mat-checkbox[@name='sameAsReportedBy']");
        public static Element claimantFirstNameField => new Element("(//input[@name='firstName'])[2]");
        public static Element claimantMiddleNameField => new Element("(//input[@name='middleName'])[2]");
        public static Element claimantLastNameField => new Element("(//input[@name='lastName'])[2]");
        public static Element claimantSuffixField => new Element("(//input[@name='suffix'])[2]");
        public static Element claimantEmailField => new Element("(//input[@name='email'])[2]");
        public static Element claimantAddAddressButton => new Element("//button[contains(text(), ' Add Address ')]");
        public static Element claimantPhoneTypeDropdown => new Element("(//mat-select[@name='phoneTypeId'])[2]");
        public static Element claimantPhoneNumberField => new Element("(//input[@name='phone'])[2]");
        public static Element claimantPhoneExtensionField => new Element("(//input[@name='extension'])[2]");
        public static Element claimantAddPhoneNumberButton => new Element("(//button //*[contains(text(), ' Add Phone ')])[2]");


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
        public static Element ContinueAnywayButton => new Element("//button[@aria-label='Close'] //*[contains(text(), 'Continue anyway')]");
        public static Element toastrMessage => new Element("//div[@class='toast-content']/descendant::*");
    }
}
