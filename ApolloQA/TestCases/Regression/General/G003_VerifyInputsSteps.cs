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

        [Then(@"Verify a Select contains value : (.*)")]
        public void ThenVerifyASelectContainsValue(string selectName, Table table)
        {
            
            var details = table.CreateDynamicSet();
            helper.ClickSelect(selectName);
            foreach (var detail in details)
            {
                bool checkValue = helper.CheckSelectValue(detail.Value);
                Assert.IsTrue(checkValue, "Value " + detail + " not found");
            }
        }

        [Then(@"Verify if the input is required")]
        public void ThenVerifyIfTheInputIsRequired(Table table)
        {
            var details = table.CreateDynamicSet();
            foreach (var detail in details)
            {
                string value = detail.Value;
                if (detail.Required == "False")
                {
                    Assert.That(() => helper.CheckInputRequirement(detail.Value), Does.Contain("false").After(3).Seconds.PollEvery(250).MilliSeconds, value + " is required when it should be false");
                } else
                {
                    Assert.That(() => helper.CheckInputRequirement(detail.Value), Does.Contain("true").After(3).Seconds.PollEvery(250).MilliSeconds, value +  " is not required but should be true");
                }
                

            }


    }
}
