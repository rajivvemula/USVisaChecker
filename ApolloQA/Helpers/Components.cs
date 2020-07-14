using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Helpers
{
    class Components
    {

        private IWebDriver cDriver;
        private Functions functions;
        public Components(IWebDriver driver)
        {
            cDriver = driver;
            functions = new Functions(driver);
        }

        public bool CheckLabel(string label)
        {
            bool verify = cDriver.FindElement(By.XPath("//mat-label[contains(text(),'" + label + "')]")).Displayed;
            return verify;
        }

        public void UpdateDropdown(string formcontrolname, string selection)
        {
            //click the dropdown
            IWebElement dropdownField = functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='" + formcontrolname + "']"));
            dropdownField.Click();

            //click the selection
            IWebElement theSelection = functions.FindElementWait(10, By.XPath("//mat-option/span[normalize-space(text())='" + selection + "']"));
            theSelection.Click();
        }

    }
}
