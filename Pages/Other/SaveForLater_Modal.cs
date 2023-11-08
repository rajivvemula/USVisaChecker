using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiBerkLOB.Pages
{
    public class SaveForLater_Modal
    {
        /*
        * Save for Later Modal
        */

        //Navigate to the Modal:
        public static Element SflNeedToFinishLater => new Element(By.XPath("//h6[@data-qa='sfl-text']"));
        public static Element SflSaveBTN => new Element(By.XPath("//button[@data-qa='sfl-link']"));
        //When Modal is opened:
        public static Element SflHeader => new Element(By.XPath("//h2[@data-qa='Save your progress-header']"));
        public static Element SfLSeeYouLater => new Element(By.XPath("//h2[@data-qa='See You Later-header']"));
        public static Element SflSubTitle => new Element(By.XPath("//p[@data-qa='sfl-instructions-text']"));
        public static Element SfLSeeYouLaterSubtitle => new Element(By.XPath("//div[@data-qa='email-link-later-text']/div/label"));
        public static Element SflEmailTxtbox => new Element(By.XPath("//input[@data-qa='_apollo_SFLEmail']"));
        public static Element SflEmailError => new Element(By.XPath("//mat-error[@data-qa='bb-error']"));
        public static Element SflPhoneTxtbox => new Element(By.XPath("//input[@data-qa='_apollo_SFLPhoneAndExt']"));
        public static Element SflPhoneError => new Element(By.XPath("//mat-error[@data-qa='number-error']"));
        public static Element SflFirstNameTxtbox => new Element(By.XPath("//input[@data-qa='SFLContacts-firstName']"));
        public static Element SflLastNameTxtbox => new Element(By.XPath("//input[@data-qa='SFLContacts-lastName']"));
        public static Element SflNameError => new Element(By.XPath("//mat-error[@data-qa='_apollo_SFLContacts-error']"));
        public static Element SflOtherEmail => new Element(By.XPath("//input[@data-qa='sfl-input']"));
        public static Element SflOtherEmailHint => new Element(By.XPath("//mat-hint[@data-qa='sfl-mat-hint']"));
        public static Element SfLSeeYouLaterTxtbox => new Element(By.XPath("//input[@data-qa='sfl-input']"));
        public static Element SfLSeeYouLaterEmailCancel => new Element(By.XPath("//mat-icon[contains(text(), 'cancel')]")); 
        public static Element SfLSeeYouLaterError => new Element(By.XPath("//mat-error[@data-qa='email-error']"));
        public static Element SfLSeeYouLaterHelperX => new Element(By.XPath("//button[@data-qa='close-modal']"));
        public static Element SfLGetMyLinkCTA => new Element(By.XPath("//button[@data-qa='modal-primary-btn']"));
        public static Element SfLMatHint => new Element(By.XPath("//mat-hint[contains(@id,'mat-hint')]"));
        public static Element VerifyPrePopulatedEmail(string email) => new Element(By.XPath($"//div[@data-qa='email-link-later-text']//mat-chip[contains(text(),'{email}')]"));
        //When successfully submitted:
        public static Element SfLSuccessToast => new Element(By.XPath("//div[@id='toast-container']/div[contains(@class,'toast-success')]"));

        public static List<Element> SFLModalElements = new List<Element>
        {
            SflHeader,
            SflSubTitle,
            SflEmailTxtbox,
            SflPhoneTxtbox,
            SflFirstNameTxtbox,
            SflLastNameTxtbox,
            SflOtherEmail,
            SflOtherEmailHint,
            SfLSeeYouLaterHelperX,
            SfLGetMyLinkCTA
        };

        public static List<Element> SfLSlimModalElements = new List<Element>
        {
            SflHeader,
            SfLSeeYouLaterSubtitle,
            SfLSeeYouLaterTxtbox,
            SfLSeeYouLaterHelperX,
            SfLGetMyLinkCTA
        };
    }
}
