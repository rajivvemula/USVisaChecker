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
    public class R018_PolicyDriversSteps
    {

        public IWebDriver driver;
        PolicyMain policyMain;
        PolicyDrivers policyDrivers;
        AddDriver addDriver;

        public R018_PolicyDriversSteps(IWebDriver Driver)
        {
            driver = Driver;
            policyMain = new PolicyMain(Driver);
            addDriver = new AddDriver(Driver);
            policyDrivers = new PolicyDrivers(Driver);
        }

        [When(@"User Click on Add Driver")]
        public void WhenUserClickOnAddDriver()
        {
            policyDrivers.newDriverButton.Click();
            Thread.Sleep(3000);
        }
        
        [When(@"Add Driver Modal User enter (.*) for (.*)")]
        public void WhenAddDriverModalUserEnterJohnForFirst(string value, string input)
        {
            //addDriver.EnterInput(input, value);
        }
        
        [When(@"Add Driver Modal User clicks on (.*)")]
        public void WhenAddDriverModalUserClicksOnLicensestate(string select)
        {
           // addDriver.ClickSelect(select);
        }
        [When(@"User clicks cancel to exit modal for Add Driver")]
        public void WhenUserClicksCancelToExitModalForAddDriver()
        {
            //addDriver.cancelButton.Click();
        }

        [When(@"Special Step after coverage for driver")]
        public void WhenSpecialStepAfterCoverageForDriver()
        {
            //addDriver.EnterInput("suffix", "q");
        }


        [Then(@"User is shown the Add Driver Modal")]
        public void ThenUserIsShownTheAddDriverModal()
        {
            bool title = policyDrivers.CheckModalTitle();
            Assert.IsTrue(title);
        }
        
        [Then(@"Add Driver Modal User should see (.*) For that (.*)")]
        public void ThenAddDriverModalUserShouldSeeJohnForThatFirst(string value, string input)
        {
            //string verifyValue = addDriver.GetValue(input);
            //Assert.AreEqual(verifyValue, value);
        }
        
        [Then(@"Add Driver Modal User is required to have values for the (.*) as (.*)")]
        public void ThenAddDriverModalUserIsRequiredToHaveValuesForTheFirstAsTrue(string input, string required)
        {
            //string verifyReq = addDriver.GetRequired(input);
            //Assert.AreEqual(verifyReq, required);
        }
        
        [Then(@"Add Driver Modal User should see all values to be present in (.*)")]
        public void ThenAddDriverModalUserShouldSeeAllValuesToBePresentInLicensestate(string select)
        {
            foreach (string i in addDriver.dropValues[select])
            {
                bool verifyRole = addDriver.CheckDropDownValue(i);
                Assert.AreEqual(verifyRole, true);
            }
        }
        
        [Then(@"Add Driver Modal User is required to have Select values for the (.*) as (.*)")]
        public void ThenAddDriverModalUserIsRequiredToHaveSelectValuesForTheLicensestateAsTrue(string select, string required)
        {
            //string verifyReq = addDriver.GetSelectRequired(select);
            //Assert.AreEqual(verifyReq, required);
        }
        [Then(@"User is no longer able to see the modal for Add Driver")]
        public void ThenUserIsNoLongerAbleToSeeTheModalForAddDriver()
        {
            bool title = policyDrivers.CheckModalTitle();
            Assert.IsFalse(title);
        }

    }
}
