using BiBerkLOB.Source.Driver.SimpleInteractions;
using BiBerkLOB.StepDefinition.General.Other.Coverages;
using HitachiQA.Driver;
using OpenQA.Selenium;
using System.Collections.Generic;
using BiBerkLOB.Pages.Other;

namespace BiBerkLOB.Pages
{
    [StaticPageName("Cyber Coverage")]
    public sealed class CyberCoveragePage : IStaticPage
    {
        /*
         * Picture Banner - Cyber Insurance
         */
        public static Element CyberInsuranceTitle => new Element(By.XPath("//h1[@data-qa='cyber-insurance']"));
        public static Element ProtectingYourBusinessCopy => new Element(By.XPath("//div[@data-qa='page-banner-subtitle']"));
        public static Element GetAQuote => new Element(By.XPath("//button[@data-qa='page-banner-button']"));

        /*
         * White Banner - Get Financial Protection With Cyber Insurance
         */
        public static Element ReviewRatingText => new Element(By.XPath("//p[@data-qa='review-teaser-text']"));
        public static Element MoreInfoLabel => new Element(By.XPath("//h2[@data-qa='more-info-label']"));

        /*
         * Grey Banner - What is Data Breach Insurance and Cyber Insurance Add-On Coverage?
         */
        public static Element WhatIsDataBreachIns => new Element(By.XPath("//h2[@data-qa='what-is-header']"));
        public static Element WhatIsDataBreachInsText => new Element(By.XPath("//p[@data-qa='what-is-main-text']"));

        /*
         * Blue Banner - Protect Your Business With Cyber Insurance Add-On Coverage
         */
        
        public static Element Dot_Active => new Element(By.XPath("//li[@class='indicator-item active']"));
        public static Element Dot_Inactive => new Element(By.XPath("//li[@class='indicator-item']"));

        /*
         * White Banner - Why biBERK for Cyber Insurance?
         */
        public static Element WhyBiberkForCyberInsHeader => new Element(By.XPath("//h2[@data-qa='why-biberk-header']"));
        public static Element WhyBiberkForCyberInsSubHeader => new Element(By.XPath("//p[@data-qa='subheader-text-label']"));

        /*
         * Light Blue Banner - Why do I Need Cyber Insurance Coverage?
         */
        public static Element WhyDoINeedCyberIns => new Element(By.XPath("//h2[@data-qa='info-image-right-header']"));
        public static Element WhyDoINeedCyberInsParagraph => new Element(By.XPath("//p[contains(text(),'Cyber insurance coverage')]"));
        public static Element WhyDoINeedCyberInsImage => new Element(By.XPath("//img[@data-qa='info-image-right-image']"));

        /*
         * Grey Banner - How Much Does Cyber Insurance Add-On Coverage Cost?
         */
        public static Element HowMuchDoesCyberInsCost => new Element(By.XPath("//h2[@data-qa='how-much-label']"));
        
        //On Average $85-$200 per Year for Base Coverage
        public static Element OnAveragePerYear => new Element(By.XPath("//h6[@data-qa='left-header']"));
        public static Element OnAveragePerYearParagraph => new Element(By.XPath("//h6[@data-qa='left-header']"));
        public static Element GetAQuoteButton => new Element(By.XPath("//div[@data-qa='get-a-quote-button']"));
        public static Element CoverageMap => new Element(By.XPath("//div[@data-qa='coverage-map-button']"));

        //Enjoy Superior Customer Service
        public static Element EnjoySuperiorCustomerService => new Element(By.XPath("//h6[@data-qa='right-header']"));
        public static Element EnjoySuperiorCustomerServiceParagraph => new Element(By.XPath("//p[contains(text(),'When you need assistance of any kind')]"));
        
        //Add Extra Insurance Coverage
        public static Element AddExtraInsCoverage => new Element(By.XPath("(//h6[@class='heavy dark-blue-text'])[3]"));
        public static Element AddExtraInsCoverageParagraph => new Element(By.XPath("//p[contains(text(),'Cyber insurance add-on coverage of')]"));
        public static Element AddExtraInsCoverageList => new Element(By.XPath("//ul[@class='bulleted-no-margins']"));

        /*
         * White Banner - Other Ways You can Protect Your Business With biBERK
         */
        public static Element OtherWaysYouCanProtect => new Element(By.XPath("//h2[@data-qa='protect-your-business-header']"));
        public static Element WeMakeItEasyToSubmitClaims => new Element(By.XPath("//h6[@data-qa='protect-your-business-subheader']"));
        
        // Workers Comp Page
        public static Element WCTitle => new Element(By.XPath("//h4[@data-qa='workers-comp-label']"));
        public static Element WCParagraph => new Element(By.XPath("//p[@data-qa='workers-comp-card-text']"));
        public static Element WCImage => new Element(By.XPath("//img[@data-qa='workers-comp-image']"));

        // Business Owners Policy
        public static Element BOPTitle => new Element(By.XPath("//h4[@data-qa='bop-label']"));
        public static Element BOPParagraph => new Element(By.XPath("//p[@data-qa='bop-card-text']"));
        public static Element BOPImage => new Element(By.XPath("//img[@data-qa='bop-image']"));

