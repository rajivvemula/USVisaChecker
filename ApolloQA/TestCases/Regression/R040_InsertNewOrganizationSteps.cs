using ApolloQA.Helpers;
using ApolloQA.Pages.Organization;
using ApolloQA.Pages.Shared;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Threading;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression
{
    [Binding]
    public class R040_InsertNewOrganizationSteps
    {
        private IWebDriver driver;
        MainNavBar mainNavBar;
        OrganizationGrid organizationGrid;
        OrganizationInsert organizationInsert;

        public R040_InsertNewOrganizationSteps(IWebDriver driver)
        {
            this.driver = driver;
            mainNavBar = new MainNavBar(driver);
            organizationGrid = new OrganizationGrid(driver);
            organizationInsert = new OrganizationInsert(driver);
        }

        [Given(@"I am on the OrganizationGrid page")]
        public void GivenIAmOnTheOrganizationGridPage()
        {
            mainNavBar.ClickOrganizationTab();
        }
        
        [Given(@"I am on the OrganizationInsert page")]
        public void GivenIAmOnTheOrganizationInsertPage()
        {
            mainNavBar.ClickOrganizationTab();
            organizationGrid.ClickNewButton();

        }
        
        [When(@"I click the New Organization button")]
        public void WhenIClickTheNewOrganizationButton()
        {
            organizationGrid.ClickNewButton();
        }
        
        [When(@"I enter organization information")]
        public void WhenIEnterOrganizationInformation(Table table)
        {
            organizationInsert.EnterName(table.Rows[0]["Name"]);
            organizationInsert.EnterAlternateName(table.Rows[0]["Alternate Name"]);
            organizationInsert.EnterLegalName(table.Rows[0]["Legal Name"]);
            organizationInsert.SelectType(table.Rows[0]["Type"]);
            organizationInsert.EnterCode(table.Rows[0]["Code"]);
            organizationInsert.ClickSubmitButton();
        }
        
        [Then(@"I am taken to the OrganizationInsert page")]
        public void ThenIAmTakenToTheOrganizationInsertPage()
        {
            Thread.Sleep(5000);


            Assert.IsTrue(driver.Url.Contains(Defaults.QA_URLS["Organization Insert"]));
        }
        
        [Then(@"A new organization is created with the appropriate values")]
        public void ThenANewOrganizationIsCreatedWithTheAppropriateValues()
        {
            Thread.Sleep(5000);

            Assert.IsTrue(driver.Url.Contains(Defaults.QA_URLS["Organization"]));

            //write organization number to file
            string orgNo = driver.Url.Substring(Defaults.QA_URLS["Organization"].Length + 1);
            Console.WriteLine(orgNo);
            using (StreamWriter writer = File.AppendText("C:\\Users\\casey.klaips\\source\\repos\\ApolloQA\\ApolloQA\\DataFiles\\Org_Numbers.txt"))
            {
                writer.WriteLine(orgNo);
            }
        }


    }
}
