using ApolloQA.Helpers;
using ApolloQA.Pages.Shared;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression.Application
{
    [Binding]
    public class D001_NavigatingToApplicationInsertSteps
    {
        private IWebDriver driver;
        Buttons button;
        MainNavBar mainNavBar;
        Components components;
        RightNavBar rightNavBar;

        public D001_NavigatingToApplicationInsertSteps(IWebDriver driver)
        {
            this.driver = driver;
            button = new Buttons(driver);
            mainNavBar = new MainNavBar(driver);
            components = new Components(driver);
            rightNavBar = new RightNavBar(driver);
        }

        [When(@"User Navigates to Application Insert")]
        public void WhenUserNavigatesToApplicationInsert()
        {
            rightNavBar.AddIcon.Click();
            rightNavBar.addAppButton.Click();
            Assert.That(() => driver.Url, Does.Contain("quote/create").After(3).Seconds.PollEvery(250).MilliSeconds, "Unable To Navigate To Qoute Creation From App Grid");
        }
    }
}
