using System;
using System.Linq;
using System.Threading.Tasks;
using BiBerkLOB.Pages;
using BiBerkLOB.Pages.Other.MadLibs;
using BiBerkLOB.Source.Helpers;
using BiBerkLOB.StepDefinition.General;
using BiBerkLOB.StepDefinition.General.GenAutomation;
using HitachiQA;
using HitachiQA.Driver;
using HitachiQA.Helpers;
using TechTalk.SpecFlow;

namespace BiBerkLOB.General
{
    [Binding]
    public sealed class GeneralInfoSteps
    {
        private readonly MadLibsAutomation _madLibsAutomation;
        public MadLibsSummaryObject MadLibsSummaryObject { get; set; }

        private LegacyPolicyApiHelper legacyPolicyApiHelper { get; set; }

        private string policyCode;
        private string phoneNumber;
        private bool isHomeBusiness = false;

        public GeneralInfoSteps(MadLibsAutomationFactory factory, MadLibsSummaryObject madLibsSummaryObject)
        {
            _madLibsAutomation = factory.CreateAutomation();
            MadLibsSummaryObject = madLibsSummaryObject;
        }

        /*
        * Functional Steps--------------------------------------------------------------------------------------
        */

        [Given(@"user starts a quote with:")]
        public void GivenUserStartsQuote(Table table)
        {
            //_madLibsAutomation.RecViewContext.RecommendationView.NavigateToLandingPage();

            General_SiteWide.AssertUrlSegmentWithCorrectHost(AppSettings.GetAQuoteUrlBaseSegment);
            AutomationHelper.WaitForAngularAppToRender();
            AutomationHelper.WaitForLoading();

            GetTableAndEnterQuoteInfo(table);
        }

        [Given(@"user starts a quote on the Landing Page with:")]
        public void GivenUserStartsAQuoteOnTheLandingPage(Table table)
        {
            GetTableAndEnterQuoteInfo(table);
        }

        [Given(@"user has navigated to the following Landing Page URL to get the quote: (.*)")]
        [Given(@"user has navigated to the following URL within the host environment: (.*)")]
        public void GivenUserHasNavigatedToTheFollowingURLWithinTheHostEnvironment(string url)
        {
            UserActions.Navigate(url);
        }

        [Then(@"user will land on madlibs path with recommendation view as (.*) and '([^']*)' LOB as '([^']*)'")]
        public void ThenUserWillLandOnMadlibsPathWithRecommendationViewAsAndLOBAs(string view, string availability, string lob)
        {
            _madLibsAutomation.VerifyMadlibsPathWithRecommendationViewByLOB(view, availability, lob);
        }

        [Then(@"user should see a 404 page")]
        public void ThenUserShouldSeeAPage()
        {
            Reusable_PurchasePath.Error404.AssertElementIsVisible();
        }

        [Then(@"user waits for the app to finish loading")]
        public void ThenUserWaitsForTheAppToFinishLoading()
        {
            AutomationHelper.WaitForLoading();
        }

        [Then(@"user waits for the app to finish legacy loading")]
        public void ThenUserWaitsForTheAppToFinishLegacyLoading()
        {
            AutomationHelper.LegacyWaitForLoading();
        }

        [Then(@"user verifies that the (.*) industry is not in the list of available industries")]
        public void ThenUserVerifiesThatTheIndustryIsNotInTheListOfAvailableIndustries(string industry)
        {
            Assert.IsTrue(_madLibsAutomation.IsIndustryDiscontinued(industry));
        }

        public void GetTableAndEnterQuoteInfo(Table table)
        {
            foreach (TableRow tableRow in table.Rows)
            {
                var countOfColumns = tableRow.Count;
                var tableHeaders = tableRow.Keys.ToList();
                for (int i = 0; i < countOfColumns; i++)
                {
                    //get the Value of the Table header AND value
                    var quoteTableQuestion = tableHeaders[i];
                    var quoteTableAnswer = tableRow[i];

                    EnterQuoteInfo(quoteTableQuestion, quoteTableAnswer);
                    AutomationHelper.WaitForLoading();
                }
            }
        }

