using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Helpers
{
    class Components
    {

        private IWebDriver cDriver;
        public Components(IWebDriver driver)
        {
            cDriver = driver;
        }

        public bool CheckLabel(string label)
        {
            bool verify = cDriver.FindElement(By.XPath("//mat-label[contains(text(),'" + label + "')]")).Displayed;
            return verify;
        }

    }
}
