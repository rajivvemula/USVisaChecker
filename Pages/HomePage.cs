using BiBerkLOB.Pages.Other;
using DocumentFormat.OpenXml.InkML;
using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiBerkLOB.Pages;
using BiBerkLOB.Source.Driver.SimpleInteractions;

namespace BiBerkLOB.Pages
{
    [StaticPageName("Home")]
    public class HomePage : Reusable_PurchasePath, IStaticPage
    {
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// ██╗  ██╗███████╗ █████╗ ██████╗ ███████╗██████╗ 
        /// ██║  ██║██╔════╝██╔══██╗██╔══██╗██╔════╝██╔══██╗
        /// ███████║█████╗  ███████║██║  ██║█████╗  ██████╔╝
        /// ██╔══██║██╔══╝  ██╔══██║██║  ██║██╔══╝  ██╔══██╗
        /// ██║  ██║███████╗██║  ██║██████╔╝███████╗██║  ██║
        /// ╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝╚═════╝ ╚══════╝╚═╝  ╚═╝
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //header footer mappings are in Reusable_PurchasePath.cs


        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// ██████╗  ██████╗ ██████╗ ██╗   ██╗
        /// ██╔══██╗██╔═══██╗██╔══██╗╚██╗ ██╔╝
        /// ██████╔╝██║   ██║██║  ██║ ╚████╔╝ 
        /// ██╔══██╗██║   ██║██║  ██║  ╚██╔╝  
        /// ██████╔╝╚██████╔╝██████╔╝   ██║   
        /// ╚═════╝  ╚═════╝ ╚═════╝    ╚═╝   
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //Small Business Insurance Made Simple
        public static Element BusinessInsMadeSimple => new Element(By.XPath("//a[@data-qa='page-banner']//h1[text()='Small Business Insurance Made Simple']"));
        //Instant Coverage. Big Savings. Insurance Experts.
        public static Element InstantCovBigSavInsrExperts => new Element(By.XPath("//a[@data-qa='page-banner']//div[text()='Instant Coverage. Big Savings. Insurance Experts.']"));
        // Home page Get a Quote CTA
        public static Element QuoteCTA => new Element(By.XPath("//a[@data-qa='get-a-quote-button_2']"));

        /*
         * Dark Blue Banner containing the links: "Workers' Compensation", "Professional Liability(E&O)", "General Liability", "Business Owners(BOPCTA)", "Commercial Auto", "Umbrella"
         */
        public static Element DarkBlueBannerWCCTA => new Element(By.XPath("//a[@data-qa='banner-lobs-link-wc']"));
        public static Element DarkBlueBannerPLCTA => new Element(By.XPath("//a[@data-qa='banner-lobs-link-pl']"));
        public static Element DarkBlueBannerGLCTA => new Element(By.XPath("//a[@data-qa='banner-lobs-link-gl']"));
        public static Element DarkBlueBannerBOPCTA => new Element(By.XPath("//a[@data-qa='banner-lobs-link-bop']"));
        public static Element DarkBlueBannerCACTA => new Element(By.XPath("//a[@data-qa='banner-lobs-link-ca']"));
        public static Element DarkBlueBannerUMCTA => new Element(By.XPath("//a[@data-qa='banner-lobs-link-um']"));

        /*
         * 4.9 out of 5 customer review rating and 150,000+ policies sold are in Reusable_PurchasePath.cs
         */

        /*
         * 3 Simple Steps to Instant Coverage
         */
        public static Element SimpleStepsToInstant => new Element(By.XPath("//h2[@data-qa='general-info-heading']"));
        public static Element BiberkProudToBePartOf => new Element(By.XPath("//p[@data-qa='general-info-text']"));
        public static Element Number1Circle => new Element(By.XPath("//div[@data-qa='general-info-step-1-number']"));
        public static Element Number1Text => new Element(By.XPath("//div[@data-qa='general-info-step-1-number']/span"));
        public static Element Number2Circle => new Element(By.XPath("//div[@data-qa='general-info-step-2-number']"));
        public static Element Number2Text => new Element(By.XPath("//div[@data-qa='general-info-step-2-number']/span"));
        public static Element Number3Circle => new Element(By.XPath("//div[@data-qa='general-info-step-3-number']"));
        public static Element Number3Text => new Element(By.XPath("//div[@data-qa='general-info-step-3-number']/span"));

