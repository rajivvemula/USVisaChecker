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
    class PL_ThankYouPage
    {
        /*
         * Thank You Page
         */
        //Thank You!
        public static Element ThankYouPageTitle => new Element(By.XPath("//h1[@data-qa='thank-you-header']"));
        //Thank you for your business! Welcome to biBERK, part of Warren Buffett's Berkshire Hathaway Company.
        public static Element ThankYouCopy => new Element(By.XPath("//h6[@data-qa='thank-you-subheader']"));
        //Professional Liability(E&O) Policy: [Policy Number]
        public static Element PLPolicyNum => new Element(By.XPath("//span[@data-qa='policy-title']"));
        //Company Name
        public static Element CompanyName => new Element(By.XPath("//h3[@data-qa='insured-name']"));
        public static Element PolicyStart => new Element(By.XPath("//span[@data-qa='policy-start']"));
        //Payment Terms
        public static Element PaymentTermsHeader => new Element(By.XPath("//h6[@data-qa='payment-terms-header']"));
        public static Element PaymentAmount => new Element(By.XPath("//span[@data-qa='payment-amount']"));
        public static Element PaymentFrequency => new Element(By.XPath("//span[@data-qa='installment-message']"));
        public static Element ConfirmationNumber => new Element(By.XPath("//span[@data-qa='payment-confirmation-amount']"));
        //Next Payment Due [Date]
        public static Element NextPaymentDue => new Element(By.XPath("//div[@data-qa='next-payment']"));
        //Get Certificate of Insurance CTA
        public static Element CertificatofInsuranceCTA => new Element(By.XPath("//a[@data-qa='get-COI-button']"));
        //A copy of your policy will be emailed and mailed to you.
        public static Element PolicyEmailed => new Element(By.XPath("//div[@data-qa='coi-email-text']"));
        //Make sure your business is fully covered.
        public static Element BusinessFullyCoveredHeader => new Element(By.XPath("//h5[@data-qa='other-coverage-options-header']"));
        //Commercial Auto
        public static Element CAAccordion => new Element(By.XPath("//div[@data-qa='ca-header']"));
        public static Element CAWhatIsItCopy => new Element(By.XPath("//p[@data-qa='ca-what-is-it-info']"));
        public static Element CAWhyGetItCopy => new Element(By.XPath("//p[@data-qa='ca-why-get-it-info']"));
        public static Element CAExampleCopy => new Element(By.XPath("//p[@data-qa='ca-example']"));
        public static Element CAPCTA => new Element(By.XPath("//a[@data-qa='get-ca-button']"));
        //Workers' Compensation
        public static Element WCAccordion => new Element(By.XPath("//div[@data-qa='wc-header']"));
        public static Element WCWhatIsItCopy => new Element(By.XPath("//p[@data-qa='wc-what-is-it-info']"));
        public static Element WCWhyGetItCopy => new Element(By.XPath("//p[@data-qa='wc-why-get-it-info']"));
        public static Element WCExampleCopy => new Element(By.XPath("//p[@data-qa='wc-example']"));
        public static Element WCCTA => new Element(By.XPath("//a[@data-qa='get-wc-button']"));
        //Business Owners (BOP)
        public static Element BOPAccordion => new Element(By.XPath("//div[@data-qa='bp-header']"));
        public static Element BOPWhatIsItCopy => new Element(By.XPath("//p[@data-qa='bp-what-is-it-info']"));
        public static Element BOPWhyGetItCopy => new Element(By.XPath("//p[@data-qa='bp-why-get-it-info']"));
        public static Element BOPExampleCopy => new Element(By.XPath("//p[@data-qa='bp-example']"));
        public static Element BOPCTA => new Element(By.XPath("//a[@data-qa='get-bp-button']"));
        //General Liability
        public static Element GLAccordion => new Element(By.XPath("//div[@data-qa='gl-header']"));
        public static Element GLWhatIsItCopy => new Element(By.XPath("//p[@data-qa='gl-what-is-it-info']"));
        public static Element GLWhyGetItCopy => new Element(By.XPath("//p[@data-qa='gl-why-get-it-info']"));
        public static Element GLExampleCopy => new Element(By.XPath("//p[@data-qa=' gl-example']"));
        public static Element GLCTA => new Element(By.XPath("//a[@data-qa='get-gl-button']"));

        /*
        * Rate Our Service Modal
        */
        public static Element RateOurServiceTitle => new Element(By.XPath("//span[text()='How Would You Rate Our Service?']"));
        public static Element RateOurServiceX => new Element(By.XPath("//p[@id='close_widget_form']"));
        public static Element ClickNumStars => new Element(By.XPath("//h3[@class='form__elem__title']"));
        public static Element UnselectedStarOne => new Element(By.XPath("//div[@class='feedback__container feedback__continuous__container']/div/div/div[2]"));
        public static Element UnselectedStarTwo => new Element(By.XPath("//div[@class='feedback__container feedback__continuous__container']/div/div/div[3]"));
        public static Element UnselectedStarThree => new Element(By.XPath("//div[@class='feedback__container feedback__continuous__container']/div/div/div[4]"));
        public static Element UnselectedStarFour => new Element(By.XPath("//div[@class='feedback__container feedback__continuous__container']/div/div/div[5]"));
        public static Element UnselectedStarFive => new Element(By.XPath("//div[@class='feedback__container feedback__continuous__container']/div/div/div[6]"));
        public static Element SelectedStarOne => new Element(By.XPath("(//i[@class='ico ico-star-selected icomoon-sudo'])[1]"));
        public static Element SelectedStarTwo => new Element(By.XPath("(//i[@class='ico ico-star-selected icomoon-sudo'])[2]"));
        public static Element SelectedStarThree => new Element(By.XPath("(//i[@class='ico ico-star-selected icomoon-sudo'])[3]"));
        public static Element SelectedStarFour => new Element(By.XPath("(//i[@class='ico ico-star-selected icomoon-sudo'])[4]"));
        public static Element SelectedStarFive => new Element(By.XPath("(//i[@class='ico ico-star-selected icomoon-sudo'])[5]"));
        public static Element EmailAddressTxtbox => new Element(By.XPath("//div[@class='caption-form__wrap']//input"));
        public static Element FeedbackTitle => new Element(By.XPath("//h3[text()='Your personal feedback:']"));
        public static Element FeedbackParagraph => new Element(By.XPath("//p[starts-with(text(),'We would like to know')]"));
        public static Element FeedbackTxtbox => new Element(By.XPath("//textarea[@name='question_476066']"));
        public static Element FeedbackRemainingChar => new Element(By.XPath("//span[@class='show_remaining_chars_message smt_add_minimum_characters']"));
        public static Element SubmitCTA => new Element(By.XPath("//button[@id='form_submit_btn']"));
    }

}
