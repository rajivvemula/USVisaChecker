using BiBerkLOB.Pages.CommAuto;
using HitachiQA.Driver;
using HitachiQA.Helpers;
using TechTalk.SpecFlow;

namespace BiBerkLOB.StepDefinition.General.CommAuto;

[Binding]
public sealed class CA_Gen_ProposalEmailModal
{
    private readonly CASummaryObject _caSummaryObject;

    public CA_Gen_ProposalEmailModal(CASummaryObject caSummaryObject)
    {
        _caSummaryObject = caSummaryObject;
    }

    [Then(@"user verifies proposal email modal")]
    public void ThenVerifiesProposalEmailModal(Table table)
    {
        CA_QuoteSummaryPage.EmailPolicyQuoteCTA.Click();
        CA_ProposalEmailModal.QuoteIDTitle.AssertElementIsVisible();
        CA_ProposalEmailModal.QuoteIDTitle.AssertElementContainsText(_caSummaryObject.QuoteID);
        CA_ProposalEmailModal.ProposalClose.Click();

        CA_QuoteSummaryPage.EmailPolicyQuoteCTA.Click();
        CA_ProposalEmailModal.QuoteIDTitle.AssertElementIsVisible();
        CA_ProposalEmailModal.ProposalModalHeader.AssertElementIsVisible();
        CA_ProposalEmailModal.ProposalModalTitle.AssertElementIsVisible();

        CA_ProposalEmailModal.ProposalModalPaymentPaymentTitle.AssertElementIsVisible();
        //check that the amount you pay today is what is expected from the Quote page
        CA_ProposalEmailModal.ProposalModalPaymentPaymentTitle.AssertElementContainsText(_caSummaryObject.AmountYouPayToday);

        CA_ProposalEmailModal.ProposalModalPaymentPaymentAmt.AssertElementIsVisible();
        //check that it either says monthly or yearly
        CA_ProposalEmailModal.ProposalModalPaymentPaymentAmt.AssertElementContainsText(_caSummaryObject.QuoteChooseYearlyOrMonthly);


        /*
         * Iterate through the table values and call a switch function to check the table values
         */
        foreach (TableRow rowy in table.Rows)
        {
            var theQuestion = rowy["Question"];
            var theAnswer = rowy["Answer"];

            HandleTableForSelectedCoverages(theQuestion, theAnswer);
        }

        CA_ProposalEmailModal.ProposalModalEmailQST.AssertElementIsVisible();
        CA_ProposalEmailModal.ProposalModalEmailTxtbox.AssertElementIsVisible();
        CA_ProposalEmailModal.EmailPolicyCTA.Click();

        //CA_ProposalEmailModal.EmailPolicySuccessToast.AssertElementIsVisible();
        //CA_ProposalEmailModal.EmailPolicySuccessToast.AssertElementNotPresent();
    }

    public void HandleTableForSelectedCoverages(string tableQuestion, string tableAnswer)
    {
        switch (tableQuestion)
        {
            case "Bodily Injury and Property Damage Liability":
                AssertCorrectIcon(tableAnswer, CA_ProposalEmailModal.BIaPDLCheckIcon, CA_ProposalEmailModal.BIaPDLCacnelIcon);
                CA_ProposalEmailModal.BIaPDLLabel.AssertElementIsVisible();
                break;
            case "Uninsured/Underinsured Motorist":
                AssertCorrectIcon(tableAnswer, CA_ProposalEmailModal.UninsuredUnderinsuredCheckIcon, CA_ProposalEmailModal.UninsuredUnderinsuredCancelIcon);
                CA_ProposalEmailModal.UninsuredUnderinsuredLabel.AssertElementIsVisible();
                break;
            case "Comp/Collision (One Vehicle)":
                AssertCorrectIcon(tableAnswer, CA_ProposalEmailModal.CompCollisionCheckIcon, CA_ProposalEmailModal.CompCollisionCancelIcon);
                CA_ProposalEmailModal.CompCollisionLabel.AssertElementIsVisible();
                break;
            case "Medical Payments":
                AssertCorrectIcon(tableAnswer, CA_ProposalEmailModal.MedicalPaymentsCheckIcon, CA_ProposalEmailModal.MedicalPaymentsCancelIcon);
                CA_ProposalEmailModal.MedicalPaymentsLabel.AssertElementIsVisible();
                break;
            case "Rental Reimbursement":
                AssertCorrectIcon(tableAnswer, CA_ProposalEmailModal.RentalReimbursementCheckIcon, CA_ProposalEmailModal.RentalReimbursementCancelIcon);
                CA_ProposalEmailModal.RentalReimbursementLabel.AssertElementIsVisible();
                break;
            case "Cargo Liability":
                AssertCorrectIcon(tableAnswer, CA_ProposalEmailModal.CargoLiabilityCheckIcon, CA_ProposalEmailModal.CargoLiabilityCancelIcon);
                CA_ProposalEmailModal.CargoLiabilityLabel.AssertElementIsVisible();
                break;
            case "Physical Damage coverage(One Vehicle)":
                AssertCorrectIcon(tableAnswer, CA_ProposalEmailModal.PhysicalDamageCheckIcon, CA_ProposalEmailModal.PhysicalDamageCancelIcon);
                CA_ProposalEmailModal.PhysicalDamageLabel.AssertElementIsVisible();
                break;
            default:
                break;
        }
    }

    private void AssertCorrectIcon(string yesOrNo, Element checkIcon, Element xIcon)
    {
        if (Functions.ConvertYesOrNoStringToBool(yesOrNo))
        {
            checkIcon.AssertElementIsVisible();
        }
        else
        {
            xIcon.AssertElementIsVisible();
        }
    }
}