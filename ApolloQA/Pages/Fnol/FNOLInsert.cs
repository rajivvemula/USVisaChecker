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
        public FNOLInsert(IWebDriver driver)
        {
            fnolDriver = driver;
        }

        public IWebElement dateOfLossInput => fnolDriver.FindElement(By.XPath("//input[@formcontrolname='dateOfLoss']"));
        public IWebElement timeOfLossInput => fnolDriver.FindElement(By.XPath("//input[@formcontrolname='timeOfLoss']"));
        public IWebElement lossDescInput => fnolDriver.FindElement(By.XPath("//textarea[@formcontrolname='lossDescription']"));
        public IWebElement dateReportedInput => fnolDriver.FindElement(By.XPath("//input[@formcontrolname='dateReported']"));
        public IWebElement policyNumberInput => fnolDriver.FindElement(By.Id("mat-input-6"));
        public IWebElement inputFirstName => fnolDriver.FindElement(By.Name("firstName"));
        public IWebElement inputMiddleName => fnolDriver.FindElement(By.Name("middleName"));
        public IWebElement inputLastName => fnolDriver.FindElement(By.Name("lastName"));
        public IWebElement inputSuffixName => fnolDriver.FindElement(By.Name("suffix"));
        public IWebElement inputEmail => fnolDriver.FindElement(By.Name("email"));
        public IWebElement inputPhoneNumber => fnolDriver.FindElement(By.Name("phone"));
        public IWebElement sameAsCheckbox => fnolDriver.FindElement(By.Id("mat-checkbox-1-input"));
        public IWebElement receivedSelect => fnolDriver.FindElement(By.XPath("//mat-select[@formcontrolname='receivedTypeId']"));
        public IWebElement relatedClaim => fnolDriver.FindElement(By.XPath("//mat-select[@formcontrolname='hasRelatedClaim']"));
        public IWebElement claimCategory => fnolDriver.FindElement(By.XPath("//mat-select[@formcontrolname='claimCategory']"));
        public IWebElement policeInvolved => fnolDriver.FindElement(By.XPath("//mat-select[@formcontrolname='wasPoliceInvolved']"));
        public IWebElement fireInvolved => fnolDriver.FindElement(By.XPath("//mat-select[@formcontrolname='wasFireDepartmentInvolved']"));
        public IWebElement policeName => fnolDriver.FindElement(By.XPath("//input[@formcontrolname='policeDepartmentName']"));
        public IWebElement policeNumber => fnolDriver.FindElement(By.XPath("//input[@formcontrolname='policeReportNumber']"));
        public IWebElement fireName => fnolDriver.FindElement(By.XPath("//input[@formcontrolname='fireDepartmentName']"));
        public IWebElement fireNumber => fnolDriver.FindElement(By.XPath("//input[@formcontrolname='fireReportNumber']"));
        public IWebElement submitButton => fnolDriver.FindElement(By.XPath("//button[@aria-label='Submit']"));
        public void SelectDropDownValue()
        {

        }

        public void EnterAllInputs()
        {
            
            inputFirstName.SendKeys("test111");
            inputMiddleName.SendKeys("test");
            inputLastName.SendKeys("test");
            inputSuffixName.SendKeys("test");
            inputEmail.SendKeys("test@email.com");
            inputPhoneNumber.SendKeys("(123) 123-1234");
            lossDescInput.SendKeys("test");
            policyNumberInput.SendKeys("12843");
            SelectHowNoticeReceived();
            SelectRelatedClaim();
            SelectClaimCategory();
            EnterFireInfo();
            EnterPoliceInfo();
            
            //sameAsCheckbox.Click();
            Thread.Sleep(5000);
            SubmitFNOL();
        }

        public void EnterPoliceInfo()
        {
            policeInvolved.Click();
            fnolDriver.FindElement(By.XPath("//span[@class='mat-option-text' and normalize-space(text())='Yes']")).Click();
            policeName.SendKeys("test");
            policeNumber.SendKeys("123");
        }

        public void EnterFireInfo()
        {
            fireInvolved.Click();
            fnolDriver.FindElement(By.XPath("//span[@class='mat-option-text' and normalize-space(text())='Yes']")).Click();
            fireName.SendKeys("test");
            fireNumber.SendKeys("123");
        }
        public void SelectHowNoticeReceived()
        {
            // modify later to receive selection
            receivedSelect.Click();
            fnolDriver.FindElement(By.XPath("//span[@class='mat-option-text' and normalize-space(text())='Email']")).Click();
        }
        public void SelectRelatedClaim()
        {
            // modify later to receive selection
            relatedClaim.Click();
            fnolDriver.FindElement(By.XPath("//span[@class='mat-option-text' and normalize-space(text())='Yes']")).Click();
        }
        public void SelectClaimCategory()
        {
            // modify later to receive selection
            claimCategory.Click();
            fnolDriver.FindElement(By.XPath("//span[@class='mat-option-text' and normalize-space(text())='Option 1']")).Click();
        }

        public void SubmitFNOL()
        {
            submitButton.Click();
        }
    }
}
