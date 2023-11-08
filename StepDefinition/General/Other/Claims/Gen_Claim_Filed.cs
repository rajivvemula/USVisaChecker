using TechTalk.SpecFlow;
using System.Collections.Generic;
using HitachiQA.Driver;
using BiBerkLOB.Pages.Other.Claims;
using HitachiQA.Helpers;

namespace BiBerkLOB.StepDefinition.General.Other.Claims
{
    [Binding]
    public sealed class Gen_Claim_Filed
    {
        [Then(@"user verifies the Claims Submitted page")]
        public void ValidateClaimSubmittedElements()
        {
            AutomationHelper.ValidateElements(ClaimFiledElements);
        }

        [When(@"user clicks on the Submit Claim Button")]
        public void WhenUserClicksOnTheSubmitClaimButton()
        {
            ClaimsPageBase.SubmitClaimsButton.Click();
        }
        [When(@"user clicks on the CA Submit Claim Button")]
        public void WhenUserClicksOnTheCASubmitClaimButton()
        {
            CA_ClaimsPage.CASubmitClaimsButton.Click();
        }

        public static List<Element> ClaimFiledElements => new()
        {
            ClaimSubmittedPage.ClaimHeader,
            ClaimSubmittedPage.ClaimSubheader,
            ClaimSubmittedPage.ContactHeader,
            ClaimSubmittedPage.ContactSubheader,
            ClaimSubmittedPage.ContactPhoneIcon,
            ClaimSubmittedPage.ContactPhone,
            ClaimSubmittedPage.ContactFax,
            ClaimSubmittedPage.ContactHours,
            ClaimSubmittedPage.ContactMailIcon,
            ClaimSubmittedPage.ContactEmail,
            ClaimSubmittedPage.ContactAddress,
        };
    }
}
