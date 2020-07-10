using ApolloQA.Pages.Shared;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Organization
{
    class OrganizationGrid
    {
        //locations
        string newButtonXPath = "//button[@aria-label='Add Master Organization']";

        protected IWebDriver driver;
        MainNavBar mainNavBar;

        public OrganizationGrid(IWebDriver driver)
        {
            this.driver = driver;
            mainNavBar = new MainNavBar(driver);
        }

        //this allows us to reference MainNavBar object and functions from Page object like so:
        // homePage.MainNavBar.ClickOnTab("Policy");
        //Per Cabe, there is likely a better way of doing this with context injection
        public MainNavBar MainNavBar { get => mainNavBar; }

        public OrganizationInsert ClickNewButton()
        {
            //wait for new button to be clickable
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            IWebElement newButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(newButtonXPath)));

            newButton.Click();

            return new OrganizationInsert(driver);
        }

    }
}
