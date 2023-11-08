using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.PL
{
    [Binding]
    public sealed class PL_QuoteDetails_CoverageDetails : Reusable_PurchasePath
    {
        /*
         * Title, Text, Including Return to Quote Options Button
         */
        //Details of Your Standard Plan Quote
        public static Element DetailsStandardPlanTitle => new Element(By.XPath("//h1[@data-qa='details-header']"));
        //Details of Your Plus Plan Quote
        public static Element DetailsPlusPlanTitle => new Element(By.XPath("//h1[@data-qa='details-header']"));
        //One year coverage starting on ##/##/##.
        public static Element OneYearCoverage_Copy => new Element(By.XPath("//h3[@data-qa='details-coverage-starting-on']"));
        //You can download the Certificate of Insurance (COI) as soon as your payment is processed.
        public static Element DownloadCOI_Copy => new Element(By.XPath("//p[@data-qa='details-coi-helptext']"));

        //Return to Quote Options
        public static Element ReturnToQuoteOptionsCTA => new Element(By.XPath("//button[@data-qa='close-policy-button']"));


        /*
         * Coverages - Specific events trigger coverage by this policy.
         */
        public static Element CoveragesTitle => new Element(By.XPath("//h6[@data-qa='coverages-header']"));
        //Specific events trigger coverage by this policy.
        public static Element CoveragesCopy => new Element(By.XPath("//p[@data-qa='specific-events-subheader']"));

        //Professional Liability (E&O)--------------------------------------------------------------------------------------
        //Professional Liability (E&O)
        public static Element CovPLEOTitle => new Element(By.XPath("//h6[@data-qa='Professional Liability (E&O)-coverage-type-header']"));
        public static Element CovPLEOChkbox => new Element(By.XPath("//i[@data-qa='Professional Liability (E&O)-coverage-check-icon']"));
        //Professional Liability (E&O), also called Errors & Omissions Insurance, covers lawsuits or claims made by your client that your services caused them to suffer financial harm through:
        public static Element CovPLEO_PLCoversLawsuits_Copy => new Element(By.XPath("//div[@data-qa='Professional Liability (E&O)-coverage-info-text']"));
        //Mistakes or alleged mistakes on your part (errors)*
        public static Element CovPLEO_MistakesOrAlleged_Copy => new Element(By.XPath("//li[@data-qa='Professional Liability (E&O)-coverage-bullet-0']"));
        //Failure or alleged faliure to perform some service (omission)
        public static Element CovPLEO_FailureOrAlleged_Copy => new Element(By.XPath("//li[@data-qa='Professional Liability (E&O)-coverage-bullet-1']"));
        //Common claims for errors and omissions lawsuits include:
        public static Element CovPLEO_CommonClaims_Copy => new Element(By.XPath("//div[@data-qa='additional-coverage-info-text']"));
        //Negligence or misrepresentation
        public static Element CovPLEO_Negligence_Copy => new Element(By.XPath("//li[@data-qa='additional-info-coverage-bullet-0']"));
        //Violation of good faith and fair dealing
        public static Element CovPLEO_Violation_Copy => new Element(By.XPath("//li[@data-qa='additional-info-coverage-bullet-1']"));
        //Wrong advice
        public static Element CovPLEO_Wrong_Copy => new Element(By.XPath("//li[@data-qa='additional-info-coverage-bullet-2']"));
        //Privacy violations
        public static Element CovPLEO_Privacy_Copy => new Element(By.XPath("//li[@data-qa='additional-info-coverage-bullet-3']"));
        //Policy coverage includes acts occurring back to ##/##/####, known as the retroactive date.
        public static Element CovPLEO_PolicyCov_Copy => new Element(By.XPath("//p[@data-qa='additional-parent-retro-text']"));
        //* Professional Liability (E&O) Insurance covers the cost of defending a lawsuit even if the lawsuit is groundless
        public static Element CovPLEO_LawsuitGroundless_Copy => new Element(By.XPath("//span[@data-qa='coverage-info-condition-text']"));

        //Errors & Omissions
        public static Element CovEOTitle => new Element(By.XPath("//h6[@data-qa='Errors & Omissions-coverage-type-header']"));
        public static Element CovEOChkbox => new Element(By.XPath("//i[@data-qa='Errors & Omissions-coverage-check-icon']"));
        public static Element CovEOParagraph => new Element(By.XPath("//div[@data-qa='Errors & Omissions-coverage-info-text']"));
        public static Element CovEOCopy_Mistakes => new Element(By.XPath("//li[@data-qa='Errors & Omissions-coverage-bullet-0']"));
        public static Element CovEOCopy_Failure => new Element(By.XPath("//li[@data-qa='Errors & Omissions-coverage-bullet-1']"));
        public static Element CovEOCopy_Common => new Element(By.XPath("//div[@data-qa='additional-coverage-info-text']"));
        public static Element CovEOCopy_Negligence => new Element(By.XPath("//li[@data-qa='additional-info-coverage-bullet-0']"));
        public static Element CovEOCopy_Violation => new Element(By.XPath("//li[@data-qa='additional-info-coverage-bullet-1']"));
        public static Element CovEOCopy_Wrong => new Element(By.XPath("//li[@data-qa='additional-info-coverage-bullet-2']"));
        public static Element CovEOCopy_Privacy => new Element(By.XPath("//li[@data-qa='additional-info-coverage-bullet-3']"));
        public static Element CovEOCopy_Policy => new Element(By.XPath("//p[@data-qa='additional-parent-retro-text']"));
        public static Element CovEOCopy_Errors => new Element(By.XPath("//span[@data-qa='coverage-info-condition-text']"));


        //Copyright/Trademark Infringement----------------------------------------------------------------------------------
        public static Element CovCopyTitle => new Element(By.XPath("//h6[@data-qa='Copyright/Trademark Infringement-coverage-type-header']"));
        public static Element CovCopyChkbox => new Element(By.XPath("//i[@data-qa='Copyright/Trademark Infringement-coverage-check-icon']"));
        //Copyright/Trademark infringement insurance covers lawsuits or claims that your business has violated the copyright or trademark protection of an individual or entity, such as by:
        public static Element CovCopy_CoversLawsuits => new Element(By.XPath("//div[@data-qa='Copyright/Trademark Infringement-coverage-info-text']"));
        //Reproducing copyrighted 
        public static Element CovCopy_Reproducing => new Element(By.XPath("//li[@data-qa='Copyright/Trademark Infringement-coverage-bullet-0']"));
        //Using another company's trademark or something similar to it in a way that may confuse consumers
        public static Element CovCopy_UsingAnother => new Element(By.XPath("//li[@data-qa='Copyright/Trademark Infringement-coverage-bullet-1']"));
        //Policy coverage includes acts occurring back to ##/##/####, known as the retroactive date.
        public static Element CovCopy_IncludesActs => new Element(By.XPath("//p[@data-qa='Copyright/Trademark Infringement-parent-retro-text']"));
        //Copyright/Trademark Infringement PLUS----------------------------------------------------------------------------------
        public static Element CovCopyPLUSTitle => new Element(By.XPath("//h6[@data-qa='Copyright/Trademark Infringement Plus-coverage-type-header']"));
        public static Element CovCopyPLUSChkbox => new Element(By.XPath("//i[@data-qa='Copyright/Trademark Infringement Plus-coverage-check-icon']"));
        //Copyright/Trademark infringement insurance covers lawsuits or claims that your business has violated the copyright or trademark protection of an individual or entity, such as by:
        public static Element CovCopyPLUS_CoversLawsuits => new Element(By.XPath("//div[@data-qa='Copyright/Trademark Infringement Plus-coverage-info-text']"));
        //Reproducing copyrighted 
        public static Element CovCopyPLUS_Reproducing => new Element(By.XPath("//li[@data-qa='Copyright/Trademark Infringement Plus-coverage-bullet-0']"));
        //Using another company's trademark or something similar to it in a way that may confuse consumers
        public static Element CovCopyPLUS_UsingAnother => new Element(By.XPath("//li[@data-qa='Copyright/Trademark Infringement Plus-coverage-bullet-1']"));
        //Policy coverage includes acts occurring back to ##/##/####, known as the retroactive date.
        public static Element CovCopyPLUS_IncludesActs => new Element(By.XPath("//p[@data-qa='Copyright/Trademark Infringement Plus-parent-retro-text']"));

        //Pollution Liability-----------------------------------------------------------------------------------------------
        public static Element CovPollutionTitle => new Element(By.XPath("//h6[@data-qa='Pollution Liability-coverage-type-header']"));
        public static Element CovPollutionChkbox => new Element(By.XPath("//i[@data-qa='Pollution Liability-coverage-check-icon']"));
        //Coverage for lawsuits and defense costs involving pollution liability such as environmental toxins, lead, mold, or other pollutants.  This is also known as Constractor's Pollution Liability but does not include coverage for asbestos or nuclear materials.
        public static Element CovPollutionCopy => new Element(By.XPath("//div[@data-qa='Pollution Liability-coverage-info-text']"));

        //Cyber Liability---------------------------------------------------------------------------------------------------
        public static Element CovCyberTitle => new Element(By.XPath("//h6[@data-qa='Cyber Liability-coverage-type-header']"));
        public static Element CovCyberChkbox => new Element(By.XPath("//i[@data-qa='Cyber Liability-coverage-check-icon']"));
        //Cyber Liability, add-on insurance protects your business against the growing threat of cyber liability, such as:
        public static Element CovCyberCopy => new Element(By.XPath("//div[@data-qa='Cyber Liability-coverage-info-text']"));
        //A data breach regarding private customer, employee, or client information
        public static Element CovCyberCopy_DataBreach => new Element(By.XPath("//li[@data-qa='Cyber Liability-coverage-bullet-0']"));
        //Coverage for regulatory action defense if a governmental agency requires your appearance in court
        public static Element CovCyberCopy_RequireInCourt => new Element(By.XPath("//li[@data-qa='Cyber Liability-coverage-bullet-1']"));
        //Policy coverage includes acts occurring back to 05/01/2022, known as the retroactive date.
        public static Element CovCyberCopy_Retro => new Element(By.XPath("//p[@data-qa='Cyber Liability-parent-retro-text']"));

        //Real Estate-------------------------------------------------------------------------------------------------------
        public static Element CovRealEstateTitle => new Element(By.XPath("//h6[@data-qa='Real Estate Plus-coverage-type-header']"));
        public static Element CovRealEstateChkbox => new Element(By.XPath("//i[@data-qa='Real Estate Plus-coverage-check-icon']"));
        //Real Estate Plus insurance covers additional lawsuits or claims related to the operation of your real estate business through:
        public static Element CovRealEstateCopy => new Element(By.XPath("//div[@data-qa='Real Estate Plus-coverage-info-text']"));
        //Property damage or injury during an open house
        public static Element CovRealEstateCopy_DamageDuringOpenHouse => new Element(By.XPath("//li[@data-qa='Real Estate Plus-coverage-bullet-0']"));
        //Failure to disclose the presence of a pollutant on a property
        public static Element CovRealEstateCopy_DisclosePollutant => new Element(By.XPath("//li[@data-qa='Real Estate Plus-coverage-bullet-1']"));
        //Fair Housing Act violations
        public static Element CovRealEstateCopy_FairHousingAct => new Element(By.XPath("//li[@data-qa='Real Estate Plus-coverage-bullet-2']"));
        public static Element CovRealEstate_Retro => new Element(By.XPath("//p[@data-qa='Real Estate Plus-parent-retro-text']"));


        /*
         * Benefits - This policy provides specific benefits in the event of covered loss.
         */
        public static Element BenefitsTitle => new Element(By.XPath("//h6[@data-qa='benefits-header']"));
        //This policy provides specific benefits in the event of covered loss.
        public static Element BenefitsCopy => new Element(By.XPath("//p[@data-qa='benefits-help-text']"));

        //Professional Liability (E&O)---------------------------------------------------------------------------------------
        public static Element BenePLTitle => new Element(By.XPath("//h6[@data-qa='Professional Liability (E&O)-benefit-coverage-type']"));
        public static Element BenePLChkbox => new Element(By.XPath("//i[@data-qa='Professional Liability (E&O)-benefit-coverage-icon']"));
        //$1,000,000 of coverage for any errors or omissions lawsuit
        public static Element BenePLCopy_EOLawsuit => new Element(By.XPath("//li[@data-qa='Professional Liability (E&O)-benefit-bullet-0']"));
        //$10,000 of coverage for any discliplinary proceedings regarding a license or certification
        public static Element BenePLCopy_Discliplinary => new Element(By.XPath("//li[@data-qa='Professional Liability (E&O)-benefit-bullet-1']"));
        //$500/day up to $10,000 of coverage if you are sued or disciplined and must make an appearance
        public static Element BenePLCopy_SuedDisciplined => new Element(By.XPath("//li[@data-qa='Professional Liability (E&O)-benefit-bullet-2']"));

        //Errors and Omissions------------------------------------------------------------------------------------------------
        public static Element BeneEOTitle => new Element(By.XPath("//h6[@data-qa='Errors & Omissions-benefit-coverage-type']"));
        public static Element BeneEOChkbox => new Element(By.XPath("//i[@data-qa='Errors & Omissions-benefit-coverage-icon']"));
        //$1,000,000 of coverage for any errors or omissions lawsuit
        public static Element BeneEOCopy_Lawsuit => new Element(By.XPath("//li[@data-qa='Errors & Omissions-benefit-bullet-0']"));
        //$10,000 of coverage for any disciplinary proceedings regarding a license or certification
        public static Element BeneEOCopy_Disciplinary => new Element(By.XPath("//li[@data-qa='Errors & Omissions-benefit-bullet-1']"));
        //$500/day up to $10,000 of coverage if you are sued or disciplined and must make an appearance
        public static Element BeneEOCopy_Appearance => new Element(By.XPath("//li[@data-qa='Errors & Omissions-benefit-bullet-2']"));

        //Sexual Abuse and Molestation---------------------------------------------------------------------------------------
        public static Element BeneSAbuseTitle => new Element(By.XPath("//h6[@data-qa='Sexual Abuse and Molestation-benefit-coverage-type']"));
        public static Element BeneSAbuseChkbox => new Element(By.XPath("//i[@data-qa='Sexual Abuse and Molestation-benefit-coverage-icon']"));
        //$250,000.00 of coverage for alleged sexual abuse and molestation claims
        public static Element BeneSAbuseCopy => new Element(By.XPath("//li[@data-qa='Sexual Abuse and Molestation-benefit-bullet-0']"));

        //Copyright/Trademark Infringement-----------------------------------------------------------------------------------
        public static Element BeneCopyrightTitle => new Element(By.XPath("//h6[@data-qa='Copyright/Trademark Infringement-benefit-coverage-type']"));
        public static Element BeneCopyrightChkbox => new Element(By.XPath("//i[@data-qa='Copyright/Trademark Infringement-benefit-coverage-icon']"));
        //$250,000 of copyright/trademark infringement coverage
        public static Element BeneCopyrightCopy => new Element(By.XPath("//li[@data-qa='Copyright/Trademark Infringement-benefit-bullet-0']"));
        //Copyright/Trademark Infringement PLUS ------------------------------------------------------------------------------
        public static Element BeneCopyrightPLUSTitle => new Element(By.XPath("//h6[@data-qa='Copyright/Trademark Infringement Plus-benefit-coverage-type']"));
        public static Element BeneCopyrightPLUSChkbox => new Element(By.XPath("//i[@data-qa='Copyright/Trademark Infringement Plus-benefit-coverage-icon']"));
        //$250,000 of copyright/trademark infringement coverage
        public static Element BeneCopyrightPLUSCopy => new Element(By.XPath("//li[@data-qa='Copyright/Trademark Infringement Plus-benefit-bullet-0']"));

        //Pollution Liability------------------------------------------------------------------------------------------------
        public static Element BenePollutionTitle => new Element(By.XPath("//h6[@data-qa='Pollution Liability-benefit-coverage-type']"));
        public static Element BenePollutionChkbox => new Element(By.XPath("//i[@data-qa='Pollution Liability-benefit-coverage-icon']"));
        //$250,000.00 of coverage for pollution liability.
        public static Element BenePollutionCopy => new Element(By.XPath("//li[@data-qa='Pollution Liability-benefit-bullet-0']"));

        //Cyber Liability----------------------------------------------------------------------------------------------------
        public static Element BeneCyberTitle => new Element(By.XPath("//h6[@data-qa='Cyber Liability-benefit-coverage-type']"));
        public static Element BeneCyberChkbox => new Element(By.XPath("//i[@data-qa='Cyber Liability-benefit-coverage-icon']"));
        //$100,000.00 of coverage for a data breach involving private customer or client information
        public static Element BeneCyberCopy_DataBreach => new Element(By.XPath("//li[@data-qa='Cyber Liability-benefit-bullet-0']"));
        //Regulatory action defense if a government agency requires your appearance in court.
        public static Element BeneCyberCopy_RegulatoryAction => new Element(By.XPath("//li[@data-qa='Cyber Liability-benefit-bullet-1']"));

        //Real Estate--------------------------------------------------------------------------------------------------------
        public static Element BeneRealEstateTitle => new Element(By.XPath("//h6[@data-qa='Real Estate Plus-benefit-coverage-type']"));
        public static Element BeneRealEstateChxbox => new Element(By.XPath("//i[@data-qa='Real Estate Plus-benefit-coverage-icon']"));
        //$100,000.00 of coverage for property damage or injury at an open house showing
        public static Element BeneRealEstateCopy_PropDamage => new Element(By.XPath("//li[@data-qa='Real Estate Plus-benefit-bullet-0']"));
        //$100,000.00 of coverage for failure to disclose a pollutant
        public static Element BeneRealEstateCopy_DisclosePollutant => new Element(By.XPath("//li[@data-qa='Real Estate Plus-benefit-bullet-1']"));
        //$100,000.00 of coverage for a Fair Housing Act violation
        public static Element BeneRealEstateCopy_FairHousingAct => new Element(By.XPath("//li[@data-qa='Real Estate Plus-benefit-bullet-2']"));


        /*
         * Risks Not Covered by Professional Liability (E&O) Insurance
         * or
         * Risks Not Covered by Errors & Omissions Insurance
         * THEY HAVE THE SAME MAPPINGS (which is ok because only one will ever appear)
         */
        //Risks Not Covered by Professional Liability (E&O) Insurance
        public static Element RisksNotCoveredTitle => new Element(By.XPath("//h6[@data-qa='risks-not-covered-header']"));
        //Costs that result from the risks below are not covered by Professional Liability (E&O) insurance.
        public static Element RisksNotCoveredCopy => new Element(By.XPath("//p[@data-qa='costs-not-covered-text']"));
        //Employee injuries
        public static Element RisksNotCovered_EmpInjuries => new Element(By.XPath("//strong[@data-qa='employee-injuries-text']"));
        //Employee injuries - Medical expenses and a portion of lost wages can be covered by a workers' compensation policy.
        public static Element RisksNotCoveredCopy_EmpInjuries => new Element(By.XPath("//p[@data-qa='medical-expenses-text']"));
        //Business property damage
        public static Element RisksNotCovered_BusPropDmg => new Element(By.XPath("//strong[@data-qa='business-property-text']"));
        //Business property damage - A business owner's policy (BOP) can pay for business property that is destroyed, damaged, lost, or stolen.
        public static Element RisksNotCoveredCopy_BusPropDmg => new Element(By.XPath("//p[@data-qa='bop-info-text']"));
        //Business vehicles
        public static Element RisksNotCovered_BusVehicles => new Element(By.XPath("//strong[@data-qa='business-vehicles-text']"));
        //Business vehicles - Vehicles owned by the business should be covered by commercial auto insurance. Leased or personal vehicles used for business purposes should be covered by hired and non-owned auto insurance.
        public static Element RisksNotCoveredCopy_BusVehicles => new Element(By.XPath("//p[@data-qa='ca-info-text']"));
        //Customer property damage and injuries
        public static Element RisksNotCovered_CustPropDmg => new Element(By.XPath("//strong[@data-qa='customer-property-damage-injuries-text']"));
        //Customer property damage and injuries - General liability can cover costs if you damage a customer's property or a customer is injured on your premises.
        public static Element RisksNotCoveredCopy_CustPropDmg => new Element(By.XPath("//p[@data-qa='gl-info-text']"));
        //Illegal acts and defense costs for criminal prosecution
        public static Element RisksNotCovered_IllegalActs => new Element(By.XPath("//strong[@data-qa='illegal-acts-text']"));
        //Illegal acts and defense costs for criminal prosecution - Professional Liability (E&O) insurance addresses honest mistakes made in the course of operating your business. It does not cover intentionally breaking the law and the resulting legal expenses or other related damages.
        public static Element RisksNotCoveredCopy_IllegalActs => new Element(By.XPath("//p[@data-qa='illegal-acts-info-text']"));
        //Employee discrimination lawsuits
        public static Element RisksNotCovered_EmpDiscrimination => new Element(By.XPath("//strong[@data-qa='employee-discrimination-text']"));
        //Employee discrimination lawsuits - Legal expenses related to claims filed by employees for wrongful termination, discrimination, and harassment can be covered by employment practices liability insurance.
        public static Element RisksNotCoveredCopy_EmpDiscrimination => new Element(By.XPath("//p[@data-qa='liability-info-text']"));


        /*
         * Deductible
         */
        public static Element DeductibleTitle => new Element(By.XPath("//h6[@data-qa='deductible-header']"));
        //Your deductible per occurrence amount is what you are responsible for before your policy pays for each event that results in a covered loss.
        public static Element DeductibleCopy => new Element(By.XPath("//p[@data-qa='deductible-helptext']"));
        //Per Occurence
        public static Element DeductiblePerOccurence => new Element(By.XPath("//div[@data-qa='deductible-per-occurence-label']"));
        //$1,000   --- this field has an EXCESSIVE amount of spaces before and after... will need to be trimmed
        public static Element Deductible1k => new Element(By.XPath("//div[@data-qa='deductible-amount']"));


        /*
         * Limits
         */
        public static Element LimitsTitle => new Element(By.XPath("//h6[@data-qa='limits-header']"));
        //The per occurrence limit is the maximum amount paid out for a covered loss resulting from a single event. The limit includes claim expenses such as defense cost*.
        public static Element LimitsCopy_WhatIsPerOccur => new Element(By.XPath("//p[@data-qa='limits-helptext']"));
        //Per Occurrence
        public static Element LimitsCopy_PerOccur => new Element(By.XPath("//div[@data-qa='limits-per-occurence-label']"));
        //$1,000,000
        public static Element LimitsCopy_PerOccur1Mil => new Element(By.XPath("//div[@data-qa='limits-occurence-amount']"));
        //The aggregate limit is the maximum amount paid out for all covered losses during at the policy period. The limit includes claim expenses such as defense cost*.
        public static Element LimitsCopy_WhatIsAggLimit => new Element(By.XPath("//p[@data-qa='aggregate-text']"));
        //Aggregate
        public static Element LimitsCopy_Agg => new Element(By.XPath("//div[@data-qa='aggregate-label']"));
        //$1,000,000
        public static Element LimitsCopy_Agg1Mil => new Element(By.XPath("//div[@data-qa='aggregate-amount']"));
        //* Does not apply in Montana and New York
        public static Element LimitsCopy_NotMTNY => new Element(By.XPath("//p[@data-qa='not-apply-text']"));


        /*
         * Premium
         */
        public static Element PremiumTitle => new Element(By.XPath("//h6[@data-qa='premium-header']"));
        //The premium is the amount you pay monthly or yearly to purchase this policy.
        public static Element PremiumCopy_DefinePremium => new Element(By.XPath("//p[@data-qa='premium-helptext']"));
        //Monthly
        public static Element PremiumCopy_Monthly => new Element(By.XPath("//div[@data-qa='monthly-label']"));
        //$118.83 (12 Monthly Payments of $118.83)
        public static Element PremiumCopy_MonthlyCost => new Element(By.XPath("//div[@data-qa='monthly-amount-label']"));
        //Yearly
        public static Element PremiumCopy_Yearly => new Element(By.XPath("//div[@data-qa='yearly-label']"));
        public static Element PremiumCopy_YearlyCost => new Element(By.XPath("//div[@data-qa='yearly-amount-label']"));


        /*
         * Part of Berkshire Hathaway
         */
        public static Element PartBerkshireHathawayTitle => new Element(By.XPath("//h6[@data-qa='bh-header']"));
        //You can insure your business with confidence when you work with biBERK. We’re part of Berkshire Hathaway, a company led by Warren Buffett, and one of the world’s largest insurance groups, paying over $35 billion a year to resolve claims. 
        //From jargon-free policies providing affordable, comprehensive coverage for your operations, people, and property, to attentive customer service, it’s easy to understand why more businesses are turning to biBERK.
        public static Element PartBerkshireHathawayCopy => new Element(By.XPath("//p[@data-qa='bh-info-text']"));

        //Cancellation Policy
        public static Element CancellationTitle => new Element(By.XPath("//h6[@data-qa='cancellation-header']"));
        //To cancel your policy, please call one of our insurance consultants at 1-844-472-0967. Please note that policies cannot be cancelled by voicemail or email. Please be aware that state regulations or policy language may affect when we are able to offer cancellation.
        public static Element CancellationCopy => new Element(By.XPath("//p[@data-qa='cancellation-text']"));
        //1-844-472-0967
        public static Element CancellationPhoneNumber => new Element(By.XPath("//a[@data-qa='contact-phone-link1']"));

        //Terms and Conditions
        public static Element TermsCondTitle => new Element(By.XPath("//h6[@data-qa='policy-terms-conditions-header']"));
        //You are entitled to cancel your policy at any time with proper notice. However, an early cancellation penalty of no more than 10 percent of the premium for the remaining policy period may apply beginning on the day your policy becomes active. 
        //To learn more or cancel your policy, call 1-844-472-0967. Please note that policies cannot be cancelled by voicemail or email. Also be aware that state regulations or policy language may affect cancellation requirements.
        public static Element TermsCondCopy_YouAreEntitled => new Element(By.XPath("//p[@data-qa='policy-terms-info']"));
        ////1-844-472-0967
        public static Element TermsCondPhoneNumber => new Element(By.XPath("//a[@data-qa='contact-phone-link2']"));
        public static Element TermsCondCopy_ForFullTerms => new Element(By.XPath("//p[@data-qa='full-terms-text']"));
        //biberk.com/terms-conditions
        public static Element TermsCondHyperlink => new Element(By.XPath("//a[@data-qa='biberk-terms-link']"));


        /*
         * Bottom of Page - CTAs
         */
        public static Element GetPlanCTA => new Element(By.XPath("//button[@data-qa='choose-plan-button']"));
        public static Element GetPlusPlanCTA => new Element(By.XPath("//button[@data-qa='choose-plan-button']"));
        public static Element BottomReturnToQuoteOptionsCTA => new Element(By.XPath("//a[@data-qa='return-to-quote-button']"));
    }
}
