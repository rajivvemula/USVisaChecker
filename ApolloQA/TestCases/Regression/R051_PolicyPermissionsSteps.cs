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

        public R051_PolicyPermissionsSteps(IWebDriver driver)
        {
            this.driver = driver;
            policyCrud = new PolicyCRUD(driver);
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
            ScenarioContext.Current.Pending();
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
