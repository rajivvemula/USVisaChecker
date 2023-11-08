using BiBerkLOB.Pages.Other.Claims;
using HitachiQA.Helpers;
using TechTalk.SpecFlow;

namespace BiBerkLOB.StepDefinition.General.Other.Claims
{
    [Binding]
    public sealed class ReportClaim_BOP
    {
        [Then(@"user validates the BOP Claim page elements")]
        public void ThenUserValidatesTheBOPClaimPageElements()
        {
            //verifies URL is still on the correct environment
            General_SiteWide.AssertEnvironmentURL();
            AutomationHelper.ValidateElements(BOPClaimsPage.BOP_ClaimsPageElements);
        }

        [Then(@"user verifies the BOP Claims page error messages")]
        public void ThenUserVerifiesTheBOPClaimsPageErrorMessages()
        {
            AutomationHelper.WaitForLoading();
            ClaimsPageBase.SubmitClaimsButton.Click();
            AutomationHelper.ValidateElements(BOPClaimsPage.BOP_ClaimsPageErrorMessages);
        }

        [When(@"user fills out the BOP Claims page with these values:")]
        public void WhenUserFillsOutTheBOPClaimsPageWithTheseValues(Table table)
        {
            foreach (TableRow rowy in table.Rows)
            {
                var theQuestion = rowy["Question"];
                var theAnswer = rowy["Answer"];
                HandleBOPClaimsPage(theQuestion, theAnswer);
            }
        }

        private static void HandleBOPClaimsPage(string theQuestion, string theAnswer)
        {
            switch (theQuestion)
            {
                case "Policy Number":
                    BOPClaimsPage.PolicyNumberTextbox.SetText(theAnswer);
                    break;
                case "Business Name":
                    BOPClaimsPage.BusinessNameTextbox.SetText(theAnswer);
                    break;
                case "First Name":
                    BOPClaimsPage.FirstNameTextbox.SetText(theAnswer);
                    break;
                case "Last Name":
                    BOPClaimsPage.LastNameTextbox.SetText(theAnswer);
                    break;
                case "Phone":
                    BOPClaimsPage.PhoneTextbox.SetText(theAnswer);
                    break;
                case "Ext":
                    BOPClaimsPage.PhoneNumExtTextbox.SetText(theAnswer);
                    break;
                case "How to Connect":
                    BOPClaimsPage.HowToConnectTextbox.SetText(theAnswer);
                    break;
                case "Date of Loss":
                    BOPClaimsPage.DateOfLossInput.EnterResponse(theAnswer);
                    break;
                case "Location of Loss":
                    BOPClaimsPage.LocationOfLossTxtbox.SetText(theAnswer);
                    break;
                case "Short Description":
                    BOPClaimsPage.ShortDescripTextbox.SetText(theAnswer);
                    break;
            }
        }
    }
}