using System;
using TechTalk.SpecFlow;
using ApolloQA.Pages.Quote;
using ApolloQA.Source.Driver;
using System.Linq;
using Entity_Quote = ApolloQA.Data.Entity.Quote;
using Entity_Organization = ApolloQA.Data.Entity.Organization;
using ApolloQA.Source.Helpers;
using ApolloQA.Pages;
using ApolloQA.Components;

namespace ApolloQA.StepDefinition.Quote
{
    [Binding]
    public class Quote_CreateSteps
    {
        public string BusinessName = "";
        public string LineOfBusiness = "";
        public string PolicyEffectiveDate = "";
        public string DriverSelected = "";
        public string Checked = "cdk-mouse focused mat-radio checked";
        public Entity_Quote quote;
        public Entity_Organization organization;


        [When(@"user navigates to Quote Page")]
        public void WhenUserNavigatesToQuotePage()
        {
            Log.Debug("Latest quote ID" + Data.Entity.Quote.GetLatestQuote().Id);
            Quote_Home_Page.navigate();
        }

        [When(@"user Selects Business Name as (.*)")]
        public void WhenUserSelectsBusinessNameAs(string business)
        {
            if (business.ToLower() == "random")
            {
                Quote_Create_Page.BusinessName.SelectMatDropdownOptionByIndex(0, out string selectionDisplayName);
                this.BusinessName = selectionDisplayName;
            }
            else if (int.TryParse(business, out int businessIndex))
            {
                Quote_Create_Page.BusinessName.SelectMatDropdownOptionByIndex(businessIndex, out string selectionDisplayName);
                this.BusinessName = selectionDisplayName;
            }
            else
            {
                Quote_Create_Page.BusinessName.SelectMatDropdownOptionByText(business);
                this.BusinessName = business;
            }
        }

        [When(@"user Selects Line of Business as (.*)")]
        public void WhenUserSelectsLineOfBusinessAs(string LOB)
        {
            LineOfBusiness = LOB;
            Quote_Create_Page.LineOfBusiness.SelectMatDropdownOptionByText(LOB);
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

        [Then(@"user should be redirected to the newly created organization")]
        public void WhenUserShouldBeRedirectedToTheNewlyCreatedOrganization()
        {
            Assert.CurrentURLContains("organization");
            this.organization = new Entity_Organization(int.Parse(string.Join("", Functions.GetCurrentURLPath().Where(char.IsDigit))));
        }

        [Then(@"previously created organization should be part of the Business Name Dropdown")]
        public void ThenPreviouslyCreatedOrganizationShouldBePartOfTheBusinessNameDropdown()
        {
            string orgName = this.organization.Name;
            Quote_Create_Page.BusinessName.AssertMatDropdownOptionsContain(orgName);
            WhenUserSelectsBusinessNameAs(orgName);
        }


        [Then(@"A new Quote should successfully be created")]
        public void ThenANewQuoteShouldSuccessfullyBeCreated()
        {
            var toastMessage = Quote_Create_Page.toastMessage.GetInnerText();
            Assert.TextContains(toastMessage, "created");

            quote = new Entity_Quote(int.Parse(string.Join("", toastMessage.Where(Char.IsDigit))));
        }

        [Then(@"User should be redirected to the newly created Quote Business Information Section")]
        public void ThenUserShouldBeRedirectedToTheNewlyCreatedQuote()
        {
            Assert.CurrentURLEquals(Quote_BusinessInformation_Page.GetURL(quote.Id, quote.Storyboard.Sections.Find(it => ((string)it["SectionName"]) == "Business Information").Id));
        }

        [Then(@"Quote header should contain correct values")]
        public void ThenQuoteHeaderShouldContainCorrectValues()
        {
            Quote_Page.GetHeaderField("Quote Number").assertElementIsVisible(120);
            Quote_Page.GetHeaderField("Quote Number").assertElementInnerTextEquals(quote.Id.ToString());
            Quote_Page.GetHeaderField("Business Name").assertElementInnerTextEquals(this.BusinessName);
            Quote_Page.GetHeaderField("Status").assertElementInnerTextEquals("Pre-Submission");
            Quote_Page.GetHeaderField("Effective Date").assertElementInnerTextEquals(this.PolicyEffectiveDate);
            Quote_Page.GetHeaderField("Line of Business").assertElementInnerTextEquals(this.LineOfBusiness);
            Quote_Page.GetHeaderField("Carrier");
            Quote_Page.GetHeaderField("Agency");
            Quote_Page.GetHeaderField("Producer").assertElementInnerTextEquals("Unassigned");

            Log.Info($"Expected: {nameof(BusinessName)}={BusinessName}");
            Log.Info($"Expected: {nameof(LineOfBusiness)}={LineOfBusiness}");
            Log.Info($"Expected: {nameof(PolicyEffectiveDate)}={PolicyEffectiveDate}");
            Log.Warn("Lastly created quote page test to be implemented");
        }

        [When(@"user checks for existing driver")]
        public void WhenUserChecksForExistingDriver()
        {
            try { Quote_Drivers.DriverRecord.assertElementIsVisible(5); }
            catch
            {
                Quote_Drivers.NewDriverButton.Click();
                Quote_Drivers.FirstNameInput.setText("Tester");
                Quote_Drivers.LastName.setText("driver");
                Quote_Drivers.DateOfBirth.setText("04/04/1989");
                Quote_Drivers.DriverLicenseDropdown.SelectMatDropdownOptionByText(" IL ");
                Quote_Drivers.DriverLicenseNumberInput.setText("E11509853027");
                Quote_Drivers.DLExpirationDate.setText("04/04/2029");
                Quote_Drivers.CdlDropdown.SelectMatDropdownOptionByText(" No ");
                //if (Quote_Drivers.DLStateExceptionsNo.assertElementNotPresent() == false)
                //{
                //    Quote_Drivers.DLStateExceptionsNo.Click();
                //}
                Quote_Drivers.ActiveLicenseStatusButton.Click();
                Quote_Drivers.InspectionCountInput.setText("10");
                Quote_Drivers.ExcludeDriverNo.Click();
                var required = Quote_Drivers.ActiveLicenseStatusButton.GetAttribute("class");
                for (var i = 0; i < 8; i++)
                {
                    do
                    {
                        if (required.EndsWith(Checked) == false)
                        {
                            Quote_Drivers.ActiveLicenseStatusButton.Click();
                        }
                    }
                    while (required.EndsWith("ng-star-inserted"));
                }
                Quote_Drivers.SaveDriverButton.Click();
            }
        }

        [Then(@"User verifies collapse all and expand all")]
        public void ThenUserVerifiesCollapseAllAndExpandAll()
        {
            Quote_Drivers.ExpandAllButton.Click();
            Quote_Drivers.ExpandedInfo.assertElementIsVisible();
            Quote_Drivers.CollapseAllButton.Click();
            Quote_Drivers.ExpandedInfo.assertElementNotPresent();
        }
    }
}
