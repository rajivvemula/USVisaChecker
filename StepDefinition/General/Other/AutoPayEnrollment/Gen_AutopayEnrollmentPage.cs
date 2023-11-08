using BiBerkLOB.Pages.Other.AutopayEnrollment;
using System.Threading;
using BiBerkLOB.Pages.WC;
using DocumentFormat.OpenXml.Office.CustomUI;
using HitachiQA.Driver;
using HitachiQA.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Interactions;
using TechTalk.SpecFlow.Assist;

namespace BiBerkLOB.StepDefinition.General.Other.AutoPayEnrollment    
{
    [Binding]
    public class Gen_AutopayEnrollmentPage
    {
        [Then(@"user verifies the appearance of the Enrollment page")]
        public void ThenUserVerifiesTheAppearanceOfTheEnrollmentPage()
        {
            foreach (var element in AutopayEntrollmentPage.AutopayEnrollmentMainElements)
            {
                element.AssertElementIsVisible();
            }
        }

        [Then(@"user fills out the payment information with these values:")]
        public void ThenUserFillsOutThePaymentInformationWithTheseValues(Table table)
        {
            foreach (TableRow rowy in table.Rows)
            {
                var theField = rowy["Field"];
                var theValue = rowy["Value"];

                HandleTableValue(theField, theValue);
            }

            AutopayEntrollmentPage.AgreeToTerms_Checkbox.ClickHack();
            AutopayEntrollmentPage.UpdateAutopay_BTN.Click();
        }        

        [Then(@"user selects a Credit Card payment plan")]
        public void ThenUserSelectsACreditCardPaymentPlan()
        {
            AutopayEntrollmentPage.Credit_BTN.Click();
        }        

        [Then(@"user selects a Direct Draft payment plan")]
        public void ThenUserSelectsADirectDraftPaymentPlan()
        {
            AutopayEntrollmentPage.DirectDraft_BTN.Click();
        }
                
        [Then(@"user selects the (.*) account option")]
        public void ThenUserSelectsTheAccountOption(string accountType)
        {
            switch (accountType)
            {
                case "Checking":
                    AutopayEntrollmentPage.Checking_BTN.Click();
                break;
                case "Savings":
                    AutopayEntrollmentPage.Savings_BTN.Click();
                break;
            }
        }

        [Then(@"verifies the appearance of the Credit Card Autopay Enrollment")]
        public void ThenVerifiesTheAppearanceOfTheCreditCardAutopayEnrollment()
        {
           foreach (var element in AutopayEntrollmentPage.AutopayCCEnrollmentEelements)
            {
                element.AssertElementIsVisible();
            }
        }

        [Then(@"verifies the appearance of the Direct Draft Autopay Enrollment")]
        public void ThenVerifiesTheAppearanceOfTheDirectDraftAutopayEnrollment()
        {
            foreach (var element in AutopayEntrollmentPage.AutopayDDEnrollmentElements)
            {
                element.AssertElementIsVisible();
            }
        }        

        [Then(@"user verifies the Autopay Payment Completed page")]
        public void ThenUserVerifiesTheAutopayPaymentCompletedPage()
        {
            AutopayComplete.AutopayEnrollmentCompleted.AssertElementIsVisible();
            AutopayComplete.EnrollmentCompletedText.AssertElementIsVisible();
        }

        public void HandleTableValue(string tableQuestion, string tableAnswer)
        {
            switch (tableQuestion)
            {
                case "CC Name":
                    AutopayEntrollmentPage.YourName.AssertElementIsVisible();
                    AutopayEntrollmentPage.YourName.SetText(tableAnswer);                    
                    break;
                case "CC Number":
                    AutopayEntrollmentPage.CCNumber.AssertElementIsVisible();
                    AutopayEntrollmentPage.CCNumber.SetText(tableAnswer);                    
                    break;
                case "CC Expiration Date":
                    AutopayEntrollmentPage.CCYear.AssertElementIsVisible();
                    AutopayEntrollmentPage.CCYear.SetText(tableAnswer);                        
                    break;
               case "Account Number":
                    AutopayEntrollmentPage.BankAccNumInput.AssertElementIsVisible();
                    AutopayEntrollmentPage.BankAccNumInput.SetText(tableAnswer);
                    break;
                case "Routing Number":
                    AutopayEntrollmentPage.BankRoutingInput.AssertElementIsVisible();
                    AutopayEntrollmentPage.BankRoutingInput.SetText(tableAnswer);
                    break;
            }
        }
    }
}
