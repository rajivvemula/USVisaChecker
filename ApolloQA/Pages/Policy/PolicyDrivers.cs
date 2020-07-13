using ApolloQA.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Policy
{
    class PolicyDrivers
    {
        private IWebDriver policyDriver;
        private Functions functions;

        public PolicyDrivers(IWebDriver driver)
        {
            policyDriver = driver;
            functions = new Functions(driver);
        }


        public IWebElement inputFirstName => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='firstName']"));
        public IWebElement inputMiddleName => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='lastName']"));
        public IWebElement inputLastName => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='middleName']"));
        public IWebElement inputSuffixName => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='nameSuffix']"));
        public IWebElement inputDOB => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='dateOfBirth']"));
        public IWebElement inputLicenseNum => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='licenseNo']"));
        public IWebElement inputLicenseExp => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='licenseExpirationDate']"));
    }
}
