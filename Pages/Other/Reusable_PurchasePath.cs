using System;
using System.Collections.Generic;
using System.Text;
using HitachiQA.Driver;
using OpenQA.Selenium;

namespace BiBerkLOB.Pages
{
    public class Reusable_PurchasePath
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

        // 404 Error
        public static Element Error404 => new Element(By.XPath("//h1[@data-qa='404-error']"));

        // biBerk Logo
        public static Element Logo => new Element(By.XPath("//a[@data-qa='biBERK-Logo']"));
        public static Element CALogo => new Element(By.XPath("//a[@data-qa='header-homeButton']"));
        public static Element TalkToALicensedExpert => new Element(By.XPath("//a[@data-qa='talk-to-a-licensed-expert']"));
        public static Element PhoneNumberNotCA => new Element(By.XPath("//a[@data-qa='header-link-dekstop-phone-number']"));
        public static Element MonFri7AM9PM => new Element(By.XPath("//span[@data-qa='header-desktop-hours']"));
        public static Element NeedToFinishLater => new Element(By.XPath("//h6[@data-qa='sfl-text']"));
        public static Element SaveButton => new Element(By.XPath("//a[@data-qa='sfl-link']"));

        // Navigation Dropdown buttons:
        public static Element MobileHamburgerMenu => new Element(By.XPath("//button[@data-qa='header-trigger-mobile-menu-icon']"));
        public static Element CoverageDD => new Element(By.XPath("//a[@data-qa='header-trigger-desktop-coverage']"));
        public static Element SmallBusinessDD => new Element(By.XPath("//a[@data-qa='header-trigger-desktop-small-business']"));
        public static Element CertificateDD => new Element(By.XPath("//a[@data-qa='header-link-desktop-certificate']"));
        public static Element PolicyHoldersDD => new Element(By.XPath("//button[@data-qa='header-trigger-desktop-policyholders']"));
        public static Element MobilePolicyHoldersDD => new Element(By.XPath("//button[@data-qa='header-trigger-mobile-policyholders']"));
        public static Element AboutUsDD => new Element(By.XPath("//a[@data-qa='header-trigger-desktop-about-us']"));

        // Coverage Dropdown:
        public static Element InsuranceCoverageTitle => new Element(By.XPath("//a[@data-qa='header-link-desktop-coverage']"));
        public static Element WCCov => new Element(By.XPath("//a[@data-qa='header-link-desktop-wc']"));
        public static Element PLCov => new Element(By.XPath("//a[@data-qa='header-link-desktop-pl']"));
        public static Element EAndOCov => new Element(By.XPath("//a[@data-qa='header-link-desktop-e-and-o']"));
        public static Element GLCov => new Element(By.XPath("//a[@data-qa='header-link-desktop-gl']"));
        public static Element BOPCov => new Element(By.XPath("//a[@data-qa='header-link-desktop-bop']"));
        public static Element CACov => new Element(By.XPath("//a[@data-qa='header-link-desktop-ca']"));
        public static Element UMCov => new Element(By.XPath("//a[@data-qa='header-link-desktop-um']"));
        public static Element CyberCov => new Element(By.XPath("//a[@data-qa='header-link-desktop-cyber']"));
        public static Element CoverageClose => new Element(By.XPath("//div[@data-qa='header-close-desktop-states']"));

