using ApolloQA.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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

        public IWebElement newButton => functions.FindElementWaitUntilClickable(10, By.XPath("//button[@aria-label='New Application']"));

        public bool ClickNew()
        {
            try
            {
                //This sleep is required for now as it the new button becomes clickable before it's functionality loads (clicking it does nothing)
                Thread.Sleep(5000);
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
