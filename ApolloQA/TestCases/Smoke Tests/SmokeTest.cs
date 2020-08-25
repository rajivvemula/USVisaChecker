﻿using ApolloQA.Helpers;
using ApolloQA.Pages.Dashboard;
using ApolloQA.Pages.Login;
using ApolloQA.Pages.Organization;
using ApolloQA.Pages.Shared;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ApolloQA.TestCases.Smoke_Tests
{

    [TestFixture]
    class SmokeTest
    {

        public IWebDriver driver;
        MainNavBar mainNavBar;
        HomePage homePage;
        OrganizationGrid organizationGrid;
        OrganizationInsert organizationInsert;
        Toaster toaster;
        Components components;
        OrganizationInformation organizationInformation;
        SmokeTestHelpers helper;


        //Variables
        //Org Number is a string 
        string smokeOrganization = "10085";
        bool smokeOrgCreated = false;
        public SmokeTest()
        {
            //driver = new ChromeDriver();
            //mainNavBar = new MainNavBar(driver);
        }
        [OneTimeSetUp]
        public void setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            mainNavBar = new MainNavBar(driver);
            homePage = new HomePage(driver);
            helper = new SmokeTestHelpers(driver);
            organizationGrid = new OrganizationGrid(driver);
            organizationInsert = new OrganizationInsert(driver);
            toaster = new Toaster(driver);
            components = new Components(driver);
            organizationInformation = new OrganizationInformation(driver);
        }

        [OneTimeTearDown]
        public void teardown()
        {
            driver.Quit();
        }

        /// <summary>
		/// Logs in As Admin
		/// </summary>
        [TestCase, Order(1)]
        public void LogIn()
        {
            LogInAsAdmin logInAsAdmin = new LogInAsAdmin(driver);
            logInAsAdmin.LoginAsValidUser();
        }

        /// <summary>
		/// Check If Admin Has appropriate Permissions
		/// </summary>
        [TestCase, Order(2)]
        public void AdminPermission()
        {
            bool verifyUser = homePage.VerifyLoggedInUser(Defaults.ADMIN_USERNAME);
            Assert.AreEqual(verifyUser, true);
            foreach (string i in Defaults.adminRoles)
            {
                bool verifyRole = homePage.CheckRole(i);
                Assert.AreEqual(verifyRole, true);
            }
        }


        /// <summary>
		/// Test 4  Main Nav Tabs(Home, Policy, Organization, and Application
		/// </summary>
        [TestCase, Order(3)]
        public void TestNav()
        {
            //bool atHome = driver.Url.Contains(Defaults.QA_URLS["Home"]);
            //Check If User is at Home if not go to Home
            //MainNavBar mainNavBar = new MainNavBar(driver);
            helper.CheckIfHome();
            mainNavBar.ClickHomeIcon();
            Assert.IsTrue(driver.Url.Contains(Defaults.QA_URLS["Home"]));
            mainNavBar.ClickPolicyTab();
            Assert.IsTrue(driver.Url.Contains(Defaults.QA_URLS["Policy"]));
            mainNavBar.ClickOrganizationTab();
            Assert.IsTrue(driver.Url.Contains(Defaults.QA_URLS["Organization"]));
            mainNavBar.ClickApplicationTab();
            Assert.IsTrue(driver.Url.Contains(Defaults.QA_URLS["Application"]));
        }

        /// <summary>
		/// Navigate to Organization,Insert New Organization and Submit a New Organization
		/// </summary>
        [TestCase, Order(4)]
        public void InsertOrganization()
        {
            mainNavBar.ClickOrganizationTab();
            //Assert.IsTrue(driver.Title.Contains("Insert Organization"), "Didn't get to Insert Organization Screen");
            Assert.That(() => driver.Title, Is.EqualTo("Organization").After(3).Seconds.PollEvery(250).MilliSeconds, "Didn't get to Insert Organization Screen");
            //Click New Button
            organizationGrid.ClickNewButton();
            Assert.That(() => driver.Title, Is.EqualTo("Insert Organization").After(3).Seconds.PollEvery(250).MilliSeconds, "Unable To Click New Button");

            //Input
            organizationInsert.EnterInput("name", "Smoke Test");
            organizationInsert.EnterInput("dba", "Smoke");
            organizationInsert.EnterInput("businessphone", "123-456-7890");
            organizationInsert.EnterInput("businessemail", "smoketest@gmail.com");
            organizationInsert.EnterInput("businesswebsite", "smoketest.com");
            organizationInsert.EnterInput("yearstarted", "2010");
            organizationInsert.EnterInput("yearownership", "2011");
            organizationInsert.EnterSelect("orgtype", "Corporation");
            organizationInsert.EnterSelect("taxtype", "FEIN");
            organizationInsert.EnterInput("keyword", "Accountant");
            organizationInsert.keywordCode.SendKeys(Keys.Enter);
            organizationInsert.EnterInput("taxid", "12-3489779");

            //Submit Ogrnaization and if it's created then test proceeds with the created organization
            //If it's not then test proceed with a preselected organization
            organizationInsert.ClickSubmitButton();
            bool verifyTitle = components.GetTitle("Organization Details");
            Assert.IsTrue(verifyTitle, "Organization was not created");
            if (verifyTitle) {
                smokeOrgCreated = true;
                //if need be that we need to put orgnumber to a variable
                //string currentURL = driver.Url;
                //string orgNumber = currentURL.Remove(0, currentURL.Length - 5);
            }
            Thread.Sleep(5000);
        }

        /// <summary>
		/// Test Save Changes For Newly Created organization
		/// </summary>
        [TestCase, Order(5)]
        public void SaveOrganization()
        {
            if(smokeOrgCreated == false) {
                driver.Navigate().GoToUrl("https://biberk-apollo-qa2.azurewebsites.net/organization/10085");
            }
            organizationInformation.EnterSelect("orgtype", "LLC");
            organizationInformation.saveButton.Click();

            //verify change saved  via toast
            string verifyToast = toaster.GetToastTitle();
            Assert.That(verifyToast, Does.Contain("was saved."));
        }

    }
}
