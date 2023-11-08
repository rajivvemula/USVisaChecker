using TechTalk.SpecFlow;
using HitachiQA.Driver;
using OpenQA.Selenium;

namespace BiBerkLOB.Pages.WC
{
    [Binding]
    public sealed class WC_PurchaseYourPolicy
    {
        public static Element PurchaseYourPolicyTitle => new Element(By.XPath("//div[@data-qa='WC_purchase_policy_header']"));
        
        //Sample: "Policy Start Date 8/2/2022"
        public static Element PolicyStartDateWithDate => new Element(By.XPath("(//div[@data-qa='WC_purchase_policy_header']//following-sibling::div)[1]"));

        public static Element CoverageForOneYear => new Element(By.XPath("(//div[@data-qa='WC_purchase_policy_header']//following-sibling::div)[2]"));
        public static Element COIAvailableOnline => new Element(By.XPath("(//div[@data-qa='WC_purchase_policy_header']//following-sibling::div)[3]"));

        //Payment Information Section
        public static Element PaymentInformationTitle => new Element(By.XPath("//h2[@data-qa='WC_payment_info_header']"));
        public static Element OrderSummaryTitle => new Element(By.XPath("//h4[@data-qa='WC_order_summary_header']"));
        public static Element ProductTitle => new Element(By.XPath("//h4[@data-qa='WC_product_header']"));
        public static Element ProductWC => new Element(By.XPath("//h4[@data-qa='WC_display_header_value']"));
        public static Element PolicyTermTitle => new Element(By.XPath("//h4[@data-qa='WC_policy_term_header']"));
        public static Element PolicyTermAmt => new Element(By.XPath("//h4[@data-qa='WC_policy_term_value']"));
        public static Element StartingDateTitle => new Element(By.XPath("//h4[@data-qa='WC_starting_date_header']"));
        public static Element StartingDateDate => new Element(By.XPath("//h4[@data-qa='WC_starting_date_value']"));
        public static Element TotalPremiumTitle => new Element(By.XPath("//h4[@data-qa='WC_total_premium_header']"));
        public static Element TotalPremiumAmt => new Element(By.XPath("//h4[@data-qa='WC_total_premium_value']"));
        public static Element PaymentOptionTitle => new Element(By.XPath("//h4[@data-qa='WC_payment_option_header']"));
        public static Element PaymentOptionDD => new Element(By.XPath("//bb-select[@data-qa='WC_payment_select']//select"));

        //Due Now Section
        public static Element DueNowTitle => new Element(By.XPath("//h4[@data-qa='WC_due_now_header']"));
        public static Element DueNowAmt => new Element(By.XPath("//h4[@data-qa='WC_down_payment_amount']"));
        public static Element FutureInstallmentTitle => new Element(By.XPath("//h4[@data-qa='WC_future_installment_header']"));
        public static Element FutureInstallmentAmt => new Element(By.XPath("//h4[@data-qa='WC_future_installment_value']"));
        public static Element PerInstallmentTitle => new Element(By.XPath("//h4[@data-qa='WC_per_installment_header']"));
        public static Element PerInstallmentAmt => new Element(By.XPath("//h4[@data-qa='WC_per_installment_value']"));

        //Pay Using Credit Card
        public static Element PayUsingCreditCardTitle => new Element(By.XPath("//h4[@data-qa='WC_cc_pay_header']"));
        public static Element CCImgs_AllFour => new Element(By.XPath("//div[@data-qa='WC_accepted_cc_images']"));
        public static Element NameOnCardQST => new Element(By.XPath("//label[@data-qa='WC_cc_name_label']"));
        public static Element NameOnCardTxtbox => new Element(By.XPath("//input[@data-qa='WC_cc_name_input']"));
        public static Element CreditCardNumQST => new Element(By.XPath("//label[@data-qa='WC_cc_number_label']"));
        public static Element CreditCardNumTxtbox => new Element(By.XPath("//bb-creditcard[@data-qa='WC_cc_number_inputr']/div/div/input"));
        public static Element CreditCardMonthTxtbox => new Element(By.XPath("//bb-creditcard[@data-qa='WC_cc_number_inputr']//input[@value.bind='month']"));
        public static Element CreditCardYearTxtbox => new Element(By.XPath("//bb-creditcard[@data-qa='WC_cc_number_inputr']//input[@value.bind='year']"));
        public static Element ThisIsASecureSSLEncryptedPayment => new Element(By.XPath("//p[@data-qa='WC_secure_cc_info']"));
        public static Element MonthlyEnrollsYouInAutopayChkbox => new Element(By.XPath("//input[@data-qa='WC_autopay_signup_checbox']"));
        public static Element MonthlyEnrollsYouInAutopayTxt => new Element(By.XPath("//label[@data-qa='WC_autopay_signup_label']"));
        public static Element MonthlyEnrollsYouInAutopayTxtLowPremium => new Element(By.XPath("//label[@data-qa='WC_autopay_monthly_enrollment_label']"));
        public static Element MonthlyEnrollsYouInAutopayHelper => new Element(By.XPath("//button[@data-qa='WC_autopay_tooltip_tooltip']"));
        public static Element MonthlyEnrollsYouInAutopayHelperTxt => new Element(By.XPath("//button[@data-qa='WC_autopay_tooltip_tooltip' and contains(@data-content,'We will automatically charge')]"));

