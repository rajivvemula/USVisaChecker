﻿using ApolloQA.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.TestCases.Smoke_Tests
{
    class SmokeTestHelpers
    {

        public IWebDriver driver;
        public Functions functions;

        public SmokeTestHelpers(IWebDriver Driver)
        {
            driver = Driver;
            functions = new Functions(Driver);

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

        public bool checkWaffleTab(string tab)
        {
            IWebElement waffleTab = functions.FindElementWait(10, By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='" + tab + "']"));
            return waffleTab.Displayed;
        }
    }
}
