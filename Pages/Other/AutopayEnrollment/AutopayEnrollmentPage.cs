using DocumentFormat.OpenXml.Office2010.ExcelAc;
using HitachiQA.Driver;
using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.Other.AutopayEnrollment
{
    public class AutopayEntrollmentPage : IStaticPage
    {
        //Mappings can be used for both Autopay Enrollment and for Updating Autopay Enrollment pages
        //Header
        public static Element AutopayEnrollment => new Element(By.XPath("//h1[@data-qa='autoPay_enroll_headerText']"));
        //To avoid any payment delays and eliminate installment fees, enroll in automatic bill pay.
        public static Element AutopayEnrollText => new Element(By.XPath("//p[@data-qa='autoPay_enroll_subText']"));
        //I want to pay using OR I want to update my
        public static Element IWantTo => new Element(By.XPath("//span[@data-qa='autoPay_enroll_paymentTypeText-label']"));

        //Credit Card
        public static Element Credit_BTN => new Element(By.XPath("//label[@data-qa='autopay_paymentType_cc']"));
        //Direct Draft
        public static Element DirectDraft_BTN => new Element(By.XPath("//label[@data-qa='autopay_paymentType_dd']"));

        /*   For Credit Card path     */
        //Payment Information
        public static Element CCPaymentInfo => new Element(By.XPath("//h3[@data-qa='cc_payment_info_header']"));
        public static Element CCVisa_IMG => new Element(By.XPath("//div[@data-qa='cc_visa']"));
        public static Element CCMastercard_IMG => new Element(By.XPath("//div[@data-qa='cc_mastercard']"));
        public static Element CCDiscover_IMG => new Element(By.XPath("//div[@data-qa='cc_discover']"));
        public static Element CCAmex => new Element(By.XPath("//div[@data-qa='cc_amex']"));
        //Your Name Input 
        public static Element YourName => new Element(By.XPath("//md-input[@data-qa='cc_payment_info_name']/div/input"));
        //Credit Card Input 
        public static Element CCNumber => new Element(By.XPath("//md-input[@data-qa='cc_payment_info_Number']/div/input"));
        //Expiration Date Input
        public static Element CCYear => new Element(By.XPath("//md-input[@data-qa='cc_payment_info_monthyear']/div/input"));
        public static Element SecurePaymentIcon => new Element(By.XPath("//i[@data-qa='cc_securePayment-help-icon']"));
        public static Element SecurePaymentParagraph => new Element(By.XPath("//span[@data-qa='cc_securePayment-label']"));

        /*   For Direct Draft path     */
        //Account Type
        public static Element AccountType => new Element(By.XPath("//span[@data-qa='dd_accountType-label']"));
        //Checking
        public static Element Checking_BTN => new Element(By.XPath("//label[@data-qa='autopay_accountType_0']"));
        //Savings
        public static Element Savings_BTN => new Element(By.XPath("//label[@data-qa='autopay_accountType_1']"));
        //Bank Account Number
        public static Element BankAccNumText => new Element(By.XPath("//span[@data-qa='dd_bankAccount_number-label']"));
        public static Element BankAccNumHelp => new Element(By.XPath("//i[@data-qa='dd_bankAccount_number-help-icon']"));
        public static Element BankAccNumInput => new Element(By.XPath("//md-input[@data-qa='dd_bankAccount_number']/div/input"));
        //Routing Number
        public static Element BankRoutingNum => new Element(By.XPath("//span[@data-qa='dd_bankAccount_routing-label']"));
        public static Element BankRoutingNumHelp => new Element(By.XPath("//i[@data-qa='dd_bankAccount_routing-help-icon']"));
        public static Element BankRoutingInput => new Element(By.XPath("//md-input[@data-qa='dd_bankRouting_number']/div/input"));

        //Agree to Terms
        public static Element AgreeToTerms_Praragraph => new Element(By.XPath("//bbmd-termsagree[@data-qa='autoPay_termsAgree_component']/md-checkbox/label"));
        public static Element AgreeToTerms_Checkbox => new Element(By.XPath("//input[@data-qa='autopay_termsAgree_checkBox']"));
        public static Element TermsAndConditionsLink => new Element(By.XPath("//a[@data-qa='autoPay_termsAgree_link']"));

        //Enroll or Update Autopay Button
        public static Element UpdateAutopay_BTN => new Element(By.XPath("//button[@data-qa='autoPay_submitButton']"));

        public static List<Element> AutopayEnrollmentMainElements => new List<Element>
            {
                AutopayEnrollment,
                AutopayEnrollText,
                IWantTo,
                Credit_BTN,
                DirectDraft_BTN,
                UpdateAutopay_BTN
            };

        public static List<Element> AutopayCCEnrollmentEelements => new List<Element>
        {
            CCPaymentInfo,
            CCVisa_IMG,
            CCMastercard_IMG,
            CCDiscover_IMG,
            CCAmex,
            YourName,
            CCNumber,
            CCYear,
            SecurePaymentIcon,
            SecurePaymentParagraph,
            AgreeToTerms_Praragraph,
            TermsAndConditionsLink
        };

        public static List<Element> AutopayDDEnrollmentElements => new List<Element> 
        {
            AccountType,
            Checking_BTN,
            Savings_BTN,
            BankAccNumText,
            BankAccNumHelp,
            BankAccNumInput,
            BankRoutingNum,
            BankRoutingNumHelp,
            BankRoutingInput,
            AgreeToTerms_Praragraph,
            TermsAndConditionsLink
        };
    }
}