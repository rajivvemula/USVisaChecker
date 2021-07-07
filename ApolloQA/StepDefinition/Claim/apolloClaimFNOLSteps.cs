using ApolloQA.Pages;
using OpenQA.Selenium;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

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
        public string ClaimAdjuster = "";
        public string VehicleOnPolicy = "";
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
            var policy = Data.Entity.Tether.GetLatestTether().CurrentPolicy;
            if (policy.TimeFrom.CompareTo(DateTime.Today) > -2)
            {
                policy.TimeFrom =policy.TimeFrom.AddDays(-2);
                policy.TimeTo = policy.TimeTo.AddDays(-2);
            }
            Occurrence.policyNumberField.setText($"{policy.PolicyNumber}");
            GlobalSearch.SearchResultLabel().assertElementContainsText($"{policy.PolicyNumber}");
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
            Occurrence.StreetAddressOneInput.setText("1900 W Field CT");
            Occurrence.StreetAddressTwoInput.setText("Apt 2");
            Occurrence.CityInput.setText("Lake Forrest");
            Occurrence.StateDropdown.SelectMatDropdownOptionByText("IL");
            Occurrence.ZipCodeInput.setText("60045");
            Occurrence.DescriptionOfLossInput.setText("Loss Description - Test!");
            Occurrence.CatastropheTypeDropdown.SelectMatDropdownOptionByText("None");
        }

        [When(@"user selects Location Information from dropdown")]
        public void WhenUserSelectsLocationInformationFromDropdown()
        {
            Occurrence.LocationDescriptionInput.setText("Description of Location - Test!");
            Occurrence.AddressDropdown.SelectMatDropdownOptionByIndex(0, out string streetAddress);
            StreetAddress = streetAddress;
            Log.Info($"Expected: {nameof(StreetAddress)}={StreetAddress}");
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
            try { Assert.TextContains(toastMessage, "was successfully saved.");
                this.ClaimID = int.Parse(string.Join("", toastMessage.Where(Char.IsDigit)));
            }
            catch { Assert.TextContains(toastMessage, "Error Saving FNOL."); }
            Log.Info($"Expected: Claim Saved. Result: " + toastMessage + "");
        }

        [Then(@"user asserts for Occurence cancel")]
        public void ThenUserAssertsForOccurenceCancel()
        {
            ClaimsFNOLGrid.managerDashboardButton.assertElementIsVisible();
            String URL = driver.Url;
            Assert.IsTrue(URL.EndsWith("/claims/fnol-dashboard"));
        }

        [When(@"user enters 255 characters in Location description field")]
        public void WhenUser255EntersCharactersInLocationDescriptionField()
        {
            Occurrence.LocationDescriptionInput.setText("Description of Location - Test! Description of Location - Test! Description of Location - Test! Description of Location - Test! Description of Location - Test! Description of Location - Test! Description of Location - Test! Description of Location - Te255");
            var charCount = Occurrence.LocationDescriptionInput.getTextFieldText().Length;
            Assert.SoftAreEqual(charCount, "255");
        }

        [Then(@"user verifies 256 characters in field is not accepted")]
        public void ThenUserVerifiesCharactersInFieldIsNotAccepted()
        {
            Occurrence.LocationDescriptionInput.clearTextField();
            Occurrence.LocationDescriptionInput.setText("Description of Location - Test! Description of Location - Test! Description of Location - Test! Description of Location - Test! Description of Location - Test! Description of Location - Test! Description of Location - Test! Description of Location - Tes256");
            var charCount = Occurrence.LocationDescriptionInput.getTextFieldText().Length;
            Assert.SoftAreEqual(charCount, "255");
        }

        [When(@"user verifies '(.*)' button")]
        public void WhenUserVerifiesButton(string addReceipt)
        {
            Shared.GetButton(addReceipt).assertElementContainsText("Add Receipt Information");
        }

        [Then(@"user completes receipt informaiton")]
        public void ThenUserCompletesReceiptInformaiton()
        {
            ReceiptInformation.FirstPartyButton.Click();
            ReceiptInformation.PropertyDamageButton.Click();
            ReceiptInformation.HowReceivedDropdown.SelectMatDropdownOptionByText("Phone");
            ReceiptInformation.FirstNameInput.setText("John");
            ReceiptInformation.LastNameInput.setText("Smith");
            ReceiptInformation.PhoneNumberInput.setText("8489698404");
            ReceiptInformation.EmailInput.setText("jsmith@email.com");
            ReceiptInformation.CityInput.setText("Chicago");
            ReceiptInformation.StateDropdown.SelectMatDropdownOptionByText("IL");
            ReceiptInformation.ZipInput.setText("61614");
            ReceiptInformation.SameAsReportedButton.Click();
            ReceiptInformation.SameAsPrimaryButton.Click();
        }

        [Then(@"user completes Loss Details information")]
        public void ThenUserCompletesLossDetailsInformation()
        {
            LossDetails.CauseOfLossDropdown.SelectMatDropdownOptionByText("Hail");
            LossDetails.FaultIndicatorDropdown.SelectMatDropdownOptionByText("No Fault");
            LossDetails.ClaimsAdjusterDropdown.SelectMatDropdownOptionByIndex(1, out string claimAdjuster);
            ClaimAdjuster = claimAdjuster;
            Log.Info($"Expected: {nameof(ClaimAdjuster)}={ClaimAdjuster}");
            LossDetails.InsuredButton.Click();
            LossDetails.VehicleOnPolicyButton.Click();
            LossDetails.SelectVehicleOnPolicyDropdown.SelectMatDropdownOptionByIndex(0, out string vehicleOnPolicy);
            VehicleOnPolicy = vehicleOnPolicy;
            Log.Info($"Expected: {nameof(VehicleOnPolicy)}={VehicleOnPolicy}");
            LossDetails.NoDriverButton.Click();
        }

        [When(@"user selects pending claim to activate")]
        public void WhenUserSelectsPendingClaimToActivate()
        {
            PendingClaim.PendingClaimToActivate.Click();  
        }

        [Then(@"claim should be successfully activated")]
        public void ThenClaimShouldBeSuccessfullyActivated()
        {
            var toastMessage = Occurrence.toastrMessage.GetInnerText();
            Assert.SoftAreEqual(toastMessage, "Claim has been activated");
            this.ClaimID = int.Parse(string.Join("", toastMessage.Where(Char.IsDigit)));
            Log.Info($"Expected: Claim Saved. Result: " + toastMessage + "");
        }

        [When(@"user validates address dropdwon")]
        public void WhenUserValidatesAddressDropdwon()
        {
            Occurrence.AddressDropdown.assertElementIsVisible();
            Occurrence.AddressDropdown.Click();
            Occurrence.AddressOption.assertElementIsVisible();            
        }

        [Then(@"user validates Address fields")]
        public void ThenUserValidatesAddressFields()
        {
            Occurrence.StreetAddressOneInput.assertElementIsVisible();
            Occurrence.StreetAddressTwoInput.assertElementIsVisible();
            Occurrence.CityInput.assertElementIsVisible();
            Occurrence.StateDropdown.assertElementIsVisible();
            Occurrence.ZipCodeInput.assertElementIsVisible();
        }

        [When(@"user selects open claim")]
        public void WhenUserSelectsOpenClaim()
        {
            ClaimsFNOLGrid.OpenClaim.assertElementIsVisible(60);
            ClaimsFNOLGrid.OpenClaim.Click();
        }

        [When(@"user selects (.*) button")]
        public void WhenUserSelectsButton(string button)
        {
            switch (button.ToLower())
            {
                case "recovery":
                    Shared.GetButton("Continue anyway").Click(3, true);
                    Shared.GetLeftSideTab("Recovery").Click();
                    break;
                case "salvage":
                    Shared.GetButton("Continue anyway").Click(3, true);
                    ClaimsFNOLGrid.SalvageButton.Click();
                    break;
                case "subrogation":
                    Shared.GetButton("Continue anyway").Click(3, true);
                    ClaimsFNOLGrid.SubrogationButton.Click();
                    break;
            }
        }

        [Then(@"claim header is visible on '(.*)'")]
        public void ThenClaimHeaderIsVisibleOnFor(string page)
        {
            Shared.GetLeftSideTab(page).Click();
            Shared.GetButton("Continue anyway").Click(3, true);
            ClaimsFNOLGrid.ClaimHeader.assertElementIsVisible();
        }

        [Then(@"user asserts of claims header")]
        public void ThenUserAssertsOfClaimsHeader()
        {
            ClaimsFNOLGrid.ClaimHeader.assertElementIsVisible();
        }
    }
}
