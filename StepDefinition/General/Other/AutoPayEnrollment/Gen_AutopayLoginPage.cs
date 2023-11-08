using TechTalk.SpecFlow;
using BiBerkLOB.General;
using BiBerkLOB.Pages;
using System.Collections.Generic;
using HitachiQA.Driver;
using BiBerkLOB.StepDefinition.General.GenAutomation;
using BiBerkLOB.Pages.Other.MadLibs;
using BiBerkLOB.Pages.Other;
using BiBerkLOB.Pages.Other.AutopayEnrollment;

namespace BiBerkLOB.StepDefinition.General.Other.AutoPayEnrollment
{
    [Binding]
    public sealed class Gen_AutopayLoginPage
    {
        [Then(@"user fills in the Autopay Login Page with these values:")]
        public void ThenUserFillsInTheAutopayLoginPageWithTheseValues(Table table)
        {
            var row = table.Rows[0];

            //Autopay page title
            AutopayLoginPage.Autopay.AssertElementIsVisible();

            //Autopay Enrollment header and text
            AutopayLoginPage.AutopayEnrollment.AssertElementIsVisible();
            AutopayLoginPage.AutopayEnrollmentText.AssertElementIsVisible();

            //Policy Number
            AutopayLoginPage.PolicyNumber.AssertElementIsVisible();
            AutopayLoginPage.PolicyNumberInput.SetText(row["Policy Number"]);

            //Phone Num
            AutopayLoginPage.PhoneNum.AssertElementIsVisible();
            AutopayLoginPage.PhoneNumInput.SetText(row["Phone"]);
          
            AutopayLoginPage.Continue_BTN.Click();
        }
    }
}