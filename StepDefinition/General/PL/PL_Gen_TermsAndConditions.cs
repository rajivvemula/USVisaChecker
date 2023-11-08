using BiBerkLOB.Pages;
using BiBerkLOB.Pages.PL;
using DocumentFormat.OpenXml.Bibliography;
using HitachiQA;
using HitachiQA.Driver;
using HitachiQA.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V85.Page;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace BiBerkLOB.StepDefinition.General.PL
{
    [Binding]
    public sealed class PL_Gen_TermsAndConditions
    {
        [Then(@"user verifies the PL terms and conditions page appearance")]
        public void ThenUserVerifiesThePLTermsAndConditionsPageAppearance()
        {
            PL_PurchasePage.TermsOfUseLink.Click();

            AutomationHelper.ValidateElements(TermsandConditionsElements);
            PL_TermsAndConditionsPage.CloseBtn.Click();
        }

        public static List<Element> TermsandConditionsElements => new()
        {   
            
            PL_TermsAndConditionsPage.TermsACondTitle,
            PL_TermsAndConditionsPage.TermsACondParagraph,
            //PL_TermsAndConditionsPage.TermsACondX,
            PL_TermsAndConditionsPage.ClaimsMadeTitle,
            PL_TermsAndConditionsPage.ClaimsMadeCopy_This,
            PL_TermsAndConditionsPage.ClaimsMadeCopy_ForNY,
            PL_TermsAndConditionsPage.ClaimsMadeCopy_Therates,
            PL_TermsAndConditionsPage.ClaimsMadeCopy_IfYour,
            PL_TermsAndConditionsPage.ClaimsMadeCopy_YouHave,
            PL_TermsAndConditionsPage.ClaimsMadeCopy_OneYearTitle,
            PL_TermsAndConditionsPage.ClaimsMadeCopy_OneYearAmt,
            PL_TermsAndConditionsPage.ClaimsMadeCopy_TwoYearTitle,
            PL_TermsAndConditionsPage.ClaimsMadeCopy_TwoYearAmt,
            PL_TermsAndConditionsPage.ClaimsMadeCopy_ThreeYearTitle,
            PL_TermsAndConditionsPage.ClaimsMadeCopy_ThreeYearAmt,
            PL_TermsAndConditionsPage.ClaimsMadeCopy_FourYearTitle,
            PL_TermsAndConditionsPage.ClaimsMadeCopy_FourYearAmt,
            PL_TermsAndConditionsPage.ClaimsMadeCopy_FiveYearTitle,
            PL_TermsAndConditionsPage.ClaimsMadeCopy_FiveYearAmt,
            PL_TermsAndConditionsPage.ClaimsMadeCopy_MayBeUnlimited,
            PL_TermsAndConditionsPage.ClaimExpenTitle,
            PL_TermsAndConditionsPage.ClaimExpenParagraph,
            PL_TermsAndConditionsPage.ClaimExpenNotApplInMontana,
            PL_TermsAndConditionsPage.ClaimExpenNotApplInNY,
            PL_TermsAndConditionsPage.PersonalInfoTitle,
            PL_TermsAndConditionsPage.PersonalInfoParagraph,
            PL_TermsAndConditionsPage.CancellationTitle,
            PL_TermsAndConditionsPage.CancellationAPortion,
            PL_TermsAndConditionsPage.CancellationIfYouCancel,
            PL_TermsAndConditionsPage.CancellationIfACheck,
            PL_TermsAndConditionsPage.RecurDDTitle,
            PL_TermsAndConditionsPage.RecurDDParagraph,
            PL_TermsAndConditionsPage.RecurDDLink,
            PL_TermsAndConditionsPage.AutoPayTitle,
            PL_TermsAndConditionsPage.AutoPayParagraph,
            PL_TermsAndConditionsPage.AutoPayPhoneLink,
            PL_TermsAndConditionsPage.PaymentSchedTitle,
            PL_TermsAndConditionsPage.PaymentSchedParagraph,
            PL_TermsAndConditionsPage.PaymentSchedPhoneLink,
            PL_TermsAndConditionsPage.StateSpecTitle,
            PL_TermsAndConditionsPage.StateSpecAZTitle,
            PL_TermsAndConditionsPage.StateSpecAZParagraph,
            PL_TermsAndConditionsPage.StateSpecCATitle,
            PL_TermsAndConditionsPage.StateSpecCAParagraph1,
            PL_TermsAndConditionsPage.StateSpecCAParagraph2,
            PL_TermsAndConditionsPage.StateSpecMATitle,
            PL_TermsAndConditionsPage.StateSpecMAParagraph,
            PL_TermsAndConditionsPage.StateSpecMNTitle,
            PL_TermsAndConditionsPage.StateSpecMNParagraph,
            PL_TermsAndConditionsPage.StateSpecORTitle,
            PL_TermsAndConditionsPage.StateSpecORParagraph1,
            PL_TermsAndConditionsPage.StateSpecORParagraph2,
            PL_TermsAndConditionsPage.StateSpecALARTitle,
            PL_TermsAndConditionsPage.StateSpecALARParagraph,
            PL_TermsAndConditionsPage.StateSpecALARAppliesIn,
            PL_TermsAndConditionsPage.StateSpecCOTitle,
            PL_TermsAndConditionsPage.StateSpecCOParagraph,
            PL_TermsAndConditionsPage.StateSpecFLOKTitle,
            PL_TermsAndConditionsPage.StateSpecFLOKParagraph,
            PL_TermsAndConditionsPage.StateSpecFLOKAppliesIn,
            PL_TermsAndConditionsPage.StateSpecKSTitle,
            PL_TermsAndConditionsPage.StateSpecKSParagraph,
            PL_TermsAndConditionsPage.StateSpecKYNYTitle,
            PL_TermsAndConditionsPage.StateSpecKYNYParagraph,
            PL_TermsAndConditionsPage.StateSpecKYNYAppliesIn,
            PL_TermsAndConditionsPage.StateSpecMETENTitle,
            PL_TermsAndConditionsPage.StateSpecMETENParagraph,
            PL_TermsAndConditionsPage.StateSpecMETENAppliesIn,
            PL_TermsAndConditionsPage.StateSpecNJTitle,
            PL_TermsAndConditionsPage.StateSpecNJParagraph,
            PL_TermsAndConditionsPage.StateSpecUTTitle,
            PL_TermsAndConditionsPage.StateSpecUTParagraph,
            PL_TermsAndConditionsPage.StateSpecVTTitle,
            PL_TermsAndConditionsPage.StateSpecVTParagraph,
            PL_TermsAndConditionsPage.CloseBtn,
        };
    }
}
