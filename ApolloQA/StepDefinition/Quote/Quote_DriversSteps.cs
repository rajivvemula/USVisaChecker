using ApolloQA.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace ApolloQA.StepDefinition.Quote
{
    [Binding]
    public class Quote_DriversSteps
    {

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
    }
}
