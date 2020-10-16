using ApolloQA.Pages.Policy;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression
{
    [Binding]
    public class R008_PolicyGeneralInformationTabsSteps
    {

        public IWebDriver driver;
        PolicySummary policySummary;


        public R008_PolicyGeneralInformationTabsSteps(IWebDriver Driver)
        {
            driver = Driver;
            policySummary = new PolicySummary(Driver);

        }

        [When(@"I click Renewal Information Tab")]
        public void WhenIClickRenewalInformationTab()
        {
            policySummary.GoToTab("renewal");
        }
        
        [When(@"I click Business Profile Tab")]
        public void WhenIClickBusinessProfileTab()
        {
            policySummary.GoToTab("business");
        }
        
        [When(@"I click Agency Information Tab")]
        public void WhenIClickAgencyInformationTab()
        {
            policySummary.GoToTab("agency");
        }
        
        [When(@"I click Accounting Profile Tab")]
        public void WhenIClickAccountingProfileTab()
        {
            policySummary.GoToTab("accounting");
        }
        
        [When(@"I click Description of Operations Tab")]
        public void WhenIClickDescriptionOfOperationsTab()
        {
            policySummary.GoToTab("operations");
        }
        
        [When(@"I click Web Site Tab")]
        public void WhenIClickWebSiteTab()
        {
            policySummary.GoToTab("website");
        }
        
        [Then(@"Renewal Information info is shown")]
        public void ThenRenewalInformationInfoIsShown()
        {
            string aria = policySummary.VerifyTab("renewal");
            Assert.AreEqual(aria, "true");
        }
        
        [Then(@"Business Profile info is shown")]
        public void ThenBusinessProfileInfoIsShown()
        {
            string aria = policySummary.VerifyTab("business");
            Assert.AreEqual(aria, "true");
        }
        
        [Then(@"Agency Information info is shown")]
        public void ThenAgencyInformationInfoIsShown()
        {
            string aria = policySummary.VerifyTab("agency");
            Assert.AreEqual(aria, "true");
        }
        
        [Then(@"Accounting Profile info is shown")]
        public void ThenAccountingProfileInfoIsShown()
        {
            string aria = policySummary.VerifyTab("accounting");
            Assert.AreEqual(aria, "true");
        }
        
        [Then(@"Description of Operations info is shown")]
        public void ThenDescriptionOfOperationsInfoIsShown()
        {
            string aria = policySummary.VerifyTab("operations");
            Assert.AreEqual(aria, "true");
        }
        
        [Then(@"Web Site info is shown")]
        public void ThenWebSiteInfoIsShown()
        {
            string aria = policySummary.VerifyTab("website");
            Assert.AreEqual(aria, "true");
        }
    }
}
