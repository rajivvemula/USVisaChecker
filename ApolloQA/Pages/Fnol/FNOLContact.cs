using ApolloQA.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Fnol
{
    class FNOLContact
    {
        private IWebDriver fnolDriver;
        private Functions functions;

        public FNOLContact(IWebDriver driver)
        {
            fnolDriver = driver;
            functions = new Functions(driver);
        }

        public IWebElement newContact => functions.FindElementWait(10, By.XPath("//button[@aria-label='New Contact']"));
        public IWebElement partyType => functions.FindElementWait(10, By.XPath("//mat-select[@name='partyType']"));
        public IWebElement partyRole => functions.FindElementWait(10, By.XPath("//mat-select[@name='partyRole']"));
        public IWebElement phoneType => functions.FindElementWait(10, By.XPath("//mat-select[@name='phoneTypeId']"));
        public IWebElement inputFirstName => functions.FindElementWait(10, By.Name("firstName"));
        public IWebElement inputMiddleName => functions.FindElementWait(10, By.Name("middleName"));
        public IWebElement inputLastName => functions.FindElementWait(10, By.Name("lastName"));
        public IWebElement inputSuffixName => functions.FindElementWait(10, By.Name("suffix"));
        public IWebElement inputEmail => functions.FindElementWait(10, By.Name("email"));
        public IWebElement inputPhone => functions.FindElementWait(10, By.XPath("//input[@name='phone']"));
        public IWebElement inputRemarks => functions.FindElementWait(10, By.XPath("//textarea[@name='remarks']"));

        public IWebElement getElementFromFieldname(string fieldName)
        {
            switch (fieldName)
            {
                case "partyRole": return partyRole;
                case "partyType": return partyRole;
                case "first": return inputFirstName;
                case "middle": return inputMiddleName;
                case "last": return inputLastName;
                case "suffix": return inputSuffixName;
                case "email": return inputEmail;
                case "remarks": return inputRemarks;
                case "phonetype": return phoneType;
                case "phonenumber": return inputPhone;
                default: return null;

            }
        }

        public void EnterInput(string locator, string value)
        {
            getElementFromFieldname(locator).SendKeys(value);
        }

        public void EnterSelect(string locator, string value)
        {
            getElementFromFieldname(locator).Click();
            functions.FindElementWait(10, By.XPath("//span[@class='mat-option-text' and normalize-space(text())='" + value + "']")).Click();
        }
    }
}
