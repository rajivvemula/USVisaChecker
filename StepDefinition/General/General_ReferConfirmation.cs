using BiBerkLOB.Pages;
using BiBerkLOB.Pages.CommAuto;
using BiBerkLOB.Pages.PL;
using BiBerkLOB.Pages.WC;
using HitachiQA.Driver;
using HitachiQA.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace BiBerkLOB.StepDefinition.General
{
    [Binding]
    public sealed class General_ReferConfirmation
    {
        [Then(@"user verifies the (.*) refer confirmation appearance")]
        public void ThenUserVerifiesTheReferPageAppearance(string lob)
        {
            ValidateReferPage(lob, ReferPageElementsByLob);
        }

        public void ValidateReferPage(string lob, Dictionary<string, List<Element>> lobDictionary) 
        {
            foreach (var entry in lobDictionary) 
            {
                if (lob == entry.Key) 
                { 
                    foreach (var element in entry.Value) element.AssertElementIsVisible(); 
                }
            }
        }

        static List<Element> CAReferElements = new List<Element>
        {
            (CA_ReferConfirmationPage.YourInfoHasBeenSubmittedTitle),
            (CA_ReferConfirmationPage.ReviewYourInfoAndBeInTouch),
            (CA_ReferConfirmationPage.QuestionsCustomerServiceTeam),
            (CA_ReferConfirmationPage.PhoneNumberBTN),
            (CA_ReferConfirmationPage.PhoneNumberAndHours),
            (CA_ReferConfirmationPage.CustomerServiceEmail)
        };

        static List<Element> PLReferElements = new List<Element>
        {
            (PL_ReferConfirmationPage.ReferredPageTitle),
            (PL_ReferConfirmationPage.ReferredPageSubtitle),
            (PL_ReferConfirmationPage.QuestionsHeader),
            (PL_ReferConfirmationPage.PhoneIcon),
            (PL_ReferConfirmationPage.Phone),
            (PL_ReferConfirmationPage.EmailIcon),
            (PL_ReferConfirmationPage.Email),
        };

        static List<Element> WCReferElements = new List<Element>
        {
            WC_ReferralThankYouPage.ThankYouHeader,
            WC_ReferralThankYouPage.ReceivedInformationText,
            WC_ReferralThankYouPage.GoToHomePageBtn
        };

        public static Dictionary<string, List<Element>> ReferPageElementsByLob = new Dictionary<string, List<Element>>
        {
            { "CA", CAReferElements},
            { "PL", PLReferElements},
            { "WC", WCReferElements}
        };
    }
}