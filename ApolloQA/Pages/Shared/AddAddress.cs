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

        public void SelectAddressType(string type)
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

        public void SelectState(string state)
        {
        
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement typeDropdown = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("(//*[contains(@id,'mat-select')])[3]")));
            typeDropdown.Click();


            IWebElement target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//mat-option//span[normalize-space(text())='" + state + "']")));
            target.Click();
        }

        public void SelectCountry(string country)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement typeDropdown = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//mat-select[@name='countryId']")));
            typeDropdown.Click();

            IWebElement target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//mat-option//span[normalize-space(text())='" + country + "']")));
            target.Click();
        }

        public IWebElement AddressLine1 => driver.FindElement(By.XPath("//input[@name='line1']"));
        public IWebElement AddressLine2 => driver.FindElement(By.XPath("//input[@name='line2']"));
        public IWebElement AddressCity => driver.FindElement(By.XPath("//input[@name='city']"));
        public IWebElement AddressZipCode => driver.FindElement(By.XPath("//input[@name='postalCode']"));
        public IWebElement SubmitButton => driver.FindElement(By.XPath("//button//span[normalize-space(text())='Submit']"));

        public void ClickSubmit()
        {
            SubmitButton.Click();
        }



    }
}
