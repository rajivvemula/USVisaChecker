using BiBerkLOB.Pages.CommAuto;
using HitachiQA;
using HitachiQA.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using BiBerkLOB.Source.Helpers;
using TechTalk.SpecFlow;

namespace BiBerkLOB.StepDefinition.General.CommAuto
{
    [Binding]
    public class CA_Gen_ThankYou
    {
        Regex checkPolicyIdFormat = new Regex("[0-9]{7}-[0-9]{2}-CA");
        Regex getNextPaymentDate = new Regex("[0-9]{2}/[0-9]{2}/[0-9]{4}");
        Regex getPaymentAmount = new Regex("[0-9,.]*[0-9]{2}");
        string UIPaymentPlanChosen;
        
        private readonly CASummaryObject _caSummaryObject;
        
        public CA_Gen_ThankYou(CASummaryObject caSummaryObject)
        {
            _caSummaryObject = caSummaryObject;
        }

        [Then(@"user verifies the Thank You Page")]
        public void UserVerifiesThankYouPage()
        {
            CA_ThankYouPage.ThankYouTitle.AssertElementIsVisible();
            CA_ThankYouPage.ThankYouParagraph.AssertElementIsVisible();
            CA_ThankYouPage.PolicyHeader.AssertElementIsVisible();

            //verify the CA policy id formatting is #######-##-CA
            CA_ThankYouPage.PolicyId.AssertElementIsVisible();
            checkPolicyIdFormat.IsMatch(CA_ThankYouPage.PolicyId.GetInnerText());

            CA_ThankYouPage.CompanyName.AssertElementIsVisible();
            CA_ThankYouPage.PolicyStartsOnWithXTimeOfCoverage.AssertElementIsVisible();
            CA_ThankYouPage.PaymentTermsTitle.AssertElementIsVisible();
            CA_ThankYouPage.PaymentTermsAmount.AssertElementIsVisible();

            //verify that Monthly/Year payment plan that was chosen earlier is appearing
            CA_ThankYouPage.PaymentTermsFrequency.AssertElementIsVisible();
            var uipaymentPlan = CA_ThankYouPage.PaymentTermsFrequency.GetInnerText();
            if (uipaymentPlan.Contains("Year")) {
                Assert.AreEqual("Yearly", _caSummaryObject.PaymentPlanChosen);
                UIPaymentPlanChosen = "Yearly";
            }
            else {
                Assert.AreEqual("Monthly", _caSummaryObject.PaymentPlanChosen);
                UIPaymentPlanChosen = "Monthly";
            }

            //verify that the amount paid today shown on the Thank You page was actually the amount paid
            CA_ThankYouPage.PaymentMadeTodayInfo.AssertElementIsVisible();
            var uiAmountPaid = CA_ThankYouPage.PaymentMadeTodayInfo.GetInnerText();
            var uiAmountPaidMatch = getPaymentAmount.Match(uiAmountPaid);
            var uiDecimalAmountPaid = Convert.ToDecimal(uiAmountPaidMatch.Value);
            Assert.AreEqual(uiDecimalAmountPaid, _caSummaryObject.PaymentAmountMadeToday);

            //if a monthly payment plan was chosen, you'll see the date the next payment is due
            if (UIPaymentPlanChosen.Equals("Yearly"))
            {
                CA_ThankYouPage.NextPaymentDueInfo.AssertElementNotPresent();
            }
            else
            {
                //find out when the UI says the next payment is due
                CA_ThankYouPage.NextPaymentDueInfo.AssertElementIsVisible();
                var uiNextPayment = getNextPaymentDate.Match(CA_ThankYouPage.NextPaymentDueInfo.GetInnerText());

                //get the date of today plus a month and a day, that is when the next payment is due
                var tomorrow = Functions.GetDifferentDateFromNow(1, "D");
                var monthFromTomorrow = Functions.GetDifferentDateFrom(tomorrow, 1, "M");

                Assert.AreEqual(uiNextPayment.Value, monthFromTomorrow.ToString("MM/dd/yyyy"));
            }        
            
            CA_ThankYouPage.CopyOfPolicyMailedToYou.AssertElementIsVisible();
            CA_ThankYouPage.TitleMakeSureBusFullCovered.AssertElementIsVisible();
        }

        [Then(@"user verifies the WC section on the Thank You page")]
        public void UserVerifyWCOnThankYou()
        {
            CA_ThankYouPage.WorkersCompAccordianCTA.AssertElementIsVisible();
            //try to click the CLOSED accordian, if it doesn't work, will just move on
            CA_ThankYouPage.WorkersCompAccordianCTA_Closed.TryClick(3);
            CA_ThankYouPage.WCWhatIsIt.AssertElementIsVisible();
            CA_ThankYouPage.WCWhyGetIt.AssertElementIsVisible();
            CA_ThankYouPage.GetWCCTA.AssertElementIsVisible();
        }

        [Then(@"user verifies the GL section on the Thank You page")]
        public void UserVerifyGLOnThankYou()
        {
            CA_ThankYouPage.GeneralLibAccordianCTA.AssertElementIsVisible();
            CA_ThankYouPage.GeneralLibAccordianCTA.Click();
            CA_ThankYouPage.GLWhatIsIt.AssertElementIsVisible();
            CA_ThankYouPage.GLWhyGetIt.AssertElementIsVisible();
            CA_ThankYouPage.GLExample.AssertElementIsVisible();
            CA_ThankYouPage.GetGeneralLibCTA.AssertElementIsVisible();
        }

        [Then(@"user verifies the PL section on the Thank You page")]
        public void UserVerifyPLOnThankYou()
        {
            CA_ThankYouPage.ProfessionalLibAccordianCTA_Closed.TryClick(3);
            CA_ThankYouPage.ProfessionalLibAccordianCTA.AssertElementIsVisible();
            CA_ThankYouPage.PLWhatIsIt.AssertElementIsVisible();
            CA_ThankYouPage.PLWhyGetIt.AssertElementIsVisible();
            CA_ThankYouPage.PLExample.AssertElementIsVisible();
            CA_ThankYouPage.GetProfessionalLibCTA.AssertElementIsVisible();
        }

        [Then(@"user verifies the BOP section on the Thank You page")]
        public void UserVerifyBOPOnThankYou()
        {
            CA_ThankYouPage.PropertyAndLibAccordianCTA_Closed.TryClick(3);
            CA_ThankYouPage.PropertyAndLibAccordianCTA.AssertElementIsVisible();
            CA_ThankYouPage.BOPWhatIsIt.AssertElementIsVisible();
            CA_ThankYouPage.BOPWhyGetIt.AssertElementIsVisible();
            CA_ThankYouPage.BOPExample.AssertElementIsVisible();
            CA_ThankYouPage.GetPropertyAndLibCTA.AssertElementIsVisible();
        }
    }
}
