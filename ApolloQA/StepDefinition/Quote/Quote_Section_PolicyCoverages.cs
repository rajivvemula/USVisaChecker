using System;
using System.Collections.Generic;
using System.Text;
using ApolloQA.Pages;
using ApolloQA.StepDefinition;
using TechTalk.SpecFlow;

namespace ApolloQA.StepDefinition.Quote
{
    [Binding]
    public class Quote_Section_PolicyCoverages
    {
        [When(@"user select Policy Coverages according to Keyword")]
        public void WhenUserSelectPolicyCoveragesAccordingToKeyword()
        {
            switch (SharedSteps.BusinessKeyword)
            {
                case "Trucking: Long Distance Hauling: more than 300 miles":
                    new SharedSteps().WhenUserSelectsCoverageWithDeductibleOf("Bodily Injury Property Damage (BIPD)", "Combined Single Limit", "$2,000,000");
                    new SharedSteps().WhenUserSelectsCoverageWithDeductibleOf("Medical Payments", "Combined Single Limit", "$2,000");
                    Shared.GetCoverageCheckbox("Rental Reimbursement").TryClick();
                    Shared.GetCoverageCheckbox("Cargo Coverage").TryClick();
                    Shared.GetCoverageCheckbox("Trailer Interchange").TryClick();
                    break;
                case "Towing Services":
                    new SharedSteps().WhenUserSelectsCoverageWithDeductibleOf("Bodily Injury Property Damage (BIPD)", "Combined Single Limit", "$2,000,000");
                    new SharedSteps().WhenUserSelectsCoverageWithDeductibleOf("Medical Payments", "Combined Single Limit", "$2,000");
                    Shared.GetCoverageCheckbox("Rental Reimbursement").TryClick();
                    Shared.GetCoverageCheckbox("In-Tow").TryClick();
                    Shared.GetCoverageCheckbox("Trailer Interchange").TryClick();
                    break;
                case "Limousine Company":
                    new SharedSteps().WhenUserSelectsCoverageWithDeductibleOf("Bodily Injury Property Damage (BIPD)", "Combined Single Limit", "$2,000,000");
                    new SharedSteps().WhenUserSelectsCoverageWithDeductibleOf("Medical Payments", "Combined Single Limit", "$2,000");
                    Shared.GetCoverageCheckbox("Rental Reimbursement").TryClick();
                    Shared.GetCoverageCheckbox("Trailer Interchange").TryClick();
                    break;
            }
        }
    }
}
