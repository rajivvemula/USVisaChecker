using ApolloQA.Helpers;
using ApolloQA.Pages.Policy;
using ApolloQA.Pages.Shared;
using ApolloQA.Workflows;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression
{
    [Binding]
    public class R051_PolicyPermissionsSteps
    {
        private IWebDriver driver;
        PolicyCRUD policyCrud;
        RightNavBar rightNavBar;
        PolicyMain policyMain;
        Components components;
        PolicySummary policySummary;

        public R051_PolicyPermissionsSteps(IWebDriver driver)
        {
            this.driver = driver;
            policyCrud = new PolicyCRUD(driver);
            rightNavBar = new RightNavBar(driver);
            policyMain = new PolicyMain(driver);
            components = new Components(driver);
            policySummary = new PolicySummary(driver);
        }

        [Then(@"I (.*) create a policy")]
        public void ThenICanCreateAPolicy(string canCannot)
        {
            string resultText = policyCrud.CreateDefaultPolicy();

            if(canCannot.Equals("can"))
                Assert.IsTrue(resultText.Contains("was created"));
            else
                Assert.IsTrue(resultText.Equals("NULL"));
        }
        
        [Then(@"I can read a policy")]
        public void ThenICanReadAPolicy()
        {

        }
        
        [Then(@"I can update a policy")]
        public void ThenICanUpdateAPolicy()
        {
            rightNavBar.SearchQuery("10082");
            rightNavBar.ClickFirstSearchResult();
            policyMain.GoToSummary();
            components.UpdateDropdown("businessTypeEntityId", "Non-Profit");
            policySummary.ClickSaveButton();
            components.UpdateDropdown("businessTypeEntityId", "Corporation");
            policySummary.ClickSaveButton();
            components.UpdateDropdown("businessTypeEntityId", "Non-Profit");
            policySummary.ClickSaveButton();
        }
        
        [Then(@"I can delete a policy")]
        public void ThenICanDeleteAPolicy()
        {
            ScenarioContext.Current.Pending();
        }
        
        //[Then(@"I cannot create a policy")]
        //public void ThenICannotCreateAPolicy()
        //{

        //}
        
        [Then(@"I cannot update a policy")]
        public void ThenICannotUpdateAPolicy()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I cannot delete a policy")]
        public void ThenICannotDeleteAPolicy()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
