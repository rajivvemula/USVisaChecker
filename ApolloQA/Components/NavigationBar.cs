using ApolloQA.Source.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ApolloQA.Components
{
    class NavigationBar
    {

        public IWebElement HomeIcon => UserActions.FindElementWaitUntilVisible(By.XPath("//fa-icon[contains(@class, 'apollo-icon')]"));
        public IWebElement SearchField => UserActions.FindElementWaitUntilVisible(By.XPath("//input[@placeholder='Search here']"));

        public bool ClickTab(string tabName)
        {
            IWebElement targetTab = UserActions.FindElementWaitUntilVisible(By.XPath("//button[contains(@class, 'top-menu-item') and contains(span, '" + tabName + "')]"), UserActions.DEFAULT_WAIT_SECONDS);

            try
            {
                targetTab.Click();

                //due to Continue Anyway bug
                try
                {
                    //wait 3 seconds to see if Continue Anyway prompt appears
                    UserActions.FindElementWaitUntilClickable(By.XPath("//button[.//span[normalize-space(text())='Continue anyway']]"), 3).Click();
                }
                catch
                {
                    //if Continue Anyway prompt was not present
                    //do nothing
                }

                return true;
            }
            catch
            {
                //if targetTab.Click() throws an exception
                return false;
            }
        }

        public void SearchQuery(string query)
        {
            SearchField.Clear();
            SearchField.SendKeys(query);
        }

        public void ClickFirstSearchResult()
        {
            new WebDriverWait(Setup.driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//mat-option[contains(@class,'provided')]")));
            Thread.Sleep(1000);
            IList<IWebElement> SearchResults = UserActions.FindElementsWaitUntilVisible(By.XPath("//mat-option[contains(@class,'provided')]"));

            SearchResults[0].Click();
        }



    }
}
