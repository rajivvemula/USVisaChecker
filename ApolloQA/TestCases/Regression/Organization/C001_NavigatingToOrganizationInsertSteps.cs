using ApolloQA.Pages.Shared;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using System.Linq;
using NUnit.Framework;
using ApolloQA.Helpers;

namespace ApolloQA.TestCases.Regression.Organization
{
    [Binding]
    public class C001_NavigatingToOrganizationInsertSteps
    {
        private IWebDriver driver;
        Buttons button;

        public C001_NavigatingToOrganizationInsertSteps(IWebDriver driver)
        {
            this.driver = driver;
            button = new Buttons(driver);
        }
        [When(@"User clicks (.*) button")]
        public void WhenUserClicksButton(string buttonName)
        {
            button.getElementFromFieldname(buttonName).Click();

        }

        [Then(@"Verify correct page (.*) is displayed")]
        public void ThenVerifyCorrectPageIsDisplayed(string pageTitle)
        {
            Assert.That(() => driver.Title, Is.EqualTo(Defaults.PageTitles[pageTitle]).After(3).Seconds.PollEvery(250).MilliSeconds, "Unable To Display correct page with " + Defaults.PageTitles[pageTitle]);
        }
    }
}
