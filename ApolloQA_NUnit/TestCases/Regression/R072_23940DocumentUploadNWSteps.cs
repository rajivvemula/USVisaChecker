using ApolloQA.Helpers;
using ApolloQA.Pages;
using ApolloQA.Pages.Login;
using ApolloQA.Pages.Policy;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression
{
    [Binding]
    public sealed class R072_23940DocumentUploadNWSteps
    {
        public IWebDriver driver;
        LoginPage loginpage;
        PolicyDocument document;
        PolicyGrid policyNumber;

        public R072_23940DocumentUploadNWSteps(IWebDriver Driver)
        {
            driver = Driver;
            loginpage = new LoginPage(Driver);
            document = new PolicyDocument(Driver);
            policyNumber = new PolicyGrid(Driver);
        }

        [Given(@"user landed biBerk home page")]
        public void GivenUserLandedBiBerkHomePage()
        {
            driver.Navigate().GoToUrl(Defaults.QA_URLS["Home"]);
            loginpage.loginValidUser(Defaults.ADMIN_USERNAME, Defaults.DEFAULT_PASSWORD);
        }

        [When(@"user clicks on Policy CTA then user landed Policy grid page")]
        public void WhenUserClicksOnPolicyCTAThenUserLandedPolicyGridPage()
        {
            JavaScriptExecutor.highlight(driver,policyNumber.PolicyCTA);
            policyNumber.PolicyCTA.Click();
        }

        [When(@"user clicks on Existing ""(.*)"" then landed policy details page")]
        public void WhenUserClicksOnExistingThenLandedPolicyDetailsPage(int p0)
        {
            JavaScriptExecutor.highlight(driver, policyNumber.getPolicyNumberElement(p0));
            policyNumber.getPolicyNumberElement(p0).Click();
        }

        [Given(@"user clicks on Documents CTA then user landed documents page")]
        public void GivenUserClicksOnDocumentsCTAThenUserLandedDocumentsPage()
        {
            JavaScriptExecutor.highlight(driver, document.documentsCTA);
            document.documentsCTA.Click();
        }

        [Given(@"user clicks on New File CTA then user landed upload page")]
        public void GivenUserClicksOnNewFileCTAThenUserLandedUploadPage()
        {
            JavaScriptExecutor.highlight(driver, document.newFileCTA);
            document.newFileCTA.Click();
        }

        [Given(@"user clicks on Browse Your Computer CTA and user upload file")]
        public void GivenUserClicksOnBrowseYourComputerCTAAndUserUploadFile()
        {
            JavaScriptExecutor.highlight(driver, document.BrowseYourComputerCTA);
            document.BrowseYourComputerCTA.Click();
            document.autoITFileUpload();
        }

        [Then(@"user verify document uploaded successfully")]
        public void ThenUserVerifyDocumentUploadedSuccessfully()
        {
            JavaScriptExecutor.highlight(driver, document.verifyFile);
            bool verfyFileUpload = document.checkStatus();
            Assert.IsTrue(verfyFileUpload);
        }

        //[Then(@"user logout of biBerk page")]
        //public void ThenUserLogoutOfBiBerkPage()
        //{
        //    Thread.Sleep(5000);
        //    driver.Quit();
        //}

    }
}
