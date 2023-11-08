using TechTalk.SpecFlow;
using BiBerkLOB.General;
using BiBerkLOB.Pages;
using System.Collections.Generic;
using HitachiQA.Driver;
using BiBerkLOB.StepDefinition.General.GenAutomation;
using BiBerkLOB.Pages.Other.MadLibs;
using BiBerkLOB.Pages.Other;

namespace BiBerkLOB.StepDefinition.General.Other.COI
{
    [Binding]
    public sealed class Gen_COI_InitialPage
    {
        [Then(@"user fills in the COI Page with these values:")]
        public void ThenUserFillsInTheCOIPageWithTheseValues(Table table)
        {
            var row = table.Rows[0];
            
            // Certificate of Insurance (COI)
            GetCertificateInsuranceLoginPage.PageTitleCOI.AssertElementIsVisible();
            
            //Get a Certificate of Insurance
            GetCertificateInsuranceLoginPage.GetCertfOfInsuranceTitle.AssertElementIsVisible();
            GetCertificateInsuranceLoginPage.GetCertfOfInsuranceParagraph.AssertElementIsVisible();
            
            //Policy Number
            GetCertificateInsuranceLoginPage.PolicyNumber.AssertElementIsVisible();
            GetCertificateInsuranceLoginPage.PolicyNumberTxtBox.SetText(row["Policy Number"]);

            //Phone
            GetCertificateInsuranceLoginPage.Phone.AssertElementIsVisible();
            GetCertificateInsuranceLoginPage.PhoneTxtBox.SetText(row["Phone"]);
            ForgotPhoneNumberModalPage.ForgotPhoneNumberCTA.AssertElementIsVisible();

            GetCertificateInsuranceLoginPage.ContinueCTA.Click();
        }
    }
}