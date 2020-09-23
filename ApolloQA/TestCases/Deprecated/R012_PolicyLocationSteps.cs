using ApolloQA.Pages.Policy;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression
{
    [Binding]
    public class R012_PolicyLocationSteps
    {
        public IWebDriver driver;
        PolicySummary policySummary;
        PolicyLocation policyLocation;

        public R012_PolicyLocationSteps(IWebDriver Driver)
        {
            driver = Driver;
            policySummary = new PolicySummary(Driver);
            policyLocation = new PolicyLocation(Driver);

        }

        [When(@"User clicks on New in Locations")]
        public void WhenUserClicksOnNewInLocations()
        {
            policyLocation.ClickAddNew();
        }
        
        [When(@"User inputs a location name")]
        public void WhenUserInputsALocationName()
        {
            policyLocation.AddLocationName();
            policyLocation.ClickSubmit();
        }
        
        [Then(@"Location name should be present in the grid")]
        public void ThenLocationNameShouldBePresentInTheGrid()
        {
            bool verifyLocation = policyLocation.checkLocation("TestAutomation");
            Assert.IsTrue(verifyLocation);
        }
    }
}
