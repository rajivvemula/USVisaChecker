using ApolloQA.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Shared
{
    class AddDriver
    {

        private IWebDriver Driver;
        Functions functions;
        public AddDriver(IWebDriver driver)
        {
            Driver = driver;
            functions = new Functions(driver);

        }

        public IWebElement inputFirst => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='firstName']"));
        public IWebElement inputMiddle => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='middleName']"));

        public IWebElement inputLast => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='lastName']"));

        public IWebElement inputSuffix => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='nameSuffix']"));

        public IWebElement inputBirth => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='dateOfBirth']"));

        public IWebElement inputLicenseNumber => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='licenseNo']"));
        public IWebElement inputLicenseExp => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='licenseExpirationDate']"));
        public IWebElement selectLicenseState => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='stateProvinceId']"));
        public IWebElement selectCDL => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='cdl']"));
        public IWebElement selectAccident => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='lastThreeYearsAccidents']"));
        public IWebElement selectViolation => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='lastThreeYearsViolations']"));
        public IWebElement selectConviction => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='lastThreeYearsConvictions']"));
        public IWebElement cancelButton => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Cancel']"));
        public IWebElement submitButton => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Submit']"));



        public readonly string[] driverLabels =
        {
            "First Name",
            "Last Name",
            "Middle Name",
            "Suffix",
            "Date of Birth",
            "Drivers License State",
            "Drivers License Number",
            "Expiration Date",
            "CDL",
            "Accidents in last 3 years?",
            "Violations in last 3 years?",
            "Convictions in last 3 years?"
        };

        public readonly IDictionary<string, string[]> dropValues = new Dictionary<string, string[]>()
        {
            {"licensestate", new []{"CA", "IL", "NJ", "NY", "PA"} },
            {"cdl", new []{"Yes", "No"} },
            {"accident", new []{"Yes", "No"} },
            {"violation", new []{"Yes", "No"} },
            {"conviction", new []{"Yes", "No"} },

        };

        
        public bool CheckDropDownValue(string value)
        {
            bool verify = functions.FindElementWait(10, By.XPath("//span[@class='mat-option-text' and normalize-space(text())='" + value + "']")).Displayed;

            return verify;
        }


    }


}
