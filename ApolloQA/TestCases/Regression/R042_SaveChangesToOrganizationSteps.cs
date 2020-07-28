using ApolloQA.Helpers;
using ApolloQA.Pages.Organization;
using ApolloQA.Pages.Shared;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression
{
    [Binding]
    public class R042_SaveChangesToOrganizationSteps
    {

        private IWebDriver driver;
        Toaster toaster;
        Components components;
        OrganizationInformation organizationInformation;

        public R042_SaveChangesToOrganizationSteps(IWebDriver Driver)
        {
            driver = Driver;
            toaster = new Toaster(Driver);
            components = new Components(Driver);
            organizationInformation = new OrganizationInformation(Driver);
            
        }

        [Given(@"User is on Business Information Tab")]
        public void GivenUserIsOnBusinessInformationTab()
        {
            Thread.Sleep(5000);
            string verifyh3 = components.Geth3();
            Assert.AreEqual(verifyh3, "Business Information");
        }
        
        [When(@"User changes sub-industry type")]
        public void WhenUserChangesSub_IndustryType()
        {
            organizationInformation.EnterSelect("subtype", "Camps");
        }
        
        [Then(@"Change should be saved to the organization")]
        public void ThenChangeShouldBeSaved()
        {
            organizationInformation.saveButton.Click();

            string verifyToast = toaster.GetToastTitle();
            Assert.That(verifyToast, Does.Contain("was saved."));
        }
    }
}
