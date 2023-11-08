using BiBerkLOB.Pages.CommAuto;
using BiBerkLOB.Pages.PL;
using BiBerkLOB.Pages.WC;
using HitachiQA;
using HitachiQA.Driver;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using BiBerkLOB.Pages.Other.MadLibs;
using BiBerkLOB.Pages;
using HitachiQA.Helpers;

namespace BiBerkLOB.StepDefinition.General
{
    [Binding]
    public sealed class General_Decline
    {
        [Then(@"user verifies the (.*) decline page appearance")]
        public void ThenUserVerifiesTheDeclinePageAppearance(string lob)
        {
            ValidateDeclinePage(lob, DeclinePageElementsByLob);

            if (lob == "CA") VerifyCAQuoteNumber();
        }

        public void ValidateDeclinePage(string lob, Dictionary<string, List<Element>> lobDictionary)
        {
            foreach (var entry in lobDictionary)
            {
                if (lob == entry.Key)
                {
                    foreach (var element in entry.Value) element.AssertElementIsVisible();
                }
            }
        }

        public void VerifyCAQuoteNumber()
        {
            string value = CA_DeclinePage.CAQuoteID_Decline.GetAttribute("innerText");
            Regex rgx = new Regex("[A-z ]*: [0-9]*");
            Assert.IsTrue(rgx.IsMatch(value));
        }

        static List<Element> CADeclineElements = new List<Element>
        {
            DeclinePage.WeAreSorry,
            DeclinePage.Text1,
            DeclinePage.Text2,
            DeclinePage.PhoneNum,
            DeclinePage.CAQuoteID_Decline
        };

        static List<Element> WCDeclineElements = new List<Element>
        {
            DeclinePage.WeAreSorry,
            DeclinePage.Text1,
            DeclinePage.Text2,
            DeclinePage.PhoneNum
        };

        static List<Element> PLDeclineElements = new List<Element>
        {
            DeclinePage.WeAreSorry,
            DeclinePage.Text1
        };

        public static Dictionary<string, List<Element>> DeclinePageElementsByLob = new Dictionary<string, List<Element>>
        {
            { "CA", CADeclineElements},
            { "PL", PLDeclineElements},
            { "WC", WCDeclineElements}
        };

        [Then(@"user verifies decline page appearance due to not offering insurance for that industry")]
        public void ThenUserVerifiesdeclinePageMadlibs()
        {
            AutomationHelper.ValidateElements(DeclinePageRecommendationElements);
        }

        public static List<Element> DeclinePageRecommendationElements => new()
        {

            MadLibDeclinePage.declinePagetitle,
            MadLibDeclinePage.declinePagesubtext,
            MadLibDeclinePage.contactTivlyPhone,
            MadLibDeclinePage.getTivlyQuote,
        };
    }
}