        /*
         * Explore Our Small Business Insurance Products
         */
        public static Element ExploreSmallBusinessInsProducts => new Element(By.XPath("//h2[@data-qa='insurance-products-header']"));

        //Workers' Compensation Tabbed Page
        public static Element ClickableTabWC => new Element(By.XPath("//li[@data-qa='insurance-products-product-one']"));
        protected static Element WCTitleInsideTab => new Element(By.XPath("//a[@data-qa='insurance-products-product-one-header']"));
        protected static Element WCText_Mandatory => new Element(By.XPath("//p[@data-qa='insurance-products-product-one-text']"));
        protected static Element WCText_BestFor => new Element(By.XPath("//p[@data-qa='insurance-products-product-one-best-for-text']"));
        protected static Element WCText_Employees => new Element(By.XPath("//li[@data-qa='insurance-products-product-one-first-list-item']"));
        protected static Element WCText_Help => new Element(By.XPath("//li[@data-qa='insurance-products-product-one-second-list-item']"));
        protected static Element WCText_Lawsuits => new Element(By.XPath("//li[@data-qa='insurance-products-product-one-third-list-item']"));
        protected static Element WCText_GetAQuote => new Element(By.XPath("//a[@data-qa='insurance-products-product-one-cta-button']"));

        //Professional Liability Tabbed Page
        public static Element ClickableTabPL => new Element(By.XPath("//li[@data-qa='insurance-products-product-two']"));
        private static Element PLTitleInsideTab => new Element(By.XPath("//a[@data-qa='insurance-products-product-two-header']"));
        private static Element PLText_AlsoCalled => new Element(By.XPath("//p[@data-qa='insurance-products-product-two-text']"));
        private static Element PLText_BestFor => new Element(By.XPath("//p[@data-qa='insurance-products-product-two-best-for-text']"));
        private static Element PLText_Professional => new Element(By.XPath("//li[@data-qa='insurance-products-product-two-first-list-item']"));
        private static Element PLText_Unfuilfilled => new Element(By.XPath("//li[@data-qa='insurance-products-product-two-second-list-item']"));
        private static Element PLText_Scope => new Element(By.XPath("//li[@data-qa='insurance-products-product-two-third-list-item']"));
        private static Element PLText_GetAQuote => new Element(By.XPath("//a[@data-qa='insurance-products-product-two-cta-button']"));

        //General Liability Tabbed Page
        public static Element ClickableTabGL => new Element(By.XPath("//li[@data-qa='insurance-products-product-three']"));
        private static Element GLTitleInsideTab => new Element(By.XPath("//a[@data-qa='insurance-products-product-three-header']"));
        private static Element GLText_ThisPolicy => new Element(By.XPath("//p[@data-qa='insurance-products-product-three-text']"));
        private static Element GLText_BestFor => new Element(By.XPath("//p[@data-qa='insurance-products-product-three-best-for-text']"));
        private static Element GLText_Visitor => new Element(By.XPath("//li[@data-qa='insurance-products-product-three-first-list-item']"));
        private static Element GLText_Employee => new Element(By.XPath("//li[@data-qa='insurance-products-product-three-second-list-item']"));
        private static Element GLText_Libel => new Element(By.XPath("//li[@data-qa='insurance-products-product-three-third-list-item']"));
        private static Element GLText_GetAQuote => new Element(By.XPath("//a[@data-qa='insurance-products-product-three-cta-button']"));

        //Business Owners Policy Tabbed Page
        public static Element ClickableTabBOP => new Element(By.XPath("//li[@data-qa='insurance-products-product-four']"));
        private static Element BOPTitleInsideTab => new Element(By.XPath("//a[@data-qa='insurance-products-product-four-header']"));
        private static Element BOPText_Also => new Element(By.XPath("//p[@data-qa='insurance-products-product-four-text']"));
        private static Element BOPText_BestFor => new Element(By.XPath("//p[@data-qa='insurance-products-product-four-best-for-text']"));
        private static Element BOPText_Property => new Element(By.XPath("//li[@data-qa='insurance-products-product-four-first-list-item']"));
        private static Element BOPText_Injuries => new Element(By.XPath("//li[@data-qa='insurance-products-product-four-second-list-item']"));
        private static Element BOPText_Business => new Element(By.XPath("//li[@data-qa='insurance-products-product-four-third-list-item']"));
        private static Element BOPText_GetAQuote => new Element(By.XPath("//a[@data-qa='insurance-products-product-four-cta-button']"));

