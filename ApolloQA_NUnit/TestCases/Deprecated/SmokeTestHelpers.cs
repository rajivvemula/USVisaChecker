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

        public void SelectOptionAddress(string address)
        {
            IWebElement addressOption = functions.FindElementWait(10, By.XPath("//div[@class='address-info' and normalize-space(text())='" + address + "']"));
            addressOption.Click();
        }

        public bool CheckIfAddressSelected(string address)
        {
            IWebElement addressOption = functions.FindElementWait(10, By.XPath("//div[@class='address-info' and normalize-space(text())='" + address + "']"));
            return addressOption.Displayed;
        }
        public void EnterInput(IWebElement locator, string value)
        {
            locator.SendKeys(value);
        }
        public void EnterSelect(IWebElement locator, string value)
        {
            locator.Click();
            functions.FindElementWait(10, By.XPath("//span[@class='mat-option-text' and normalize-space(text())='" + value + "']")).Click();
        }
        public string GetRequired(IWebElement locator)
        {
            return locator.GetAttribute("aria-required");
        }
        public string GetValue(IWebElement locator)
        {
            return locator.GetAttribute("value");
        }
    }
}
