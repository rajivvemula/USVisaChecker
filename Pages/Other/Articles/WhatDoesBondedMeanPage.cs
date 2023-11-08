using HitachiQA.Driver;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.Other.Articles
{
    [Binding]
    public sealed class WhatDoesBondedMeanPage
    {
        //Header
        public static Element WhatDoesBondedMean => new Element(By.XPath("//h1[@data-qa='what-does-bonded-and-insured-mean']"));
        //Date
        public static Element WhatDoesBondedMeanDate => new Element(By.XPath("//span[@data-qa='blogpost-meta-date']"));
        //Category
        public static Element WhatDoesBondedMeanCategory => new Element(By.XPath("//span[@data-qa='blogpost-meta-category']"));
        public static Element BusinessesWillSometimesIndicate => new Element(By.XPath("//p[@data-qa='article-main-header-and-text-text-0']"));
        public static Element AnswerToTheseQuestions => new Element(By.XPath("//p[@data-qa='article-main-header-and-text-text-1']"));
        public static Element CleaningWindows_Image => new Element(By.XPath("(//img[@data-qa='article-main-image'])[1]"));
        public static Element DifferenceBetweenBonding => new Element(By.XPath("//h2[@data-qa='article-section-with-bulleted-list-header']"));
        public static Element SmallBizInsuranceProvided => new Element(By.XPath("(//p[@data-qa='article-section-with-bulleted-list-lead-text-0'])[1]"));
        public static Element SpecificallyWeOffer => new Element(By.XPath("(//p[@data-qa='article-section-with-bulleted-list-lead-text-1'])[1]"));
        public static Element WCInsurance => new Element(By.XPath("(//li[@data-qa='article-section-with-bulleted-list-li-one'])[1]"));
        public static Element PLInsurance => new Element(By.XPath("(//li[@data-qa='article-section-with-bulleted-list-li-two'])[1]"));
        public static Element GLInsurance => new Element(By.XPath("(//li[@data-qa='article-section-with-bulleted-list-li-three'])[1]"));
        public static Element BOPInsurance => new Element(By.XPath("(//li[@data-qa='article-section-with-bulleted-list-li-four'])[1]"));
        public static Element CommAutoInsurance => new Element(By.XPath("(//li[@data-qa='article-section-with-bulleted-list-li-five'])[1]"));
        public static Element UmbrellaInsurance => new Element(By.XPath("(//li[@data-qa='article-section-with-bulleted-list-li-six'])[1]"));
        public static Element CyberInsurance => new Element(By.XPath("//ul[@data-qa='article-section-with-bulleted-list-ul']/li[7]"));
        public static Element ThesePoliciesProvide => new Element(By.XPath("//p[@data-qa='article-section-with-checked-list-lead-text-0']"));
        public static Element Principal => new Element(By.XPath("//li[@data-qa='article-section-with-checked-list-li-one']"));
        public static Element Obligee => new Element(By.XPath("//li[@data-qa='article-section-with-checked-list-li-two']"));
        public static Element Surety => new Element(By.XPath("//li[@data-qa='article-section-with-checked-list-li-three']"));
        public static Element TheseBondsProvide => new Element(By.XPath("//p[@data-qa='article-with-checked-list-bottom-text-0']"));
        public static Element ThreeCommonBondTypes => new Element(By.XPath("(//p[@data-qa='article-section-with-bulleted-list-lead-text-0'])[2]"));
        public static Element ContractorConstructionBonds => new Element(By.XPath("(//li[@data-qa='article-section-with-bulleted-list-li-one'])[2]"));
        public static Element FidelityBonds => new Element(By.XPath("(//li[@data-qa='article-section-with-bulleted-list-li-two'])[2]"));
        public static Element JanitorialBonds => new Element(By.XPath("(//li[@data-qa='article-section-with-bulleted-list-li-three'])[2]"));
        public static Element BondsCanBeRequired => new Element(By.XPath("//p[@data-qa='article-section-with-bulleted-list-bottom-text-0']"));
        public static Element HowToGetBonded => new Element(By.XPath("(//h2[@data-qa='article-secondary-header-and-text-header'])[1]"));
        public static Element CompaniesWondering => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-0'])[1]"));
        public static Element AsNotedOnWebsite => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-1'])[1]"));
        public static Element AsForInsurance => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-2'])[1]"));
        public static Element WhyBeingBondedMatters => new Element(By.XPath("(//h2[@data-qa='article-secondary-header-and-text-header'])[2]"));
        public static Element OnceYourInsuredAndBonded => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-0'])[2]"));
        public static Element CompaniesThatChoose => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-1'])[2]"));
        public static Element LicensedBondedAndInsured => new Element(By.XPath("(//h2[@data-qa='article-secondary-header-and-text-header'])[3]"));
        public static Element InSomeScenarios => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-0'])[3]"));
        public static Element BeingLicensedMeans => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-1'])[3]"));
        public static Element RequirementsForBeingLicensed => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-2'])[2]"));
        public static Element BondedAndInsuredReassurance => new Element(By.XPath("(//h2[@data-qa='article-secondary-header-and-text-header'])[4]"));
        public static Element BondedAndInsuredReassuranceText => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-0'])[4]"));
        public static Element LearnMore => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-1'])[4]"));
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