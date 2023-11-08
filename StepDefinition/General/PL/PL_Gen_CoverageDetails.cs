using BiBerkLOB.Pages;
using BiBerkLOB.Pages.PL;
using TechTalk.SpecFlow;
using HitachiQA.Helpers;
using BiBerkLOB.Components.PL;
using System;
using BiBerkLOB.Source.Helpers;
using BiBerkLOB.StepDefinition.General.GenAutomation;
using BiBerkLOB.StepDefinition.General.PL.Automation;
using BiBerkLOB.StepDefinition.General.PL.Automation.Factories;

namespace BiBerkLOB.StepDefinition.General.PL
{
    [Binding]
    public sealed class PL_Gen_CoverageDetails
    {
        private readonly PLCoverageDetailsAutomation _automation;

        public PL_Gen_CoverageDetails(PLCoverageDetailsAutomationFactory factory)
        {
            _automation = factory.CreateAutomation();
        }

        [Then(@"user verifies the appearance of the PL Coverage Details page")]
        public void ThenUserVerifiesThePLCoverageDetailsPage()
        {
            PL_CoverageDetails.LoadingRequirements.AssertLegacy();
            //verifies URL is still on the correct environment
            General_SiteWide.AssertEnvironmentURL();
        }

        [Then(@"user fills out the PL Coverage Details page with these values:")]
        public void UserPLCovDetailFill(Table table)
        {
            AutomationHelper.LegacyWaitForLoading(120);

            foreach (TableRow rowy in table.Rows)
            {
                var theQuestion = rowy["Question"];
                var theAnswer = rowy["Answer"];
                HandleCovDetails(theQuestion, theAnswer);
            }

            PL_CoverageDetails.LetsContinueCTA.Click();
        }

        private void HandleCovDetails(string theQuestion, string theAnswer)
        {
            switch (theQuestion)
            {
                case "When should your policy start?":
                    _automation.VerifyDefaultPolicyStartDate();
                    _automation.SelectPolicyStartDate(theAnswer);
                    break;
                case "Do you currently have an Errors & Omissions policy in effect?":
                case "Do you currently have a Professional Liability (E&O) policy in effect?":
                    _automation.SelectCurrentlyHavePLPolicyYesOrNo(theAnswer);
                    break;
                case "Does your current policy have a retroactive date?":
                    _automation.SelectCurrentRetroDateYesNoIdk(theAnswer);
                    break;
                case "What is the retroactive date?":
                    _automation.SpecifyRetroDate(theAnswer);
                    break;
                case "Have you had a Professional Liability (E&O) policy in the last 3 years?":
                    _automation.SelectHaveYouHadPLYesOrNo(theAnswer);
                    break;

                case ("Which option best describes your current professional liability policy?"):
                case ("Which option best describes your current Errors & Omissions policy?"):
                    _automation.ChooseOptionBestDescribesCurrentPolicy(theAnswer);
                    break;

                case "How many Professional Liability (E&O) claims have you had in the past 3 years, if any?":
                case "How many Errors & Omissions claims have you had in the past 3 years, if any?":
                    _automation.SpecifyHowManyClaimsInLast3Years(theAnswer);
                    break;
                default:
                    break;
            }
        }
    }
}