using ApolloQA.Pages.Policy;
using ApolloQA.Pages.Shared;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression
{
    [Binding]
    public class R011_PolicyCoverageSteps
    {

        public IWebDriver driver;
        PolicySummary policySummary;
        Toaster toaster;
        PolicyCoverage policyCoverage;

        public R011_PolicyCoverageSteps(IWebDriver Driver)
        {
            driver = Driver;
            policySummary = new PolicySummary(Driver);
            toaster = new Toaster(Driver);
            policyCoverage = new PolicyCoverage(Driver);

        }

        [When(@"User Clicks New in Coverages")]
        public void WhenUserClicksNewInCoverages()
        {
            policyCoverage.newButton.Click();
            Thread.Sleep(4000);
        }
        
        [When(@"User inputs default values for Premium and Coverage")]
        public void WhenUserInputsDefaultValuesForPremiumAndCoverage()
        {
            policyCoverage.EnterInput("premium", "5000");
            policyCoverage.ClickCoverage();
            policyCoverage.saveButton.Click();

        }
        
        [Then(@"User is shown toast for creating coverage")]
        public void ThenUserIsShownToastForCreatingCoverage()
        {
            string currentToast = toaster.GetToastTitle();
            Assert.AreEqual(currentToast, "Coverage output created successfully.");
            driver.Navigate().Refresh();
        }
    }
}
