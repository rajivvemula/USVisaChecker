using BiBerkLOB.StepDefinition.General.Other.Coverages;
using HitachiQA.Driver;
using OpenQA.Selenium;
using System.Collections.Generic;
using BiBerkLOB.Pages.Other;
using BiBerkLOB.Source.Driver.SimpleInteractions;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.PL
{
    [StaticPageName("PL Coverage")]
    public sealed class PLPage : IStaticPage
    {
        /*
         * Photo Banner - Professional Liability Insurance
         */
        public static Element ProfessionalLiabIns => new Element(By.XPath("//h1[@data-qa='professional-liability-insurance']"));
        public static Element TakeGuessworkOut => new Element(By.XPath("//div[@data-qa='page-banner-subtitle']"));
        public static Element PLGetAQuoteCTA => new Element(By.XPath("//button[@data-qa='page-banner-button']"));

        /*
         * White Banner - Protect yourself With Professional Liability Insurance
         */
        public static Element ProtectYourselfPL => new Element(By.XPath("//h2[@data-qa='info-image-right-main-header']"));
        public static Element ProtectYourselfPLParagraph => new Element(By.XPath("//p[@data-qa='info-image-right-main-text']"));
        //Getting Professional Liability Coverage is Simple with biBERK
        public static Element GettingPLSimple => new Element(By.XPath("//h3[@data-qa='info-image-right-header']"));
        public static Element GettingPLSimple_GiveInfoOnline => new Element(By.XPath("//li[@data-qa='info-image-right-list-0']"));
        public static Element GettingPLSimple_BuyOnlineOrPhone => new Element(By.XPath("//li[@data-qa='info-image-right-list-1']"));
        public static Element GettingPLSimple_PaymentsOnline => new Element(By.XPath("//li[@data-qa='info-image-right-list-2']"));
        public static Element GettingPLSimpleImage => new Element(By.XPath("//img[@data-qa='info-image-right-image']"));

        /*
         * Blue Banner - What is Professional Liability Insurance?
         */
        public static Element WhatIsPLIns => new Element(By.XPath("//h2[@data-qa='info-image-left-header']"));
        public static Element WhatIsPLInsParagraph => new Element(By.XPath("//p[@data-qa='info-image-left-text-0']"));
        public static Element WhatIsPLInsImage => new Element(By.XPath("//img[@data-qa='info-image-left-image']"));

        /*
         * Grey Banner - What Does Professional Liability Cover?
         */
        public static Element WhatDoesPLCover => new Element(By.XPath("//h2[@data-qa='what-is-header']"));
        public static Element WhatDoesPLCoverParagraph => new Element(By.XPath("(//p[@data-qa='what-is-main-text'])[2]"));

        //In each instance, professional liability insurance covers the costs for legal defense and damages.  Plus, biBERK provides an attorney to represent you.
        public static Element WhatDoesPLCoverParagraph_InEachInstance => new Element(By.XPath("(//p[@data-qa='what-is-bottom-text'])[2]"));

        /*
         * White Banner - Why biBERK Professional Liability Insurance?
         */
        public static Element WhybiBERKPL => new Element(By.XPath("//h2[@data-qa='why-biberk-header']"));
        public static Element biBERKTheExperts => new Element(By.XPath("//p[@data-qa='subheader-text-label_2']"));

        //for the Save Time, Save Money, Experienced columns reference the Reusable_PurchasePath.cs file


        /*
         * Blue Banner - Who Should Consider Professional Liability Insurance?
         */
        public static Element WhoShouldConsiderPL => new Element(By.XPath("//h2[@data-qa='info-list-box-heading']"));
        public static Element WhoShouldConsiderPLParagraph => new Element(By.XPath("//p[@data-qa='info-list-box-text-0']"));
        public static Element WhoShouldConsiderPLList => new Element(By.XPath("//li[@data-qa='info-list-box-list-item-0']//parent::ul"));
        public static CoverageCatalogue PLCoverageList => new CoverageCatalogue(WhoShouldConsiderPLList, 44); //WhoShouldConsiderPLList

        /*
         * White Banner - Professional Liability Insurance Offers Protection Beyond Claims
         */
        public static Element PLInsProtectionBeyond => new Element(By.XPath("(//h2[@data-qa='faq-header'])[1]"));
        public static Element PLInsProtectionBeyondParagraph => new Element(By.XPath("(//p[@data-qa='faq-subheader'])[1]"));

        

        /*
         * Grey Banner - What's not Covered by Professional Liability Insurance Companies?
         */
        public static Element WhatNotCoveredByPL => new Element(By.XPath("//h2[@data-qa='more-info-main-header']"));
        public static Element WhatNotCoveredByPLParagraph => new Element(By.XPath("(//h2[@data-qa='more-info-main-header']//parent::div/p)[2]"));

        //Illegal Acts or Costs of Defense for Criminal Prosecution
        public static Element IllegalActs => new Element(By.XPath("//h6[@data-qa='more-info-header_1']"));
        public static Element IllegalActsParagraph => new Element(By.XPath("(//p[@data-qa='content-text_1']/following-sibling::p)[1]"));

        //Employee Injuries and Related Costs
        public static Element EmployeeInjuries => new Element(By.XPath("//h6[@data-qa='more-info-header_2']"));
        public static Element EmployeeInjuriesParagraph => new Element(By.XPath("(//p[@data-qa='content-text_2']/following-sibling::p)[1]"));
        public static Element EmployeeInjuriesLink => new Element(By.XPath("//h6[@data-qa='more-info-header_2']//parent::div//a[@href='/small-business-insurance/workers-compensation-insurance']"));

        //Regular Accidents That Aren’t Related to Your Expertise
        public static Element RegAccidentsUnrelated => new Element(By.XPath("//h6[@data-qa='more-info-header_5']"));
        public static Element RegAccidentsUnrelatedParagraph => new Element(By.XPath("(//p[@data-qa='content-text_5']/following-sibling::p)[1]"));
        public static Element RegAccidentsUnrelatedLink => new Element(By.XPath("//h6[@data-qa='more-info-header_5']//parent::div//a[@href='/small-business-insurance/general-liability-insurance']"));

        //Damages to Your Business Property
        public static Element DamagesToProp => new Element(By.XPath("//h6[@data-qa='more-info-header_6']"));
        public static Element DamagesToPropParagraph => new Element(By.XPath("(//p[@data-qa='content-text_6']/following-sibling::p)[1]"));
        public static Element DamagesToPropLink => new Element(By.XPath("//h6[@data-qa='more-info-header_6']//parent::div//a[@href='/small-business-insurance/business-owners-policy']"));

        /*
         * Blue Banner - Are You Required to Carry Professional Liability Insurance? / Be Sure You're Protected by Professional Liability Insurance
         */

        public static Element AreYouRequired_LeftDot => new Element(By.XPath("//li[@class='indicator-item active']")); //cannot manipulate to use data-qa attribute
        public static Element AreYouRequired_RightDot => new Element(By.XPath("//li[@class='indicator-item']")); //cannot manipulate to use data-qa attribute

        /*
         * White Banner - What Does Professional Liability Insurance Cost?
         */
        public static Element WhatPLCost => new Element(By.XPath("//h2[@data-qa='info-image-left-main-header']"));
        public static Element WhatPLCostParagraph => new Element(By.XPath("//p[@data-qa='info-image-left-main-text']"));

        //How do I Lower My Professional Liability Insurance Cost?
        public static Element HowLowerPLCost => new Element(By.XPath("//h3[@data-qa='info-image-left-header']"));
        public static Element HowLowerPLCost_PurchaseRightAmount => new Element(By.XPath("//li[@data-qa='info-image-left-list-0']"));
        public static Element HowLowerPLCost_HigherDeduct => new Element(By.XPath("//li[@data-qa='info-image-left-list-1']"));
        public static Element HowLowerPLCost_BuybiBERK => new Element(By.XPath("//li[@data-qa='info-image-left-list-2']"));

        //biBERK Insurance Coverage by State
        public static Element biBERKInsCovByState => new Element(By.XPath("//h3[@data-qa='info-image-left-header-below-image']"));
        public static Element biBERKInsCovByStateImage => new Element(By.XPath("(//img[@data-qa='info-image-left-image'])[2]"));
        public static Element biBERKInsCovByStateCTA => new Element(By.XPath("//a[@data-qa='info-image-left-button-below-image']"));

        /*
         * Grey Banner - Professional Liability Insurance Frequently Asked Questions (FAQs)
         */
        public static Element PLFAQsHeader => new Element(By.XPath("//h2[@data-qa='faq-header']"));
        public static Element PLFAQsParagraph => new Element(By.XPath("//p[@data-qa='faq-subheader']"));
        
        /*
         *  Blue Banner - Get a Professional Liability Insurance Quote Today
         */
        public static Element GetPLToday => new Element(By.XPath("//h2[@data-qa='get-a-quote-label']"));
        public static Element GetPLTodaySubtitle => new Element(By.XPath("//p[@data-qa='trust-biberk-quote']"));
        public static Element GetPLTodayGetQuoteCTA => new Element(By.XPath("//a[@data-qa='get-a-quote-button_2']"));

        /*
         * Flip Cards
         */
        //Unfufilled Duties
        private static Element UnfufilledDuties => new Element(By.XPath("//h4[@data-qa='card-1-title']"));
        private static Element UnfufilledDutiesImage => new Element(By.XPath("//img[@data-qa='what-is-card-1']"));
        //This happens when you’re expected to take certain actions but fail to do so. For instance, your accounting firm is supposed to file the client’s tax return by a specific deadline and you do not.
        private static Element UnfufilledDutiesTextBehind => new Element(By.XPath("//p[@data-qa='broader-coverage-text']"));

        //Negligence
        private static Element Negligence => new Element(By.XPath("//h4[@data-qa='card-2-title']"));
        private static Element NegligenceImage => new Element(By.XPath("//img[@data-qa='what-is-card-2']"));
        //Negligence occurs when you fail to use proper care when performing an important task. For example, as an insurance agent you fail to advise a client about important coverage and they’re left with a wide gap in protection.
        private static Element NegligenceTextBehind => new Element(By.XPath("//p[@data-qa='card-text_2']"));

        //Errors
        private static Element Errors => new Element(By.XPath("//h4[@data-qa='card-3-title']"));
        private static Element ErrorsImage => new Element(By.XPath("//img[@data-qa='what-is-card-3']"));
        //In this instance, you’re being held responsible for a mistake made by you or your employee that caused your client a financial loss.
        private static Element ErrorsTextBehind => new Element(By.XPath("//p[@data-qa='card-text_3']"));

        public static IStaticInteraction UnfufilledDutiesFlipCard => new FlipCard(UnfufilledDuties, UnfufilledDutiesImage, UnfufilledDutiesTextBehind);
        public static IStaticInteraction NegligenceFlipCard => new FlipCard(Negligence, NegligenceImage, NegligenceTextBehind);
        public static IStaticInteraction ErrorsFlipCard => new FlipCard(Errors, ErrorsImage, ErrorsTextBehind);

        /*
         * Carousel
         */

        //Are You Required to Carry Professional Liability Insurance?
        private static Element AreYouRequired => new Element(By.XPath("//h2[@data-qa='info-image-carousel-image-left-slide1-header']"));
        private static Element AreYouRequiredParagraph => new Element(By.XPath("//p[@data-qa='info-image-carousel-image-left-slide1-text']"));
        private static Element AreYouRequired_LeftArrow => new Element(By.XPath("//i[@data-qa='info-image-carousel-image-left-chevron-previous']"));
        private static Element AreYouRequired_RightArrow => new Element(By.XPath("//i[@data-qa='info-image-carousel-image-left-chevron-next']"));
        //Be Sure You're Protected by Professional Liability Insurance
        private static Element BeSureYoureProtected => new Element(By.XPath("//h2[@data-qa='info-image-carousel-image-left-slide2-header']"));
        private static Element BeSureYoureProtectedParagraph => new Element(By.XPath("//p[@data-qa='info-image-carousel-image-left-slide2-text']"));

        private static Dictionary<Element, Element> PLCarouselItems => new Dictionary<Element, Element>
        {
            { AreYouRequired,AreYouRequiredParagraph },
            { BeSureYoureProtected,BeSureYoureProtectedParagraph }
        };
        public static IStaticInteraction PLCarousel => new Carousel(PLCarouselItems, AreYouRequired_LeftArrow, AreYouRequired_RightArrow);

        /*
         * White banner accordion
         */
        //Claims Arising From Past Services Provided in the Past (Based on Retroactive Date)
        private static Element ClaimsFromPast => new Element(By.XPath("//h3[@data-qa='faq-question-1-question']"));
        private static Element ClaimsFromPastParagraph => new Element(By.XPath("//p[@data-qa='faq-question-1-answer']"));
        private static Element ClaimsFromPastArrow => new Element(By.XPath("//i[@data-qa='faq-question-1-arrow']"));

        //Legal Costs Associated With Groundless Claims
        private static Element LegalCostsGroundless => new Element(By.XPath("//h3[@data-qa='faq-question-2-question']"));
        private static Element LegalCostsGroundlessParagraph => new Element(By.XPath("//p[@data-qa='faq-question-2-answer']"));
        private static Element LegalCostsGroundlessArrow => new Element(By.XPath("//i[@data-qa='faq-question-2-arrow']"));

        //Cyber Liabilities
        private static Element CyberLiab => new Element(By.XPath("//h3[@data-qa='faq-question-3-question']"));
        private static Element CyberLiabParagraph => new Element(By.XPath("//p[@data-qa='faq-question-3-answer']"));
        private static Element CyberLiabArrow => new Element(By.XPath("//i[@data-qa='faq-question-3-arrow']"));

        public static IStaticInteraction ClaimsFromPastAccordion => new AccordionSection(ClaimsFromPast, ClaimsFromPastArrow, ClaimsFromPastParagraph);
        public static IStaticInteraction LegalCostsGroundlessAccordion => new AccordionSection(LegalCostsGroundless, LegalCostsGroundlessArrow, LegalCostsGroundlessParagraph);
        public static IStaticInteraction CyberLiabAccordion => new AccordionSection(CyberLiab, CyberLiabArrow, CyberLiabParagraph);

        /*
         * FAQs
         */
        //Are professional liability and errors and omissions insurance the same thing?
        private static Element PLandEOSame => new Element(By.XPath("(//h3[@data-qa='faq-question-1-question'])[2]"));
        private static Element PLandEOSameParagraph => new Element(By.XPath("//p[@data-qa='faq-text-item-1']"));
        private static Element PLandEOSameArrow => new Element(By.XPath("(//i[@data-qa='faq-question-1-arrow'])[2]"));

        //What is a retroactive date?
        private static Element WhatRetroactiveDate => new Element(By.XPath("(//h3[@data-qa='faq-question-2-question'])[2]"));
        private static Element WhatRetroactiveDateParagraph => new Element(By.XPath("//p[@data-qa='faq-text-item-2']"));
        private static Element WhatRetroactiveDateArrow => new Element(By.XPath("(//i[@data-qa='faq-question-2-arrow'])[2]"));

        //What is professional liability insurance?
        private static Element WhatPLIns => new Element(By.XPath("(//h3[@data-qa='faq-question-3-question'])[2]"));
        private static Element WhatPLInsParagraph => new Element(By.XPath("//p[@data-qa='faq-text-item-3']"));
        private static Element WhatPLInsArrow => new Element(By.XPath("(//i[@data-qa='faq-question-3-arrow'])[2]"));

        //What does professional liability insurance cost?
        private static Element WhatPLInsCost => new Element(By.XPath("//h3[@data-qa='faq-question-4-question']"));
        private static Element WhatPLInsCostParagraph => new Element(By.XPath("//p[@data-qa='faq-text-item-4']"));
        private static Element WhatPLInsCostArrow => new Element(By.XPath("//i[@data-qa='faq-question-4-arrow']"));

        //How much liability insurance do I need?
        private static Element HowMuchLiabNeed => new Element(By.XPath("//h3[@data-qa='faq-question-5-question']"));
        private static Element HowMuchLiabNeedParagraph => new Element(By.XPath("//p[@data-qa='faq-text-item-5']"));
        private static Element HowMuchLiabNeedArrow => new Element(By.XPath("//i[@data-qa='faq-question-5-arrow']"));

        //What is the minimum amount of liability insurance required?
        private static Element MinAmountLiab => new Element(By.XPath("//h3[@data-qa='faq-question-6-question']"));
        private static Element MinAmountLiabParagraph => new Element(By.XPath("//p[@data-qa='faq-text-item-6']"));
        private static Element MinAmountLiabArrow => new Element(By.XPath("//i[@data-qa='faq-question-6-arrow']"));

        //Does my business need errors and omissions insurance?
        private static Element NeedEOIns => new Element(By.XPath("//h3[@data-qa='faq-question-7-question']"));
        private static Element NeedEOInsParagraph => new Element(By.XPath("//p[@data-qa='faq-text-item-7']"));
        private static Element NeedEOInsArrow => new Element(By.XPath("//i[@data-qa='faq-question-7-arrow']"));

        //How is professional liability insurance different from general liability insurance?
        private static Element PLvGLIns => new Element(By.XPath("//h3[@data-qa='faq-question-8-question']"));
        private static Element PLvGLInsParagraph => new Element(By.XPath("//p[@data-qa='faq-text-item-8']"));
        private static Element PLvGLInsArrow => new Element(By.XPath("//i[@data-qa='faq-question-8-arrow']"));

        //Does biBERK offer professional liability insurance in my state?
        private static Element PLInMyState => new Element(By.XPath("//h3[@data-qa='faq-question-9-question']"));
        private static Element PLInMyStateParagraph => new Element(By.XPath("//p[@data-qa='faq-text-item-9']"));
        private static Element PLInMyStateArrow => new Element(By.XPath("//i[@data-qa='faq-question-9-arrow']"));

        //Does professional liability insurance cover my company even if a lawsuit is baseless?
        private static Element PLCoverCompany => new Element(By.XPath("//h3[@data-qa='faq-question-10-question']"));
        private static Element PLCoverCompanyParagraph => new Element(By.XPath("//p[@data-qa='faq-text-item-10']"));
        private static Element PLCoverCompanyArrow => new Element(By.XPath("//i[@data-qa='faq-question-10-arrow']"));
        
        public static IStaticInteraction PLandEOSameFAQ => new CoveragePageFAQ(PLandEOSame, PLandEOSameParagraph, PLandEOSameArrow);
        public static IStaticInteraction WhatRetroactiveDateFAQ => new CoveragePageFAQ(WhatRetroactiveDate, WhatRetroactiveDateParagraph, WhatRetroactiveDateArrow);
        public static IStaticInteraction WhatPLInsFAQ => new CoveragePageFAQ(WhatPLIns, WhatPLInsParagraph, WhatPLInsArrow);
        public static IStaticInteraction WhatPLInsCostFAQ => new CoveragePageFAQ(WhatPLInsCost, WhatPLInsCostParagraph, WhatPLInsCostArrow);
        public static IStaticInteraction HowMuchLiabNeedFAQ => new CoveragePageFAQ(HowMuchLiabNeed, HowMuchLiabNeedParagraph, HowMuchLiabNeedArrow);
        public static IStaticInteraction MinAmountLiabFAQ => new CoveragePageFAQ(MinAmountLiab, MinAmountLiabParagraph, MinAmountLiabArrow);
        public static IStaticInteraction NeedEOInsFAQ => new CoveragePageFAQ(NeedEOIns, NeedEOInsParagraph, NeedEOInsArrow);
        public static IStaticInteraction PLvGLInsFAQ => new CoveragePageFAQ(PLvGLIns, PLvGLInsParagraph, PLvGLInsArrow);
        public static IStaticInteraction PLInMyStateFAQ => new CoveragePageFAQ(PLInMyState, PLInMyStateParagraph, PLInMyStateArrow);
        public static IStaticInteraction PLCoverCompanyFAQ => new CoveragePageFAQ(PLCoverCompany, PLCoverCompanyParagraph, PLCoverCompanyArrow);
        
        public static Element SaveTime => Reusable_PurchasePath.SaveTime;
        public static Element SaveTimeImage => Reusable_PurchasePath.SaveTimeImage;
        public static Element SaveTimeParagraph => Reusable_PurchasePath.SaveTimeParagraph;
        public static Element SaveMoney => Reusable_PurchasePath.SaveMoney;
        public static Element SaveMoneyImage => Reusable_PurchasePath.SaveMoneyImage;
        public static Element SaveMoneyParagraph => Reusable_PurchasePath.SaveMoneyParagraph;
        public static Element Experienced => Reusable_PurchasePath.Experienced;
        public static Element ExperiencedImage => Reusable_PurchasePath.ExperiencedImage;
        public static Element ExperiencedParagraph => Reusable_PurchasePath.ExperiencedParagraph;
    }
}