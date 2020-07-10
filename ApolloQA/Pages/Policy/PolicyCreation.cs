using ApolloQA.DataFiles;
using ApolloQA.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Policy
{
    class PolicyCreation
    {

        private IWebDriver policyDriver;
        private Functions functions;

        public PolicyCreation(IWebDriver driver)
        {
            policyDriver = driver;
            functions = new Functions(driver);
        }

        public IWebElement inputInsured => functions.FindElementWait(10, By.XPath("//bh-input-autocomplete[@formcontrolname ='insuredPartyId']/input"));
        public IWebElement inputAgency => functions.FindElementWait(10, By.XPath("//bh-input-autocomplete[@formcontrolname ='agencyPartyId']/input"));
        public IWebElement inputCarrier => functions.FindElementWait(10, By.XPath("//bh-input-autocomplete[@formcontrolname ='carrierPartyId']/input"));
        public IWebElement inputEffective => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='timeFrom']"));
        public IWebElement inputExpiration => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='timeTo']"));
        public IWebElement inputIssue => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='issueDate']"));
        public IWebElement inputYears => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='yearsInBusiness']"));
        public IWebElement inputID => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='taxId']"));
        public IWebElement selectLOB => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='lineId']"));
        public IWebElement selectBus => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='businessTypeEntityId']"));
        public IWebElement selecID => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='taxIdType']"));
        public IWebElement submitButton => functions.FindElementWait(10, By.XPath("//button[@aria-label='Submit']"));
        public IWebElement cancelButton => functions.FindElementWait(10, By.XPath("//button[@aria-label='Cancel']"));

        //For Dev Purposes
        public void EnterDefaultInputs()
        {
            //inputInsured.SendKeys("A MASTER Organization");
            //inputInsured.SendKeys(Keys.Enter);
            //inputAgency.SendKeys("10003");
            //inputAgency.SendKeys(Keys.Enter);
            //selectLOB.Click();
            //policyDriver.FindElement(By.XPath("//span[@class='mat-option-text' and normalize-space(text())='Business Owners']")).Click();
            //selectBus.Click();
            //policyDriver.FindElement(By.XPath("//span[@class='mat-option-text' and normalize-space(text())='Corporation']")).Click();
            //selecID.Click();
            //policyDriver.FindElement(By.XPath("//span[@class='mat-option-text' and normalize-space(text())='FEIN']")).Click();
            //inputYears.SendKeys("6");
            //inputID.SendKeys("12-2222222");

            EnterInsuredOrg("ACME");
            EnterAgency("A Master Organization");
            EnterCarrier("Berkshire Hathaway Direct Insurance Company");
            EnterLOB("Commercial Auto");
            EnterBusType("Corporation");
            EnterYears("3");
            EnterTaxIDType("FEIN");
            EnterTaxID("12-2222222");
            

        }
        public void EnterLOB(string lob)
        {

            selectLOB.Click();
            functions.FindElementWait(10, By.XPath("//span[@class='mat-option-text' and normalize-space(text())='" + lob + "']")).Click();

        }
        public void EnterInsuredOrg(string org)
        {
            inputInsured.SendKeys(org);

            //have to wait for autocomplete dropdown to appear
            functions.FindElementWait(10, By.XPath("//mat-option[contains(@class,'provided')]"));

            inputInsured.SendKeys(Keys.Enter);
        }

        public void EnterAgency(string agency)
        {
            inputAgency.SendKeys(agency);

            //have to wait for autocomplete dropdown to appear
            functions.FindElementWait(10, By.XPath("//mat-option[contains(@class,'provided')]"));

            inputAgency.SendKeys(Keys.Enter);

        }

        public void EnterCarrier(string carrier)
        {
            inputCarrier.SendKeys(carrier);

            //have to wait for autocomplete dropdown to appear
            functions.FindElementWait(10, By.XPath("//mat-option[contains(@class,'provided')]"));

            inputCarrier.SendKeys(Keys.Enter);

        }

        public void EnterBusType(string corp)
        {
            selectBus.Click();
            functions.FindElementWait(10, By.XPath("//span[@class='mat-option-text' and normalize-space(text())='" + corp + "']")).Click();
        }

        public void EnterYears(string year)
        {
            inputYears.SendKeys(year);
        }

        public void EnterTaxIDType(string idType)
        {
            selecID.Click();
            functions.FindElementWait(10, By.XPath("//span[@class='mat-option-text' and normalize-space(text())='" + idType + "']")).Click();
        }

        public void EnterTaxID(string taxID)
        {
            inputID.SendKeys(taxID);
        }

        public void ClickSubmitButton()
        {
            submitButton.Click();
        }

        public void ClickCancelButton()
        {
            cancelButton.Click();
        }

        public bool CheckHeading()
        {
            IWebElement target = functions.FindElementWait(10, By.XPath("//h3[normalize-space(text())='Insert Policy']"));
            bool verifyHeading = target.Displayed;
            return verifyHeading;
        }
    }
}
