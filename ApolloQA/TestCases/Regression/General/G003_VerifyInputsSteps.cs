using ApolloQA.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ApolloQA.TestCases.Regression.General
{
    [Binding]
    public class G003_VerifyInputsSteps
    {
        private IWebDriver driver;
        Components helper;

        public G003_VerifyInputsSteps(IWebDriver driver)
        {
            this.driver = driver;
            helper = new Components(driver);
        }
        [Then(@"Verify an input is displayed with label")]
        public void ThenVerifyAnInpuIsDisplayedWithLabel(Table table)
        {
            var details = table.CreateDynamicSet();
            foreach (var detail in details)
            {
                bool checkLabel = helper.CheckLabel(detail.Value);
                Assert.IsTrue(checkLabel, "Label " + detail + " not found");
            }
        }
    }
}