        // Small business Dropdown:
        public static Element SmallBusinessTitle => new Element(By.XPath("//a[@data-qa='header-link-desktop-small-business-insurance']"));
        // Industries
        public static Element IndustriesTitle => new Element(By.XPath("//a[@data-qa='header-link-desktop-industries']"));
        public static Element AccountingAndFinance => new Element(By.XPath("//a[@data-qa='header-link-desktop-industries-accounting']"));
        public static Element ApartmentsAndBuildings => new Element(By.XPath("//a[@data-qa='header-link-desktop-industries-apartments']"));
        public static Element AutoServicesAndDealers => new Element(By.XPath("//a[@data-qa='header-link-desktop-industries-auto-services']"));
        public static Element Bakery => new Element(By.XPath("//a[@data-qa='header-link-desktop-industries-bakery']"));
        public static Element CleaningAndJanitorial => new Element(By.XPath("//a[@data-qa='header-link-desktop-industries-cleaning']"));
        public static Element ConstructionAndContractor => new Element(By.XPath("//a[@data-qa='header-link-desktop-industries-construction']"));
        public static Element Consultant => new Element(By.XPath("//a[@data-qa='header-link-desktop-industries-consultant']"));
        public static Element Electrician => new Element(By.XPath("//a[@data-qa='header-link-desktop-industries-electrician']"));
        public static Element Healthcare => new Element(By.XPath("//a[@data-qa='header-link-desktop-industries-healthcare']"));
        public static Element Hotel => new Element(By.XPath("//a[@data-qa='header-link-desktop-industries-hotel']"));
        public static Element InformationTechnology => new Element(By.XPath("//a[@data-qa='header-link-desktop-industries-it']"));
        public static Element Landlord => new Element(By.XPath("//a[@data-qa='header-link-desktop-industries-landlord']"));
        public static Element LawnCareAndLandscaping => new Element(By.XPath("//a[@data-qa='header-link-desktop-industries-lawn-care']"));
        public static Element LiquorStore => new Element(By.XPath("//a[@data-qa='header-link-desktop-industries-liquor']"));
        public static Element Office => new Element(By.XPath("//a[@data-qa='header-link-desktop-industries-office']"));
        public static Element Restaurant => new Element(By.XPath("//a[@data-qa='header-link-desktop-industries-restaurant']"));
        public static Element Retail => new Element(By.XPath("//a[@data-qa='header-link-desktop-industries-retail']"));
        public static Element SmallBusiness => new Element(By.XPath("//a[@data-qa='header-link-desktop-industries-small-business']"));
        public static Element TownhouseAssociations => new Element(By.XPath("//a[@data-qa='header-link-desktop-industries-townhouse']"));
        public static Element Transportation => new Element(By.XPath("//a[@data-qa='header-link-desktop-industries-transportation']"));
        public static Element ViewAllIndustries => new Element(By.XPath("//a[@data-qa='header-link-desktop-industries-view-all']"));
        // States
        public static Element States => new Element(By.XPath("//a[@data-qa='header-link-desktop-states']"));
        public static Element Arizona => new Element(By.XPath("//a[@data-qa='header-link-desktop-states-az']"));
        public static Element California => new Element(By.XPath("//a[@data-qa='header-link-desktop-states-ca']"));
        public static Element Colorado => new Element(By.XPath("//a[@data-qa='header-link-desktop-states-co']"));
        public static Element Connecticut => new Element(By.XPath("//a[@data-qa='header-link-desktop-states-ct']"));
        public static Element Georgia => new Element(By.XPath("//a[@data-qa='header-link-desktop-states-ga']"));
        public static Element Illinois => new Element(By.XPath("//a[@data-qa='header-link-desktop-states-il']"));
        public static Element Indiana => new Element(By.XPath("//a[@data-qa='header-link-desktop-states-in']"));
        public static Element Louisiana => new Element(By.XPath("//a[@data-qa='header-link-desktop-states-la']"));
        public static Element Maryland => new Element(By.XPath("//a[@data-qa='header-link-desktop-states-md']"));
        public static Element Massachusetts => new Element(By.XPath("//a[@data-qa='header-link-desktop-states-ma']"));
        public static Element Michigan => new Element(By.XPath("//a[@data-qa='header-link-desktop-states-mi']"));
        public static Element Minnesota => new Element(By.XPath("//a[@data-qa='header-link-desktop-states-mn']"));
        public static Element Nebraska => new Element(By.XPath("//a[@data-qa='header-link-desktop-states-ne']"));
        public static Element NewJersey => new Element(By.XPath("//a[@data-qa='header-link-desktop-states-nj']"));
        public static Element NewYork => new Element(By.XPath("//a[@data-qa='header-link-desktop-states-ny']"));
        public static Element NorthCarolina => new Element(By.XPath("//a[@data-qa='header-link-desktop-states-nc']"));
        public static Element Oklahoma => new Element(By.XPath("//a[@data-qa='header-link-desktop-states-ok']"));
        public static Element Pennsylvania => new Element(By.XPath("//a[@data-qa='header-link-desktop-states-pa']"));
        public static Element SouthCarolina => new Element(By.XPath("//a[@data-qa='header-link-desktop-states-sc']"));
        public static Element Tennessee => new Element(By.XPath("//a[@data-qa='header-link-desktop-states-tn']"));
        public static Element Texas => new Element(By.XPath("//a[@data-qa='header-link-desktop-states-tx']"));
        public static Element Virginia => new Element(By.XPath("//a[@data-qa='header-link-desktop-states-va']"));
        public static Element ViewAllStates => new Element(By.XPath("//a[@data-qa='header-link-desktop-states-view-all']"));
        public static Element SmallBusinessClose => new Element(By.XPath("//div[@data-qa='header-close-desktop-states']"));

