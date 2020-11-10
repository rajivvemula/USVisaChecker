using System;
using System.Collections.Generic;
using System.Text;
using ApolloQA.Pages;
using ApolloQA.Source.Driver;
using TechTalk.SpecFlow;

namespace ApolloQA.StepDefinition.Claim
{[Binding]
    public class LossDetailStep
    {
        [When(@"user selects pending FNOL")]
        public void WhenUserSelectsPendingFNOL()
        {
            ClaimsFNOLGrid.PendingFNOL.Click();
        }

        [When(@"user navigates to Loss Details")]
        public void WhenUserNavigatesToLossDetails()
        {
            LossDetails.LossDetailsButton.WaitUntilClickable();
            LossDetails.LossDetailsButton.Click();
        }

        [When(@"user completes loss details section")]
        public void WhenUserCompletesLossDetailsSection()
        {
            Shared.GetButton(" First Party ").Click();
            Shared.GetButton(" Property Damage ").Click();
            LossDetails.FaultIndicatorDropdown.SelectMatDropdownOptionByText(" No Fault ");
            LossDetails.ClaimsAdjusterDropdown.SelectMatDropdownOptionByText("ApolloTestUserG102");
            LossDetails.ComplexityDropdown.SelectMatDropdownOptionByText(" Fastrack ");
            LossDetails.SupervisorNotesInput.setText("Notes of Supervisor : TEST TEST!");
        }

        [When(@"user completes Other Insurer Info")]
        public void WhenUserCompletesOtherInsurerInfo()
        {
            LossDetails.OtherInsurerInput.setText("Insurer - Other");
            LossDetails.InsurerPolicyNumInput.setText("132");
            LossDetails.InsurerClaimNumInput.setText("987");
            LossDetails.OtherInsurerAdjusterInput.setText("Test Test");
            LossDetails.SuitFiledDropdown.SelectMatDropdownOptionByText(" Yes ");
            //LossDetails.AttorneyAuthRepDropdown.SelectMatDropdownOptionByText(" No ");
            LossDetails.ReportOnlyDropdown.SelectMatDropdownOptionByText(" Yes ");
        }

        [When(@"user completes Vehicle damage section")]
        public void WhenUserCompletesVehicleDamageSection()
        {
            LossDetails.VehicleDispositionDropdown.SelectMatDropdownOptionByText("Damaged ");
            LossDetails.DamageSeenInput.setText("Front Bumper");
            LossDetails.EstimateOfLossInput.setText("2,000");
            LossDetails.SubrogationReferralDropdown.SelectMatDropdownOptionByText(" No ");
        }

        [When(@"user completes additional information section")]
        public void WhenUserCompletesAdditionalInformationSection()
        {
            LossDetails.InsuredButton.Click();
            LossDetails.VehicleNotOnPolicyButton.Click();
            
            LossDetails.RelationshipToInsuredDropdown.SelectMatDropdownOptionByText("");
        }

        [Then(@"user assert for Loss Details save")]
        public void ThenUserAssertForLossDetailsSave()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
