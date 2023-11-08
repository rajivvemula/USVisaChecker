using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BiBerkLOB.Pages.Other;
using BiBerkLOB.Source.Driver;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.CommAuto
{
    [Mapping("CA Purchase Page")]
    public sealed class CA_PurchaseYourPlanPage
    {
        public static LoadingRequirements LoadingRequirements => new LoadingRequirements(PurchaseYourPlan, OneYearCoverageStarting, CertificateOfInsAvailable);
        /*
        * Headers----------------------------------------------------------
        */

        //Your Commercial Auto Quote ID: #####

        //Purchase Your Plan
        public static Element PurchaseYourPlan => new Element(By.XPath("//h1[@data-qa='purchase-your-plan-header']"));

        //One year coverage starting on ##/##/##.
        public static Element OneYearCoverageStarting => new Element(By.XPath("//p[@data-qa='purchase-your-plan-subHeader']"));

        //Your auto ID cards will be mailed to you post purchase. If you need a COI please call and we can assist you.
        public static Element CertificateOfInsAvailable => new Element(By.XPath("//p[@data-qa='purchase-page-text']"));

        /*
        * Questions----------------------------------------------------------
        */

        //Your Payment Terms
        public static Element PaymentTerms => new Element(By.XPath("//h3[@data-qa='your-payment-terms-title']"));

        //12 Monthly Payments
        public static Element TwelveMonthlyPayments => new Element(By.XPath("//strong[@data-qa='12 Monthly Payments-title']"));
        public static Element TwelveMonthlyPaymentsAmountPerMonth => new Element(By.XPath("//div[@data-qa='per month-frequency-section']/h5"));
        public static Element TwelveMonthlyPaymentsViewSchedule => new Element(By.XPath("//mat-panel-title[@data-qa='view-payment-schedule-title']"));
        public static Element TwelveMonthlyPaymentsChkbox => new Element(By.XPath("//mat-checkbox[@data-qa='12 Monthly Payments-checkbox']"));

        //Yearly
        public static Element YearlyPayment => new Element(By.XPath("//strong[@data-qa='Yearly-title']"));
        //Save: $###.##
        public static Element YearlyPaymentSaveAmount => new Element(By.XPath("//strong[@data-qa='yearly-saved']"));
        public static Element YearlyPaymentDueToday => new Element(By.XPath("//div[@data-qa='1 payment, due today-frequency-section']/h5"));
        public static Element YearlyPaymentChkbox => new Element(By.XPath("//mat-checkbox[@data-qa='Yearly-checkbox']/label"));

        //Autopay
        public static Element AutopayTitle => new Element(By.XPath("//h6[@data-qa='autoPay-title']"));
        public static Element AutopayToggle => new Element(By.XPath("//mat-slide-toggle[@data-qa='autoPay-toggle']"));
        public static Element AutopayValue => new Element(By.XPath("//mat-slide-toggle[@data-qa='autoPay-toggle']/div/button"));

        //Autopay required (selected monthly and total cost less than $1,000)
        public static Element AutopayReqTitle => new Element(By.XPath("//h6[@data-qa='autoPay-title' and text()=' By selecting to pay monthly you will automatically be enrolled in autopay. ']"));
        public static Element AutopayReqHelper => new Element(By.XPath("//button[@data-qa='buttonShowHelpToggle-AutoPay']"));
        public static Element AutopayReqHelperText => new Element(By.XPath("//p[@data-qa='autoPayHelpText-label']"));
        public static Element AutopayReqHelperX => new Element(By.XPath("//button[@data-qa='buttonClose-autoPayHelpText']"));

        //Payment Information
        public static Element PaymentInformationTitle => new Element(By.XPath("//h3[@data-qa='payment-information-title']"));
        public static Element CCImg_Visa => new Element(By.XPath("//bb-cc-images/div[@data-qa='Visa-name']"));
        public static Element CCImg_Mastercard => new Element(By.XPath("//bb-cc-images/div[@data-qa='Mastercard-name']"));
        public static Element CCImg_Discover => new Element(By.XPath("//bb-cc-images/div[@data-qa='Discover-name']"));
        public static Element CCImg_AmEx => new Element(By.XPath("//bb-cc-images/div[@data-qa='Amex-name']"));
        public static Element CreditCardName => new Element(By.XPath("//input[@data-qa='ccName']"));
        public static Element CreditCardNameError => new Element(By.XPath("//mat-error[@data-qa='ccName-error']"));
        public static Element CreditCardNumber => new Element(By.XPath("//input[@data-qa='creditcard']"));
        public static Element CreditCardNumberError => new Element(By.XPath("//mat-error[@data-qa='cc-error']"));
        public static Element CreditCardMMYY => new Element(By.XPath("//input[@data-qa='ccExp']"));
        public static Element CreditCardMMYYError => new Element(By.XPath("//mat-error[@data-qa='ccExp-error']"));
        public static Element CreditCardLockImage => new Element(By.XPath("//span[@data-qa='lockIcon']"));
        public static Element CreditCardSecurePayment => new Element(By.XPath("//p[@data-qa='ssl-text']"));
        public static Element CreditCardHelper => new Element(By.XPath("//button[@data-qa='buttonShowHelpToggle-SSL']"));
        public static Element CreditCardHelperText => new Element(By.XPath("//p[@data-qa='sslHelpText-label']"));
        public static Element CreditCardHelperX => new Element(By.XPath("//button[@data-qa='buttonClose-sslHelpText']"));

        public static Element AgreeToTermsOfUseHyperlink => new Element(By.XPath("//button[@data-qa='termsAgree-button']"));
        public static Element AgreeToTermsOfUseChkbox => new Element(By.XPath("//mat-checkbox[@data-qa='termsAgree-checkbox']"));
        public static Element AgreeToTermsOfUseError => new Element(By.XPath("//mat-error[@data-qa='termsAgree-error']"));
        //Verified Authorize.Net Merchant
        public static Element AuthNetMerchantImg => new Element(By.XPath("//img[@data-qa='authorize.net-img']"));

        /*
         * AUTH USER EXPOSED ELEMENTS
         */
        public static Element EnglishTermsTab => new Element(By.XPath("//div[@data-qa='english-terms']"));
        public static Element EnglishTermsText => new Element(By.XPath("//div[@data-qa='english-terms-content']"));
        public static Element SpanishTermsTab => new Element(By.XPath("//div[@data-qa='spanish-terms']"));
        public static Element SpanishTermsText => new Element(By.XPath("//div[@data-qa='spanish-terms-content']"));
        public static Element TermsChkbox => new Element(By.XPath("//mat-checkbox[@data-qa='terms-checkbox']//input"));
        public static Element TermsChkboxText => new Element(By.XPath("//span[@data-qa='terms-checkbox-text']"));

        public static Element SubmitToUWCTA => new Element(By.XPath("//button[@data-qa='underwriting']"));

        /*
        * Page CTA----------------------------------------------------------
        */
        public static Element PayCTA => new Element(By.XPath("//button[@data-qa='pay']"));
        public static Element BetterBusinessIMG => new Element(By.XPath("//img[@data-qa='bbb-img']"));

        public static Dictionary<Element, string> ErrorElements => new Dictionary<Element, string>
        {
            {CA_PurchaseYourPlanPage.CreditCardNameError,"Please enter your first and last name, it's required."},
            {CA_PurchaseYourPlanPage.CreditCardNumberError,"Please enter a valid credit card number, it's required."},
            {CA_PurchaseYourPlanPage.CreditCardMMYYError,"Required"},
            {CA_PurchaseYourPlanPage.AgreeToTermsOfUseError,"Please agree to the terms and conditions."},
        };

        public static  Dictionary<Element, string> HelpTextElements => new Dictionary<Element, string>
        {
            {CA_PurchaseYourPlanPage.AutopayReqHelperText,"When you select autopay, we automatically charge your credit card each time your monthly or yearly payment is due. We use the same payment method you provide for your initial payment."},
            {CA_PurchaseYourPlanPage.CreditCardHelperText,"SSL (Secure Sockets Layer) is the standard security technology for establishing an encrypted link between a web server and a browser. This link ensures that all data passed between the web server and browsers remains private and secure"},
        };

        public static  List<Element> HelpElements => new List<Element>
        {
            CA_PurchaseYourPlanPage.AutopayReqHelper,
            CA_PurchaseYourPlanPage.CreditCardHelper
        };
    }
}