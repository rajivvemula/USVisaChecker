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
        public string RelatedExistingClaim = "";
        public string PoliceInvolved = "";
        public string FireInvolved = "";
        public int ClaimID = 0;

        [When(@"user selects '(.*)' this occurrence related to an existing claim")]
        public void WhenUserSelectsThisOccurrenceRelatedToAnExistingClaim(string answer)
        {
            switch (answer.ToUpper())
            {
                case "YES":
                    Occurrence.relatedToExistingClaimDropdown.SelectMatDropdownOptionByIndex(0, out string relatedtoExistingClaim);
                    RelatedExistingClaim = relatedtoExistingClaim;
                    Log.Info($"Expected: {nameof(RelatedExistingClaim)}={RelatedExistingClaim}");
                    break;
                case "NO":
                    Occurrence.relatedToExistingClaimDropdown.SelectMatDropdownOptionByIndex(1, out string NOTrelatedtoExistingClaim);
                    RelatedExistingClaim = NOTrelatedtoExistingClaim;
                    Log.Info($"Expected: {nameof(RelatedExistingClaim)}={RelatedExistingClaim}");
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
        }

        [When(@"user enters loss date and time")]
        public void WhenUserEntersLossDateAndTime()
        {
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
            Shared.ScrollIntoView("Cancel");
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
                case "YES":
                    Occurrence.policeInvolvedDropdown.SelectMatDropdownOptionByIndex(0, out string WerepoliceInvolved);
                    Occurrence.policeDepartmentNameField.setText("Test Police Department");
                    Occurrence.policeReportNumberField.setText("987");
                    PoliceInvolved = WerepoliceInvolved;
                    Log.Info($"Expected: {nameof(PoliceInvolved)}={PoliceInvolved}");
                    break;
                case "NO":
                    Occurrence.policeInvolvedDropdown.SelectMatDropdownOptionByIndex(1, out string policeNOTInvolved);
                    PoliceInvolved = policeNOTInvolved;
                    Log.Info($"Expected: {nameof(PoliceInvolved)}={PoliceInvolved}");
                    break;
                default:
                    Log.Info($"Related to an existing claim answer" + policeInvolved + "not found.");
                    throw new Exception("Related to an existing claim answer" + policeInvolved + "not found.");
            }
        }

        [When(@"user enters fire involved info - '(.*)'")]
        public void WhenUserEntersFireInvolvedInfo_(string fireInvolved)
        {
            switch (fireInvolved.ToUpper())
            {
                case "YES":
                    Occurrence.fireInvolvedDropdown.SelectMatDropdownOptionByIndex(0, out string wereFireInvolved);
                    Occurrence.fireDepartmentNameField.setText("Test Fire Department");
                    Occurrence.fireReportNumberField.setText("123");
                    FireInvolved = wereFireInvolved;
                    Log.Info($"Expected: {nameof(FireInvolved)}={FireInvolved}");
                    break;
                case "NO":
                    Occurrence.fireInvolvedDropdown.SelectMatDropdownOptionByIndex(1, out string fireNOTInvolved);
                    FireInvolved = fireNOTInvolved;
                    Log.Info($"Expected: {nameof(FireInvolved)}={FireInvolved}");
                    break;
                default:
                    Log.Info($"Related to an existing claim answer" + fireInvolved + "not found.");
                    throw new Exception("Related to an existing claim answer" + fireInvolved + "not found.");
            }
        }

        [Then(@"user asserts for Occurence save")]
        public void ThenUserAssertsForOccurenceSave()
        {
            var toastMessage = Occurrence.toastrMessage.GetInnerText();
            Assert.TextContains(toastMessage, "was successfully saved.");
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
