using ApolloQA.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Policy
{
    class PolicyGrid
    {

        private IWebDriver policyDriver;
        private Functions functions;

        public PolicyGrid(IWebDriver driver)
        {
            policyDriver = driver;
            functions = new Functions(driver);
        }

        public IWebElement newButton => functions.FindElementWait(5, By.XPath("//button[@aria-label = 'Add Policy']"));
        public IWebElement nextPage => functions.FindElementWait(10, By.XPath("//a[@aria-label = 'go to next page']"));
        public IWebElement firstPage => functions.FindElementWait(10, By.XPath("//a[@aria-label = 'go to first page']"));
        public IWebElement prevPage => functions.FindElementWait(10, By.XPath("//a[@aria-label = 'go to previous page']"));
        public IWebElement lastPage => functions.FindElementWait(10, By.XPath("//a[@aria-label = 'go to last page']"));

        //returns true if user is able to click New, returns false if user does not have New button
        public bool ClickNew()
        {
            try
            {
                newButton.Click();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }


        public string GetTitle()
        {
            string title = policyDriver.Title;
            return title;
        }
        //Add pagination
        public void Pagination(string page)
        {
            switch (page)
            {
                default:
                    nextPage.Click();
                    break;
                case "prev":
                    prevPage.Click();
                    break;
                case "last":
                    lastPage.Click();
                    break;
                case "first":
                    firstPage.Click();
                    break;
            }
        }
    }
}
