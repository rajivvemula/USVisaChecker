using ApolloQA.Helpers;
using ApolloQA.Pages.Organization;
using ApolloQA.Pages.Shared;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Threading;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression
{
    [Binding]
    public class R040_InsertNewOrganizationSteps
    {
        private IWebDriver driver;
        MainNavBar mainNavBar;
        OrganizationGrid organizationGrid;
        OrganizationInsert organizationInsert;

        public R040_InsertNewOrganizationSteps(IWebDriver driver)
        {
            this.driver = driver;
            mainNavBar = new MainNavBar(driver);
            organizationGrid = new OrganizationGrid(driver);
            organizationInsert = new OrganizationInsert(driver);
        }

        [Given(@"I am on the OrganizationGrid page")]
        public void GivenIAmOnTheOrganizationGridPage()
        {
            mainNavBar.ClickOrganizationTab();
        }
        
        [Given(@"I am on the OrganizationInsert page")]
        public void GivenIAmOnTheOrganizationInsertPage()
        {
            mainNavBar.ClickOrganizationTab();
            organizationGrid.ClickNewButton();

        }
        
        [When(@"I click the New Organization button")]
        public void WhenIClickTheNewOrganizationButton()
        {
            organizationGrid.ClickNewButton();
        }


        [When(@"User clicks on cancel Button in IOrganization Insert")]
        public void WhenUserClicksOnCancelButtonInIOrganizationInsert()
        {
            organizationInsert.cancelButton.Click();
        }


        [Then(@"I am taken to the OrganizationInsert page")]
        public void ThenIAmTakenToTheOrganizationInsertPage()
        {
            Thread.Sleep(5000);


            Assert.IsTrue(driver.Url.Contains(Defaults.QA_URLS["Organization Insert"]));
        }

        [When(@"Organization Insert User enter (.*) for (.*)")]
        public void WhenAddDriverModalUserEnterJohnForFirst(string value, string input)
        {
            organizationInsert.EnterInput(input, value);
        }

        [When(@"Organization Insert User clicks on (.*)")]
        public void WhenAddDriverModalUserClicksOnLicensestate(string select)
        {
            organizationInsert.ClickSelect(select);
        }
        [Then(@"Organization Insert User should see (.*) For that (.*)")]
        public void ThenAddDriverModalUserShouldSeeJohnForThatFirst(string value, string input)
        {
            string verifyValue = organizationInsert.GetValue(input);
            Assert.AreEqual(verifyValue, value);
        }

        [Then(@"Organization Insert User is required to have values for the (.*) as (.*)")]
        public void ThenAddDriverModalUserIsRequiredToHaveValuesForTheFirstAsTrue(string input, string required)
        {
            string verifyReq = organizationInsert.GetRequired(input);
            Assert.AreEqual(verifyReq, required);
        }

        [Then(@"Organization Insert User should see all values to be present in (.*)")]
        public void ThenAddDriverModalUserShouldSeeAllValuesToBePresentInLicensestate(string select)
        {
            foreach (string i in organizationInsert.dropValues[select])
            {
                bool verifyRole = organizationInsert.CheckDropDownValue(i);
                Assert.AreEqual(verifyRole, true);
            }
        }

        [Then(@"Organization Insert User is required to have Select values for the (.*) as (.*)")]
        public void ThenAddDriverModalUserIsRequiredToHaveSelectValuesForTheLicensestateAsTrue(string select, string required)
        {
            string verifyReq = organizationInsert.GetSelectRequired(select);
            Assert.AreEqual(verifyReq, required);
        }


    }
}
