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
    }
}
