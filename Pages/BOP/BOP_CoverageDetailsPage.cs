using BiBerkLOB.Source.Driver;
using HitachiQA.Driver;
using OpenQA.Selenium;
using HitachiQA.Driver.Input;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.BOP
{
    [Binding]
    public sealed class BOP_CoverageDetailsPage
    {
        public static LoadingRequirements LoadingRequirements =>
            new LoadingRequirements(CoverageDetailsTitle, CoverageDetailsTitleText);

        //Coverage Details Header
        public static Element CoverageDetailsTitle => new Element(By.XPath("//h1[@data-qa='Coverage-label']"));
        public static Element CoverageDetailsTitleText => new Element(By.XPath("//h6[@data-qa='Coverage-sub-label']"));

        //Coverage Details Questions

        //Are you required to name a third party as an additional insured or loss payee on your policy? (e.g., landlord, banker, client, contractor, etc.)?
        public static Element AreYouRequiredToNameAThirdPartyQST => new Element(By.XPath("//label[@data-qa='_apollo_ThirdPartyRequired-label']"));
        public static Element AreYouRequiredToNameAThirdPartyYesButton => new Element(By.XPath("//button[@data-qa='_apollo_ThirdPartyRequired-8015-yes-button']"));
        public static Element AreYouRequiredToNameAThirdPartyNoButton => new Element(By.XPath("//button[@data-qa='_apollo_ThirdPartyRequired-8015-no-button']"));
        public static Element AreYouRequiredToNameAThirdPartyHint => new Element(By.XPath("//mat-hint[@data-qa='_apollo_ThirdPartyRequired-hint']"));
        public static YesOrNoGroup AreYouRequiredToNameAThirdPartyGroup => new YesOrNoGroup(AreYouRequiredToNameAThirdPartyYesButton, AreYouRequiredToNameAThirdPartyNoButton);
        public static InputSection AnyVolunteers_Input =>
          new YesOrNoInput(AreYouRequiredToNameAThirdPartyGroup)
           .AsAQuestion(AreYouRequiredToNameAThirdPartyQST).
            WithExtraText(AreYouRequiredToNameAThirdPartyHint);

        //Have you had any property or liability claims in the past 3 years?
        public static Element PropertyLiabilityClaim3YearQST => new Element(By.XPath("//label[@data-qa='_apollo_PropertyLiabilityClaim3Year-label']"));
        public static Element PropertyLiabilityClaim3YearHelper => new Element(By.XPath("//button[@data-qa='buttonShowHelpToggle-_apollo_PropertyLiabilityClaim3Year']"));
        public static Element PropertyLiabilityClaim3YearHelperText => new Element(By.XPath("//bb-helptext[@data-qa='bbHelpText-_apollo_PropertyLiabilityClaim3Year-label']"));
        public static Element PropertyLiabilityClaim3YearYesButton => new Element(By.XPath("//button[@data-qa='_apollo_PropertyLiabilityClaim3Year-8015-yes-button']"));
        public static Element PropertyLiabilityClaim3YearNoButton => new Element(By.XPath("//button[@data-qa='_apollo_PropertyLiabilityClaim3Year-8015-no-button']"));
        public static YesOrNoGroup PropertyLiabilityClaim3YearGroup => new YesOrNoGroup(PropertyLiabilityClaim3YearYesButton, PropertyLiabilityClaim3YearNoButton);
        public static InputSection PropertyLiabilityClaim3Year_Input =>
          new YesOrNoInput(PropertyLiabilityClaim3YearGroup)
           .AsAQuestion(PropertyLiabilityClaim3YearQST);

        //Do you currently have a property or general liability policy in effect?
        public static Element CurrentPropertyGeneralLiabilityQST => new Element(By.XPath("//label[@data-qa='_apollo_CurrentPropertyGeneralLiability-label']"));

        public static Element CurrentPropertyGeneralLiabilityHelper => new Element(By.XPath("//button[@data-qa='buttonShowHelpToggle-_apollo_CurrentPropertyGeneralLiability']"));
        public static Element CurrentPropertyGeneralLiabilityHelperText => new Element(By.XPath("//bb-helptext[@data-qa='bbHelpText-_apollo_CurrentPropertyGeneralLiability-label']"));
        public static Element CurrentPropertyGeneralLiabilityYesButton => new Element(By.XPath("//button[@data-qa='_apollo_CurrentPropertyGeneralLiability-8015-yes-button']"));
        public static Element CurrentPropertyGeneralLiabilityNoButton => new Element(By.XPath("//button[@data-qa='_apollo_CurrentPropertyGeneralLiability-label']"));
        public static YesOrNoGroup CurrentPropertyGeneralLiabilityGroup => new YesOrNoGroup(CurrentPropertyGeneralLiabilityYesButton, CurrentPropertyGeneralLiabilityNoButton);
        public static InputSection CurrentPropertyGeneralLiability_Input =>
          new YesOrNoInput(CurrentPropertyGeneralLiabilityGroup)
           .AsAQuestion(CurrentPropertyGeneralLiabilityQST);

        //When was your last policy in effect?
        public static Element LastPolicyEffectiveQST => new Element(By.XPath("//label[@data-qa='_apollo_LastPolicyEffective-label']"));
        public static Element LastPolicyEffectiveSelectDD => new Element(By.XPath("//mat-select[@data-qa='_apollo_LastPolicyEffective']"));
        public static InputSection LastPolicyEffectiveInput => new MatDropdownInput(LastPolicyEffectiveSelectDD)
            .AsAQuestion(LastPolicyEffectiveQST);

        //Since your last policy, have there been any losses, accidents, or events that might result in a claim?
        public static Element EventsLastPolicyQST => new Element(By.XPath("//label[@data-qa='_apollo_EventsLastPolicy-label']"));
        public static Element EventsLastPolicyLabelYesButton => new Element(By.XPath("//button[@data-qa='_apollo_EventsLastPolicy-8015-yes-button']"));
        public static Element EventsLastPolicyLabelNoButton => new Element(By.XPath("//button[@data-qa='_apollo_EventsLastPolicy-8015-no-button']"));
        public static YesOrNoGroup EventsLastPolicyGroup => new YesOrNoGroup(EventsLastPolicyLabelYesButton, EventsLastPolicyLabelNoButton);
        public static InputSection EventsLastPolicy_Input =>
          new YesOrNoInput(EventsLastPolicyGroup)
           .AsAQuestion(EventsLastPolicyQST);
    }
}