        // Policyholders Dropdown:
        public static Element PolicyHoldersTitle => new Element(By.XPath("//a[@data-qa='header-link-desktop-policyholders']"));
        public static Element GetACertificate => new Element(By.XPath("//a[@data-qa='header-link-desktop-policyholders-get-coi']"));
        public static Element MobileGetACertificate => new Element(By.XPath("//a[@data-qa='header-link-mobile-policyholders-get-coi']"));
        public static Element WorkersCompAudit => new Element(By.XPath("//a[@data-qa='header-link-desktop-policyholders-audit-wc']"));
        // Report A Claim:
        public static Element ReportAClaim => new Element(By.XPath("//a[@data-qa='header-link-desktop-policyholders-report-claim']"));
        public static Element WCClaim => new Element(By.XPath("//a[@data-qa='header-link-desktop-claims-wc']"));
        public static Element PLClaim => new Element(By.XPath("//a[@data-qa='header-link-desktop-claims-pl']"));
        public static Element GLClaim => new Element(By.XPath("//a[@data-qa='header-link-desktop-claims-gl']"));
        public static Element BOPClaim => new Element(By.XPath("//a[@data-qa='header-link-desktop-claims-bop']"));
        public static Element CAClaim => new Element(By.XPath("//a[@data-qa='header-link-desktop-claims-ca']"));
        public static Element UMClaim => new Element(By.XPath("//a[@data-qa='header-link-desktop-claims-um']"));
        // Make A Payment
        public static Element MakeAPayment => new Element(By.XPath("//a[@data-qa='header-link-desktop-policyholders-payment']"));
        public static Element MobileMakeAPayment => new Element(By.XPath("//a[@data-qa='header-link-mobile-policyholders-payment']"));
        public static Element AutoPayEnrollment => new Element(By.XPath("//a[@data-qa='header-link-desktop-policyholders-autopay']"));
        // Resources
        public static Element Resources => new Element(By.XPath("//a[@data-qa='header-link-desktop-policyholders-resources']"));
        public static Element Articles => new Element(By.XPath("//a[@data-qa='header-link-desktop-resources-articles']"));
        public static Element ResourceFAQs => new Element(By.XPath("//a[@data-qa='header-link-desktop-resources-faqs']"));
        public static Element EducationalFlyers => new Element(By.XPath("//a[@data-qa='header-link-desktop-resources-educational-flyers']"));
        public static Element SafetyVideos => new Element(By.XPath("//a[@data-qa='header-link-desktop-resources-safety-videos']"));
        public static Element EmployerPostingNotices => new Element(By.XPath("//a[@data-qa='header-link-desktop-resources-posting-notices']"));
        public static Element CaliforniaMPN => new Element(By.XPath("//a[@data-qa='header-link-desktop-resources-ca-mpn']"));
        public static Element ConnecticutMCP => new Element(By.XPath("//a[@data-qa='header-link-desktop-resources-cn-mcp']"));
        public static Element TexasMPN => new Element(By.XPath("//a[@data-qa='header-link-desktop-resources-tx-mpn']"));
        public static Element StormSafety => new Element(By.XPath("//a[@data-qa='header-link-desktop-resources-storm-safety']"));
        public static Element LossControl => new Element(By.XPath("//a[@data-qa='header-link-desktop-resources-loss-control']"));
        public static Element PolicyHoldersClose => new Element(By.XPath("//div[@data-qa='header-close-desktop-resources']"));

        // About Us
        public static Element AboutUsTitle => new Element(By.XPath("//a[@data-qa='header-link-desktop-about']"));
        public static Element AboutUsFAQs => new Element(By.XPath("//a[@data-qa='header-link-desktop-about-faqs']"));
        public static Element Reviews => new Element(By.XPath("//a[@data-qa='header-link-desktop-about-reviews']"));
        public static Element Careers => new Element(By.XPath("//a[@data-qa='header-link-desktop-about-careers']"));
        public static Element Partners => new Element(By.XPath("//a[@data-qa='header-link-desktop-about-partner']"));
        public static Element AboutUsClose => new Element(By.XPath("//div[@data-qa='header-close-desktop-about']"));

