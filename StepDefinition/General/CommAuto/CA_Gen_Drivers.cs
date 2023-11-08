using BiBerkLOB.Pages.CommAuto;
using System;
using System.Linq;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation.Factories;
using TechTalk.SpecFlow;
using BiBerkLOB.Pages;
using BiBerkLOB.StepDefinition.General.GenAutomation;

namespace BiBerkLOB.StepDefinition.General.CommAuto
{
    [Binding]
    public sealed class CA_Gen_Drivers
    {
        private readonly CADriversAutomation _automation;
        private readonly QuestionErrorHandler _questionErrorHandler;

        public CA_Gen_Drivers(CADriverAutomationFactory factory, QuestionErrorHandler questionErrorHandler)
        {
            _automation = factory.CreateAutomation();
            _questionErrorHandler = questionErrorHandler;
        }

        [Then(@"user clicks continue from the Drivers page")]
        public void ThenUserContinueFromDriversPage()
        {
            _automation.ContinueToNextPage();
            _questionErrorHandler.IsErrorVisible();
          }

        [Then(@"User verifies appearance of the Drivers Page")]
        public void ThenUserVerifiesAppearanceOfTheDriversPage()
        {
            CA_DriversPage.LoadingRequirements.Assert();
        }

        [Then(@"user checks the stepper appearance on the Drivers page")]
        public void ThenUserChecksStepperDriversPage()
        {
            _automation.ValidateStepper();
        }

        [Then(@"user creates a driver with these values:")]
        public void ThenUserCreatesADriverWithTheseValues(Table table)
        {
            _automation.Reset();
            for (var r = 0; r < table.RowCount; r++)
            {
                var row = table.Rows[r];
                var countOfColumns = row.Count;
                var listOfKeys = row.Keys.ToList();
                for (int i = 0; i < countOfColumns; i++)
                {
                    //get the Value of the Table header AND value
                    var valueOfKey = listOfKeys[i];
                    var valueOfColumn = row[i];
                    //checking to see if a cell in the Vehicle table is empty to skip over it.
                    if (!string.IsNullOrEmpty(valueOfColumn))
                    {
                        HandleTableValue(valueOfKey, valueOfColumn, r);
                    }
                }

                _automation.SaveCurrentDriverObject();

                //check if there are more drivers to add
                //---if so, click the "Add Another Driver" button
                if (r != table.RowCount - 1)
                {
                    _automation.AddAnotherDriver();
                }
            }
        }

        [Then(@"user clicks on Remove Driver button")]
        public void ThenUserClicksOnRemoveDriverButton()
        {
            CA_DriversPage.RemoveButton.Click();
        }

        public void HandleTableValue(string tableColumn, string tableValue, int driverIndex)
        {
            switch (tableColumn)
            {
                //First Name
                case "FirstName":
                    _automation.GetDriver(driverIndex).EnterFirstName(tableValue);
                    break;
                //Last Name
                case "LastName":
                    _automation.GetDriver(driverIndex).EnterLastName(tableValue);
                    break;
                //Driver License State
                case "DLState":
                    _automation.GetDriver(driverIndex).SelectState(tableValue);
                    break;
                //Date of Birth
                case "DOB":
                    _automation.GetDriver(driverIndex).EnterDateOfBirth(tableValue);
                    break;
                //Does this driver have a Commercial Driver's License /(CDL)?
                case "CDL":
                    _automation.GetDriver(driverIndex).SelectCDL(tableValue);
                    break;
                //NSC Defensive Driving Course
                case "ILDDC":
                    _automation.GetDriver(driverIndex).SaveNSCDrivingCourseYesOrNo(tableValue);
                    break;
                //Illinois motor vehicle laws violations
                case "ILViolation":
                    _automation.GetDriver(driverIndex).SaveILViolationsYesOrNo(tableValue);
                    break;
                //Illinois Driver License revoked/suspended
                case "ILDLRevoked":
                    _automation.GetDriver(driverIndex).SaveILRevokedYesOrNo(tableValue);
                    break;
                //Has this driver had an accident or violation in the past 3 years, or a conviction in the past 5 years?
                case "Accident":
                    _automation.GetDriver(driverIndex).SelectAccidentViolationConvictionYesNo(tableValue);
                    break;
                //Driver's License Number
                case "DLNumber":
                    _automation.GetDriver(driverIndex).EnterDLN(tableValue);
                    break;
                default: throw new Exception("Table value is not currently mapped or is misspelled.");
            }
        }
    }
}

