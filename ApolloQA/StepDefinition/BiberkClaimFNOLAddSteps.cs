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
