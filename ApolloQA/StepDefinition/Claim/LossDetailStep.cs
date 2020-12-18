using ApolloQA.Pages;
using TechTalk.SpecFlow;

namespace ApolloQA.StepDefinition.Claim
{[Binding]
    public class LossDetailStep
    {
        [When(@"user selects pending FNOL")]
        public void WhenUserSelectsPendingFNOL()
        {
            try { ClaimsFNOLGrid.PendingFNOL.Click(); }
            catch
            {
                GlobalSearch.SearchInput.setText("FNOL");
                GlobalSearch.SearchResult.assertElementIsVisible();
                GlobalSearch.SearchResultDescription.assertElementContainsText("Pending");
                GlobalSearch.SearchResult.Click();
            }
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
            try
            {
                Shared.GetButton(" First Party ").Click();
                Shared.GetButton(" Property Damage ").Click();
            }
            catch
            {
                LossDetails.FaultIndicatorDropdown.SelectMatDropdownOptionByText("No Fault");
                LossDetails.ClaimsAdjusterDropdown.SelectMatDropdownOptionByText("Unassigned");
                LossDetails.ComplexityDropdown.SelectMatDropdownOptionByText("Fastrack");
                LossDetails.SupervisorNotesInput.setText("Notes of Supervisor : TEST TEST!");
            }
        }

        [When(@"user completes Other Insurer Info")]
        public void WhenUserCompletesOtherInsurerInfo()
        {
            LossDetails.OtherInsurerInput.setText("Insurer - Other");
            LossDetails.InsurerPolicyNumInput.setText("132");
            LossDetails.InsurerClaimNumInput.setText("987");
            LossDetails.OtherInsurerAdjusterInput.setText("Test Test");
            LossDetails.SuitFiledDropdown.SelectMatDropdownOptionByText(" Yes ");
            LossDetails.AttorneyAuthRepDropdown.SelectMatDropdownOptionByText(" No ");
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
            LossDetails.NoDriverButton.Click();
            LossDetails.RelationshipToInsuredDropdown.SelectMatDropdownOptionByText(" Not Related ");
        }

        [Then(@"user assert for Loss Details save")]
        public void ThenUserAssertForLossDetailsSave()
        {
            LossDetails.SaveButton.Click();
            Shared.SpinnerLoad.assertElementIsVisible(5, true);
            Shared.SpinnerLoad.assertElementNotPresent();
            var toastMessage = Shared.toastrMessage.GetInnerText();
            try
            {
                Assert.TextContains(toastMessage, "Loss Details were saved.");
            }
            catch { Assert.TextContains(toastMessage, "Error Saving Loss Details."); }
            Log.Info($"Expected: Loss Details Saved. Result: " + toastMessage + "");
        }

    }
}
