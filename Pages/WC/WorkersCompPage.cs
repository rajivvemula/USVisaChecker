using BiBerkLOB.StepDefinition.General.Other.Coverages;
using HitachiQA.Driver;
using OpenQA.Selenium;
using System.Collections.Generic;
using BiBerkLOB.Pages.Other;
using BiBerkLOB.Source.Driver.SimpleInteractions;

namespace BiBerkLOB.Pages
{
    [StaticPageName("WC Coverage")]
    public class WorkersCompPage : IStaticPage
    {
        // Title - Workers’ Compensation Insurance
        public static Element WCInsuranceTitle => new Element(By.XPath("//h1[@data-qa='workers-compensation-insurance']"));
        // Title - Protect your employees, your business, and your peace of mind with a policy from biBERK.
        public static Element ProtectYourEmpAndBusiness => new Element(By.XPath("//div[@data-qa='page-banner-subtitle']"));
        // Get a Quote CTA Under: Title - Protect your employees, your business, and your peace of mind with a policy from biBERK.
        public static Element GetAQuteCTA => new Element(By.XPath("//button[@data-qa='page-banner-button']"));

        /*
         * White Banner with Small Business Insurance Experts, 3 Boxes of Save Time/Save Money/Experienced
         */
        // Title - Small Business Insurance Experts
        public static Element GetTheInsYourBusiness => new Element(By.XPath("//h2[@data-qa='why-biberk-header']"));
        public static Element GetTheInsYourBusinessParagraph => new Element(By.XPath("//p[@data-qa='subheader-text-label_2']"));
       
        // Picture Box - Save Time
        public static Element PicSaveTime => new Element(By.XPath("(//div[@class='card-content white-text'])[1]"));
        public static Element PicSaveTimeImage => new Element(By.XPath("(//img[@data-qa='three-column-about-card1-image'])"));
        public static Element PicSaveTimeTitle => new Element(By.XPath("//h3[@data-qa='three-column-about-card1-title']"));
        public static Element PicSaveTimeParagraph => new Element(By.XPath("//p[@data-qa='three-column-about-card1-text']"));

        // Picture Box - Save Money
        public static Element PicSaveMoney => new Element(By.XPath("(//div[@class='card-content white-text'])[2]"));
        public static Element PicSaveMoneyImage => new Element(By.XPath("(//img[@data-qa='three-column-about-card2-image'])"));
        public static Element PicSaveMoneyTitle => new Element(By.XPath("//h3[@data-qa='three-column-about-card2-title']"));
        public static Element PicSaveMoneyParagraph => new Element(By.XPath("//p[@data-qa='three-column-about-card2-text']"));

        // Picture Box - Experienced
        public static Element PicExperienced => new Element(By.XPath("//h3[@data-qa='three-column-about-card3-title']"));
        public static Element PicExperiencedImage => new Element(By.XPath("//img[@data-qa='three-column-about-card3-image']"));
        public static Element PicExperiencedTitle => new Element(By.XPath("//h3[@data-qa='three-column-about-card3-title']"));
        public static Element PicExperiencedParagraph => new Element(By.XPath("//p[@data-qa='three-column-about-card3-text']"));

        /*
         * Grey Banner - Determine Your Insurance Costs With A Workers' Compensation Insurance Quote
         */
        //Determine Your Insurance Costs With a Workers' Compensation Insurance Quote
        public static Element DetermineYourCosts => new Element(By.XPath("//h2[@data-qa='more-info-main-header' and text()='Determine Your Insurance Costs With a Workers’ Compensation Insurance Quote']"));
        //The best way to understand what this type of small business coverage will cost is to get a [link]. 
        //In just a few minutes spent online or on the phone with one of our insurance experts, you can get a quote and be ready to purchase worker's comp insurance that will provide fainancial protection and peace of mind.
        public static Element DetermineYourCostsParagraph => new Element(By.XPath("//p[@data-qa='more-info-main-text']"));
        //hyperlink text in paragraph above - workers' compensation insurance quote
        public static Element DetermineYourCostsLink => new Element(By.XPath("//a[@data-qa='Get a Quote link']"));