        // Commercial Auto
        public static Element CATitle => new Element(By.XPath("//h4[@data-qa='comm-auto-label']"));
        public static Element CAParagraph => new Element(By.XPath("//p[@data-qa='comm-auto-card-text']"));
        public static Element CAImage => new Element(By.XPath("//img[@data-qa='comm-auto-image']"));

        // General Liability
        public static Element GLTitle => new Element(By.XPath("//h4[@data-qa='general-liability-label']"));
        public static Element GLParagraph => new Element(By.XPath("//p[@data-qa='general-liability-card-text']"));
        public static Element GLImage => new Element(By.XPath("//img[@data-qa='general-liability-image']"));

        // Professional Liability
        public static Element PLTitle => new Element(By.XPath("//h4[@data-qa='professional-liability-label']"));
        public static Element PLParagraph => new Element(By.XPath("//p[@data-qa='professional-liability-card-text']"));
        public static Element PLImage => new Element(By.XPath("//img[@data-qa='professional-liability-image']"));

        /*
         * Light Blue Banner - Get a Quote Today
         */
        public static Element GetAQuoteTodayLabel => new Element(By.XPath("//h2[@data-qa='get-a-quote-label']"));
        public static Element AddCyberInsurance => new Element(By.XPath("//p[@data-qa='trust-biberk-quote']"));
        public static Element GetAQuoteCTA => new Element(By.XPath("//a[@data-qa='get-a-quote-button_2']"));

        /*
         * Reusable marketing
         */
        public static Element SaveTime => Reusable_PurchasePath.SaveTime;
        public static Element SaveTimeImage => Reusable_PurchasePath.SaveTimeImage;
        public static Element SaveTimeParagraph => Reusable_PurchasePath.SaveTimeParagraph;
        public static Element SaveMoney => Reusable_PurchasePath.SaveMoney;
        public static Element SaveMoneyImage => Reusable_PurchasePath.SaveMoneyImage;
        public static Element SaveMoneyParagraph => Reusable_PurchasePath.SaveMoneyParagraph;
        public static Element Experienced => Reusable_PurchasePath.Experienced;
        public static Element ExperiencedImage => Reusable_PurchasePath.ExperiencedImage;
        public static Element ExperiencedParagraph => Reusable_PurchasePath.ExperiencedParagraph;

        /*
         * Carousel
         */
        private static Element CarouselImage => new Element(By.XPath("//img[@data-qa='carousel-image']"));
        private static Element Arrow_Right => new Element(By.XPath("//i[@data-qa='right-chevron']"));
        private static Element Arrow_Left => new Element(By.XPath("//i[@data-qa='left-chevron']"));

        //Protect Your Business With Cyber Insurance Add-On Coverage
        private static Element ProtectYourBusiness => new Element(By.XPath("//h2[@data-qa='right-header-text_1']"));
        private static Element ProtectYourBusinessParagraph => new Element(By.XPath("//p[@data-qa='carousel-text_1']"));

        //Cyber Insurance Add-On Coverage for Powerful Peace of Mind
        private static Element CyberInsuranceAddOn => new Element(By.XPath("//h2[@data-qa='right-header-text_2']"));
        private static Element CyberInsuranceAddOnParagraph => new Element(By.XPath("//p[@data-qa='carousel-text_2']"));
        
        public static Dictionary<Element, Element> CarouselTextItems => new Dictionary<Element, Element>
        {
            { ProtectYourBusiness,ProtectYourBusinessParagraph },
            { CyberInsuranceAddOn,CyberInsuranceAddOnParagraph }
        };
        public static IStaticInteraction CyberCarousel => new Carousel(CarouselTextItems, Arrow_Left, Arrow_Right, CarouselImage);

        /*
         * Flip Cards
         */
        //Credit Card Fraud
        private static Element CreditCardFraud => new Element(By.XPath("//h4[@data-qa='card-1-title']"));
        private static Element CreditCardFraudImage => new Element(By.XPath("//img[@data-qa='what-is-card-1']"));
        private static Element CreditCardFraudTextBehind => new Element(By.XPath("//p[@data-qa='broader-coverage-text']"));

        //System Hacks
        private static Element SystemHacks => new Element(By.XPath("//h4[@data-qa='card-2-title']"));
        private static Element SystemHacksImage => new Element(By.XPath("//img[@data-qa='what-is-card-2']"));
        private static Element SystemHacksTextBehind => new Element(By.XPath("//p[@data-qa='card-text_2']"));

        //Credit Card Fraud
        private static Element DataSecurityBreaches => new Element(By.XPath("//h4[@data-qa='card-3-title']"));
        private static Element DataSecurityBreachesImage => new Element(By.XPath("//img[@data-qa='what-is-card-3']"));
        private static Element DataSecurityBreachesTextBehind => new Element(By.XPath("//p[@data-qa='card-text_3']"));

        public static IStaticInteraction CreditCardFraudFlipCard => new FlipCard(CreditCardFraud, CreditCardFraudImage, CreditCardFraudTextBehind);
        public static IStaticInteraction SystemHacksFlipCard => new FlipCard(SystemHacks, SystemHacksImage, SystemHacksTextBehind);
        public static IStaticInteraction DataSecurityBreachesFlipCard => new FlipCard(DataSecurityBreaches, DataSecurityBreachesImage, DataSecurityBreachesTextBehind);
        
    }
}
