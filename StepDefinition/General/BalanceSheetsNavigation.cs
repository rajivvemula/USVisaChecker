using BiBerkLOB.Pages;
using HitachiQA.Driver;
using System;
using TechTalk.SpecFlow;
using HitachiQA;
namespace BiBerkLOB.StepDefinition.General
{
    [Binding]
    public class BalanceSheetsNavigation
    {
        [Then(@"user verifies the navigation to Balance sheets PDF file")]
        public void ThenUserVerifiesTheNavigationToBalanceSheetsPDFFile()
        {
            BalanceSheetsfileinNewTab();
        }
        private void BalanceSheetsfileinNewTab()
        {
            // check if clicking link opens a new tab
            var originalTabCount = UserActions.GetTabs().Count;
            Reusable_PurchasePath.Footer_BalanceSheets.Click();
            var allTabs = UserActions.GetTabs();
            Assert.IsTrue(allTabs.Count == originalTabCount + 1);
            // ensure we're in new tab and verify the file is in pdf format
            UserActions.SwitchToTab(allTabs[1]);
            String BalanceSheetsPageURL = UserActions.GetCurrentURL();
            if (BalanceSheetsPageURL.EndsWith(".pdf"))
            {
                Console.WriteLine("Balance Sheets file is in PDF format");
            }
            else
                Console.WriteLine("Balance Sheets file is not in PDF format");
        }
    }
}









