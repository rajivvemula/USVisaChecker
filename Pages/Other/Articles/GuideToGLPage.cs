using DocumentFormat.OpenXml.Wordprocessing;
using HitachiQA.Driver;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages
{
    [Binding]
    class GuideToGLPage
    {
        //Header
        public static Element GuideToGLHeader => new Element(By.XPath("//h1[@data-qa='guide-to-general-liability-insurance']"));
        //Date
        public static Element GuideToGLDate => new Element(By.XPath("//span[@data-qa='blogpost-meta-date']"));
        // Article Category
        public static Element GuideToGLCategory => new Element(By.XPath("//[@data-qa='blogpost-meta-category']"));
        public static Element ProtectingBusiness => new Element(By.XPath("//p[@data-qa='article-main-header-and-text-text-0']"));
        public static Element CommercialGL => new Element(By.XPath("//p[@data-qa='article-main-header-and-text-text-1']"));
        public static Element FoodTruck_Image => new Element(By.XPath("//img[@data-qa='article-main-image']"));
        public static Element WhyOfferGL => new Element(By.XPath("(//h2[@data-qa='article-secondary-header-and-text-header'])[1]"));
        public static Element ToolForProtection => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-0'])[1]]"));
        public static Element FastForwardToday => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-2'])[1]"));
        public static Element RecognizingThis => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-3'])[1]"));
        public static Element IsRequiredByLaw => new Element(By.XPath("(//h2[@data-qa='article-secondary-header-and-text-header'])[2]"));
        public static Element ShieldingYourBusiness => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-0'])[2]"));
        public static Element SomeClientsMay => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-1'])[2]"));
        public static Element WhatIsCovered => new Element(By.XPath("(//h2[@data-qa='article-section-with-checked-list-header'])[1]"));
        public static Element GLProvides => new Element(By.XPath("(//p[@data-qa='article-section-with-checked-list-lead-text-0'])[1]"));
        public static Element GLProvides_IMG => new Element(By.XPath("(//p[@data-qa='article-section-with-checked-list-lead-text-1'])[1]"));
        public static Element CustomerPropertyDamage => new Element(By.XPath("(//li[@data-qa='article-section-with-checked-list-li-one'])[1]"));
        public static Element NonEmployee => new Element(By.XPath("(//li[@data-qa='article-section-with-checked-list-li-two'])[1]"));
        public static Element ProductLiability => new Element(By.XPath("(//li[@data-qa='article-section-with-checked-list-li-three'])[1]"));
        public static Element PersonalAdvertisingInj => new Element(By.XPath("(//li[@data-qa='article-section-with-checked-list-li-four'])[1]"));
        public static Element GLPolicyEndorsments => new Element(By.XPath("//h2[@data-qa='article-section-with-bulleted-list-header']"));
        public static Element CustomizeGL => new Element(By.XPath("//p[@data-qa='article-section-with-bulleted-list-lead-text-0']"));
        public static Element LiquorLiability => new Element(By.XPath("//li[@data-qa='article-section-with-bulleted-list-li-one']"));
        public static Element CyberLiability => new Element(By.XPath("//li[@data-qa='article-section-with-bulleted-list-li-two']"));
        public static Element ContractorAndToolsCoverage => new Element(By.XPath("//li[@data-qa='article-section-with-bulleted-list-li-three']"));
        public static Element EmployeeBenefitsLiability => new Element(By.XPath("//li[@data-qa='article-section-with-bulleted-list-li-four']"));
        public static Element EmploymentRelatedPracticesLiability => new Element(By.XPath("//li[@data-qa='article-section-with-bulleted-list-li-five']"));
        public static Element HiredandNonOwnedAuto => new Element(By.XPath("//li[@data-qa='article-section-with-bulleted-list-li-six']"));
        public static Element LicensedInsuranceExperts => new Element(By.XPath("//p[@data-qa='article-section-with-bulleted-list-bottom-text-0']"));
        public static Element LookingIPad_image => new Element(By.XPath("(//img[@data-qa='article-main-image'])[2]"));
        public static Element WhoNeedsGL => new Element(By.XPath("(//h2[@data-qa='article-section-with-checked-list-header'])[2]"));
        public static Element VirtuallyAnyCompany => new Element(By.XPath("(//p[@data-qa='article-section-with-checked-list-lead-text-0'])[2]"));
        public static Element WorkInPerson => new Element(By.XPath("(//li[@data-qa='article-section-with-checked-list-li-one'])[2]"));
        public static Element HasPhysicalSpace => new Element(By.XPath("(//li[@data-qa='article-section-with-checked-list-li-two'])[2]"));
        public static Element GLIsRequired => new Element(By.XPath("(//li[@data-qa='article-section-with-checked-list-li-three'])[2]"));
        public static Element ThirdPartyLocation => new Element(By.XPath("(//li[@data-qa='article-section-with-checked-list-li-four'])[2]"));
        public static Element RepresentsClients => new Element(By.XPath("//li[@data-qa='article-section-with-checked-list-li-five']"));
        public static Element UsesContractors => new Element(By.XPath("//li[@data-qa='article-section-with-checked-list-li-six']"));
        public static Element SellsPhysicalProducts => new Element(By.XPath("//li[@data-qa='article-section-with-checked-list-li-seven']"));
        public static Element RelatedQuestion => new Element(By.XPath("//p[@data-qa='article-with-checked-list-bottom-text-0']"));
        public static Element CantPurchaseGLAfter => new Element(By.XPath("//p[@data-qa='article-with-checked-list-bottom-text-1']"));
        public static Element CommonForBizOwners => new Element(By.XPath("//p[@data-qa='article-with-checked-list-bottom-text-2']"));
        public static Element GLCost => new Element(By.XPath("(//h2[@data-qa='article-secondary-header-and-text-header'])[3]"));
        public static Element GLIsAffordable => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-0'])[3]"));
        public static Element GLPayisBased => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-1'])[3]"));
        public static Element ForAFewHundred => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-2'])[3]"));
        public static Element InvolvedInPurchasingGL => new Element(By.XPath("(//h2[@data-qa='article-secondary-header-and-text-header'])[4]"));
        public static Element OneOfTheGreatThings => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-0'])[4]"));
        public static Element AsNotedAbove => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-1'])[4]"));
        public static Element ShoppingForGL => new Element(By.XPath("//h2[@data-qa='article-section-with-example-header']"));
        public static Element BizInsuranceIsnt => new Element(By.XPath("//p[@data-qa='article-section-with-example-section-text-0']"));
        public static Element BeAwareThat => new Element(By.XPath("//p[@data-qa='article-section-with-example-section-text-1']"));
        public static Element HereIsAScenario => new Element(By.XPath("//h3[@data-qa='article-section-with-example-section-box-header']"));
        public static Element ImagineBuyingInsurance => new Element(By.XPath("//p[@data-qa='article-section-with-example-section-box-text']"));
        public static Element ThisScenario => new Element(By.XPath("//p[@data-qa='article-section-with-example-section-bottom-text-0']"));
        public static Element AsABerkshire => new Element(By.XPath("//p[@data-qa='article-section-with-example-section-bottom-text-1']"));
        public static Element WhatsMore => new Element(By.XPath("//p[@data-qa='article-section-with-example-section-bottom-text-2']"));
        public static Element HowToProveGL => new Element(By.XPath("(//h2[@data-qa='article-secondary-header-and-text-header'])[5]"));
        public static Element CommonForClients => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-0'])[5]"));
        public static Element BiberkCanProvide => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-1'])[5]"));
        public static Element BizAssociateMay => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-2'])[3]"));
        public static Element RockClimbing_Image => new Element(By.XPath("(//img[@data-qa='article-main-image'])[3]"));
        public static Element IsGLAllINeed => new Element(By.XPath("//h2[@data-qa='article-section-with-ordered-list-header']"));
        public static Element OneOfTheBestThings => new Element(By.XPath("//p[@data-qa='article-section-with-ordered-list-lead-text-0']"));
        public static Element InsteadPurchaseOnly => new Element(By.XPath("//p[@data-qa='article-section-with-ordered-list-lead-text-1']"));
        public static Element BiberkHasThesePolicys => new Element(By.XPath("//p[@data-qa='article-section-with-ordered-list-lead-text-2']"));
        public static Element GLInsurance => new Element(By.XPath("//li[@data-qa='article-section-with-ordered-list-li-one']"));
        public static Element WorkersCompInsurance => new Element(By.XPath("//li[@data-qa='article-section-with-ordered-list-li-two']"));
        public static Element BOPInsurance => new Element(By.XPath("//li[@data-qa='article-section-with-ordered-list-li-three']"));
        public static Element PLInsurance => new Element(By.XPath("//li[@data-qa='article-section-with-ordered-list-li-four']"));
        public static Element CommAutoInsurance => new Element(By.XPath("//li[@data-qa='article-section-with-ordered-list-li-five']"));
        public static Element CyberInsurance => new Element(By.XPath("//li[@data-qa='article-section-with-ordered-list-li-six']"));
        public static Element UmbrellaInsurance => new Element(By.XPath("//li[@data-qa='article-section-with-ordered-list-li-seven']"));
        public static Element GLForSmallBiz => new Element(By.XPath("(//h2[@data-qa='article-secondary-header-and-text-header'])[6]"));
        public static Element AsABizOwner_text => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-0'])[6]"));
        public static Element ShouldTheUnexpected => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-1'])[6]"));
        public static Element RelatedArticles => new Element(By.XPath("//h1[@data-qa='related-articles-heading']"));
        public static Element DoesLLCProtect => new Element(By.XPath("(//a[@data-qa='related-article-heading-link'])[1]"));
        public static Element ManySmallBiz => new Element(By.XPath("(//span[@data-qa='related-article-excerpt'])[1]"));
        public static Element DoesLLCProtect_Image => new Element(By.XPath("(//img[@data-qa='related-article-teaser-image'])[1]"));
        public static Element WhatIsGL => new Element(By.XPath("(//a[@data-qa='related-article-heading-link'])[2]"));
        public static Element ProtectsCompanyFromRisk => new Element(By.XPath("(//span[@data-qa='related-article-excerpt'])[2]"));
        public static Element WhatIsGL_Image => new Element(By.XPath("(//img[@data-qa='related-article-teaser-image'])[2]"));
        public static Element CommonGLClaims => new Element(By.XPath("(//a[@data-qa='related-article-heading-link'])[3]"));
        public static Element CommonGLClaimsText => new Element(By.XPath("(//span[@data-qa='related-article-excerpt'])[3]"));
        public static Element CommonGLClaims_Image => new Element(By.XPath("(//img[@data-qa='related-article-teaser-image'])[3]"));

    }
}