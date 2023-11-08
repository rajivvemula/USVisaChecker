using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiBerkLOB.Pages
{
    public class IndustryQuestionPage : Reusable_PurchasePath
    {
        //Small Business Insurance
        public static Element SmallBusInsuranceTitle => new Element(By.XPath("//h1[@data-qa='page-title']"));

        // Save up to 20% on your business insurance. Get a quote and get covered online in minutes.
        public static Element SaveUpTo20 => new Element(By.XPath("//p[@data-qa='page-subtitle']"));

        // What's your industry?
        public static Element IndustryQST => new Element(By.XPath("//label[@data-qa='industryAutocomplete-label']"));
        public static Element IndustryTxtbox => new Element(By.XPath("//input[@data-qa='autocompleteIndustryControl']"));
        public static Element getIndustryDD(string keyword) => new Element(By.XPath($"//mat-option[@data-qa='autocompleteIndustryControl-option-{keyword}']"));
        public static Element IndustryDD_CantFindBusiness => new Element(By.XPath("//mat-option[@data-qa=\"autocompleteIndustryControl-option-I can't find my business description\"]"));
        public static Element IndustryHelper => new Element(By.XPath("//button[@data-qa='buttonShowHelpToggle-industryAutocomplete']"));
        public static Element IndustryHelperText => new Element(By.XPath("//p[@data-qa='bbHelpText-industryAutocomplete-label']"));
        public static Element IndustryHelperX => new Element(By.XPath("//button[@data-qa='buttonClose-bbHelpText-industryAutocomplete']"));
        public static Element IndustryTextBelow => new Element(By.XPath("//mat-hint[@data-qa='industry-hint']"));
        public static Element IndustryError => new Element(By.XPath("//mat-error[@data-qa='industry-error']"));
        public static Element IndustrySpinner => new Element(By.XPath("//mat-spinner[@data-qa='spinner']"));

        //What does your business do?
        public static Element WhatDoesYourBusinessDoQST => new Element(By.XPath("//label[@data-qa='businessDescription-label']"));
        public static Element WhatDoesYourBusinessDoTxtbox => new Element(By.XPath("//input[@data-qa='businessDescription']"));
        public static Element WhatDoesYourBusinessDoTxtBelow => new Element(By.XPath("//mat-hint[@data-qa='businessDescription-hint']"));

        // Let's Go! CTA
        public static Element LetsGoCTA => new Element(By.XPath("//button[@data-qa='next-button']"));
    }
}
