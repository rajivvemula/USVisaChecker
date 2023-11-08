using BiBerkLOB.Pages.Other.Claims;
using HitachiQA.Helpers;
using TechTalk.SpecFlow;


namespace BiBerkLOB.StepDefinition.General.Other.Claims
{
    [Binding]
    public sealed class ReportClaim_PL
    {
        [Then(@"user validates the PL Claim page elements")]
        public void ThenUserValidatesTheWCClaimPageElements()
        {
            General_SiteWide.AssertEnvironmentURL();
            AutomationHelper.ValidateElements(PLClaimsPage.PL_ClaimsPageElements);
        }

        [Then(@"user validates the PL Claims page error messages")]
        public void ThenUserVerifiesThePLClaimsPageErrorMessages()
        {
            AutomationHelper.WaitForLoading();
            PLClaimsPage.SubmitClaimsButton.Click();
            AutomationHelper.ValidateElements(PLClaimsPage.PLClaimErrorElements);
        }

        [When(@"user fills out the PL Claims page with these values:")]
        public void WhenUserFillsOutThePLClaimsPageWithTheseValues(Table table)
        {
            AutomationHelper.WaitForLoading();
            foreach (TableRow rowy in table.Rows)
            {
                var theQuestion = rowy["Question"];
                var theAnswer = rowy["Answer"];
                HandlePLClaimsPage(theQuestion, theAnswer);
            }
        }

        private void HandlePLClaimsPage(string theQuestion, string theAnswer)
        {
            switch (theQuestion)
            { 
            case "Policy Number":
                PLClaimsPage.PolicyNumberTextbox.SetText(theAnswer);
                break;
            case "Business Name":
                PLClaimsPage.BusinessNameTextbox.SetText(theAnswer);
                break;
            case "First Name":
                PLClaimsPage.FirstNameTextbox.SetText(theAnswer);
                break;
            case "Last Name":
                PLClaimsPage.LastNameTextbox.SetText(theAnswer);
                break;
            case "Phone":
                PLClaimsPage.PhoneTextbox.SetText(theAnswer);
                break;
            case "Ext":
                PLClaimsPage.PhoneNumExtTextbox.SetText(theAnswer);
                break;
            case "How to Connect":
                PLClaimsPage.HowToConnectTextbox.SetText(theAnswer);
                break;
            case "Date of Injury":
                PLClaimsPage.DateOfLossInput.EnterResponse(theAnswer);
                break;
            case "Injury Location":
                PLClaimsPage.LocationOfLossTxtbox.SetText(theAnswer);
                break;
            case "Short Description":
                PLClaimsPage.ShortDescripTextbox.SetText(theAnswer);
                break;
            }
        }
    }
}