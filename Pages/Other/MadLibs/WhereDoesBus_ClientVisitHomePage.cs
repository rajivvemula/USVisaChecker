using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using HitachiQA.Driver;
using OpenQA.Selenium;

namespace BiBerkLOB.Pages
{
    [Binding]
    public class WhereDoesBus_ClientVisitHomePage : Reusable_PurchasePath
    {
        public static Element DoClientsVisitTitle => new Element(By.XPath("//h1[@data-qa='page-title']"));
        public static Element DoClientsVisitQST => new Element(By.XPath("//label[@data-qa='clientsVisitHome-label']"));
        public static Element DoClientsVisitBTN_Yes => new Element(By.XPath("//button[@data-qa='yes-button']"));
        public static Element DoClientsVisitBTN_No => new Element(By.XPath("//button[@data-qa='no-button']"));
        public static Element DoClientsVisitError => new Element(By.XPath("//mat-error[@data-qa='clientsVisitHome-error']"));

        /*
         * Page CTA
         */
        public static Element NextCTA => new Element(By.XPath("//button[@data-qa='bbnav-navNext-tablet']"));
        public static Element BackCTA => new Element(By.XPath("//button[@data-qa='bbnav-navBack']"));
        /*
         * Button Groups
         */
        public static YesOrNoGroup DoClientsVisitBTNGroup => new YesOrNoGroup(DoClientsVisitBTN_Yes, DoClientsVisitBTN_No);
    }
}
