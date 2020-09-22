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
        public void ThenURLIsDisplayed(string url)
        {
            Assert.That(() => driver.Url, Does.Contain(Defaults.URLContains["Business Information"]).After(30).Seconds.PollEvery(250).MilliSeconds, "Unable To Navigate To Qoute Creation From App Grid");
        }
    }
}
