using BiBerkLOB.Pages;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation.Factories;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation;
using HitachiQA.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using BiBerkLOB.Pages.CommAuto;
using HitachiQA.Driver;

namespace BiBerkLOB.StepDefinition.General.CommAuto
{
    [Binding]
    public sealed class CA_Gen_ReducedFooter
    {
        [Then(@"user verifies the elements present in footer section")]
        public void ThenUserVerifiesFooterElements()
        {
            AutomationHelper.ValidateElements(new List<Element>
            {
                Reusable_PurchasePath.Footer_PrivacyPolicy,
                Reusable_PurchasePath.Footer_TermsConditions,
                Reusable_PurchasePath.Footer_OtherDisclosures,
                Reusable_PurchasePath.Footer_ReviewStars,
                Reusable_PurchasePath.Footer_Rating,
                Reusable_PurchasePath.Footer_Copyright,
                Reusable_PurchasePath.Footer_LinkBBB,
                Reusable_PurchasePath.Footer_RatingBBB,
            });
        }
    }
}