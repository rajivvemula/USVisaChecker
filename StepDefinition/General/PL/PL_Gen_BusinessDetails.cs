using BiBerkLOB.Components.PL;
using BiBerkLOB.Pages;
using BiBerkLOB.Pages.PL;
using BiBerkLOB.Source.Helpers;
using HitachiQA.Helpers;
using System;
using BiBerkLOB.StepDefinition.General.PL.Automation;
using BiBerkLOB.StepDefinition.General.PL.Automation.Factories;
using TechTalk.SpecFlow;

namespace BiBerkLOB.StepDefinition.General.PL
{
    [Binding]
    public sealed class PL_Gen_BusinessDetails
    {
        private readonly PLBusinessDetailsAutomation _businessDetailsAutomation;
        
        public PL_Gen_BusinessDetails(PLBusinessDetailsAutomationFactory factory)
        {
            _businessDetailsAutomation = factory.CreateAutomation();
        }

        [Then(@"user verifies the appearance of the PL Business Details page")]
        public void UserPLBusDetailAppearance()
        {
            PL_BusinessDetailsPage.LoadingRequirements.AssertLegacy();
            //verifies URL is still on the correct environment
            General_SiteWide.AssertEnvironmentURL();
        }

        [Then(@"user fills out the PL Business Details page with these values:")]
        public void UserPLBusDetailFill(Table table)
        {
            foreach (TableRow rowy in table.Rows)
            {
                var theQuestion = rowy["Question"];
                var theAnswer = rowy["Answer"];
                HandleBusDetails(theQuestion, theAnswer);
            }
            PL_BusinessDetailsPage.LetsContinueCTA.Click();
        }

        private void HandleBusDetails(string theQuestion, string theAnswer)
        {
            switch (theQuestion)
            {
                case "What year was your business started?":
                    _businessDetailsAutomation.EnterBusinessYearStarted(theAnswer);
                    break;
                case "What is your estimated gross annual revenue?":
                    _businessDetailsAutomation.EnterGrossAnnualRevenue(theAnswer);
                    break;
                case "Do you use a written contract or statement of work (SOW)?":
                    _businessDetailsAutomation.ChooseContractOption(theAnswer);
                    break;
                case "How many attorneys does your firm have?":
                    _businessDetailsAutomation.EnterNumAttorneys(theAnswer);
                    break;
                case "Do you use any of counsel or independent contractor attorneys?":
                    _businessDetailsAutomation.SpecifyCounselContractAttorneyYesOrNo(theAnswer);
                    break;
                case "Number of full-time of counsel/independent contractor attorneys:":
                    _businessDetailsAutomation.EnterNumFullTimeAttorneys(theAnswer);
                    break;
                case "Number of part-time of counsel/independent contractor attorneys:":
                    _businessDetailsAutomation.EnterNumPartTimeAttorneys(theAnswer);
                    break;
                case "Who signs off on the terms & conditions for written contracts or statements of work (SOW)?":
                    _businessDetailsAutomation.ChooseWhoSignsTermsAndConditions(theAnswer);
                    break;
                case "How many healthcare professionals work for your business?":
                    _businessDetailsAutomation.EnterNumHealthcareProfessionals(theAnswer);
                    break;
                case "How many health students work for your business?":
                    _businessDetailsAutomation.SpecifyNumHealthStudents(theAnswer);
                    break;
                case "Do you work as an independent contractor (paid via 1099) or as an employee of a health organization (paid via W-2)?":
                    _businessDetailsAutomation.ChooseIndependentContractorOrEmployee(theAnswer);
                    break;
                case "Have you obtained this professional healthcare designation within the last two years?":
                    _businessDetailsAutomation.ChooseHealthcareLastTwoYearsYesOrNo(theAnswer);
                    break;
                case "When did you graduate or obtain this designation?":
                    _businessDetailsAutomation.PickDateForDesignation(theAnswer);
                    break;
                default:
                    break;
            }
        }
        [Then(@"user verifies the appearance of the Save in PL Business Details page")]
        public void VerifySaveButtonIsVisible()
        {
            PL_BusinessDetailsPage.QuoteRibbonNeedToFinishLater.AssertElementIsVisible();
            PL_BusinessDetailsPage.QuoteRibbonSaveButton.AssertElementIsVisible();
            PL_BusinessDetailsPage.QuoteRibbonSaveButton.Click();
        }

        [Then(@"user enter the following email ""(.*)"" to save for later")]
        public void UserEntersEmail(string email)
        {
            PL_BusinessDetailsPage.EmailInput.AssertElementIsVisible();
            PL_BusinessDetailsPage.EmailInput.SetText(email);
            PL_BusinessDetailsPage.GetMyLinkButton.AssertElementIsVisible();
            PL_BusinessDetailsPage.GetMyLinkButton.Click();
        }
    }
}