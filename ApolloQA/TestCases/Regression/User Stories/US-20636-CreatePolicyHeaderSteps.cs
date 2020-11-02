using ApolloQA.Helpers;
using ApolloQA.Pages.Login;
using ApolloQA.Pages.Policy;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression
{
    [Binding]
    public sealed class _20636_CreatePolicyHeaderSteps
    {
        public IWebDriver driver;
        LoginPage loginpage;
        PolicyHeader header;
        PolicyGrid policyNumber;

        public _20636_CreatePolicyHeaderSteps(IWebDriver Driver)
        {
            driver = Driver;
            loginpage = new LoginPage(Driver);
            header = new PolicyHeader(Driver);
            policyNumber = new PolicyGrid(Driver);
        }

        [Given(@"user landed biBerk homepage")]
        public void GivenUserLandedBiBerkHomepage()
        {
            driver.Navigate().GoToUrl(Defaults.QA_URLS["Home"]);
            loginpage.loginValidUser(Defaults.ADMIN_USERNAME, Defaults.DEFAULT_PASSWORD);
        }

        [When(@"user click on Policy CTA then user landed Policy grid page")]
        public void WhenUserClickOnPolicyCTAThenUserLandedPolicyGridPage()
        {
            JavaScriptExecutor.highlight(driver, policyNumber.PolicyCTA);
            policyNumber.PolicyCTA.Click();
        }

        [When(@"user clicks on existing ""(.*)"" then user landed Policy details page")]
        public void WhenUserClicksOnExistingThenUserLandedPolicyDetailsPage(int p0)
        {
            JavaScriptExecutor.highlight(driver, policyNumber.getPolicyNumberElement(p0));
            policyNumber.getPolicyNumberElement(p0).Click();
            Thread.Sleep(2000);
        }

        [Then(@"user verify ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"",""(.*)"" and ""(.*)""")]
        public void ThenUserVerifyAnd(string p0, string p1, string p2, string p3, string p4, string p5, string p6, string p7, string p8, string p9, string p10)
        {
            string [] aryValues = { p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };
            string [] aryLabels = { "Policy Number", "Business Name", "Status", "Effective Date", "Expiration Date", "Line of Business", "Carrier", "Agency", "Underwriter", "Products", "Alerts" };
            checkPolicyHeadersDetails(aryValues, aryLabels);
        }

        [When(@"user clicks on Chevron CTA then Policy Header should be displayed as collpased view")]
        public void WhenUserClicksOnChevronCTAThenPolicyHeaderShouldBeDisplayedAsCollpasedView()
        {
            JavaScriptExecutor.highlight(driver, header.chevronCTA);
            header.chevronCTA.Click();
            JavaScriptExecutor.highlight(driver, header.chevronCTA, 0);
        }

        [Then(@"user verify collapsed view ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"" and ""(.*)""")]
        public void ThenUserVerifyAnd(string p0, string p1, string p2, string p3, string p4, string p5)
        {
            string[] aryValues = { p0, p1, p2, p3, p4, p5 };
            string[] aryLabels = { "Policy Number", "Business Name", "Status", "Effective Date", "Expiration Date", "Alerts" };
            checkPolicyHeadersDetails(aryValues, aryLabels);
        }

        [When(@"user clicks on page then user landed realted page")]
        public void WhenUserClicksOnPageThenUserLandedRealtedPage()
        {
            header.pagesName.Click();
        }

        public void checkPolicyHeadersDetails(string[] aryValues, string [] aryLabels)
        {
            for (int i = 0; i < aryValues.Length; i++)
            {
                IWebElement valueElement = header.getElementFor(aryLabels[i]);
                JavaScriptExecutor.highlight(driver, valueElement);
                Assert.AreEqual(valueElement.Text, aryValues[i]);
                JavaScriptExecutor.highlight(driver, valueElement, 0);
            }
        }

    }
}
