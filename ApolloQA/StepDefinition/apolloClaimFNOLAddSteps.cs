using ApolloQA.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using TechTalk.SpecFlow;

namespace ApolloQA.StepDefinition
{
    [Binding]
    public sealed class apolloClaimFNOLAddSteps
    {
        public IWebDriver driver;

        apolloClaimFNOLAddSteps(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        private string Loss = DateTime.Today.AddDays(-1).ToShortDateString();
        private string Reported = DateTime.Today.ToShortDateString();
        private string Time = "02:04PM";
        public string ReceivedNotice = "";
        public string PolicyNumber = "";
        public string ReportedByPhoneType = "";
        public string ClaimantPhoneType = "";

        [Then(@"user verifies '(.*)' is not an option")]
        public void ThenUserVerifiesIsNotAnOption(string text)
        {
            Occurrence.howWasNoticeReceivedDropdown.SelectMatDropdownOptionByText(text);
            Occurrence.receivedByCarrierPigeonOption.assertElementIsVisible();
            //will need to be "assertElementNotVisible" when option is removed
        }

        [When(@"user enters occurrence information for Policy")]
        public void WhenUserEntersOccurrenceInformationForPolicy()
        {
            Occurrence.dateOfLossField.setText(Loss);
            Occurrence.timeOFLossField.setText(Time);
            Occurrence.howWasNoticeReceivedDropdown.SelectMatDropdownOptionByIndex(1, out string selectionNoticeReceived);
            ReceivedNotice = selectionNoticeReceived;
            Log.Info($"Expected: {nameof(ReceivedNotice)}={ReceivedNotice}");
            Occurrence.dateReportedField.setText(Reported);
            Occurrence.timeReportedField.setText(Time);
            Occurrence.policyNumberField.setText("101"); // generic Text to initiate the list to choose from
            Occurrence.policyNumberField.SelectMatDropdownOptionByIndex(0, out string selectionPolicyNumber);
            PolicyNumber = selectionPolicyNumber;
            Log.Info($"Expected: {nameof(PolicyNumber)}={PolicyNumber}");
        }

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

        [When(@"user enters Reported by contact information")]
        public void WhenUserEntersReportedByContactInformation()
        {
            Occurrence.reportedFirstNameField.setText("Reported");
            Occurrence.reportedMiddleNameField.setText("M");
            Occurrence.reportedLastNameField.setText("Test");
            Occurrence.reportedSuffixField.setText("111");
            Occurrence.reportedEmailField.setText("ReportedMTest@testemail.com");
            Occurrence.ReportedPhoneTypeDropdown.SelectMatDropdownOptionByIndex(1, out string ReportedByTypePhone);
            ReportedByPhoneType = ReportedByTypePhone;
            Log.Info($"Expected: {nameof(ReportedByPhoneType)}={ReportedByPhoneType}");
            Occurrence.reportedPhonenumberField.setText("4843020219");
            Occurrence.reportedPhoneExtensionField.setText("33");
        }

        [When(@"user enters catastrophe and claimant contact info")]
        public void WhenUserEntersCatastropheAndClaimantContactInfo()
        {
            Occurrence.casastropheDropdown.SelectMatDropdownOptionByText("Option 1");
            Occurrence.descriptionofLossField.setText("DescriptionOfLoss");
            Occurrence.claimantFirstNameField.setText("Reported2");
            Occurrence.claimantMiddleNameField.setText("T");
            Occurrence.claimantLastNameField.setText("Testing");
            Occurrence.claimantSuffixField.setText("2nd");
            Occurrence.claimantEmailField.setText("Reported2@Testing.com");
            Occurrence.claimantPhoneTypeDropdown.SelectMatDropdownOptionByIndex(1, out string claimantPhoneType);
            ClaimantPhoneType = claimantPhoneType;
            Log.Info($"Expected: {nameof(ClaimantPhoneType)}={claimantPhoneType}");
            Occurrence.claimantPhoneNumberField.setText("8790654050");
            Occurrence.claimantPhoneExtensionField.setText("891");
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

        [When(@"user clicks '(.*)' button to save/cancel occurrence")]
        public void WhenUserClicksButtonToSaveCancelOccurrence(string action)
        {
            switch (action.ToUpper())
            {
                case "CANCEL":
                    Occurrence.cancelButton.Click();
                    Occurrence.ContinueAnywayButton.Click();
                    ClaimsFNOLGrid.managerDashboardButton.assertElementIsVisible();
                    String URL = driver.Url;
                    Assert.IsTrue(URL.EndsWith("/claims/fnol-dashboard"));
                    break;
                case "SAVE":
                    Occurrence.saveButton.Click();
                    // Assert for Save
                    break;
                default:
                    Log.Info($"Police involved question answer" + action + "not found.");
                    throw new Exception("Police involved question answer" + action + "not found.");
            }
        }

    }
}
