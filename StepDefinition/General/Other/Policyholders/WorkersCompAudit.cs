using TechTalk.SpecFlow;
using BiBerkLOB.Pages;
using HitachiQA.Driver;
using BiBerkLOB.StepDefinition.General.GenAutomation;
using System.Linq;
using BiBerkLOB.Source.Helpers;
using HitachiQA.Helpers;
using DocumentFormat.OpenXml.Presentation;
using DocumentFormat.OpenXml.Bibliography;
using Faker;
using Microsoft.Azure.Cosmos;
using BiBerkLOB.Pages.Other.Policyholders;


namespace BiBerkLOB.StepDefinition.General.Other.COI
{
    [Binding]
    public sealed class WorkersCompAudit
    {
        [Then(@"user verifies WC Audit page")]
        public void ThenUserVerifyWCAuditPage()
        {
            foreach (var element in WorkersCompAuditPage.WCAuditElements)
            {
                element.AssertElementIsVisible();
            }
        }

        [Then(@"user fills out WC Audit page with the following values:")]
        public void UserWCAuditFill(Table table)
        {
            foreach (TableRow rowy in table.Rows)
            {
                var theQuestion = rowy["Question"];
                var theAnswer = rowy["Answer"];
                UserWCAuditFill(theQuestion, theAnswer);
            }
            WorkersCompAuditPage.ForgotPhoneNumber_BTN.Click();
        }

        private void UserWCAuditFill(string theQuestion, string theAnswer)
        {
            switch (theQuestion)
            {
                case "Policy Number":
                    WorkersCompAuditPage.PolicyNumber.AssertElementIsVisible();
                    WorkersCompAuditPage.PolicyNumber_Input.SetText(theAnswer);
                    break;
            }
        }

        [Then(@"user clicks Forgot Phone Number button")]
        public void ThenUserClicksForgotButton()
        {
            WorkersCompAuditPage.ForgotPhoneNumber_BTN.Click();
        }

        [Then(@"user validates Forgot Phone Number modal")]
        public void ThenUserValidatesForgotNumber()
        {
            foreach (var element in WorkersCompAuditPage.ForgotNumElements)
            {
                element.AssertElementIsVisible();
            }
        }

        [Then(@"user fills out Forgot Phone Number modal with following values:")]
        public void UserForgotNumberFill(Table table)
        {
            foreach (TableRow rowy in table.Rows)
            {
                var theQuestion = rowy["Question"];
                var theAnswer = rowy["Answer"];
                HandleForgotNumber(theQuestion, theAnswer);
            }
            WorkersCompAuditPage.EmailYourPhoneNumber_CTA.Click();
        }

        private void HandleForgotNumber(string theQuestion, string theAnswer)
        {
            switch (theQuestion)
            {
                case "Policy Number":
                    WorkersCompAuditPage.PolicyNumberRecovery.AssertElementIsVisible();
                    WorkersCompAuditPage.PolicyNumberRecovery_Input.SetText(theAnswer);
                    break;

            }
        }

        [Then(@"user validates that the Policy Details Have Been Emailed toast appears")]
        public void ThenUserValidatesConfirmation()
        {
            WorkersCompAuditPage.PolicyDetailsHaveBeenEmailed.AssertElementIsVisible();
        }

    }
}