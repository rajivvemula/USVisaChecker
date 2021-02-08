using System;
using TechTalk.SpecFlow;
using ApolloQA.Pages;
using ApolloQA.Source.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace ApolloQA.StepDefinition.Quote
{
    [Binding]
    public class QuoteSectionDriverSteps
    {

        [When(@"user select a Driver with the following relevant values")]
        public void WhenUserSelectADriverWithTheFollowingRelevantValues()
        {
            var field = Shared.GetDropdownField("Select Driver");

            //if there are no existing drivers, Create New
            if (field.GetMatdropdownOptionsText().ToList().Count <= 1)
            {
                //call create new driver
                Functions.handleFailure(new NotImplementedException("there was no drivers to pick from, handle to create new driver needs to be implemented"));
            }
            field.SelectMatDropdownOptionByIndex(0);
        }

        [When(@"user select a Driver with the following relevant values")]
        public void WhenUserSelectADriverWithTheFollowingRelevantValues(Table table)
        {
            new NotImplementedException("Selecting a driver with defined values not yet implemented");
        }


        [When(@"user adds a new Driver with the following relevant values")]
        public void WhenUserAddsANewDriverWithTheFollowingRelevantValues(Table table)
        {
            //additional rows will be ignored
            var row = table.Rows[0];

            foreach (var column in row)
            {
                var fieldDisplayName = column.Key;
                var fieldValue = column.Value;
                var fieldType = FieldTypes[fieldDisplayName];

                if (fieldValue.ToLower() == "random")
                {
                    switch (fieldDisplayName)
                    {
                        case "Drivers License Number":
                            fieldValue = Functions.GetValidIllinoisDriversLicenseNumber();
                            break;
                        default:
                            Functions.handleFailure(new NotImplementedException($"Field {fieldDisplayName} random value hasn't been implemented"));
                            break;
                    }
                }
                var field = Shared.GetField(fieldDisplayName, fieldType);

                if (fieldType == "Dropdown" && fieldValue.Contains(':'))
                {
                    switch (fieldValue.Substring(0, fieldValue.IndexOf(':')))
                    {
                        case "index":
                            field.SelectMatDropdownOptionByIndex(int.Parse(fieldValue.Substring(fieldValue.IndexOf(':') + 1, 1)));
                            break;
                        default:
                            Functions.handleFailure(new NotImplementedException($"Field {fieldDisplayName} custom value: {fieldValue} hasn't been implemented"));
                            break;
                    }
                }
                else
                {

                    field.setValue(fieldType, fieldValue);
                }
            }
        }



        private static readonly Dictionary<String, String> FieldTypes = new Dictionary<String, String>() {

            {"First Name","Input" },
            {"Last Name", "Input" },
            {"Middle Name", "Input" },
            {"Suffix", "Input" },
            {"Date of Birth", "Input" },
            {"Drivers License State", "Dropdown" },
            {"Drivers License Number", "Input" },
            {"Expiration Date", "Input" },
        };





        public string DriverSelected = "";
        public string Checked = "cdk-mouse focused mat-radio checked";

        [When(@"user checks for existing driver")]
        public void WhenUserChecksForExistingDriver()
        {
            try { Quote_Drivers_Page.DriverRecord.assertElementIsVisible(5); }
            catch
            {
                Quote_Drivers_Page.NewDriverButton.Click();
                try
                {
                    Quote_Drivers_Page.ExistingDriverDropdown.SelectMatDropdownOptionByIndex(0, out string existingDriver);
                    DriverSelected = existingDriver;
                    Log.Info($"Expected Selected Driver: {nameof(DriverSelected)}={DriverSelected}");
                }
                catch
                {
                    Quote_Drivers_Page.FirstNameInput.setText("Tester");
                    Quote_Drivers_Page.LastName.setText("driver");
                    Quote_Drivers_Page.DateOfBirth.setText("04/04/1989");
                    Quote_Drivers_Page.DriverLicenseDropdown.SelectMatDropdownOptionByText(" IL ");
                    Quote_Drivers_Page.DriverLicenseNumberInput.setText("E53509853027");
                    Quote_Drivers_Page.DLExpirationDate.setText("04/04/2029");
                    Quote_Drivers_Page.CdlDropdown.SelectMatDropdownOptionByText(" No ");
                    //if (Quote_Drivers.DLStateExceptionsNo.assertElementNotPresent() == false)
                    //{
                    //    Quote_Drivers.DLStateExceptionsNo.Click();
                    //}
                }
                Quote_Drivers_Page.ActiveLicenseStatusButton.Click();
                Quote_Drivers_Page.InspectionCountInput.setText("10");
                Quote_Drivers_Page.ExcludeDriverNo.Click();
                var required = Quote_Drivers_Page.ActiveLicenseStatusButton.GetAttribute("class");
                // TODO : Temporary fix until scroll to Element is working again.
                for (var i = 0; i < 5; i++)
                {
                    do
                    {
                        if (required.EndsWith(Checked) == false)
                        {
                            Quote_Drivers_Page.ActiveLicenseStatusButton.Click();
                        }
                    }
                    while (required.EndsWith("ng-star-inserted"));
                }
                Quote_Drivers_Page.SaveDriverButton.Click();
            }
        }

        [Then(@"User verifies collapse all and expand all")]
        public void ThenUserVerifiesCollapseAllAndExpandAll()
        {
            Quote_Drivers_Page.ExpandAllButton.Click();
            Quote_Drivers_Page.ExpandedInfo.assertElementIsVisible();
            Quote_Drivers_Page.CollapseAllButton.Click();
            Quote_Drivers_Page.ExpandedInfo.assertElementNotPresent();
        }

        [When(@"user checks Quote info page buttons")]
        public void WhenUserChecksQuoteInfoPageButtons()
        {
            //Quote_Create_Page.SubmitButton.assertElementNotPresent();
            Quote_Create_Page.BusinessName.setText("A&M");
            Quote_Create_Page.BusinessName.SelectMatDropdownOptionByText("A&M Organization Test");
            var primary = Quote_Create_Page.SubmitButton.GetAttribute("class");
            Assert.IsTrue(primary.Contains("mat-primary"));
            var color = Quote_Create_Page.SubmitButton.GetAttribute("color");
            Assert.AreEqual(color, "primary");
        }

        [Then(@"user checks Drivers grid page buttons")]
        public void ThenUserChecksDriversGridPageButtons()
        {
            var gridbutton = Quote_Drivers_Page.GridNextButton.GetAttribute("color");
            Assert.AreEqual(gridbutton, "primary");
            var primary = Quote_Drivers_Page.GridNextButton.GetAttribute("class");
            Assert.IsTrue(primary.Contains("mat-primary"));
        }
    }
}
