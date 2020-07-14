using ApolloQA.Helpers;
using ApolloQA.Pages.Shared;
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
        private Functions functions;
        private RightNavBar rightNavBar;
        private PolicyMain policyMain;
        private PolicySummary policySummary;
        private Components components;

        public PolicySummary(IWebDriver driver)
        {
            policyDriver = driver;
            functions = new Functions(driver);
            rightNavBar = new RightNavBar(driver);
            policyMain = new PolicyMain(driver);
            policySummary = new PolicySummary(driver);
            components = new Components(driver);
        }

        public IList<IWebElement> status => policyDriver.FindElements(By.XPath("//input[contains(@id,'mat-input')]"));


        /* LOCATORS */
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

        /* ELEMENTS */
        public IWebElement businessTab => functions.FindElementWait(10, By.Id("mat-tab-label-0-0"));
        public IWebElement renewalTab => functions.FindElementWait(10, By.Id("mat-tab-label-0-1"));
        public IWebElement agencyTab => functions.FindElementWait(10, By.Id("mat-tab-label-0-2"));
        public IWebElement accountingTab => functions.FindElementWait(10, By.Id("mat-tab-label-0-3"));
        public IWebElement operationsTab => functions.FindElementWait(10, By.Id("mat-tab-label-0-4"));
        public IWebElement websiteTab => functions.FindElementWait(10, By.Id("mat-tab-label-0-5"));
        public IWebElement selectBus => functions.FindElementWait(10, By.XPath("//mat-select[@formcontrolname='businessTypeEntityId']"));
        public IWebElement saveButton => functions.FindElementWait(10, By.ClassName("save-button"));

        /* PERMISSIONS */
        //public bool CanUpdateGeneralInformationTab(string policyNo)
        //{
        //    //search a policy and go to it's general information tab
        //    rightNavBar.SearchQuery(policyNo);
        //    rightNavBar.ClickFirstSearchResult();
        //    policyMain.GoToSummary();
        //    components.UpdateDropdown("businessTypeEntityId", "Non-Profit");
        //    components.UpdateDropdown("businessTypeEntityId", "Corporation");
        //    components.UpdateDropdown("businessTypeEntityId", "Non-Profit");
        //}

        /* COMPONENTS */
        public string CheckPolicyStatus()
        {
            string policyStatus = status[4].GetAttribute("value");
            return policyStatus;
        }

        public void GoToTab(string id)
        {
            policyDriver.FindElement(By.Id(tabId[id])).Click();
        }

        public string VerifyTab(string id)
        {
            string selected = functions.FindElementWait(10, By.Id(tabId[id])).GetAttribute("aria-selected");
            return selected;
        }

        public bool CheckLabel(string label)
        {
            bool verify = functions.FindElementWait(10, By.XPath("//mat-label[contains(text(),'" + label + "')]")).Displayed;
            return verify;
        }
        public void EnterBusType(string corp)
        {
            selectBus.Click();
            functions.FindElementWait(10, (By.XPath("//span[@class='mat-option-text' and normalize-space(text())='" + corp + "']"))).Click();
        }

        public void ClickSaveButton()
        {
            saveButton.Click();
        }


    }
}
