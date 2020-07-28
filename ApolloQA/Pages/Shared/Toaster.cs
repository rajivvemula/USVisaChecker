using ApolloQA.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Shared
{
    class Toaster
    {

        private IWebDriver Driver;
        private Functions functions;

        public Toaster(IWebDriver driver)
        {
            Driver = driver;
            functions = new Functions(driver);
        }

        public string GetToastTitle()
        {
            IWebElement toast = functions.FindElementWait(60, By.ClassName("toast-title"));
            string toastTitle = toast.Text;
            return toastTitle;
        }
    }
}
