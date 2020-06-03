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

        public void EnterLOB()
        {
            string lob = "Business Owners";
            // select the drop down list
            policyDriver.FindElement(By.Id(PolicyLocs.locInputLOB)).Click();
            policyDriver.FindElement(By.XPath("//span[@class='mat-option-text' and normalize-space(text())='"+ lob + "']")).Click();
            //create select element object 
            //var selectElement = new SelectElement(education);

            //select by value
            //selectElement.SelectByValue("Commercial Auto");
        }
        public void EnterInsuredOrg()
        {
            policyDriver.FindElement(By.Id(PolicyLocs.locInputOrg)).SendKeys("A MASTER ORGANIZATION");
            policyDriver.FindElement(By.XPath("//div[@class='ng-star-inserted' and normalize-space(text())='A MASTER ORGANIZATION']")).Click();
        }

        public void EnterAgency()
        {
            policyDriver.FindElement(By.Id(PolicyLocs.locInputAgency)).SendKeys("10003");
            policyDriver.FindElement(By.XPath("//div[@class='ng-star-inserted' and normalize-space(text())='10003']")).Click();
        }

        public void EnterBusType()
        {
            policyDriver.FindElement(By.Id(PolicyLocs.locInputBusType)).Click();
            policyDriver.FindElement(By.XPath("//span[@class='mat-option-text' and normalize-space(text())='Corporation']")).Click();
        }

        public void EnterYears()
        {
            policyDriver.FindElement(By.Id(PolicyLocs.locInputYears)).SendKeys("6");
        }

        public void EnterTaxIDType()
        {
            policyDriver.FindElement(By.Id(PolicyLocs.locInputTaxIDType)).Click();
            policyDriver.FindElement(By.XPath("//span[@class='mat-option-text' and normalize-space(text())='FEIN']")).Click();
        }

        public void EnterTaxID()
        {
            policyDriver.FindElement(By.Id(PolicyLocs.locInputTaxID)).SendKeys("12-2222222");
        }

        public void ClickSubmitButton()
        {
            policyDriver.FindElement(By.XPath(PolicyLocs.locSubmitButton)).Click();
        }
    }
}
