using BiBerkLOB.Pages;
using BiBerkLOB.StepDefinition.General;
using HitachiQA.Driver;
using System.Linq;
using BiBerkLOB.Source.Helpers;
using BiBerkLOB.StepDefinition.General.GenAutomation;
using TechTalk.SpecFlow;
using BiBerkLOB.Pages.PL;
using HitachiQA;
using HitachiQA.Helpers;
using OpenQA.Selenium.DevTools.V85.Database;
using System;
using BiBerkLOB.Pages.Other.MadLibs;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BiBerkLOB.Source.Helpers.LegacyModels;

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
        [Then(@"user clears the cache of the webpage")]
        public void ThenUserClearsTheCacheOfTheWebpage()
        {
            UserActions.Navigate("/MUNCH");
            ClearCacheMunchPage.MunchTitle.AssertElementIsVisible();
            ClearCacheMunchPage.returnToHomePageButton.Click();
        }

        [Given(@"user lands on biBerk Home page")]
        public void GivenUserLandedBiBerkHomePageAndUserClicksOnGetAQuoteCTA()
        {
            UserActions.GoHome();
            HomePage.Logo.AssertElementIsVisible();
        }

        [Given(@"user lands biBerk Home page and clicks on Get a Quote")]
        public void GivenUserLandsOnHomePageAndUserClicksOnGetAQuoteCTA()
        {
            UserActions.GoHome();
            HomePage.QuoteCTA.Click();
        }

        [Given(@"user starts a quote with:")]
        public void GivenUserStartsQuote(Table table)
        {
            _madLibsAutomation.RecViewContext.RecommendationView.NavigateToLandingPage();

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

        [Then(@"user verifies confirmation popup is displayed")]
        public void VerifyPopUpIsVisible(Table table)
        {
            var row = table.Rows[0];
            var text = row["Text"];
            switch (text)
            {
                case "We emailed you a link to your saved application.":
                    PL_BusinessDetailsPage.EmailConfirmationPopUpByText(text).AssertElementIsVisible();
                    break;
                default:
                    break;
            }
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

        [Then(@"user verifies the following title for the Landing Page: (.*)")]
        public void ThenUserVerifiesTheFollowingTitleForTheLandingPage(string title)
        {
            Assert.IsTrue(HowManyEmpPage.PageHeader.GetElementText().Equals(title));
        }

        [Then(@"user should see a 404 page")]
        public void ThenUserShouldSeeAPage()
        {
            Reusable_PurchasePath.Error404.AssertElementIsVisible();
        }

        [When(@"user responds with (.*) to the over 1000 employees modal")]
        public void WhenUserRespondsWithToTheOverEmployeesModal(string decision)
        {
            WhereDoesYourBusPage.WhereDoesYourBusQst.AssertElementIsVisible();
            HowManyEmpPage.BackCTA.Click();
            HowManyEmpPage.HowManyEmpDoYouHaveTxtbox.SetText(MadLibsSummaryObject.NoOfEmp.ToString());
            HowManyEmpPage.NextCTA.Click();
            HowManyEmpPage.Over1000EmployeesModal.AssertAllElements();
            HowManyEmpPage.Over1000EmployeesModal.EnterResponse(decision);
        }

        [Then(@"the madlibs location screen will appear")]
        public void ThenTheMadlibsLocationScreenWillAppear()
        {
            WhereDoesYourBusPage.WhereDoesYourBusQst.AssertElementIsVisible();
        }

        [Then(@"the over 1000 employees modal will be closed")]
        public void ThenTheOverEmployeesModalWillBeClosed()
        {
            HowManyEmpPage.Over1000EmployeesQuestion.AssertElementNotPresent();
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