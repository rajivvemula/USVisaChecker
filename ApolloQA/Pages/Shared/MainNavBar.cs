using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Shared
{
    class MainNavBar : RightNavBar
    {

        private IWebDriver driver;


        public MainNavBar(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }


        public IWebElement HomeIcon => driver.FindElement(By.XPath("//fa-icon[contains(@class, 'apollo-icon')]"));
        public IWebElement PolicyTab => driver.FindElement(By.XPath("//button[contains(@class, 'top-menu-item') and contains(span, 'Policy')]"));
        public IWebElement OrganizationTab => driver.FindElement(By.XPath("//button[contains(@class, 'top-menu-item') and contains(span, 'Organization')]"));

        public void ClickHomeIcon()
        {
            HomeIcon.Click();
        }

        public void ClickPolicyTab()
        {
            PolicyTab.Click();
        }

        public void ClickOrganizationTab()
        {
            OrganizationTab.Click();
        }

    }
}
