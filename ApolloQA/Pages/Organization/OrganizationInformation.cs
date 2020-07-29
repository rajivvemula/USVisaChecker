using ApolloQA.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Organization
{
    class OrganizationInformation
    {

        private IWebDriver Driver;
        Functions functions;

        public OrganizationInformation(IWebDriver driver)
        {
            Driver = driver;
            functions = new Functions(driver);

        }

        public IWebElement selectSubType => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='subIndustryTypeId']"));
        public IWebElement saveButton => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Save']"));



        public IWebElement getElementFromFieldname(string fieldName)
        {
            switch (fieldName)
            {
                case "subtype": return selectSubType;
                default: return null;

            }
        }

        public void EnterSelect(string locator, string value)
        {
            getElementFromFieldname(locator).Click();
            functions.FindElementWait(10, By.XPath("//span[@class='mat-option-text' and normalize-space(text())='" + value + "']")).Click();
        }

    }
}
