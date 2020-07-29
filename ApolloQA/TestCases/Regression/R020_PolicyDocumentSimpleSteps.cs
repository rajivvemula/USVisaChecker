using ApolloQA.Pages.Policy;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression
{
    [Binding]
    public class R020_PolicyDocumentSimpleSteps
    {

        public IWebDriver driver;
        PolicyDocument policyDocument;

        public R020_PolicyDocumentSimpleSteps(IWebDriver Driver)
        {
            driver = Driver;
            policyDocument = new PolicyDocument(Driver);

        }
        [When(@"User user clicks on New File")]
        public void WhenUserUserClicksOnNewFile()
        {
            policyDocument.ClickAddNew();
        }
        
        [When(@"user uploads a txt file")]
        public void WhenUserUploadsATxtFile()
        {
            policyDocument.uploadFile();
        }
        
        [Then(@"User sees the file upload succesfully")]
        public void ThenUserSeesTheFileUploadSuccesfully()
        {
            bool verifyUpload = policyDocument.checkStatus();
            Assert.IsTrue(verifyUpload);
        }
    }
}
