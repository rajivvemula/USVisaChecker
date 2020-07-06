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
        WebDriverWait wait;

        public PolicyContacts(IWebDriver driver)
        {
            policyDriver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
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
        public IWebElement inputRemarks => policyDriver.FindElement(By.Name("remarks"));
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
            bool verify = policyDriver.FindElement(By.XPath("//mat-label[contains(text(),'" + label + "')]")).Displayed;
            return verify;
        }
        public bool CheckDropDownValue(string value)
        {
            bool verify = policyDriver.FindElement(By.XPath("//span[@class='mat-option-text' and normalize-space(text())='" + value + "']")).Displayed;
            return verify;
        }
        public bool CheckEmailError()
        {
            IWebElement error = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//mat-error[contains(text(),'Email is invalid')]")));
            bool verifyError = error.Displayed;
            return verifyError;
            
        }
    }
}
