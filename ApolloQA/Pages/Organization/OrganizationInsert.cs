using ApolloQA.Pages.Nav;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ApolloQA.Pages.Organization
{
    class OrganizationInsert
    {
        //to hold text fields
        public IList<IWebElement> fields;

        protected IWebDriver driver;
        MainNavBar mainNavBar;

        string submitButtonXPath = "//button[contains(.//span, 'Submit')]";

        public OrganizationInsert(IWebDriver driver)
        {
            this.driver = driver;
            mainNavBar = new MainNavBar(driver);

            //wait for all 
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            fields = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//input[contains(@id,'mat-input')]")));

            //for debugging
            //foreach(IWebElement item in fields)
            //{
            //    Console.WriteLine(item.GetAttribute("outerHTML"));
            //}
        }

        public MainNavBar MainNavBar { get => mainNavBar; }

        public IWebElement NameField => driver.FindElement(By.XPath("(//*[contains(@id,'mat-input')])[2]"));
        public IWebElement AlternateNameField => driver.FindElement(By.XPath("(//*[contains(@id,'mat-input')])[3]"));
        public IWebElement LegalNameField => driver.FindElement(By.XPath("(//*[contains(@id,'mat-input')])[4]"));
        public IWebElement CodeField => driver.FindElement(By.XPath("(//*[contains(@id,'mat-input')])[5]"));


        public void EnterAllValues()
        {
            this.EnterName("Test Organization");
            this.EnterAlternateName("Test Alternate");
            this.EnterLegalName("Test Legal");
            this.SelectType("Insured");
            this.EnterCode("12345");
        }

        public void EnterName(string name)
        {
            NameField.SendKeys(name);
        }

        public void EnterAlternateName(string alternateName)
        {
            AlternateNameField.SendKeys(alternateName);
        }

        public void EnterLegalName(string legalName)
        {
            LegalNameField.SendKeys(legalName);
        }

        public void SelectType(string type)
        {
            //wait for dropdown to be clickable
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement typeDropdown = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//mat-select[@id='mat-select-1']")));
            typeDropdown.Click();

            //click selection
            IWebElement target = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//span[normalize-space(text())='" + type + "']")));
            target.Click();
        }

        public void EnterCode(string code)
        {
            CodeField.SendKeys(code);
        }

        public OrganizationDetails ClickSubmitButton()
        {
            //wait for new button to be clickable
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement submitButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(submitButtonXPath)));

            submitButton.Click();

            return new OrganizationDetails(driver);
        }
    }
}