        //Commercial Auto Tabbed Page
        public static Element ClickableTabCA => new Element(By.XPath("//li[@data-qa='insurance-products-product-five']"));
        private static Element CATitleInsideTab => new Element(By.XPath("//a[@data-qa='insurance-products-product-five-header']"));
        private static Element CAText_Covers => new Element(By.XPath("//p[@data-qa='insurance-products-product-five-text']"));
        private static Element CAText_BestFor => new Element(By.XPath("//p[@data-qa='insurance-products-product-five-best-for-text']"));
        private static Element CAText_ThirdParty => new Element(By.XPath("//li[@data-qa='insurance-products-product-five-first-list-item']"));
        private static Element CAText_Damage => new Element(By.XPath("//li[@data-qa='insurance-products-product-five-second-list-item']"));
        private static Element CAText_Collision => new Element(By.XPath("//li[@data-qa='insurance-products-product-five-third-list-item']"));
        private static Element CAText_GetAQuote => new Element(By.XPath("//a[@data-qa='insurance-products-product-five-cta-button']"));

        //Umbrella Tabbed Page
        public static Element ClickableTabUM => new Element(By.XPath("//li[@data-qa='insurance-products-product-six']"));
        private static Element UMTitleInsideTab => new Element(By.XPath("//a[@data-qa='insurance-products-product-six-header']"));
        private static Element UMText_Protect => new Element(By.XPath("//p[@data-qa='insurance-products-product-six-text']"));
        private static Element UMText_BestFor => new Element(By.XPath("//p[@data-qa='insurance-products-product-six-best-for-text']"));
        private static Element UMText_Added => new Element(By.XPath("//li[@data-qa='insurance-products-product-six-first-list-item']"));
        private static Element UMText_Scenario => new Element(By.XPath("//li[@data-qa='insurance-products-product-six-second-list-item']"));
        private static Element UMText_Additional => new Element(By.XPath("//li[@data-qa='insurance-products-product-six-third-list-item']"));
        private static Element UMText_GetAQuote => new Element(By.XPath("//a[@data-qa='insurance-products-product-six-cta-button']"));

        public static IStaticInteraction InusranceProductsTabe =>
            new InsuranceProductsTabs(ClickableTabWC, ClickableTabPL,
                ClickableTabGL, ClickableTabBOP, ClickableTabCA, ClickableTabUM)
                .SetTabSections(ClickableTabWC, WCTitleInsideTab,
                    WCText_Mandatory, WCText_BestFor, WCText_Employees, WCText_Help,
                    WCText_Lawsuits, WCText_GetAQuote)
                .SetTabSections(ClickableTabPL, PLTitleInsideTab,
                    PLText_AlsoCalled, PLText_BestFor, PLText_Professional,
                    PLText_Unfuilfilled, PLText_Scope, PLText_GetAQuote)
                .SetTabSections(ClickableTabGL, GLTitleInsideTab,
                    GLText_ThisPolicy, GLText_BestFor, GLText_Visitor,
                    GLText_Employee, GLText_Libel, GLText_GetAQuote)
                .SetTabSections(ClickableTabBOP, BOPTitleInsideTab,
                    BOPText_Also, BOPText_BestFor, BOPText_Property, BOPText_Injuries,
                    BOPText_Business, BOPText_GetAQuote)
                .SetTabSections(ClickableTabCA, CATitleInsideTab,
                    CAText_Covers, CAText_BestFor, CAText_ThirdParty,
                    CAText_Damage, CAText_Collision, CAText_GetAQuote)
                .SetTabSections(ClickableTabUM, UMTitleInsideTab,
                    UMText_Protect, UMText_BestFor, UMText_Added,
                    UMText_Scenario, UMText_Additional, UMText_GetAQuote);

