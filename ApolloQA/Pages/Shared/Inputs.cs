using ApolloQA.Helpers;
using ApolloQA.Pages.Organization;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Shared
{
    class Inputs
    {
        OrganizationInformation organizationInformation;

        IWebDriver driver;
        Functions functions;

        //mat-option/span/b[normalize-space(text())='No results found']
        //div[@class='line-label' and normalize-space(text())='Smoke Test873']

        public IWebElement noResultFound => functions.FindElementWaitUntilClickable(10, By.XPath("mat-option/span/b[normalize-space(text())='No results found']"));

        public Inputs(IWebDriver driver)
        {
            this.driver = driver;
            organizationInformation = new OrganizationInformation(driver);

        }

        public IWebElement getElementFromFieldname(string fieldName)
        {
            switch (fieldName)
            {
                case "busInfoOrgType": return organizationInformation.selectOrgType;
                default: return null;

            }
        }

        public bool CheckIfResultExists(string value)
        {
            IWebElement valueToBeChecked = functions.FindElementWaitUntilClickable(10, By.XPath("//div[@class='line-label' and normalize-space(text())='" + value + "']"));
            return valueToBeChecked.Displayed;
        }
    }
}
