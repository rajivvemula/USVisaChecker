using ApolloQA.Helpers;
using ApolloQA.Pages.Policy;
using ApolloQA.Pages.Shared;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ApolloQA.TestCases.Regression
{
    [Binding]
    public class R015_PolicyContactsCreateContactSteps
    {
        public IWebDriver driver;
        PolicyContacts policyContacts;
        Components components;
        Toaster toaster;
        

        public R015_PolicyContactsCreateContactSteps(IWebDriver Driver)
        {
            driver = Driver;
            policyContacts = new PolicyContacts(Driver);
            components = new Components(Driver);
            toaster = new Toaster(Driver);
        }

        [When(@"User enters all inputs in insert contact screen")]
        public void WhenUserEntersAllInputsInInsertContactScreen(Table table)
        {
            //policyContacts.partyRole.Click();
            //policyContacts.partyRole.SendKeys(Keys.Enter);
            Thread.Sleep(5000);
            var detail = table.CreateDynamicSet();
            foreach (var details in detail)
            {
                
                
                policyContacts.EnterInput("first", details.First);
                policyContacts.EnterSelect("party", details.Role);
                policyContacts.EnterInput("middle", details.Middle);
                policyContacts.EnterInput("last", details.Last);
                policyContacts.EnterInput("suffix", details.Suffix);
                policyContacts.EnterInput("email", details.Email);
                policyContacts.EnterInput("job", details.Job);
                policyContacts.EnterInput("company", details.Company);
                policyContacts.EnterInput("internet", details.Internet);
                policyContacts.EnterInput("remarks", details.Remarks);
                policyContacts.EnterInput("phonenumber", details.PhoneNumber.ToString());
                policyContacts.EnterPhoneTypeWorkaround(details.PhoneType);
            }
        }


        [When(@"User clicks the save button in insert contact screen")]
        public void WhenUserClicksTheSaveButtonInInsertContactScreen()
        {
            
            policyContacts.SubmitContact();
        }

        [Then(@"User is shown a toast saying Contact Saved Succesfully")]
        public void ThenUserIsShownAToastSayingContactSavedSuccesfully()
        {
            
            string verifyToast = toaster.GetToastTitle();
            Assert.That(verifyToast, Does.Contain("Contact was successfully saved."));
        }
    }
}