        /*
         * Dark Blue Banner - A Top Rated & Financially Secure Business Insurance Company (has pics of all subsidiaries)
         */
        //A Top-Rated & Financially Secure Business Insurance Company
        public static Element ATopRatedFinanciallySecure => new Element(By.XPath("//h2[@data-qa='top-rated-header']"));
        //biBERK is a small business insurance company that's part of the Berkshire Hathaway Insurance Group.  All of the company's major insurance subsidiaries are rated A++ by A.M. Best Company.  We have millions of customers and over 75 years of insurance experience.  Berkshire Hathaway paid $38 billion in cliams in 2020.
        public static Element ATopRatedFinanciallySecureParagraph => new Element(By.XPath("//p[@data-qa='top-rated-main-text']"));
        public static Element SubsidiaryImage_GEICO => new Element(By.XPath("//div[@data-qa='top-rated-logo-1']/img"));
        public static Element SubsidiaryImage_Guard => new Element(By.XPath("//div[@data-qa='top-rated-logo-2']/img"));
        public static Element SubsidiaryImage_NationalIndemnity => new Element(By.XPath("//div[@data-qa='top-rated-logo-3']/img"));
        public static Element SubsidiaryImage_MedPro => new Element(By.XPath("//div[@data-qa='top-rated-logo-4']/img"));
        public static Element SubsidiaryImage_BHSpecialityIns => new Element(By.XPath("//div[@data-qa='top-rated-logo-5']/img"));
        public static Element SubsidiaryImage_USLI => new Element(By.XPath("//div[@data-qa='top-rated-logo-6']/img"));
        public static Element SubsidiaryImage_BHHomestate => new Element(By.XPath("//div[@data-qa='top-rated-logo-7']/img"));
        public static Element SubsidiaryImage_THREE => new Element(By.XPath("//div[@data-qa='top-rated-logo-8']/a/img"));
        public static Element TheBerkshireHathawayInsuranceFamily => new Element(By.XPath("//p[@data-qa='top-rated-subtext']"));

        /*
         * What is Small Business Insurance?
         */
        public static Element WhatIsSmallBusinessIns => new Element(By.XPath("//h2[@data-qa='info-image-left-header']"));
        public static Element WhatIsSmallBusinessInsParagraph => new Element(By.XPath("//p[@data-qa='info-image-left-text-0']"));
        public static Element WhatIsSmallBusinessInsImage => new Element(By.XPath("//img[@data-qa='info-image-left-image']"));

        /*
         * Dark Blue Banner - What Does Small Business Insurance Cost?
         */
        public static Element WhatDoesSmBusinessInsCost => new Element(By.XPath("//h2[@data-qa='info-image-right-header']"));
        public static Element WhatDoesSmBusinessInsCostParagraphA => new Element(By.XPath("//p[@data-qa='info-image-right-text-0']"));
        public static Element WhatDoesSmBusinessInsCostParagraphB => new Element(By.XPath("//p[@data-qa='info-image-right-text-1']"));
        public static Element WhatDoesSmBusinessInsCostImage => new Element(By.XPath("//img[@data-qa='info-image-right-image']"));

        /*
         * Small Business Insurance Experts
         */
        public static Element SmallBusInsExperts => new Element(By.XPath("//h2[@data-qa='why-biberk-header']"));
        public static Element SmallBusInsExpertsParagraph => new Element(By.XPath("//p[@data-qa='subheader-text-label_2']"));
        // map the rest of these fields in Reusable_PurchasePath.cs

        /*
         * Small Business Insurance for Nearly Everyone
         */
        public static Element SmBusNearly => new Element(By.XPath("//h2[@data-qa='industries-header']"));
        public static Element SmBusNearlyParagraph => new Element(By.XPath("//p[@data-qa='industries-text']"));
        public static Element SmBusNearly_Accounting => new Element(By.XPath("//a[@data-qa='industries-link-1']"));
        public static Element SmBusNearly_Apartments => new Element(By.XPath("//a[@data-qa='industries-link-2']"));
        public static Element SmBusNearly_AutoServices => new Element(By.XPath("//a[@data-qa='industries-link-3']"));
        public static Element SmBusNearly_Cleaning => new Element(By.XPath("//a[@data-qa='industries-link-4']"));
        public static Element SmBusNearly_Construction => new Element(By.XPath("//a[@data-qa='industries-link-5']"));
        public static Element SmBusNearly_Health => new Element(By.XPath("//a[@data-qa='industries-link-6']"));
        public static Element SmBusNearly_Information => new Element(By.XPath("//a[@data-qa='industries-link-7']"));
        public static Element SmBusNearly_Lawn => new Element(By.XPath("//a[@data-qa='industries-link-8']"));
        public static Element SmBusNearly_Professionals => new Element(By.XPath("//a[@data-qa='industries-link-9']"));
        public static Element SmBusNearly_Restaurants => new Element(By.XPath("//a[@data-qa='industries-link-10']"));
        public static Element SmBusNearly_Retail => new Element(By.XPath("//a[@data-qa='industries-link-11']"));
        public static Element SmBusNearly_Transportation => new Element(By.XPath("//a[@data-qa='industries-link-12']"));
        public static Element ViewAllIndustriesBTN => new Element(By.XPath("//a[@data-qa='industries-button']"));

