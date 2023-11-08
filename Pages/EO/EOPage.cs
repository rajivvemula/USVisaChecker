using BiBerkLOB.StepDefinition.General.Other.Coverages;
using HitachiQA.Driver;
using OpenQA.Selenium;
using BiBerkLOB.Pages.Other;
using BiBerkLOB.Source.Driver.SimpleInteractions;

namespace BiBerkLOB.Pages.EO
{
    [StaticPageName("EO Coverage")]
    public sealed class EOPage : IStaticPage
    {
        //Photo Banner - Errors and Omissions Insurance
        public static Element ErrorsAndOmissionsIns => new Element(By.XPath("//h1[@data-qa='errors-omissions-insurance']"));
        public static Element GetReassuringErrors => new Element(By.XPath("//div[@data-qa='page-banner-subtitle']"));
        public static Element EOGetAQuoteCTA => new Element(By.XPath("//button[@data-qa='page-banner-button']"));
        public static Element Ratings => new Element(By.XPath("//p[@data-qa='review-teaser-text']"));

        // White Banner - Errors & Omissions Insurance Addresses the Special Risks Faced by Experts 
        public static Element AddressesSpecialRisk => new Element(By.XPath("//h2[@data-qa='info-image-right-main-header']"));
        public static Element AddressesSpecialRiskText => new Element(By.XPath("//p[@data-qa='info-image-right-main-text']"));

        //Getting Errors and Omissions Coverage is Simple With biBERK
        public static Element GettingEOSimple => new Element(By.XPath("//h3[@data-qa='info-image-right-header']"));
        public static Element GettingEOSimple_OnlineInfo => new Element(By.XPath("//li[@data-qa='info-image-right-list-0']"));
        public static Element GettingEOSimple_ReadyToBuy => new Element(By.XPath("//li[@data-qa='info-image-right-list-1']"));
        public static Element GettingEOSimple_MakePayments => new Element(By.XPath("//li[@data-qa='info-image-right-list-2']"));
        public static Element GettingEOSimple_IMG => new Element(By.XPath("//img[@data-qa='info-image-right-image']"));

        //Blue Banner - What is Errors and Omissions Insurance?
        public static Element WhatIsEO => new Element(By.XPath("//h2[@data-qa='info-image-left-header']"));
        public static Element WhatIsEO_IMG => new Element(By.XPath("//img[@data-qa='info-image-left-image'][1]"));
        public static Element WhatIsEOText => new Element(By.XPath("//p[@data-qa='info-image-left-text-0']"));

        //White Banner - What Does Errors & Omissions Insurance Cover?
        public static Element WhatDoesEOCover => new Element(By.XPath("(//h2[@data-qa='what-is-header'])[1]"));
        public static Element WhatDoesEOCoverText => new Element(By.XPath("(//p[@data-qa='what-is-main-text'])[1]"));

        // ---------- Flip Cards -------------

        //Unfufilled Duties
        private static Element UnfufilledDuties => new Element(By.XPath("(//h4[@data-qa='card-1-title'])[1]"));
        private static Element UnfufilledDuties_IMG => new Element(By.XPath("(//img[@data-qa='what-is-card-1'])[1]"));
        private static Element UnfufilledDutiesText => new Element(By.XPath("(//p[@data-qa='broader-coverage-text'])[1]"));
        //Negligence
        private static Element Negligence => new Element(By.XPath("(//h4[@data-qa='card-2-title'])[1]"));
        private static Element Negligence_IMG => new Element(By.XPath("(//img[@data-qa='what-is-card-2'])[1]"));
        private static Element NegligenceText => new Element(By.XPath("(//p[@data-qa='card-text_2'])[1]"));
        //Errors
        private static Element Errors => new Element(By.XPath("(//h4[@data-qa='card-3-title'])[1]"));
        private static Element Errors_IMG => new Element(By.XPath("(//img[@data-qa='what-is-card-3'])[1]"));
        private static Element ErrorsText => new Element(By.XPath("(//p[@data-qa='card-text_3'])[1]"));

