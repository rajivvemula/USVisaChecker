using BiBerkLOB.StepDefinition.General.Other.Coverages;
using HitachiQA.Driver;
using OpenQA.Selenium;
using BiBerkLOB.Pages.Other;
using BiBerkLOB.Source.Driver.SimpleInteractions;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.UM
{
    [StaticPageName("Umbrella Coverage")]
    public sealed class UMPage : IStaticPage
    {
        /*
         * Photo Banner - Umbrella Insurance
         */
        public static Element UmbrellaIns => new Element(By.XPath("//h1[@data-qa='umbrella-insurance']"));
        public static Element UmbrellaIns_Subtitle => new Element(By.XPath("//div[@data-qa='page-banner-subtitle']"));
        public static Element UmbrellaIns_GetAQuoteCTA => new Element(By.XPath("//button[@data-qa='page-banner-button']"));

        /*
         * White Banner - Increase Your Financial Protection with Umbrella Insurance
         */
        //4.9 out of 5 customer review rating and 150,000+ policies sold. is mapped on Reusable_PurchasePath.cs

        //Increase Your Financial Protection with Umbrella Insurance
        public static Element IncreaseFinanProtec => new Element(By.XPath("//h2[@data-qa='umbrella-protection-label']"));
        public static Element IncreaseFinanProtecParagraph => new Element(By.XPath("//p[@data-qa='umbrella-intro-text']"));

        //What is Small Business Umbrella Insurance?
        public static Element WhatSmBusUm => new Element(By.XPath("//h6[@data-qa='umbrella-what-is-label']"));
        //An umbrella insurance policy helps cover costs associated with:
        public static Element WhatSmBusUmSubtitle => new Element(By.XPath("//p[@data-qa='list-intro-text']"));
        //Bodily injury and related medical expenses, Product liability, Customer property damage....
        public static Element WhatSmBusUmList => new Element(By.XPath("//ul[@data-qa='umbrella-checked-list']"));
        //In New York for biBERK, umbrella insurance is known as commercial excess insurance.
        public static Element WhatSmBusUmNYCX => new Element(By.XPath("//p[@data-qa='first-card-bottom-text']"));

        //How Does Umbrella Insurance Work?
        public static Element HowUMWork => new Element(By.XPath("//h6[@data-qa='what-is-label']"));
        public static Element HowUMWorkParagraph_When => new Element(By.XPath("//p[@data-qa='second-card-first-text']"));
        public static Element HowUMWorkParagraph_Keep => new Element(By.XPath("//p[@data-qa='second-card-second-text']"));
        public static Element HowUMWork_1YouAlready => new Element(By.XPath("//p[@data-qa='second-card-numbered-item']"));
        public static Element HowUMWork_1YouAlreadyText => new Element(By.XPath("//p[@data-qa='second-card-numbered-item']/..//p[contains(text(), 'For example')]"));
        public static Element HowUMWork_2TheLimits => new Element(By.XPath("//p[@data-qa='second-card-second-numbered-item']"));

        /*
         * Blue Banner - An Example of Umbrella Insurance in Action
         */
        public static Element ExOfUmInAction => new Element(By.XPath("//h2[@data-qa='info-image-left-header']"));
        public static Element ExOfUmInActionParagraph => new Element(By.XPath("//p[@data-qa='info-image-left-text-0']"));
        public static Element ExOfUmInActionImage => new Element(By.XPath("//img[@data-qa='info-image-left-image']"));

        /*
         * White Banner - Why biBERK Commercial Umbrella Insurance?
         */
        public static Element whyBiberk => new Element(By.XPath("//h2[@data-qa='why-biberk-header']"));
        public static Element whyBiberkSubitle => new Element(By.XPath("//p[@data-qa='subheader-text-label_2']"));
        public static Element SaveTime => new Element(By.XPath("//h3[@data-qa='three-column-about-card1-title']"));
        public static Element SaveTimeImage => new Element(By.XPath("//img[@data-qa='three-column-about-card1-image']"));
        public static Element SaveTimeParagraph => new Element(By.XPath("//p[@data-qa='three-column-about-card1-text']"));
        public static Element SaveMoney => new Element(By.XPath("//h3[@data-qa='three-column-about-card2-title']"));
        public static Element SaveMoneyImage => new Element(By.XPath("//img[@data-qa='three-column-about-card2-image']"));
        public static Element SaveMoneyParagraph => new Element(By.XPath("//p[@data-qa='three-column-about-card2-text']"));
        public static Element Experienced => new Element(By.XPath("//h3[@data-qa='three-column-about-card3-title']"));
        public static Element ExperiencedImage => new Element(By.XPath("//img[@data-qa='three-column-about-card3-image']"));
        public static Element ExperiencedParagraph => new Element(By.XPath("//p[@data-qa='three-column-about-card3-text']"));


        /*
         * Blue Banner - Do I Need a Business Umbrella Policy?
         */
        public static Element DoINeedUM => new Element(By.XPath("//h2[@data-qa='info-image-right-header']"));
        public static Element DoINeedUMParagraph => new Element(By.XPath("(//p[@data-qa='info-image-right-text-0'])[1]"));
        public static Element DoINeedUMImage => new Element(By.XPath("//img[@data-qa='info-image-right-image']"));
        //business umbrella policy
        public static Element DoINeedUMLink => new Element(By.XPath("//a[@data-qa='business-umbrella-policy-link'] | //a[text()='business umbrella policy']"));

        /*
         * Grey Banner - What Does a Business Umbrella Policy NOT Cover?
         */
        public static Element BusUMNotCover => new Element(By.XPath("//h2[@data-qa='two-columns-with-header-header']"));
        public static Element BusUMNotCoverSubtitle => new Element(By.XPath("//p[@data-qa='two-column-list-intro-text']"));

        public static Element BusUMNotCover_IntenDamage => new Element(By.XPath("//h6[@data-qa='two-columns-with-header-col-one-row-one-header']"));
        public static Element BusUMNotCover_IntenDamageParagraph => new Element(By.XPath("//p[@data-qa='info-text_1']"));
        public static Element BusUMNotCover_ContractLiab => new Element(By.XPath("//h6[@data-qa='two-columns-with-header-col-two-row-one-header']"));
        public static Element BusUMNotCover_ContractLiabParagraph => new Element(By.XPath("//p[@data-qa='info-text_3']"));
        public static Element BusUMNotCover_DmgToProp => new Element(By.XPath("//h6[@data-qa='two-columns-with-header-col-one-row-two-header']"));
        public static Element BusUMNotCover_DmgToPropParagraph => new Element(By.XPath("//p[@data-qa='info-text_2']"));
        public static Element BusUMNotCover_LiabWar => new Element(By.XPath("//h6[@data-qa='two-columns-with-header-col-two-row-two-header']"));
        public static Element BusUMNotCover_LiabWarParagraph => new Element(By.XPath("//p[@data-qa='info-text-4']"));
        public static Element BusUMNotCoverJustFewExamples => new Element(By.XPath("//p[@data-qa='bottom-info-text']"));

        /*
         * White Banner - Enjoy Superior Customer Service from biBERK
         */
        public static Element SuperiorCust => new Element(By.XPath("(//h2[@data-qa='info-image-right-header'])[2]"));
        public static Element SuperiorCustParagraph => new Element(By.XPath("(//p[@data-qa='info-image-right-text-0'])[2]"));
        //licensed experts are just a phone call, email, or chat away
        public static Element SuperiorCustLink => new Element(By.XPath("//a[@data-qa='contact-link'] | //a[text()='licensed experts are just a phone call, email, or chat away']"));
        public static Element SuperiorCustImage => new Element(By.XPath("(//img[@data-qa='info-image-right-image'])[2]"));

        /*
         * Grey Banner - How Much Does Umbrella Insurance Cost?
         */
        public static Element HowMuchUmCost => new Element(By.XPath("//h2[@data-qa='how-much-label']"));
        //On Average $200-$400 per Year
        public static Element AvgCost => new Element(By.XPath("//h6[@data-qa='left-header']"));
        public static Element AvgCostParagraph => new Element(By.XPath("//p[@data-qa='first-text-left']"));

        //Add Extra Insurance Coverage
        public static Element AddExCov => new Element(By.XPath("//h6[@data-qa='right-header']"));
        public static Element AddExCovParagraph => new Element(By.XPath("//p[@data-qa='second-text-right']"));
        //Business activities, Number of employees, Annual revenue, Industry...
        public static Element AddExCovList => new Element(By.XPath("//ul[@data-qa='second-text-right-list']"));

        public static Element GetAQuoteCTA => new Element(By.XPath("//div[@data-qa='get-a-quote-button']"));
        public static Element CoverageMapCTA => new Element(By.XPath("//div[@data-qa='coverage-map-button']"));

        /*
         * White Banner - Other Ways to Protect Your Business with Insurance From biBERK
         */
        public static Element OtherWaysToProtectBus => new Element(By.XPath("//h2[@data-qa='protect-your-business-header']"));
        public static Element OtherWaysToProtectBusSubtitle => new Element(By.XPath("//h6[@data-qa='protect-your-business-subheader']"));

        public static Element OtherWaysProtectWC => new Element(By.XPath("//h4[@data-qa='workers-comp-label']"));
        public static Element OtherWaysProtectWCParagraph => new Element(By.XPath("//p[@data-qa='workers-comp-card-text']"));
        public static Element OtherWaysProtectWCImage => new Element(By.XPath("//img[@data-qa='workers-comp-image']"));
        public static Element OtherWaysProtectBOP => new Element(By.XPath("//h4[@data-qa='bop-label']"));
        public static Element OtherWaysProtectBOPParagraph => new Element(By.XPath("//p[@data-qa='bop-card-text']"));
        public static Element OtherWaysProtectBOPImage => new Element(By.XPath("//img[@data-qa='bop-image']"));
        public static Element OtherWaysProtectGL => new Element(By.XPath("//h4[@data-qa='general-liability-label']"));
        public static Element OtherWaysProtectGLParagraph => new Element(By.XPath("//p[@data-qa='general-liability-card-text']"));
        public static Element OtherWaysProtectGLImage => new Element(By.XPath("//img[@data-qa='general-liability-image']"));
        public static Element OtherWaysProtectPL => new Element(By.XPath("//h4[@data-qa='professional-liability-label']"));
        public static Element OtherWaysProtectPLParagraph => new Element(By.XPath("//p[@data-qa='professional-liability-card-text']"));
        public static Element OtherWaysProtectPLImage => new Element(By.XPath("//img[@data-qa='professional-liability-image']"));
        public static Element OtherWaysProtectCA => new Element(By.XPath("//h4[@data-qa='comm-auto-label']"));
        public static Element OtherWaysProtectCAParagraph => new Element(By.XPath("//p[@data-qa='comm-auto-card-text']"));
        public static Element OtherWaysProtectCAImage => new Element(By.XPath("//img[@data-qa='comm-auto-image']"));
        public static Element OtherWaysProtectCI => new Element(By.XPath("//h4[@data-qa='cyber-label']"));
        public static Element OtherWaysProtectCIParagraph => new Element(By.XPath("//p[@data-qa='cyber-card-text']"));
        public static Element OtherWaysProtectCIImage => new Element(By.XPath("//img[@data-qa='cyber-image']"));

        /*
         * Grey Banner - Umbrella Insurance Frequently Asked Questions (FAQs)
         */
        public static Element UMFAQ => new Element(By.XPath("//h2[@data-qa='faq-header']"));
        public static Element UMFAQSubtitle => new Element(By.XPath("(//p[@data-qa='faq-subheader'])[2]"));

        /*
         * Blue Banner - Get an Umbrella Insurance Quote Today
         */
        public static Element GetUMIns => new Element(By.XPath("//h2[@data-qa='get-a-quote-label']"));
        public static Element GetUMInsSubtitle => new Element(By.XPath("//p[@data-qa='trust-biberk-quote']"));
        public static Element GetUMIns_GetAQuoteCTA => new Element(By.XPath("//a[@data-qa='get-a-quote-button_2']"));

        /*
         * FAQs
         */
        private static Element UMFAQ_WhatUMIns => new Element(By.XPath("//h3[@data-qa='faq-question-1-question']"));
        private static Element UMFAQ_WhatUMInsParagraph => new Element(By.XPath("//p[@data-qa='faq-item-1-text']"));
        private static Element UMFAQ_WhatUMInsArrow => new Element(By.XPath("//i[@data-qa='faq-question-1-arrow']"));

        private static Element UMFAQ_WhatCovered => new Element(By.XPath("//h3[@data-qa='faq-question-2-question']"));
        private static Element UMFAQ_WhatCoveredParagraph => new Element(By.XPath("//p[@data-qa='faq-item-2-text']"));
        private static Element UMFAQ_WhatCoveredArrow => new Element(By.XPath("//i[@data-qa='faq-question-2-arrow']"));

        private static Element UMFAQ_WhatNotCovered => new Element(By.XPath("//h3[@data-qa='faq-question-3-question']"));
        private static Element UMFAQ_WhatNotCoveredParagraph => new Element(By.XPath("//p[@data-qa='faq-item-3-text']"));
        private static Element UMFAQ_WhatNotCoveredArrow => new Element(By.XPath("//i[@data-qa='faq-question-3-arrow']"));

        private static Element UMFAQ_NeedUM => new Element(By.XPath("//h3[@data-qa='faq-question-4-question']"));
        private static Element UMFAQ_NeedUMParagraph => new Element(By.XPath("//p[@data-qa='faq-item-4-text']"));
        private static Element UMFAQ_NeedUMArrow => new Element(By.XPath("//i[@data-qa='faq-question-4-arrow']"));

        private static Element UMFAQ_HowMuchNeed => new Element(By.XPath("//h3[@data-qa='faq-question-5-question']"));
        private static Element UMFAQ_HowMuchNeedParagraph => new Element(By.XPath("//p[@data-qa='faq-item-5-text']"));
        private static Element UMFAQ_HowMuchNeedArrow => new Element(By.XPath("//i[@data-qa='faq-question-5-arrow']"));

        public static IStaticInteraction UMFAQ_WhatUMInsFAQ => new CoveragePageFAQ(UMFAQ_WhatUMIns, UMFAQ_WhatUMInsParagraph, UMFAQ_WhatUMInsArrow);
        public static IStaticInteraction UMFAQ_WhatCoveredFAQ => new CoveragePageFAQ(UMFAQ_WhatCovered, UMFAQ_WhatCoveredParagraph, UMFAQ_WhatCoveredArrow);
        public static IStaticInteraction UMFAQ_WhatNotCoveredFAQ => new CoveragePageFAQ(UMFAQ_WhatNotCovered, UMFAQ_WhatNotCoveredParagraph, UMFAQ_WhatNotCoveredArrow);
        public static IStaticInteraction UMFAQ_NeedUMFAQ => new CoveragePageFAQ(UMFAQ_NeedUM, UMFAQ_NeedUMParagraph, UMFAQ_NeedUMArrow);
        public static IStaticInteraction UMFAQ_HowMuchNeedFAQ => new CoveragePageFAQ(UMFAQ_HowMuchNeed, UMFAQ_HowMuchNeedParagraph, UMFAQ_HowMuchNeedArrow);

    }
}