        /*
         * Real People. Real Coverage.
         */
        public static Element RealPpl => new Element(By.XPath("//h2[@data-qa='reviews-heading']"));
        public static Element RealPplYouTubeEmbedded => new Element(By.XPath("//div[@class='embed-video']"));
        public static Element RealPplCheckOutSome => new Element(By.XPath("//p[@data-qa='reviews-text']"));
        public static Element RealPplReadMoreReviewsButton => new Element(By.XPath("//a[@data-qa='reviews-read-more-button']"));

        /*
         * Small Business Insurance Frequently Asked Questions
         */
        public static Element SmBusFAQ => new Element(By.XPath("//h2[@data-qa='faq-header']"));
        public static Element SmBusFAQParagraph => new Element(By.XPath("//p[@data-qa='faq-subheader']"));

        //Am I required to have small business insurance?
        private static Element ReqHaveIns => new Element(By.XPath("//h3[@data-qa='faq-question-1-question']"));
        private static Element ReqHaveInsAccordionArrow => new Element(By.XPath("//i[@data-qa='faq-question-1-arrow']"));
        private static Element ReqHaveInsParagraph => new Element(By.XPath("//p[@data-qa='faq-question-1-answer']"));
        private static Element ReqHaveInsLink => new Element(By.XPath("//p[@data-qa='faq-question-1-answer']//parent::div//a"));
        public static IStaticInteraction ReqHaveInsAccordion =>
            new AccordionSection(ReqHaveIns, ReqHaveInsAccordionArrow,
                ReqHaveInsParagraph, ReqHaveInsLink);

        //Does biBERK provide business insurance in my state?
        private static Element InsInState => new Element(By.XPath("//h3[@data-qa='faq-question-2-question']"));
        private static Element InsInStateAccordionArrow => new Element(By.XPath("//i[@data-qa='faq-question-2-arrow']"));
        private static Element InsInStateParagraph => new Element(By.XPath("//p[@data-qa='faq-question-2-answer']"));
        private static Element InsInStateLink => new Element(By.XPath("//p[@data-qa='faq-question-2-answer']//parent::div//a"));
        public static IStaticInteraction InsInStateAccordion =>
            new AccordionSection(InsInState, InsInStateAccordionArrow,
                InsInStateParagraph, InsInStateLink);

        //What kind of small business insurance do I need?
        private static Element KindOfIns => new Element(By.XPath("//h3[@data-qa='faq-question-3-question']"));
        private static Element KindOfInsAccordionArrow => new Element(By.XPath("//i[@data-qa='faq-question-3-arrow']"));
        private static Element KindOfInsParagraph => new Element(By.XPath("//p[@data-qa='faq-question-3-answer']"));
        public static IStaticInteraction KindOfInsAccordion =>
            new AccordionSection(KindOfIns, KindOfInsAccordionArrow, KindOfInsParagraph);

        /*
         * Light Blue Banner - Get a Small Business Insurance Quote Today
         */
        public static Element GetSmBusQuoteToday => new Element(By.XPath("//h2[@data-qa='get-a-quote-label']"));
        public static Element GetSmBusQuote_TrustbiBERK => new Element(By.XPath("//p[@data-qa='trust-biberk-quote']"));
        public static Element GetSmBusQuote_GetAQuoteButton => new Element(By.XPath("//a[@data-qa='get-a-quote-button_2']"));

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// ███████╗ ██████╗  ██████╗ ████████╗███████╗██████╗ 
        /// ██╔════╝██╔═══██╗██╔═══██╗╚══██╔══╝██╔════╝██╔══██╗
        /// █████╗  ██║   ██║██║   ██║   ██║   █████╗  ██████╔╝
        /// ██╔══╝  ██║   ██║██║   ██║   ██║   ██╔══╝  ██╔══██╗
        /// ██║     ╚██████╔╝╚██████╔╝   ██║   ███████╗██║  ██║
        /// ╚═╝      ╚═════╝  ╚═════╝    ╚═╝   ╚══════╝╚═╝  ╚═╝
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //all footer mappings are in Reusable_PurchasePath.cs
    }
}