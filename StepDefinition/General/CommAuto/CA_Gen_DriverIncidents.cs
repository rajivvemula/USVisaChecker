using ApolloQA.Source.Helpers;
using BiBerkLOB.Pages;
using BiBerkLOB.Pages.CommAuto;
using HitachiQA;
using HitachiQA.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using BiBerkLOB.Source.Driver;
using BiBerkLOB.Source.Helpers;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation.Factories;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation.Models;
using BiBerkLOB.StepDefinition.General.GenAutomation;
using HitachiQA.Helpers;
using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace BiBerkLOB.StepDefinition.General.CommAuto
{
    [Binding]
    public sealed class CA_Gen_DriverIncidents
    {
        private readonly CADriverIncidentAutomation _automation;
        private readonly QuestionErrorHandler _questionErrorHandler;

        public CA_Gen_DriverIncidents(CADriverIncidentAutomationFactory factory, QuestionErrorHandler questionErrorHandler)
        {
            _automation = factory.CreateAutomation();
            _questionErrorHandler = questionErrorHandler;

        }

        [Then(@"user verifies the appearance of the Drivers Incidents page")]
        public void ThenUserVerifiesTheAppearanceOfTheDriversIncidentsPage()
        {
            CA_DriverIncidentsPage.LoadingRequirements.Assert(90);
        }

        [Then(@"user adds incidents with the following values:")]
        public void ThenAddDriverIncident(Table table)
        {
            _automation.Reset();
            for (var r = 0; r < table.RowCount; r++)
            {
                var row = table.Rows[r];
                var listOfKeys = row.Keys.ToList();
                FillCurrentOutIncident(listOfKeys, row);
                _automation.SaveCurrentIncidentObject();
                AddIncidentPanelIfThereIsMore(table, r);
            }
        }

        //"incident #x" should be zero-indexed (ie: first incident is #0, second is #1, etc.)
        [Then(@"user edits incident #(\d+) with the following values:")]
        public void ThenEditDriverIncident(string incidentIndex, Table table)
        {
            var row = table.Rows[0];
            var index = int.Parse(incidentIndex);
            EditIncident(index, row.Keys.ToList(), row);
            _automation.SaveIncidentObject(index);
        }

        [Then(@"user continues to the Operations page")]
        public void ThenUserContinuesToOperationsPage()
        {
            _automation.ContinueToNextPage();
            _questionErrorHandler.IsErrorVisible();

        }

        [Then(@"user checks the stepper appearance on the Driver Incidents page")]
        public void ThenUserChecksStepperDriverIncidentsPage()
        {
            _automation.ValidateStepper();
        }


        [Then(@"user clicks on Remove Incident button")]
        public void ThenUserClicksOnRemoveIncidentButton()
        {
            CA_DriverIncidentsPage.RemoveButton.Click();
        }
        private void EditIncident(int incidentIndex, List<string> questions, TableRow answers)
        {
            EnsurePanelIsOpen(incidentIndex);
            for (int i = 0; i < answers.Count; i++)
            {
                //get the Value of the Table header AND value
                var question = questions[i];
                var answer = answers[i];

                //different incidents may have not have the same questions
                //blank will be considered "not present, do not answer"
                if (!string.IsNullOrEmpty(answer))
                {
                    //assign the switch value to the table header
                    AutomateIncidentPanel(_automation.GetIncident(incidentIndex), question, answer);
                }
            }
        }

        private void EnsurePanelIsOpen(int incidentIndex)
        {
            _automation.GetIncident(incidentIndex).ExpandPanel();
        }

        private void FillCurrentOutIncident(List<string> questions, TableRow answers)
        {
            for (int i = 0; i < answers.Count; i++)
            {
                //get the Value of the Table header AND value
                var question = questions[i];
                var answer = answers[i];

                //different incidents may have not have the same questions
                //blank will be considered "not present, do not answer"
                if (!string.IsNullOrEmpty(answer))
                {
                    //assign the switch value to the table header
                    AutomateIncidentPanel(_automation.LastIncident, question, answer);
                }
            }
        }

        private void AutomateIncidentPanel(IncidentPanelAutomation incidentAutomation, string question, string answer)
        {
            var questionName = question;
            int? violationNum = null;
            // allow for specifying which violation in the event of needing edits
            if (question.Contains('#'))
            {
                questionName = question.Substring(0, question.IndexOf('#') - 1);
                violationNum = int.Parse(question.Last().ToString());
            }
            switch (questionName)
            {
                //Which driver was involved in this incident? - Driver	
                case "Driver":
                    incidentAutomation.SelectDriver(answer);
                    break;
                //What was the date of the incident? - Date
                case "Date":
                    incidentAutomation.EnterDateOfIncident(answer);
                    break;
                //What type of incident was it?	- Incident Type
                case "Incident Type":
                    incidentAutomation.SelectIncidentType(answer);
                    break;
                //Was the driver at fault? - At Fault
                case "At Fault":
                    incidentAutomation.SelectAtFault(answer);
                    break;
                //What was the violation / conviction? - Violation/Conviction
                case "Violation/Conviction":
                    if(violationNum == null)
                    {
                        incidentAutomation.SelectCurrentViolationConviction(answer);
                        break;
                    }
                    incidentAutomation.SelectViolationConviction(answer, violationNum.Value);
                    break;
                //Describe the violation / conviction. - Describe V/C
                case "Describe V/C":
                    if (violationNum == null)
                    {
                        incidentAutomation.EnterCurrentVCDescription(answer);
                        break;
                    }
                    incidentAutomation.EnterVCDescription(answer, violationNum.Value);
                    break;
                //Did this speeding violation also result in a reckless / careless driving conviction - Reckless	
                case "Reckless":
                    if (violationNum == null)
                    {
                        incidentAutomation.SelectCurrentRecklessDrivingYesNo(answer);
                        break;
                    }
                    incidentAutomation.SelectRecklessDrivingYesNo(answer, violationNum.Value);
                    break;
                //Was there another violation / conviction associated with this incident? - Another V/C
                case "Another V/C":
                    if (violationNum == null)
                    {
                        incidentAutomation.HandleCurrentAnotherVCYesNo(answer);
                        break;
                    }
                    incidentAutomation.HandleAnotherVCYesNo(answer, violationNum.Value);
                    break;
                default:
                    throw new Exception($"'{question}' is not a valid Drivers Incidents question");
            }
        }

        private void AddIncidentPanelIfThereIsMore(Table table, int r)
        {
            if (r != table.RowCount - 1)
            {
                _automation.AddAnotherIncident();
            }
        }
    }
}