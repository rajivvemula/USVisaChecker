using ApolloQA.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace ApolloQA.StepDefinition
{
    [Binding]
    public sealed class apolloClaimFNOLSteps
    {
        public IWebDriver driver;

        apolloClaimFNOLSteps(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        private string Loss = DateTime.Today.AddDays(-1).ToShortDateString();
        private string Time = "02:04PM";
        public string ReceivedNotice = "";
        public string PolicyNumber = "";
        public string ReportedByPhoneType = "";
        public string ClaimantPhoneType = "";
        public string StreetAddress = "";
        public int ClaimID = 0;

        [When(@"user selects '(.*)' this occurrence related to an existing claim")]
        public void WhenUserSelectsThisOccurrenceRelatedToAnExistingClaim(string answer)
        {
            switch (answer.ToUpper())
            {
                case "YES":
                    Occurrence.relatedToExistingClaimDropdown.SelectMatDropdownOptionByText("Yes");
                    break;
                case "NO":
                    Occurrence.relatedToExistingClaimDropdown.SelectMatDropdownOptionByText("No");
                    break;
                default:
                    Log.Info($"Related to an existing claim answer" + answer + "not found.");
                    throw new Exception("Related to an existing claim answer" + answer + "not found.");
            }
        }

        [When(@"user enters occurrence information for Policy")]
        public void WhenUserEntersOccurrenceInformationForPolicy()
        {
            Occurrence.policyNumberField.setText("101"); // generic Text to initiate the list to choose from
            Occurrence.policyNumberField.SelectMatDropdownOptionByIndex(0, out string selectionPolicyNumber);
            PolicyNumber = selectionPolicyNumber;
            Log.Info($"Expected: {nameof(PolicyNumber)}={PolicyNumber}");
            Occurrence.dateOfLossField.setText(Loss);
            Occurrence.timeOFLossField.setText(Time);
        }

        [When(@"user enters Location information")]
        public void WhenUserEntersLocationInformation()
        {
            Occurrence.LocationDescriptionInput.setText("Description of Location - Test!");
            Occurrence.AddressDropdown.SelectMatDropdownOptionByIndex(0, out string streetAddress);
            StreetAddress = streetAddress;
            Log.Info($"Expected: {nameof(StreetAddress)}={StreetAddress}");
            Occurrence.DescriptionOfLossInput.setText("Loss Description - Test!");
            Occurrence.CatastropheTypeDropdown.SelectMatDropdownOptionByText("None");
        }

        [When(@"user selects Location Information from dropdown")]
        public void WhenUserSelectsLocationInformationFromDropdown()
        {
            Occurrence.LocationDescriptionInput.setText("Description of Location - Test!");
            Occurrence.StreetAddressOneInput.setText("1900 W Field CT");
            Occurrence.StreetAddressTwoInput.setText("Apt 2");
            Occurrence.CityInput.setText("Lake Forrest");
            Occurrence.StateDropdown.SelectMatDropdownOptionByText(" IL ");
            Occurrence.ZipCodeInput.setText("60045");
            Occurrence.DescriptionOfLossInput.setText("Loss Description - Test!");
            Occurrence.CatastropheTypeDropdown.SelectMatDropdownOptionByText("None");
        }

        [When(@"user enters police involved info - '(.*)'")]
        public void WhenUserEntersPoliceInvolvedInfo_(string policeInvolved)
        {
            switch (policeInvolved.ToUpper())
            {
                case "NO":
                    Occurrence.policeInvolvedDropdown.SelectMatDropdownOptionByText("No");
                    break;
                case "YES":
                    Occurrence.policeInvolvedDropdown.SelectMatDropdownOptionByText("Yes");
                    Occurrence.policeDepartmentNameField.setText("TestPolice");
                    Occurrence.policeReportNumberField.setText("123");
                    break;
                default:
                    Log.Info($"Police involved question answer" + policeInvolved + "not found.");
                    throw new Exception("Police involved question answer" + policeInvolved + "not found.");
            }
        }

        [When(@"user enters fire involved info - '(.*)'")]
        public void WhenUserEntersFireInvolvedInfo_(string fireInvolved)
        {
            switch (fireInvolved.ToUpper())
            {
                case "NO":
                    Occurrence.fireInvolvedDropdown.SelectMatDropdownOptionByText("No");
                    break;
                case "YES":
                    Occurrence.fireInvolvedDropdown.SelectMatDropdownOptionByText("Yes");
                    Occurrence.fireDepartmentNameField.setText("TestFire");
                    Occurrence.fireReportNumberField.setText("123");
                    break;
                default:
                    Log.Info($"Police involved question answer" + fireInvolved + "not found.");
                    throw new Exception("Police involved question answer" + fireInvolved + "not found.");
            }
        }

        [Then(@"user asserts for Occurence save")]
        public void ThenUserAssertsForOccurenceSave()
        {
            var toastMessage = Occurrence.toastrMessage.GetInnerText();
            //Assert.TextContains(toastMessage, "was successfully saved.");
            this.ClaimID = int.Parse(string.Join("", toastMessage.Where(Char.IsDigit)));
            Log.Info($"Expected: Claim Saved. Result: " + toastMessage + "");
        }

        [Then(@"user asserts for Occurence cancel")]
        public void ThenUserAssertsForOccurenceCancel()
        {
            ClaimsFNOLGrid.managerDashboardButton.assertElementIsVisible();
            String URL = driver.Url;
            Assert.IsTrue(URL.EndsWith("/claims/fnol-dashboard"));
        }
    }
}
