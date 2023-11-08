using BiBerkLOB.StepDefinition.General.Other.Coverages;
using HitachiQA.Driver;
using OpenQA.Selenium;
using BiBerkLOB.Pages.Other;
using BiBerkLOB.Source.Driver.SimpleInteractions;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.CommAuto
{
    [StaticPageName("CA Coverage")]
    public sealed class CommAutoPage : IStaticPage
    {
        /*
         * Picture Banner - Commercial Auto Insurance
         */
        public static Element CommercialAutoInsurance => new Element(By.XPath("//h1[@data-qa='commercial-auto-insurance']"));
        //Secure the coverage you need for your vehicles quickly and efficiently.
        public static Element SecureCoverNeed => new Element(By.XPath("//div[@data-qa='page-banner-subtitle']"));
        public static Element GetAQuoteCTA => new Element(By.XPath("//button[@data-qa='page-banner-button']"));

        /*
         * White Banner - Protect Your Commercial Vehicles
         */
        public static Element ReviewRatingText => new Element(By.XPath("//p[@data-qa='review-teaser-text']"));
        public static Element ProtectYourComVehicles => new Element(By.XPath("//h2[@data-qa='main-header-label']"));
        public static Element ProtectYourComVehiclesParagraph => new Element(By.XPath("//p[@data-qa='first-text-label']"));
        public static Element WhatIsComAutoIns => new Element(By.XPath("//h6[@data-qa='subheader-label']"));
        public static Element WhatIsComAutoInsParagraph => new Element(By.XPath("//p[@data-qa='second-text-label']"));

        /*
         * Blue Banner - What Vehicles are Covered by Small Business Car Insurance?
         */
        public static Element WhatVehCovered => new Element(By.XPath("(//h2[@data-qa='list-header-label'])[1]"));
        public static Element WhatVehCoveredParagraph => new Element(By.XPath("//p[@data-qa='CA-list-main-text-label']"));
        public static Element WhatVehCoveredScrollBar => new Element(By.XPath("(//ul[@data-qa='coverage-list'])[1]"));
        /*
         * Grey Banner - What Does Commercial Auto Insurance Cover?
         */
        public static Element WhatDoesComAutoCover => new Element(By.XPath("//h2[@data-qa='more-info-header-label']"));
        public static Element BodilyInjury => new Element(By.XPath("//h6[@data-qa='more-info-label_1']"));
        public static Element BodilyInjuryParagraph => new Element(By.XPath("//p[@data-qa='more-info-text_1']"));
        public static Element PropertyDamage => new Element(By.XPath("//h6[@data-qa='more-info-headerl_2']"));
        public static Element PropertyDamageParagraph => new Element(By.XPath("//p[@data-qa='more-info-text_2']"));
        public static Element MedicalPayments => new Element(By.XPath("(//h6[@data-qa='more-info-header_3'])[1]"));
        public static Element MedicalPaymentsParagraph => new Element(By.XPath("//p[@data-qa='more-info-text_3']"));
        public static Element UninsurMotorist => new Element(By.XPath("//h6[@data-qa='more-info-header_4']"));
        public static Element UninsurMotoristParagraph => new Element(By.XPath("//p[@data-qa='more-info-text_4']"));
        public static Element CompPhysDamage => new Element(By.XPath("(//h6[@data-qa='more-info-header_5'])[1]"));
        public static Element CompPhysDamageParagraph => new Element(By.XPath("//p[@data-qa='more-info-text_5']"));
        public static Element CollisionCov => new Element(By.XPath("//h6[@data-qa='more-info-header_6']"));
        public static Element CollisionCovParagraph => new Element(By.XPath("//h6[@data-qa='more-info-header_6']"));

        /*
         * Blue Banner - Who Should Consider Small Business Auto Insurance?
         */
        public static Element WhoShouldConsider => new Element(By.XPath("(//h2[@data-qa='list-header-label'])[2]"));
        public static Element WhoShouldConsiderParagraph => new Element(By.XPath("(//h2[@data-qa='list-header-label'])[2]"));
        public static Element WhoShouldConsiderScrollBar => new Element(By.XPath("(//ul[@data-qa='coverage-list'])[2]"));
        /*
         * White Banner - Why Does Your Company Need Small Business Car Insurance?
         */
        public static Element WhyDoesYourCompany => new Element(By.XPath("//h2[@data-qa='state-selector-header']"));
        public static Element WhyDoesYourCompanyParagraph => new Element(By.XPath("//p[@data-qa='CA-state-selector-text']"));
        public static Element FindYourInsCov => new Element(By.XPath("//h3[@data-qa='dropdown-header']")); 
        public static Element FindYourInsCovDD => new Element(By.XPath("//input[@data-qa='state-dropdown-trigger']"));
        public static Element FindYourInsCovSearchButton => new Element(By.XPath("//a[@data-qa='state-dropdown-button']"));

        /*
         * Blue Banner - What is the Difference Between Commercial and Personal Auto Insurance?
         */
        public static Element WhatIsDiff => new Element(By.XPath("//h2[@data-qa='info-image-left-header']"));
        public static Element WhatIsDiffParagraph => new Element(By.XPath("//p[@data-qa='info-image-left-text-0']"));
        public static Element WhatIsDiffImage => new Element(By.XPath("//img[@data-qa='info-image-left-image']"));
 
        /*
         * White Banner - Small Business Insurance Experts
         */
        public static Element WhybiBERK => new Element(By.XPath("//h2[@data-qa='why-biberk-header']"));
        public static Element WhybiBERKParagraph => new Element(By.XPath("//p[@data-qa='subheader-text-label_2']"));

        //Save Time, Save Money, Experienced Sections
        public static Element SaveTimeHead => new Element(By.XPath("//h3[@data-qa='three-column-about-card1-title']"));
        public static Element SaveTimePara => new Element(By.XPath("//p[@data-qa='three-column-about-card1-text']"));
        public static Element SaveMoneyHead => new Element(By.XPath("//h3[@data-qa='three-column-about-card2-title']"));
        public static Element SaveMoneyPara => new Element(By.XPath("//p[@data-qa='three-column-about-card2-text']"));
        public static Element ExperiencedHead => new Element(By.XPath("//h3[@data-qa='three-column-about-card3-title']"));
        public static Element ExperiencedPara => new Element(By.XPath("//p[@data-qa='three-column-about-card3-text']"));

        /*
         * Grey Banner - What's not Covered by Small Business Auto Insurance?
         */
        public static Element WhatsNotCovered => new Element(By.XPath("//h2[@data-qa='more-info-main-header']"));
        public static Element WhatsNotCoveredParagraph => new Element(By.XPath("//p[@data-qa='more-info-main-text']"));

        //Intended or expected property damange or injuries
        public static Element IntendedDamage => new Element(By.XPath("//h6[@data-qa='more-info-header_1']"));
        public static Element IntendedDamageParagraph => new Element(By.XPath("//p[@data-qa='more-info-first-content-text']"));

        //Racing
        public static Element Racing => new Element(By.XPath("//h6[@data-qa='more-info-header_2']"));
        public static Element RacingParagraph => new Element(By.XPath("//p[@data-qa='more-info-third-content-text']"));

        //Mobile Equipment Operation
        public static Element Mobile => new Element(By.XPath("(//h6[@data-qa='more-info-header_3'])[2]"));
        public static Element MobileParagraph => new Element(By.XPath("//p[@data-qa='more-info-fourth-content-text']"));

        //Injuries covered under workers' compensation
        public static Element InjuriesCoveredWC => new Element(By.XPath("(//h6[@data-qa='more-info-header_5'])[2]"));
        public static Element InjuriesCoveredWCParagraph => new Element(By.XPath("//p[@data-qa='more-info-second-content-text']"));

        //Hired and non-owned vehicles
        public static Element HiredAndNonOwned => new Element(By.XPath("//h6[@data-qa='more-info-header_7']"));
        public static Element HiredAndNonOwnedParagraph => new Element(By.XPath("//p[@data-qa='more-info-fifth-content-text']"));

        //This is a partial list of exclusions.  Our insurance experts can provide more details.
        public static Element PartialListExclusions => new Element(By.XPath("(//div[@class='col s12 '])[2]"));

        /*
         * Blue Banner - How Much is Commercial Auto Insurance?
         */
        public static Element HowMuchIsComm => new Element(By.XPath("//h2[@data-qa='how-much-label']"));
        public static Element HowMuchIsCommParagraph => new Element(By.XPath("//p[@data-qa='how-much-text']"));
        public static Element HowMuchIsCommImage => new Element(By.XPath("//img[@data-qa='how-much-image']"));

        /*
         * Blue Banner - Get a Commercial Auto Insurance Quote
         */
        public static Element GetCAInsQuote => new Element(By.XPath("//h2[@data-qa='get-a-quote-label']"));
        public static Element FindOutAffordable => new Element(By.XPath("//p[@data-qa='trust-biberk-quote']"));
        public static Element GetCAInsQuoteCTA => new Element(By.XPath("//a[@data-qa='get-a-quote-button_2']"));

        /*
         * Commercial Auto Insurance FAQs
         */
        public static Element CAFAQsHeader => new Element(By.XPath("//h2[@data-qa='faq-header']"));
        public static Element CAFAQsParagraph => new Element(By.XPath("//p[@data-qa='faq-subheader']"));

        //What is commercial auto insurance for a small business?
        private static Element WhatIsCAIns => new Element(By.XPath("//h3[@data-qa='faq-question-1-question']"));
        private static Element WhatIsCAInsParagraph => new Element(By.XPath("//p[@data-qa='CA-first-faq']"));
        private static Element WhatIsCAInsArrow => new Element(By.XPath("//i[@data-qa='faq-question-1-arrow']"));

        //How much does commercial auto insurance cost on average?
        private static Element HowMuchCAIns => new Element(By.XPath("//h3[@data-qa='faq-question-2-question']"));
        private static Element HowMuchCAInsParagraph => new Element(By.XPath("//p[@data-qa='CA-second-faq']"));
        private static Element HowMuchCAInsArrow => new Element(By.XPath("//i[@data-qa='faq-question-2-arrow']"));

        //Is my business vehicle covered by my commercial auto policy when I’m using it for personal activities?
        private static Element CoveredForPersonal => new Element(By.XPath("//h3[@data-qa='faq-question-3-question']"));
        private static Element CoveredForPersonalParagraph => new Element(By.XPath("//p[@data-qa='CA-third-faq']"));
        private static Element CoveredForPersonalArrow => new Element(By.XPath("//i[@data-qa='faq-question-3-arrow']"));


        //For damage caused by at-fault accidents, which drivers are covered by my small business auto insurance?
        private static Element AtFaultAccidentsCovered => new Element(By.XPath("//h3[@data-qa='faq-question-4-question']"));
        private static Element AtFaultAccidentsCoveredParagraph => new Element(By.XPath("//p[@data-qa='CA-fourth-faq']"));
        private static Element AtFaultAccidentsCoveredArrow => new Element(By.XPath("//i[@data-qa='faq-question-4-arrow']"));

        //Will my insurance cost increase if I’m involved in an accident in my covered vehicle?
        private static Element InsCostIncrease => new Element(By.XPath("//h3[@data-qa='faq-question-5-question']"));
        private static Element InsCostIncreaseParagraph => new Element(By.XPath("//p[@data-qa='CA-fifth-faq']"));
        private static Element InsCostIncreaseArrow => new Element(By.XPath("//i[@data-qa='faq-question-5-arrow']"));

        //Does my small business car insurance cover items stolen from my vehicle?
        private static Element CoverItemsStolen => new Element(By.XPath("//h3[@data-qa='faq-question-6-question']"));
        private static Element CoverItemsStolenParagraph => new Element(By.XPath("//p[@data-qa='CA-sixth-faq']"));
        private static Element CoverItemsStolenArrow => new Element(By.XPath("//i[@data-qa='faq-question-6-arrow']"));


        //If I’m pulling a trailer with a vehicle that’s covered under my policy, is the trailer automatically covered?
        private static Element TrailerAutomaticallyCover => new Element(By.XPath("//h3[@data-qa='faq-question-7-question']"));
        private static Element TrailerAutomaticallyCoverParagraph => new Element(By.XPath("//p[@data-qa='CA-seventh-faq']"));
        private static Element TrailerAutomaticallyCoverArrow => new Element(By.XPath("//i[@data-qa='faq-question-7-arrow']"));
        
        //What is combined single limit (CSL) versus split limit coverage?
        private static Element WhatCSLvSplit => new Element(By.XPath("//h3[@data-qa='faq-question-8-question']"));
        private static Element WhatCSLvSplitParagraph => new Element(By.XPath("//p[@data-qa='CA-eighth-faq']"));
        private static Element WhatCSLvSplitArrow => new Element(By.XPath("//i[@data-qa='faq-question-8-arrow']"));

        public static IStaticInteraction WhatIsCAInsFAQ => new CoveragePageFAQ(WhatIsCAIns,WhatIsCAInsParagraph, WhatIsCAInsArrow);
        public static IStaticInteraction HowMuchCAInsFAQ => new CoveragePageFAQ(HowMuchCAIns,HowMuchCAInsParagraph, HowMuchCAInsArrow);
        public static IStaticInteraction CoveredForPersonalFAQ => new CoveragePageFAQ(CoveredForPersonal,CoveredForPersonalParagraph, CoveredForPersonalArrow);
        public static IStaticInteraction AtFaultAccidentsCoveredFAQ => new CoveragePageFAQ(AtFaultAccidentsCovered,AtFaultAccidentsCoveredParagraph, AtFaultAccidentsCoveredArrow);
        public static IStaticInteraction InsCostIncreaseFAQ => new CoveragePageFAQ(InsCostIncrease,InsCostIncreaseParagraph, InsCostIncreaseArrow);
        public static IStaticInteraction CoverItemsStolenFAQ => new CoveragePageFAQ(CoverItemsStolen,CoverItemsStolenParagraph, CoverItemsStolenArrow);
        public static IStaticInteraction TrailerAutomaticallyCoverFAQ => new CoveragePageFAQ(TrailerAutomaticallyCover,TrailerAutomaticallyCoverParagraph, TrailerAutomaticallyCoverArrow);
        public static IStaticInteraction WhatCSLvSplitFAQ => new CoveragePageFAQ(WhatCSLvSplit, WhatCSLvSplitParagraph, WhatCSLvSplitArrow);
    }
}