using TechTalk.SpecFlow;
using System.Collections.Generic;
using HitachiQA.Driver;
using BiBerkLOB.Pages.Other;

namespace BiBerkLOB.StepDefinition.General.Other
{
    [Binding]
    public sealed class Gen_ForgotPhoneNumber
    {
        [Then(@"user interacts with Forgot Phone Number modal using (.*)")]
        public void ThenCOIForgotPhoneNumber(string policyId)
        {
            ForgotPhoneNumberModalPage.ForgotPhoneNumberCTA.Click();
            ValidateElements(ForgotPhoneNumberModalPage.ForgotPhoneModal);
            ForgotPhoneNumberModalPage.PolicyNumberPNRTxtBox.SetText(policyId);
            ForgotPhoneNumberModalPage.EmailPhoneNumberCTA_Enabled.Click();

            //verify loading B appearance, disappearance
            ForgotPhoneNumberModalPage.LoadingB.AssertElementIsVisible();
            ForgotPhoneNumberModalPage.LoadingB.AssertElementNotPresent();
            //verify toaster message appearance, disappearance
            ForgotPhoneNumberModalPage.ToasterMsgSuccessful.AssertElementIsVisible();
            ForgotPhoneNumberModalPage.ToasterMsgSuccessful.AssertElementNotPresent();
        }

        public void ValidateElements(List<Element> elements)
        {
            foreach (var element in elements) element.AssertElementIsVisible();
        }
    }
}