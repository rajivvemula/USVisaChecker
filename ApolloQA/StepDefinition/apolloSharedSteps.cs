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

        [When(@"user clicks on addFNOL button to begin an FNOL report")]
        public void WhenUserClicksOnAddFNOLButtonToBeginAnFNOLReport()
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
