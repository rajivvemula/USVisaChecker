using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BiBerkLOB.Source.Driver;
using BiBerkLOB.Source.Driver.Input;

using HitachiQA.Driver.Input;
using TechTalk.SpecFlow;


namespace BiBerkLOB.Pages.BOP
{
    [Binding]
    public sealed class BOP_AQuickIntroductionPage
    {
        public static LoadingRequirements LoadingRequirements => new LoadingRequirements(IntroPageTitle, PleaseTellUsALittle);
        /*
       * Headers----------------------------------------------------------
       */

        // A Quick Introduction
        public static Element IntroPageTitle => new Element(By.XPath("//h1[@data-qa='Introduction-label']"));
        // Please tell us a little bit about your company
        public static Element PleaseTellUsALittle => new Element(By.XPath("//p[@data-qa='Introduction-sub-label']"));


        //How is your business structured?
        public static Element BusinessStructuredQST => new Element(By.XPath("//label[@data-qa='_apollo_BusinessStructure-label']"));
        public static Element BusinessStructuredDD => new Element(By.XPath("//mat-select[@data-qa='_apollo_BusinessStructure']"));
        public static InputSection BusinessStructuredInput => new MatDropdownInput(BusinessStructuredDD)
            .AsAQuestion(BusinessStructuredQST);
        public static Element BusinessStructuredHelper => new Element(By.XPath("//button[@data-qa='buttonShowHelpToggle-_apollo_BusinessStructure']/mat-icon"));
        public static Element BusinessStructuredHelperX => new Element(By.XPath("//button[@data-qa='buttonClose-bbHelpText-_apollo_BusinessStructure']/span/mat-icon"));
        public static Element BusinessStructuredHelperText => new Element(By.XPath("//p[@data-qa='bbHelpText-_apollo_BusinessStructure-label']"));
        public static Element BusinessStructuredError => new Element(By.XPath("//bb-error-message[@data-qa='_apollo_BusinessStructure-errorMessage']/span/div"));

        // What is the name of your business?
        public static Element BusinessNameQST => new Element(By.XPath("//label[@data-qa='_apollo_BusinessName-label']"));
        public static Element BusinessNameTxtbox => new Element(By.XPath("//input[@data-qa='_apollo_BusinessName']"));
        public static Element BusinessNameErrorMsg => new Element(By.XPath("//bb-error-message[@data-qa='_apollo_BusinessName-errorMessage']/span/div"));

        // Do you do business under another name?
        public static Element BusinessUnderAnotherNameQST => new Element(By.XPath("//label[@data-qa='_apollo_BusinessUnderAnotherName-label']"));
        public static Element BusinessUnderAnotherNameYesButton => new Element(By.XPath("//button[@data-qa='_apollo_BusinessUnderAnotherName-8001-yes-button']"));
        public static Element BusinessUnderAnotherNameNoButton => new Element(By.XPath("//button[@data-qa='_apollo_BusinessUnderAnotherName-8001-no-button']"));
        public static Element BusinessUnderAnotherNameErrorMsg => new Element(By.XPath("//bb-error-message[@data-qa='_apollo_BusinessUnderAnotherName-errorMessage']/span/div"));

        // What is the other Business name?
        public static Element BusinessOtherNameQST => new Element(By.XPath("//label[@data-qa='_apollo_BusinessOtherName-label']"));
        public static Element BusinessOtherNameTxtBox => new Element(By.XPath("//input[@data-qa='_apollo_BusinessOtherName']"));
        public static Element BusinessOtherNameErrorMsg => new Element(By.XPath("//bb-error-message[@data-qa='_apollo_BusinessOtherName-errorMessage']/span/div"));
        public static Element BusinessOtherNameHelper => new Element(By.XPath("//button[@data-qa='buttonShowHelpToggle-_apollo_BusinessOtherName']/mat-icon"));
        public static Element BusinessOtherNameHelperX => new Element(By.XPath("//button[@data-qa='buttonClose-bbHelpText-_apollo_BusinessOtherName']/span/mat-icon"));
        public static Element BusinessOtherNameHelperText => new Element(By.XPath("//p[@data-qa='bbHelpText-_apollo_BusinessOtherName-label']"));
       

        //What year was your business started?
        public static Element BusinessStartedQST => new Element(By.XPath("//label[@data-qa='_apollo_YearBusinessStarted-label']"));
        public static Element BusinessStartedTxtbox => new Element(By.XPath("//input[@data-qa='_apollo_YearBusinessStarted']"));
        public static Element BusinessStartedTextBelow => new Element(By.XPath("//mat-hint[@data-qa='_apollo_YearBusinessStarted-hint']"));
        public static InputSection BusinessStartedInput => new TextBoxInput(BusinessStartedTxtbox)
            .AsAQuestion(BusinessStartedQST)
            .WithExtraText(BusinessStartedTextBelow);
        public static Element BusinessStartedHelper => new Element(By.XPath("//button[@data-qa='buttonShowHelpToggle-_apollo_YearBusinessStarted']"));
        public static Element BusinessStartedHelperText => new Element(By.XPath("//p[@data-qa='bbHelpText-_apollo_YearBusinessStarted-label']"));
        public static Element BusinessStartedHelperX => new Element(By.XPath("//button[@data-qa='buttonClose-bbHelpText-_apollo_YearBusinessStarted']"));
        public static Element BusinessStartedError => new Element(By.XPath("//bb-error-message[@data-qa='_apollo_YearBusinessStarted-errorMessage']/span/div"));

     
    }
}
