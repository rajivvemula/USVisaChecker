using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Policy
{
    class PolicyGrid
    {

        private IWebDriver policyDriver;
        public PolicyGrid(IWebDriver driver)
        {
            policyDriver = driver;

        }

        public IWebElement newButton => policyDriver.FindElement(By.XPath("//button[@aria-label = 'Add Policy']"));
        public IWebElement nextPage => policyDriver.FindElement(By.XPath("//a[@aria-label = 'go to next page']"));
        public IWebElement firstPage => policyDriver.FindElement(By.XPath("//a[@aria-label = 'go to first page']"));
        public IWebElement prevPage => policyDriver.FindElement(By.XPath("//a[@aria-label = 'go to previous page']"));
        public IWebElement lastPage => policyDriver.FindElement(By.XPath("//a[@aria-label = 'go to last page']"));
        public void ClickNew()
        {
            newButton.Click();
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
