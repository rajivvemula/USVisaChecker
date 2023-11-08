using BiBerkLOB.Pages.WC;
using HitachiQA.Driver;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace BiBerkLOB.StepDefinition.General.WC
{
    [Binding]
    public sealed class WC_Gen_GetYourQuoteViaEmail
    {
        [When(@"user saves their quote for later by sending it to the following email\(s\): (.*)")]
        public void WhenUserSavesTheirQuoteForLaterBySendingItToTheFollowingEmailS(string unparsedEmails)
        {
            var emails = ParseEmails(unparsedEmails);

            WC_GetYourQuoteViaEmail.SaveForLaterLink.Click();

            ValidateElements(GetYourQuoteModalElements);
            EnterEmails(emails);

            ValidateElements(ConfirmationWindowElements);
            WC_GetYourQuoteViaEmail.ConfirmationCloseButton.Click();
        }

        public List<string> ParseEmails(string unparsedEmails)
        {
            var emails = new List<string>();
            var regx = new Regex(@"[^,\s]+");
            var match = regx.Match(unparsedEmails);

            while (match.Success)
            {
                emails.Add(match.Value);
                match = match.NextMatch();
            }

            return emails;
        }

        public void EnterEmails(List<string> emails)
        {
            for (var i = 0; i <= emails.Count - 1; i++)
            {
                if (WC_GetYourQuoteViaEmail.EmailTxtbox(i).AssertElementIsVisible(1, true))
                {
                    WC_GetYourQuoteViaEmail.EmailTxtbox(i).SetText(emails[i]);
                }
                else
                {
                    WC_GetYourQuoteViaEmail.AddMoreButton.Click();
                    WC_GetYourQuoteViaEmail.EmailTxtbox(i).SetText(emails[i]);
                }
            }

            WC_GetYourQuoteViaEmail.SubmitButton.Click();
        }

        public void ValidateElements(List<Element> elements)
        {
            foreach (var element in elements) element.AssertElementIsVisible();
        }

        static List<Element> GetYourQuoteModalElements = new List<Element>
        {
            WC_GetYourQuoteViaEmail.GetYourQuoteViaEmail,
            WC_GetYourQuoteViaEmail.PleaseEnterTheRecipentsEmail,
            WC_GetYourQuoteViaEmail.EmailTxtbox(0),
            WC_GetYourQuoteViaEmail.AddMoreButton,
            WC_GetYourQuoteViaEmail.SubmitButton,
            WC_GetYourQuoteViaEmail.CancelButton
        };

        static List<Element> ConfirmationWindowElements = new List<Element>
        {
            WC_GetYourQuoteViaEmail.WantToSaveOrShareTitle,
            WC_GetYourQuoteViaEmail.WeveSavedYourInfo,
            WC_GetYourQuoteViaEmail.PriceChangeDisclaimer,
            WC_GetYourQuoteViaEmail.ConfirmationCloseButton
        };
    }
}