        //For invalid idustry input "Other Industry" value is used 
        //When original industry input can't be found then the Description is used to progress to PP
        public void EnterQuoteInfo(string quoteTableQuestion, string quoteTableAnswer)
        {
            switch (quoteTableQuestion)
            {
                case "Industry":
                    _madLibsAutomation.SelectIndustry(quoteTableAnswer);
                    break;
                case "Other Industry":
                    _madLibsAutomation.EnterCustomIndustry(quoteTableAnswer);
                    break;
                case "Other Industry 2":
                    _madLibsAutomation.EnterCustomSecondIndustry(quoteTableAnswer);
                    break;
                case "Description":
                    _madLibsAutomation.EnterCustomIndustryDescription(quoteTableAnswer);
                    break;
                case "Employees":
                    _madLibsAutomation.SelectNumberOfEmployees(quoteTableAnswer);
                    break;
                case "Location":
                    _madLibsAutomation.SelectBusinessOperationLocation(quoteTableAnswer);
                    break;
                case "Client Home":
                    if (!quoteTableAnswer.Equals(""))
                    {
                        isHomeBusiness = true;
                        _madLibsAutomation.SpecifyIfClientVisitsHomeYesOrNo(quoteTableAnswer);
                    }
                    break;
                case "Own or Lease":
                    _madLibsAutomation.ChooseOwnOrLeasedProperty(quoteTableAnswer);
                    break;
                case "ZIP Code":
                    _madLibsAutomation.EnterZipCode(quoteTableAnswer);
                    break;
                case "LOB":
                    if (isHomeBusiness == true)
                    {
                        try
                        {
                            //verify PL is present
                            PieChartBackupPage.PLOfferedCTA.AssertElementIsVisible();
                        }
                        catch
                        {
                            throw new Exception("PL must be present for at home business");
                        }

                    }
                    _madLibsAutomation.SelectLOB(quoteTableAnswer);

                    break;

                default:
                    break;
            }
        }

        [Then(@"user gets past due policy information where LOB is ([^']*)")]
        public async Task UserGetsPastDuePolicyFromApi(string lob)
        {
            var policyPastDue = await LegacyPolicyApiHelper.GetPolicyCurrentAndPastDueExist(lob, true);

            phoneNumber = policyPastDue.BusinessPhone;
            policyCode = policyPastDue.PolicyCode;
        }
        [Then(@"user gets policy total information where LOB is ([^']*)")]
        public async Task UserGetsPolicyTotalDueFromApi(string lob)
        {
            var policyTotalDue = await LegacyPolicyApiHelper.GetPolicyCurrentEqualsTotalDue(lob, true);

            phoneNumber = policyTotalDue.BusinessPhone;
            policyCode = policyTotalDue.PolicyCode;
        }
        [Then(@"user gets policy ready for renewal information where LOB is ([^']*)")]
        public async Task UserGetsPolicyReadyForRenewalFromApi(string lob)
        {
            var policyReadyForRenewal = await LegacyPolicyApiHelper.GetPolicyReadyForRenewal(lob, true);

            phoneNumber = policyReadyForRenewal.BusinessPhone;
            policyCode = policyReadyForRenewal.PolicyCode;
        }
        [Then(@"user gets policy audit path")]
        public async Task UserGetsPolicyAuditPathFromApi()
        {
            var policyAuditPath = await LegacyPolicyApiHelper.GetPolicyAbleToEnterAuditPath(true);


            phoneNumber = policyAuditPath.BusinessPhone;
            policyCode = policyAuditPath.PolicyCode;
        }
        [Then(@"user navigates to the careers page")]
        public void UserNavigatesToCareersPage()
        {
            Reusable_PurchasePath.Footer_Careers.AssertElementIsVisible();
            Reusable_PurchasePath.Footer_Careers.Click();
        }

    }
}