        //COMMERCIAL AUTO specific
        public static Element YourCommAutoQuoteID => new Element(By.XPath("//div[@data-qa='quoteID-ribbon']"));
        public static Element CABackCTA => new Element(By.XPath("//button[@data-qa='bbnav-navBack']"));
        //1-833-224-5431
        public static Element PhoneNumberCA => new Element(By.XPath("//a[@data-qa='footer-telephone']"));
        //Steppers
        public static Element CAStepper_1Coverage_Current => new Element(By.XPath("//mat-step-header[@aria-selected='true']//p[@data-qa='1-index']"));
        public static Element CAStepper_1Coverage_Past => new Element(By.XPath("//p[@data-qa='Coverage-Completed']//ancestor::div[@class='mat-step-label mat-step-label-active']//preceding-sibling::div/div/mat-icon[text()='done']"));
        public static Element CAStepper_2Operations_Before => new Element(By.XPath("//mat-step-header[@aria-selected='false']//p[@data-qa='2-index']"));
        public static Element CAStepper_2Operations_Current => new Element(By.XPath("//mat-step-header[@aria-selected='true']//p[@data-qa='2-index']"));
        public static Element CAStepper_2Operations_Past => new Element(By.XPath("//p[@data-qa='Operation-step']//ancestor::div[@class='mat-step-label mat-step-label-active']//preceding-sibling::div/div/mat-icon[text()='done']"));
        public static Element CAStepper_3AboutYou_Before => new Element(By.XPath("//mat-step-header[@aria-selected='false']//p[@data-qa='3-index']"));
        public static Element CAStepper_3AboutYou_Current => new Element(By.XPath("//mat-step-header[@aria-selected='true']//p[@data-qa='3-index']"));
        public static Element CAStepper_3AboutYou_Past => new Element(By.XPath("//p[@data-qa='About You-step']//ancestor::div[@class='mat-step-label mat-step-label-active']//preceding-sibling::div/div/mat-icon[text()='done']"));
        public static Element CAStepper_4Summary_Before => new Element(By.XPath("//mat-step-header[@aria-selected='false']//p[@data-qa='4-index']"));
        public static Element CAStepper_4Summary_Current => new Element(By.XPath("//mat-step-header[@aria-selected='true']//p[@data-qa='4-index']"));
        //Starting here, pattern established above breaks because the stepper disappears once you land on the Quote page
        public static Element CAStepper_5Quote_Before => new Element(By.XPath("//mat-step-header[@aria-selected='false']//p[@data-qa='5-index']"));
        public static Element CAStepper_6Purchase_Before => new Element(By.XPath("//mat-step-header[@aria-selected='false']//p[@data-qa='6-index']"));


        //PROFESSIONAL LIABILITY/ ERRORS & OMISSIONS specific
        public static Element YourPLQuoteID => new Element(By.XPath("//span[@data-qa='LOB-Quote-ID']"));
        public static Element YourEOQuoteID => new Element(By.XPath(""));

        //WORKERS COMPENSATION
        public static Element YourWCQuoteID => new Element(By.XPath("//div[@data-qa='wc_your_quoteId_header']"));
        //Steppers (both PL and EO)
        public static Element PLStepper_1Intro => new Element(By.XPath(""));
        public static Element PLStepper_2Business => new Element(By.XPath(""));
        public static Element PLStepper_3Coverage => new Element(By.XPath(""));
        public static Element PLStepper_4Customize => new Element(By.XPath(""));
        public static Element PLStepper_5Contact => new Element(By.XPath(""));


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

        /*
         * SSR platform marker (check if page was rendered by browser or by the server)
         */
        public static Element BrowserRenderedMarker => new Element(By.XPath("//router-outlet[@data-platform='browser']"));

        /*
        * 4.9 out of 5 customer review rating and 150,000+ policies sold.
        */
        public static Element FullStar => new Element(By.XPath("//span[@data-qa='homepage-review-teaser-reviews-stars']//i[1]"));
        public static Element HalfStar => new Element(By.XPath("//span[@data-qa='homepage-review-teaser-reviews-stars']//i[5]"));
        public static Element Rating => new Element(By.XPath("//span[@data-qa='homepage-review-teaser-reviews-numbers']/span"));
        public static Element OutOf5 => new Element(By.XPath("//span[@data-qa='homepage-review-teaser-reviews-numbers']/text()[2]"));
        public static Element CustomerReviewRating => new Element(By.XPath("//span[@data-qa='homepage-review-teaser-reviews-numbers']"));
        public static Element CustomerReviewRatingLink => new Element(By.XPath("//a[@data-qa='review-teaser-link']"));
        public static Element And200kPoliciesSold => new Element(By.XPath("//span[@data-qa='homepage-review-teaser-reviews-numbers']/text()[3]"));

