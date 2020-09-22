using ApolloQA.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Application
{
    class ApplicationGrid
    {
        private IWebDriver driver;
        private Functions functions;

        public ApplicationGrid(IWebDriver driver)
        {
            this.driver = driver;
            functions = new Functions(driver);
        }

        public IWebElement newButton => functions.FindElementWait(5, By.XPath("//button[@aria-label='New Application']"));

        public bool ClickNew()
        {
            try
            {
                newButton.Click();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
