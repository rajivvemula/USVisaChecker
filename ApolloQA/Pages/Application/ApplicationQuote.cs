using ApolloQA.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Application
{
    class ApplicationQuote
    {
        private IWebDriver driver;
        private Functions functions;
        private Components components;

        public ApplicationQuote(IWebDriver driver)
        {
            this.driver = driver;
            functions = new Functions(driver);
            components = new Components(driver);
        }

        private IWebElement businessName => functions.FindElementWait(10, By.XPath("//bh-input-autocomplete[@formcontrolname='insuredPartyId']"));
        private IWebElement agencyName => functions.FindElementWait(10, By.XPath("//bh-input-autocomplete[@formcontrolname='insuredAgencyId']"));
        private IWebElement carrierName => functions.FindElementWait(10, By.XPath("//bh-input-autocomplete[@formcontrolname='insuredCarrierId']"));
        private IWebElement lobType => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='lineId']"));
        private IWebElement effectiveDate => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='policyEffectiveDate']"));
        private IWebElement expirationDate => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='policyExpirationDate']"));
        private IWebElement nextButton => functions.FindElementWait(10, By.XPath("//button[@aria-label='Submit']"));

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
            effectiveDate.SendKeys(effDate);
        }

        public void EnterExpirationDate(string expDate)
        {
            expirationDate.SendKeys(expDate);
        }

        public void ClickNext()
        {
            nextButton.Click();
        }
    }
}
