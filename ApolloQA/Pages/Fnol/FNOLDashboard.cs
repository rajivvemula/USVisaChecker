using ApolloQA.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Fnol
{
    class FNOLDashboard
    {
        private IWebDriver fnolDriver;
        private Functions functions;

        public FNOLDashboard(IWebDriver driver)
        {
            fnolDriver = driver;
            functions = new Functions(driver);
        }

        public IWebElement newFNOL => functions.FindElementWait(10, By.XPath("//button[@aria-label='New FNOL']"));
    }
}
