using ApolloQA.Pages.Policy;
using ApolloQA.Pages.Shared;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Workflows
{
    class PolicyCRUD
    {

        private IWebDriver driver;
        MainNavBar mainNavBar;
        PolicyGrid policyGrid;
        PolicyCreation policyCreation;
        PolicyMain policyMain;
        Toaster toaster;

        string toastTitle;


        public PolicyCRUD(IWebDriver driver)
        {
            this.driver = driver;
            mainNavBar = new MainNavBar(driver);
            policyGrid = new PolicyGrid(driver);
            policyCreation = new PolicyCreation(driver);
            policyMain = new PolicyMain(driver);
            toaster = new Toaster(driver);
        }

        /* CreateDefaultPolicy
         * returns NULL if user is not allowed to create a policy, returns Toast text if successful
         */
        public string CreateDefaultPolicy()
        {
            
            mainNavBar.ClickPolicyTab();
            
            //if we don't have the new button, we can't create a policy
            if(!policyGrid.ClickNew())
                return "NULL";

            policyCreation.EnterDefaultInputs();
            policyCreation.ClickSubmitButton();
            //should now be on newly created policy

            //return toast
            toastTitle = toaster.GetToastTitle();
            Console.WriteLine(toastTitle);

            return toastTitle;

        }


        public string GetToastText()
        {
            return toastTitle;
        }

        ////search existing policy
        //mainNavBar.SearchQuery("10020");
        //mainNavBar.ClickFirstSearchResult();
        //policyMain.GoToSummary();
        ////should be on policy general info page

        ////verify title of page
        //Assert.AreEqual("General Information", driver.Title);
        
    }
}
