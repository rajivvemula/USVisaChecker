using ApolloQA.Source.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Components
{
    class Toaster
    {

        By locator;

        public Toaster(string containsText)
        {
            string xpath = $"//*[@class='toast-title' and contains(normalize-space(text()), '{containsText}')]";

            locator = By.XPath(xpath);
        }

        IWebElement theToast => UserActions.FindElementWaitUntilVisible(locator, 5);

        public bool IsPresent()
        {
            try
            {
                return theToast.Displayed;
            }
            catch
            {
                return false;
            }
        }
    }
}
