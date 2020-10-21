using ApolloQA.Helpers;
using ApolloQA.Pages.Policy;
using ApolloQA.Pages.Shared;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ApolloQA.Workflows
{
    class PolicyCRUD
    {

        private IWebDriver driver;
        MainNavBar mainNavBar;
        PolicyGrid policyGrid;
        PolicyCreation policyCreation;
        Toaster toaster;
        PolicyMain policyMain;
        Components components;
        PolicySummary policySummary;

        string toastTitle;


        public PolicyCRUD(IWebDriver Driver)
        {
            this.driver = Driver;
            mainNavBar = new MainNavBar(driver);
            policyGrid = new PolicyGrid(driver);
            policyCreation = new PolicyCreation(driver);
            toaster = new Toaster(driver);
            policyMain = new PolicyMain(driver);
            components = new Components(driver);
            policySummary = new PolicySummary(driver);
        }

        /* CreateDefaultPolicy
         * returns "NULL" if user is not allowed to create a policy, returns Toast text if successful
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


        public bool CanUpdatePolicyGeneralInformation(string policyNumber)
        {
            driver.Navigate().GoToUrl(Defaults.HOST + "/policy/" + policyNumber);
            policyMain.GoToSummary();
            string toastTitle;

            //if we can successfully update to Non-Profit, then save
            if (components.UpdateDropdown("businessTypeEntityId", "Non-Profit"))
                policySummary.ClickSaveButton();
            //otherwise, update to individual, then save
            else if (components.UpdateDropdown("businessTypeEntityId", "Individual"))
                policySummary.ClickSaveButton();
            else 
                return false;

            //if we get here, we successfully updated to Non-Profit or Individual and saved
            toastTitle = toaster.GetToastTitle();
            Console.WriteLine(toastTitle);
            if (toastTitle.Contains("was saved"))
                return true;
            else return false;

        }


        public string GetToastText()
        {
            return toastTitle;
        }

        
    }
}
