using ApolloQA.Pages;
using ApolloQA.Source.Driver;
using Microsoft.AspNetCore.Builder;
using OpenQA.Selenium;
using System;
using System.Linq;
using System.Security.Policy;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using static ApolloQA.Source.Helpers.SpecflowTables;

namespace ApolloQA.StepDefinition
{
    [Binding]
    public sealed class apolloOrganizationSteps
    {
        public IWebDriver driver;


        apolloOrganizationSteps(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        public int OrgID;
        public string OrgType = "";
        public string Keyword = "";

        [Then(@"user verifies Email is required")]
        public void ThenUserVerifiesEmailIsRequired()
        {
            BusinessInformation.businessEmailAddressField.assertElementIsPresent(30);
            BusinessInformation.businessEmailAddressField.Click();
            string isRequired = BusinessInformation.businessEmailAddressField.GetAttribute("aria-required");
            Assert.AreEqual("true", isRequired);
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
            Pages.Shared.GetDropdownField("Tax ID Type").SelectMatDropdownOptionByText(OrgTable.TaxIdType);
            BusinessInformation.taxIdNumberField.setText(OrgTable.TaxIdNumber);
            BusinessInformation.descriptionOfOperationsField.setText(OrgTable.DescriptionOfOperations);
            BusinessInformation.businessphoneNumberField.setText(OrgTable.BusinessPhoneNumber);
            BusinessInformation.businessEmailAddressField.setText(OrgTable.BusinessEamil);
            BusinessInformation.businessWebsiteField.setText(OrgTable.BusinessWebsite);
            Pages.Shared.GetInputField("Keyword").setText(OrgTable.Keyword);
            Pages.Shared.GetInputField("Keyword").SelectMatDropdownOptionByIndex(0, out string selectionKeyWord);
            Keyword = selectionKeyWord;
            Log.Info($"Expected: {nameof(Keyword)}={Keyword}");
            BusinessInformation.businessYearStartedField.setText(OrgTable.YearStarted);
            BusinessInformation.businessYearOwnershipField.setText(OrgTable.YearOwned);
        }

        [When(@"user asserts for saved organization")]
        public void WhenUserAssertsForSavedOrganization()
        {
            var toastMessage = BusinessInformation.toastrMessage.GetInnerText();
            Assert.TextContains(toastMessage, "created");
            this.OrgID = int.Parse(string.Join("", toastMessage.Where(Char.IsDigit)));
            Log.Info($"Expected: Application Saved. Result: " + toastMessage + "");
        }

        [Then(@"user asserts for canceled organization add")]
        public void ThenUserAssertsForCanceledOrganizationAdd()
        {
            String URL = driver.Url;
            Assert.IsTrue(URL.EndsWith("/organization"));
        }

        [Then(@"user deletes created test organization")]
        public void ThenUserDeletesCreatedTestOrganization()
        {
            OrganizationGrid.skipToLastButton.assertElementIsVisible();
            OrganizationGrid.skipToLastButton.Click();
            OrganizationGrid.theTestOrg.assertElementIsVisible();
            OrganizationGrid.theTestOrgId.Click();
            BusinessInformation.blueEllipsesButton.Click();
            BusinessInformation.deleteOrgButton.Click();
            BusinessInformation.confirmDeleteOrg.Click();
            var toastMessage = BusinessInformation.toastrMessage.GetInnerText();
            Assert.TextContains(toastMessage, "was deleted.");
            this.OrgID = int.Parse(string.Join("", toastMessage.Where(Char.IsDigit)));
            Log.Info($"Expected: Org Deleted. Result: " + toastMessage + "");
        }
    }
}
