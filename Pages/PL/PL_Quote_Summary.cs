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
    class PL_Quote_Summary : Reusable_PurchasePath
    {
        /*
         * Your Quote
         */
        public static Element YourQuotePageTitle => new Element(By.XPath("//h1[@data-qa='quote-header']"));
        public static Element YourQuotePageSubTitle => new Element(By.XPath("//h3[@data-qa='quote-subheader']"));
        public static Element MonthlyYearlyToggle => new Element(By.XPath("//span[@data-qa='monthly-toggle']"));
        public static Element ToggleIsSetToMonthly => new Element(By.XPath("//span[@data-qa='monthly-toggle']"));
        public static Element ToggleIsSetToYearly => new Element(By.XPath("//span[@data-qa='yearly-toggle']"));
        //sample text: "Save 10 %"
        public static Element SavePercentText => new Element(By.XPath("//span[@data-qa='save-amount']"));

        /*
         * Your Plan (Standard)
         */
        public static Element YourPlanTitle => new Element(By.XPath("//legend[@data-qa='your-plan-header-Standard']"));
        //sample Yearly: "$1,160.00"
        public static Element PmtAmtYrly => new Element(By.XPath("//p[@data-qa='Standard-payment-amount-yearly']"));
        //sample Monthly: "$107.50"
        public static Element PmtAmtMnthly => new Element(By.XPath("//p[@data-qa='Standard-payment-amount-per-month']"));
        //"Per month, $1,160.00 yearly"
        public static Element PerMonth => new Element(By.XPath("//p[@data-qa='Standard-per-month-yearly']"));
        //"Per year: Save $130.00"
        public static Element PerYear => new Element(By.XPath("//p[@data-qa='Standard-per-year-save']"));
        public static Element CoverageStart => new Element(By.XPath("//p[@data-qa='Standard-coverage-start-date']"));
        //Coverages
        public static Element CoveragesTitle => new Element(By.XPath("//li[@data-qa='Standard-coverages-title']"));
        public static Element CoveragesHelper => new Element(By.XPath("//i[@data-qa='Standard-coverage-help-button']"));
        public static Element CoveragesHelpX => new Element(By.XPath("//i[@data-qa='Standard-coverages-help-text-close-icon']"));
        public static Element CoveragesHelperText => new Element(By.XPath("//div[@data-qa='Standard-coverages-help-text']"));
        //Professional Liability(E&O)
        public static Element CoverageProfLiabilityIcon => new Element(By.XPath("//i[@data-qa='Standard-coverages-list-icon-Professional Liability (E&O)']"));
        public static Element CoverageProfLiability => new Element(By.XPath("//p[@data-qa='Standard-coverages-list-Professional Liability (E&O)']"));
        //Errors & Omissions
        public static Element ErrorsAndOmisIcon => new Element(By.XPath("//i[@data-qa='Standard-coverages-list-icon-Errors & Omissions']"));
        public static Element ErrorsAndOmis => new Element(By.XPath("//p[@data-qa='Standard-coverages-list-Errors & Omissions']"));
        //Copyright Infringement
        public static Element CoverageCIIcon => new Element(By.XPath("//p[@data-qa='coverages-listCopyright/Trademark Infringement']/i[@data-qa='coverages-list-icon']"));
        public static Element CoverageCI => new Element(By.XPath("//p[@data-qa='Standard-coverages-list-Copyright/Trademark Infringement']"));
        //Sexual Abuse and Molestation
        public static Element CoverageSAMIcon => new Element(By.XPath("//i[@data-qa='Standard-coverages-list-icon-Sexual Abuse and Molestation']"));
        public static Element CoverageSAM => new Element(By.XPath("//p[@data-qa='Standard-coverages-list-Sexual Abuse and Molestation']"));

        //Deductible
        public static Element DeductibleTitle => new Element(By.XPath("//li[@data-qa='Standard-deductible-header']"));
        public static Element DeductibleHelper => new Element(By.XPath("//i[@data-qa='Standard-deductible-help-button']"));
        public static Element DeductibleHelperX => new Element(By.XPath("//i[@data-qa='Standard-deductible-help-text-close-icon']"));
        public static Element DeductibleHelperText => new Element(By.XPath("//div[@data-qa='Standard-deductible-help-text']"));
        // Deductible Per Occurrence
        public static Element DeductiblePerOcc => new Element(By.XPath("//span[@data-qa='Standard-per-occurrence-header']"));
        //sample: "$1,000"
        public static Element DeductiblePerOccAmt => new Element(By.XPath("//span[@data-qa='Standard-deductible-per-occurence']"));
        public static Element DeductiblePerOccEdit => new Element(By.XPath("//i[@data-qa='Standard-per-occurrence-edit-button']"));

        //Limits
        public static Element LimitsTitle => new Element(By.XPath("//li[@data-qa='Standard-limits-header']"));
        public static Element LimitsHelper => new Element(By.XPath("//i[@data-qa='Standard-limits-help-button']"));
        public static Element LimitsHelpX => new Element(By.XPath("//i[@data-qa='Standard-limits-help-text-close-icon']"));
        public static Element LimitsHelperText => new Element(By.XPath("//div[@data-qa='Standard-limits-help-text']"));
        //Limits Professional Liability
        public static Element LimitsPofLiabilityTitle => new Element(By.XPath("//p[@data-qa='Standard-professional-liability-header']"));
        //Limits Per Occurrence
        public static Element LimitsPerOccurrence => new Element(By.XPath("//span[@data-qa='pl-per-occurrence-label']"));
        public static Element LimitsPerOccurrenceAmt => new Element(By.XPath("//span[@data-qa='Standard-pl-per-occurrence-amount']"));
        public static Element LimitsPerOccurrenceEdit => new Element(By.XPath("//i[@data-qa='Standard-pl-occurrence-edit-button']"));
        //Limits Aggregate
        public static Element LimitsAggregate => new Element(By.XPath("//span[@data-qa='Standard-aggregate-label']"));
        public static Element LimitsAggregateAmt => new Element(By.XPath("//span[@data-qa='Standard-aggregate-amount']"));
        public static Element LimitsAggregateEdit => new Element(By.XPath("//i[@data-qa='Standard-aggregate-edit-button']"));
        //Limits Sexual Abuse and Molestation
        public static Element SAbuseAggregate => new Element(By.XPath("//p[@data-qa='Standard-SA-header']"));
        public static Element SAbuseAggregateAmt => new Element(By.XPath("//span[@data-qa='Standard-SA-amount']"));

        //Standard View Coverage Details
        public static Element StandardViewCoverageCTA => new Element(By.XPath("//a[@data-qa='Standard-view-coverage']"));
        //Standard Purchase
        public static Element PurchaseCTA => new Element(By.XPath("//button[@data-qa='Standard-purchase-button']"));
        //Cancel Coverage Anytime
        public static Element CancelCopy => new Element(By.XPath("//p[@data-qa='Standard-cancel-coverage-text']"));

        /*
         * Plus
         */
        public static Element PlusTitle => new Element(By.XPath("//legend[@data-qa='your-plan-header-Plus']"));
        public static Element PlusPmtAmtYrly => new Element(By.XPath("//p[@data-qa='Plus-payment-amount-yearly']"));
        public static Element PlusPmtAmtMnthly => new Element(By.XPath("//p[@data-qa='payment-amount-per-month']"));
        public static Element PlusPerMonth => new Element(By.XPath("//p[@data-qa='Plus-per-month-yearly']"));
        public static Element PlusPerYear => new Element(By.XPath("//p[@data-qa='Plus-per-year-save']"));
        public static Element PlusCoverageStart => new Element(By.XPath("//p[@data-qa='Plus-coverage-start-date']"));

        //Coverages
        public static Element PlusCoveragesTitle => new Element(By.XPath("//li[@data-qa='Plus-coverages-title']"));
        public static Element PlusCoveragesHelper => new Element(By.XPath("//i[@data-qa='Plus-coverage-help-button']"));
        public static Element PlusCoveragesHelpX => new Element(By.XPath("//i[@data-qa='Plus-coverages-help-text-close-icon']"));
        public static Element PlusCoveragesHelperText => new Element(By.XPath("//div[@data-qa='Plus-coverages-help-text']"));
        //Plus Professional Liability (E&O)
        public static Element PlusCoverageProfLiabilityIcon => new Element(By.XPath("//i[@data-qa='Plus-coverages-list-icon-Professional Liability (E&O)']"));
        public static Element PlusCoverageProfLiability => new Element(By.XPath("//p[@data-qa='Plus-coverages-list-Professional Liability (E&O)']"));
        //Plus Errors & Omissions
        public static Element PlusEOIcon => new Element(By.XPath("//i[@data-qa='Plus-coverages-list-icon-Errors & Omissions']"));
        public static Element PlusEO => new Element(By.XPath("//p[@data-qa='Plus-coverages-list-Errors & Omissions']"));
        //Plus Pollution Liability
        public static Element PlusPollutionLiabilityIcon => new Element(By.XPath("//i[@data-qa='Plus-coverages-list-icon-Pollution Liability']"));
        public static Element PlusPollutionLiability => new Element(By.XPath("//p[@data-qa='Plus-coverages-list-Pollution Liability']"));
        //Cyber Liability
        public static Element PlusCyberLiabilityIcon => new Element(By.XPath("//i[@data-qa='Plus-coverages-list-icon-Cyber Liability']"));
        public static Element PlusCyberLiability => new Element(By.XPath("//p[@data-qa='Plus-coverages-list-Cyber Liability']"));
        //Copyright Infringement
        public static Element PlusCopyrightInfringeIcon => new Element(By.XPath("//i[@data-qa='Plus-coverages-list-icon-Copyright/Trademark Infringement Plus']"));
        public static Element PlusCopyrightInfringe => new Element(By.XPath("//p[@data-qa='Plus-coverages-list-Copyright/Trademark Infringement Plus']"));
        //Real Estate Plus
        public static Element PlusRealEstateIcon => new Element(By.XPath("//i[@data-qa='Plus-coverages-list-icon-Real Estate Plus']"));
        public static Element PlusRealEstate => new Element(By.XPath("//p[@data-qa='coverages-listReal Estate Plus']"));
        //Plus Deductible
        public static Element PlusDeductibleTitle => new Element(By.XPath("//li[@data-qa='Plus-deductible-header']"));
        public static Element PlusDeductibleHelper => new Element(By.XPath("//i[@data-qa='Plus-deductible-help-button']"));
        public static Element PlusDeductibleHelpX => new Element(By.XPath("//i[@data-qa='Plus-deductible-help-text-close-icon']"));
        public static Element PlusDeductibleHelperText => new Element(By.XPath("//div[@data-qa='Plus-deductible-help-text']"));
        //Plus Deductible Per Occurrence
        public static Element PlusDeductPerOccur => new Element(By.XPath("//span[@data-qa='Plus-per-occurrence-header']"));
        public static Element PlusDeductPerOccurAmt => new Element(By.XPath("//span[@data-qa='Plus-deductible-per-occurence']"));
        public static Element PlusDeductPerOccurEdit => new Element(By.XPath("//i[@data-qa='Plus-pl-occurrence-edit-button']"));
        //Plus Limits
        public static Element PlusLimitsTitle => new Element(By.XPath("//li[@data-qa='Plus-limits-header']"));
        public static Element PlusLimitsHelper => new Element(By.XPath("//i[@data-qa='Plus-limits-help-button']"));
        public static Element PlusLimitsHelpX => new Element(By.XPath("//i[@data-qa='Plus-limits-help-text-close-icon']"));
        public static Element PlusLimitsHelperText => new Element(By.XPath("//div[@data-qa='Plus-limits-help-text']"));
        //Plus Limits Professional Liability
        public static Element PlusLimitsProfLiabilityTitle => new Element(By.XPath("//p[@data-qa='Plus-professional-liability-header']"));
        //Plus Limits Per Occurrence
        public static Element PlusLimitsPerOccur => new Element(By.XPath("//span[@data-qa='Plus-pl-per-occurrence-label']"));
        public static Element PlusLimitsPerOccurAmt => new Element(By.XPath("//span[@data-qa='Plus-pl-per-occurrence-amount']"));
        public static Element PlusLimitsPerOccurEdit => new Element(By.XPath("//i[@data-qa='Plus-pl-occurrence-edit-button']"));
        //Plus Limits Aggregate
        public static Element PlusLimitsAggregate => new Element(By.XPath("//span[@data-qa='Plus-aggregate-label']"));
        public static Element PlusLimitsAggregateAmt => new Element(By.XPath("//span[@data-qa='Plus-aggregate-amount']"));
        public static Element PlusLimitsAggregateEdit => new Element(By.XPath("//i[@data-qa='Plus-aggregate-edit-button']"));
        //Plus Cyber Liability Aggregate
        public static Element PlusCyberLiab => new Element(By.XPath("//p[@data-qa='Plus-cyber-liability-label']"));
        public static Element PlusCyberLiabAmt => new Element(By.XPath("//span[@data-qa='Plus-cyber-amount']"));
        public static Element PlusCyberLiabEdit => new Element(By.XPath("//i[@data-qa='Plus-cyber-edit-button']"));
        //Plus Pollution Liability Aggregate
        public static Element PlusPoll => new Element(By.XPath("//p[@data-qa='Plus-pollution-liability-header']"));
        public static Element PlusPollAggregateAmt => new Element(By.XPath("//span[@data-qa='Plus-pollution-liability-amount']"));
        public static Element PlusPollAggregateEdit => new Element(By.XPath("//i[@data-qa='Plus-pollution-liability-edit-button']"));

        //Plus View Coverage Details
        public static Element PlusViewCoverageCTA => new Element(By.XPath("//a[@data-qa='Plus-view-coverage']"));
        //Plus Purchase CTA
        public static Element PlusPurchaseCTA => new Element(By.XPath("//button[@data-qa='Plus-purchase-button']"));
        public static Element PlusCancelCopy => new Element(By.XPath("//p[@data-qa='Plus-cancel-coverage-text']"));
        /*
         * Contact
         */
        //Questions?
        public static Element ContactTitle => new Element(By.XPath("//h3[@data-qa='questions-header']"));
        public static Element ContactCopy => new Element(By.XPath("//div[@data-qa='contact-header']"));
        public static Element ContactEmail => new Element(By.XPath("//span[@data-qa='email']"));
        public static Element ContactPhone => new Element(By.XPath("//span[@data-qa='contact-phone']"));
        public static Element ContactHoursOfOp => new Element(By.XPath("//span[@data-qa='contact-hours']"));
        //Customer Reviews
        public static Element CustomerReviewTitle => new Element(By.XPath("//h3[@data-qa='customer-reviews-title']"));
        public static Element CustReviews => new Element(By.XPath("//customer-review[@data-qa='customer-reviews']"));

        //Certificate of Insurance
        public static Element CertOfInsuranceTitle => new Element(By.XPath("//h3[@data-qa='coi-label']"));
        public static Element CertOfInsuranceCopy => new Element(By.XPath("//div[@data-qa='coi-text']"));

        /*
         * Customize Your Plan
         */
        public static Element CustomizeTitle => new Element(By.XPath("//h2[@data-qa='customize-plan-header']"));
        //Deductible
        public static Element CstmDeductibleTitle => new Element(By.XPath("//div[@data-qa='deductible']"));
        //Deductible Per Occurrence
        public static Element CstmDeductPerOccurTitle => new Element(By.XPath("//span[@data-qa='per-occurrence-label']"));
        public static Element CstmDeductPerOccurHelper => new Element(By.XPath("//i[@data-qa='per-occurrence-help-icon']"));
        public static Element CstmDeductPerOccurHelperText => new Element(By.XPath("//div[@data-qa='per-occurrence-help-text']"));
        public static Element CstmDeductPerOccurHelperX => new Element(By.XPath("//i[@data-qa='per-occurrence-help-text-close-icon']"));
        public static Element CstmDeductPerOccurDDa => new Element(By.XPath("//select[@data-qa='deductible-occurence-dropdown']//parent::div[@class='select-wrapper']//input"));
        public static Element CstmDeductPerOccurDDb(string theAnswer) => new Element(By.XPath($"//div[@data-qa='deductible']/parent::fieldset//ul/li/span[text()='{theAnswer}']"));
        //Limits
        public static Element CstmLimits => new Element(By.XPath("//div[@data-qa='limits-header']"));
        //Per Occurrence
        public static Element CstmLimitsPerOccurTitle => new Element(By.XPath("//span[@data-qa='per-occurence-label']"));
        public static Element CstmLimitsPerOccurHelper => new Element(By.XPath("//i[@data-qa='per-occurence-help-icon']"));
        public static Element CstmLimitsPerOccurHelperX => new Element(By.XPath("//i[@data-qa='per-occurence-help-text-close-icon']"));
        public static Element CstmLimitsPerOccurHelperText => new Element(By.XPath("//div[@data-qa='per-occurence-help-text']"));
        public static Element CstmLimitsPerOccurDDa => new Element(By.XPath("//select[@data-qa='limits-occurence-dropdown']//parent::div[@class='select-wrapper']//input"));
        public static Element CstmLimitsPerOccurDDb(string dollarValue) => new Element(By.XPath($"//div[@data-qa='limits-header']/parent::fieldset//ul/li/span[text()='{dollarValue}']"));
        //Aggregate
        public static Element CstmAggregateTitle => new Element(By.XPath("//span[@data-qa='aggregate-label']"));
        public static Element CstmAggregateHelper => new Element(By.XPath("//i[@data-qa='aggregate-help-icon']"));
        public static Element CstmAggregateHelperText => new Element(By.XPath("//div[@data-qa='aggregate-help-text']"));
        public static Element CstmAggregateHelperX => new Element(By.XPath("//i[@data-qa='aggregate-help-text-close-icon']"));
        public static Element CstmAggregateDDa => new Element(By.XPath("//select[@data-qa='aggregate-dropdown']//parent::div[@class='select-wrapper']//input"));
        public static Element CstmAggregateDDb(string dollarValue) => new Element(By.XPath($"//select[@data-qa='aggregate-dropdown']/parent::div/ul/li/span[text()='{dollarValue}']"));
        //Cyber Liability (Aggregate)
        public static Element CstmCybLiabTitle => new Element(By.XPath("//span[@data-qa='cyber-aggregate-label']"));
        public static Element CstmCybLiabHelper => new Element(By.XPath("//i[@data-qa='cyber-aggregate-help-icon']"));
        public static Element CstmCybLiabHelperText => new Element(By.XPath("//div[@data-qa='cyber-aggregate-help-text']"));
        public static Element CstmCybLiabHelperX => new Element(By.XPath("//i[@data-qa='cyber-aggregate-help-text-close-icon']"));
        public static Element CstmCybLiabDDa => new Element(By.XPath("//select[@data-qa='cyber-dropdown']//parent::div[@class='select-wrapper']//input"));
        public static Element CstmCybLiabDDb(string dollarValue) => new Element(By.XPath($"//select[@data-qa='cyber-dropdown']/parent::div/ul/li/span[text()='{dollarValue}']"));
        //Pollution Liability (Aggregate)
        public static Element CstmPollLiabTitle => new Element(By.XPath("//span[@data-qa='pollution-label']"));
        public static Element CstmPollLiabHelper => new Element(By.XPath("//i[@data-qa='pollution-help-icon']"));
        public static Element CstmPollLiabHelperText => new Element(By.XPath("//div[@data-qa='pollution-help-text']"));
        public static Element CstmPollLiabHelperX => new Element(By.XPath("//i[@data-qa='pollution-help-text-close-icon']"));
        public static Element CstmPollLiabDDa => new Element(By.XPath("//select[@data-qa='pollution-dropdown']//parent::div[@class='select-wrapper']//input"));
        public static Element CstmPollLiabDDb(string dollarValue) => new Element(By.XPath($"//*[@id=\"customizemodal\"]/div/div[1]/form/fieldset[2]/div[4]/div[2]/div/input/parent::div/ul/li/span[text()='{dollarValue}']"));

        //Update CTA
        public static Element CstmUpdateCTA => new Element(By.XPath("//button[@data-qa='update-button']"));
    }
}
