using ApolloQA.Pages.Organization;
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
    public class R044_AddDriverToOrganizationSteps
    {

        private IWebDriver driver;
        OrganizationDriver organizationDriver;
        AddDriver addDriver;
        Toaster toaster;

        public R044_AddDriverToOrganizationSteps(IWebDriver Driver)
        {
            driver = Driver;
            organizationDriver = new OrganizationDriver(Driver);
            addDriver = new AddDriver(Driver);
            toaster = new Toaster(Driver);

        }

        [When(@"User clicks Drivers Tab In Organization")]
        public void WhenUserClicksDriversTabInOrganization()
        {
            //organizationDriver.addressTab.Click();
        }
        
        [When(@"User clicks Add Driver in Organization")]
        public void WhenUserClicksAddDriverInOrganization()
        {
            Thread.Sleep(4000);
            organizationDriver.addDriverButton.Click();
            //organizationDriver.addAddressButton.Click();
        }

        [When(@"user enters inputs for add driver in organization")]
        public void WhenUserEntersInputsForAddDriverInOrganization(Table table)
        {
            var detail = table.CreateDynamicSet();
            foreach (var details in detail)
            {
                //addDriver.EnterInput("first", details.First);
                //addDriver.EnterInput("last", details.Last);
                //addDriver.EnterInput("middle", details.Middle);
                //addDriver.EnterInput("dob", details.DOB.ToString());
                //addDriver.EnterSelect("licensestate", details.State);
                //addDriver.EnterInput("licensenumber", details.Number.ToString());
                //addDriver.EnterInput("licenseexp", details.Exp.ToString());
                //addDriver.EnterSelect("cdl", details.CDL);
            }
        }
        [When(@"user clicks submit to add driver")]
        public void WhenUserClicksSubmitToAddDriver()
        {
            addDriver.submitButton.Click();
        }

        [Then(@"User should see toast confirming driver was added")]
        public void ThenUserShouldSeeToastConfirmingDriverWasAdded()
        {
            string verifyToast = toaster.GetToastTitle();
            Assert.That(verifyToast, Does.Contain("Driver saved"));
            
        }

        [When(@"User clicks edit driver")]
        public void WhenUserClicksEditDriver()
        {
            organizationDriver.moreButton.Click();
            organizationDriver.editButton.Click();
        }
        [When(@"changes driver first name")]
        public void WhenChangesDriverFirstName()
        {
            addDriver.inputFirst.Clear();
            //addDriver.EnterInput("first", "Joseph");
        }

        [Then(@"wait (.*) secs")]
        public void ThenWaitSecs(int p0)
        {
            Thread.Sleep(5000);
        }




    }
}

/* 
 * 
 * | First | Last | Middle | DOB        | State | Number  | Exp        | CDL |
	| Jacob | Seed | J      | 01/02/1975 | AZ    | AZ15435 | 01/01/2022 | No  |
 * 
 * case "first": return inputFirst;
                case "middle": return inputMiddle;
                case "last": return inputLast;
                case "suffix": return inputSuffix;
                case "dob": return inputBirth;
                case "licensenumber": return inputLicenseNumber;
                case "licenseexp": return inputLicenseExp;
                case "licensestate": return selectLicenseState;
                case "cdl": return selectCDL;
                case "accident": return selectAccident ;
                case "violation": return selectViolation;
                case "conviction": return selectConviction;
                default: return null;
 * 
 * */
