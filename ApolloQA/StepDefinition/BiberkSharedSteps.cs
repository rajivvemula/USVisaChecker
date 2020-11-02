using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using ApolloQA.Source.Driver;
using ApolloQA.Source.Helpers;
using ApolloQA.Pages;

namespace ApolloQA.StepDefinition
{
    [Binding]
    public sealed class BiberkSharedSteps
    {
        public IWebDriver driver;


        BiberkSharedSteps(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        [Given(@"user clicks on waffle menu")]
        public void GivenUserClicksOnWaffleMenu()
        {
            TopNavBar.WaffleGridButton.Click();
        }

        [When(@"user clicks on Claims")]
        public void WhenUserClicksOnClaims()
        {
            WaffleMenu.claimsButton.Click();
        }

        [When(@"user clicks on \+FNOL button to begin an FNOL report")]
        public void WhenUserClicksOnFNOLButtonToBeginAnFNOLReport()
        {
            ClaimsFNOLGrid.addNewFNOLButton.Click();
        }

        [Given(@"user clicks addNew button to add an organization")]
        public void GivenUserClicksAddNewButtonToAddAnOrganization()
        {
            TopNavBar.OrganizationButton.Click();
            OrganizationGrid.addNewButton.Click();
        }
    }
}
