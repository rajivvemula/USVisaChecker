using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Policy
{
    class PolicyContacts
    {

        private IWebDriver policyDriver;
        public PolicyContacts(IWebDriver driver)
        {
            policyDriver = driver;

        }

        public IWebElement addContact => policyDriver.FindElement(By.XPath("//button[@aria-label='Add Contact']"));
        public IWebElement partyRole => policyDriver.FindElement(By.Id("partyRole"));
        public IWebElement inputFirstName => policyDriver.FindElement(By.Name("firstName"));
        public IWebElement inputMiddleName => policyDriver.FindElement(By.Name("middleName"));
        public IWebElement inputLastName => policyDriver.FindElement(By.Name("lastName"));
        public IWebElement inputSuffixName => policyDriver.FindElement(By.Name("suffix"));
        public IWebElement inputEmail => policyDriver.FindElement(By.Name("email"));
        public IWebElement inputJobTitle => policyDriver.FindElement(By.XPath("//input[@formcontrolname='jobTitle']"));
        public IWebElement inputCompany => policyDriver.FindElement(By.XPath("//input[@formcontrolname='company']"));
        public IWebElement inputInternet => policyDriver.FindElement(By.XPath("//input[@formcontrolname='internetAddress']"));
        public IWebElement phoneType => policyDriver.FindElement(By.XPath("//mat-select[@id='mat-select-1']"));
        public IWebElement inputPhoneNumber=> policyDriver.FindElement(By.Name("phone"));
        public IWebElement inputExtension => policyDriver.FindElement(By.Name("extension"));

        public IWebElement submitButton => policyDriver.FindElement(By.XPath("//button[@aria-label='Submit']"));
        public void ClickAddContact()
        {
            addContact.Click();
        }

        public void EnterPartyRole()
        {
            partyRole.Click();
            policyDriver.FindElement(By.XPath("//span[@class='mat-option-text' and normalize-space(text())='Underwriter']")).Click();
        }
        public void EnterPhoneType()
        {
            phoneType.Click();
            policyDriver.FindElement(By.XPath("//span[@class='mat-option-text' and normalize-space(text())='Business']")).Click();
        }
        public void EmptyClick()
        {
            //to prevent error in automation, sometimes entering select dropdowns dont click properly.
            inputFirstName.Click();
        }

        public void EnterAllInputs()
        {
            inputFirstName.SendKeys("test");
            inputMiddleName.SendKeys("test");
            inputLastName.SendKeys("test");
            inputSuffixName.SendKeys("test");
            inputEmail.SendKeys("test@email.com");
            inputJobTitle.SendKeys("test");
            inputCompany.SendKeys("test");
            inputInternet.SendKeys("test");
            inputPhoneNumber.SendKeys("1231231234");
        }
        public void SubmitContact()
        {
            submitButton.Click();
        }
    }
}
