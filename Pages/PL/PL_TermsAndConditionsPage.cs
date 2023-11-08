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
    class PL_TermsAndConditionsPage
    {
        public static Element TermsACondTitle => new Element(By.XPath("//h1[@data-qa='T&C-Header']"));
        public static Element TermsACondParagraph => new Element(By.XPath("//div[@data-qa='T&C-Subheader-Text']"));
        public static Element TermsACondX => new Element(By.XPath("//i[@data-qa='modal-x-icon']"));
        
        //Claims Made Coverage Basis
        public static Element ClaimsMadeTitle => new Element(By.XPath("//h2[@data-qa='T&C-Claims-Made-Coverage-Basis']"));
        public static Element ClaimsMadeCopy_This => new Element(By.XPath("//div[@data-qa='T&C-Claims-Made-Coverage-Basis-text']"));
        public static Element ClaimsMadeCopy_ForNY => new Element(By.XPath("//h2[@data-qa='T&C-For-NY-policyholders']"));
        public static Element ClaimsMadeCopy_Therates => new Element(By.XPath("//p[contains(text(), 'The rates')]"));
        public static Element ClaimsMadeCopy_IfYour => new Element(By.XPath("//p[contains(text(), 'If your policy')]"));
        public static Element ClaimsMadeCopy_YouHave => new Element(By.XPath("//p[contains(text(), 'You have the following options')]"));
        public static Element ClaimsMadeCopy_OneYearTitle => new Element(By.XPath("//li[@data-qa='NY-policyholders-year-1']"));
        public static Element ClaimsMadeCopy_OneYearAmt => new Element(By.XPath("//li[@data-qa='NY-policyholders-option-100-percent']"));
        public static Element ClaimsMadeCopy_TwoYearTitle => new Element(By.XPath("//li[@data-qa='NY-policyholders-year-2']"));
        public static Element ClaimsMadeCopy_TwoYearAmt => new Element(By.XPath("//li[@data-qa='NY-policyholders-option-150-percent']"));
        public static Element ClaimsMadeCopy_ThreeYearTitle => new Element(By.XPath("//li[@data-qa='NY-policyholders-year-3']"));
        public static Element ClaimsMadeCopy_ThreeYearAmt => new Element(By.XPath("//li[@data-qa='NY-policyholders-option-200-percent']"));
        public static Element ClaimsMadeCopy_FourYearTitle => new Element(By.XPath("//li[@data-qa='NY-policyholders-year-4']"));
        public static Element ClaimsMadeCopy_FourYearAmt => new Element(By.XPath("//li[@data-qa='NY-policyholders-option-225-percent']"));
        public static Element ClaimsMadeCopy_FiveYearTitle => new Element(By.XPath("//li[@data-qa='NY-policyholders-year-5-or-more']"));
        public static Element ClaimsMadeCopy_FiveYearAmt => new Element(By.XPath("//li[@data-qa='NY-policyholders-option-250-percent']"));
        public static Element ClaimsMadeCopy_MayBeUnlimited => new Element(By.XPath("//p[@data-qa='NY-help-text']"));

        //Claim Expense
        public static Element ClaimExpenTitle => new Element(By.XPath("//h2[@data-qa='T&C-Claim-Expense']"));
        public static Element ClaimExpenParagraph => new Element(By.XPath("//p[contains(text(), 'Claim Expense is')]"));
        public static Element ClaimExpenNotApplInMontana => new Element(By.XPath("//p[@data-qa='claim-expense-help-text-1']"));
        public static Element ClaimExpenNotApplInNY => new Element(By.XPath("//p[@data-qa='claim-expense-help-text-2']"));

        //Personal Information
        public static Element PersonalInfoTitle => new Element(By.XPath("//h2[@data-qa='T&C-Personal-Information']"));
        public static Element PersonalInfoParagraph => new Element(By.XPath("//p[@data-qa='personal-information-text']"));

        //Cancellation
        public static Element CancellationTitle => new Element(By.XPath("//h2[@data-qa='T&C-Cancellation']"));
        public static Element CancellationAPortion => new Element(By.XPath("//p[@data-qa='cancellation-text-1']"));
        public static Element CancellationIfYouCancel => new Element(By.XPath("//p[@data-qa='cancellation-text-2']"));
        public static Element CancellationIfACheck => new Element(By.XPath("//p[@data-qa='cancellation-text-3']"));

        //Recurring Direct Draft Program
        public static Element RecurDDTitle => new Element(By.XPath("//h2[@data-qa='T&C-Recurring-Direct-Draft-Program']"));
        public static Element RecurDDParagraph => new Element(By.XPath("//p[@data-qa='recurring-direct-draft-text']"));
        public static Element RecurDDLink => new Element(By.XPath("//a[@data-qa='customer-service-email']"));

        //AutoPay - Recurring Credit Card Program
        public static Element AutoPayTitle => new Element(By.XPath("//h2[@data-qa='T&C-AutoPay---Recurring-Credit-Card-Program']"));
        public static Element AutoPayParagraph => new Element(By.XPath("//p[@data-qa='autopay-recurring-text']"));
        public static Element AutoPayPhoneLink => new Element(By.XPath("//a[@data-qa='autopay-recurring-help-number']"));

        //Payment Schedule
        public static Element PaymentSchedTitle => new Element(By.XPath("//h2[@data-qa='T&C-Payment-Schedule']"));
        public static Element PaymentSchedParagraph => new Element(By.XPath("//p[@data-qa='payment-schedule-text']"));
        public static Element PaymentSchedPhoneLink => new Element(By.XPath("//a[@data-qa='payment-schedule-help-number']"));

        //State Specific Terms & Conditions
        public static Element StateSpecTitle => new Element(By.XPath("//h2[@data-qa='T&C-State-Specific-Header']"));
        public static Element StateSpecAZTitle => new Element(By.XPath("//h3[@data-qa='T&C-Arizona']"));
        public static Element StateSpecAZParagraph => new Element(By.XPath("//p[@data-qa='Arizona-text']"));
        public static Element StateSpecCATitle => new Element(By.XPath("//h3[@data-qa='T&C-California']"));
        public static Element StateSpecCAParagraph1 => new Element(By.XPath("//p[@data-qa='California-text-1']"));
        public static Element StateSpecCAParagraph2 => new Element(By.XPath("//p[@data-qa='California-text-2']"));
        public static Element StateSpecMATitle => new Element(By.XPath("//h3[@data-qa='T&C-Massachusetts']")); 
        public static Element StateSpecMAParagraph => new Element(By.XPath("//p[@data-qa='Massachusetts-text-1']"));
        public static Element StateSpecMNTitle => new Element(By.XPath("//h3[@data-qa='T&C-Minnesota']")); 
        public static Element StateSpecMNParagraph => new Element(By.XPath("//p[@data-qa='Minnesota-text-1']"));
        public static Element StateSpecORTitle => new Element(By.XPath("//h3[@data-qa='T&C-Oregon']"));
        public static Element StateSpecORParagraph1 => new Element(By.XPath("//p[@data-qa='Oregon-text-1']"));
        public static Element StateSpecORParagraph2 => new Element(By.XPath("//p[@data-qa='Oregon-text-2']"));
        public static Element StateSpecALARTitle => new Element(By.XPath("//h3[@data-qa='T&C-Alabama-Arkansas-District-of-Columbia-Louisiana-Maryland-New-Mexico-Rhode-Island-and-West-Virginia']"));
        public static Element StateSpecALARParagraph => new Element(By.XPath("//p[@data-qa='multi-state-text']"));
        public static Element StateSpecALARAppliesIn => new Element(By.XPath("//p[@data-qa='T&C-Sixth-Addendum']"));
        public static Element StateSpecCOTitle => new Element(By.XPath("//h3[@data-qa='T&C-Colorado']"));
        public static Element StateSpecCOParagraph => new Element(By.XPath("//p[@data-qa='Colorado-text-1']"));
        public static Element StateSpecFLOKTitle => new Element(By.XPath("//h3[@data-qa='T&C-Florida-and-Oklahoma']"));
        public static Element StateSpecFLOKParagraph => new Element(By.XPath("//p[@data-qa='FL&OK-text-1']"));
        public static Element StateSpecFLOKAppliesIn => new Element(By.XPath("//p[@data-qa='T&C-Eighth-Addendum']"));
        public static Element StateSpecKSTitle => new Element(By.XPath("//h3[@data-qa='T&C-Kansas']"));
        public static Element StateSpecKSParagraph => new Element(By.XPath("//p[@data-qa='Kansas-text-1']"));
        public static Element StateSpecKYNYTitle => new Element(By.XPath("//h3[@data-qa='T&C-Kentucky-New-York-Ohio-and-Pennsylvania']"));
        public static Element StateSpecKYNYParagraph => new Element(By.XPath("//p[@data-qa='KT-NY-OH-PA-text-1']"));
        public static Element StateSpecKYNYAppliesIn => new Element(By.XPath("//p[@data-qa='T&C-Tenth-Addendum']"));
        public static Element StateSpecMETENTitle => new Element(By.XPath("//h3[@data-qa='T&C-Maine-Tennessee-Virginia-and-Washington']"));
        public static Element StateSpecMETENParagraph => new Element(By.XPath("//p[@data-qa='ME-TN-VA-WA-text-1']"));
        public static Element StateSpecMETENAppliesIn => new Element(By.XPath("//p[@data-qa='T&C-Eleventh-Addendum']"));
        public static Element StateSpecNJTitle => new Element(By.XPath("//h3[@data-qa='T&C-New-Jersey']"));
        public static Element StateSpecNJParagraph => new Element(By.XPath("//p[@data-qa='New-Jersey-text-1']"));
        public static Element StateSpecUTTitle => new Element(By.XPath("//h3[@data-qa='T&C-Utah']"));
        public static Element StateSpecUTParagraph => new Element(By.XPath("//p[@data-qa='Utah-text-1']"));
        public static Element StateSpecVTTitle => new Element(By.XPath("//h3[@data-qa='T&C-Vermont']"));
        public static Element StateSpecVTParagraph => new Element(By.XPath("//p[@data-qa='Vermont-text-1']"));

        public static Element CloseBtn => new Element(By.XPath("//button[@data-qa='modal-close-button']"));
    }
}