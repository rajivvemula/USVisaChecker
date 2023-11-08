using TechTalk.SpecFlow;
using BiBerkLOB.Pages.CommAuto;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation.Factories;
using HitachiQA.Driver;

namespace BiBerkLOB.StepDefinition.General.CommAuto
{
    [Binding]
    public sealed class CA_Gen_CoverageDetails
    {
        private readonly CACoverageDetailsAutomation _automation;

        public CA_Gen_CoverageDetails(CACoverageDetailsAutomationFactory factory)
        {
            _automation = factory.CreateAutomation();
        }

        [When(@"user opens the Quote Details Page")]
        public void WhenUserOpensTheQuoteDetailsPage()
        {
            CA_QuoteSummaryPage.ViewCoverageDetailsCTA.Click();
        }

        [Then(@"user verifies the coverage details")]
        public void ThenUserVerifyQuoteDetails(Table table)
        {
            CA_QuoteSummaryPage.ViewCoverageDetailsCTA.Click();

            _automation.VerifyPageHeader();
            _automation.VerifyPolicyStartDateInTitle();

            //test leaving and coming back to this page
            _automation.LeaveThenReEnterDetails();

            //Coverages Section
            _automation.VerifyCoverageSection();

            //Drivers Section
            _automation.VerifyDriversSection();

            //Other Coverages Not Selected Section
            _automation.VerifyNotSelectedCoverages(table);

            //Risks Not Covered by Commercial Auto Insurance
            _automation.VerifyRisksNotCovered();

            //Benefits
            _automation.VerifyBenefits();

            //Premium
            _automation.VerifyPremiums();

            //Part of Berkshire Hathaway
            _automation.VerifyLegalStuff();

            //Return to Quote, Back to Coverage Details, Get Plan (goes onto Purchase Page)
            _automation.TestFooterReturnButton();
        }

        [Then(@"user clicks Get Plan from coverage details page")]
        public void ThenUserContinues()
        {
            _automation.ClickContinue();
        }

        [Then(@"user verifies that the terms link displays the terms in a new tab when selected")]
        public void ThenUserVerifiesThatTheTermsLinkDisplaysTheTermsInANewTabWhenSelected()
        {
            _automation.TestTermsAndConditionsInNewTab();
        }

        [Then(@"user verifies the sticky footer buttons on the Covoverage Details page")]
        public void ThenUserVerifiesTheStickyFooterButtonsOnTheCovoverageDetailsPage()
        {
            CA_QuoteSummaryPage.ViewCoverageDetailsCTA.Click();

            //Bumping down a bit till we find the footer elements
            while (CA_CoverageDetailsPage.FooterReturnToQuoteCTA.GetCountOfElements() == 0
                    && CA_CoverageDetailsPage.GetPlanCTA.GetCountOfElements() == 0
                    && !UserActions.HasReachedPageEnd())
            {
                UserActions.BumpScreenDownABit();
            }

            //Scroll down and verify footer elements till the end of page is reached
            while (!UserActions.HasReachedPageEnd())
            {
                CA_CoverageDetailsPage.FooterReturnToQuoteCTA.AssertIsElementVisibleInViewport();
                CA_CoverageDetailsPage.GetPlanCTA.AssertIsElementVisibleInViewport();

                UserActions.BumpScreenDownABit();
            }
        }
    }
}