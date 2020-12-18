using ApolloQA.Source.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Components
{
    class Button
    {
        By locator;

        public Button(string buttonText)
        {
            string xpath = $"//button[./*[normalize-space(text())='{buttonText}']] |" +
                           $"//button[normalize-space(text())='{buttonText}'] |" +
                           $"//button//*[contains(text(), '{buttonText}')]";

            locator = By.XPath(xpath);
        }

        public Button(By locator)
        {
            this.locator = locator;
        }

        IWebElement theButton => UserActions.FindElementWaitUntilVisible(locator, UserActions.DEFAULT_WAIT_SECONDS);

        public bool IsEnabled()
        {
            return theButton.Enabled;
        }

        public bool Click()
        {
            try
            {
                theButton.Click();
                return true;
            }
            catch 
            {
                return false;
            }
        }

    }
}
