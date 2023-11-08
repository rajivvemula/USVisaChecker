using BiBerkLOB.Pages;
using BiBerkLOB.Pages.CommAuto;
using HitachiQA;
using System;
using System.Collections.Generic;
using System.Linq;
using BiBerkLOB.Source.Driver;
using BiBerkLOB.Source.Helpers;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation.Factories;
using TechTalk.SpecFlow;
using HitachiQA.Driver;
using BiBerkLOB.StepDefinition.General.GenAutomation;
using HitachiQA.Helpers;

namespace BiBerkLOB.StepDefinition.General.CommAuto
{
    [Binding]
    public sealed class CA_Gen_Summary
    {
        private readonly QuestionErrorHandler _questionErrorHandler;
        private readonly CASummaryAutomation _automation;

        public CA_Gen_Summary(CASummaryAutomationFactory factory, QuestionErrorHandler questionErrorHandler)
        {
            _automation = factory.CreateAutomation();
            _questionErrorHandler = questionErrorHandler;
        }

        [Then(@"user clicks (.*) from the Summary page")]
        public void ThenUserClickFromSummaryPage(string buttonDescription)
        {
            _automation.ClickNavigation(buttonDescription);
            _questionErrorHandler.IsErrorVisible();
         }

        [Then(@"user checks the stepper appearance on the Summary page")]
        public void ThenUserChecksStepperSummaryPage()
        {
            _automation.ValidateStepper();
        }

        [Then(@"user verifies landing on Summary page")]
        public void ThenUserVerifiesLandingOnSummaryPage()
        {
            CA_SummaryPage.LoadingRequirements.Assert();
        }

        [Then(@"user verifies the appearance of the Summary page")]
        public void ThenUserVerifiesSummaryPage()
        {
            ThenUserVerifiesLandingOnSummaryPage();

            _automation.VerifyStartYourQuoteSummary();
            _automation.VerifyQuickIntroSummary();
            _automation.VerifyVehiclesSummary();
            _automation.VerifyDriversSummary();
            _automation.VerifyIncidentsSummaryIfAny();
            _automation.VerifyOperationsSummary();
            _automation.VerifyContactDetails();
        }

        [Then(@"user reverifies the appearance of Summary page")]
        public void ThenUserReverifiesTheAppearanceOfSummaryPage()
        {
            _automation.ReverifySummary();
        }
    }    
}