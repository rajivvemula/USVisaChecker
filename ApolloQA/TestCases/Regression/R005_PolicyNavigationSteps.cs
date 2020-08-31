using ApolloQA.Helpers;
using ApolloQA.Pages.Policy;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression
{
    [Binding]
    public class R005_PolicyNavigationSteps
    {

        public IWebDriver driver;
        PolicyMain policyMain;
        Components components;


        public R005_PolicyNavigationSteps(IWebDriver Driver)
        {
            driver = Driver;
            policyMain = new PolicyMain(Driver);
            components = new Components(Driver);

        }

        [Given(@"User navigates to Policy Page For Policy (.*)")]
        public void GivenUserNavigatesToPolicyPageForPolicyNumber(int number)
        {
            policyMain.NavigateToPolicy(number);
        }
        
        [When(@"User Click on General Information")]
        public void WhenUserClickOnGeneralInformation()
        {
            policyMain.GoToSummary();
            Thread.Sleep(5000);
        }
        
        //[When(@"User Click on Locations")]
        //public void WhenUserClickOnLocations()
        //{
        //    policyMain.GoToLocations();
        //}
        
        [When(@"User Click on Contacts")]
        public void WhenUserClickOnContacts()
        {
            policyMain.GoToContacts();
        }
        
        [When(@"User Click on Vehicles")]
        public void WhenUserClickOnVehicles()
        {
            policyMain.GoToVehicles();
        }
        
        [When(@"User Click on Drivers")]
        public void WhenUserClickOnDrivers()
        {
            policyMain.GoToDrivers();
        }
        
        [When(@"User Click on Coverages")]
        public void WhenUserClickOnCoverages()
        {
            policyMain.GoToCoverages();
        }
        
        [When(@"User Click on Rate Calculation")]
        public void WhenUserClickOnRateCalculation()
        {
            policyMain.GoToRates();
        }
        
        [When(@"User Click on Documents")]
        public void WhenUserClickOnDocuments()
        {
            policyMain.GoToDocuments();
        }
        
        [When(@"User Click on Policy History")]
        public void WhenUserClickOnPolicyHistory()
        {
            policyMain.GotoHistory();
            Thread.Sleep(5000);
        }
        
        [Then(@"User is shown the General Information screen for that policy")]
        public void ThenUserIsShownTheGeneralInformationScreenForThatPolicy()
        {
            string verifyTitle = driver.Title;
            Assert.AreEqual(verifyTitle, "General Information");
        }
        
        [Then(@"User is shown the Locations screen for that policy")]
        public void ThenUserIsShownTheLocationsScreenForThatPolicy()
        {
            string verifyTitle = driver.Title;
            Assert.AreEqual(verifyTitle, "Locations");
            
        }
        
        [Then(@"User is shown the Contacts screen for that policy")]
        public void ThenUserIsShownTheContactsScreenForThatPolicy()
        {
            //ScenarioContext.Current.Pending();
        }
        
        [Then(@"User is shown the Vehicles screen for that policy")]
        public void ThenUserIsShownTheVehiclesScreenForThatPolicy()
        {
            //string verifyTitle = driver.Title;
            //Assert.AreEqual(verifyTitle, "Vehicles");
            bool verifyTitle = components.GetTitle("Vehicles");
            Assert.IsTrue(verifyTitle);
        }
        
        [Then(@"User is shown the Drivers screen for that policy")]
        public void ThenUserIsShownTheDriversScreenForThatPolicy()
        {
            string verifyTitle = driver.Title;
            Assert.AreEqual(verifyTitle, "Drivers");
        }
        
        [Then(@"User is shown the Coverages screen for that policy")]
        public void ThenUserIsShownTheCoveragesScreenForThatPolicy()
        {
            string verifyTitle = driver.Title;
            Assert.AreEqual(verifyTitle, "Coverages");
        }
        
        [Then(@"User is shown the Rate Calculation screen for that policy")]
        public void ThenUserIsShownTheRateCalculationScreenForThatPolicy()
        {
            string verifyTitle = driver.Title;
            Assert.AreEqual(verifyTitle, "Rate Calculation");
        }
        
        [Then(@"User is shown the Documents screen for that policy")]
        public void ThenUserIsShownTheDocumentsScreenForThatPolicy()
        {
            string verifyTitle = driver.Title;
            Assert.AreEqual(verifyTitle, "Document List");
        }
        
        [Then(@"User is shown the Policy History screen for that policy")]
        public void ThenUserIsShownThePolicyHistoryScreenForThatPolicy()
        {
            string verifyTitle = driver.Title;
            Assert.AreEqual(verifyTitle, "Policy History");
        }
    }
}
