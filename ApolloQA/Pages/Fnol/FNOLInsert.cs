using ApolloQA.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ApolloQA.Pages.Fnol
{
    class FNOLInsert
    {

        private IWebDriver fnolDriver;
        private Functions functions;

        public FNOLInsert(IWebDriver driver)
        {
            fnolDriver = driver;
            functions = new Functions(driver);
        }

        public IWebElement dateOfLossInput => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='dateOfLoss']"));
        public IWebElement timeOfLossInput => functions.FindElementWait(10,By.XPath("//input[@formcontrolname='timeOfLoss']"));
        public IWebElement lossDescInput => functions.FindElementWait(10,By.XPath("//textarea[@formcontrolname='lossDescription']"));
        public IWebElement dateReportedInput => functions.FindElementWait(10,By.XPath("//input[@formcontrolname='dateReported']"));
        public IWebElement policyNumberInput => functions.FindElementWait(10,By.XPath("//bh-input-autocomplete[@name='policyNumberControl']"));
        public IWebElement inputFirstName => functions.FindElementWait(10,By.Name("firstName"));
        public IWebElement inputMiddleName => functions.FindElementWait(10,By.Name("middleName"));
        public IWebElement inputLastName => functions.FindElementWait(10,By.Name("lastName"));
        public IWebElement inputSuffixName => functions.FindElementWait(10,By.Name("suffix"));
        public IWebElement inputEmail =>functions.FindElementWait(10,By.Name("email"));
        public IWebElement inputPhoneNumber => functions.FindElementWait(10,By.Name("phone"));
        public IWebElement sameAsCheckbox => functions.FindElementWait(10, By.XPath("//span[@class='mat-checkbox-label' and normalize-space(text())='Same as Reported By']"));
        public IWebElement receivedSelect => functions.FindElementWait(10,By.XPath("//mat-select[@formcontrolname='receivedTypeId']"));
        public IWebElement relatedClaim => functions.FindElementWait(10,By.XPath("//mat-select[@formcontrolname='hasRelatedClaim']"));
        public IWebElement phoneSelect => functions.FindElementWait(10, By.XPath("//mat-select[@name='phoneTypeId']"));
        public IWebElement claimCategory => functions.FindElementWait(10,By.XPath("//mat-select[@formcontrolname='catastropheTypeId']"));
        public IWebElement policeInvolved => functions.FindElementWait(10,By.XPath("//mat-select[@formcontrolname='wasPoliceInvolved']"));
        public IWebElement fireInvolved => functions.FindElementWait(10,By.XPath("//mat-select[@formcontrolname='wasFireDepartmentInvolved']"));
        public IWebElement policeName => functions.FindElementWait(10,By.XPath("//input[@formcontrolname='policeDepartmentName']"));
        public IWebElement policeNumber => functions.FindElementWait(10,By.XPath("//input[@formcontrolname='policeReportNumber']"));
        public IWebElement fireName => functions.FindElementWait(10,By.XPath("//input[@formcontrolname='fireDepartmentName']"));
        public IWebElement fireNumber => functions.FindElementWait(10,By.XPath("//input[@formcontrolname='fireReportNumber']"));
        public IWebElement submitButton => functions.FindElementWait(10,By.XPath("//button[@aria-label='Loss Details']"));

        public IWebElement getElementFromFieldname(string fieldName)
        {
            switch (fieldName)
            {
                case "dateOfLoss": return dateOfLossInput;
                case "timeOfLoss": return timeOfLossInput;
                case "lossDesc": return lossDescInput; 
                case "dateReported": return dateReportedInput;
                case "policyNumber": return policyNumberInput;
                case "firstName": return inputFirstName;
                case "middleName": return inputMiddleName;
                case "lastName": return inputLastName;
                case "suffixName": return inputSuffixName;
                case "email": return inputEmail;
                case "phoneNumber": return inputPhoneNumber;
                case "phoneType": return phoneSelect;
                case "sameAs": return sameAsCheckbox;
                case "received": return receivedSelect;
                case "related": return relatedClaim;
                case "claimCategory": return claimCategory;
                case "policeInvolved": return policeInvolved;
                case "fireInvolved": return fireInvolved;
                case "policeName": return policeName;
                case "policeNumber": return policeNumber;
                case "fireName": return fireName;
                case "fireNumber": return fireNumber;
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

