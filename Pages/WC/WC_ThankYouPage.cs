using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiBerkLOB.Pages.WC
{
    public sealed class WC_ThankYouPage
    {
        // Title Elements:
        public static Element ThankYou => new Element(By.XPath("//h1[@data-qa='wc_thank_you_header']"));
        public static Element ThankYouBHText => new Element(By.XPath("//p[@data-qa='wc_thank_you_BH_text']"));
        public static Element GetCOICTA => new Element(By.XPath("//button[@data-qa='wc_thank_you_get_COI_button']"));
        public static Element CopyOfYourPolicyText => new Element(By.XPath("//p[@data-qa='wc_thank_you_copy_policy_mailed_text']"));

        // Your Order Summary:
        // Product
        public static Element ProductLabel => new Element(By.XPath("//td[@data-qa=\"wc_thank_you_product_header_Workers' Compensation\"]"));
        public static Element ProductValue => new Element(By.XPath("//td[@data-qa=\"wc_thank_you_product_Workers' Compensation\"]"));
        // Policy Number
        public static Element PolicyNumberLabel => new Element(By.XPath("//td[@data-qa='wc_thank_you_policy_number_header']"));
        public static Element PolicyNumberValue => new Element(By.XPath("//td[@data-qa='wc_thank_you_policy_number_value']"));
        // Confirmation Number
        public static Element ConfirmationNumberLabel => new Element(By.XPath("//td[@data-qa='wc_thank_you_confirmation_number_header']"));
        public static Element ConfirmationValue => new Element(By.XPath("//td[@data-qa='wc_thank_you_confirmation_number_value']"));
        // Policy Start Date
        public static Element PolicyStartDateLabel => new Element(By.XPath("//td[@data-qa='wc_thank_you_policy_start_date_header']"));
        public static Element PolicyStartDateValue => new Element(By.XPath("//td[@data-qa='wc_thank_you_policy_start_date']"));
        public static Element CoverageForOneYearTxt => new Element(By.XPath("//p[@data-qa='wc_thank_you_coverage_one_year_text']"));
        //Down Payment
        public static Element DownPaymentLabel => new Element(By.XPath("//td[@data-qa='wc_thank_you_down_payment_header']"));
        public static Element DownPaymentValue => new Element(By.XPath("//td[@data-qa='wc_thank_you_down_payment_value']"));
        //Payment per Month
        public static Element PaymentPerMonthLabel => new Element(By.XPath("//td[@data-qa='wc_thank_you_payment_frequency']"));
        public static Element PaymentPerMonthValue => new Element(By.XPath("//td[@data-qa='wc_thank_you_installment_amount']"));
        //Next Payment Due
        public static Element NextPaymentDueLabel => new Element(By.XPath("//td[@data-qa='wc_thank_you_next_payment_header']"));
        public static Element NextPaymentDueValue=> new Element(By.XPath("//span[@data-qa='wc_thank_you_next_payment_due']"));

        // LOB Recomendations:
        public static Element MakeSureYourBusiness => new Element(By.XPath("//h2[@data-qa='wc_thank_you_business_coverage_text']"));

        // Professional Liability(E&O)
        public static Element PLHeader => new Element(By.XPath("//p[@data-qa='lob_accordion_Professional Liability (E&O)']"));
        public static Element PLWhatIsIt => new Element(By.XPath("//span[@data-qa='lob_accordion_Professional Liability (E&O)_what_is_it']"));
        public static Element PLWhyGetIt => new Element(By.XPath("//span[@data-qa='lob_accordion_Professional Liability (E&O)_why_get_it']"));
        public static Element PLExample => new Element(By.XPath("//span[@data-qa='lob_accordion_Professional Liability (E&O)_example']"));
        public static Element GetPLCTA => new Element(By.XPath("//button[@data-qa='lob_accordion_get_Professional Liability (E&O)_button']"));

        // Business Owners (BOP)
        public static Element BOPHeader => new Element(By.XPath("//p[@data-qa='lob_accordion_Business Owners (BOP)']"));
        public static Element BOPWhatIsIt => new Element(By.XPath("//span[@data-qa='lob_accordion_Business Owners (BOP)_what_is_it']"));
        public static Element BOPWhyGetIt => new Element(By.XPath("//span[@data-qa='lob_accordion_Business Owners (BOP)_why_get_it']"));
        public static Element BOPExample => new Element(By.XPath("//span[@data-qa='lob_accordion_Business Owners (BOP)_example']"));
        public static Element GetBOPCTA => new Element(By.XPath("//button[@data-qa='lob_accordion_get_Business Owners (BOP)_button']"));

        //Commercial Auto
        public static Element CAHeader => new Element(By.XPath("//p[@data-qa='lob_accordion_Commercial Auto']"));
        public static Element CAWhatIsIt => new Element(By.XPath("//span[@data-qa='lob_accordion_Commercial Auto_what_is_it']"));
        public static Element CAWhyGetIt => new Element(By.XPath("//span[@data-qa='lob_accordion_Commercial Auto_why_get_it']"));
        public static Element CAExample => new Element(By.XPath("//span[@data-qa='lob_accordion_Commercial Auto_example']"));
        public static Element GetCACTA => new Element(By.XPath("//button[@data-qa='lob_accordion_get_Commercial Auto_button']"));

        // General Liability (GL)
        public static Element GLHeader => new Element(By.XPath("//p[@data-qa='lob_accordion_General Liability']"));
        public static Element GLWhatIsIt => new Element(By.XPath("//span[@data-qa='lob_accordion_General Liability_what_is_it']"));
        public static Element GLWhyGetIt => new Element(By.XPath("//span[@data-qa='lob_accordion_General Liability_why_get_it']"));
        public static Element GLExample => new Element(By.XPath("//span[@data-qa='lob_accordion_General Liability_example']"));
        public static Element GetGLCTA => new Element(By.XPath("//button[@data-qa='lob_accordion_get_General Liability_button']"));

        /*
         * How Would You Rate Our Service?
         */
        public static Element RateOurServiceTitle => new Element(By.XPath("//span[text()='How Would You Rate Our Service?']"));
        public static Element RateOurServiceX => new Element(By.XPath("//*[@id='close_widget_form']"));
    }
}