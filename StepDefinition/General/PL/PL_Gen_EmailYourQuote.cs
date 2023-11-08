using BiBerkLOB.Pages.PL;
using BiBerkLOB.Source.Helpers;
using BiBerkLOB.StepDefinition.General.GenAutomation;
using HitachiQA.Driver;
using HitachiQA.Helpers;
using TechTalk.SpecFlow;


namespace BiBerkLOB.StepDefinition.General.PL
{
    [Binding]
    public sealed class PL_Gen_EmailYourQuote
    {
        [Then(@"user verifies the PL Email Your Quote modal appears")]

        public void ThenUserVerifiesThePLEmailYourQuoteModalAppears()
        {
            EmailYourQuoteModal.EmailMyQuoteBttn.Click();
            EmailYourQuoteModal.YourQuoteID.AssertElementIsVisible();
            EmailYourQuoteModal.EmailYourPolicyQuoteHeader.AssertElementIsVisible();
            EmailYourQuoteModal.ChooseYourInsurancePlanHeaader.AssertElementIsVisible();
            EmailYourQuoteModal.StandardPlanCTA.AssertElementIsVisible();
            EmailYourQuoteModal.PlusPlanCTA.AssertElementIsVisible();
            EmailYourQuoteModal.PlusPlan.AssertElementIsVisible();
            EmailYourQuoteModal.PlusPlan.Click();
            EmailYourQuoteModal.EmailAddressQST.AssertElementIsVisible();
            EmailYourQuoteModal.EmailAddressTxtbox.AssertElementIsVisible();
            EmailYourQuoteModal.EmailAddressQST.AssertElementIsVisible();
            EmailYourQuoteModal.EmailYourQuoteCTA.AssertElementIsVisible();
            EmailYourQuoteModal.EmailYourQuoteCTA.Click();
            EmailYourQuoteModal.EmailYourQuoteCTA.AssertElementNotPresent();
        }

        [When(@"user emails their (.*) quote")]
        public void WhenUserEmailsTheirQuote(string quoteType)
        {
            EmailYourQuoteModal.EmailMyQuoteBttn.Click();
            AutomationHelper.ValidateElements(EmailYourQuoteModal.BaseElements);

            SelectQuote(quoteType);

            EmailYourQuoteModal.EmailYourQuoteCTA.Click();
            EmailYourQuoteModal.PolicyEmailedToaster.AssertElementIsVisible();
            EmailYourQuoteModal.PolicyEmailedToaster.AssertElementNotPresent();
        }

        public void SelectQuote(string quoteType) 
        {
            switch (quoteType.ToLower())
            {
                case "standard":
                    AutomationHelper.ValidateElements(EmailYourQuoteModal.StandardElements);
                    EmailYourQuoteModal.StandardPlan.Click();
                    break;
                case "plus":
                    AutomationHelper.ValidateElements(EmailYourQuoteModal.StandardElements);
                    AutomationHelper.ValidateElements(EmailYourQuoteModal.PlusElements);
                    EmailYourQuoteModal.PlusPlan.Click();
                    break;
            }
        }
    }
}