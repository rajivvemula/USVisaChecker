using ApolloQA.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Shared
{
    class Grid
    {
        private IWebDriver driver;
        private Functions functions;

        public Grid(IWebDriver driver)
        {
            this.driver = driver;
            functions = new Functions(driver);
        }

        public bool CheckColumnLabel(string title)
        {
            IWebElement columnTitle = functions.FindElementWait(10, By.XPath("//datatable-header-cell[@title='" + title + "']"));
            return columnTitle.Displayed;
        }

        public bool CheckValueDisplayed(string title)
        {
            IWebElement columnTitle = functions.FindElementWait(10, By.XPath("//span[@title='" + title + "']"));
            return columnTitle.Displayed;
        }
    }
}
