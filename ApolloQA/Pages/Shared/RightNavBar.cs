using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Shared
{
    class RightNavBar
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public RightNavBar(IWebDriver driver)
        {
            this.driver = driver;
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }


        public IWebElement SearchField => driver.FindElement(By.XPath("//input[@placeholder='Search here']"));

        public IWebElement ImpersonateIcon => driver.FindElement(By.XPath("//button[@title='Choose user to impersonate']"));

        public IWebElement HistoryIcon => driver.FindElement(By.XPath("//button/span/mat-icon[text()='history']/../.."));
        


        public void SearchQuery(string query)
        {
            SearchField.Clear();
            SearchField.SendKeys(query);

        }

        public void ClickFirstSearchResult()
        {
            IList<IWebElement> SearchResults = driver.FindElements(By.XPath("//mat-option[contains(@class,'provided')]"));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SearchResults[0]));
            

            ////for debugging
            //Console.WriteLine(SearchResults.Count);

            //foreach (IWebElement item in SearchResults)
            //{
            //    Console.WriteLine(item.GetAttribute("outerHTML"));
            //}

            SearchResults[0].Click();
        }

         






    }
}
