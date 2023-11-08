using BiBerkLOB.Source.Driver;
using HitachiQA.Driver;
using OpenQA.Selenium;

namespace BiBerkLOB.Pages.Other.BSP
{
    public sealed class BSP_PolicyPage
    {
        public static LoadingRequirements LoadingRequirements => new LoadingRequirements(PolicyStatus, CoverageTab, BillingTab, ConversationsTab, DocumentsTab, UnderwrittingTab);
        // Header
        public static Element PolicyStatus => new Element(By.XPath("//p[@data-qa='policy-status']"));

        // Tabs
        public static Element BillingTab => new Element(By.XPath("//li[@data-qa='billing-tab']"));
        public static Element CertificatesTab => new Element(By.XPath("//li[@data-qa='certificates-tab']"));
        public static Element ContactsTab => new Element(By.XPath("//li[@data-qa='contacts-tab']"));
        public static Element ConversationsTab => new Element(By.XPath("//li[@data-qa='conversations-tab']"));
        public static Element CoverageTab => new Element(By.XPath("//li[@data-qa='coverage-tab']"));
        public static Element DocumentsTab => new Element(By.XPath("//li[@data-qa='documents-tab']"));
        public static Element UnderwrittingTab => new Element(By.XPath("//li[@data-qa='underwriting-tab']"));
        //BillingTab Elements
        public static Element PaymentMethodSelect => new Element(By.XPath("//bb-options[@data-qa='payment-method-select']"));
        public static Element CurrentPaymentAmount => new Element(By.XPath("//input[@data-qa='dd-payment-current-amount-input']"));
        public static Element PaymentBalanceAmount => new Element(By.XPath("//input[@data-qa='dd-payment-balance-amount-input']"));
        public static Element PaymentDate => new Element(By.XPath("//bb-date[@data-qa='dd-payment-date-input']"));
        public static Element PaymentDateInput => new Element(By.XPath("//input[@data-qa='dd-payment-date-input_input']"));
        public static Element AccountTypeSelect => new Element(By.XPath("//bb-select[@data-qa='dd-account-type-select']"));
        public static Element AccountNumberInput => new Element(By.XPath("//input[@data-qa='dd-account-number-input']"));
        public static Element RoutingNumberInput => new Element(By.XPath("//input[@data-qa='dd-routing-number-input']"));
        public static Element EmailSelect => new Element(By.XPath("//bb-select[@data-qa='dd-email-select']"));
        public static Element AutopayTooltipIcon => new Element(By.XPath("//bb-tooltip[@data-qa='undefined']"));
        public static Element AutopayTooltipButton => new Element(By.XPath("//button[@data-qa='undefined_tooltip']"));
        public static Element AutopayLabel => new Element(By.XPath("//label[@data-qa='dd-auto-pay-label']"));
        public static Element AutopayInput => new Element(By.XPath("//input[@data-qa='dd-autopay-input']"));
        public static Element SubmitButton => new Element(By.XPath("//button[@data-qa='dd-payment-submit-button']"));
        public static Element PremiumText => new Element(By.XPath("//p[@data-qa='summary-premium-text']"));
        public static Element StateFees => new Element(By.XPath("//p[@data-qa='summary-state-fees-text']"));
        public static Element BillingFees => new Element(By.XPath("//p[@data-qa='summary-billing-fees-text']"));
        public static Element SummaryStateFees => new Element(By.XPath("//p[@data-qa='summary-state-fees-text']"));
        public static Element PaymentsText => new Element(By.XPath("//p[@data-qa='summary-payments-text']"));
        public static Element AuditAmount => new Element(By.XPath("//p[@data-qa='summary-audit-amount-text']"));
        public static Element BalanceText => new Element(By.XPath("//p[@data-qa='summary-balance-text']"));
        public static Element DirectDraftText => new Element(By.XPath("//p[@data-qa='billing-status-direct-draft-text']"));
        public static Element StatusCollectionsText => new Element(By.XPath("//p[@data-qa='billing-status-in-collections-text']"));
        public static Element ForceStatement => new Element(By.XPath("//p[@data-qa='billing-status-force-statment-text']"));
        public static Element BillingStatusCollectionsText => new Element(By.XPath("//p[@data-qa='billing-status-in-collections-text']"));
        public static Element FinalLapseText => new Element(By.XPath("//p[@data-qa='billing-status-final-lapse-text']"));
        public static Element WrittenOffText => new Element(By.XPath("//p[@data-qa='billing-status-written-off-text']"));
        public static Element DNOCText => new Element(By.XPath("//p[@data-qa='policy-status-dnoc-count-text']"));
        public static Element CancellationReasonText => new Element(By.XPath("//p[@data-qa='policy-status-cancellation-reason-text']"));
        public static Element PendingCancellationText => new Element(By.XPath("//p[@data-qa='policy-status-pending-cancellation-text']"));
        public static Element EstimateAmountText => new Element(By.XPath("//p[@data-qa='policy-status-estimate-amount-text']"));
        public static Element ActualAmountText => new Element(By.XPath("//p[@data-qa='policy-status-actual-amount-text']"));
        public static Element FinanceCompanyText => new Element(By.XPath("//p[@data-qa='policy-status-finance-company-text']"));
        //PL CoverageTab Elements
        public static Element PolicyMainTitleText => new Element(By.XPath("//p[@data-qa='policy-coverages-main-title']"));
        public static Element PolicyStartDate => new Element(By.XPath("//p[@data-qa='policy-coverages-start-date']"));
        public static Element PolicyCoveragesTerm => new Element(By.XPath("//p[@data-qa='policy-coverages-term']"));
        public static Element PolicyInfoSectionTitle => new Element(By.XPath("//p[@data-qa='policy-coverages-coverageinfo-sectiontitle']"));
        public static Element PolicyGeneralInfo => new Element(By.XPath("//p[@data-qa='policy-coverages-coverageinfo-generalinfo']"));
        public static Element PolicyInfoName => new Element(By.XPath("//p[@data-qa='policy-coverages-coverageinfo-EO-0-name']"));
        public static Element PolicyInfoHeading => new Element(By.XPath("//p[@data-qa='policy-coverages-coverageinfo-EO-0-heading']"));
        public static Element PolicyInfoBullets => new Element(By.XPath("//p[@data-qa='policy-coverages-coverageinfo-EO-0-infobullets']"));
        public static Element PolicyInfoHeading01 => new Element(By.XPath("//p[@data-qa='policy-coverages-coverageinfo-EO-1-heading']"));
        public static Element PolicyInfoBullets01 => new Element(By.XPath("//p[@data-qa='policy-coverages-coverageinfo-EO-1-infobullets']"));
        public static Element PolicyInfoRetroText => new Element(By.XPath("//p[@data-qa='policy-coverages-coverageinfo-EO-1-retrotext']"));
        public static Element PolicyInfoConditionText => new Element(By.XPath("//p[@data-qa='policy-coverages-coverageinfo-EO-1-conditiontext']"));
        public static Element PolicyBenefitInfoSectionTitle => new Element(By.XPath("//p[@data-qa='policy-coverages-benefitinfo-sectiontitle']"));
        public static Element PolicyBenefitGeneralInfo => new Element(By.XPath("//p[@data-qa='policy-coverages-benefitinfo-generalinfo']"));
        public static Element PolicyBenefitInfoName => new Element(By.XPath("//p[@data-qa='policy-coverages-benefitinfo-EO-0-name']"));
        public static Element PolicyBenefitInfoBullets => new Element(By.XPath("//p[@data-qa='policy-coverages-benefitinfo-EO-0-infobullets']"));
    }
}