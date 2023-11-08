using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiBerkLOB.Pages.WC
{
    public sealed class WC_GetYourQuoteViaEmail
    {
        // Save for later link:
        public static Element SaveForLaterLink => new Element(By.XPath("//a[@data-qa='save_for_later_Save for Later']"));

        // Modal Elements
        public static Element GetYourQuoteViaEmail => new Element(By.XPath("//h2[@data-qa='get_quote_via_email_header']"));
        public static Element PleaseEnterTheRecipentsEmail => new Element(By.XPath("//p[@data-qa='recipient_email_header']"));
        public static Element EmailTxtbox(int index) => new Element(By.XPath($"//bb-email[@data-qa='recipient_email_input_{index}']//input"));
        public static Element AddMoreButton => new Element(By.XPath("//a[@data-qa='add_recipient_email_button']"));
        public static Element RemoveEmailButton(int index) => new Element(By.XPath($"//bb-email[@data-qa='remove_recipient_email_button_{index}']//input"));
        public static Element SubmitButton => new Element(By.XPath("//button[@data-qa='save_for_later_submit_button']"));
        public static Element CancelButton => new Element(By.XPath("//button[@data-qa='save_for_later_cancel_button']"));

        //Confimration Window Elements:
        public static Element WantToSaveOrShareTitle => new Element(By.XPath("//h2[@data-qa='save_share_quote_header']"));
        public static Element WeveSavedYourInfo => new Element(By.XPath("//p[@data-qa='information_saved_label']"));
        public static Element PriceChangeDisclaimer => new Element(By.XPath("//div[@data-qa='price_change_disclaimer']/span"));
        public static Element ConfirmationCloseButton => new Element(By.XPath("//button[@data-qa='save_for_later_close_button']"));
    }
}