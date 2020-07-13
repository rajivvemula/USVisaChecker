using ApolloQA.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Policy
{
    class PolicyContacts
    {

        private IWebDriver policyDriver;
        Functions functions;

        public PolicyContacts(IWebDriver driver)
        {
            policyDriver = driver;
            functions = new Functions(driver);
        }

        public readonly string[] contactLabels =
        {
            "Contact Party Role",
            "First Name",
            "Middle Name",
            "Last Name",
            "Suffix",
            "Email",
            "Job Title",
            "Company",
            "Internet Address",
            "Remarks",
            "Phone Type",
            "Phone Number"
        };

        public readonly string[] partyDropDownValues =
        {
            "Customer Service Representative",
            "Underwriter",
            "Producer",
            "Loss Control",
            "Executive",
            "Billing",
            "Auditor",
            "Risk Manager",
            "Claims",
            "Finance",
            "Policy Holder",
            "Agency Billing",
            "Other"
        };


        public IWebElement addContact => functions.FindElementWait(10, By.XPath("//button[@aria-label='Add Contact']"));
        public IWebElement partyRole => functions.FindElementWait(10, By.Id("partyRole"));
        public IWebElement inputFirstName => functions.FindElementWait(10, By.Name("firstName"));
        public IWebElement inputMiddleName => functions.FindElementWait(10, By.Name("middleName"));
        public IWebElement inputLastName => functions.FindElementWait(10, By.Name("lastName"));
        public IWebElement inputSuffixName => functions.FindElementWait(10, By.Name("suffix"));
        public IWebElement inputEmail => functions.FindElementWait(10, By.Name("email"));
        public IWebElement inputJobTitle => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='jobTitle']"));
        public IWebElement inputCompany => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='company']"));
        public IWebElement inputInternet => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='internetAddress']"));
        public IWebElement inputRemarks => functions.FindElementWait(10, By.Name("remarks"));
        public IWebElement phoneType => functions.FindElementWait(10, By.XPath("//mat-select[@id='mat-select-1']"));
        public IWebElement inputPhoneNumber=> functions.FindElementWait(10, By.Name("phone"));
        public IWebElement inputExtension => functions.FindElementWait(10, By.Name("extension"));

        public IWebElement submitButton => functions.FindElementWait(10, By.XPath("//button[@aria-label='Submit']"));

        public void ClickAddContact()
        {
            addContact.Click();
        }

        public void EnterPartyRole()
        {
            partyRole.Click();
            functions.FindElementWait(10, By.XPath("//span[@class='mat-option-text' and normalize-space(text())='Underwriter']")).Click();
        }
        public void EnterPhoneType()
        {
            phoneType.Click();
            functions.FindElementWait(10, By.XPath("//span[@class='mat-option-text' and normalize-space(text())='Business']")).Click();
        }
        public void EmptyClick()
        {
            //to prevent error in automation, sometimes entering select dropdowns dont click properly.
            inputFirstName.Click();
        }
        public void EnterFirstName(string name)
        {
            inputFirstName.SendKeys(name);
        }
        public string GetFirstName()
        {
            string value = inputFirstName.GetAttribute("value");
            return value;
        }

        public void EnterMiddleName(string name)
        {
            inputMiddleName.SendKeys(name);
        }
        public string GetMiddleName()
        {
            string value = inputMiddleName.GetAttribute("value");
            return value;
        }

        public void EnterLastName(string name)
        {
            inputLastName.SendKeys(name);
        }
        public string GetLastName()
        {
            string value = inputLastName.GetAttribute("value");
            return value;
        }

        public void EnterSuffixName(string name)
        {
            inputSuffixName.SendKeys(name);
        }
        public string GetSuffixName()
        {
            string value = inputSuffixName.GetAttribute("value");
            return value;
        }

        public void EnterEmail(string name)
        {
            inputEmail.SendKeys(name);
        }
        public string GetEmail()
        {
            string value = inputEmail.GetAttribute("value");
            return value;
        }

        public void EnterJobTitle(string name)
        {
            inputJobTitle.SendKeys(name);
        }
        public string GetJobTitle()
        {
            string value = inputJobTitle.GetAttribute("value");
            return value;
        }


        public void EnterCompany(string name)
        {
            inputCompany.SendKeys(name);
        }
        public string GetCompany()
        {
            string value = inputCompany.GetAttribute("value");
            return value;
        }

        public void EnterInternet(string name)
        {
            inputInternet.SendKeys(name);
        }
        public string GetInternet()
        {
            string value = inputInternet.GetAttribute("value");
            return value;
        }

        public void EnterRemarks(string name)
        {
            inputRemarks.SendKeys(name);
        }
        public string GetRemarks()
        {
            string value = inputRemarks.GetAttribute("value");
            return value;
        }

        public void EnterPhoneNumber(string name)
        {
            inputPhoneNumber.SendKeys(name);
        }
        public string GetPhoneNumber()
        {
            string value = inputPhoneNumber.GetAttribute("value");
            return value;
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

        public bool CheckLabel(string label)
        {
            bool verify = functions.FindElementWait(10, By.XPath("//mat-label[contains(text(),'" + label + "')]")).Displayed;
            return verify;
        }
        public bool CheckDropDownValue(string value)
        {
            bool verify = functions.FindElementWait(10, By.XPath("//span[@class='mat-option-text' and normalize-space(text())='" + value + "']")).Displayed;
            return verify;
        }
        public bool CheckEmailError()
        {
            IWebElement error = functions.FindElementWait(10, By.XPath("//mat-error[contains(text(),'Email is invalid')]"));
            bool verifyError = error.Displayed;
            return verifyError;
            
        }
    }
}
