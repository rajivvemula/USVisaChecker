using ApolloQA.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ApolloQA.Pages.Shared
{
    class RightNavBar
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private Functions functions;

        public RightNavBar(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            functions = new Functions(driver);
        }


        //public IWebElement SearchField => driver.FindElement(By.XPath("//input[@placeholder='Search here']"));
        public IWebElement SearchField => functions.FindElementWait(10, By.XPath("//input[@placeholder='Search here']"));

        //public IWebElement ImpersonateIcon => driver.FindElement(By.XPath("//button/span/mat-icon[text()='assignment_ind']/../.."));
        public IWebElement ImpersonateIcon => functions.FindElementWait(20, By.XPath("//button/span/mat-icon[text()='assignment_ind']/../.."));

        //public IWebElement RedImpersonateIcon => driver.FindElement(By.XPath("//button/span/mat-icon[contains(@class, 'is-impersonated')]/../.."));
        public IWebElement RedImpersonateIcon => functions.FindElementWait(20, By.XPath("//button/span/mat-icon[contains(@class, 'is-impersonated')]/../.."));


        //public IWebElement HistoryIcon => driver.FindElement(By.XPath("//button/span/mat-icon[text()='history']/../.."));
        public IWebElement HistoryIcon => functions.FindElementWait(10, By.XPath("//button/span/mat-icon[text()='history']/../.."));

        public void ImpersonateValidUser(string userName)
        {
            string currentImpersonatedUser = CurrentlyImpersonatedUser();

            //if already impersonating this user
            if (currentImpersonatedUser.Equals(userName))
                return;

            //if impersonating other user, need to stop impersonation
            if (!currentImpersonatedUser.Equals("NULL"))
                StopImpersonation();


            ImpersonateIcon.Click();
            IWebElement usernameField = driver.FindElement(By.XPath("//input[@formcontrolname='email']"));
            usernameField.SendKeys(userName);
            IWebElement submitButton = driver.FindElement(By.XPath("//button[@aria-label='Submit']"));
            submitButton.Click();

            //wait for presence of RED impersonate icon
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(RedImpersonateIcon));
        }

        public string CurrentlyImpersonatedUser()
        {

            //if impersonating, the impersonate icon will have title="On Behalf Of Sonia.Amaravel@biberk.com  Click to stop impersonation"
            //if not impersonating, title="Choose user to impersonate"
            string currentImpText = ImpersonateIcon.GetAttribute("title");

            if (currentImpText.Contains("Choose"))
                return "NULL";

            //split the title based on white-space
            char[] delimiters = { ' ', '\n', '\r'};
            string[] words = currentImpText.Split(delimiters);

            ////for debugging
            //foreach(string word in words)
            //{
            //    Console.WriteLine(word);
            //}

            //grab the email address and return it
            string currentImpUser = words[3];
            return currentImpUser;
        }

        public void StopImpersonation()
        {
            RedImpersonateIcon.Click();

            IWebElement yesButton = functions.FindElementWait(5, By.XPath("//button/span[text()='Yes']/.."));
            yesButton.Click();
              
        }



        public void SearchQuery(string query)
        {
            SearchField.Clear();
            SearchField.SendKeys(query);

        }

        public void ClickFirstSearchResult()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//mat-option[contains(@class,'provided')]")));
            IList<IWebElement> SearchResults = driver.FindElements(By.XPath("//mat-option[contains(@class,'provided')]"));
            
            

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
