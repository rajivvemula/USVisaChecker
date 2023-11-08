using System.Threading;
using BiBerkLOB.Pages.Other.Claims;
using HitachiQA.Helpers;
using TechTalk.SpecFlow;

namespace BiBerkLOB.StepDefinition.General.Other.Claims
{
    [Binding]
    public sealed class ReportClaim_WC
    {
        [Then(@"user validates the WC Claim page elements")]
        public void ThenUserValidatesTheWCClaimPageElements()
        {
            General_SiteWide.AssertEnvironmentURL();
            AutomationHelper.ValidateElements(WCClaimsPage.WC_ClaimsPageElements);
        }

        [Then(@"user verifies the WC Claims page error messages")]
        public void ThenUserVerifiesTheWCClaimsPageErrorMessages()
        {
            AutomationHelper.WaitForLoading();
            WCClaimsPage.SubmitClaimsButton.Click();
            AutomationHelper.ValidateElements(WCClaimsPage.WC_ClaimsPageErrorMessages);
        }

        [When(@"user fills out the WC Claims page with these values:")]
        public void WhenUserFillsOutTheWCClaimsPageWithTheseValues(Table table)
        {
            foreach (TableRow rowy in table.Rows)
            {
                var theQuestion = rowy["Question"];
                var theAnswer = rowy["Answer"];
                HandleWCClaimsPage(theQuestion, theAnswer);
            }
        }

        private static void HandleWCClaimsPage(string theQuestion, string theAnswer)
        {
            switch (theQuestion)
            {
                case "Policy Number":
                    WCClaimsPage.PolicyNumberTextbox.SetText(theAnswer);
                    break;
                case "Business Name":
                    WCClaimsPage.BusinessNameTextbox.SetText(theAnswer);
                    break;
                case "First Name":
                    WCClaimsPage.FirstNameTextbox.SetText(theAnswer);
                    break;
                case "Last Name":
                    WCClaimsPage.LastNameTextbox.SetText(theAnswer);
                    break;
                case "Phone":
                    WCClaimsPage.PhoneTextbox.SetText(theAnswer);
                    break;
                case "Ext":
                    WCClaimsPage.PhoneNumExtTextbox.SetText(theAnswer);
                    break;
                case "How to Connect":
                    WCClaimsPage.HowToConnectTextbox.SetText(theAnswer);
                    break;
                case "Injured Worker First Name":
                    WCClaimsPage.InjuredWorkerFirstNameAnswer.SetText(theAnswer);
                    break;
                case "Injured Worker Last Name":
                    WCClaimsPage.InjuredWorkerLastNameAnswer.SetText(theAnswer);
                    break;
                case "Injured Worker Street Address":
                    WCClaimsPage.InjuredWorkerAddress1.SetText(theAnswer);
                    break;
                case "ZIP Code":
                    WCClaimsPage.InjuredWorkerZip.SetText(theAnswer);
                    break;
                case "City":
                    Thread.Sleep(1000);
                    if (WCClaimsPage.InjuredWorkerCityModel(theAnswer).GetCountOfElements() == 0)
                    {
                        WCClaimsPage.InjuredWorkerCity.Click();
                        WCClaimsPage.InjuredWorkerCityOption(theAnswer).Click();
                    }
                    break;
                case "Injured Worker SSN":
                    WCClaimsPage.InjuredWorkerSSNAnswer.SetText(theAnswer);
                    break;
                case "Injured Worker DOB":
                    WCClaimsPage.InjuredWorkerDOBInput.EnterResponse(theAnswer);
                    break;
                case "Injured Worker Phone":
                    WCClaimsPage.InjuredWorkerPhoneAnswer.SetText(theAnswer);
                    break;
                case "Injured Worker Ext":
                    WCClaimsPage.InjuredWorkerExtAnswer.SetText(theAnswer);
                    break;
                case "Date of Injury":
                    WCClaimsPage.DateOfInjuryOrIllnessInput.EnterResponse(theAnswer);
                    break;
                case "Injury Location":
                    WCClaimsPage.LocationOfLossTxtbox.SetText(theAnswer);
                    break;
                case "Short Description":
                    WCClaimsPage.ShortDescripTextbox.SetText(theAnswer);
                    break;
            }
        }
    }
}
