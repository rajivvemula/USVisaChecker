using System;
using TechTalk.SpecFlow;
using ApolloQA.Pages;
using ApolloQA.Source.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ApolloQA.StepDefinition.Quote
{
    [Binding]
    public class QuoteSectionVehicleSteps
    {
        [When(@"user selects a Vehicle with the following relevant values")]
        public void WhenUserSelectsAVehicleWithTheFollowingRelevantValues()
        {
            var field = Shared.GetDropdownField("Select Vehicle");

            //if there are no existing vehicles, Create New
            if (field.GetMatdropdownOptionsText().ToList().Count <= 1) 
            {
                //call create new vehicle
                Functions.handleFailure(new NotImplementedException("there was no vehicles to pick from, handle to create new vehicle needs to be implemented"));
            }
            else
            {
                Shared.GetDropdownField("Select Vehicle").SelectMatDropdownOptionByIndex(1);
            }
        }

        [When(@"user selects a Vehicle with the following relevant values")]
        public void WhenUserSelectsAVehicleWithTheFollowingRelevantValues(Table table)
        {

            
            
        }

        [When(@"user adds a new Vehicle with the following relevant values")]
        public void WhenUserEntersANewVehicleWithTheFollowingRelevantValues(Table table)
        {
                //additional rows will be ignored
                var row = table.Rows[0];
            
                foreach(var column in row)
                {
                    var fieldDisplayName = column.Key;
                    var fieldValue = column.Value;
                    var fieldType = FieldTypes[fieldDisplayName];

                    if(fieldValue.ToLower()=="random")
                    {
                        switch(fieldDisplayName)
                        {
                            case "VIN":
                                fieldValue = Functions.GetRandomVIN();
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
                            field.SelectMatDropdownOptionByIndex(int.Parse(fieldValue.Substring(fieldValue.IndexOf(':')+1, 1)));
                            break;
                            default:
                                Functions.handleFailure(new NotImplementedException($"Field {fieldDisplayName} custom value: {fieldValue} hasn't been implemented"));
                                break;
                        }
                    }
                    else
                    {
                        try
                        {
                            field.setValue(fieldType, fieldValue);
                        }
                        catch (Exception ex)
                        {
                        Log.Critical($"Field Type {fieldType} fieldValue: {fieldValue}");
                        }

                    }
                }
            
        }


        private static readonly Dictionary<String, String> FieldTypes = new Dictionary<String, String>() { 
            
            {"VIN","Input" },
            {"Year", "Input" },
            {"Make", "Input" },
            {"Model", "Input" },
            {"Body Category", "Dropdown" },
            {"Body Subcategory", "Dropdown" },
            {"Seating Capacity", "Dropdown" },
            {"Gross Vehicle Weight", "Dropdown" },
            {"Vehicle Class Code", "Dropdown" },
            {"Cost New", "Input" },
            {"Estimated Current Value", "Input" },
            {"Additional Modifications", "Input" },
            {"Underwriter Value", "Input" }
        };




        [When(@"user selects (.*) Button")]
        public void WhenUserSelectsButton(string button)
        {
            // TODO : Temporary fix until scroll to Element is working again.
            for (var i = 0; i < 5; i++)
            {
                switch (button.ToLower())
                {
                    case "owned":
                        Quote_Vehicles_Page.OwnedButton.Click();
                        break;
                    case "financed":
                        Quote_Vehicles_Page.FinancedButton.Click();
                        break;
                    case "leased":
                        Quote_Vehicles_Page.LeasedButton.Click();
                        break;
                    default:
                        throw new Exception($"Button option {button} not found");
                }
            }
        }

        [When(@"user verifies owner input is visible")]
        public void WhenUserVerifiesOwnerInputIsVisible()
        {
            Quote_Vehicles_Page.NameOfOwnerFirstInput.assertElementIsVisible();
            Quote_Vehicles_Page.NameOfOwnerSecondInput.assertElementIsVisible();
            Quote_Vehicles_Page.NameOfOwnerFirstInput.setText("Test Owner 1");
            Quote_Vehicles_Page.NameOfOwnerSecondInput.setText("Test Owner 2");
        }

        [When(@"user enters (.*) info")]
        public void WhenUserEntersInfo(string info)
        {
            switch (info.ToLower())
            {
                case "lienholder":
                    Quote_Vehicles_Page.NameOfLienholderInput.setText("Test Name of Lienholder");
                    break;
                case "lessor":
                    Quote_Vehicles_Page.NameOfLessorInput.setText("Test Name of Lessor");
                    break;
                default:
                    throw new Exception($"Ownership type {info} not found.");
            }
        }


        [Then(@"user adds Address")]
        public void ThenUserAddsAddress()
        {
            Quote_Vehicles_Page.AddAddressButton.Click();
            //scenario sometimes fails because it clicks location too fast (before it loads)
            Thread.Sleep(1000);
            Quote_Vehicles_Page.AddressTypeDropdown.SelectMatDropdownOptionByText("Location");
            Quote_Vehicles_Page.StreetAddressOneInput.setText("14662 La Grange Road");
            Quote_Vehicles_Page.StreetAddressTwoInput.setText("Unit B-1");
            Quote_Vehicles_Page.CityInput.setText("Orland Park");
            Quote_Vehicles_Page.StateDropdown.SelectMatDropdownOptionByText("IL");
            Quote_Vehicles_Page.ZipInput.setText("60462");
            Quote_Vehicles_Page.CountryDropdown.SelectMatDropdownOptionByText("United States");
        }
    }
}
