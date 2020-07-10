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

        public IWebElement ImpersonateIcon => driver.FindElement(By.XPath("//button/span/mat-icon[text()='assignment_ind']/../.."));

        public string GetImpersonateTitle => ImpersonateIcon.GetAttribute("title");

        public IWebElement HistoryIcon => driver.FindElement(By.XPath("//button/span/mat-icon[text()='history']/../.."));

        public void ImpersonateValidUser(string userName)
        {
            ImpersonateIcon.Click();
            IWebElement usernameField = driver.FindElement(By.XPath("//input[@formcontrolname='email']"));
            usernameField.SendKeys(userName);
            IWebElement submitButton = driver.FindElement(By.XPath("//button[@aria-label='Submit']"));
            submitButton.Click();
        }

        public string CurrentlyImpersonatedUser()
        {
            Console.WriteLine(GetImpersonateTitle);

            //if impersonating, the impersonate icon will have title="On Behalf Of Sonia.Amaravel@biberk.com  Click to stop impersonation"
            //if not impersonating, title="Choose user to impersonate"
            string currentImpText = ImpersonateIcon.GetAttribute("title");

            Console.WriteLine("current title is: " + currentImpText);

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
            IWebElement impersonatedUserIcon = driver.FindElement(By.XPath("//button[contains(@title, 'On Behalf Of')]"));
            impersonatedUserIcon.Click();

            IWebElement yesButton = driver.FindElement(By.XPath("//button/span[text()='Yes']/.."));
            yesButton.Click();
              
        }



        public void SearchQuery(string query)
        {
            SearchField.Clear();
            SearchField.SendKeys(query);
            SearchField.SendKeys(Keys.Enter);

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
