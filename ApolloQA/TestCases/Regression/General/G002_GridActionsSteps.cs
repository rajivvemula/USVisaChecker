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
                Assert.IsTrue(checkLabel, "Column Title:" + detail.Value + " not found");
            }

        }
        [Then(@"Verify grid contains ellipsis")]
        public void ThenVerifyGridContainsEllipsis()
        {
            bool verifyEllipsis = grid.gridEllipsis.Displayed;
            Assert.IsTrue(verifyEllipsis, "Grid does not have an ellipsis");
        }

        [Then(@"Verify grid does not contain ellipsis")]
        public void ThenVerifyGridDoesNotContainEllipsis()
        {
            bool verifyEllipsis = grid.gridEllipsis.Displayed;
            Assert.IsFalse(verifyEllipsis, "Grid has an ellipsis, when it should not have any");
        }

        [Then(@"Verify ellipsis contains the following options")]
        public void ThenVerifyEllipsisContainsTheFollowingOptions(Table table)
        {
            var details = table.CreateDynamicSet();
            foreach (var detail in details)
            {
                bool checkMenu = grid.CheckIfEllipsisMenuContains(detail.Value);
                Assert.IsTrue(checkMenu, "Menu does contain " + detail.value);
            }
        }



    }
}
