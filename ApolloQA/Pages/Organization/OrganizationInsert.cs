using ApolloQA.Helpers;
using ApolloQA.Pages.Shared;
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
        Functions functions;


        public OrganizationInsert(IWebDriver driver)
        {
            this.driver = driver;

            //for debugging
            //foreach(IWebElement item in fields)
            //{
            //    Console.WriteLine(item.GetAttribute("outerHTML"));
            //}
        }

        public IWebElement NameField => functions.FindElementWait(10, By.XPath("(//*[contains(@id,'mat-input')])[2]"));
        public IWebElement AlternateNameField => functions.FindElementWait(10, By.XPath("(//*[contains(@id,'mat-input')])[3]"));
        public IWebElement LegalNameField => functions.FindElementWait(10, By.XPath("(//*[contains(@id,'mat-input')])[4]"));
        public IWebElement CodeField => functions.FindElementWait(10, By.XPath("(//*[contains(@id,'mat-input')])[5]"));
        public IWebElement SubmitButton => functions.FindElementWait(10, By.XPath("//button[contains(.//span, 'Submit')]"));
        


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

        public void ClickSubmitButton()
        {
            SubmitButton.Click();
        }
    }
}
