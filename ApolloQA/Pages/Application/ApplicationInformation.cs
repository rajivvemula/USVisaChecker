using System;
using System.Collections.Generic;
using System.Text;
using ApolloQA.Helpers;
using OpenQA.Selenium;

namespace ApolloQA.Pages.Application
{
    class ApplicationInformation
    {
        private IWebDriver driver;
        private Functions functions;
        private Components components;

        public ApplicationInformation(IWebDriver driver)
        {
            this.driver = driver;
            functions = new Functions(driver);
            components = new Components(driver);
        }

        //auto-completes
        public IWebElement businessName => functions.FindElementWait(10, By.XPath("//bh-input-autocomplete[@formcontrolname='insuredPartyId']/input"));
        public IWebElement agencyName => functions.FindElementWait(10, By.XPath("//bh-input-autocomplete[@formcontrolname='insuredAgencyId']"));
        private IWebElement carrierName => functions.FindElementWait(10, By.XPath("//bh-input-autocomplete[@formcontrolname='insuredCarrierId']"));

        //drop-downs
        public IWebElement lobType => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='lineId']"));

        //inputs
        public IWebElement effectiveDate => functions.FindElementWaitUntilClickable(10, By.XPath("//input[@formcontrolname='policyEffectiveDate']"));
        public IWebElement expirationDate => functions.FindElementWaitUntilClickable(10, By.XPath("//input[@formcontrolname='policyExpirationDate']"));
        public IWebElement nextButton => functions.FindElementWaitUntilClickable(10, By.XPath("//button[@aria-label='Submit']"));

        public void EnterBusinessName(string businessName)
        {
            components.UpdateAutoCompleteInput("insuredPartyId", businessName);
        }

        public void SelectLOB(string lobName)
        {
            components.UpdateDropdown("lineId", lobName);
        }

        public void EnterAgency(string agencyName)
        {
            components.UpdateAutoCompleteInput("insuredAgencyId", agencyName);
        }

        public void EnterCarrier(string carrierName)
        {
            components.UpdateAutoCompleteInput("insuredCarrierId", carrierName);
        }

        public void EnterEffectiveDate(string effDate)
        {
            effectiveDate.SendKeys(Keys.Control + "a");
            effectiveDate.SendKeys(Keys.Backspace);
            effectiveDate.SendKeys(effDate);
        }

        public void EnterExpirationDate(string expDate)
        {
            expirationDate.SendKeys(Keys.Control + "a");
            expirationDate.SendKeys(Keys.Backspace);
            expirationDate.SendKeys(expDate);
        }

        public void ClickNext()
        {
            nextButton.Click();
        }
    }
}
