using ApolloQA.Pages.Policy;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression
{
    [Binding]
    public class R019_PolicyHistoryVerifySteps
    {
        public IWebDriver driver;
        PolicyHistory policyHistory;

        public R019_PolicyHistoryVerifySteps(IWebDriver Driver)
        {
            driver = Driver;
            policyHistory = new PolicyHistory(Driver);
            
        }

        [Then(@"Verify policy was intialized")]
        public void ThenVerifyPolicyWasIntialized()
        {
            bool verify = policyHistory.CheckTransaction("Policy initialized as Pre-Submission");
            Assert.IsTrue(verify);
        }
        
        [Then(@"Verify driver was added")]
        public void ThenVerifyDriverWasAdded()
        {
            bool verify = policyHistory.CheckTransaction("Policy added driver Jacob Seed q.");
            Assert.IsTrue(verify);
        }
        
        [Then(@"Verify location was added")]
        public void ThenVerifyLocationWasAdded()
        {
            bool verify = policyHistory.CheckTransaction("Policy location `TestAutomation` was created.");
            Assert.IsTrue(verify);
            //Policy location `TestAutomation` was created.
        }

        [When(@"User refreshes browser")]
        public void WhenUserRefreshesBrowser()
        {
            driver.Navigate().Refresh();
        }

    }
}
