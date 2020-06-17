using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Shared
{
    class AddAddress
    {

        IWebDriver driver;

        //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        //IWebElement typeDropdown => wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//mat-select[@name='addressTypeId']")));

        public AddAddress(IWebDriver driver)
        {
            this.driver = driver;

        }

        public void selectAddressType(string type)
        {
            //types: Billing, Location, Mailing, Shipping

            //wait for dropdown to be clickable
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement typeDropdown = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//mat-select[@name='addressTypeId']")));
            typeDropdown.Click();

            //click selection
            IWebElement target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//mat-option//span[normalize-space(text())='" + type + "']")));
            target.Click();
        }


    }
}
