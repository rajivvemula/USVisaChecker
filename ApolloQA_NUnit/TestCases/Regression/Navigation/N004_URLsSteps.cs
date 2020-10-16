using ApolloQA.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression.Navigation
{
    [Binding]
    public class N004_URLsSteps
    {
        private IWebDriver driver;

        public N004_URLsSteps(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Then(@"(.*) page is displayed")]
        public void ThenURLIsDisplayed(string pageName)
        {
            //check URL
            Assert.That(() => driver.Url, Does.Contain(Defaults.URLContains[pageName]).After(15).Seconds.PollEvery(250).MilliSeconds, "Unable To Navigate To Qoute Creation From App Grid");

            //also check page title (e.g. "Contacts")
            
        }
    }
}