        public static Element WhatIsEO_CoversCost => new Element(By.XPath("(//p[@data-qa='what-is-bottom-text'])[1]"));

        public static IStaticInteraction UnfufilledDutiesFlipCard => new FlipCard(UnfufilledDuties, UnfufilledDuties_IMG, UnfufilledDutiesText);
        public static IStaticInteraction NegligenceFlipCard => new FlipCard(Negligence, Negligence_IMG, NegligenceText);
        public static IStaticInteraction ErrorsFlipCard => new FlipCard(Errors, Errors_IMG, ErrorsText);
        //----------Flip Card End-------------

        //Why biBERK E&O Insurance?
        public static Element WhyOurEOIns => new Element(By.XPath("//h2[@data-qa='why-biberk-header']"));
        public static Element WhyOurEOInsText => new Element(By.XPath("//p[@data-qa='subheader-text-label']"));

        // Save Time, Save Money, Experienced flipcards

        // Blue Banner -  Who Should Consider Errors and Omissions Coverage?
        public static Element WhoShouldConsiderEO => new Element(By.XPath("//h2[@data-qa='list-header-label']"));
        public static Element WhoShouldConsiderEOText => new Element(By.XPath("//p[@data-qa='list-main-text-label']"));
        public static Element WhoShouldConsiderEOList => new Element(By.XPath("//ul[@data-qa='coverage-list']"));

        //White Banner - Get an Errors and Omissions Insurance Quote
        public static Element GetEOQuote => new Element(By.XPath("//h2[@data-qa='info-image-right-header']"));
        public static Element BestWayToUnderstand => new Element(By.XPath("//p[@data-qa='info-image-right-text-0']"));
        public static Element WhenItComesToEO => new Element(By.XPath("//p[@data-qa='info-image-right-text-1']"));
        public static Element GetEOQuote_IMG => new Element(By.XPath("//img[@data-qa='info-image-right-image']"));

        //Errors and Omissions Coverage: Protection Beyond Claims
        public static Element ProtectionBeyondClaims => new Element(By.XPath("(//h2[@data-qa='what-is-header'])[2]"));
        public static Element ProtectionBeyondClaimsText => new Element(By.XPath("(//p[@data-qa='what-is-main-text'])[2]"));

        // ---------- Flip Cards -------------
        private static Element PastServiceClaims_IMG => new Element(By.XPath("(//img[@data-qa='what-is-card-1'])[2]"));
        private static Element PastServiceClaims => new Element(By.XPath("(//h4[@data-qa='card-1-title'])[2]"));
        private static Element PastServiceClaimsText => new Element(By.XPath("(//p[@data-qa='broader-coverage-text'])[2]"));

        private static Element LegalCosts => new Element(By.XPath("(//h4[@data-qa='card-2-title'])[2]"));
        private static Element LegalCosts_IMG => new Element(By.XPath("(//img[@data-qa='what-is-card-2'])[2]"));
        private static Element LegalCostsText => new Element(By.XPath("(//p[@data-qa='card-text_2'])[2]"));

        private static Element CyberLiabilities => new Element(By.XPath("(//h4[@data-qa='card-3-title'])[2]"));
        private static Element CyberLiabilities_IMG => new Element(By.XPath("(//img[@data-qa='what-is-card-3'])[2]"));
        private static Element CyberLiabilitiesText => new Element(By.XPath("(//p[@data-qa='card-text_3'])[2]"));

        public static IStaticInteraction PastServiceClaimsFlipCard => new FlipCard(PastServiceClaims, PastServiceClaims_IMG, PastServiceClaimsText);
        public static IStaticInteraction LegalCostsFlipCard => new FlipCard(LegalCosts, LegalCosts_IMG, LegalCostsText);
        public static IStaticInteraction CyberLiabilitiesFlipCard => new FlipCard(CyberLiabilities, CyberLiabilities_IMG, CyberLiabilitiesText);
        // ---------- Flip Cards End -------------

