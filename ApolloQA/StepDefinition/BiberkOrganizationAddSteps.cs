using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace ApolloQA.StepDefinition
{
    [Binding]
    public sealed class BiberkOrganizationAddSteps
    {
        public IWebDriver driver;


        BiberkOrganizationAddSteps(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        [Then(@"user verifies Email is required")]
        public void ThenUserVerifiesEmailIsRequired()
        {
            IWebElement businessEmail = driver.FindElement(By.XPath("//input[@name='orgEmailAddress']"));
            string EmailRequired = businessEmail.GetAttribute("required");
            Assert.AreEqual(EmailRequired, "true");
        }
    }
}
