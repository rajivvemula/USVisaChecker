using TechTalk.SpecFlow;
using System.Collections.Generic;
using HitachiQA.Driver;
using HitachiQA.Helpers;
using BiBerkLOB.Pages.CommAuto;

namespace BiBerkLOB.StepDefinition.General.Other
{
    [Binding]
    public sealed class CA_Gen_TermsandConditions
    {
        [Then(@"user verifies the Terms and Conditions window")]
        public void ThenUserVerifiesTheTermsAndConditionsWindow()
        {
            CA_PurchaseYourPlanPage.AgreeToTermsOfUseHyperlink.Click();

            AutomationHelper.ValidateElements(TermsandConditionsElements);
            CA_Gen_TermsAndConditionsPage.TermsAndConditionsX.Click();
        }

        public static List<Element> TermsandConditionsElements => new()
        {
            CA_Gen_TermsAndConditionsPage.TermsAndConditionsTitle,
            CA_Gen_TermsAndConditionsPage.TermsAndConditionsParagraph,
            CA_Gen_TermsAndConditionsPage.TermsAndConditionsX,
            CA_Gen_TermsAndConditionsPage.PersonalInfoTitle,
            CA_Gen_TermsAndConditionsPage.PersonalInfoParagraph,
            CA_Gen_TermsAndConditionsPage.CancellationTitle,
            CA_Gen_TermsAndConditionsPage.CancellationParagraph,
            CA_Gen_TermsAndConditionsPage.AutoPayTitle,
            CA_Gen_TermsAndConditionsPage.AutoPayParagraph,
            CA_Gen_TermsAndConditionsPage.PaymentSchedTitle,
            CA_Gen_TermsAndConditionsPage.PaymentSchedParagraph,
            CA_Gen_TermsAndConditionsPage.RecurringDirectDraftTitle,
            CA_Gen_TermsAndConditionsPage.RecurringDirectDraftParagraph,
            CA_Gen_TermsAndConditionsPage.StateTermsTitle,
            CA_Gen_TermsAndConditionsPage.StateTerms_AZTitle,
            CA_Gen_TermsAndConditionsPage.StateTerms_AZParagraph,
            CA_Gen_TermsAndConditionsPage.StateTerms_CATitle,
            CA_Gen_TermsAndConditionsPage.StateTerms_CAParagraph,
            CA_Gen_TermsAndConditionsPage.StateTerms_MassTitle,
            CA_Gen_TermsAndConditionsPage.StateTerms_MassParagraph,
            CA_Gen_TermsAndConditionsPage.StateTerms_MinnTitle,
            CA_Gen_TermsAndConditionsPage.StateTerms_MinnParagraph,
            CA_Gen_TermsAndConditionsPage.StateTerms_ORTitle,
            CA_Gen_TermsAndConditionsPage.StateTerms_ORParagraph,
            CA_Gen_TermsAndConditionsPage.StateTerms_ALDCLAMYNMRIWVTitle,
            CA_Gen_TermsAndConditionsPage.StateTerms_ALDCLAMYNMRIWVParagraph,
            CA_Gen_TermsAndConditionsPage.StateTerms_ALDCLAMYNMRIWV_Asterisk,
            CA_Gen_TermsAndConditionsPage.StateTerms_COTitle,
            CA_Gen_TermsAndConditionsPage.StateTerms_COParagraph,
            CA_Gen_TermsAndConditionsPage.StateTerms_FLOKTitle,
            CA_Gen_TermsAndConditionsPage.StateTerms_FLOKParagraph,
            CA_Gen_TermsAndConditionsPage.StateTerms_FLOK_Asterisk,
            CA_Gen_TermsAndConditionsPage.StateTerms_KSTitle,
            CA_Gen_TermsAndConditionsPage.StateTerms_KSParagraph,
            CA_Gen_TermsAndConditionsPage.StateTerms_KYNYOHPATitle,
            CA_Gen_TermsAndConditionsPage.StateTerms_KYNYOHPAParagraph,
            CA_Gen_TermsAndConditionsPage.StateTerms_KYNYOHPA_Asterisk,
            CA_Gen_TermsAndConditionsPage.StateTerms_METNVAWATitle,
            CA_Gen_TermsAndConditionsPage.StateTerms_METNVAWAParagraph,
            CA_Gen_TermsAndConditionsPage.StateTerms_METNVAWA_Asterisk,
            CA_Gen_TermsAndConditionsPage.StateTerms_NJTitle,
            CA_Gen_TermsAndConditionsPage.StateTerms_NJParagraph,
            CA_Gen_TermsAndConditionsPage.StateTerms_UTTitle,
            CA_Gen_TermsAndConditionsPage.StateTerms_UTParagraph,
            CA_Gen_TermsAndConditionsPage.StateTerms_VTTitle,
            CA_Gen_TermsAndConditionsPage.StateTerms_VTParagraph,
            CA_Gen_TermsAndConditionsPage.PrintBTN,
        };
    }
}
