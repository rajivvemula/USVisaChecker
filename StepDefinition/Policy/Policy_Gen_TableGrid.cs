using System;
using System.Text.RegularExpressions;
using ApolloQAAutomation.Pages;
using ApolloQAAutomation.Pages.Policy;
using HitachiQA;
using HitachiQA.Helpers;
using TechTalk.SpecFlow;

namespace ApolloQAAutomation.StepDefinition.Policy
{
    [Binding]
    public sealed class Policy_Gen_TableGrid
    {
        [When(@"user clicks on Policy button on the header")]
        public void WhenUserClicksOnPolicyButtonOnTheHeader()
        {
            Apollo_HomePage.HeaderPolicyBtn.Click();
        }

        [Then(@"user verifies the Policy table grid column names")]
        public void ThenUserVerifiesThePolicyTableGridColumnNames()
        {
            AutomationHelper.ValidateElements(Policy_TableGrid.PolicyGridColumns);
        }

        [Then(@"user verifies the Policy table row (.*) has the correct format for fields")]
        public void ThenUserVerifiesThePolicyTableRowHasTheCorrectFormatForFields(int index)
        {
            // Verify LOB is Comm Auto
            var lobData = Policy_TableGrid.LOBRowData(index).GetElementText().Trim();
            Assert.AreEqual(lobData,"Comm Auto");

            // Verify premium amount is in $###,###.## format
            string pattern = @"^\$\d{1,3}(,\d{3})*(\.\d{2})?$";
            var premiumAmount = Policy_TableGrid.PremiumRowData(index).GetElementText().Trim();
            Assert.IsTrue(Regex.IsMatch(premiumAmount, pattern));

            //Verify Policy Period is within MM/DD/YYYY           
            var policyPeriod = Policy_TableGrid.PolicyPeriodRowData(index).GetElementText().Trim();
            Assert.IsTrue(IsValidDateFormat(policyPeriod));
        }

        private static bool IsValidDateFormat(string input)
        {
            string[] dateParts = input.Split(" - ");

            foreach (string datePart in dateParts)
            {
                if (!DateTime.TryParseExact(datePart, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out _))
                {
                    return false;
                }
            }
            return dateParts.Length == 2;
        }
    }
}
