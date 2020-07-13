using ApolloQA.Helpers;
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
        Functions functions;

        public OrganizationDetails(IWebDriver driver)
        {
            this.driver = driver;
            functions = new Functions(driver);

        }

        public IWebElement addAddressButton => functions.FindElementWait(10, By.XPath("//button/span[normalize-space(text())='Add address']"));

        public void ClickAddAddress()
        {
            addAddressButton.Click();

        }

        
    }
}
