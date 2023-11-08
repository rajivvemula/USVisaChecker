using BiBerkLOB.Pages.Other.Claims;
using HitachiQA.Helpers;
using TechTalk.SpecFlow;

namespace BiBerkLOB.StepDefinition.General.Other.Claims
{
    [Binding]
    public sealed class ReportClaim_UM
    {
        [Then(@"user validates the UM Claim page elements")]
        public void ThenUserValidatesTheGLClaimPageElements()
        {
            General_SiteWide.AssertEnvironmentURL();
            AutomationHelper.ValidateElements(UMClaimsPage.UM_ClaimsPageElements);
        }

        [Then(@"user verifies the UM Claims page error messages")]
        public void ThenUserVerifiesTheGLClaimsPageErrorMessages()
        {
            AutomationHelper.WaitForLoading();
            UMClaimsPage.SubmitClaimsButton.Click();
            AutomationHelper.ValidateElements(UMClaimsPage.UM_ClaimsPageErrorMessages);
        }

        [When(@"user fills out the UM Claims page with these values:")]
        public void WhenUserFillsOutTheUMClaimsPageWithTheseValues(Table table)
        {
            foreach (TableRow rowy in table.Rows)
            {
                var theQuestion = rowy["Question"];
                var theAnswer = rowy["Answer"];
                HandleUMClaimsPage(theQuestion, theAnswer);
            }
        }

        private static void HandleUMClaimsPage(string theQuestion, string theAnswer)
        {
            switch (theQuestion)
            {
                case "Policy Number":
                    UMClaimsPage.PolicyNumberTextbox.SetText(theAnswer);
                    break;
                case "Business Name":
                    UMClaimsPage.BusinessNameTextbox.SetText(theAnswer);
                    break;
                case "First Name":
                    UMClaimsPage.FirstNameTextbox.SetText(theAnswer);
                    break;
                case "Last Name":
                    UMClaimsPage.LastNameTextbox.SetText(theAnswer);
                    break;
                case "Phone":
                    UMClaimsPage.PhoneTextbox.SetText(theAnswer);
                    break;
                case "Ext":
                    UMClaimsPage.PhoneNumExtTextbox.SetText(theAnswer);
                    break;
                case "How to Connect":
                    UMClaimsPage.HowToConnectTextbox.SetText(theAnswer);
                    break;
                case "Date of Injury":
                    UMClaimsPage.DateOfLossInput.EnterResponse(theAnswer);
                    break;
                case "Injury Location":
                    UMClaimsPage.LocationOfLossTxtbox.SetText(theAnswer);
                    break;
                case "Short Description":
                    UMClaimsPage.ShortDescripTextbox.SetText(theAnswer);
                    break;
            }
        }
    }
}
