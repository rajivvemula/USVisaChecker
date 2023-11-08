using DocumentFormat.OpenXml.Wordprocessing;
using HitachiQA.Driver;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.Other.Articles
{
    [Binding]
    class GuideToWCPage
    {
        //Header
        public static Element GuideToWCHeader => new Element(By.XPath("//h1[@data-qa='a-guide-to-workers-compensation-insurance']"));
        //Date
        public static Element GuideToWCDate => new Element(By.XPath("//span[@data-qa='blogpost-meta-date']"));
        //Category
        public static Element GuideToWCCategory => new Element(By.XPath("//span[@data-qa='blogpost-meta-category']"));
        public static Element WCInsuranceProvides => new Element(By.XPath("//p[@data-qa='article-main-header-and-text-text-0']"));
        public static Element WhyWasWCCreated => new Element(By.XPath("//p[@data-qa='article-main-header-and-text-text-1']"));
        public static Element ShakingHands_Image => new Element(By.XPath("(//img[@data-qa='article-main-image'])[1]"));
        public static Element BizTypeRequiredToHaveWC => new Element(By.XPath("(//h2[@data-qa='article-secondary-header-and-text-header'])[1]"));
        public static Element WCInsuranceForSmallBiz => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-0'])[1]"));
        public static Element WCVaryByState => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-1'])[1]"));
        public static Element FewExceptionsToRule => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-2'])[1]"));
        public static Element BeAwareThatSome => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-3'])[1]"));
        public static Element OriginsOfWC => new Element(By.XPath("(//h2[@data-qa='article-secondary-header-and-text-header'])[2]"));
        public static Element WCCompensationSystem => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-0'])[2]"));
        public static Element LongCourtBattle => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-1'])[2]"));
        public static Element WCAndIndustrialRevolution => new Element(By.XPath("(//h2[@data-qa='article-secondary-header-and-text-header'])[3]"));
        public static Element AsTheIndustrialRevolution => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-0'])[3]"));
        public static Element RecognitionByEmployers => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-1'])[3]"));
        public static Element WCAndSUpportingLaws => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-2'])[2]"));
        public static Element WhatWCCover => new Element(By.XPath("(//h2[@data-qa='article-section-with-ordered-list-header'])[1]"));
        public static Element WCIsImportant => new Element(By.XPath("(//p[@data-qa='article-section-with-ordered-list-lead-text-0'])[1]"));
        public static Element FinancialProtection_Image => new Element(By.XPath("(//img[@data-qa='article-main-image'])[2]"));
        public static Element MedicalCoverage => new Element(By.XPath("(//li[@data-qa='article-section-with-checked-list-li-one'])[1]"));
        public static Element DisabilityBenefits => new Element(By.XPath("(//li[@data-qa='article-section-with-checked-list-li-two'])[1]"));
        public static Element VocationalRehabilitation => new Element(By.XPath("(//li[@data-qa='article-section-with-checked-list-li-three'])[1]"));
        public static Element DeathBenefits => new Element(By.XPath("(//li[@data-qa='article-section-with-checked-list-li-four'])[1]"));
        public static Element GoalOfTheseBenefits => new Element(By.XPath("(//p[@data-qa='article-with-checked-list-bottom-text-0'])[1]"));
        public static Element ImportantToNote => new Element(By.XPath("(//p[@data-qa='article-with-checked-list-bottom-text-1'])[1]"));
        public static Element WhatIsWC_Video => new Element(By.XPath("(//p[@data-qa='article-with-checked-list-bottom-text-2'])[1]"));
        public static Element WhatsInvolvedWhenPurchasing => new Element(By.XPath("(//h2[@data-qa='article-secondary-header-and-text-header'])[4]"));
        public static Element BuyingWCEasy => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-0'])[4]"));
        public static Element CostIsCalculated => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-1'])[4]"));
        public static Element OnceYouHearWCQuote => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-2'])[3]"));
        public static Element BizOwnersShouldBeAware => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-3'])[2]"));
        public static Element WhatIsWCExemption => new Element(By.XPath("(//h2[@data-qa='article-section-with-bulleted-list-header'])[1]"));
        public static Element ParticularlyForSmallBiz => new Element(By.XPath("(//p[@data-qa='article-section-with-bulleted-list-lead-text-0'])[1]"));
        public static Element IfThatsTheCase => new Element(By.XPath("(//p[@data-qa='article-section-with-bulleted-list-lead-text-1'])[1]"));
        public static Element WCExemptionMayBeGranted => new Element(By.XPath("(//p[@data-qa='article-section-with-bulleted-list-lead-text-2'])[1]"));
        public static Element SelfEmployed => new Element(By.XPath("(//li[@data-qa='article-section-with-bulleted-list-li-one'])[1]"));
        public static Element IndependentContractors => new Element(By.XPath("(//li[@data-qa='article-section-with-bulleted-list-li-two'])[1]"));
        public static Element BizOwnersAndOfficers => new Element(By.XPath("(//li[@data-qa='article-section-with-bulleted-list-li-three'])[1]"));
        public static Element DomesticWorkers => new Element(By.XPath("(//li[@data-qa='article-section-with-bulleted-list-li-four'])[1]"));
        public static Element FarmWorkers => new Element(By.XPath("(//li[@data-qa='article-section-with-bulleted-list-li-five'])[1]"));
        public static Element GovWorkers => new Element(By.XPath("(//li[@data-qa='article-section-with-bulleted-list-li-six'])[1]"));
        public static Element RailroadEmployees => new Element(By.XPath("//ul[@data-qa='article-section-with-bulleted-list-ul']/li[7]"));
        public static Element LongShoremenAndMaritimeWorkers => new Element(By.XPath("(//li[@data-qa='article-section-with-bulleted-list-li-seven'])[1]"));
        public static Element Volunteers => new Element(By.XPath("(//li[@data-qa='article-section-with-bulleted-list-li-eight'])[1]"));
        public static Element EachStateHasOwnWCRequirements => new Element(By.XPath("(//p[@data-qa='article-section-with-bulleted-list-bottom-text-0'])[1]"));
        public static Element BeAwareOfRisksofNotCovering => new Element(By.XPath("(//p[@data-qa='article-section-with-bulleted-list-bottom-text-1'])[1]"));
        public static Element WCIsCrucial => new Element(By.XPath("(//p[@data-qa='article-section-with-bulleted-list-bottom-text-2'])[1]"));
        public static Element ManReviewingPapers_image => new Element(By.XPath("(//img[@data-qa='article-main-image'])[3]"));
        public static Element WhatIsWCAudit => new Element(By.XPath("(//h2[@data-qa='article-secondary-header-and-text-header'])[5]"));
        public static Element AuditorReviewsRecords => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-0'])[5]"));
        public static Element WCAuditDoesNotChange => new Element(By.XPath("(//p[@data-qa='article-secondary-header-and-text-section-text-1'])[5]"));
        public static Element HowDoesWCAuditWork => new Element(By.XPath("//h2[@data-qa='article-section-with-checked-list-header']"));
        public static Element WCAuditIsStrightforward => new Element(By.XPath("//p[@data-qa='article-section-with-checked-list-lead-text-0']"));
        public static Element DetailedBizDescription => new Element(By.XPath("(//li[@data-qa='article-section-with-checked-list-li-one'])[1]"));
        public static Element EmployeesRecords => new Element(By.XPath("(//li[@data-qa='article-section-with-checked-list-li-two'])[1]"));
        public static Element PayrollRecords => new Element(By.XPath("(//li[@data-qa='article-section-with-checked-list-li-three'])[1]"));
        public static Element CertificatesOfInsurance => new Element(By.XPath("(//li[@data-qa='article-section-with-checked-list-li-four'])[1]"));
        public static Element HowDoesWCClaimWork => new Element(By.XPath("(//h2[@data-qa='article-section-with-ordered-list-header'])[2]"));
        public static Element ClaimProcessVaries => new Element(By.XPath("(//p[@data-qa='article-section-with-ordered-list-lead-text-0'])[2]"));
        public static Element ClaimProcess_Image => new Element(By.XPath("//p[@data-qa='article-section-with-ordered-list-lead-text-1']"));
        public static Element IncidentOccurs => new Element(By.XPath("(//li[@data-qa='article-section-with-ordered-list-li-one'])"));
        public static Element IncidentReported => new Element(By.XPath("(//li[@data-qa='article-section-with-ordered-list-li-two'])"));
        public static Element ClaimFiled => new Element(By.XPath("(//li[@data-qa='article-section-with-ordered-list-li-three'])"));
        public static Element PaymentApproved => new Element(By.XPath("(//li[@data-qa='article-section-with-ordered-list-li-four'])"));
        public static Element OSHANotified => new Element(By.XPath("(//li[@data-qa='article-section-with-ordered-list-li-five'])"));
        public static Element HowMuchWCCoversWageReplacemt => new Element(By.XPath("(//h2[@data-qa='article-section-with-bulleted-list-header'])[2]"));
        public static Element AmountThatWCPays => new Element(By.XPath("(//p[@data-qa='article-section-with-bulleted-list-lead-text-0'])[2]"));
        public static Element EmployeePayRate => new Element(By.XPath("(//li[@data-qa='article-section-with-bulleted-list-li-one'])[2]"));
        public static Element InjuryOrIllness => new Element(By.XPath("(//li[@data-qa='article-section-with-bulleted-list-li-two'])[2]"));
        public static Element TempOrPermInjury => new Element(By.XPath("(//li[@data-qa='article-section-with-bulleted-list-li-three'])[2]"));
        public static Element CaseOfDisability => new Element(By.XPath("(//li[@data-qa='article-section-with-bulleted-list-li-four'])[2]"));
        public static Element WCLawsInState => new Element(By.XPath("(//li[@data-qa='article-section-with-bulleted-list-li-five'])[2]"));
        public static Element HourlyWageIndemnifications => new Element(By.XPath("(//p[@data-qa='article-section-with-bulleted-list-bottom-text-0'])[2]"));
        public static Element FAQsAboutWC => new Element(By.XPath("//h2[@data-qa='article-faqs-header']"));
        public static Element EmployeeGotHurt => new Element(By.XPath("//h3[@data-qa='article-faqs-question-one-header']"));
        public static Element EmployeeGotHurtText => new Element(By.XPath("//p[@data-qa='article-faqs-question-one-text']"));
        public static Element ManAtDesk_Image => new Element(By.XPath("(//img[@data-qa='article-main-image'])[4]"));
        public static Element HowLongCanEmployeesBePaid => new Element(By.XPath("//h3[@data-qa='article-faqs-question-two-header']"));
        public static Element HowLongCanEmployeesBePaidText => new Element(By.XPath("//p[@data-qa='article-faqs-question-two-text']"));
        public static Element WhatIsWorkerClassification => new Element(By.XPath("//h3[@data-qa='article-faqs-question-three-header']"));
        public static Element WhatIsWorkerClassificationText => new Element(By.XPath("//p[@data-qa='article-faqs-question-three-text']"));
        public static Element MisclassifyWorkers => new Element(By.XPath("//h3[@data-qa='article-faqs-question-four-header']"));
        public static Element MisclassifyWorkersText => new Element(By.XPath("//p[@data-qa='article-faqs-question-four-text']"));
        public static Element DoesSelfEmployedNeedWC => new Element(By.XPath("//h3[@data-qa='article-faqs-question-five-header']"));
        public static Element DoesSelfEmployedNeedWCText => new Element(By.XPath("//p[@data-qa='article-faqs-question-five-text']"));
        public static Element DoesWCCoverLawsuits => new Element(By.XPath("//h3[@data-qa='article-faqs-question-six-header']"));
        public static Element DoesWCCoverLawsuitsText => new Element(By.XPath("//p[@data-qa='article-faqs-question-six-text']"));
        public static Element DoesWCCoverWorkRelatedInjuries => new Element(By.XPath("//h3[@data-qa='article-faqs-question-seven-header']"));
        public static Element DoesWCCoverWorkRelatedInjuriesText => new Element(By.XPath("//p[@data-qa='article-faqs-question-seven-text']"));
        public static Element RelatedArticles => new Element(By.XPath("//h1[@data-qa='related-articles-heading']"));
        public static Element DoesYourBizNeedWC => new Element(By.XPath("(//a[@data-qa='related-article-heading-link'])[1]"));
        public static Element DoesYourBizNeedWCText => new Element(By.XPath("(//span[@data-qa='related-article-excerpt'])[1]"));
        public static Element DoesYourBizNeedWC_image => new Element(By.XPath("(//img[@data-qa='related-article-teaser-image'])[1]"));
        public static Element WCPayrollAudit => new Element(By.XPath("(//a[@data-qa='related-article-heading-link'])[2]"));
        public static Element WCPayrollAuditText => new Element(By.XPath("(//span[@data-qa='related-article-excerpt'])[2]"));
        public static Element WCPayrollAudit_image => new Element(By.XPath("(//img[@data-qa='related-article-teaser-image'])[2]"));
        public static Element WhatisWC => new Element(By.XPath("(//a[@data-qa='related-article-heading-link'])[3]"));
        public static Element WhatisWCText => new Element(By.XPath("(//span[@data-qa='related-article-excerpt'])[3]"));
        public static Element WhatisWC_image => new Element(By.XPath("(//img[@data-qa='related-article-teaser-image'])[3]"));
    }
}