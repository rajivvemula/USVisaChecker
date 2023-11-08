using BiBerkLOB.StepDefinition.General.Other.Coverages;
using HitachiQA.Driver;
using OpenQA.Selenium;
using System.Collections.Generic;
using BiBerkLOB.Pages.Other;
using BiBerkLOB.Source.Driver.SimpleInteractions;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.GL
{
    [StaticPageName("GL Coverage")]
    public sealed class GeneralLiabilityPage : IStaticPage
    {
        /*
         * Photo Banner - General Liability Insurance
         */
        public static Element GenLiabIns => new Element(By.XPath("//h1[@data-qa='general-liability-insurance']"));
        public static Element GenLiabInsSubtitle => new Element(By.XPath("//div[@data-qa='page-banner-subtitle']"));
        public static Element GenLiabInsGetAQuoteCTA => new Element(By.XPath("//button[@data-qa='page-banner-button']"));

        /*
         * White Banner - biBERK Makes Getting General Liability Insurance Convenient
         */
        //4.9 out of 5 customer review rating and 150,000+ policies sold.
        //This mapping can be found on the Reusable_PurchasePath.cs file

        public static Element biBERKGLConvenient => new Element(By.XPath("//h2[@data-qa='more-info-label']"));
        public static Element biBERKGLConvenientParagraph_1 => new Element(By.XPath("//p[@data-qa='more-info-p-1']"));
        public static Element biBERKGLConvenientParagraph_2 => new Element(By.XPath("//p[@data-qa='more-info-p-2']"));

        /*
         * Grey Banner - What is General Liability Insurance?
         */
        public static Element WhatIsGLIns => new Element(By.XPath("(//h2[@data-qa='two-columns-with-header-header'])[1]"));
        public static Element WhatIsGLInsParagraph => new Element(By.XPath("(//p[@data-qa='two-columns-with-header-lead-text'])[1]"));

        //Property Damage
        public static Element PropDamag => new Element(By.XPath("(//h6[@data-qa='two-columns-with-header-col-one-row-one-header'])[1]"));
        public static Element PropDamagParagraph => new Element(By.XPath("(//p[@data-qa='two-columns-with-header-col-one-row-one-text'])[1]"));

        //Product Liability
        public static Element ProdLiab => new Element(By.XPath("(//h6[@data-qa='two-columns-with-header-col-two-row-one-header'])[1]"));
        public static Element ProdLiabParagraph => new Element(By.XPath("(//p[@data-qa='two-columns-with-header-col-two-row-one-text'])[1]"));

        //Bodily Injury
        public static Element BodilyInj => new Element(By.XPath("(//h6[@data-qa='two-columns-with-header-col-one-row-two-header'])[1]"));
        public static Element BodilyInjParagraph => new Element(By.XPath("(//p[@data-qa='two-columns-with-header-col-one-row-two-text'])[1]"));

        //Libel, Slander, and Copyright Infringement
        public static Element LibelSlander => new Element(By.XPath("(//h6[@data-qa='two-columns-with-header-col-two-row-two-header'])[1]"));
        public static Element LibelSlanderParagraph => new Element(By.XPath("(//p[@data-qa='two-columns-with-header-col-two-row-two-text'])[1]"));

        /*
         * Blue Banner - Why do I Need General Liability Insurance? / Business Liability Insurance for Your Company
         */
        public static Element DotLeft => new Element(By.XPath("//li[@class='indicator-item active']"));
        public static Element DotRight => new Element(By.XPath("//li[@class='indicator-item']"));

        /*
         * White Banner - How do I Know if I Need a Liability Insurance Policy?
         */
        public static Element HowDoIKnowNeedLiabTitle => new Element(By.XPath("//h2[@data-qa='do-i-need-header']"));
        public static Element HowDoIKnowNeedLiabText => new Element(By.XPath("//p[@data-qa='do-i-need-main-text']"));
        public static Element HowDoIKnowNeedLiabHeader => new Element(By.XPath("//h6[@data-qa='do-i-need-list-header']"));
        public static Element HowDoIKnowNeedLiabList => new Element(By.XPath("//ul[@data-qa='bulleted-list']"));
        public static Element HowDoIKnowNeedLiabCTA_CoverageMap => new Element(By.XPath("//a[@data-qa='coverage-map-button']"));

        /*
         * Blue Banner - Industries That Typically Need Business Liability Insurance Include:
         */
        public static Element IndustriesNeedBusLiab => new Element(By.XPath("//h2[@data-qa='list-header-label']"));
        public static Element IndustriesNeedBusLiabList => new Element(By.XPath("//ul[@data-qa='coverage-list']"));

        /*
         * Grey Banner - What if I'm a Contractor or I Operate My Business out of My Home?
         */
        public static Element WhatIfContractor => new Element(By.XPath("//h2[@data-qa='what-is-header']"));
        public static Element WhatIfContractorParagraph => new Element(By.XPath("//p[@data-qa='what-is-text']"));
        //liability insurance policy
        public static Element WhatIfContractorLink => new Element(By.XPath("//p[@data-qa='what-is-text']/a"));

        /*
         * Blue Banner - How Much is General Liability Insurance?
         */
        public static Element WhatGLCostForSmBus => new Element(By.XPath("//h2[@data-qa='how-much-label']"));
        public static Element WhatGLCostForSmBusParagraph => new Element(By.XPath("//p[@data-qa='how-much-text']"));
        public static Element WhatGLCostForSmBusImage => new Element(By.XPath("//img[@data-qa='how-much-image']"));

        /*
         * Grey Banner - Customizing Your General Liability Insurance Policy With Endorsements
         */
        public static Element CustomizingGLIns => new Element(By.XPath("(//h2[@data-qa='two-columns-with-header-header'])[2]"));
        public static Element CustomizingGLInsParagraph => new Element(By.XPath("//p[@data-qa='customize-gl-lead-text']"));

        //Cyber
        public static Element Cyber => new Element(By.XPath("(//h6[@data-qa='two-columns-with-header-col-one-row-one-header'])[2]"));
        public static Element CyberParagraph => new Element(By.XPath("(//p[@data-qa='col-1-row-1-text'])"));

        //Employment-Related Practices LIability
        public static Element EmployRelatedLiab => new Element(By.XPath("(//h6[@data-qa='two-columns-with-header-col-one-row-two-header'])[2]"));
        public static Element EmployRelatedLiabParagraph => new Element(By.XPath("//p[@data-qa='col-2-row-1-text']"));

        //Contractors Installation, Tools & Equipment
        public static Element ContractorsInstall => new Element(By.XPath("(//h6[@data-qa='two-columns-with-header-col-two-row-two-header'])[2]"));
        public static Element ContractorsInstallParagraph => new Element(By.XPath("//p[@data-qa='col-2-row-2-text']"));

        //Hired and Non-Owned Auto Liability
        public static Element HiredNonOwnedAuto => new Element(By.XPath("(//h6[@data-qa='two-columns-with-header-col-one-row-two-header'])[2]"));
        public static Element HiredNonOwnedAutoParagraph => new Element(By.XPath("//p[@data-qa='col-1-row-2-text']"));

        //Employee Benefits Liability
        public static Element EmployBenefitsLiab => new Element(By.XPath("//h6[@data-qa='two-columns-with-header-col-one-row-three-header']"));
        public static Element EmployBenefitsLiabParagraph => new Element(By.XPath("//p[@data-qa='col-1-row-3-text']"));

        //Liquor Liability
        public static Element LiquorLiab => new Element(By.XPath("//h6[@data-qa='two-columns-with-header-col-two-row-three-header']"));
        public static Element LiquorLiabParagraph => new Element(By.XPath("//p[@data-qa='col-2-row-3-text']"));

        //Our commercial general liability insurance experts can help you understand whether you need endorsements for your general liability insurance policy.
        public static Element InsExpertsUnderstand => new Element(By.XPath("//p[@data-qa='customize-gl-bottom-text']"));

        /*
         * White Banner - Why biBERK for General Liability Insurance?
         */
        public static Element WhyBiberkForGL => new Element(By.XPath("//h2[@data-qa='why-biberk-header']"));
        public static Element WhyBiberkForGLParagraph => new Element(By.XPath("//p[@data-qa='subheader-text-label']"));

        /*
         * Blue Banner - Get a General Liability Insurance Quote Today
         */
        public static Element GetGLQuoteToday => new Element(By.XPath("//h2[@data-qa='get-a-quote-label']"));
        public static Element GetGLQuoteTodayParagraph => new Element(By.XPath("//p[@data-qa='trust-biberk-quote']"));
        public static Element GetGLQuoteTodayCTA_GetAQuote => new Element(By.XPath("//a[@data-qa='get-a-quote-button_2']"));

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
         * Flip Cards
         */
        //It Provides Financial Protection
        private static Element ProvideFinancialProtect => new Element(By.XPath("//h4[@data-qa='card-1-title']"));
        private static Element ProvideFinancialProtectImage => new Element(By.XPath("//img[@data-qa='what-is-card-1']"));
        private static Element ProvideFinancialProtectTextBehind => new Element(By.XPath("//p[@data-qa='broader-coverage-text']"));

        //It May Be Required By Law
        private static Element MayBeRequiredByLaw => new Element(By.XPath("//h4[@data-qa='card-2-title']"));
        private static Element MayBeRequiredByLawImage => new Element(By.XPath("//img[@data-qa='what-is-card-2']"));
        private static Element MayBeRequiredByLawTextBehind => new Element(By.XPath("//p[@data-qa='card-text_2']"));

        //Clients Require Insurance
        private static Element ClientsReqIns => new Element(By.XPath("//h4[@data-qa='card-3-title']"));
        private static Element ClientsReqInsImage => new Element(By.XPath("//img[@data-qa='what-is-card-3']"));
        private static Element ClientsReqInsTextBehind => new Element(By.XPath("//p[@data-qa='card-text_3']"));

        public static IStaticInteraction ProvideFinancialProtectFlipCard => new FlipCard(ProvideFinancialProtect, ProvideFinancialProtectImage, ProvideFinancialProtectTextBehind);
        public static IStaticInteraction MayBeRequiredByLawFlipCard => new FlipCard(MayBeRequiredByLaw, MayBeRequiredByLawImage, MayBeRequiredByLawTextBehind);
        public static IStaticInteraction ClientsReqInsFlipCard => new FlipCard(ClientsReqIns, ClientsReqInsImage, ClientsReqInsTextBehind);

        /*
         * Grey Banner - General Liability Insurance Frequently Asked Questions (FAQs)
         */
        public static Element GLFAQsHeader => new Element(By.XPath("//h2[@data-qa='faq-header']"));
        public static Element GLFAQsParagraph => new Element(By.XPath("//p[@data-qa='faq-subheader']"));

        //What is general liability insurance?
        private static Element WhatGLIns => new Element(By.XPath("//h3[@data-qa='faq-question-1-question']"));
        private static Element WhatGLInsParagraph => new Element(By.XPath("//p[@data-qa='faq-item-1-text']"));
        private static Element WhatGLInsArrow => new Element(By.XPath("//i[@data-qa='faq-question-1-arrow']"));

        //Do I need general liability insurance for my business?
        private static Element DoINeedGL => new Element(By.XPath("//h3[@data-qa='faq-question-2-question']"));
        private static Element DoINeedGLParagraph => new Element(By.XPath("//p[@data-qa='faq-item-2-text']"));
        private static Element DoINeedGLArrow => new Element(By.XPath("//i[@data-qa='faq-question-2-arrow']"));

        //How do I prove I have general liability insurance?
        private static Element ProveIHaveGL => new Element(By.XPath("//h3[@data-qa='faq-question-3-question']"));
        private static Element ProveIHaveGLParagraph => new Element(By.XPath("//p[@data-qa='faq-item-3-text']"));
        private static Element ProveIHaveGLArrow => new Element(By.XPath("//i[@data-qa='faq-question-3-arrow']"));

        //Does general liability insurance cover lawsuits?
        private static Element GLCoverLawsuits => new Element(By.XPath("//h3[@data-qa='faq-question-4-question']"));
        private static Element GLCoverLawsuitsParagraph => new Element(By.XPath("//p[@data-qa='faq-item-4-text']"));
        private static Element GLCoverLawsuitsArrow => new Element(By.XPath("//i[@data-qa='faq-question-4-arrow']"));

        //What is primary insurance versus excess insurance?
        private static Element PrimaryInsVsExcessIns => new Element(By.XPath("//h3[@data-qa='faq-question-5-question']"));
        private static Element PrimaryInsVsExcessInsParagraph => new Element(By.XPath("//p[@data-qa='faq-item-5-text']"));
        private static Element PrimaryInsVsExcessInsArrow => new Element(By.XPath("//i[@data-qa='faq-question-5-arrow']"));

        //Does general liability insurance cover errors and omissions?
        private static Element GLCoverEandO => new Element(By.XPath("//h3[@data-qa='faq-question-6-question']"));
        private static Element GLCoverEandOParagraph => new Element(By.XPath("//p[@data-qa='faq-item-6-text']"));
        private static Element GLCoverEandOLink_PL => new Element(By.XPath("//p[@data-qa='faq-item-6-text']/a"));
        private static Element GLCoverEandOArrow => new Element(By.XPath("//i[@data-qa='faq-question-6-arrow']"));

        //Does biBERK provide general liability insurance in my state?
        private static Element biBERKProvideGLInState => new Element(By.XPath("//h3[@data-qa='faq-question-7-question']"));
        private static Element biBERKProvideGLInStateParagraph => new Element(By.XPath("//p[@data-qa='faq-item-7-text']"));
        private static Element biBERKProvideGLInStateLink_CoverageMap => new Element(By.XPath("//p[@data-qa='faq-item-7-text']/a"));
        private static Element biBERKProvideGLInStateArrow => new Element(By.XPath("//i[@data-qa='faq-question-7-arrow']"));

        public static IStaticInteraction WhatGLInsFAQ => new CoveragePageFAQ(WhatGLIns, WhatGLInsParagraph, WhatGLInsArrow);
        public static IStaticInteraction DoINeedGLFAQ => new CoveragePageFAQ(DoINeedGL, DoINeedGLParagraph, DoINeedGLArrow);
        public static IStaticInteraction ProveIHaveGLFAQ => new CoveragePageFAQ(ProveIHaveGL, ProveIHaveGLParagraph, ProveIHaveGLArrow);
        public static IStaticInteraction GLCoverLawsuitsFAQ => new CoveragePageFAQ(GLCoverLawsuits, GLCoverLawsuitsParagraph, GLCoverLawsuitsArrow);
        public static IStaticInteraction PrimaryInsVsExcessInsFAQ => new CoveragePageFAQ(PrimaryInsVsExcessIns, PrimaryInsVsExcessInsParagraph, PrimaryInsVsExcessInsArrow);
        public static IStaticInteraction GLCoverEandOFAQ => new CoveragePageFAQ(GLCoverEandO, GLCoverEandOParagraph, GLCoverEandOArrow, GLCoverEandOLink_PL);
        public static IStaticInteraction biBERKProvideGLInStateFAQ => new CoveragePageFAQ(biBERKProvideGLInState, biBERKProvideGLInStateParagraph, biBERKProvideGLInStateArrow, biBERKProvideGLInStateLink_CoverageMap);

        /*
         * Carousel
         */
        private static Element CarouselImage => new Element(By.XPath("//img[@data-qa='info-image-carousel-image-left']"));
        private static Element ArrowLeft => new Element(By.XPath("//i[@data-qa='info-image-carousel-image-left-chevron-previous']"));
        private static Element ArrowRight => new Element(By.XPath("//i[@data-qa='info-image-carousel-image-left-chevron-next']"));

        //Why do I Need General Liability Insurance?
        private static Element WhyNeedGLIns => new Element(By.XPath("//h2[@data-qa='info-image-carousel-image-left-slide1-header']"));
        private static Element WhyNeedGLInsParagraph => new Element(By.XPath("//p[@data-qa='info-image-carousel-image-left-slide1-text']"));


        //Business Liability Insurance for Your Company
        private static Element BusLiabIns => new Element(By.XPath("//h2[@data-qa='info-image-carousel-image-left-slide2-header']"));
        private static Element BusLiabInsParagraph => new Element(By.XPath("//p[@data-qa='info-image-carousel-image-left-slide2-text']"));

        private static Dictionary<Element, Element> GLCarouselTextItems => new Dictionary<Element, Element>
        {
            { WhyNeedGLIns,WhyNeedGLInsParagraph },
            { BusLiabIns,BusLiabInsParagraph }
        };
        public static IStaticInteraction GLCarousel => new Carousel(GLCarouselTextItems, ArrowLeft, ArrowRight, CarouselImage);
    }
}