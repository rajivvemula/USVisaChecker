using ApolloQA.Pages.Shared;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Organization
{
    class OrganizationDetails
    {
        IWebDriver driver;
        //MainNavBar mainNavBar;

        public OrganizationDetails(IWebDriver driver)
        {
            this.driver = driver;
            //mainNavBar = new MainNavBar(driver);

        }

        public AddAddress ClickAddAddress()
        {
            string addAddressXPath = "//button/span[normalize-space(text())='Add address']";

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement addAddressButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(addAddressXPath)));

            addAddressButton.Click();

            return new AddAddress(driver);
        }

        
    }
}