        //Understanding E&O Insurance Retroactive Dates
        public static Element UnderstandingEORetro => new Element(By.XPath("(//h2[@data-qa='two-columns-with-header-header'])[1]"));
        public static Element HavingARetoText => new Element(By.XPath("(//p[@data-qa='two-columns-with-header-col-one-row-one-text'])[1]"));
        public static Element SinceTheOccurrence => new Element(By.XPath("(//p[@data-qa='two-columns-with-header-col-two-row-one-text'])[1]"));

        //Blue Banner - Are You Required to Have Errors and Omissions Coverage?
        public static Element AreYouRequiredEO => new Element(By.XPath("(//h2[@data-qa='info-image-left-header'])[2]"));
        public static Element AreYouRequiredEO_IMG => new Element(By.XPath("//img[@data-qa='info-image-left-image']"));
        public static Element AreYouRequiredEOText => new Element(By.XPath("//p[@data-qa='info-image-left-text-0']"));

        //White Banner - What Isn’t Covered by Errors & Omissions Insurance?
        public static Element WhatIsntCoveredEO => new Element(By.XPath("(//h2[@data-qa='two-columns-with-header-header'])[2]"));
        public static Element WhatIsntCoveredEOText => new Element(By.XPath("//p[@data-qa='two-columns-with-header-lead-text']"));
        public static Element IllegalActs => new Element(By.XPath("//h6[@data-qa='two-columns-with-header-col-one-row-one-header']"));
        public static Element IllegalActsText => new Element(By.XPath("(//p[@data-qa='two-columns-with-header-col-one-row-one-text'])[2]"));
        public static Element RegularAccidents => new Element(By.XPath("//h6[@data-qa='two-columns-with-header-col-two-row-one-header']"));
        public static Element RegularAccidentsText => new Element(By.XPath("(//p[@data-qa='two-columns-with-header-col-two-row-one-text'])[2]"));
        public static Element EmployeeInjuries => new Element(By.XPath("//h6[@data-qa='two-columns-with-header-col-one-row-two-header']"));
        public static Element EmployeeInjuriesText => new Element(By.XPath("//p[@data-qa='two-columns-with-header-col-one-row-two-text']"));
        public static Element DamagesToBiz => new Element(By.XPath("(//h6[@data-qa='two-columns-with-header-col-two-row-two-header'])"));
        public static Element DamagesToBizText => new Element(By.XPath("//p[@data-qa='two-columns-with-header-col-two-row-two-text']"));

        //What Does Errors and Omissions Insurance Cost? 
        public static Element WhatDoesEOCost => new Element(By.XPath("//h2[@data-qa='info-image-left-main-header']"));
        public static Element WhatDoesEOCostText => new Element(By.XPath("//p[@data-qa='info-image-left-main-text']"));
        public static Element StateCoverage => new Element(By.XPath("//h3[@data-qa='info-image-left-header-below-image']"));
        public static Element StateCoverage_IMG => new Element(By.XPath("//img[@data-qa='info-image-left-image']"));
        public static Element StateCoverageMapCTA => new Element(By.XPath("//a[@data-qa='info-image-left-button-below-image']"));

        //How do I Save Money on Errors and Omissions Coverage?
        public static Element HowDoISaveOnEO => new Element(By.XPath("//h3[@data-qa='info-image-left-header']"));
        public static Element PurchaseRightAmount => new Element(By.XPath("//li[@data-qa='info-image-left-list-0']"));
        public static Element ChooseHigherDeductible => new Element(By.XPath("//li[@data-qa='info-image-left-list-1']"));
        public static Element BuyFromUs => new Element(By.XPath("//li[@data-qa='info-image-left-list-2']"));

