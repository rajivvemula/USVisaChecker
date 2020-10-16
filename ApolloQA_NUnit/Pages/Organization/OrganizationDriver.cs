using ApolloQA.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Organization
{
    class OrganizationDriver
    {

        private IWebDriver Driver;
        Functions functions;

        public OrganizationDriver(IWebDriver driver)
        {
            Driver = driver;
            functions = new Functions(driver);

        }

        public IWebElement driverTab => functions.FindElementWait(10, By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Drivers']"));
        public IWebElement addAddressButton => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Add Driver']"));

        public IWebElement addDriverButton => functions.FindElementWait(10, By.XPath("//mat-icon[@aria-label='add']"));

        public IWebElement moreButton => functions.FindElementWait(10, By.XPath("//mat-icon[@aria-label='more']"));
        public IWebElement editButton => functions.FindElementWait(10, By.XPath("//button[normalize-space(text())='Edit']"));

        public bool CheckLicenseNumber(string title)
        {
            return functions.FindElementWait(60, By.XPath("//span[@title='" + title + "']")).Displayed;
        }

    }
}
