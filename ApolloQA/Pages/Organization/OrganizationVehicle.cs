using ApolloQA.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Organization
{
    class OrganizationVehicle
    {

        private IWebDriver Driver;
        Functions functions;

        public OrganizationVehicle(IWebDriver driver)
        {
            Driver = driver;
            functions = new Functions(driver);

        }

        public IWebElement VehicleTab => functions.FindElementWait(10, By.XPath("//div[@class='mat-list-item-content' and normalize-space(text())='Vehicles']"));
        public IWebElement addAddressButton => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Add Vehicle']"));

        public IWebElement addDriverButton => functions.FindElementWait(10, By.XPath("//mat-icon[@aria-label='add']"));

        public IWebElement moreButton => functions.FindElementWait(10, By.XPath("//mat-icon[@aria-label='more']"));
        public IWebElement editButton => functions.FindElementWait(10, By.XPath("//button[normalize-space(text())='Edit']"));
    }
}