        /*
         * Blue Banner - Save up to 20% on Workers' Comp Insurance Coverage / Workers' Compensation Insurance Helps Pay Work-Related Injury Bills
         */
        public static Element SaveTwentyPercentLink => new Element(By.XPath("//p[@data-qa='info-image-carousel-image-left-slide1-text']/a"));
        
        
        /*
         * White Banner - Does My Business Need Workers' Compensation Insurance?
         */

        // Title - Does My Business Need Workers' Compensation Insurance?
        public static Element WhyNeedWC => new Element(By.XPath("//h2[@data-qa='state-selector-header']"));
        //If you have employees, then you should buy workers' compensation insurance.  Most states require it if you have even one employee or one subcontractor.
        //If you don't have coverage, you face state fines and penalities - even if you never file a claim.  You could also get stuck with unexpected costs you have to pay out of your own pocket.
        //Workers' comp insurance coverage gives your employees and their families peace of mind knowing they won't have to pay for medical treatment or other injury-related expenses.
        public static Element WhyNeedWCParagraph1 => new Element(By.XPath("//p[@data-qa='wc-coverage-text_1']"));
        public static Element WhyNeedWCParagraph2 => new Element(By.XPath("//p[@data-qa='wc-coverage-text_2']"));
        // Title - Find your insurance coverage options.
        public static Element FindInsCoverOpts => new Element(By.XPath("//h3[@data-qa='dropdown-header']"));
        // Dropdown - Choose a state
        public static Element ChooseAStateDD => new Element(By.XPath("//input[@data-qa='state-dropdown-trigger']"));
        // Search button under: Dropdown - Choose a state
        public static Element SearchStateDD => new Element(By.XPath("//a[@data-qa='state-dropdown-button']"));
        
        /*
         * Blue Banner - Does Workers' Compensation Insurance Cover Employees Who Contract COVID-19?
         */
        public static Element Covid19Title => new Element(By.XPath("//h2[contains(text(), 'Does Workers’ Compensation Insurance Cover Employees Who Contract COVID-19?')]"));
        //It can, if they contract the disease while at work.  Workers' compensation insurance is designed to address work-related injuries and illnesses.
        //For example, if a nurse treating someone with COVID-19 soon after develops the illness, this might be covered by workers' comp insurance.  Some states may help cover COVID-19-related costs as well, so it's important to do your research.
        public static Element Covid19Paragraph => new Element(By.XPath("//p[@data-qa='wc-covid-main-text']"));

        /*
         * Grey Banner - What is Workers' Compensation Insurance?
         */
        // Title - What is Workers' Compensation Insurance?
        public static Element WhatIsWCIns => new Element(By.XPath("//h2[@data-qa='what-is-header']"));
        //Workers' compensation insurance - commonly called "workers' comp" or "workman's comp"- is an often-mandatory type of insurance that protects both your employees and your company if an employee experiences an injury or diesease while at work, including strains, trip and falls, or accidental death.
        public static Element WhatIsWCInsParagraph => new Element(By.XPath("(//p[@data-qa='what-is-main-text'])[2]"));
        
        /*
         * Grey Banner - How do I Save Money on My Workers' Comp Policy?
         */

        // Title - How do I Save Money on My Policy?
        public static Element SaveMoneyOnPolicy => new Element(By.XPath("//h2[@data-qa='two-columns-with-header-header']"));
        public static Element SaveMoneyOnPolicySubTitle => new Element(By.XPath("//p[@data-qa='save-money-lead-text']"));

        //Understand Who Needs to be Covered
        public static Element UnderstandWhoNeeds => new Element(By.XPath("//h6[@data-qa='two-columns-with-header-col-one-row-one-header']"));
        public static Element UnderstandWhoNeedsParagraph => new Element(By.XPath("//p[@data-qa='column-1-text']"));

        //Manage Your Risks
        public static Element ManageYourRisks => new Element(By.XPath("//h6[@data-qa='two-columns-with-header-col-two-row-one-header']"));
        public static Element ManageYourRisksParagraph => new Element(By.XPath("//p[@data-qa='column-2-text_1']"));
        // Link - Loss Control under: Title - How do I Save Money on My Policy?
        public static Element ManageYourRisksLink => new Element(By.XPath("//p[@data-qa='column-2-text_1']/a"));

