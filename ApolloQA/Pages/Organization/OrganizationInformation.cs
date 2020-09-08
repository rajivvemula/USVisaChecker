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
        public IWebElement selectOrgType => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='businessTypeEntityId']"));
        public IWebElement saveButton => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Save']"));


    }
}
