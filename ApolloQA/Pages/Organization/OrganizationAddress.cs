using ApolloQA.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ApolloQA.Pages.Organization
{
    class OrganizationAddress
    {
        private IWebDriver Driver;
        Functions functions;

        public OrganizationAddress(IWebDriver driver)
        {
            Driver = driver;
            functions = new Functions(driver);

        }

        public IWebElement addAddressButton => functions.FindElementWait(10, By.XPath("//button/span[normalize-space(text())='Add Address']"));
        public IWebElement moreButton => functions.FindElementWait(10, By.XPath("//mat-icon[@aria-label='more']"));
        public IWebElement editButton => functions.FindElementWait(10, By.XPath("//button[normalize-space(text())='Edit']"));
        public IWebElement addressTab => functions.FindElementWait(10, By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Addresses']"));

        public void ClickAddAddress()
        {
            addAddressButton.Click();

        }

        public bool CheckAddress(string title)
        {
            return functions.FindElementWait(60, By.XPath("//span[@title='" + title + "']")).Displayed;
        }
    }
}
