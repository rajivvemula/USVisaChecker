using System;
using TechTalk.SpecFlow;
using ApolloQA.Pages;
using ApolloQA.Source.Driver;
using System.Linq;
using Entity_Quote = ApolloQA.Data.Entity.Quote;
using Entity_Organization = ApolloQA.Data.Entity.Organization;
using ApolloQA.Source.Helpers;
using ApolloQA.Components;
using System.Collections.Generic;

namespace ApolloQA.StepDefinition.Quote
{
    [Binding]
    public class Quote_GeneralSteps
    {
        public string BusinessName = "";
        public string LineOfBusiness = "";
        public string PolicyEffectiveDate = "";
        public Entity_Quote quote;
        public Entity_Organization organization;


        [When(@"user navigates to Quote Page")]
        public void WhenUserNavigatesToQuotePage()
        {
            Quote_Home_Page.navigate();
        }

        [When(@"user Selects Policy Effective Date as (.*)")]
        public void WhenUserSelectsPolicyEffectiveDateAs(string Date)
        {
            if (Date == "Tomorrow")
            {
                Date = DateTime.Now.AddDays(1).ToString("MM/dd/yyyy");
            }
            PolicyEffectiveDate = Date;
            Quote_Create_Page.PolicyEffectiveDate.setText(Date);

        }


        [Then(@"previously created organization should be part of the Business Name Dropdown")]
        public void ThenPreviouslyCreatedOrganizationShouldBePartOfTheBusinessNameDropdown()
        {
            string orgName = this.organization.Name;
            var field = Shared.GetDropdownField("Named Insured");
            field.AssertMatDropdownOptionsContain(orgName);
            field.SelectMatDropdownOptionByText(orgName);

        }


        [Then(@"A new Quote should successfully be created")]
        public void ThenANewQuoteShouldSuccessfullyBeCreated()
        {
            var toastMessage = Quote_Create_Page.toastMessage.GetInnerText();
            Assert.TextContains(toastMessage, "created");

            quote = new Entity_Quote("ApplicationNumber", string.Join("", toastMessage.Where(Char.IsDigit)));
            Functions.MarkTestCasePassed(17022);
            Functions.MarkTestCasePassed(17024);
            Functions.MarkTestCasePassed(17974);

        }

        [Then(@"User should be redirected to the newly created Quote Business Information Section")]
        public void ThenUserShouldBeRedirectedToTheNewlyCreatedQuote()
        {
            Assert.CurrentURLEquals(Quote_BusinessInformation_Page.GetURL(quote.Id, quote.Storyboard.Sections.Find(it => ((string)it["SectionName"]) == "Business Information").Id));

            Functions.MarkTestCasePassed(17027);
        }

        [Then(@"Quote header should contain correct values")]
        public void ThenQuoteHeaderShouldContainCorrectValues()
        {
            Quote_Page.GetHeaderField("Quote Number").assertElementIsVisible(120);
            Quote_Page.GetHeaderField("Quote Number").assertElementInnerTextEquals(quote.ApplicationNumber);
            Quote_Page.GetHeaderField("Business Name").assertElementInnerTextEquals(quote.Organization.Name);
            Quote_Page.GetHeaderField("Status").assertElementInnerTextEquals("Pre-Submission");
            Quote_Page.GetHeaderField("Effective Date").assertElementInnerTextEquals(this.PolicyEffectiveDate);
            Quote_Page.GetHeaderField("Line of Business").assertElementInnerTextEquals("Commercial Auto");
            Quote_Page.GetHeaderField("Carrier");
            Quote_Page.GetHeaderField("Agency");
            //this will be readonly in the future
            //Quote_Page.GetHeaderField("Producer").assertElementInnerTextEquals("Unassigned");

            Log.Info($"Expected: {nameof(BusinessName)}={BusinessName}");
            Log.Info($"Expected: {nameof(LineOfBusiness)}={LineOfBusiness}");
            Log.Info($"Expected: {nameof(PolicyEffectiveDate)}={PolicyEffectiveDate}");

            Functions.MarkTestCasePassed(17028);
        }




        List<String> sortedSectionNames;

        [Then(@"Left Nav Sections should be displayed successfully")]
        public void ThenLeftNavSectionsShouldBeDisplayedAccordingToTheCurrentStoryboard(Table table)
        {
            this.sortedSectionNames = table.Rows.ToList<TableRow>().Select(it => (String)it[0]).ToList<String>();
            Assert.AreEqual(this.sortedSectionNames, Quote_Page.LeftSiveNavBar.GetInnerTexts());

            ScreenShot.Error();
        }

        [Then(@"User should be able to navigate to each section successfully")]
        public void ThenUserShouldBeAbleToNavigateToEachSectionSuccessfully()
        {
            //TODO: Storyboard section missmatch
            foreach (var section in Quote_GeneralSteps.Quote.Storyboard.Sections)
            {
                new SharedSteps().WhenUserWaitsForSpinnerToLoad();
                var sectionCTA = Shared.GetLeftSideTab(section.Name);
                sectionCTA.Click();
                try { Shared.GetButton(" Continue Anyway ").assertElementNotPresent(); }
                catch
                {
                    Shared.GetButton(" Continue Anyway ").Click();
                }
                Assert.CurrentURLEquals(Quote_Page.GetURL(Quote_GeneralSteps.Quote.Id, section.Id));
            }
        }

        public static Entity_Quote Quote;

        [When(@"User Navigates to Quote (.*)")]
        public void GivenUserNavigatesToQuote(string quote)
        {
            if (quote?.ToLower() == "recent" || quote?.ToLower() == "latest")
            {
                Quote = Entity_Quote.GetLatestQuote();
            }
            else
            {
                Quote = new Entity_Quote(int.Parse(quote));
            }
            Quote_Page.Navigate(Quote.Id);
        }


    }
}
