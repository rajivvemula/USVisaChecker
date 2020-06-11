using ApolloQA.Pages.Nav;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Organization
{
    class OrganizationInsert
    {
        //locations
        public IList<IWebElement> fields;

        protected IWebDriver driver;
        MainNavBar mainNavBar;

        public OrganizationInsert(IWebDriver driver)
        {
            this.driver = driver;
            mainNavBar = new MainNavBar(driver);

            fields = driver.FindElements(By.XPath("//input[contains(@id,'mat-input')]"));
        }

        public MainNavBar MainNavBar { get => mainNavBar; }

        //public OrganizationXXXXXX ClickNewButton()
        //{
        //    //wait for new button to be clickable
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        //    IWebElement newButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(newButtonXPath)));

        //    newButton.Click();

        //    return new OrganizationInsert(driver);
        //}

        public void EnterAllValues()
        {
            this.EnterName("Test Organization");
            this.EnterAlternateName("Test Alternate");
            this.EnterLegalName("Test Legal");
            this.SelectType();
            this.EnterCode("12345");
        }

        public void EnterName(string name)
        {
            fields[1].SendKeys(name);
        }

        public void EnterAlternateName(string alternateName)
        {
            fields[2].SendKeys(alternateName);
        }

        public void EnterLegalName(string legalName)
        {
            fields[3].SendKeys(legalName);
        }

        public void SelectType()
        {
            IWebElement typeDropdown = driver.FindElement(By.XPath("//div[@class='mat-form-field-infix ng-tns-c112-13']"));
            typeDropdown.Click();

            IWebElement insured = driver.FindElement(By.XPath("//span[normalize-space(text())='Insured']"));
            insured.Click();
        }

        public void EnterCode(string code)
        {
            fields[3].SendKeys(code);
        }
    }
}
