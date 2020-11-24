using ApolloQA.Source.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Components
{
    class LeftSidetab
    {
        // Note: This class is sloppy and needs re-working

        By locator;

        public LeftSidetab(string fieldLabel)
        {
            string xpath = $"//div[@class='mat-list-item-content' and normalize-space(text())='{fieldLabel}']";

            locator = By.XPath(xpath);
        }

        public LeftSidetab(By locator)
        {
            this.locator = locator;
        }

        IWebElement sideTab => UserActions.FindElementWaitUntilVisible(locator, UserActions.DEFAULT_WAIT_SECONDS);

        public bool Click()
        {
            try
            {
                sideTab.Click();

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
                //if sideTab.Click() throws an exception
                return false;
            }
        }

        public string GetActiveSidetab()
        {
            string active = "//div[@class='mat-list-item-content']/parent::a[contains(@class, 'active-link')]";

            IWebElement activeSidetab = UserActions.FindElementWaitUntilVisible(By.XPath(active), UserActions.DEFAULT_WAIT_SECONDS);

            return activeSidetab.Text;
        }

    }
}
