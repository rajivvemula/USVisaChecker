
using ApolloQA.Pages.Shared;
using ApolloQA.Pages.Policy;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression
{
    [Binding]
    public class R006_PolicyInsertScreenFromPolicyListSteps
    {

        public IWebDriver driver;
        MainNavBar mainNavBar;
        PolicyMain policyMain;
        PolicyGrid policyGrid;
        PolicyCreation policyCreation;

        public R006_PolicyInsertScreenFromPolicyListSteps(IWebDriver Driver)
        {
            driver = Driver;
            mainNavBar = new MainNavBar(Driver);
            policyMain = new PolicyMain(Driver);
            policyGrid = new PolicyGrid(Driver);
            policyCreation = new PolicyCreation(Driver);
        }


        [Given(@"User clicks Policy Tab on navigation")]
        public void GivenUserClicksPolicyTabOnNavigation()
        {
            mainNavBar.ClickHomeIcon();
        }

        [Given(@"User is on Insert Policy Page")]
        public void GivenUserIsOnInsertPolicyPage()
        {
            bool verifyH = policyCreation.CheckHeading();
            Assert.AreEqual(verifyH, true);
        }


        [When(@"User clicks on New Button")]
        public void WhenUserClicksOnNewButton()
        {
            policyGrid.ClickNew();
        }
        
        [When(@"User Navigates to Insert Policy Page Via URL")]
        public void WhenUserNavigatesToInsertPolicyPageViaURL()
        {
            policyMain.NavigateToPolicyCreation();
        }

        [When(@"User Click on the cancel button")]
        public void WhenUserClickOnTheCancelButton()
        {
            policyCreation.ClickCancelButton();
            Thread.Sleep(5000);
        }


        [Then(@"User is shown the Insert Policy Page")]
        public void ThenUserIsShownTheInsertPolicyPage()
        {
            bool verifyH = policyCreation.CheckHeading();
            Assert.AreEqual(verifyH, true);
        }
    }
}