        //Add a Small Deductible
        public static Element AddASmallDeductible => new Element(By.XPath("//h6[@data-qa='two-columns-with-header-col-two-row-two-header']"));
        public static Element AddASmallDeductibleParagraph => new Element(By.XPath("//p[@data-qa='column-2-text_2']"));

        
        /*
         *  Blue Banner - Get a Workers' Comp Insurance Quote Today
         */
        // Title - Get a Quote Today (bottom of the screen)
        public static Element GetQuoteToday => new Element(By.XPath("//h2[@data-qa='get-a-quote-label']"));
        // Get a Quote CTA under: Title - Get a Quote Today (bottom of the screen)
        public static Element TrustbiBERK => new Element(By.XPath("//p[@data-qa='trust-biberk-quote']"));
        public static Element BottomGetAQuoteCTA => new Element(By.XPath("//a[@data-qa='get-a-quote-button_2']"));
        
        /*
         * Flip Cards
         */
        private static Element FewerHighFront => new Element(By.XPath("//h4[@data-qa='card-1-title']"));
        private static Element FewerHighBehind => new Element(By.XPath("//p[@data-qa='broader-coverage-text']"));
        private static Element FewerHighImage => new Element(By.XPath("//img[@data-qa='what-is-card-1']"));

        private static Element ProtectFromLawsuitsFront => new Element(By.XPath("//h4[@data-qa='card-2-title']"));
        private static Element ProtectFromLawsuitsBehind => new Element(By.XPath("//p[@data-qa='card-text_2']"));
        private static Element ProtectionFromLawsuitsImage => new Element(By.XPath("//img[@data-qa='what-is-card-2']"));
        
        private static Element ComplianceFront => new Element(By.XPath("//h4[@data-qa='card-3-title']"));
        private static Element ComplianceBehind => new Element(By.XPath("//p[@data-qa='card-text_3']"));
        private static Element ComplianceImage => new Element(By.XPath("//img[@data-qa='what-is-card-3']"));

        public static IStaticInteraction AnimationFewerHighFlipCard => new FlipCard(FewerHighFront, FewerHighImage, FewerHighBehind);
        public static IStaticInteraction AnimationProtectFromLawsuitsFlipCard => new FlipCard(ProtectFromLawsuitsFront, ProtectionFromLawsuitsImage, ProtectFromLawsuitsBehind);
        public static IStaticInteraction AnimationComplyStateLawsFlipCard => new FlipCard(ComplianceFront, ComplianceImage, ComplianceBehind);
        
        /*
         * Carousel
         */
        private static Element CarouselRightArrow => new Element(By.XPath("//i[@data-qa='info-image-carousel-image-left-chevron-next']"));
        private static Element CarouselLeftArrow => new Element(By.XPath("//i[@data-qa='info-image-carousel-image-left-chevron-previous']"));
        private static Element CarouselImage => new Element(By.XPath("//img[@data-qa='info-image-carousel-image-left']"));

        private static Element SaveTwentyPercent => new Element(By.XPath("//h2[@data-qa='info-image-carousel-image-left-slide1-header']"));
        private static Element SaveTwentyPercentParagraph => new Element(By.XPath("//p[@data-qa='info-image-carousel-image-left-slide1-text']"));

        private static Element HelpPayingWorkRelatedInjury => new Element(By.XPath("//h2[@data-qa='info-image-carousel-image-left-slide2-header']"));
        private static Element HelpPayingWorkRelatedInjuryParagraph => new Element(By.XPath("//p[@data-qa='info-image-carousel-image-left-slide2-text']"));

        public static Dictionary<Element, Element> CarouselTextItems => new Dictionary<Element, Element>
        {
            { SaveTwentyPercent,SaveTwentyPercentParagraph },
            { HelpPayingWorkRelatedInjury,HelpPayingWorkRelatedInjuryParagraph }
        };
        public static IStaticInteraction WCCarousel => new Carousel(CarouselTextItems, CarouselLeftArrow, CarouselRightArrow, CarouselImage);

