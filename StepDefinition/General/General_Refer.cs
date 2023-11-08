using BiBerkLOB.Pages.CommAuto;
using BiBerkLOB.Pages.PL;
using BiBerkLOB.Pages.WC;
using HitachiQA.Driver;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace BiBerkLOB.StepDefinition.General
{
    [Binding]
    public sealed class General_Refer
    {
        [When(@"user fills out the (.*) refer page with these values:")]
        public void WhenUserFillsOutTheReferPageWithTheseValues(string lob, Table table)
        {
            ValidateBasePageElements(lob);
            FillReferPage(lob, table);
            SelectCTA(lob);
        }

        [Then(@"user verifies the appearance of the Refer page due to no LOB")]
        public void ThenUserVerifiesReferForNoLOB(Table table)
        {
            var row = table.Rows[0];

            CA_ReferPage.ThanksForYourInterest.AssertElementIsVisible();
            CA_ReferPage.ThanksForYourInterestParagraph.AssertElementIsVisible();

            CA_ReferPage.NameOfBusiness.AssertElementIsVisible();
            CA_ReferPage.NameOfBusinessTxtbox.SetText(row["Business Name"]);
            CA_ReferPage.NameOfBusinessTextBelow.AssertElementIsVisible();

            CA_ReferPage.DBA.AssertElementIsVisible();
            CA_ReferPage.DBATextBelow.AssertElementIsVisible();
            try { CA_ReferPage.DBATxtbox.SetText(row["DBA"]); }
            //just continue if exception thrown
            catch (Exception) { }
            CA_ReferPage.ContactFirstNameTxtboxOverlay.Click();
            CA_ReferPage.ContactFirstNameTxtbox.SetText(row["First Name"]);
            CA_ReferPage.ContactLastNameTxtboxOverlay.Click();
            CA_ReferPage.ContactLastNameTxtbox.SetText(row["Last Name"]);
            CA_ReferPage.ContactEmailTxtbox.SetText(row["Email"]);
            CA_ReferPage.ContactBusPhoneTxtbox.SetText(row["Phone"]);

            try { CA_ReferPage.ContactBusWebsiteTxtbox.SetText(row["Website"]); }
            //just continue if exception thrown
            catch (Exception) { }
            CA_ReferPage.ContactBusWebsiteTextBelow.AssertElementIsVisible();
            CA_ReferPage.WellBeInTouchCTA.Click();
        }

        private void FillReferPage(string lob, Table table)
        {            
            foreach (var rowy in table.Rows)
            {
                var field = rowy["Field"];
                var value = rowy["Value"];

                switch (lob)
                {
                    case "WC":
                        var wcReferFields = new ReferPageFieldGroup(WC_YourCoverageRequiresPage.ReferFields);
                        wcReferFields.FillReferField(field, value);
                        break;
                    case "PL":
                        var plReferFields = new ReferPageFieldGroup(PL_Referral_Page.ReferFields);
                        plReferFields.FillReferField(field, value);
                        break;
                }
            }
        }

        public void SelectCTA(string lob)
        {
            var CTA = ContinueCTAs.GetValueOrDefault(lob);
            CTA.Click();
        }

        public void ValidateBasePageElements(string lob)
        {
            switch (lob)
            {
                case "WC":
                    ValidateElements(WC_YourCoverageRequiresPage.TitleElements);
                    break;
                case "PL":
                    ValidateElements(PL_Referral_Page.TitleElements);
                    break;
            }
        }

        public void ValidateElements(List<Element> elements) 
        {
            foreach (var element in elements) 
            {
                element.AssertElementIsVisible();
            }
        }

        private Dictionary<string, Element> ContinueCTAs = new Dictionary<string, Element>
            {
                { "WC", WC_YourCoverageRequiresPage.SubmitCTA },
                { "PL", PL_Referral_Page.WellBeInTouchCTA }
            };
    }
}