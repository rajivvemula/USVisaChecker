using BiBerkLOB.Pages.Other.AutopayEnrollment;
using BiBerkLOB.Pages.Other.Claims;
using BiBerkLOB.Pages.PL;
using HitachiQA.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace BiBerkLOB.StepDefinition.General.Other.Claims
{

    [Binding]
    public sealed class ReportClaim_CA
    {
        [Then(@"user validates the CA Claim page elements")]
        public void ThenUserValidatesTheCAClaimPageElements()
        {
            //verifies URL is still on the correct environment
            General_SiteWide.AssertEnvironmentURL();
            AutomationHelper.ValidateElements(CA_ClaimsPage.CA_ClaimsPageElements);
        }

        [Then(@"user verifies the CA Claims page error messages")]
        public void ThenUserVerifiesTheCAClaimsPageErrorMessages()
        {
            AutomationHelper.WaitForLoading();
            CA_ClaimsPage.CASubmitClaimsButton.Click();
            AutomationHelper.ValidateElements(CA_ClaimsPage.CA_ClaimsPageErrorMessages);
        }

        [When(@"user fills out the CA Claims page with these values:")]
        public void WhenUserFillsOutTheCA_ClaimsPageWithTheseValues(Table table)
        {
            foreach (TableRow rowy in table.Rows)
            {
                var theQuestion = rowy["Question"];
                var theAnswer = rowy["Answer"];
                HandleCA_ClaimsPage(theQuestion, theAnswer);
            }
        }

        private void HandleCA_ClaimsPage(string theQuestion, string theAnswer)
        {
            switch (theQuestion)
            {
                case "Policy Number":
                    CA_ClaimsPage.PolicyNumberTextbox.SetText(theAnswer);
                    break;
                case "Business Name":
                    CA_ClaimsPage.BusinessNameTextbox.SetText(theAnswer);
                    break;
                case "First Name":
                    CA_ClaimsPage.FirstNameTextbox.SetText(theAnswer);
                    break;
                case "Last Name":
                    CA_ClaimsPage.LastNameTextbox.SetText(theAnswer);
                    break;
                case "Phone":
                    CA_ClaimsPage.PhoneTextbox.SetText(theAnswer);
                    break;
                case "How to Connect":
                    CA_ClaimsPage.HowToConnectTextbox.SetText(theAnswer);
                    break;
                case "Driver First Name":
                    CA_ClaimsPage.DriverFirstNameTxtbox.SetText(theAnswer);
                    break;
                case "Driver Last Name":
                    CA_ClaimsPage.DriverLastNameTxtbox.SetText(theAnswer);
                    break;
                case "Driver Address":
                    CA_ClaimsPage.DriverAddressTxtbox.SetText(theAnswer);
                    break;
                case "ZIP Code":
                    CA_ClaimsPage.DriverAddressZipCodeTxtbox.SetText(theAnswer);
                    break;
                case "City":
                    Thread.Sleep(1000);
                    CA_ClaimsPage.DriverAddressCityDD.AssertElementIsVisible();
                    if (!theAnswer.Equals(CA_ClaimsPage.DriverAddressCityDD.GetTextFieldValue()))
                    {
                        CA_ClaimsPage.DriverAddressCityDD.Click();
                        CA_ClaimsPage.DriverCityOption(theAnswer).Click();
                    }
                    break;
                case "Driver Phone":
                    CA_ClaimsPage.DriverPhoneTxtbox.SetText(theAnswer);
                    break;
                case "Date of Loss":
                    CA_ClaimsPage.DateOfLossInput.EnterResponse(theAnswer);
                    break;
                case "Location of Loss":
                    CA_ClaimsPage.LocationOfLossTxtbox.SetText(theAnswer);
                    break;
                case "Year":
                    CA_ClaimsPage.VehicleYearTxtbox.SetText(theAnswer);
                    break;
                case "Make":
                    Thread.Sleep(1000);
                    CA_ClaimsPage.VehicleMakeDD.AssertElementIsVisible();
                    CA_ClaimsPage.VehicleMakeDD.Click();
                    if (!theAnswer.Equals(CA_ClaimsPage.VehicleMakeDD.GetTextFieldValue()))
                    { 
                        CA_ClaimsPage.VehicleMakeDD.Click();
                        CA_ClaimsPage.VehicleMakeOption(theAnswer).Click();
                    }
                    break;
                case "Short Description":
                    CA_ClaimsPage.ShortDescripTextbox.SetText(theAnswer);
                    break;
            }
        }
    }
}