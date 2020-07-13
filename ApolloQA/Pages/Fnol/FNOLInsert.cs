using ApolloQA.Helpers;
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
        public IWebElement policyNumberInput => functions.FindElementWait(10,By.Id("mat-input-6"));
        public IWebElement inputFirstName => functions.FindElementWait(10,By.Name("firstName"));
        public IWebElement inputMiddleName => functions.FindElementWait(10,By.Name("middleName"));
        public IWebElement inputLastName => functions.FindElementWait(10,By.Name("lastName"));
        public IWebElement inputSuffixName => functions.FindElementWait(10,By.Name("suffix"));
        public IWebElement inputEmail =>functions.FindElementWait(10,By.Name("email"));
        public IWebElement inputPhoneNumber => functions.FindElementWait(10,By.Name("phone"));
        public IWebElement sameAsCheckbox => functions.FindElementWait(10,By.Id("mat-checkbox-1"));
        public IWebElement receivedSelect => functions.FindElementWait(10,By.XPath("//mat-select[@formcontrolname='receivedTypeId']"));
        public IWebElement relatedClaim => functions.FindElementWait(10,By.XPath("//mat-select[@formcontrolname='hasRelatedClaim']"));
        public IWebElement claimCategory => functions.FindElementWait(10,By.XPath("//mat-select[@formcontrolname='claimCategory']"));
        public IWebElement policeInvolved => functions.FindElementWait(10,By.XPath("//mat-select[@formcontrolname='wasPoliceInvolved']"));
        public IWebElement fireInvolved => functions.FindElementWait(10,By.XPath("//mat-select[@formcontrolname='wasFireDepartmentInvolved']"));
        public IWebElement policeName => functions.FindElementWait(10,By.XPath("//input[@formcontrolname='policeDepartmentName']"));
        public IWebElement policeNumber => functions.FindElementWait(10,By.XPath("//input[@formcontrolname='policeReportNumber']"));
        public IWebElement fireName => functions.FindElementWait(10,By.XPath("//input[@formcontrolname='fireDepartmentName']"));
        public IWebElement fireNumber => functions.FindElementWait(10,By.XPath("//input[@formcontrolname='fireReportNumber']"));
        public IWebElement submitButton => functions.FindElementWait(10,By.XPath("//button[@aria-label='Submit']"));
        

        public void EnterDateOfLoss(string date)
        {
            dateOfLossInput.SendKeys(date);
        }
        public void EnterTimeOfLos(string lossTime)
        {
            timeOfLossInput.SendKeys(lossTime);
        }
        public void EnterLosDesc(string desc)
        {
            lossDescInput.SendKeys(desc);
        }
        public void EnterDateReported(string date)
        {
            dateReportedInput.SendKeys(date);
        }
        public void EnterPolicyNumber(string number)
        {
            policyNumberInput.SendKeys(number);
            policyNumberInput.SendKeys(Keys.Enter);

        }

        public void EnterFirstName(string name)
        {
            inputFirstName.SendKeys(name);
        }
        public void EnterMiddleName(string name)
        {
            inputMiddleName.SendKeys(name);
        }
        public void EnterLastName(string name)
        {
            inputLastName.SendKeys(name);
        }
        public void EnterSuffix(string name)
        {
            inputSuffixName.SendKeys(name);
        }
        public void EnterEmail(string email)
        {
            inputEmail.SendKeys(email);
        }

        public void EnterPhoneNumber(string phone)
        {
            inputPhoneNumber.SendKeys(phone);
        }

        public void EnterLossDesc(string desc)
        {
            lossDescInput.SendKeys(desc);
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
            functions.FindElementWait(10, By.XPath("//span[@class='mat-option-text' and normalize-space(text())='Yes']")).Click();
            policeName.SendKeys("test");
            policeNumber.SendKeys("123");
        }

        public void EnterFireInfo()
        {
            fireInvolved.Click();
            functions.FindElementWait(10, By.XPath("//span[@class='mat-option-text' and normalize-space(text())='Yes']")).Click();
            fireName.SendKeys("test");
            fireNumber.SendKeys("123");
        }
        public void SelectHowNoticeReceived()
        {
            // modify later to receive selection
            receivedSelect.Click();
            functions.FindElementWait(10, By.XPath("//span[@class='mat-option-text' and normalize-space(text())='Email']")).Click();
        }
        public void SelectRelatedClaim()
        {
            // modify later to receive selection
            relatedClaim.Click();
            functions.FindElementWait(10, By.XPath("//span[@class='mat-option-text' and normalize-space(text())='Yes']")).Click();
        }
        public void SelectClaimCategory()
        {
            // modify later to receive selection
            claimCategory.Click();
            functions.FindElementWait(10, By.XPath("//span[@class='mat-option-text' and normalize-space(text())='Option 1']")).Click();
        }

        public void SubmitFNOL()
        {
            submitButton.Click();
        }
    }
}
