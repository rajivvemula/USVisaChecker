using HitachiQA.Driver;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.Other.Articles
{
    [Binding]
    class SmallBusinessInsuranceSurveyPage
    {
        //Header
        public static Element SmallBizInsuranceReveals => new Element(By.XPath("//h1[@data-qa='business-owner-survey-results']"));
        //Date
        public static Element SmallBizInsuranceRevealsDate => new Element(By.XPath("//span[@data-qa='blogpost-meta-date']"));
        // Article Category
        public static Element SmallBizInsuranceRevealsCategory => new Element(By.XPath("//[@data-qa='blogpost-meta-category']"));
        public static Element AsImportantSmallBizInsurance => new Element(By.XPath("//p[@data-qa='article-main-header-and-text-text-0']"));
        public static Element ConductedRecentSurvey => new Element(By.XPath("//p[@data-qa='article-main-header-and-text-text-1']"));
        public static Element WomanHoldingPaper_image => new Element(By.XPath("//img[@data-qa='article-main-image']"));
        public static Element InterestingDataContradictions => new Element(By.XPath("(//h2[@data-qa='article-secondary-header-and-text-header'])[1]"));
        public static Element OneNotableObservation => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-0'])[1]]"));
        public static Element SurveyConfirmedBeliefs => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-1'])[1]"));
        public static Element Nearly90Percent => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-2'])[1]"));
        public static Element SomeNumbersAreConcering => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-3'])[1]"));
        public static Element SurveyResults => new Element(By.XPath("//h2[@data-qa='article-section-with-multiple-sections-header']"));
        public static Element SurveyResultsText => new Element(By.XPath("//p[@data-qa='article-section-with-multiple-sections-lead-text-0']"));
        public static Element PurchasingBizInsuranceOnline => new Element(By.XPath("//h3[@data-qa='article-section-with-multiple-sections-section-one-header']"));
        public static Element PurchasingBizInsuranceOnlineAnswer => new Element(By.XPath("//p[@data-qa='article-section-with-multiple-sections-section-one-text']"));
        public static Element PersonalInsuranceNotCoveringBiz => new Element(By.XPath("//h3[@data-qa='article-section-with-multiple-sections-section-two-header']"));
        public static Element PersonalInsuranceNotCoveringBizAnswer => new Element(By.XPath("//p[@data-qa='article-section-with-multiple-sections-section-two-text']"));
        public static Element ReviewPersonalInsurance => new Element(By.XPath("//h3[@data-qa='article-section-with-multiple-sections-section-three-header']"));
        public static Element ReviewPersonalInsuranceAnswer => new Element(By.XPath("//p[@data-qa='article-section-with-multiple-sections-section-three-text']"));
        public static Element IfYouDontReviewWhy => new Element(By.XPath("//h3[@data-qa='article-section-with-multiple-sections-section-four-header']"));
        public static Element IfYouDontReviewWhyAnswer => new Element(By.XPath("//p[@data-qa='article-section-with-multiple-sections-section-four-text']"));
        public static Element IncreaseLimits => new Element(By.XPath("//h3[@data-qa='article-section-with-multiple-sections-section-five-header']"));
        public static Element IncreaseLimitsAnswer => new Element(By.XPath("//p[@data-qa='article-section-with-multiple-sections-section-five-text']"));
        public static Element IfYouHaveIncreaseLimits => new Element(By.XPath("//h3[@data-qa='article-section-with-multiple-sections-section-six-header']"));
        public static Element IfYouHaveIncreaseLimitsAnswer => new Element(By.XPath("//p[@data-qa='article-section-with-multiple-sections-section-six-text']"));
        public static Element SufferedALoss => new Element(By.XPath("//h3[@data-qa='article-section-with-multiple-sections-section-seven-header']"));
        public static Element SufferedALossAnswer => new Element(By.XPath("//p[@data-qa='article-section-with-multiple-sections-section-seven-text']"));
        public static Element BizChangedSignificantly => new Element(By.XPath("//h3[@data-qa='article-section-with-multiple-sections-section-eight-header']"));
        public static Element BizChangedSignificantlyAnswer => new Element(By.XPath("//p[@data-qa='article-section-with-multiple-sections-section-eight-text']"));
        public static Element BizPoliciesCanBeTailored => new Element(By.XPath("//h3[@data-qa='article-section-with-multiple-sections-section-nine-header']"));
        public static Element BizPoliciesCanBeTailoredAnswer => new Element(By.XPath("//p[@data-qa='article-section-with-multiple-sections-section-nine-text']"));
        public static Element DoYouHaveAdequateInsurance => new Element(By.XPath("//h3[@data-qa='article-section-with-multiple-sections-section-ten-header']"));
        public static Element DoYouHaveAdequateInsuranceAnswer => new Element(By.XPath("//p[@data-qa='article-section-with-multiple-sections-section-ten-text']"));
        public static Element ImportantTakeaways => new Element(By.XPath("//p[@data-qa='article-section-with-multiple-sections-bottom-text-0']"));
        public static Element HilightedTheImportance => new Element(By.XPath("//p[@data-qa='article-section-with-multiple-sections-bottom-text-2']"));
        public static Element RelatedArticles => new Element(By.XPath("//h1[@data-qa='related-articles-heading']"));
        public static Element WhatDoINeedForMyCompany => new Element(By.XPath("(//a[@data-qa='related-article-heading-link'])[1]"));
        public static Element WhatDoINeedForMyCompanyText => new Element(By.XPath("(//span[@data-qa='related-article-excerpt'])[1]"));
        public static Element WhatDoINeedForMyCompany_image => new Element(By.XPath("(//img[@data-qa='related-article-teaser-image'])[1]"));
        public static Element DoesLLCProtectMe => new Element(By.XPath("(//a[@data-qa='related-article-heading-link'])[2]"));
        public static Element DoesLLCProtectMeText => new Element(By.XPath("(//span[@data-qa='related-article-excerpt'])[2]"));
        public static Element DoesLLCProtectMe_image => new Element(By.XPath("(//img[@data-qa='related-article-teaser-image'])[2]"));
        public static Element DoINeedSmallBizLiability => new Element(By.XPath("(//a[@data-qa='related-article-heading-link'])[3]"));
        public static Element DoINeedSmallBizLiabilityText => new Element(By.XPath("(//span[@data-qa='related-article-excerpt'])[3]"));
        public static Element DoINeedSmallBizLiability_image => new Element(By.XPath("(//img[@data-qa='related-article-teaser-image'])[3]"));
    }
}