using ApolloQA.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Shared
{
    class Buttons
    {

        IWebDriver driver;
        Functions functions;


        public Buttons(IWebDriver driver)
        {
            this.driver = driver;
            functions = new Functions(driver);

        }

        public IWebElement getElementFromFieldname(string fieldName)
        {
            switch (fieldName)
            {
                case "orgGridNew": return orgGridNew;
                case "fnolGridNew": return fnolGridNew;
                case "appGridNew": return appGridNew;
                case "orgInsertSave": return orgInsertSave;
                case "appInsertCreateNewOrg": return appInsertCreateNewOrg;
                default: return null;

            }
        }

        // The buttons are named <section> + <button name> = orgGrid + New = orgGridNew
        /// <Section>
		/// Organization
		/// </Section>

        //Org Grid
        public IWebElement orgGridNew => functions.FindElementWait(10, By.XPath("//button[@aria-label='Add Master Organization']"));
        //public IWebElement saveButton => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Save']"));

        //Insert
        public IWebElement orgInsertSave => functions.FindElementWait(10, By.XPath("//button[@aria-label='Save']"));
        public IWebElement orgInsertCancel => functions.FindElementWait(10, By.XPath("//button[@aria-label='Cancel']"));

        //Org Details
        public IWebElement busInfoSave => functions.FindElementWait(10, By.XPath("//button[@aria-label='Save']"));

        //Org Address
        public IWebElement orgAddressAdd => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Save']"));

        //Org Driver
        public IWebElement orgDriverAdd => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Add Driver']"));

        //Org Vehicle
        public IWebElement orgVehicleAdd => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Add Vehicle']"));

        //Org Ripple Menu
        public IWebElement orgRippleCreateChildOrg => functions.FindElementWait(60, By.XPath("//button[//text()[normalize-space() = 'Create Child Organization']]"));
        public IWebElement orgRippleDeleteOrg => functions.FindElementWait(60, By.XPath("//button[//text()[normalize-space() = 'Delete Organization']]"));


        /// <Section>
        /// Organization
        /// </Section>

        //App Grid
        public IWebElement appGridNew => functions.FindElementWait(10, By.XPath("//button[@aria-label='New Application']"));

        //App Insert
        public IWebElement appInsertCreateNewOrg => functions.FindElementWait(60, By.XPath("//button[//text()[normalize-space() = 'Create New Organization']]"));
        public IWebElement appInsertNext => functions.FindElementWait(10, By.XPath("//button[@aria-label='Submit']"));

        //App Business Info
        //public IWebElement appInfoDropDownAddAddress => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Add Address']"));
        public IWebElement appInfoNext => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Next']"));

        //App Contacts
        public IWebElement appContactNew => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Contact']"));
        public IWebElement appContactNext => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Next']"));
        public IWebElement appContactDropDownAddAddress => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Add Address']"));
        public IWebElement appContactDropDownAddContact => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Add Contact']"));
        public IWebElement appContactSave => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Save']"));
        public IWebElement appContactCancel => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Cancel']"));

        //App Driver
        public IWebElement appDriverNew => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Add Driver']"));
        public IWebElement appDriverNext => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Next']"));
        public IWebElement appDriverDropDownCreateNew => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Create new']"));

        /* might be better to keep below three in POM files
        public IWebElement appDriverAddAccident => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Add Accident']"));
        public IWebElement appDriverViolation => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Add Violation']"));
        public IWebElement appDriverConviction => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Add Conviction']"));
        */
        public IWebElement appDriverSubmit => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Submit']"));
        public IWebElement appDriverCancel => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Cancel']"));

        //App Vehicle
        public IWebElement appVehicleNew => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Add Vehicle']"));
        public IWebElement appVehicleNext => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Next']"));
        public IWebElement appVehicleSaveVehicle => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Save Vehicle']"));
        public IWebElement appVehicleCancel => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Cancel']"));
        public IWebElement appVehicleClearAll => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='clear all']"));
        public IWebElement appVehicleSearchVin => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Search VIN']"));
        public IWebElement appVehicleDropDownCreateNew => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Create new']"));

        //App Summary
        public IWebElement appSummaryViewRating => functions.FindElementWait(60, By.XPath("//button[//text()[normalize-space() = 'View Rating Worksheet']]"));
        public IWebElement appSummaryViewPolicy => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='See Policy']"));
        public IWebElement appSummaryReject => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Reject']"));
        public IWebElement appSummaryApproveProposal => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Approve and Generate Proposal']"));

        /// <Section>
        /// FNOL
        /// </Section>

        //FNOL Grid
        public IWebElement fnolGridNew => functions.FindElementWait(10, By.XPath("//button[@aria-label='New FNOL']"));

        //FNOL Insert
        public IWebElement fnolInsertAddPhone => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Add Phone']"));
        public IWebElement fnolInsertAddAddress => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Add Address']"));
        public IWebElement fnolInsertLossDetails => functions.FindElementWait(10, By.XPath("//button[@aria-label='Loss Details']"));
        public IWebElement fnolInsertCancel => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Cancel']"));
        public IWebElement fnolInsertSave => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Save']"));

        //FNOL Loss Details
        public IWebElement fnolLossAddContacts => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Add Contacts']"));
        public IWebElement fnolLossCancel => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Cancel']"));
        public IWebElement fnolLossSave => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Save']"));

        //FNOL Contacts
        public IWebElement fnolContactNew => functions.FindElementWait(10, By.XPath("//button[@aria-label='New Contact']"));
        public IWebElement fnolContactAddDocuments => functions.FindElementWait(10, By.XPath("//button[@aria-label='Navigate to Documents']"));
        /* might be better to keep below 2 in POM files
        public IWebElement fnolContactAddPhone => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Add Phone']"));
        public IWebElement fnolContactAddAddress => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Add Address']"));
        */
        public IWebElement fnolContactCancel => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Cancel']"));
        public IWebElement fnolContactSave => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Save']"));

        //FNOL Documents
        public IWebElement fnolDocumentNew => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='New File']"));

        //FNOL Supervisor
        public IWebElement fnolSupervisorActivateClaim => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Activate Claim']"));
        public IWebElement fnolSupervisorCancel => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Cancel']"));
        public IWebElement fnolSupervisorSave => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Save']"));

        //FNOL Ripple
        public IWebElement fnolRippleRemoveFnol => functions.FindElementWait(60, By.XPath("//button[//text()[normalize-space() = 'Remove FNOL']]"));

        /// <Section>
        /// Alerts
        /// </Section>
        public IWebElement alertCancel => functions.FindElementWait(10, By.XPath("//button[@aria-label='Close']"));
        public IWebElement alertContinueAnyway => functions.FindElementWait(10, By.XPath("//button[.//span[normalize-space(text())='Continue anyway']]"));


        /// <Section>
        /// Address Modal
        /// </Section>
        public IWebElement modalAddressSave => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Save']"));
        public IWebElement modalAddressCancel => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Cancel']"));

        /// <Section>
        /// Address Modal
        /// </Section>
        public IWebElement modalDriverSubmit => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Submit']"));
        public IWebElement modalDriverCancel => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Cancel']"));

        /// <Section>
        /// Address Modal
        /// </Section>
        public IWebElement modalVehicleSubmit => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Submit']"));
        public IWebElement modalVehicleCancel => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Cancel']"));
        public IWebElement modalVehicleClearAll => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='clear all']"));
        public IWebElement modalVehicleSearchVin => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Search VIN']"));


        /// <Section>
        /// Generic Buttons
        /// </Section>
        public IWebElement iconAdd => functions.FindElementWait(10, By.XPath("//button[@aria-label='add']"));
        public IWebElement buttonNext => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Next']"));
        public IWebElement buttonCancel => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Cancel']"));
        public IWebElement buttonSave => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Save']"));
    }
}
