using BiBerkLOB.Pages.Other.Claims;
using HitachiQA.Helpers;
using TechTalk.SpecFlow;

namespace BiBerkLOB.StepDefinition.General.Other.Claims
{
    [Binding]
    public sealed class ReportClaim_GL
    {
        [Then(@"user validates the GL Claim page elements")]
        public void ThenUserValidatesTheGLClaimPageElements()
        {
            General_SiteWide.AssertEnvironmentURL();
            AutomationHelper.ValidateElements(GLClaimsPage.GL_ClaimsPageElements);
        }

        [Then(@"user verifies the GL Claims page error messages")]
        public void ThenUserVerifiesTheGLClaimsPageErrorMessages()
        {
            AutomationHelper.WaitForLoading();
            WCClaimsPage.SubmitClaimsButton.Click();
            AutomationHelper.ValidateElements(GLClaimsPage.GL_ClaimsPageErrorMessages);
        }

        [When(@"user fills out the GL Claims page with these values:")]
        public void WhenUserFillsOutTheGLClaimsPageWithTheseValues(Table table)
        {
            foreach (TableRow rowy in table.Rows)
            {
                var theQuestion = rowy["Question"];
                var theAnswer = rowy["Answer"];
                HandleGLClaimsPage(theQuestion, theAnswer);
            }
        }

        private static void HandleGLClaimsPage(string theQuestion, string theAnswer)
        {
            switch (theQuestion)
            {
                case "Policy Number":
                    GLClaimsPage.PolicyNumberTextbox.SetText(theAnswer);
                    break;
                case "Business Name":
                    GLClaimsPage.BusinessNameTextbox.SetText(theAnswer);
                    break;
                case "First Name":
                    GLClaimsPage.FirstNameTextbox.SetText(theAnswer);
                    break;
                case "Last Name":
                    GLClaimsPage.LastNameTextbox.SetText(theAnswer);
                    break;
                case "Phone":
                    GLClaimsPage.PhoneTextbox.SetText(theAnswer);
                    break;
                case "Ext":
                    GLClaimsPage.PhoneNumExtTextbox.SetText(theAnswer);
                    break;
                case "How to Connect":
                    GLClaimsPage.HowToConnectTextbox.SetText(theAnswer);
                    break;
                case "Date of Injury":
                    GLClaimsPage.DateOfLossInput.EnterResponse(theAnswer);
                    break;
                case "Injury Location":
                    GLClaimsPage.LocationOfLossTxtbox.SetText(theAnswer);
                    break;
                case "Short Description":
                    GLClaimsPage.ShortDescripTextbox.SetText(theAnswer);
                    break;
            }
        }
    }
}
