using ApolloQA.Pages;
using OpenQA.Selenium;
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
            Occurrence.howWasNoticeReceivedDropdown.SelectMatDropdownOptionByIndex(0, out string selectionNoticeReceived);
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
                    Occurrence.howWasNoticeReceivedDropdown.SelectMatDropdownOptionByText("Yes");
                    break;
                case "NO":
                    Occurrence.howWasNoticeReceivedDropdown.SelectMatDropdownOptionByText("No");
                    break;
            }
        }


        //BusinessInformation.businessKeywordField.SelectMatDropdownOptionByIndex(0, out string selectionKeyWord);
        //Keyword = selectionKeyWord;
        //    Log.Info($"Expected: {nameof(Keyword)}={Keyword}");

    }
}
