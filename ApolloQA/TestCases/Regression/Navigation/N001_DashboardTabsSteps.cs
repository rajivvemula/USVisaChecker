using ApolloQA.Helpers;
using ApolloQA.Pages.Shared;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ApolloQA.TestCases.Regression.Navigation
{
    [Binding]
    public class N001_DashboardTabsSteps
    {
        private IWebDriver driver;
        MainNavBar mainNavBar;
        Components components;
        RightNavBar rightNavBar;

        public N001_DashboardTabsSteps(IWebDriver driver)
        {
            this.driver = driver;
            mainNavBar = new MainNavBar(driver);
            components = new Components(driver);
            rightNavBar = new RightNavBar(driver);
        }

        [Given(@"User is on Homepage")]
        public void GivenUserIsOnHomepage()
        {
            components.CheckIfHome();
        }

        [Given(@"User opens Waffle Menu")]
        public void GivenUserClicksOnWaffleMenu()
        {
            rightNavBar.waffleMenu.Click();
        }

        [When(@"User navigates to (.*) Tab")]
        public void WhenUserNavigatesToHomeTab(string name)
        {
            mainNavBar.getElementFromFieldname(name).Click();
        }

        [Then(@"Correct (.*) is displayed")]
        public void ThenCorrectIsDisplayed(string tabsetName)
        {
            foreach (var i in Defaults.TabSets[tabsetName])
            {
                bool verifyTab = components.CheckIfTabPresent(i);
                Assert.IsTrue(verifyTab, i + " Tab not present");
            }
        }
        [Then(@"Tab navigates to (.*) URL")]
        public void ThenTabNavigatesToHomeURL(string tab)
        {
            Assert.That(() => driver.Url, Does.Contain(Defaults.QA_URLS[tab]).After(10).Seconds.PollEvery(250).MilliSeconds, "Unable to Click " + tab);
        }

        [Then(@"User closes Waffle Menu")]
        public void ThenUserClosesWaffleMenu()
        {
            rightNavBar.sideWaffleMenu.Click();
        }

    }
}
