using BiBerkLOB.Pages;
using BiBerkLOB.Pages.CommAuto;
using HitachiQA;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using BiBerkLOB.Source.Driver;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation.Factories;
using HitachiQA.Helpers;
using BiBerkLOB.StepDefinition.General.GenAutomation;

namespace BiBerkLOB.StepDefinition.General.CommAuto
{
    [Binding]
    public sealed class CA_Gen_Introduction
    {
        private readonly CAQuickIntroAutomation _automation;
        private readonly QuestionErrorHandler _questionErrorHandler;

        public CA_Gen_Introduction(CAQuickIntroAutomationFactory factory, QuestionErrorHandler questionErrorHandler)
        {
            _automation = factory.CreateAutomation();
            _questionErrorHandler = questionErrorHandler;
        }

        [Then(@"user verifies the appearance of the Introduction page")]
        public void ThenUserVerifiesIntroPage()
        {
            AutomationHelper.WaitForLoading();
            CA_IntroductionPage.LoadingRequirements.Assert();
            _automation.AssertQuoteIdIsVisible();
        }

        [Then(@"user checks the stepper appearance on the Introduction page")]
        public void ThenUserChecksStepperIntroPage()
        {
            _automation.ValidateStepper();
        }

        [Then(@"user fills in the Introduction page with these values:")]
        public void ThenUserFillsInIntroPage(Table table)
        {
            var row = table.Rows[0];

            var yearBusStarted = row["Year Business Started"];
            _automation.EnterYearBusinessStarted(yearBusStarted);

            var optionDisplayText = row["How Business Structured"];
            _automation.SelectBusinessStructure(optionDisplayText);

            if(row.ContainsKey("Government Entity Type"))
            {
                var govEntityType = row["Government Entity Type"];
                _automation.SelectGovernmentEntityType(govEntityType);
            }

            var businessAddress = new Address()
            {
                Line1 =  row["Address1"],
                Line2 =  row["Address2"],
                City = row["City"]
            };
            
            row.TryGetValue("Select an Address", out var suggestion);
            _automation.EnterBusinessAddress(businessAddress, suggestion);
        }

        [Then(@"user fills in the alternate mailing address with these values:")]
        public void ThenUserFillsInAlternateMailingAddress(Table table)
        {
            var row = table.Rows[0];

            _automation.ToggleMailingAddressCheckbox(false);

            var address = new Address()
            {
                Line1 = row["Address1"],
                Line2 = row["Address2"],
                ZipCode = row["Zip"],
                City = row["City"],
                State = State.FromAny(row["State"])
            };
            row.TryGetValue("Select an Address", out var suggestion);

            _automation.EnterMailingAddress(address, suggestion);
        }

        [Then(@"user clicks continue from CA Introduction")]
        public void ThenUserContinues()
        {
            _automation.ClickContinue();
            _questionErrorHandler.IsErrorVisible();
        }
    }
}
