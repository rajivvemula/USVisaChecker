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

        public IWebElement nextPage => functions.FindElementWait(10, By.XPath("//a[@aria-label = 'go to next page']"));
        public IWebElement firstPage => functions.FindElementWait(10, By.XPath("//a[@aria-label = 'go to first page']"));
        public IWebElement prevPage => functions.FindElementWait(10, By.XPath("//a[@aria-label = 'go to previous page']"));
        public IWebElement lastPage => functions.FindElementWait(10, By.XPath("//a[@aria-label = 'go to last page']"));

        //This is the first ellipsis, use it to verify if it exists.
        public IWebElement gridEllipsis => functions.FindElementWait(10, By.XPath("//mat-icon[@aria-label='more']"));

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

        public bool CheckIfEllipsisMenuContains(string text)
        {
            //button[@role='menuitem' and normalize-space(text())='Delete' ]
            IWebElement menuButton = functions.FindElementWait(10, By.XPath("//button[@role='menuitem' and normalize-space(text())='" + text + "']"));
            return menuButton.Displayed;
        }
    }
}
