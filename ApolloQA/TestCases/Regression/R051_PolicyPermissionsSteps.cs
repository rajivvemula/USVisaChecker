using ApolloQA.Helpers;
using ApolloQA.Pages.Policy;
using ApolloQA.Pages.Shared;
using ApolloQA.Workflows;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression
{
    [Binding]
    public class R051_PolicyPermissionsSteps
    {
        private IWebDriver driver;
        private PolicyCRUD policyCrud;
        private RightNavBar rightNavBar;
        private PolicyMain policyMain;
        private Components components;
        private PolicySummary policySummary;

        public R051_PolicyPermissionsSteps(IWebDriver Driver)
        {
            this.driver = Driver;
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

            if (canCannot.Equals("can"))
                Assert.IsTrue(resultText.Contains("was created"));
            else
                Assert.IsTrue(resultText.Equals("NULL"));
        }

        [Then(@"I can read a policy")]
        public void ThenICanReadAPolicy()
        {

        }

        [Then(@"I (.*) update the policy general information tab")]
        public void ThenICanUpdateThePolicyGeneralInformationTab(string canCannot)
        {
            bool canUpdate = policyCrud.CanUpdatePolicyGeneralInformation("10170");

            if (canCannot.Equals("can"))
                Assert.IsTrue(canUpdate);
            else
                Assert.IsTrue(!canUpdate);
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
