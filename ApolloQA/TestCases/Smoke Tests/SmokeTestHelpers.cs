using ApolloQA.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.TestCases.Smoke_Tests
{
    class SmokeTestHelpers
    {

        public IWebDriver driver;

        public SmokeTestHelpers(IWebDriver Driver)
        {
            driver = Driver;

        }

        public void CheckIfHome()
        {
            if (driver.Url.Contains(Defaults.QA_URLS["Home"]))
            {
                //home 
            }
            else
            {
                driver.Navigate().GoToUrl(Defaults.QA_URLS["Home"]);
            }
        }

    }
}
