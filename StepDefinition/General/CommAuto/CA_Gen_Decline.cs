using ApolloQA.Source.Helpers;
using BiBerkLOB.Pages;
using BiBerkLOB.Pages.CommAuto;
using HitachiQA;
using HitachiQA.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using TechTalk.SpecFlow;

namespace BiBerkLOB.StepDefinition.General.CommAuto
{
    [Binding]
    public sealed class CA_Gen_Decline
    {
        [Then(@"user verifies the appearance of the Decline (for keyword) page")]
        public void ThenUserVerifiesDeclineForKeywordPage()
        {
            CA_DeclinePage.ThankYouForInterest.AssertElementIsVisible();
            CA_DeclinePage.ThankYouForInterestParagraph.AssertElementIsVisible();
        }



        [Then(@"user verifies the appearance of the Decline page")]
        public void ThenUserVerifiesDeclinePage()
        {
            CA_DeclinePage.PhoneNumber.AssertElementIsVisible();

            //check decline page title and paragraphs
            CA_DeclinePage.CoverageDeclinedTitle.AssertElementIsPresent();
            CA_DeclinePage.UnfortunatelyNotOfferCommercialAutoIns.AssertElementIsPresent();
            CA_DeclinePage.ForQuestionsOrGiveFeedback.AssertElementIsPresent();

            CA_DeclinePage.CAQuoteID_Decline.AssertElementIsVisible();

            //check that there is a quote number after the first part of the element
            string value = CA_DeclinePage.CAQuoteID_Decline.GetAttribute("innerText");
            Regex rgx = new Regex("[A-z ]*: [0-9]*");
            Assert.IsTrue(rgx.IsMatch(value));

        }    


            
    }
}
