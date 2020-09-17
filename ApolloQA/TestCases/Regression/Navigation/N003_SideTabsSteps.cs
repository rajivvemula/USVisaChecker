using ApolloQA.Helpers;
using ApolloQA.Pages.Shared;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression.Navigation
{
    [Binding]
    public class N003_SideTabsSteps
    {
        private IWebDriver driver;
        Components components;
        Buttons buttons;

        public N003_SideTabsSteps(IWebDriver driver)
        {
            this.driver = driver;
            components = new Components(driver);
            buttons = new Buttons(driver);
        }
        [When(@"User navigates to (.*) SideTab")]
        public void WhenUserNavigatesToSideTab(string tabName)
        {
            components.ClickSideTab(tabName);
            try { buttons.alertContinueAnyway.Click(); } catch { };
        }
    }
}
