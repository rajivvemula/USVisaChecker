using ApolloQA.Helpers;
using ApolloQA.Pages.Shared;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression
{
    [Binding]
    public class N005_MainNavbar
    {
        private IWebDriver driver;
        MainNavBar mainNavBar;
        Functions functions;
        WebDriverWait wait;

        public N005_MainNavbar(IWebDriver driver)
        {
            this.driver = driver;
            mainNavBar = new MainNavBar(driver);
            functions = new Functions(driver);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }


        [Then(@"the Impersonate icon is visible")]
        public void ThenTheImpersonateIconIsVisible()
        {
            Assert.IsTrue(mainNavBar.ImpersonateIcon.Displayed);
        }

        [Then(@"the Impersonate icon is not visible")]
        public void ThenTheImpersonateIconIsNotVisible()
        {
            try
            {
                mainNavBar.ImpersonateIcon.Click();
            }
            catch
            {
                Assert.IsTrue(true);
                return;
            }

            Assert.IsTrue(false);
        }


        [When(@"User clicks the Impersonate icon")]
        public void WhenUserClicksTheImpersonateIcon()
        {
            mainNavBar.ImpersonateIcon.Click();
        }

        [When(@"User escapes the modal")]
        public void WhenUserEscapesTheModal()
        {
            //to close pop-up
            IWebElement currentElement = driver.SwitchTo().ActiveElement();
            currentElement.SendKeys(Keys.Escape);
        }


        [When(@"User enters impersonation username: (.*)")]
        public void WhenUserEntersImpersonationUsername(string userName)
        {
            mainNavBar.usernameField.Clear();
            mainNavBar.usernameField.SendKeys(userName);
        }

        [When(@"User clicks Submit impersonation")]
        public void WhenUserClicksSubmitImpersonation()
        {
            mainNavBar.submitButton.Click();
        }

        [Then(@"Impersonation error displays text: (.*)")]
        public void ThenImpersonationErrorDisplaysText(string expectedError)
        {
            Assert.That(mainNavBar.errorMessage.Text, Does.Contain(expectedError));
        }



        [Given(@"I am on a page containing the Main Navigation Bar")]
        public void GivenIAmOnAPageContainingTheMainNavigationBar()
        {
            driver.Navigate().GoToUrl(Defaults.QA_URLS["Home"]);
        }
        
        [When(@"I click on the Home tab")]
        public void WhenIClickOnTheHomeTab()
        {
            mainNavBar.ClickHomeIcon();
        }
        
        [When(@"I click on the Policy tab")]
        public void WhenIClickOnThePolicyTab()
        {
            mainNavBar.ClickPolicyTab();        
        }
        
        [When(@"I click on the Organization tab")]
        public void WhenIClickOnTheOrganizationTab()
        {
            mainNavBar.ClickOrganizationTab();
        }
        
        [When(@"I enter policy number (.*) in the search field")]
        public void WhenIEnterPolicyNumberInTheSearchField(int policyNo)
        {
            mainNavBar.SearchQuery(policyNo.ToString());
        }
        
        [When(@"I enter organization name (.*) in the search field")]
        public void WhenIEnterOrganizationNameInTheSearchField(string orgName)
        {
            mainNavBar.SearchQuery(orgName);
        }

        [When(@"I click the first search result")]
        public void WhenIClickTheFirstSearchResult()
        {
            mainNavBar.ClickFirstSearchResult();
        }

        [Then(@"The Home tab should load properly")]
        public void ThenTheHomeTabShouldLoadProperly()
        {
            Assert.IsTrue(driver.Url.Contains(Defaults.QA_URLS["Home"]));
        }
        
        [Then(@"The Policy tab should load properly")]
        public void ThenThePolicyTabShouldLoadProperly()
        {
            Assert.IsTrue(driver.Url.Contains(Defaults.QA_URLS["Policy"]));
        }
        
        [Then(@"The Organization tab should load properly")]
        public void ThenTheOrganizationTabShouldLoadProperly()
        {
            Assert.IsTrue(driver.Url.Contains(Defaults.QA_URLS["Organization"]));
        }


        [Then(@"I should be directed to policy (.*)")]
        public void ThenIShouldBeDirectedToPolicy(int policyNo)
        {
            Assert.AreEqual(Defaults.QA_URLS["Policy"] + "/" + policyNo + "/summary", driver.Url);
        }
        
        
        [Then(@"I should be directed to organization (.*)")]
        public void ThenIShouldBeDirectedToOrganization(string orgName)
        {
            Assert.IsTrue(driver.Url.Contains(Defaults.QA_URLS["Organization"]));
        }

        [When(@"I impersonate impersonateable user (.*)")]
        public void WhenIImpersonateImpersonateableUser(string userName)
        {
            mainNavBar.ImpersonateValidUser(userName);

        }

        [Then(@"I am currently impersonating user (.*)")]
        public void ThenIAmCurrentlyImpersonatingUser(string userName)
        {
            string currentImpersonation = mainNavBar.CurrentlyImpersonatedUser();
            Console.WriteLine(currentImpersonation);
            Assert.AreEqual(currentImpersonation, userName);
        }

        [When(@"I click stop impersonation")]
        public void WhenIClickStopImpersonation()
        {
            mainNavBar.StopImpersonation();
        }

        [Then(@"I am not impersonating")]
        public void ThenIAmNotImpersonating()
        {
            string user = mainNavBar.CurrentlyImpersonatedUser();
            Console.WriteLine(user);
            Assert.IsTrue(user.Equals("NULL"));
        }


    }
}
