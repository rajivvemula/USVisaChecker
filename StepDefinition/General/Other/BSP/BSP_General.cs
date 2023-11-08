using BiBerkLOB.Pages.Other.BSP;
using BiBerkLOB.Pages.WC;
using HitachiQA.Driver;
using HitachiQA.Helpers;
using System;
using TechTalk.SpecFlow;

namespace BiBerkLOB.StepDefinition.General.Other.BSP
{
    [Binding]
    public sealed class BSP
    {
        [Given(@"user logs into BSP portal with Username and password")]
        public void GivenUserLogsIntoBSPPortalWithUsernameAndPassword()
        {
            string BSP_URL = Environment.GetEnvironmentVariable("BSP_URL");

            var BSP_USERNAME = KeyVault.GetStoredEnvironmentSecret("BSP_USERNAME_BSPSECRET");
            var BSP_PWD = KeyVault.GetStoredEnvironmentSecret("BSP_PASSWORD_BSPSECRET");

            Setup.driver.Navigate().GoToUrl(BSP_URL);

            // method to sign in 
            BSP_SignIn(BSP_USERNAME, BSP_PWD);
        }

        [Given(@"user is viewing policy number (.*) with the following configuration:")]
        public void GivenUserIsViewingPolicyNumberWithTheFollowingConfiguration(string policyID, Table table)
        {
            BSP_Reusable.SettingsIcon.AssertElementIsVisible();
            BSP_Reusable.SettingsIcon.Click();

            //Inpersonate feature not available in the Test enviroment of BSP will comment out for now
            //HandleImpersonateTable(table);

            //BSP_SettingsPage.ImpersonateCTA.Click();
           
            BSP_Reusable.SearchBoxInput.EnterResponse(policyID);
            BSP_Reusable.SearchBoxPolicyNumberButton.Click();
            BSP_PolicyPage.PolicyStatus.AssertElementIsVisible();
        }

        [Then(@"The user verifies the policy tabs and status")]
        public void verifyPolicyStatusAndTabs()
        {
            BSP_PolicyPage.PolicyStatus.AssertElementIsVisible();
            if (BSP_PolicyPage.PolicyStatus.GetElementText().Contains("Issued"))
            {
                BSP_PolicyPage.CertificatesTab.AssertElementIsVisible();
            }
            BSP_PolicyPage.BillingTab.AssertElementIsVisible();
            BSP_PolicyPage.BillingTab.Click();
            BSP_PolicyPage.CoverageTab.AssertElementIsVisible();
            BSP_PolicyPage.CoverageTab.Click();
            BSP_PolicyPage.ContactsTab.AssertElementIsVisible();
            BSP_PolicyPage.ContactsTab.Click();
            BSP_PolicyPage.ConversationsTab.AssertElementIsVisible();
            BSP_PolicyPage.DocumentsTab.AssertElementIsVisible();
            BSP_PolicyPage.DocumentsTab.Click();
            BSP_PolicyPage.UnderwrittingTab.AssertElementIsVisible();
            BSP_PolicyPage.UnderwrittingTab.Click();
        }
        /*
        Inpersonate feature not available in the Test enviroment of BSP
        public void HandleImpersonateTable(Table table)
        {
            foreach (var row in table.Rows)
            {
                var input = row["Input"];
                var value = row["Value"];

                switch (input)
                {
                    case "Agency":
                        BSP_SettingsPage.AgencySelectionDDInput.AssertAllElements();
                        BSP_SettingsPage.AgencySelectionDDInput.EnterResponse(value);
                        break;
                    case "Role":
                        BSP_SettingsPage.RoleInput(value).AssertAllElements();
                        BSP_SettingsPage.RoleInput(value).EnterResponse(true);
                        break;
                    default:
                        break;
                }
            }
        }
        */

        public void BSP_SignIn(string userName, string password)
        {
            BSP_LoginPage.UserNameInput.SetText(userName);
            BSP_LoginPage.Confirm.Click();
            BSP_LoginPage.PassWordInput.SetText(password);
            BSP_LoginPage.Confirm.Click();
            BSP_LoginPage.Confirm.Click();
        }
    }
}