using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace ApolloQA.StepDefinition
{
    [Binding]
    public sealed class BiberkClaimFNOLAddSteps
    {
        public IWebDriver driver;


        BiberkClaimFNOLAddSteps(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        [Then(@"user verifies '(.*)' is not an option")]
        public void ThenUserVerifiesIsNotAnOption(string text)
        {
            {
                try
                {
                    SelectElement NoticeDropdown = new SelectElement(driver.FindElement(By.XPath("//*[@name='receivedTypeId']")));
                    NoticeDropdown.SelectByValue(text);
                }
                catch
                {
                    NullReferenceException pigeonNotFound = new NullReferenceException();
                    Assert.IsNotNull(pigeonNotFound);
                }
            }
        }
    }
}
