using ApolloQA.Helpers;
using ApolloQA.Pages.Shared;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression.Navigation
{
    [Binding]
    public class N001_DashboardTabsSteps
    {
        private IWebDriver driver;
        MainNavBar mainNavBar;
        Components components;

        public N001_DashboardTabsSteps(IWebDriver driver)
        {
            this.driver = driver;
            mainNavBar = new MainNavBar(driver);
            components = new Components(driver);
        }

        [Given(@"User is on Homepage")]
        public void GivenUserIsOnHomepage()
        {
            components.CheckIfHome();
        }
        
        [When(@"User navigates to (.*) Tab")]
        public void WhenUserNavigatesToHomeTab(string name)
        {
            mainNavBar.getElementFromFieldname(name).Click();
        }
        
        [Then(@"Tab navigates to (.*) URL")]
        public void ThenTabNavigatesToHomeURL(string tab)
        {
            Assert.That(() => driver.Url, Does.Contain(Defaults.QA_URLS[tab]).After(3).Seconds.PollEvery(250).MilliSeconds, "Unable to Click " + tab);
            //Assert.IsTrue(driver.Url.Contains(Defaults.QA_URLS[tab]), "Unable to Click " + tab);
        }
    }
}
