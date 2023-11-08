using BiBerkLOB.StepDefinition.General.Other.Coverages;
using HitachiQA.Driver;
using OpenQA.Selenium;
using System.Collections.Generic;
using BiBerkLOB.Pages.Other;
using BiBerkLOB.Source.Driver.SimpleInteractions;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.BOP
{
    [StaticPageName("BOP Coverage")]
    public sealed class BOPPage : IStaticPage
    {
        /*
        * Photo Banner - Business Owners Policy
        */
        public static Element BusinessOwnersPol => new Element(By.XPath("//a[@data-qa='page-banner']//h1"));
        public static Element BusinessOwnersPolSubtitle => new Element(By.XPath("//a[@data-qa='page-banner']//div[@name='subTitleName']"));
        public static Element BusinessOwnersPolGetAQuoteCTA => new Element(By.XPath("//a[@data-qa='page-banner']//button"));

        /*
         * White Banner - Protect Your Company with a Business Owners Policy
         */
        //4.9 out of 5 customer review rating and 150,000+ policies sold.
        //This mapping can be found on the Reusable_PurchasePath.cs file
        public static Element ProtectYourCompany => new Element(By.XPath("//h2[@data-qa='info-image-left-header']"));
        public static Element ProtectYourCompanyParagraph => new Element(By.XPath("//p[@data-qa='info-image-left-text-0']"));
        public static Element ProtectYourCompanyImage => new Element(By.XPath("//img[@data-qa='info-image-left-image']"));

        /*
         * Grey Banner - What is Property and Liability Insurance?
         */
        public static Element WhatPropAndLiabIns => new Element(By.XPath("//h2[@data-qa='what-is-header']"));
        public static Element WhatPropAndLiabInsParagraph => new Element(By.XPath("//p[@data-qa='pl-what-is-text']"));

        //Your Coverage is Broader
        private static Element YourCoverageIsBroader => new Element(By.XPath("//h4[@data-qa='card-1-title']"));
        private static Element YourCoverageIsBroaderImage => new Element(By.XPath("//img[@data-qa='what-is-card-1']"));
        //More potential insurance claims are protected by a single BOP policy.
        private static Element YourCoverageIsBroaderTextBehind => new Element(By.XPath("//p[@data-qa='broader-coverage-text']"));

        //Managing Your Policy is a Breeze
        private static Element ManagingPolicyBreeze => new Element(By.XPath("//h4[@data-qa='card-2-title']"));
        private static Element ManagingPolicyBreezeImage => new Element(By.XPath("//img[@data-qa='what-is-card-2']"));
        //Submitting claims is simpler because more concerns fall under this one policy.
        private static Element ManagingPolicyBreezeTextBehind => new Element(By.XPath("//p[@data-qa='card-text_2']"));

        //You Could Save Money
        private static Element CouldSaveMoney => new Element(By.XPath("//h4[@data-qa='card-3-title']"));
        private static Element CouldSaveMoneyImage => new Element(By.XPath("//img[@data-qa='what-is-card-3']"));
        //Property and liability insurance purchased together usually cost less than the total cost of individual policies.
        private static Element CouldSaveMoneyTextBehind => new Element(By.XPath("//p[@data-qa='card-text_3']"));

        /*
         * White Banner - What Coverages are Included in a BOP?
         */
        public static Element WhatDoesLiabAndPropCover => new Element(By.XPath("//h2[contains(text(),'What Coverages are Included in a BOP?')]"));

        //General Liability Insurance Typically Covers:
        public static Element GLInsCovers => new Element(By.XPath("//h6[@data-qa='general-liability-covers-header']"));

        //Property Damage
        public static Element GLInsCovers_PropDamage => new Element(By.XPath("(//li[@data-qa='property-damage-title']/span/p)[1]"));
        public static Element GLInsCovers_PropDamageParagraph => new Element(By.XPath("(//li[@data-qa='property-damage-title']/span/p)[2]"));

        //Bodily Injury
        public static Element GLInsCovers_BodilyInj => new Element(By.XPath("(//li[@data-qa='bodily-injury-title']/span/p)[1]"));
        public static Element GLInsCovers_BodilyInjParagraph => new Element(By.XPath("(//li[@data-qa='bodily-injury-title']/span/p)[2]"));

        //Product Liability
        public static Element GLInsCovers_ProdLiab => new Element(By.XPath("(//li[@data-qa='product-liability-title']/span/p)[1]"));
        public static Element GLInsCovers_ProdLiabParagraph => new Element(By.XPath("(//li[@data-qa='product-liability-title']/span/p)[2]"));

        //Libel, Slander, and Copyright Infringement
        public static Element GLInsCovers_Libel => new Element(By.XPath("(//li[@data-qa='libel-slander-title']/span/p)[1]"));
        public static Element GLInsCovers_LibelParagraph => new Element(By.XPath("(//li[@data-qa='libel-slander-title']/span/p)[2]"));

        //Property Insurance Typically Covers:
        public static Element PropInsCovers => new Element(By.XPath("//h6[@data-qa='property-insurance-header']"));

        //Your Building or Leased Space.
        public static Element PropInsCovers_Building => new Element(By.XPath("(//li[@data-qa='building-leased-space-title']/span/p)[1]"));
        public static Element PropInsCovers_BuildingParagraph => new Element(By.XPath("(//li[@data-qa='building-leased-space-title']/span/p)[2]"));

        //The Contents of Your Building.
        public static Element PropInsCovers_Contents => new Element(By.XPath("(//li[@data-qa='building-contents-title']/span/p)[1]"));
        public static Element PropInsCovers_ContentsParagraph => new Element(By.XPath("(//li[@data-qa='building-contents-title']/span/p)[2]"));

        //Income From Your Business.
        public static Element PropInsCovers_Income => new Element(By.XPath("(//li[@data-qa='income-from-business-title']/span/p)[1]"));
        public static Element PropInsCovers_IncomeParagraph => new Element(By.XPath("(//li[@data-qa='income-from-business-title']/span/p)[2]"));

        /*
         * Grey Banner - Can I Customize My Business Owners Policy?
         */
        public static Element CustomizeBOP => new Element(By.XPath("//h2[contains(text(),'Can I Customize My Business Owners Policy?')]"));
        public static Element CustomizeBOPParagraph => new Element(By.XPath("//h2[contains(text(),'Can I Customize My Business Owners Policy?')]//../p[contains(text(),'Yes. Your')]"));
        //liability and property insurance
        public static Element CustomizeBOPLink => new Element(By.XPath("//h2[contains(text(),'Can I Customize My Business Owners Policy?')]//..//a"));

        //Industry Endorsements
        public static Element CustomizeBOP_IndustryEndorse => new Element(By.XPath("//h2[contains(text(),'Can I Customize My Business Owners Policy?')]/ancestor::section//h6[contains(text(),'Industry Endorsements')]"));
        public static Element CustomizeBOP_IndustryEndorseParagraph => new Element(By.XPath("//p[@data-qa='content-text_1']//parent::div/p[contains(text(),'Depending')]"));

        //Risk-Specific Endorsements
        public static Element CustomizeBOP_RiskSpecific => new Element(By.XPath("//h2[contains(text(),'Can I Customize My Business Owners Policy?')]/ancestor::section//h6[contains(text(),'Risk-Specific')]"));
        public static Element CustomizeBOP_RiskSpecificParagraph => new Element(By.XPath("//p[@data-qa='content-text_5']//parent::div/p[contains(text(),'Some')]"));

        //Increased Coverage Limits
        public static Element CustommizeBOP_IncreasedCov => new Element(By.XPath("//h2[contains(text(),'Can I Customize My Business Owners Policy?')]/ancestor::section//h6[contains(text(),'Increased Coverage')]"));
        public static Element CustommizeBOP_IncreasedCovParagraph => new Element(By.XPath("//p[@data-qa='content-text_6']//parent::div/p[contains(text(),'business owners')]"));

        /*
         * White Banner - Why biBERK for Property and Liability Insurance?
         */
        public static Element whyBiberkBOP => new Element(By.XPath("//h2[@data-qa='why-biberk-header']"));
        public static Element whyBiberkBOPParagraph => new Element(By.XPath("//p[@data-qa='subheader-text-label_2']"));

        //Save Time, Save Money, Experienced Sections can be found mapped in the Reusable_PurchasePath.cs file

        /*
         * Grey Banner - Common Business Owners Policy Endorsements
         */
        public static Element BOPEnd => new Element(By.XPath("//h2[contains(text(),'Common Business Owners Policy Endorsements')]"));
        public static Element BOPEndParagraph => new Element(By.XPath("//h2[contains(text(),'Common Business Owners Policy Endorsements')]//../p[contains(text(),'Some')]"));

        //Cyber
        public static Element BOPEnd_Cyber => new Element(By.XPath("//h6[@data-qa='more-info-header_1' and text()='Cyber']"));
        public static Element BOPEnd_CyberParagraph => new Element(By.XPath("//h6[@data-qa='more-info-header_1' and text()='Cyber']//parent::div/p[contains(text(),'Cyber')]"));
        //Hired and Non-Owned Auto Liability
        public static Element BOPEnd_Auto => new Element(By.XPath("//h6[@data-qa='more-info-header_2' and text()='Hired and Non-Owned Auto Liability']"));
        public static Element BOPEnd_AutoParagraph => new Element(By.XPath("//h6[@data-qa='more-info-header_2' and text()='Hired and Non-Owned Auto Liability']//parent::div/p[contains(text(),'Hired')]"));
        //Employment-Related Practices Liability
        public static Element BOPEnd_Employment => new Element(By.XPath("//h6[@data-qa='more-info-header_3' and text()='Employment-Related Practices Liability']"));
        public static Element BOPEnd_EmploymentParagraph => new Element(By.XPath("//h6[@data-qa='more-info-header_3' and text()='Employment-Related Practices Liability']//parent::div/p[contains(text(),'This add-on')]"));
        //Employee Benefits Liability
        public static Element BOPEnd_Benefits => new Element(By.XPath("//h6[@data-qa='more-info-header_4' and text()='Employee Benefits Liability']"));
        public static Element BOPEnd_BenefitsParagraph => new Element(By.XPath("//h6[@data-qa='more-info-header_4' and text()='Employee Benefits Liability']//parent::div/p[contains(text(),'Employee benefits')]"));
        //Contractors Installation, Tools & Equipment
        public static Element BOPEnd_Contractors => new Element(By.XPath("//h6[@data-qa='more-info-header_5' and text()='Contractors Installation, Tools & Equipment']"));
        public static Element BOPEnd_ContractorsParagraph => new Element(By.XPath("//h6[@data-qa='more-info-header_5' and text()='Contractors Installation, Tools & Equipment']//parent::div/p[contains(text(),'This add-on')]"));
        //Liquor Liability
        public static Element BOPEnd_Liquor => new Element(By.XPath("//h6[@data-qa='more-info-header_6' and text()='Liquor Liability']"));
        public static Element BOPEnd_LiquorParagraph => new Element(By.XPath("//h6[@data-qa='more-info-header_6' and text()='Liquor Liability']//parent:: div/p[contains(text(),'Liquor liability')]"));
        //Equipment Breakdown/Boiler & Machinery
        public static Element BOPEnd_EquipBreak => new Element(By.XPath("//h6[@data-qa='more-info-header_7' and text()='Equipment Breakdown/Boiler & Machinery']"));
        public static Element BOPEnd_EquipBreakParagraph => new Element(By.XPath("//h6[@data-qa='more-info-header_7' and text()='Equipment Breakdown/Boiler & Machinery']//parent::div/p[contains(text(),'This add-on')]"));

        /*
         * Blue Banner - Is Property and Liability Right for My Small Business? / Be Confident in Your Business Owners Policy Coverage
         */
        
        public static Element Dot_Active => new Element(By.XPath("//li[@class='indicator-item active']"));
        public static Element Dot_Inactive => new Element(By.XPath("//li[@class='indicator-item']"));
        public static Element CoverageCTA => new Element(By.XPath("//a[@data-qa='info-image-carousel-image-right-button']"));

        /*
         * White Banner - How Much Does a Business Owners Policy Cost?
         */
        public static Element HowMuchBOP => new Element(By.XPath("//h2[@data-qa='info-image-left-main-header']"));
        //Our BOP polices start at about $500 per year, and most people pay less than $2,000
        public static Element HowMuchBOPubheader => new Element(By.XPath("//h3[@data-qa='info-image-left-header-above-image']"));
        public static Element HowMuchBOPImage => new Element(By.XPath("//img[@data-qa='info-image-left-image']"));
        public static Element CalculateBOPPrem => new Element(By.XPath("//h3[@data-qa='info-image-left-header']"));
        //All of these factors are considered when calculating your business owners policy premium:
        public static Element CalculateBOPPremParagraph => new Element(By.XPath("//p[@data-qa='info-image-left-text-0']"));
        [IndexRange(0, 7)] public static Element CalculateBOPPremBulletListItem(int index) => new Element(By.XPath($"//ul/li[@data-qa='info-image-left-list-{index}']"));
        public static Element CalculateBOPPrem_GetAQuoteCTA => new Element(By.XPath("//a[@data-qa='info-image-left-button-below-text']"));

        /*
         * Grey Banner - How can I Reduce My Liability and Property Insurance Costs?
         */
        public static Element ReduceBopCost => new Element(By.XPath("//h2[contains(text(),'How can I Reduce')]"));
        public static Element ReduceBopCostParagraph => new Element(By.XPath("//h2[@data-qa='more-info-main-header']//parent::div/p[contains(text(),'Liability')]"));

        //Choose biBERK
        public static Element ReduceBopCost_ChooseBiberk => new Element(By.XPath("//h6[@data-qa='more-info-header_1' and text()='Choose biBERK']"));
        public static Element ReduceBopCost_ChooseBiberkParagraph => new Element(By.XPath("//h6[@data-qa='more-info-header_1' and text()='Choose biBERK']//../p[contains(text(), 'By working')]"));
        //Actively Manage Risks
        public static Element ReduceBopCost_ManageRisk => new Element(By.XPath("//h6[@data-qa='more-info-header_2' and text()='Actively Manage Risks']"));
        public static Element ReduceBopCost_ManageRiskParagraph => new Element(By.XPath("//h6[@data-qa='more-info-header_2' and text()='Actively Manage Risks']//../p[contains(text(), 'Prevent slips')]"));
        //Save on Billing Fees
        public static Element ReduceBopCost_SaveFees => new Element(By.XPath("//h6[@data-qa='more-info-header_2' and text()='Actively Manage Risks']//../p[contains(text(), 'Prevent slips')]"));
        public static Element ReduceBopCost_SaveFeesParagraph => new Element(By.XPath("//h6[@data-qa='more-info-header_5' and text()='Save on Billing Fees']/..//p[contains(text(),'Pay you')]"));
        //Protect Your Property
        public static Element ReduceBopCost_ProtectProp => new Element(By.XPath("//h6[@data-qa='more-info-header_6' and text()='Protect Your Property']"));
        public static Element ReduceBopCost_ProtectPropParagraph => new Element(By.XPath("//h6[@data-qa='more-info-header_6' and text()='Protect Your Property']/..//p[contains(text(),'If you')]"));
        
        /*
         * Get a Business Owners Policy Quote Today
         */
        public static Element GetBOPToday => new Element(By.XPath("//h2[@data-qa='get-a-quote-label']"));
        public static Element GetBOPTodaySubTitle => new Element(By.XPath("//p[@data-qa='trust-biberk-quote']"));
        public static Element GetBOPToday_GetAQuoteCTA => new Element(By.XPath("//a[@data-qa='get-a-quote-button_2']"));

        /*
         * Reusable Marketing
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
         * Flip Cards
         */
        public static IStaticInteraction YourCoverageIsBroaderFlipCard => new FlipCard(YourCoverageIsBroader, YourCoverageIsBroaderImage, YourCoverageIsBroaderTextBehind);
        public static IStaticInteraction ManagingPolicyBreezeFlipCard => new FlipCard(ManagingPolicyBreeze, ManagingPolicyBreezeImage, ManagingPolicyBreezeTextBehind);
        public static IStaticInteraction CouldSaveMoneyFlipCard => new FlipCard(CouldSaveMoney, CouldSaveMoneyImage, CouldSaveMoneyTextBehind);

        /*
         * Carousel
         */
        private static Element Arrow_Right => new Element(By.XPath("//i[@data-qa='info-image-carousel-image-right-chevron-next']"));
        private static Element Arrow_Left => new Element(By.XPath("//i[@data-qa='info-image-carousel-image-right-chevron-previous']"));
        private static Element CarouselImage => new Element(By.XPath("//img[@data-qa='info-image-carousel-image-right']"));
        
        //Is Property and Liability Right for My Small Business?
        private static Element PropAndLiabRight => new Element(By.XPath("//h2[@data-qa='info-image-carousel-image-right-slide1-header']"));
        private static Element PropAndLiabRightParagraph => new Element(By.XPath("//p[@data-qa='info-image-carousel-image-right-slide1-text']"));
        
        //Be Confident in Your Business Owners Policy Coverage
        private static Element BeConfident => new Element(By.XPath("//h2[@data-qa='info-image-carousel-image-right-slide2-header']"));
        private static Element BeConfidentParagraph => new Element(By.XPath("//p[@data-qa='carousel-text_2']"));
        
        private static Dictionary<Element, Element> CarouselTextItems => new Dictionary<Element, Element>
        {
            { PropAndLiabRight, PropAndLiabRightParagraph },
            { BeConfident, BeConfidentParagraph }
        };
        public static IStaticInteraction BOPCarousel => new Carousel(CarouselTextItems, Arrow_Left, Arrow_Right, CarouselImage);

        /*
         * White Banner - Business Owners Policy Frequently Asked Questions (FAQs)
         */
        public static Element BOPFAQsHeader => new Element(By.XPath("//h2[@data-qa='faq-header']"));
        public static Element BOPFAQsParagraph => new Element(By.XPath("//p[@data-qa='faq-subheader']"));

        //What is liability insurance?
        private static Element WhatIsLiabIns => new Element(By.XPath("//h3[@data-qa='faq-question-1-question']"));
        private static Element WhatIsLiabInsParagraph => new Element(By.XPath("//p[@data-qa='faq-question-1-answer']"));
        private static Element WhatIsLiabInsArrow => new Element(By.XPath("//i[@data-qa='faq-question-1-arrow']"));

        //How do I know how much property coverage to purchase?
        private static Element HowMuchPropCovPurchase => new Element(By.XPath("//h3[@data-qa='faq-question-2-question']"));
        private static Element HowMuchPropCovPurchaseParagraph => new Element(By.XPath("//p[@data-qa='faq-question-2-answer']"));
        private static Element HowMuchPropCovPurchaseArrow => new Element(By.XPath("//i[@data-qa='faq-question-2-arrow']"));

        //What's covered by a business owners policy?
        private static Element WhatsCoveredBOP => new Element(By.XPath("//h3[@data-qa='faq-question-3-question']"));
        private static Element WhatsCoveredBOPParagraph => new Element(By.XPath("//p[@data-qa='faq-question-3-answer']"));
        private static Element WhatsCoveredBOPArrow => new Element(By.XPath("//i[@data-qa='faq-question-3-arrow']"));

        //What does liability insurance cost?
        private static Element LiabInsCost => new Element(By.XPath("//h3[@data-qa='faq-question-4-question']"));
        private static Element LiabInsCostParagraph => new Element(By.XPath("//p[@data-qa='faq-question-4-answer']"));
        private static Element LiabInsCostArrow => new Element(By.XPath("//i[@data-qa='faq-question-4-arrow']"));

        //How much liability insurance do I need?
        private static Element HowMuchLiab => new Element(By.XPath("//h3[@data-qa='faq-question-5-question']"));
        private static Element HowMuchLiabParagraph => new Element(By.XPath("//p[@data-qa='faq-question-5-answer']"));
        private static Element HowMuchLiabArrow => new Element(By.XPath("//i[@data-qa='faq-question-5-arrow']"));

        //What is the minimum amount of liability insurance required?
        private static Element MinLiabReq => new Element(By.XPath("//h3[@data-qa='faq-question-6-question']"));
        private static Element MinLiabReqParagraph => new Element(By.XPath("//p[@data-qa='faq-question-6-answer']"));
        private static Element MinLiabReqArrow => new Element(By.XPath("//i[@data-qa='faq-question-6-arrow']"));

        //What types of businesses need BOP coverage?
        private static Element TypesBusNeedBOP => new Element(By.XPath("//h3[@data-qa='faq-question-7-question']"));
        private static Element TypesBusNeedBOPParagraph => new Element(By.XPath("//p[@data-qa='faq-question-7-answer']"));
        private static Element TypesBusNeedBOPArrow => new Element(By.XPath("//i[@data-qa='faq-question-7-arrow']"));

        //How are a BOP policy and general liability insurance different?
        private static Element BOPvGL => new Element(By.XPath("//h3[@data-qa='faq-question-8-question']"));
        private static Element BOPvGLParagraph => new Element(By.XPath("//p[@data-qa='faq-question-8-answer']"));
        private static Element BOPvGLArrow => new Element(By.XPath("//i[@data-qa='faq-question-8-arrow']"));

        //Does biBERK offer business owners policies in my state?
        private static Element BOPInMyState => new Element(By.XPath("//h3[@data-qa='faq-question-9-question']"));
        private static Element BOPInMyStateParagraph => new Element(By.XPath("//p[@data-qa='faq-question-9-answer']"));
        private static Element BOPInMyStateArrow => new Element(By.XPath("//i[@data-qa='faq-question-9-arrow']"));
        //coverage map link
        private static Element BOPInMyStateLink => new Element(By.XPath("//p[@data-qa='faq-question-9-answer']//parent::div//a"));

        //Can I buy and manage my BOP policy from biBERK online?
        private static Element BuyBOPOnline => new Element(By.XPath("//h3[@data-qa='faq-question-10-question']"));
        private static Element BuyBOPOnlineParagraph => new Element(By.XPath("//p[@data-qa='faq-question-10-answer']"));
        private static Element BuyBOPOnlineArrow => new Element(By.XPath("//i[@data-qa='faq-question-10-arrow']"));

        public static IStaticInteraction WhatIsLiabInsFAQ => new CoveragePageFAQ(WhatIsLiabIns, WhatIsLiabInsParagraph, WhatIsLiabInsArrow);
        public static IStaticInteraction HowMuchPropCovPurchaseFAQ => new CoveragePageFAQ(HowMuchPropCovPurchase, HowMuchPropCovPurchaseParagraph, HowMuchPropCovPurchaseArrow);
        public static IStaticInteraction WhatsCoveredBOPFAQ => new CoveragePageFAQ(WhatsCoveredBOP, WhatsCoveredBOPParagraph, WhatsCoveredBOPArrow);
        public static IStaticInteraction LiabInsCostFAQ => new CoveragePageFAQ(LiabInsCost, LiabInsCostParagraph, LiabInsCostArrow);
        public static IStaticInteraction HowMuchLiabFAQ => new CoveragePageFAQ(HowMuchLiab, HowMuchLiabParagraph, HowMuchLiabArrow);
        public static IStaticInteraction MinLiabReqFAQ => new CoveragePageFAQ(MinLiabReq, MinLiabReqParagraph, MinLiabReqArrow);
        public static IStaticInteraction TypesBusNeedBOPFAQ => new CoveragePageFAQ(TypesBusNeedBOP, TypesBusNeedBOPParagraph, TypesBusNeedBOPArrow);
        public static IStaticInteraction BOPvGLFAQ => new CoveragePageFAQ(BOPvGL, BOPvGLParagraph, BOPvGLArrow);
        public static IStaticInteraction BOPInMyStateFAQ => new CoveragePageFAQ(BOPInMyState, BOPInMyStateParagraph, BOPInMyStateArrow, BOPInMyStateLink);
        public static IStaticInteraction BuyBOPOnlineFAQ => new CoveragePageFAQ(BuyBOPOnline, BuyBOPOnlineParagraph, BuyBOPOnlineArrow);
        
    }
}