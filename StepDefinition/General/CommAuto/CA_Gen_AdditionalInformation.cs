using BiBerkLOB.Pages;
using BiBerkLOB.Pages.CommAuto;
using HitachiQA.Helpers;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation.Factories;
using TechTalk.SpecFlow;
using BiBerkLOB.StepDefinition.General.GenAutomation;

namespace BiBerkLOB.StepDefinition.General.CommAuto
{
    [Binding]
    public sealed class CA_Gen_AdditionalInformation
    {
        private readonly CAAdditionalInfoAutomation _automation;
        private readonly QuestionErrorHandler _questionErrorHandler;

        public CA_Gen_AdditionalInformation(CAAdditionalInfoAutomationFactory factory, QuestionErrorHandler questionErrorHandler)
        {
            _automation = factory.CreateAutomation();
            _questionErrorHandler = questionErrorHandler;

        }

        [Then(@"user verifies the appearance of the Additional Information page")]
        public void AppearanceAdditionalInfo()
        {
            CA_AdditionalInformationPage.LoadingRequirements.Assert(120);
        }


        [Then(@"user fills out the Additional Information page:")]
        public void ThenAdditionalInfoPopulate(Table table)
       {
            _automation.InitPanelsAutomation(table.RowCount);
            
            for (int i = 0; i < table.RowCount; i++)
            {
                _automation.GetPanel(i).ExpandPanel();
                var row = table.Rows[i];
                
                // Vehicle details section should show up regardless of the VIN/NO VIN
                // status of vehicle so verify these fields first:
                _automation.GetPanel(i).VerifyVehicleDetails();
                HandleTableRow(row, i);
                _automation.GetPanel(i).CollapsePanel();
            }
        }

        [Then(@"user clicks continue from Additional Information")]
        public void ThenUserClicksContinueFromAdditionalInformation()
        {
            _automation.ClickContinue();
            _questionErrorHandler.IsErrorVisible();
        }


        private void HandleTableRow(TableRow row, int tableRowIndex)
        {
            var panel = _automation.GetPanel(tableRowIndex);
            foreach(var (valueOfKey, tableValue) in row)
            { 
                switch (valueOfKey)
                {
                    //checks for vin, if vin = yes then it will check for the vin that has been mentioned in feature file already,
                    //else it will take in the new vin you have entered 
                    case "VIN":
                        if (tableValue.Equals("Yes"))
                        {
                            panel.VerifyVINMatch();
                        }
                        else
                        {
                            panel.EnterVIN(tableValue);
                        }

                        break;
                    case "Trim":
                        if (!string.IsNullOrEmpty(tableValue))
                        {
                            panel.SelectTrim(tableValue);
                        }
                        break;
                    case "OLF":
                        HandleOLF(tableRowIndex, tableValue, row.TryGetValue("Who Holds Vehicle", out var titleHolder) ? titleHolder : null);
                        break;
                }
            }
        }

        private void HandleOLF(int tableRowIndex, string olfValue, string titleHolder)
        {
            var panel = _automation.GetPanel(tableRowIndex);
            var randomName = Functions.GetRandomStringWithRestrictions(7, "alpha");
            switch (olfValue)
            {
                case "Owned":
                    panel.SetVehicleAsOwned(titleHolder, randomName, randomName);
                    break;
                case "Financed":
                    panel.SetVehicleFinanced(randomName);
                    break;
                case "Leased":
                    panel.SetVehicleLeased(randomName);
                    break;
            }
        }
    }
}
