using ApolloQA.DataFiles;
using ApolloQA.Helpers;
using ApolloQA.Pages.Shared;
using ApolloQA.Workflows;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression.Organization
{
    [Binding]
    public class C003_SaveChangesToAOrganizationSteps
    {

        private IWebDriver driver;
        Random rnd;
        State state;
        Components component;
        Toaster toaster;
        Inputs input;
        

        public C003_SaveChangesToAOrganizationSteps(IWebDriver driver, State state)
        {
            this.driver = driver;
            this.state = state;
            rnd = new Random();
            component = new Components(driver);
            toaster = new Toaster(driver);
            input = new Inputs(driver);
        }

        [Given(@"User is on organization (.*)")]
        public void GivenUserIsOnOrganization(string orgID)
        {
            //Check wether the org has id or created
            if (orgID == "Created")
            {
                driver.Navigate().GoToUrl("https://biberk-apollo-qa2.azurewebsites.net/organization/" + state.createOrgsList.First());
                //driver.Navigate().GoToUrl("https://biberk-apollo-qa2.azurewebsites.net/organization/" + state.createOrgRecent);
            } else
            {
                driver.Navigate().GoToUrl("https://biberk-apollo-qa2.azurewebsites.net/organization/" + orgID);
            };

            

        }
        
        [When(@"User changes dropdown (.*) to (.*)")]
        public void WhenUserChangesTo(string locator, string value)
        {

            component.EnterSelect(input.getElementFromFieldname(locator), value);
            
        }
        
        [Then(@"Verify correct toast (.*) is displayed")]
        public void ThenVerifyCorrectToastIsDisplayed(string toastMessage)
        {
            string verifyToast = toaster.GetToastTitle();
            Assert.That(verifyToast, Does.Contain(toastMessage));
        }
    }
}
