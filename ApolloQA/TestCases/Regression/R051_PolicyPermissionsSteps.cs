using ApolloQA.Pages.Policy;
using ApolloQA.Pages.Shared;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression
{
    [Binding]
    public class R051_PolicyPermissionsSteps
    {
        private IWebDriver driver;
        MainNavBar mainNavBar;
        PolicyGrid policyGrid;
        PolicyCreation policyCreation;
        PolicyMain policyMain;
        Toaster toaster;


        public R051_PolicyPermissionsSteps(IWebDriver driver)
        {
            this.driver = driver;
            mainNavBar = new MainNavBar(driver);
            policyGrid = new PolicyGrid(driver);
            policyCreation = new PolicyCreation(driver);
            policyMain = new PolicyMain(driver);
            toaster = new Toaster(driver);
        }

        [Then(@"I can create a policy")]
        public void ThenICanCreateAPolicy()
        {
            mainNavBar.ClickPolicyTab();
            policyGrid.ClickNew();
            policyCreation.EnterDefaultInputs();
            policyCreation.ClickSubmitButton();
            //should now be on newly created policy

            //verify toast pop-up saying new policy was created
            string toastTitle = toaster.GetToastTitle();
            Assert.IsTrue(toastTitle.Contains("was created"));

        }
        
        [Then(@"I can read a policy")]
        public void ThenICanReadAPolicy()
        {
            //search existing policy
            mainNavBar.SearchQuery("10020");
            mainNavBar.ClickFirstSearchResult();
            policyMain.GoToSummary();
            //should be on policy general info page

            //verify title of page
            Assert.AreEqual("General Information", driver.Title);

        }
        
        [Then(@"I can update a policy")]
        public void ThenICanUpdateAPolicy()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I can delete a policy")]
        public void ThenICanDeleteAPolicy()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I cannot create a policy")]
        public void ThenICannotCreateAPolicy()
        {
            mainNavBar.ClickPolicyTab();
            try 
            {
                policyGrid.ClickNew();
            }
            catch (Exception e)
            {
                Console.WriteLine("tostring: " + e.ToString());
                Console.WriteLine("message: " + e.Message);
                Console.WriteLine("base exception: " + e.GetBaseException());
            }
        }
        
        [Then(@"I cannot update a policy")]
        public void ThenICannotUpdateAPolicy()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I cannot delete a policy")]
        public void ThenICannotDeleteAPolicy()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
