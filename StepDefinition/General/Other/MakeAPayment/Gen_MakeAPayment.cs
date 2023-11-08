using TechTalk.SpecFlow;
using BiBerkLOB.General;
using BiBerkLOB.Pages;
using System.Collections.Generic;
using HitachiQA.Driver;
using BiBerkLOB.StepDefinition.General.GenAutomation;
using BiBerkLOB.Pages.Other.MadLibs;
using BiBerkLOB.Pages.Other.MakeAPayment;

namespace BiBerkLOB.StepDefinition.General.Other.MakeAPayment
{
    [Binding]
    public sealed class Gen_MakeAPayment
    {
        [Given(@"user navigates to the Make a Payment page")]
        public void GivenUserLandedBiBerkHomePageAndUserClicksOnGetAQuoteCTA()
        {
            UserActions.GoHome();
            try
            {
                Reusable_PurchasePath.MobileHamburgerMenu.Click(3);
                Reusable_PurchasePath.MobilePolicyHoldersDD.Click();
                Reusable_PurchasePath.MobileMakeAPayment.Click();
            }
            catch
            {
                Reusable_PurchasePath.PolicyHoldersDD.Click();
                Reusable_PurchasePath.PolicyHoldersTitle.AssertElementIsVisible();
                Reusable_PurchasePath.MakeAPayment.Click();
            }            
        }

        [Then(@"user verifies landing on Make a Payment login page")]
        public void ThenUserVerifyLandGetCOILoginPage()
        {
            ValidateElements(MakeAPaymentLoginPage.MakeAPaymentLoginPageElements);
        }

        public void ValidateElements(List<Element> elements)
        {
            foreach (var element in elements) element.AssertElementIsVisible();
        }
    }
}