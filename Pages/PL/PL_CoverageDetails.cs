using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BiBerkLOB.Components.PL;
using BiBerkLOB.Source.Driver;
using HitachiQA.Driver.Input;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.PL
{
    public sealed class PL_CoverageDetails
    {
        /*
         * PROFESSIONAL LIABILITY ONLY-----------------------------------------------------------------------
         */

        //Coverage Details
        public static Element CoverageDetails => new Element(By.XPath("//h1[@data-qa='coverage-details-header']"));
        //You're making great progress!  Now we'd like to know about your insurance needs.
        public static Element CoverageDetailsParagraph => new Element(By.XPath("//h6[@data-qa='progress-subheader']"));
        public static LoadingRequirements LoadingRequirements => new LoadingRequirements(Reusable_PurchasePath.YourPLQuoteID, CoverageDetails, CoverageDetailsParagraph);

        //When should your policy start?
        public static Element PolicyStart => new Element(By.XPath("//span[@data-qa='policy-start-question-label']"));
        public static Element PolicyStartHelper => new Element(By.XPath("//i[@data-qa='policy-start-question-help-icon']"));
        public static Element PolicyStartHelperText => new Element(By.XPath("//div[@data-qa='policy-start-question-help-text']"));
        public static Element PolicyStartHelperX => new Element(By.XPath("//i[@data-qa='policy-start-question-help-text-close-icon']"));
        //Date field that holds a date
        public static IDatePicker PolicyStartDatePicker => new PL_DatePicker("When should your policy start?");
        public static InputSection PolicyStartQuestion =>
            new DatePickerInput(PolicyStartDatePicker)
                .AsAQuestion(PolicyStart)
                .WithHelpText(PolicyStartHelper, PolicyStartHelperText, PolicyStartHelperX);
 
        //Do you currently have a Professional Liability (E&O) policy in effect?
        public static Element CurrentlyHavePL => new Element(By.XPath("//span[@data-qa='question-33699-label']"));
        public static Element CurrentlyHavePLBTN_Yes => new Element(By.XPath("//label[@data-qa='33699Yes']"));
        public static Element CurrentlyHavePLBTN_No => new Element(By.XPath("//label[@data-qa='33699No']"));
        public static Element CurrentlyHavePLHelper => new Element(By.XPath("//i[@data-qa='question-33699-help-icon']"));
        public static Element CurrentlyHavePLHelperText => new Element(By.XPath("//div[@data-qa='question-33699-help-text']"));
        public static Element CurrentlyHavePLHelperX => new Element(By.XPath("//i[@data-qa='question-33699-help-text-close-icon']"));
        public static Element CurrentlyHavePLTextBelow => new Element(By.XPath("//span[@data-qa='33699-validation-text']"));
        public static YesOrNoGroup CurrentlyHavePLGroup => new YesOrNoGroup(CurrentlyHavePLBTN_Yes, CurrentlyHavePLBTN_No);
        public static InputSection CurrentlyHavePLQuestion =>
            new YesOrNoInput(CurrentlyHavePLGroup)
                .AsAQuestion(CurrentlyHavePL)
                .WithExtraText(CurrentlyHavePLTextBelow)
                .WithHelpText(CurrentlyHavePLHelper, CurrentlyHavePLHelperText, CurrentlyHavePLHelperX);

        //Does your current policy have a retroactive date?
        public static Element HaveRetroDate => new Element(By.XPath("//span[@data-qa='question-33693-label']"));
        public static Element HaveRetroDateBTN_Yes => new Element(By.XPath("//label[@data-qa='33693Yes']"));
        public static Element HaveRetroDateBTN_No => new Element(By.XPath("//label[@data-qa='33693No']"));
        public static Element HaveRetroDateBTN_IDK => new Element(By.XPath("//label[@data-qa='33693I Dont Know']"));
        public static Element HaveRetroDateHelper => new Element(By.XPath("//i[@data-qa='question-33693-help-icon']"));
        public static Element HaveRetroDateHelperText => new Element(By.XPath("//div[@data-qa='question-33693-help-text']"));
        public static Element HaveRetroDateHelperX => new Element(By.XPath("//i[@data-qa='question-33693-help-text-close-icon']"));
        private static Dictionary<string, Element> _haveRetroChoices => new Dictionary<string, Element>()
        {
            { "Yes", HaveRetroDateBTN_Yes },
            { "No", HaveRetroDateBTN_No },
            { "I Don't Know", HaveRetroDateBTN_IDK }
        };
        public static ChoiceGroup HaveRetroDateGroup => new ChoiceGroup(_haveRetroChoices);
        public static InputSection HaveRetroDateChoiceQuestion =>
            new SingleChoiceGroupInput(HaveRetroDateGroup)
                .AsAQuestion(HaveRetroDate)
                .WithHelpText(HaveRetroDateHelper, HaveRetroDateHelperText, HaveRetroDateHelperX);

        //What is retroactive date?
        // (shows if answer "Yes" to Does your current policy have a retroactive date?)
        public static Element RetroDate => new Element(By.XPath("//span[@data-qa='question-33717-label']"));
        public static Element RetroDateError => new Element(By.XPath("//span[@data-qa='retro-date-datepicker-input-validation-error']"));
        public static IDatePicker RetroDateDatePicker => new PL_DatePicker("What is the retroactive date?");
        public static InputSection RetroDateDateQuestion => 
            new DatePickerInput(RetroDateDatePicker)
                .AsAQuestion(RetroDate);
        public static Element RetroDateInput => new Element("//input[@data-qa='retro-date-datepicker-input']");

        //Have you had a Professional Liability (E&O) policy in the last 3 years?
        // (shows if answer "No" to Do you currently have a Professional Liability (E&O) policy in effect?)
        public static Element HaveHadPLInLast3Years => new Element(By.XPath("//span[@data-qa='past-policy-label']"));
        public static Element HaveHadPLInLast3YearsBTN_Yes => new Element(By.XPath("//label[@data-qa='past-policy-buttonYes']"));
        public static Element HaveHadPLInLast3YearsBTN_No => new Element(By.XPath("//label[@data-qa='past-policy-buttonNo']"));
        public static YesOrNoGroup HaveHadPLInLast3YearsGroup => new YesOrNoGroup(HaveHadPLInLast3YearsBTN_Yes, HaveHadPLInLast3YearsBTN_No);
        public static InputSection HaveHadPLInLast3YearsQuestion =>
            new YesOrNoInput(HaveHadPLInLast3YearsGroup)
                .AsAQuestion(HaveHadPLInLast3Years);

        //Which option best describes your current professional liability policy?
        // (shows if answer "No" to Does your current policy have a retroactive date?)
        public static Element CurrentPLPolicy => new Element(By.XPath("//span[@data-qa='question-33709-label']"));
        // Allowed Choices:
        // This was my first policy
        // I have full prior acts coverage under my current policy
        public static Element CurrentPLPolicyChoiceBTN(string answer) => new Element(By.XPath($"//label[@data-qa='33709{answer}']"));
        public static ChoiceGroup CurrentPLPolicyGroup = new ChoiceGroup(CurrentPLPolicyChoiceBTN);
        public static InputSection CurrentPLPolicyQuestion =>
            new SingleChoiceGroupInput(CurrentPLPolicyGroup)
                .AsAQuestion(CurrentPLPolicy);

        //How many Professional Liability (E&O) claims have you had in the past 3 years, if any?
        // (shows if answer "Yes" to Do you currently have a Professional Liability (E&O) policy in effect?)
        public static Element HowManyPLClaims => new Element(By.XPath("//span[@data-qa='num-past-claims-label']"));
        // to delete ------------
        public static Element HowManyPLClaimsBTN_0 => new Element(By.XPath("//label[@data-qa='claim-num-button0']"));
        public static Element HowManyPLClaimsBTN_1 => new Element(By.XPath("//label[@data-qa='claim-num-button1']"));
        public static Element HowManyPLClaimsBTN_2 => new Element(By.XPath("//label[@data-qa='claim-num-button2']"));
        public static Element HowManyPLClaimsBTN_3 => new Element(By.XPath("//label[@data-qa='claim-num-button3']"));
        public static Element HowManyPLClaimsBTN_4 => new Element(By.XPath("//label[@data-qa='claim-num-button4']"));
        public static Element HowManyPLClaimsBTN_5 => new Element(By.XPath("//label[@data-qa='claim-num-button5']"));
        // ----------------------
        public static Element HowManyPLClaimsBTNChoice(int numClaims) => new Element(By.XPath($"//label[@data-qa='claim-num-button{Math.Clamp(numClaims, 0, 5)}']"));
        public static Element HowManyPLClaimsHelper => new Element(By.XPath("//i[@data-qa='num-past-claims-help-icon']"));
        public static Element HowManyPLClaimsHelperText => new Element(By.XPath("//div[@data-qa='num-past-claims-help-text']"));
        public static Element HowManyPLClaimsHelperX => new Element(By.XPath("//i[@data-qa='num-past-claims-help-text-close-icon']"));
        public static ChoiceGroup HowManyPLClaimsGroup => new ChoiceGroup(s => HowManyPLClaimsBTNChoice(int.Parse(s)));
        public static InputSection HowManyPLClaimsQuestion =>
            new SingleChoiceGroupInput(HowManyPLClaimsGroup)
                .AsAQuestion(HowManyPLClaims)
                .WithHelpText(HowManyPLClaimsHelper, HowManyPLClaimsHelperText, HowManyPLClaimsHelperX);

        // Page CTA
        public static Element BackCTA => new Element(By.XPath("//button[@data-qa='go-to-business-button']"));
        public static Element LetsContinueCTA => new Element(By.XPath("//button[@data-qa='validate-coverage-button']"));
    }
}