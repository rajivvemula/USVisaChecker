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
        public PolicyCreation(IWebDriver driver)
        {
            policyDriver = driver;
        }

        public IWebElement inputInsured => policyDriver.FindElement(By.XPath("//bh-input-autocomplete[@formcontrolname ='insuredPartyId']/input"));
        public IWebElement inputAgency => policyDriver.FindElement(By.XPath("//bh-input-autocomplete[@formcontrolname ='agencyPartyId']/input"));
        public IWebElement inputEffective => policyDriver.FindElement(By.XPath("//input[@formcontrolname='timeFrom']"));
        public IWebElement inputExpiration => policyDriver.FindElement(By.XPath("//input[@formcontrolname='timeTo']"));
        public IWebElement inputIssue => policyDriver.FindElement(By.XPath("//input[@formcontrolname='issueDate']"));
        public IWebElement inputYears => policyDriver.FindElement(By.XPath("//input[@formcontrolname='yearsInBusiness']"));
        public IWebElement inputID => policyDriver.FindElement(By.XPath("//input[@formcontrolname='taxId']"));
        public IWebElement selectLOB => policyDriver.FindElement(By.XPath("//mat-select[@formcontrolname='lineId']"));
        public IWebElement selectBus => policyDriver.FindElement(By.XPath("//mat-select[@formcontrolname='businessTypeEntityId']"));
        public IWebElement selecID => policyDriver.FindElement(By.XPath("//mat-select[@formcontrolname='taxIdType']"));
        public IWebElement submitButton => policyDriver.FindElement(By.XPath("//button[@aria-label='Submit']"));

        //For Dev Purposes
        public void EnterDefaultInputs()
        {
            inputInsured.SendKeys("A MASTER Organization");
            inputInsured.SendKeys(Keys.Enter);
            inputAgency.SendKeys("10003");
            inputAgency.SendKeys(Keys.Enter);
            selectLOB.Click();
            policyDriver.FindElement(By.XPath("//span[@class='mat-option-text' and normalize-space(text())='Business Owners']")).Click();
            selectBus.Click();
            policyDriver.FindElement(By.XPath("//span[@class='mat-option-text' and normalize-space(text())='Corporation']")).Click();
            selecID.Click();
            policyDriver.FindElement(By.XPath("//span[@class='mat-option-text' and normalize-space(text())='FEIN']")).Click();
            inputYears.SendKeys("6");
            inputID.SendKeys("12-2222222");

        }
        public void EnterLOB(string lob)
        {
            
            selectLOB.Click();
            policyDriver.FindElement(By.XPath("//span[@class='mat-option-text' and normalize-space(text())='"+ lob + "']")).Click();
           
        }
        public void EnterInsuredOrg(string org)
        {
            inputInsured.SendKeys(org);
            inputInsured.SendKeys(Keys.Enter);
        }

        public void EnterAgency(string agency)
        {
            inputAgency.SendKeys(agency);
            inputAgency.SendKeys(Keys.Enter);
            
        }

        public void EnterBusType(string corp)
        {
            selectBus.Click();
            policyDriver.FindElement(By.XPath("//span[@class='mat-option-text' and normalize-space(text())='" + corp + "']")).Click();
        }

        public void EnterYears(string year)
        {
            inputYears.SendKeys(year);
        }

        public void EnterTaxIDType(string idType)
        {
            selecID.Click();
            policyDriver.FindElement(By.XPath("//span[@class='mat-option-text' and normalize-space(text())='" + idType + "']")).Click();
        }

        public void EnterTaxID(string taxID)
        {
            inputID.SendKeys(taxID);
        }

        public void ClickSubmitButton()
        {
            submitButton.Click();
        }
    }
}
