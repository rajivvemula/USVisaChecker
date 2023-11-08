using BiBerkLOB.Pages.CommAuto;
using System;
using TechTalk.SpecFlow;
using BiBerkLOB.Pages.Other;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation.Factories;
using BiBerkLOB.StepDefinition.General.GenAutomation;
using BiBerkLOB.Pages;
using System.Threading;
using HitachiQA.Helpers;

namespace BiBerkLOB.StepDefinition.General.CommAuto
{
    [Binding]
    public sealed class CA_Gen_Operations
    {
        private readonly CAOperationsAutomation _automation;
        private readonly QuestionErrorHandler _questionErrorHandler;

        public CA_Gen_Operations(CAOperationsAutomationFactory automationFactory, QuestionErrorHandler questionErrorHandler)
        {
            _automation = automationFactory.CreateAutomation();
            _questionErrorHandler = questionErrorHandler;
        }

        [Then(@"user fills out the Operations page:")]
        public void UserFillsOutOperationsPage(Table table)
        {
            CA_OperationsPage.LoadingRequirements.Assert();
            foreach (TableRow rowy in table.Rows)
            {
                var theQuestion = rowy["Question"];
                var theAnswer = rowy["Answer"];

                try
                {
                    HandleOperationsPage(theQuestion, theAnswer);
                }
                catch (Exception ex)
                {
                    _questionErrorHandler.ThrowErrorIfQuestionShouldAppear(ex);
                }
            }
        }

        public void HandleOperationsPage(string theQuestion, string theAnswer)
        {
            var questionDefinition = _automation.GetQuestionDefinitionFromText(theQuestion);
            var questionAnswer = questionDefinition.GetAnswerFromText(theAnswer);

            switch (questionDefinition.QuestionType)
            {
                case "singleselection-buttons":
                     _automation.AnswerSingleSelectButton(questionDefinition.QuestionAlias, questionAnswer.AnswerValue);
                    break;
                case "singleselection":
                    // selection method goes off dropdown text
                     _automation.AnswerSingleSelectDropdown(questionDefinition.QuestionAlias, questionAnswer.AnswerText);
                    break;
                case "boolean":
                    //boolean questions don't need an entry in the answer table
                    _automation.VerifyFMCSADefaultAnswer(theQuestion, theAnswer, questionDefinition.QuestionAlias);
                    _automation.AnswerYesNoButton(questionDefinition.QuestionAlias, theAnswer);
                    break;
                case "multiselection":      //separated by semicolon (;)
                    _automation.ClickOnCheckBoxes(questionDefinition.QuestionAlias, theAnswer);
                    break;
                case "text":
                case "number-string":
                case "numeric":
                    _automation.AnswerTextBox(questionDefinition.QuestionAlias, theAnswer);
                    break;
                case "checkbox-label":
                    _automation.ClickSoloCheckbox(questionDefinition.QuestionAlias, theAnswer);
                    break;
                default:
                    break;
            }

            _automation.SaveOperationsQuestion(new OperationsQuestionObject(theQuestion, theAnswer, questionDefinition));
        }

        [Then(@"user checks the stepper appearance on the Operations page")]
        public void ThenUserChecksStepperOperationsPage()
        {
            _automation.ValidateStepper();
        }

        [Then(@"user continues to the Contact page")]
        public void ThenUserLeavesOperationsPage()
        {
            CA_OperationsPage.LetsContinueCTA.Click();
            AutomationHelper.WaitForLoading();
            _questionErrorHandler.IsErrorVisible();
        }
    }
}