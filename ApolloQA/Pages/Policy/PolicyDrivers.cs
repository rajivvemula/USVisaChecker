using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Policy
{
    class PolicyDrivers
    {
        private IWebDriver policyDriver;
        public PolicyDrivers(IWebDriver driver)
        {
            policyDriver = driver;

        }

        public IWebElement inputFirstName => policyDriver.FindElement(By.XPath("//mat-select[@formcontrolname='firstName']"));
        public IWebElement inputMiddleName => policyDriver.FindElement(By.XPath("//mat-select[@formcontrolname='lastName']"));
        public IWebElement inputLastName => policyDriver.FindElement(By.XPath("//mat-select[@formcontrolname='middleName']"));
        public IWebElement inputSuffixName => policyDriver.FindElement(By.XPath("//mat-select[@formcontrolname='nameSuffix']"));
        public IWebElement inputDOB => policyDriver.FindElement(By.XPath("//mat-select[@formcontrolname='dateOfBirth']"));
        public IWebElement inputLicenseNum => policyDriver.FindElement(By.XPath("//mat-select[@formcontrolname='licenseNo']"));
        public IWebElement inputLicenseExp => policyDriver.FindElement(By.XPath("//mat-select[@formcontrolname='licenseExpirationDate']"));
    }
}
