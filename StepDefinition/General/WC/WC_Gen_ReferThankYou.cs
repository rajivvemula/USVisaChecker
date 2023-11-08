using BiBerkLOB.Pages.WC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace BiBerkLOB.StepDefinition.General.WC
{
    [Binding]
    public class WC_Gen_ReferThankYou
    {
        [Then(@"user verifies the refer thank you page appears")]
        public void UserVerifiesTheReferThankYouPage()
        {
            WC_ReferralThankYouPage.ThankYouHeader.AssertElementIsVisible();
            WC_ReferralThankYouPage.ReceivedInformationText.AssertElementIsVisible();
            WC_ReferralThankYouPage.GoToHomePageBtn.AssertElementIsVisible();

            WC_ReferralThankYouPage.GoToHomePageBtn.Click();
        }
    }
}
