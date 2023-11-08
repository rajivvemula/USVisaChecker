using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;


namespace BiBerkLOB.Pages.PL
{
    [Binding]
    public sealed class PL_AttorneysPage
    {
        /*
         * Attorneys Page
         */
        //Almost Done!
        public static Element AlmostDoneTitle => new Element(By.XPath("//h1[@data-qa='almost-done-header']"));
        //Nearly Finished
        public static Element AttorneyPageTitle => new Element(By.XPath("//h1[@data-qa='attorney-refer-header']"));
        //Due to your industry we'll need a little more information [before proceeding to checkout].
        //Please enter the first and last names of the attorneys that were indicated earlier.
        public static Element AttorneyPageCopy => new Element(By.XPath("//h6[@data-qa='attorney-page-copy']"));

        //Attorney names 
        public static Element AttorneyNameQST(string indexNum) => new Element(By.XPath($"//span[@data-qa='attorney-name-{indexNum}-label']"));
        public static Element FirstNameTxtbox(string indexNum) => new Element(By.XPath($"//md-input[@data-qa='attorney-firstname-input-{indexNum}']//input"));
        public static Element LastNameTxtbox(string indexNum) => new Element(By.XPath($"//md-input[@data-qa='attorney-lastname-input-{indexNum}']//input"));
        public static Element FirstNameError(string indexNum) => new Element(By.XPath($"//span[@data-qa='attorney-firstname-input-{indexNum}-validation-error']"));
        public static Element LastNameError(string indexNum) => new Element(By.XPath($"//span[@data-qa='attorney-lastname-input-{indexNum}-validation-error']"));

        //Full-time Independent Contractor Attorney / Of Counsel Name
        public static Element FullTimeQST(string indexNum) => new Element(By.XPath($"//span[@data-qa='{indexNum}-counsel-name-label']"));
        public static Element FTFirstNameTxtbox(string indexNum) => new Element(By.XPath($"//md-input[@data-qa='counsel-firstname-input-{indexNum}']//input"));
        public static Element FTLastNameTxtbox(string indexNum) => new Element(By.XPath($"//md-input[@data-qa='counsel-lastname-input-{indexNum}']//input"));
        public static Element FTFirstNameError(string indexNum) => new Element(By.XPath($"//span[@data-qa='counsel-firstname-input-{indexNum}-validation-error']"));
        public static Element FTLastNameError(string indexNum) => new Element(By.XPath($"//span[@data-qa='counsel-lastname-input-{indexNum}-validation-error']"));

        //Part-time Independent Contractor Attorney / Of Counsel Name
        public static Element PartTimeQST(string indexNum) => new Element(By.XPath($"//span[@data-qa='{indexNum}-parttime-name-label']"));
        public static Element PTFirstNameTxtbox(string indexNum) => new Element(By.XPath($"//md-input[@data-qa='parttime-firstname-input-{indexNum}']//input"));
        public static Element PTLastNameTxtbox(string indexNum) => new Element(By.XPath($"//md-input[@data-qa='parttime-lastname-input-{indexNum}']//input"));
        public static Element PTFirstNameError(string indexNum) => new Element(By.XPath($"//span[@data-qa='parttime-firstname-input-{indexNum}-validation-error']"));
        public static Element PTLastNameOneError(string indexNum) => new Element(By.XPath($"//span[@data-qa='parttime-lastname-input-{indexNum}-validation-error']"));

        //Enter the name of your Title Agency:
        public static Element TitleAgencyQST => new Element(By.XPath("//span[@data-qa='title-agency-name-label']"));
        public static Element TitleAgencyTxtbox => new Element(By.XPath("//md-input[@data-qa='title-agency-input']//input"));
        public static Element TitleAgencyError => new Element(By.XPath("//span[@data-qa='title-agency-input-validation-error']"));

        //Continue
        public static Element ReferredContinueCTA => new Element(By.XPath("//button[@data-qa='attorney-referred-continue-button']"));
    }
}
