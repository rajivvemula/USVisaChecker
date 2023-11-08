using ApolloQA.Source.Helpers;
using BiBerkLOB.Pages;
using BiBerkLOB.Pages.CommAuto;
using HitachiQA;
using HitachiQA.Driver;
using HitachiQA.Helpers;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation.Factories;
using TechTalk.SpecFlow;

namespace BiBerkLOB.StepDefinition.General.CommAuto
{
    [Binding]
    public sealed class CA_Gen_YourQuote
    {
        private readonly CAYourQuoteAutomation _automation;

        public CA_Gen_YourQuote(CAYourQuoteAutomationFactory factory)
        {
            _automation = factory.CreateAutomation();
        }

        [Then(@"user verifies the appearance of the Quote Page")]
        public void ThenUserVerifiesTheAppearanceOfTheQuotePage()
        {
            AutomationHelper.WaitForLoading();
            CA_QuoteSummaryPage.LoadingRequirements.Assert();
        }
        
        [Then(@"user verifies the current price is (more|less) than \$(.*)")]
        public void ThenUserVerifiesCurrentPrice(string moreOrLessTxt, decimal valueToCompareTo)
        {
            _automation.VerifyPriceComparison(moreOrLessTxt, valueToCompareTo);
        }

        [Then(@"user checks the stepper appearance on the Your Quote page")]
        public void ThenUserChecksStepperYourQuotePage()
        {
            _automation.ValidateStepper();
        }

        [Then(@"user clicks continue from the Quote page")]
        public void ThenUserContinuesFromQuotePage()
        {
            _automation.ClickContinue();
        }


        [Then(@"user completes their Quote")]
        public void ThenUserCompletesTheirQuote(Table table)
        {
            foreach (TableRow rowy in table.Rows)
            {
                var theQuestion = rowy["Question"];
                var theAnswer = rowy["Answer"];
                //If an answer is empty/null, skips over the question to the next one
                if (!string.IsNullOrEmpty(theAnswer))
                {
                    HandleTableValue(theQuestion, theAnswer);
                }
            }

            _automation.SaveUpdatesIfAny();

            _automation.ValidateUnInsuredUnderInsuredSection(); // This new section is by default disabled in the Your Quote Page
            //Save the expected payment amount today
            _automation.SaveExpectedPaymentToday();
        }

        public void HandleTableValue(string tableQuestion, string tableAnswer)
        {
            switch (tableQuestion)
            {
                case "Yearly":
                    _automation.SetYearlyOrMonthly(tableAnswer);
                    break;
                case "Policy Coverages":
                    _automation.SelectPolicyCoverages(tableAnswer);
                    break;
                case "Vehicle 1 Coverage":
                    _automation.SelectVehicleCoverage(tableAnswer, 0);
                    break;
                case "Vehicle 2 Coverage":
                    _automation.SelectVehicleCoverage(tableAnswer, 1);
                    break;
                case "Vehicle 3 Coverage":
                    _automation.SelectVehicleCoverage(tableAnswer, 2);
                    break;
                case "Medical Payments":
                    _automation.SelectMedicalPaymentCoverage(tableAnswer);
                    break;
                case "Cargo Liability":
                    _automation.SelectCargoCoverage(tableAnswer);
                    break;
                case "Trailer Interchange":
                    _automation.SelectTrailerCoverage(tableAnswer);
                    break;
                case "Rental Reimbursement":
                    _automation.SelectRentalCoverage(tableAnswer);
                    break;
                case "In-Tow":
                    _automation.SelectInTowCoverage(tableAnswer);
                    break;
                case "Policy Medical":
                    _automation.SelectPolicyMedicalCoverage(tableAnswer);
                    break;
                default:
                    break;
            }
        }
    }
}