        /*
         * Grey Banner - Workers' Compensation Insurance Frequently Asked Questions
         */
        //Workers' Compensation Insurance Frequently Asked Questions
        public static Element WCFAQ => new Element(By.XPath("//h2[@data-qa='faq-header']"));
        //Our insurance experts are happy to assist you, but answers to some of the workers' compensation insurance questions we get asked most frequently are below.
        public static Element WCFAQParagraph => new Element(By.XPath("//p[@data-qa='faq-subheader']"));

        //What is workers’ compensation insurance?
        private static Element WhatWCIns => new Element(By.XPath("//h3[@data-qa='faq-question-1-question']"));
        private static Element WhatWCInsParagraph => new Element(By.XPath("//p[@data-qa='faq-text-item_1']"));
        private static Element WhatWCInsArrow => new Element(By.XPath("//i[@data-qa='faq-question-1-arrow']"));

        //What does workers’ compensation insurance not cover?
        private static Element WhatWCCover => new Element(By.XPath("//h3[@data-qa='faq-question-2-question']"));
        private static Element WhatWCCoverParagraph => new Element(By.XPath("//p[@data-qa='faq-text-item_2']"));
        private static Element WhatWCCoverArrow => new Element(By.XPath("//i[@data-qa='faq-question-2-arrow']"));

        //What does workers’ compensation insurance not cover?
        private static Element WhatWCNotCover => new Element(By.XPath("//h3[@data-qa='faq-question-3-question']"));
        private static Element WhatWCNotCoverParagraph => new Element(By.XPath("//p[@data-qa='faq-text-item_3']"));
        private static Element WhatWCNotCoverArrow => new Element(By.XPath("//i[@data-qa='faq-question-2-arrow']"));

        //How long does workers’ comp last?
        private static Element HowLongWC => new Element(By.XPath("//h3[@data-qa='faq-question-4-question']"));
        private static Element HowLongWCParagraph => new Element(By.XPath("//p[@data-qa='faq-text-item_4']"));
        private static Element HowLongWCArrow => new Element(By.XPath("//i[@data-qa='faq-question-4-arrow']"));

        //Who pays for workers’ compensation?
        private static Element WhoPaysWC => new Element(By.XPath("//h3[@data-qa='faq-question-5-question']"));
        private static Element WhoPaysWCParagraph => new Element(By.XPath("//p[@data-qa='faq-text-item_5']"));
        private static Element WhoPaysWCArrow => new Element(By.XPath("//i[@data-qa='faq-question-5-arrow']"));

        //Does my business need workers’ compensation insurance?
        private static Element DoINeedWC => new Element(By.XPath("//h3[@data-qa='faq-question-6-question']"));
        private static Element DoINeedWCParagraph => new Element(By.XPath("//p[@data-qa='faq-text-item_6']"));
        private static Element DoINeedWCArrow => new Element(By.XPath("//i[@data-qa='faq-question-6-arrow']"));

        //What does workers’ compensation insurance cost?
        private static Element WhatDoesWCCost => new Element(By.XPath("//h3[@data-qa='faq-question-7-question']"));
        private static Element WhatDoesWCCostParagraph => new Element(By.XPath("//p[@data-qa='faq-text-item_7']"));
        private static Element WhatDoesWCCostArrow => new Element(By.XPath("//i[@data-qa='faq-question-7-arrow']"));

        //Do I need workers’ comp insurance coverage as a self-employed business owner?
        private static Element DoINeedWCSelfEmp => new Element(By.XPath("//h3[@data-qa='faq-question-8-question']"));
        private static Element DoINeedWCSelfEmpParagraph => new Element(By.XPath("//p[@data-qa='faq-text-item_8']"));
        private static Element DoINeedWCSelfEmpArrow => new Element(By.XPath("//i[@data-qa='faq-question-8-arrow']"));

        //Does biBERK provide workers’ comp insurance in my state?
        private static Element ProvideWCInState => new Element(By.XPath("//h3[@data-qa='faq-question-9-question']"));
        private static Element ProvideWCInStateParagraph => new Element(By.XPath("//p[@data-qa='faq-text-item_9']"));
        private static Element ProvideWCInStateArrow => new Element(By.XPath("//i[@data-qa='faq-question-9-arrow']"));

