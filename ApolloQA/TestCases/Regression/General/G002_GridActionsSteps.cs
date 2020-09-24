using ApolloQA.Pages.Shared;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ApolloQA.TestCases.Regression.General
{
    [Binding]
    public class G002_GridActionsSteps
    {
        private IWebDriver driver;
        private Grid grid;

        public G002_GridActionsSteps(IWebDriver driver)
        {
            this.driver = driver;
            grid = new Grid(driver);
        }

        [Then(@"Grid column label is displayed")]
        public void ThenGridColumnLabelIsDisplayed(Table table)
        {
            var details = table.CreateDynamicSet();
            foreach (var detail in details)
            {
                bool checkLabel = grid.CheckColumnLabel(detail.Value);
                Assert.IsTrue(checkLabel, "Column Title:" + detail + " not found");
            }

        }
    }
}
