using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;


namespace ApolloQA.Pages.Policy
{
    class PolicySummary
    {

        private IWebDriver policyDriver;
        public PolicySummary(IWebDriver driver)
        {
            policyDriver = driver;
            
        }

        public IList<IWebElement> status => policyDriver.FindElements(By.XPath("//input[contains(@id,'mat-input')]"));

        public static IDictionary<string, string> tabId = new Dictionary<string, string>()
        {
            {"business", "mat-tab-label-0-0" },
            {"renewal", "mat-tab-label-0-1" },
            {"agency", "mat-tab-label-0-2" },
            {"accounting", "mat-tab-label-0-3" },
            {"operations", "mat-tab-label-0-4" },
            {"website", "mat-tab-label-0-5" }
        };
        
        public readonly string[] generalInformationLabels =
        {
            "Policy Number",
            "Insured Party",
            "Agency",
            "Carrier",
            "Line of Business",
            "Effective Date",
            "Expiration Date",
            "Business Type",
            "NAICS",
            "Status",
            "Underwriter",
            "Underwriter Agency"
        };

        public IWebElement businessTab => policyDriver.FindElement(By.XPath("//div[@class='mat-tab-label-content' and normalize-space(text())='Business Profile']"));
        public IWebElement renewalTab => policyDriver.FindElement(By.XPath("//div[@class='mat-tab-label-content' and normalize-space(text())='Renewal Information']"));
        public IWebElement agencyTab => policyDriver.FindElement(By.XPath("//div[@class='mat-tab-label-content' and normalize-space(text())='Agency Information']"));
        public IWebElement accountingTab => policyDriver.FindElement(By.XPath("//div[@class='mat-tab-label-content' and normalize-space(text())='Accounting Profile']"));
        public IWebElement operationsTab => policyDriver.FindElement(By.XPath("//div[@class='mat-tab-label-content' and normalize-space(text())='Description of Operations']"));
        public IWebElement websiteTab => policyDriver.FindElement(By.XPath("//div[@class='mat-tab-label-content' and normalize-space(text())='Web Site']"));
        public IWebElement selectBus => policyDriver.FindElement(By.XPath("//mat-select[@formcontrolname='businessTypeEntityId']"));
        public IWebElement saveButton => policyDriver.FindElement(By.ClassName("save-button"));

        public IWebElement getElementFromFieldname(string fieldName)
        {
            switch (fieldName)
            {
                case "business": return businessTab;
                case "renewal": return renewalTab;
                case "agency": return agencyTab;
                case "accounting": return accountingTab;
                case "operations": return operationsTab;
                case "website": return websiteTab;
                default: return null;

            }
        }

        public string CheckPolicyStatus()
        {
            string policyStatus = status[4].GetAttribute("value");
            return policyStatus;
        }

        public void GoToTab(string id)
        {
            getElementFromFieldname(id).Click();
        }

        public string VerifyTab(string id)
        {
            string selected = policyDriver.FindElement(By.Id(tabId[id])).GetAttribute("aria-selected");
            return selected;
        }

        public bool CheckLabel(string label)
        {
            bool verify = policyDriver.FindElement(By.XPath("//mat-label[contains(text(),'" + label + "')]")).Displayed;
            return verify;
        }
        public void EnterBusType(string corp)
        {
            selectBus.Click();
            policyDriver.FindElement(By.XPath("//span[@class='mat-option-text' and normalize-space(text())='" + corp + "']")).Click();
        }

        public void ClickSaveButton()
        {
            saveButton.Click();
        }


    }
}
