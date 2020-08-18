using ApolloQA.Pages.Fnol;
using ApolloQA.Pages.Shared;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression
{
    [Binding]
    public class R070_FNOLGridSteps
    {

        public IWebDriver driver;
        FNOLDash fnolDash;
        MainNavBar mainNav;
        RightNavBar rightNav;
        public R070_FNOLGridSteps(IWebDriver Driver)
        {
            driver = Driver;
            fnolDash = new FNOLDash(Driver);
            mainNav = new MainNavBar(Driver);
            rightNav = new RightNavBar(Driver);
        }
        
        [Given(@"User is shown the Manager Dashboard")]
        public void GivenUserIsShownTheManagerDashboard()
        {
            fnolDash.GoToFNOL();
        }
        
        [When(@"User Clicks on Waffle Mene")]
        public void WhenUserClicksOnWaffleMene()
        {
            mainNav.waffleMenu.Click();
        }
        
        [When(@"User clicks on Claims")]
        public void WhenUserClicksOnClaims()
        {
            mainNav.ClaimTab.Click();
        }
        
        [When(@"User clicks on Add New FNOL Button")]
        public void WhenUserClicksOnAddNewFNOLButton()
        {
            fnolDash.AddNewFNOL();
        }
        
        [When(@"USer clicks Add FNOL")]
        public void WhenUSerClicksAddFNOL()
        {
            rightNav.AddIcon.Click();
            rightNav.addFnolButton.Click();
        }
        
        [Then(@"User is shown the Manager Dashboard")]
        public void ThenUserIsShownTheManagerDashboard()
        {
            Assert.IsTrue(driver.Title.Contains("First Notice of Loss"));
        }
        
        [Then(@"User is taken to the FNOL Occurence Page")]
        public void ThenUserIsTakenToTheFNOLOccurencePage()
        {
            Assert.IsTrue(driver.Title.Contains("Insert First Notice of Loss"));
        }
    }
}
