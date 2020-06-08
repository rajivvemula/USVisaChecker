using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;


using ApolloQA.Pages.Policy;


namespace ApolloQA.TestCases.LoginTest
{
    [Binding]
    public class PolicyTestSteps
    {

        public IWebDriver driver;

        public PolicyTestSteps(IWebDriver Driver)
        {
            driver = Driver;
        }

        [Given(@"User is on Policy Page")]
        public void GivenUserIsOnPolicyPage()
        {
            PolicyMain policyPage = new PolicyMain(driver);
            
            policyPage.GoToSummary();
            //policyPage.GoToLocations();
            //policyPage.GoToContacts();
            //policyPage.GoToVehicles();
            //policyPage.GoToDrivers();
            //policyPage.GoToCoverages();
            //policyPage.GoToRates();
            
        }

        [When(@"User clicks Policy Summary")]
        public void WhenUserClicksPolicySummary()
        {
            PolicySummary policySummary = new PolicySummary(driver);
            string writeStatus = policySummary.CheckPolicyStatus();
            Console.WriteLine(writeStatus);
            policySummary.status.Click();

            
        }
        
        [Then(@"user is shown the Summary screen")]
        public void ThenUserIsShownTheSummaryScreen()
        {
            //empty
        }
    }
}
