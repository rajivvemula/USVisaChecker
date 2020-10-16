using ApolloQA.Helpers;
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

        protected IWebDriver driver;
        Functions functions;

        public OrganizationGrid(IWebDriver driver)
        {
            this.driver = driver;
            functions = new Functions(driver);
        }

        public IWebElement newButton => functions.FindElementWait(10, By.XPath("//button[@aria-label='Add Master Organization']"));

        public void ClickNewButton()
        {
            newButton.Click();
        }

    }
}
