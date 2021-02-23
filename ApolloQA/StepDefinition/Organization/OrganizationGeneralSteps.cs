using ApolloQA.Pages;
using OpenQA.Selenium;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using ApolloQA.Source.Helpers;
using static ApolloQA.Source.Helpers.SpecflowTables;

namespace ApolloQA.StepDefinition
{
    [Binding]
    public sealed class OrganizationGeneralSteps
    {
        public IWebDriver driver;

        OrganizationGeneralSteps(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        public static int OrgID;
        public string OrgType = "";
        public string Keyword = "";
        public static Data.Entity.Organization _Organization;

        [When(@"user navigates to latest organization")]
        public void WhenUserNavigatesToLatestOrganization()
        {
            Log.Debug("Latest Organization ID" + Data.Entity.Organization.GetLatestOrganization().Id);
            _Organization = Data.Entity.Organization.GetLatestOrganization();
            Organization_Page.Navigate(_Organization.Id);
        }


        [When(@"user enters business information")]
        public void WhenUserEntersBusinessInformation(Table table)
        {
            OrganizationTable OrgTable = table.CreateInstance<OrganizationTable>();
            BusinessInformation.BusinessNameField.assertElementIsVisible();
            BusinessInformation.BusinessNameField.setText(OrgTable.BusinessName);
            BusinessInformation.organizationTypeDropdown.SelectMatDropdownOptionByIndex(1, out string selectionOrgType);
            OrgType = selectionOrgType;
            Log.Info($"Expected : {nameof(OrgType)}={OrgType}");
            BusinessInformation.businessDBAField.setText(OrgTable.DBA);
            Shared.GetDropdownField("Tax ID Type").SelectMatDropdownOptionByText(OrgTable.TaxIdType);
            BusinessInformation.taxIdNumberField.setText(OrgTable.TaxIdNumber);
            BusinessInformation.descriptionOfOperationsField.setText(OrgTable.DescriptionOfOperations);
            BusinessInformation.businessphoneNumberField.setText(OrgTable.BusinessPhoneNumber);
            BusinessInformation.businessEmailAddressField.setText(OrgTable.BusinessEamil);
            string isRequired = BusinessInformation.businessEmailAddressField.GetAttribute("aria-required");
            Assert.AreEqual("true", isRequired);
            BusinessInformation.businessWebsiteField.setText(OrgTable.BusinessWebsite);
            Shared.GetInputField("Keyword").setText(OrgTable.Keyword);
            Shared.GetInputField("Keyword").SelectMatDropdownOptionByIndex(1, out string selectionKeyWord);
            Keyword = selectionKeyWord;
            Log.Info($"Expected: {nameof(Keyword)}={Keyword}");
            BusinessInformation.businessYearStartedField.setText(OrgTable.YearStarted);
            BusinessInformation.businessYearOwnershipField.setText(OrgTable.YearOwned);
        }

        [When(@"user asserts for saved organization")]
        public void WhenUserAssertsForSavedOrganization()
        {
            // TODO : Issue with the save toastMessage
            var toastMessage = BusinessInformation.toastrMessage.GetInnerText();
            //Assert.TextContains(toastMessage, "created");
            //OrgID = int.Parse(string.Join("", toastMessage.Where(Char.IsDigit)));
            //Log.Info($"Expected: Quote Saved. Result: " + toastMessage + "");

            // Delete Org Functinality temporarily disabled 
            //BusinessInformation.toastrMessage.assertElementNotPresent();
            //BusinessInformation.blueEllipsesButton.Click();
            //BusinessInformation.deleteOrgButton.Click();
            //BusinessInformation.confirmDeleteOrg.Click();
            //var toastMessage2 = BusinessInformation.toastrMessage.GetInnerText();
            //Assert.TextContains(toastMessage2, "was deleted.");
            //OrgID = int.Parse(string.Join("", toastMessage2.Where(Char.IsDigit)));
            //Log.Info($"Expected: Org Deleted. Result: " + toastMessage2 + "");
        }

        [Then(@"user asserts for canceled organization add")]
        public void ThenUserAssertsForCanceledOrganizationAdd()
        {
            String URL = driver.Url;
            Assert.IsTrue(URL.EndsWith("/organization"));
        }

        [Then(@"user deletes entry")]
        public void ThenUserDeletesEntry()
        {
            var toastMessage = BusinessInformation.toastrMessage;
            OrganizationGrid.gridButton.Click();
            OrganizationGrid.gridDeleteButton.Click();

            toastMessage.assertElementNotPresent();
            OrganizationGrid.confirmGridDeleteButton.Click();
            //TODO :
            // API error response - Address post release 1
            Assert.TextContains(toastMessage.GetInnerText(), "deleted");
        }
    }
}