        /*
        * Get the Insurance Your Business Needs
        */
        public static Element InsYourBusNeeds => new Element(By.XPath(""));
        public static Element InsYourBusNeedsParagraph => new Element(By.XPath(""));
        public static Element SaveTime => new Element(By.XPath("//h3[@data-qa='three-column-about-card1-title']"));
        public static Element SaveTimeImage => new Element(By.XPath("//h3[@data-qa='three-column-about-card1-title']/..//preceding-sibling::div//img"));
        public static Element SaveTimeParagraph => new Element(By.XPath("//h3[@data-qa='three-column-about-card1-title']//following-sibling::p"));
        public static Element SaveMoney => new Element(By.XPath("//h3[@data-qa='three-column-about-card2-title']"));
        public static Element SaveMoneyImage => new Element(By.XPath("//h3[@data-qa='three-column-about-card2-title']/..//preceding-sibling::div//img"));
        public static Element SaveMoneyParagraph => new Element(By.XPath("//h3[@data-qa='three-column-about-card2-title']//following-sibling::p"));
        public static Element Experienced => new Element(By.XPath("//h3[@data-qa='three-column-about-card3-title']"));
        public static Element ExperiencedImage => new Element(By.XPath("//h3[@data-qa='three-column-about-card3-title']/..//preceding-sibling::div//img"));
        public static Element ExperiencedParagraph => new Element(By.XPath("//h3[@data-qa='three-column-about-card3-title']//following-sibling::p"));

        /*
        * Dark Blue Banner containing: Picture, "Help Paying Work-Related Injury Bills" / "Save up to 20% on Small Business Insurance"
        */
        //Image of Professional
        public static Element SaveUpTo20PerImage => new Element(By.XPath(""));

        //Save up to 20% on Small Business Insurance
        public static Element SaveUpTo20Per => new Element(By.XPath(""));

        //We offer top-rated insurance products at prices up to 20% less than the competition.  
        //We also offer fast-and-easy claims and unrivaled customer service.  
        //You can call and speak with a small business insurance expert, or you can do everything-including purchasing a plan and submitting claims-entirely online.
        //Our processes are all designed with efficiency in mind so you can spend less time dealing with insurance and more time focused on your business.
        public static Element SaveUpTo20PerParagraph => new Element(By.XPath(""));

        //Help Paying Work-Related Injury Bills
        public static Element WorkRelatedBills => new Element(By.XPath(""));

        //Workers' compensation insurance helps pay bills associated with a work-related injury, including medical care and lost wages.
        //It's useful in many industries, including apartment and property management, auto services and dealers, cleaning, janitorial, condominimums, hotels, construction, contracting, health care, lawn care, landscapeing, professional services, restaurants, bars, retail stores, transportation, and more.
        public static Element WorkRelatedBillsParagraph => new Element(By.XPath(""));

        //Left Dot
        public static Element LeftDotCTA => new Element(By.XPath(""));

        //Right Dot
        public static Element RightDotCTA => new Element(By.XPath(""));

        //Left Arrow
        public static Element LeftArrowCTA => new Element(By.XPath(""));

        //Right Arrow
        public static Element RightArrowCTA => new Element(By.XPath(""));


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

        //Left Column, with: biBERK, INSURANCE COVERAGE, Workers' Compensation, Professional Liability (E&O), etc.
        public static Element Footer_biBERK => new Element(By.XPath("//a[@data-qa='footer-biberk-logo']"));
        public static Element Footer_InsuranceCoverage => new Element(By.XPath("//a[@data-qa='footer-link-coverage']"));
        public static Element Footer_WorkersComp => new Element(By.XPath("//a[@data-qa='footer-link-wc']"));
        public static Element Footer_ProfessionalLiab => new Element(By.XPath("//a[@data-qa='footer-link-pl']"));
        public static Element Footer_ErrorsAndOmissions => new Element(By.XPath("//a[@data-qa='footer-link-e-and-o']"));
        public static Element Footer_GeneralLiab => new Element(By.XPath("//a[@data-qa='footer-link-gl']"));
        public static Element Footer_PropertyLiab => new Element(By.XPath("//a[@data-qa='footer-link-bop']"));
        public static Element Footer_CommercialAuto => new Element(By.XPath("//a[@data-qa='footer-link-ca']"));
        public static Element Footer_Umbrella => new Element(By.XPath("//a[@data-qa='footer-link-um']"));
        public static Element Footer_Cyber => new Element(By.XPath("//a[@data-qa='footer-link-cyber']"));

