using System;
using TechTalk.SpecFlow;
using System;
using TechTalk.SpecFlow;
using ApolloQA.Pages;
using ApolloQA.Components;
using ApolloQA.Source.Driver;
using System.Linq;
using ApolloQA.Source.Helpers;

namespace ApolloQA.StepDefinition
{
    [Binding]
    public class PolicyCancelandReinstatementSteps
    {
        public static Data.Entity.Policy _pol;
        public static Data.Entity.Policy _polCan;
        [When(@"User Navigates to Policy latest")]
        public void WhenUserNavigatesToPolicyLatest()
        {
            //Get Policy Number
            _pol = Data.Entity.Policy.GetLatestPolicy();
            long policyNumber = _pol.Id;

            UserActions.Navigate($"/policy/{policyNumber}/cancellation");

        }


        [When(@"User Navigates to Policy Cancelled")]
        public void WhenUserNavigatesToPolicyCancelled()
        {
            //Get Policy Number
            _polCan = Data.Entity.Policy.GetLatestCancelledPolicy();
            long policyNumberCan = _polCan.Id;

            UserActions.Navigate($"/policy/{policyNumberCan}/reinstatement");
        }


        [Then(@"User enters ""(.*)"" and ""(.*)"" with an effective date of tommorrow")]
        public void ThenUserEntersAndWithAnEffectiveDateOfTommorrow(string iniBy, string reason)
        {
            Dropdown dropdown = new Dropdown("Initiated By");
            dropdown.SetValue(iniBy);
            Dropdown dropdown2 = new Dropdown("Reason");
            dropdown2.SetValue(reason);

            Shared.GetInputField("Effective Date").setText(DateTime.Now.AddDays(60).ToString("MM/dd/yyyy"));
        }


        [Then(@"User Enters Reason with an effective date of tommorrow")]
        public void ThenUserEntersReasonWithAnEffectiveDateOfTommorrow()
        {

            Shared.GetInputField("Reason").setText("Test");
            Shared.GetInputField("Effective Date").setText(DateTime.Now.AddDays(1).ToString("MM/dd/yyyy"));
        }

    }
}