        //Are seasonal workers covered by workers’ compensation insurance?
        private static Element SeasonalCovered => new Element(By.XPath("//h3[@data-qa='faq-question-10-question']"));
        private static Element SeasonalCoveredParagraph => new Element(By.XPath("//p[@data-qa='faq-text-item_10']"));
        private static Element SeasonalCoveredArrow => new Element(By.XPath("//i[@data-qa='faq-question-10-arrow']"));

        //If my business makes changes, how will it affect my workers’ comp insurance?
        private static Element ChangesAffectWC => new Element(By.XPath("//h3[@data-qa='faq-question-11-question']"));
        private static Element ChangesAffectWCParagraph => new Element(By.XPath("//p[@data-qa='faq-text-item_11']"));
        private static Element ChangesAffectWCArrow => new Element(By.XPath("//i[@data-qa='faq-question-11-arrow']"));

        public static IStaticInteraction WhatWCInsFAQ => new CoveragePageFAQ(WhatWCIns, WhatWCInsParagraph, WhatWCInsArrow);
        public static IStaticInteraction WhatWCCoverFAQ => new CoveragePageFAQ(WhatWCCover, WhatWCCoverParagraph, WhatWCCoverArrow);
        public static IStaticInteraction WhatWCNotCoverFAQ => new CoveragePageFAQ(WhatWCNotCover, WhatWCNotCoverParagraph, WhatWCNotCoverArrow);
        public static IStaticInteraction HowLongWCFAQ => new CoveragePageFAQ(HowLongWC, HowLongWCParagraph, HowLongWCArrow);
        public static IStaticInteraction WhoPaysWCFAQ => new CoveragePageFAQ(WhoPaysWC, WhoPaysWCParagraph, WhoPaysWCArrow);
        public static IStaticInteraction DoINeedWCFAQ => new CoveragePageFAQ(DoINeedWC, DoINeedWCParagraph, DoINeedWCArrow);
        public static IStaticInteraction WhatDoesWCCostFAQ => new CoveragePageFAQ(WhatDoesWCCost, WhatDoesWCCostParagraph, WhatDoesWCCostArrow);
        public static IStaticInteraction DoINeedWCSelfEmpFAQ => new CoveragePageFAQ(DoINeedWCSelfEmp, DoINeedWCSelfEmpParagraph, DoINeedWCSelfEmpArrow);
        public static IStaticInteraction ProvideWCInStateFAQ => new CoveragePageFAQ(ProvideWCInState, ProvideWCInStateParagraph, ProvideWCInStateArrow);
        public static IStaticInteraction SeasonalCoveredFAQ => new CoveragePageFAQ(SeasonalCovered, SeasonalCoveredParagraph, SeasonalCoveredArrow);
        public static IStaticInteraction ChangesAffectWCFAQ => new CoveragePageFAQ(ChangesAffectWC, ChangesAffectWCParagraph, ChangesAffectWCArrow);
        
        /*
         * White Banner - Coverage for Independent Contractors and Subcontractors / Determining the Cost of Workers' Comp Insurance Coverage
         */
        // Policy Cost Tab
        private static Element PolicyCostTab => new Element(By.XPath("//a[@data-qa='info-image-with-tabs-tab-1-label']"));
        private static Element PolicyCostTitle => new Element(By.XPath("//h2[@data-qa='info-image-with-tabs-tab-1-header']"));
        private static Element PolicyCostParagraph => new Element(By.XPath("//p[@data-qa='info-image-with-tabs-tab-1-text-0']"));

        // Independent Contractors Tab
        private static Element IndependContrTab => new Element(By.XPath("//a[@data-qa='info-image-with-tabs-tab-2-label']"));
        private static Element IndependContrTitle => new Element(By.XPath("//h2[@data-qa='info-image-with-tabs-tab-2-header']"));
        private static Element IndependContrParagraph => new Element(By.XPath("//p[@data-qa='info-image-with-tabs-tab-2-text-0']"));
        
        public static IStaticInteraction PolicyCostTabBanner => new WCDeterminingCostTab(PolicyCostTab, PolicyCostTitle, PolicyCostParagraph);
        public static IStaticInteraction IndependContrTabBanner => new WCDeterminingCostTab(IndependContrTab, IndependContrTitle, IndependContrParagraph);
        
    }
}