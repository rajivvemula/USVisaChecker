using TechTalk.SpecFlow;
using BiBerkLOB.Pages;
using HitachiQA.Driver;
using BiBerkLOB.StepDefinition.General.GenAutomation;
using System.Linq;
using BiBerkLOB.Pages.Other.COI;
using BiBerkLOB.Source.Helpers;
using HitachiQA.Helpers;
using BiBerkLOB.Pages.PartnersPage;
using BiBerkLOB.Pages.PL;
using BiBerkLOB.StepDefinition.General.PL.Automation;
using DocumentFormat.OpenXml.Bibliography;

namespace BiBerkLOB.StepDefinition.General.Other.Partners
{
    [Binding]
    public sealed class Partners
    {
        [Then(@"user verifies the Partners page")]
        public void ThenUserVerifyPartnersPage()
        {
            foreach (var element in PartnersPage.PartnersElements)
            {
                element.AssertElementIsVisible();
            }
        }
               
        [Then(@"user fills out the Patrners Contact form with the following values:")]
        public void UserPartnerDetailFill(Table table)
        {
            foreach (TableRow rowy in table.Rows)
            {
                var theQuestion = rowy["Question"];
                var theAnswer = rowy["Answer"];
                HandlePartnerDetails(theQuestion, theAnswer);
            }
            PartnersPage.ContactBiberk_BTN.Click();
        }

        private void HandlePartnerDetails(string theQuestion, string theAnswer)
        {
            switch (theQuestion)
            {
                case "First Name":
                    PartnersPage.ContactName.AssertElementIsVisible();
                    PartnersPage.ContactFirstName.SetText(theAnswer);
                    break;
                case "Last Name":
                    PartnersPage.ContactLastName.SetText(theAnswer);
                    break;
                case "Company":
                    PartnersPage.Company.AssertElementIsVisible();
                    PartnersPage.CompanyInput.SetText(theAnswer);
                    break;
                case "Email":
                    PartnersPage.Email.AssertElementIsVisible();
                    PartnersPage.EmailInput.SetText(theAnswer);
                    break;
                case "Phone":
                    PartnersPage.Phone.AssertElementIsVisible();
                    PartnersPage.PhoneInput.SetText(theAnswer);
                    break;
            }
        }
    }
}