using OpenQA.Selenium;
using TechTalk.SpecFlow;
using ApolloQA.Pages;

namespace ApolloQA.StepDefinition
{
    [Binding]
    public sealed class apolloSharedSteps
    {
        public IWebDriver driver;


        apolloSharedSteps(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        [When(@"user clicks on waffle menu")]
        public void WhenUserClicksOnWaffleMenu()
        {
            Home.WaffleGridButton.Click();
        }

        [When(@"user clicks on Claims")]
        public void WhenUserClicksOnClaims()
        {
            WaffleMenu.claimsButton.Click();
        }


        [When(@"user clicks on addFNOL button to begin an FNOL report")]
        public void WhenUserClicksOnAddFNOLButtonToBeginAnFNOLReport()
        {
            ClaimsFNOLGrid.addNewFNOLButton.Click();
        }

        [When(@"user clicks addNew button to add an organization")]
        public void WhenUserClicksAddNewButtonToAddAnOrganization()
        {
            Home.OrganizationButton.Click();
            OrganizationGrid.addNewButton.Click();
        }
    }
}
