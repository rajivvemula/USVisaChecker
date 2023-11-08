using BiBerkLOB.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HitachiQA;
using TechTalk.SpecFlow;

namespace BiBerkLOB.General
{
    [Binding]
    public sealed class General_ResultOfDeclineOrRefer
    {
        //For Referral
        [Given(@"user lands on Referred details and user verifies title")]
        public void ThenUserLandsReferredDetailsAndUserVerifiesTitle()
        {
            ReferredPage.CoverageRequiresAttention.AssertElementIsVisible();
            ReferredPage.PleaseContactUs.AssertElementIsVisible();
        }

        //For Referral
        [Given(@"user verifies business information details")]
        public void ThenUserVerifiesBusinessInformationDeatils()
        {
            Log.Info(ReferredPage.BusinessName.GetAttribute("value"));
            Log.Info(ReferredPage.DoingBusiness.GetAttribute("value"));
            Log.Info(ReferredPage.FirstName.GetAttribute("value"));
            Log.Info(ReferredPage.LastName.GetAttribute("value"));
            Log.Info(ReferredPage.Email.GetAttribute("value"));
            Log.Info(ReferredPage.ContactPhone.GetAttribute("value"));
            Log.Info(ReferredPage.BusinessWebsite.GetAttribute("value"));
        }

        //For Referral
        [Given(@"user clicks on Submit CTA from the Referred page")]
        public void ThenUserClicksOnSubmitCTAFromTheReferredPage()
        {
            ReferredPage.SubmitCTA.Click();
        }

        //For Referral
        [Given(@"user lands We've received your information and will contact you shortly\.")]
        public void GivenUserLandsWeVeReceivedYourInformationAndWillContactYouShortly_()
        {
            ReferredPage.ReceivedYourInformation.AssertElementIsVisible();
        }

        //Navigate back to home page
        [Given(@"user clicks on Go To Homepage CTA")]
        public void GivenUserClicksOnGoToHomepageCTA()
        {
            ReferredPage.GoToHomepageCTA.Click();
        }

        //Navigate back to home page
        [Then(@"user lands biBerk Home page")]
        public void ThenUserLandsBiBerkHomePage()
        {
            Reusable_PurchasePath.Logo.AssertElementIsVisible();
        }

        //For Decline
        [Given(@"user lands on the We are sorry page")]
        public void GivenUserLandsWeAreSorryPage()
        {
            DeclinePage.WeAreSorry.AssertElementIsVisible();
            DeclinePage.Text1.AssertElementIsVisible();
        }


    }
}
