﻿using ApolloQA.Helpers;
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

        public IWebElement HomeIcon => functions.FindElementWait(20, By.XPath("//fa-icon[contains(@class, 'apollo-icon')]"));
        public IWebElement PolicyTab => functions.FindElementWait(20, By.XPath("//button[contains(@class, 'top-menu-item') and contains(span, 'Policy')]"));
        public IWebElement OrganizationTab => functions.FindElementWait(20, By.XPath("//button[contains(@class, 'top-menu-item') and contains(span, 'Organization')]"));

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