        //Contact information
        public static Element ContactInfoTitle => new Element(By.XPath("//h2[@data-qa='WC_contact_info_header']"));
        public static Element FirstNameQST => new Element(By.XPath("//label[@data-qa='WC_contact_firstname_label']"));
        public static Element FirstNameTxtbox => new Element(By.XPath("//input[@data-qa='WC_contact_firstname_input']"));
        public static Element LastNameQST => new Element(By.XPath("//label[@data-qa='WC_contact_lastname_label']"));
        public static Element LastNameTxtbox => new Element(By.XPath("//input[@data-qa='WC_contact_lastname_input']"));
        public static Element EmailQST => new Element(By.XPath("//label[@data-qa='WC_contact_email_label']"));
        public static Element EmailTxtbox => new Element(By.XPath("//bb-email[@data-qa='WC_contact_email_input']/input"));
        public static Element PhoneQST => new Element(By.XPath("//label[@data-qa='WC_contact_phone_label']"));
        public static Element PhoneTxtbox => new Element(By.XPath("//bb-phone[@data-qa='WC_contact_phone_input']/input"));
        public static Element UseThisAsBillingContactQST => new Element(By.XPath("//label[@data-qa='WC_use_billing_info_label']"));
        //this box is checked by default
        public static Element UseThisAsBillingContactChkbox => new Element(By.XPath("//input[@data-qa='WC_use_billing_info_checbox']"));

        //Billing Contact Information (if you uncheck the checkbox)
        public static Element BillingFirstNameQST => new Element(By.XPath("//label[@data-qa='WC_diff_contact_firstname_label']"));
        public static Element BillingFirstNameTxtbox => new Element(By.XPath("//input[@data-qa='WC_diff_contact_firstname_input']"));
        public static Element BillingLastNameQST => new Element(By.XPath("//label[@data-qa='WC_diff_contact_lastname_label']"));
        public static Element BillingLastNameTxtbox => new Element(By.XPath("//input[@data-qa='WC_diff_contact_lastname_input']"));
        public static Element BillingEmailQST => new Element(By.XPath("//label[@data-qa='WC_diff_contact_email_label']"));
        public static Element BillingEmailTxtbox => new Element(By.XPath("//bb-email[@data-qa='WC_diff_contact_email_input']/input"));
        public static Element BillingPhoneQST => new Element(By.XPath("//label[@data-qa='WC_diff_contact_phone_label']"));
        public static Element BillingPhoneTxtbox => new Element(By.XPath("//bb-phone[@data-qa='WC_diff_contact_firstname_input']/input"));

        //ToS
        public static Element AgreeToTermsQST => new Element(By.XPath("//bb-termsagree[@data-qa='payment_terms_agree']/div/label"));
        public static Element AgreeToTermsChkbox => new Element(By.XPath("(//bb-termsagree[@data-qa='payment_terms_agree']/div/label/input)"));
        public static Element AgreeToTermsLink => new Element(By.XPath("//bb-termsagree[@data-qa='payment_terms_agree']/div/label/a"));
        public static Element PurchaseCTA => new Element(By.XPath("//button[@data-qa='WC_purchase_button_1']"));

        //Florida document agreements
        public static Element FloridaApplicationsChkBox => new Element(By.XPath("//input[@data-qa='floridaTerms_checkbox']"));
        public static Element FloridaApplicationsLink => new Element(By.XPath("//a[@data-qa='floridaTerms_link']"));
        public static Element FloridaForegoingChkBox => new Element(By.XPath("//input[@data-qa='floridaAcord_checkbox']"));
        public static Element FloridaForegoingLink => new Element(By.XPath("//a[@data-qa='floridaAcord_link']"));

        //Footer Elements
        public static Element ACOIIsAvailableParagraph => new Element(By.XPath("//div[@data-qa='WC_COI_text']"));
        public static Element BBBImg => new Element(By.XPath("//img[@data-qa='WC_BBB_accreditation_image']"));
        public static Element AuthorizeNETImg => new Element(By.XPath("//img[@data-qa='WC_auth_net_image']"));
    }
}