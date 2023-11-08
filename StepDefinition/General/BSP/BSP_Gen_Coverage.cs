using BiBerkLOB.Pages.Other.BSP;
using BiBerkLOB.Pages.WC;
using BiBerkLOB.StepDefinition.General.WC;
using HitachiQA.Driver;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace BiBerkLOB.StepDefinition.General.BSP
{
    [Binding]
    public sealed class General_BSP_Coverage
    {
        [Then(@"user verifies appearance of the Policy Page")]
        public void ThenUserVerifiesAppearanceOfTheBSP_PolicyPage()
        {
            BSP_PolicyPage.LoadingRequirements.Assert();
        }
        [Then(@"user verifies appearance of the Billing Tab")]
        public void ThenUserVerifiesAppearanceOfTheBillingTab()
        {
            BSP_PolicyPage.BillingTab.Click();
            BSP_PolicyPage.PaymentMethodSelect.AssertElementIsVisible();
            BSP_PolicyPage.CurrentPaymentAmount.AssertElementIsVisible();
            BSP_PolicyPage.PaymentBalanceAmount.AssertElementIsVisible();
            BSP_PolicyPage.PaymentDate.AssertElementIsVisible();
            BSP_PolicyPage.PaymentDateInput.AssertElementIsVisible();
            BSP_PolicyPage.AccountTypeSelect.AssertElementIsVisible();
            BSP_PolicyPage.AccountNumberInput.AssertElementIsVisible();
            BSP_PolicyPage.RoutingNumberInput.AssertElementIsVisible();
            BSP_PolicyPage.EmailSelect.AssertElementIsVisible();
            BSP_PolicyPage.AutopayTooltipIcon.AssertElementIsVisible();
            BSP_PolicyPage.AutopayTooltipButton.AssertElementIsVisible();
            BSP_PolicyPage.AutopayLabel.AssertElementIsVisible();
            BSP_PolicyPage.AutopayInput.AssertElementIsVisible();
            BSP_PolicyPage.SubmitButton.AssertElementIsVisible();
            BSP_PolicyPage.PremiumText.AssertElementIsVisible();
            BSP_PolicyPage.StateFees.AssertElementIsVisible();
            BSP_PolicyPage.BillingFees.AssertElementIsVisible();
            BSP_PolicyPage.SummaryStateFees.AssertElementIsVisible();
            BSP_PolicyPage.PaymentsText.AssertElementIsVisible();
            BSP_PolicyPage.AuditAmount.AssertElementIsVisible();
            BSP_PolicyPage.BalanceText.AssertElementIsVisible();
            BSP_PolicyPage.DirectDraftText.AssertElementIsVisible();
            BSP_PolicyPage.StatusCollectionsText.AssertElementIsVisible();
            BSP_PolicyPage.ForceStatement.AssertElementIsVisible();
            BSP_PolicyPage.ForceStatement.AssertElementIsVisible();
            BSP_PolicyPage.FinalLapseText.AssertElementIsVisible();
            BSP_PolicyPage.WrittenOffText.AssertElementIsVisible();
            BSP_PolicyPage.DNOCText.AssertElementIsVisible();
            BSP_PolicyPage.CancellationReasonText.AssertElementIsVisible();
            BSP_PolicyPage.PendingCancellationText.AssertElementIsVisible();
            BSP_PolicyPage.EstimateAmountText.AssertElementIsVisible();
            BSP_PolicyPage.ActualAmountText.AssertElementIsVisible();
            BSP_PolicyPage.FinanceCompanyText.AssertElementIsVisible();
        }

        [Then(@"user verifies appearance of the PL Coverage Tab")]
        public void ThenUserVerifiesAppearanceOfThePLCoverageTab()
        {
            BSP_PolicyPage.PolicyMainTitleText.AssertElementIsVisible();
            BSP_PolicyPage.PolicyStartDate.AssertElementIsVisible();
            BSP_PolicyPage.PolicyCoveragesTerm.AssertElementIsVisible();
            BSP_PolicyPage.PolicyInfoSectionTitle.AssertElementIsVisible();
            BSP_PolicyPage.PolicyGeneralInfo.AssertElementIsVisible();
            BSP_PolicyPage.PolicyInfoName.AssertElementIsVisible();
            BSP_PolicyPage.PolicyInfoHeading.AssertElementIsVisible();
            BSP_PolicyPage.PolicyInfoBullets.AssertElementIsVisible();
            BSP_PolicyPage.PolicyInfoHeading01.AssertElementIsVisible();
            BSP_PolicyPage.PolicyInfoBullets01.AssertElementIsVisible();
            BSP_PolicyPage.PolicyInfoRetroText.AssertElementIsVisible();
            BSP_PolicyPage.PolicyInfoConditionText.AssertElementIsVisible();
            BSP_PolicyPage.PolicyBenefitGeneralInfo.AssertElementIsVisible();
            BSP_PolicyPage.PolicyBenefitInfoName.AssertElementIsVisible();
            BSP_PolicyPage.PolicyBenefitInfoBullets.AssertElementIsVisible();
        }
    }
}

