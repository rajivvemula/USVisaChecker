using ApolloQA.Helpers;
using ApolloQA.Pages.Policy;
using ApolloQA.Pages.Shared;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression
{
    [Binding]
    public class R004A_CreateAPolicySteps
    {
        public IWebDriver driver;
        Components components;
        PolicyCreation policyCreation;
        PolicyGrid policyGrid;
        Toaster toaster;
        public R004A_CreateAPolicySteps(IWebDriver Driver)
        {
            driver = Driver;
            components = new Components(Driver);
            policyGrid = new PolicyGrid(Driver);
            policyCreation = new PolicyCreation(Driver);
            toaster = new Toaster(driver);
        }

        [Given(@"User is on Policy List Page")]
        public void GivenUserIsOnPolicyListPage()
        {
            bool verifyTitle = components.GetTitle("Policy List");
            Assert.IsTrue(verifyTitle);
        }
        
        [When(@"User clicks New Policy Button")]
        public void WhenUserClicksNewPolicyButton()
        {
            policyGrid.ClickNew();
        }
        
        [When(@"User inputs basic attributes for new policy")]
        public void WhenUserInputsBasicAttributesForNewPolicy()
        {
            policyCreation.EnterDefaultInputs();
        }
        
        [When(@"User clicks on Submit Policy")]
        public void WhenUserClicksOnSubmitPolicy()
        {
            policyCreation.ClickSubmitButton();
        }
        
        [Then(@"User is on Insert Policy Page")]
        public void ThenUserIsOnInsertPolicyPage()
        {
            bool verifyTitle = components.GetTitle("Insert Policy");
            Assert.IsTrue(verifyTitle);
        }
        
        [Then(@"User is shown the toast saying the new policy created")]
        public void ThenUserIsShownTheToastSayingTheNewPolicyCreated()
        {
            string verifyToast = toaster.GetToastTitle();
            Assert.That(verifyToast, Does.Contain("was created"));
        }
    }
}
