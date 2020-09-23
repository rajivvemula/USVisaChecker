using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;


using ApolloQA.Pages.Policy;
using System.Threading;
using ApolloQA.Pages.Fnol;
using ApolloQA.Workflows;
using ApolloQA.Pages.Dashboard;
using System.ComponentModel;
using ApolloQA.Pages.Shared;

namespace ApolloQA.TestCases.LoginTest
{
    [Binding]
    public class PolicyTestSteps
    {

        public IWebDriver driver;

        public PolicyTestSteps(IWebDriver Driver)
        {
            driver = Driver;
        }

        [Given(@"User is on Policy Page")]
        public void GivenUserIsOnPolicyPage()
        {
            PolicyMain policyPage = new PolicyMain(driver);

            //policyPage.GoToSummary();
            //policyPage.GoToLocations();
            //policyPage.GoToContacts();
            policyPage.GoToVehicles();
            //policyPage.GoToDrivers();
            //policyPage.GoToCoverages();
            //policyPage.GoToRates();

            //PolicyGrid policyGrid = new PolicyGrid(driver);
            //policyGrid.Pagination("");
            //Thread.Sleep(5000);
            
        }

        [When(@"User clicks Policy Summary")]
        public void WhenUserClicksPolicySummary()
        {

            PolicyVehicle policyVehicle = new PolicyVehicle(driver);

            policyVehicle.ClickNewVehicle();

            AddVehicle addVehicle = new AddVehicle(driver);
            addVehicle.inputVin.SendKeys("123456");
            addVehicle.EnterAllInputs();
            Thread.Sleep(5000);
            /*
            PolicySummary policySummary = new PolicySummary(driver);
            string writeStatus = policySummary.CheckPolicyStatus();
            Console.WriteLine(writeStatus);

            PolicyMain policyPage = new PolicyMain(driver);

            /*
            policyPage.GoToLocations();

            PolicyLocation policyLocation = new PolicyLocation(driver);
            policyLocation.ClickAddNew();
            policyLocation.AddLocationName();
            policyLocation.ClickSubmit();
            policyLocation.removeLocation();
            */

            /*
            policyPage.GoToContacts();
            PolicyContacts policyContacts = new PolicyContacts(driver);
            policyContacts.ClickAddContact();
            policyContacts.EmptyClick();
            policyContacts.EnterPartyRole();
            //policyContacts.EnterPhoneType();
            policyContacts.EnterAllInputs();
            policyContacts.SubmitContact();
            policyPage.GoToContacts();
            */

            /*
            policyPage.GoToDocuments();

            PolicyDocument policyDocument = new PolicyDocument(driver);
            policyDocument.ClickAddNew();
            string directory = System.AppContext.BaseDirectory;
            Console.WriteLine(directory);
            
            policyDocument.uploadFile();
            //policyPage.GoToDocuments();
            //policyDocument.checkStatus();
            Thread.Sleep(15000);
            policyDocument.OpenFile("TestFile.txt");
            Thread.Sleep(5000);
            policyDocument.DeleteDocument();
            */

            /*
            FNOLDash fnolDash = new FNOLDash(driver);
            fnolDash.GoToFNOL();
            fnolDash.AddNewFNOL();

            FNOLInsert fnolInsert = new FNOLInsert(driver);
            fnolInsert.EnterAllInputs();
            */

            
            //ImpersonateUser impUser = new ImpersonateUser(driver);
            //impUser.UserToImp("ApolloTestUserG201@biberk.com");
            
            
            
            
            //HomePage homePage = new HomePage(driver);
            //homePage.SendInput();
        }

        [Then(@"user is shown the Summary screen")]
        public void ThenUserIsShownTheSummaryScreen()
        {
            //empty
        }
    }
}
