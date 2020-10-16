using ApolloQA.Helpers;
using ApolloQA.Pages.Shared;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression.Navigation
{
    [Binding]
    public class N002_SearchSteps
    {
        private IWebDriver driver;
        MainNavBar mainNavBar;
        Buttons buttons;

        public N002_SearchSteps(IWebDriver driver)
        {
            this.driver = driver;
            mainNavBar = new MainNavBar(driver);
            buttons = new Buttons(driver);
        }
        [When(@"User enters (.*) in search field")]
        public void WhenUserEntersAInSearchField(string searchValue)
        {
            mainNavBar.SearchQuery(searchValue);
        }
        
        [When(@"User selects the first result")]
        public void WhenUserSelectsTheFirstResult()
        {
            mainNavBar.ClickFirstSearchResult();
            try { buttons.alertContinueAnyway.Click(); } catch { };
        }
        
        [Then(@"User is directed to (.*) URL with ID (.*)")]
        public void ThenUserIsDirectedToURLWithID(string urlName, string ID)
        {
            Assert.That(() => driver.Url, Does.Contain(Defaults.QA_URLS[urlName] + "/" + ID ).After(10).Seconds.PollEvery(250).MilliSeconds, "Unable to click the search result");
        }

        [Then(@"User is directed to Organization")]
        public void ThenUserIsDirectedToOrganizationTemporaryStep()
        {
            Assert.That(() => driver.Url, Does.Contain(Defaults.QA_URLS["Organization"]).After(10).Seconds.PollEvery(250).MilliSeconds, "Unable to navigate to Organization");
        }

    }
}