        //2nd Column, with: POLICYHOLDERS, Get a Certificate, Make a Claim, etc.
        public static Element Footer_POLICYHOLDERS => new Element(By.XPath("//a[@data-qa='footer-link-policyholders']"));
        public static Element Footer_GetACertificate => new Element(By.XPath("//a[@data-qa='footer-link-policyholders-get-coi']"));
        public static Element Footer_MakeAClaim => new Element(By.XPath("//a[@data-qa='footer-link-policyholders-claims']"));
        public static Element Footer_MakeAPayment => new Element(By.XPath("//a[@data-qa='footer-link-policyholders-payment']"));
        public static Element Footer_SmallBusiness => new Element(By.XPath("//a[@data-qa='footer-link-small-business-insurance']"));

        //3rd Column, with: ABOUT, Careers, RESOURCES, etc.
        public static Element Footer_About => new Element(By.XPath("//a[@data-qa='footer-link-about']"));
        public static Element Footer_Careers => new Element(By.XPath("//a[@data-qa='footer-link-careers']"));
        public static Element Footer_Partners => new Element(By.XPath("//a[@data-qa='footer-link-partners']"));
        public static Element Footer_RESOURCES => new Element(By.XPath("//a[@data-qa='footer-link-resources']"));
        public static Element Footer_Articles => new Element(By.XPath("//a[@data-qa='footer-link-articles']"));
        public static Element Footer_FAQs => new Element(By.XPath("//a[@data-qa='footer-link-faqs']"));
        public static Element Footer_BalanceSheets => new Element(By.XPath("//a[@data-qa='footer-link-balance-sheets']"));
        public static Element Footer_LossControl => new Element(By.XPath("//a[@data-qa='footer-link-loss-control']"));

        //4th Column, with: CONTACT, ###-###-####, Get A Quote, etc.
        public static Element Footer_Contact => new Element(By.XPath("//a[@data-qa='footer-link-contact']"));
        //1-844-472-0967
        public static Element Footer_PhoneNumber => new Element(By.XPath("//a[@data-qa='footerTelephone']"));
        public static Element Footer_GetAQuote => new Element(By.XPath("//a[@data-qa='footer-link-get-a-quote']"));
        public static Element Footer_ReviewsLink => new Element(By.XPath("//a[@data-qa='footer-link-reviews']"));
        public static Element Footer_ReviewStars => new Element(By.XPath("//span[@data-qa='footer-reviews-stars']"));
        //Copyright
        public static Element Footer_Copyright => new Element(By.XPath("//div[@class='copyright is-flex is-flex-grow-1 is-align-items-center']"));
        public static Element Footer_Facebook => new Element(By.XPath("//a[@data-qa='footer-link-facebook']"));
        public static Element Footer_LinkedIn => new Element(By.XPath("//a[@data-qa='footer-link-linkedin']"));
        public static Element Footer_Rating => new Element(By.XPath("//span[@data-qa='footer-reviews-numbers']"));
        //Better Business Bureau
        public static Element Footer_LinkBBB => new Element(By.XPath("//a[@data-qa='footer-link-bbb']"));
        public static Element Footer_RatingBBB => new Element(By.XPath("//div[@class='rating']"));

        //Bottom of the Header
        public static Element Footer_BiBERKPoliciesIssued => new Element(By.XPath("//p[@data-qa='footer-policies-issued']"));
        public static Element Footer_BiBERKCopyRight => new Element(By.XPath("//span[@data-qa='footer-copyright']"));
        public static Element Footer_PrivacyPolicy => new Element(By.XPath("//a[@data-qa='footer-link-privacy']"));
        public static Element Footer_TermsConditions => new Element(By.XPath("//a[@data-qa='footer-link-terms']"));
        public static Element Footer_OtherDisclosures => new Element(By.XPath("//a[@data-qa='footer-link-disclosures']"));
        public static Element SiteMap => new Element(By.XPath("//a[@data-qa='footer-link-sitemap']"));
    }
}