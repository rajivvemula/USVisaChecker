using ApolloQA.Helpers;
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
        private Functions functions;


        public MainNavBar(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            functions = new Functions(driver);
        }

        public IWebElement HomeIcon => functions.FindElementWait(60, By.XPath("//fa-icon[contains(@class, 'apollo-icon')]"));
        public IWebElement PolicyTab => functions.FindElementWait(60, By.XPath("//button[contains(@class, 'top-menu-item') and contains(span, 'Policy')]"));
        public IWebElement OrganizationTab => functions.FindElementWait(60, By.XPath("//button[contains(@class, 'top-menu-item') and contains(span, 'Organization')]"));
        public IWebElement ApplicationTab => functions.FindElementWait(60, By.XPath("//button[contains(@class, 'top-menu-item') and contains(span, 'Application')]"));
        public IWebElement ManagerDashboardTab => functions.FindElementWait(60, By.XPath("//button[contains(@class, 'top-menu-item') and contains(span, 'Manager Dashboard')]"));
        public IWebElement AdjusterDashboardTab => functions.FindElementWait(60, By.XPath("//button[contains(@class, 'top-menu-item') and contains(span, 'Adjuster Dashboard')]"));

        public IWebElement getElementFromFieldname(string fieldName)
        {
            switch (fieldName)
            {
                case "Home": return HomeIcon;
                case "Organization": return OrganizationTab;
                case "Application": return ApplicationTab;
                case "Policy": return PolicyTab;
                default: return null;

            }
        }

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

        public void ClickApplicationTab()
        {
            ApplicationTab.Click();
        }

    }
}
