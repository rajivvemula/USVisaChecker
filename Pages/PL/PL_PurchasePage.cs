using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.PL
{
    [Binding]
    public sealed class PL_PurchasePage : Reusable_PurchasePath
    {

        //Page Title
        public static Element PurchasePageTitle => new Element(By.XPath("//h1[@data-qa='purchase-header']"));
        public static Element PurchasePageSubTitle => new Element(By.XPath("//h3[@data-qa ='purchase-subheader']"));
        public static Element COIAvailableOnlineStmt => new Element(By.XPath("//div[@data-qa='coi-subtext']"));

        //Your Payment Terms for Your Plan
        public static Element PaymentTermsTitle => new Element(By.XPath("//h3[@data-qa='payment-terms-header']"));

        //12 Monthly Payments
        public static Element MonthlyPaymentChkbox => new Element(By.XPath("//payment-option[@data-qa='multipay-terms']//div[@data-qa='payment-option']"));
        public static Element MonthlyPaymentLabel => new Element(By.XPath("//strong[@data-qa='payment-schedule-type']"));
        public static Element PricePerMonthLabel => new Element(By.XPath("//h5[@data-qa='payment-price-per-month']"));

        //View payment schedule accordian
        public static Element ViewPaymentScheduleAccordian => new Element(By.XPath("//div[@data-qa='view-payment-schedule']"));
        public static Element ViewPaymentScheduleAccordian_DueDatePrice => new Element(By.XPath("//ul[@data-qa='schedule']"));
        public static Element ViewPaymentScheduleTotalCost => new Element(By.XPath("//span[@data-qa='total-amount']"));

        //Yearly Payment
        public static Element YearlyPaymentChkbox => new Element(By.XPath("//payment-option[@data-qa='onepay-terms']//div[@data-qa='payment-option']"));
        public static Element YearlyPaymentLabel_YearlySave => new Element(By.XPath("//strong[@data-qa='payment-count']"));
        public static Element YearlyPaymentLabel_PriceDueToday => new Element(By.XPath("//h5[@data-qa='payment-price-down-today']"));

        //AutoPay
        public static Element AutoPayLabel => new Element(By.XPath("//span[@data-qa='autopay-label']"));
        public static Element AutoPayHelper=> new Element(By.XPath("//span[@data-qa='autopay-button']"));
        public static Element AutoPayChkbox => new Element(By.XPath("//md-switch[@data-qa='autopay-toggle-switch']"));
        public static Element MandatoryAutoPayPrgrph => new Element(By.XPath("//span[@data-qa='autopay-msg']"));
        public static Element AutoPayHelperText => new Element(By.XPath("//div[@data-qa='autopay-helptext-help-text']"));
        public static Element AutoPayHelperX => new Element(By.XPath("//i[@data-qa='autopay-helptext-help-text-close-icon']"));

        //Payment Information 
        public static Element PaymentInformationTitle => new Element(By.XPath("//h3[@data-qa='payment-info-header']"));
        public static Element PaymentInformationCCImage_Visa => new Element(By.XPath("//div[@data-qa='visa-cc-image']"));
        public static Element PaymentInformationCCImage_MasterCard => new Element(By.XPath("//div[@data-qa='mastercard-cc-image']"));
        public static Element PaymentInformationCCImage_Discover => new Element(By.XPath("//div[@data-qa='discover-cc-image']"));
        public static Element PaymentInformationCCImage_AmericanExpress => new Element(By.XPath("//div[@data-qa='amex-cc-image']"));
        public static Element PaymentInformationNameTxtbox => new Element(By.XPath("//md-input[@data-qa='cc-name-input']//input"));
        public static Element PaymentInformationNameError => new Element(By.XPath("//span[@data-qa='cc-name-input-validation-error']"));
        public static Element PaymentInformationCCNumberTxtbox => new Element(By.XPath("//md-input[@data-qa='cc-number-input']//input"));
        public static Element PaymentInformationCCNumberError => new Element(By.XPath("//span[@data-qa='cc-number-input-validation-error']"));
        public static Element PaymentInformationCCExpirationTxtbox => new Element(By.XPath("//md-input[@data-qa='cc-month-year-input']//input"));
        public static Element PaymentInformationCCExpirationError => new Element(By.XPath("//span[@data-qa='cc-month-year-input-validation-error']"));

        //Secure payment, 128 bit SSL encrypted
        public static Element SecurePaymentLockImage => new Element(By.XPath("//span[@data-qa='ssl-icon']"));
        public static Element SecurePaymentLabel => new Element(By.XPath("//span[@data-qa='secure-payment-text']"));
        public static Element SecurePaymentHelper => new Element(By.XPath("//span[@data-qa='secure-payment-help-button']"));
        public static Element SecurePaymentHelperText => new Element(By.XPath("//bbmd-helptext[@dataqa='ssl']"));
        public static Element SecurePaymentHelperX => new Element(By.XPath("//i[@data-qa='ssl-help-text-close-icon']"));

        //Address Information
        public static Element BillingStreetAddressTxtbox => new Element(By.XPath("//md-input[@data-qa='billing-address-input']//input"));
        public static Element BillingStreetAddressError => new Element(By.XPath("//span[@data-qa='billing-address-input-validation-error']"));
        public static Element BillingApartmentSuiteTxtbox => new Element(By.XPath("//md-input[@data-qa='2-billing-address-input']//input"));
        public static Element BillingZipCodeTxtbox => new Element(By.XPath("//md-input[@data-qa='billing-zip-input']//input"));
        public static Element BillingZipCodeError => new Element(By.XPath("//span[@data-qa='billing-zip-input-validation-error']"));
        public static Element BillingCityDD => new Element(By.XPath("//select[@data-qa='city-input']//../input"));
        public static Element BillingStateTxtbox => new Element(By.XPath("//md-input[@data-qa='billing-state-input']//input"));
        public static Element BillingStateError => new Element(By.XPath("//md-input[@data-qa='billing-state-input-validation-error']"));
        public static Element BillingPhoneTxtbox => new Element(By.XPath("//md-input[@data-qa='billing-phone-input']//input"));
        public static Element BillingPhoneError => new Element(By.XPath("//span[@data-qa='billing-phone-input-validation-error']"));
        public static Element BillingPhoneExtensionTxtbox => new Element(By.XPath("//md-input[@data-qa='billing-phone-ext-input']//input"));

        //Terms and Conditions Checkbox and Label
        public static Element TermsConditionsChkbox => new Element(By.XPath("//md-checkbox[@data-qa='TOA-checkbox']"));
        public static Element TermsConditionsLabel => new Element(By.XPath("//span[@data-qa='TOA-text']"));
        public static Element TermsOfUseLink => new Element(By.XPath("//a[@data-qa='TOA-link']"));

        /*
         * Terms and Conditions Modal ************************************************************
         */

        //Terms & Conditions
        public static Element TermsConditionsTitle => new Element(By.XPath("//h3[@data-qa='T&C-title']"));
        public static Element TermsConditionsModalX => new Element(By.XPath("//i[@data-qa='modal-x-icon']"));
        public static Element TermsConditionsParagraph => new Element(By.XPath("//h6[@data-qa='agree-applicant']"));

        //Claims Made Coverage Basis
        public static Element ClaimsMadeCoverageBasisTitle => new Element(By.XPath("//h5[@data-qa='claims-coverage-title']"));
        public static Element ClaimsMadeCoverageBasisParagraph => new Element(By.XPath("//p[@data-qa='claims-coverage-text']"));

        //For NY policyholders:
        public static Element NYPolicyHoldersTitle => new Element(By.XPath("//h5[@data-qa='NY-policyholders-title']"));
        public static Element NYPolicyHoldersParagraph_RatesForClaims => new Element(By.XPath("//p[@data-qa='NY-policyholders-text-1']"));
        public static Element NYPolicyHoldersParagraph_PolicyCancelled => new Element(By.XPath("//p[@data-qa='NY-policyholders-text-2']"));
        public static Element NYPolicyHoldersParagraph_Options => new Element(By.XPath("//p[@data-qa='NY-policyholders-options-text']"));
        public static Element NYPolicyHoldersPremiumCharge1 => new Element(By.XPath("//li[@data-qa='NY-policyholder-option-100-percent']"));
        public static Element NYPolicyHoldersPremiumCharge2 => new Element(By.XPath("//li[@data-qa='NY-policyholder-option-150-percent']"));
        public static Element NYPolicyHoldersPremiumCharge3 => new Element(By.XPath("//li[@data-qa='NY-policyholder-option-200-percent']"));
        public static Element NYPolicyHoldersPremiumCharge4 => new Element(By.XPath("//li[@data-qa='NY-policyholder-option-225-percent']"));
        public static Element NYPolicyHoldersPremiumCharge5 => new Element(By.XPath("//li[@data-qa='NY-policyholder-option-250-percent']"));

        public static Element NYPolicyHoldersPremiumChargYear1 => new Element(By.XPath("//li[@data-qa='NY-policyholder-year-1']"));
        public static Element NYPolicyHoldersPremiumChargYear2 => new Element(By.XPath("//li[@data-qa='NY-policyholder-year-2']"));
        public static Element NYPolicyHoldersPremiumChargYear3 => new Element(By.XPath("//li[@data-qa='NY-policyholder-year-3']"));
        public static Element NYPolicyHoldersPremiumChargYear4 => new Element(By.XPath("//li[@data-qa='NY-policyholder-year-4']"));
        public static Element NYPolicyHoldersPremiumChargYear5 => new Element(By.XPath("//li[@data-qa='NY-policyholder-year-5']"));


        public static Element NYPolicyHoldersStmt => new Element(By.XPath("//p[@data-qa='NY-help-text']"));

        //Claim Expense
        public static Element ClaimExpenseTitle => new Element(By.XPath("//h5[@data-qa='claims-expense-title']"));
        public static Element ClaimExpenseParagraph => new Element(By.XPath("//p[@data-qa='claims-expense-text-1']"));
        public static Element ClaimExpenseStmt_NAinMTandVT => new Element(By.XPath("//p[@data-qa='claims-expense-help-text-1']"));
        public static Element ClaimExpenseStmt_NAinNY => new Element(By.XPath("//p[@data-qa='claims-expense-help-text-2']"));

        //Personal Information
        public static Element PersonInformationTitle => new Element(By.XPath("//h5[@data-qa='personal-information-title']"));
        public static Element PersonInformationParagraph => new Element(By.XPath("//p[@data-qa='personal-information-text']"));

        //Cancellation
        public static Element CancellationTitle => new Element(By.XPath("//h5[@data-qa='cancellation-title']"));
        public static Element CancellationParagraph_DownPayment => new Element(By.XPath("//p[@data-qa='cancellation-text-1']"));
        public static Element CancellationParagraph_CancelPolicy => new Element(By.XPath("//p[@data-qa='cancellation-text-2']"));
        public static Element CancellationParagraph_CheckReturned => new Element(By.XPath("//p[@data-qa='cancellation-text-3']"));

        //Recurring Direct Draft Program
        public static Element RecurringDDProgramTitle => new Element(By.XPath("//h5[@data-qa='recurring-direct-draft-title']"));
        public static Element RecurringDDProgramParagraph => new Element(By.XPath("//p[@data-qa='recurring-direct-draft-text']"));

        //AutoPay - Recurring Credit Card Program
        public static Element AutoPayRecurringCCTitle => new Element(By.XPath("//h5[@data-qa='autopay-recurring-title']"));
        public static Element AutoPayRecurringCCParagraph => new Element(By.XPath("//p[@data-qa='autopay-recurring-text']"));

        //Payment Schedule
        public static Element PaymentScheduleTitle => new Element(By.XPath("//h5[@data-qa='payment-schedule-title']"));
        public static Element PaymentScheduleParagraph => new Element(By.XPath("//p[@data-qa='payment-schedule-text']"));

        //State Specific Terms & Conditions
        public static Element StateTermsTitle => new Element(By.XPath("//h5[@data-qa='state-specific-T&C-title']"));

        //Arizona
        public static Element StateTermsTitle_AZ => new Element(By.XPath("//h6[@data-qa='Arizona-title']"));
        public static Element StateTermsParagraph_AZ => new Element(By.XPath("//p[@data-qa='Arizona-text-1']"));

        //California
        public static Element StateTermsTitle_CA => new Element(By.XPath("//h6[@data-qa='California-title']"));
        public static Element StateTermsParagraph_CA => new Element(By.XPath("//p[@data-qa='California-text-1']"));

        //Massachusetts
        public static Element StateTermsTitle_MA => new Element(By.XPath("//h6[@data-qa='Massachusetts-title']"));
        public static Element StateTermsParagraph_MA => new Element(By.XPath("//p[@data-qa='Massachusetts-text-1']"));

        //Minnesota
        public static Element StateTermsTitle_MN => new Element(By.XPath("//h6[@data-qa='Minnesota-title']"));
        public static Element StateTermsParagraph_MN => new Element(By.XPath("//p[@data-qa='Massachusetts-text']"));

        //Oregon
        public static Element StateTermsTitle_OR => new Element(By.XPath("//h6[@data-qa='Oregon-title']"));
        public static Element StateTermsParagraph_ORPersonalInfo => new Element(By.XPath("//p[@data-qa='Oregon-text-1']"));
        public static Element StateTermsParagraph_ORIntentToDefraud => new Element(By.XPath("//p[@data-qa='Oregon-text-2']"));

        //Alabama, Arkansas, District of Columbia, Louisiana, Maryland, New Mexico, Rhode Island and West Virginia
        public static Element StateTermsTitle_AL => new Element(By.XPath("//h6[@data-qa='multi-state-title']"));
        public static Element StateTermsParagraph_AL => new Element(By.XPath("//p[@data-qa='multi-state-text']"));
        public static Element StateTermsStmt_AL => new Element(By.XPath("//p[@data-qa='multi-state-Maryland-only']"));

        //Colorado
        public static Element StateTermsTitle_CO => new Element(By.XPath("//h6[@data-qa='Colorado-title']"));
        public static Element StateTermsParagraph_CO => new Element(By.XPath("//p[@data-qa='Colorado-text-1']"));

        //Florida and Oklahoma
        public static Element StateTermsTitle_FLandOK => new Element(By.XPath("//h6[@data-qa='FL&OK-title']"));
        public static Element StateTermsParagraph_FLandOK => new Element(By.XPath("//p[@data-qa='FL&OK-text-1']"));
        public static Element StateTermsStmt_FLandOK => new Element(By.XPath("//p[@data-qa='Florida-only']"));

        //Kansas
        public static Element StateTermsTitle_KS => new Element(By.XPath("//h6[@data-qa='Kansas-title']"));
        public static Element StateTermsParagraph_KS => new Element(By.XPath("//p[@data-qa='Kansas-text-1']"));

        //Kentucky, New York, Ohio and Pennsylvania
        public static Element StateTermsTitle_KY=> new Element(By.XPath("//h6[@data-qa='KY-NY-OH-PA-title']"));
        public static Element StateTermsParagraph_KY => new Element(By.XPath("//p[@data-qa='KY-NY-OH-PA-text-1']"));
        public static Element StateTermsStmt_KY => new Element(By.XPath("//p[@data-qa='NY-only']"));

        //Maine, Tennessee, Virginia and Washington
        public static Element StateTermsTitle_ME => new Element(By.XPath("//h6[@data-qa='ME-TN-VA-WA-title']"));
        public static Element StateTermsParagraph_ME => new Element(By.XPath("//p[@data-qa='ME-TN-VA-WA-text-1']"));
        public static Element StateTermsStmt_ME => new Element(By.XPath("//p[@data-qa='Maine-only']"));

        //New Jersey
        public static Element StateTermsTitle_NJ => new Element(By.XPath("//h6[@data-qa='New-Jersey-title']"));
        public static Element StateTermsParagraph_NJ => new Element(By.XPath("//p[@data-qa='New-Jersey-text-1']"));

        //Utah
        public static Element StateTermsTitle_UT => new Element(By.XPath("//h6[@data-qa='Utah-title']"));
        public static Element StateTermsParagraph_UT => new Element(By.XPath("//p[@data-qa='Utah-text-1']"));

        //Vermont
        public static Element StateTermsTitle_VT => new Element(By.XPath("//h6[@data-qa='Vermont-title']"));
        public static Element StateTermsParagraph_VT => new Element(By.XPath("//p[@data-qa='Vermont-text-1']"));

        //Close Modal Button
        public static Element TermsConditionsModalBtn_Close => new Element(By.XPath("//button[@data-qa='modal-close-button']"));

        /*
         * End of Terms and Conditions Modal ********************************************************
         */

        //English Terms
        public static Element EnglishTermsTitle => new Element(By.XPath(""));
        public static Element EnglishTermsParagraph => new Element(By.XPath(""));
        public static Element EnglishTermsChkbox => new Element(By.XPath(""));
        public static Element EnglishTermsLabel => new Element(By.XPath(""));

        //Spanish Terms
        public static Element SpanishTermsTitle => new Element(By.XPath(""));
        public static Element SpanishTermsParagraph => new Element(By.XPath(""));
        public static Element SpanishTermsChkbox => new Element(By.XPath(""));
        public static Element SpanishTermsLabel => new Element(By.XPath(""));

        /*
         * CTA *********************************************************************
         */

        //Purchase Button
        public static Element PayAmountCTA => new Element(By.XPath("//button[@data-qa='payment-validate-button']"));
        //Submit to UW Button
        public static Element SubmitToUWCTA => new Element(By.XPath(""));

        /*
         * Logos *******************************************************
         */

        //Logo Image
        public static Element BBBImage => new Element(By.XPath("//img[@data-qa='payment-bbb-logo']"));
        public static Element AuthorizeNetImage => new Element(By.XPath("//img[@data-qa='payment-authorizeDotNet-logo']"));

        //Proud to be part of Warren Buffett's Berkshire Hathaway Company
        public static Element ProudToBeACopy => new Element(By.XPath("//div[@data-qa='footer-text']"));

    }
}
