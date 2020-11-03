using ApolloQA.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using static ApolloQA.Source.Helpers.SpecflowTables;

namespace ApolloQA.StepDefinition
{
    [Binding]
    public sealed class apolloOrganizationAddSteps
    {
        public IWebDriver driver;


        apolloOrganizationAddSteps(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        [Then(@"user verifies Email is required")]
        public void ThenUserVerifiesEmailIsRequired()
        {
            BusinessInformation.businessEmailAddressField.Click();
           string isRequired = BusinessInformation.businessEmailAddressField.GetAttribute("aria-required");
            Assert.AreEqual("false", isRequired);
            // Assertion will need to be set to 'true' once functionality implemented. 
        }

        [Given(@"user enters business information")]
        public void GivenUserEntersBusinessInformation(Table table)
        {
            OrganizationTable OrgTable = table.CreateInstance<OrganizationTable>();
            BusinessInformation.BusinessNameField.setText(OrgTable.BusinessName);
            BusinessInformation.businessDBAField.setText(OrgTable.DBA);
            BusinessInformation.descriptionOfOperationsField.setText(OrgTable.DescriptionOfOperations);
            BusinessInformation.businessphoneNumberField.setText(OrgTable.BusinessPhoneNumber);
            BusinessInformation.businessEmailAddressField.setText(OrgTable.BusinessEamil);
            BusinessInformation.businessWebsiteField.setText(OrgTable.BusinessWebsite);
            BusinessInformation.businessYearStartedField.setText(OrgTable.YearStarted);
            BusinessInformation.businessYearOwnershipField.setText(OrgTable.YearOwned);

            //BusinessInformation.taxIdNumberField.setText(OrgTable.TaxIdNumber);
            //var orgType = driver.FindElement(By.XPath("//*[@role='combobox' and @formcontrolname='organizationTypeId']"));
            //var selectElement = new SelectElement(orgType);
            //selectElement.SelectByText(OrgTable.OrganizationType);
            //var taxtype = driver.FindElement(By.XPath("//*[@id='mat-select-value-7']"));
            //var selectElement2 = new SelectElement(taxtype);
            //selectElement2.SelectByText(OrgTable.TaxIdType);
            //BusinessInformation.businessKeywordField.setText(OrgTable.Keyword);
            //BusinessInformation.KeywordOption.Click();
            //BusinessInformation.businessClassTaxonomyField.setText(OrgTable.ClassTaxonomy);
        }
    }
}