        /**
         Errors & Omissions Insurance Frequently Asked Questions (FAQs)
         **/

        public static Element EOFAQ => new Element(By.XPath("//h2[@data-qa='faq-header']"));
        public static Element EOFAQText => new Element(By.XPath("//p[@data-qa='faq-subheader']"));
        //What is errors and omissions insurance?
        private static Element WhatIsEOFAQ => new Element(By.XPath("//h3[@data-qa='faq-question-1-question']"));
        private static Element WhatIsEOFAQText => new Element(By.XPath("//p[@data-qa='faq-question-1-answer']"));
        private static Element WhatIsEOFAQArrow => new Element(By.XPath("//i[@data-qa='faq-question-1-arrow']"));
        //What is the difference between professional liability and errors and ommissions insurance
        private static Element DiffBetweenPLFAQ => new Element(By.XPath("//h3[@data-qa='faq-question-2-question']"));
        private static Element DiffBetweenPLFAQText => new Element(By.XPath("//p[@data-qa='faq-question-2-answer']"));
        private static Element DiffBetweenPLFAQArrow => new Element(By.XPath("//i[@data-qa='faq-question-2-arrow']"));
        //What is a retroactive date?
        private static Element WhatIsRetroDateFAQ => new Element(By.XPath("//h3[@data-qa='faq-question-3-question']"));
        private static Element WhatIsRetroDateFAQText => new Element(By.XPath("//p[@data-qa='faq-question-3-answer']"));
        private static Element WhatIsRetroDateFAQArrow => new Element(By.XPath("//i[@data-qa='faq-question-3-arrow']"));
        //How much does errors and omissions insurance cost?
        private static Element EOCostFAQ => new Element(By.XPath("//h3[@data-qa='faq-question-4-question']"));
        private static Element EOCostFAQText => new Element(By.XPath("//p[@data-qa='faq-question-4-answer']"));
        private static Element EOCostFAQArrow => new Element(By.XPath("//i[@data-qa='faq-question-4-arrow']"));
        //Who needs errors and omissions insurance?
        private static Element WhoNeedsEOFAQ => new Element(By.XPath("//h3[@data-qa='faq-question-5-question']"));
        private static Element WhoNeedsEOFAQText => new Element(By.XPath("//p[@data-qa='faq-question-5-answer']"));
        private static Element WhoNeedsEOFAQArrow => new Element(By.XPath("//i[@data-qa='faq-question-5-arrow']"));

        public static IStaticInteraction WhatIsEOFAQSection => new CoveragePageFAQ(WhatIsEOFAQ, WhatIsEOFAQText, WhatIsEOFAQArrow);
        public static IStaticInteraction DiffBetweenPLFAQSection => new CoveragePageFAQ(DiffBetweenPLFAQ, DiffBetweenPLFAQText, DiffBetweenPLFAQArrow);
        public static IStaticInteraction WhatIsRetroDateFAQSection => new CoveragePageFAQ(WhatIsRetroDateFAQ, WhatIsRetroDateFAQText, WhatIsRetroDateFAQArrow);
        public static IStaticInteraction EOCostFAQSection => new CoveragePageFAQ(EOCostFAQ, EOCostFAQText, EOCostFAQArrow);
        public static IStaticInteraction WhoNeedsEOFAQSection => new CoveragePageFAQ(WhoNeedsEOFAQ, WhoNeedsEOFAQText, WhoNeedsEOFAQArrow);

        //Blue Banner - Get a EO Quote Today
        public static Element GetEOToday => new Element(By.XPath("//h2[@data-qa='get-a-quote-label']"));
        public static Element GetEOTodayText => new Element(By.XPath("//p[@data-qa='trust-biberk-quote']"));
        public static Element GetEOTodayQuoteCTA => new Element(By.XPath("//a[@data-qa='get-a-quote-button_2']"));
    }
}