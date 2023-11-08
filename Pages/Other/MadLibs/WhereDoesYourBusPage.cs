using HitachiQA.Driver;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace BiBerkLOB.Pages
{
    class WhereDoesYourBusPage : Reusable_PurchasePath
    {
        // Where does your business operate?
        public static Element WhereDoesYourBusQst => new Element(By.XPath("//label[@data-qa='employeeButtonList-label']"));
        public static Element WhereDoesYourBusHelper => new Element(By.XPath("//button[@data-qa='buttonShowHelpToggle-employeeButtonList']"));
        public static Element WhereDoesYourBusHelperText => new Element(By.XPath("//p[@data-qa='bbHelpText-employeeButtonList-label']"));
        public static Element WhereDoesYourBusHelperX => new Element(By.XPath("//button[@data-qa='buttonClose-bbHelpText-employeeButtonList']"));
        public static Element WhereDoesYourBusError => new Element(By.XPath("//mat-error[@data-qa='occupancyTypeCode-error']"));

        // I Run My Business Out of My Home
        public static Element RunMyBusOutOfMyHomeCTA => new Element(By.XPath("//button[@data-qa='TEHOME-button']"));
        // I Lease a Space From Others
        public static Element LeaseSpaceFromOthersCTA => new Element(By.XPath("//button[@data-qa='TEBUILDING-button']"));
        // I Work at a Job Site
        public static Element WorkJobSiteCTA => new Element(By.XPath("//button[@data-qa='TEJOBSITE-button']"));
        // I Run My Business From Property I Own
        public static Element RunMyBusFromProOwnCTA => new Element(By.XPath("//button[@data-qa='OM-button']"));
        // I Own a Property & Lease to Others
        public static Element OwnPropertyAndLeaseOthersCTA => new Element(By.XPath("//button[@data-qa='NO-button']"));

        // Next CTA
        public static Element NextCTA => new Element(By.XPath("//button[@data-qa='bbnav-navNext-tablet']"));
        // Back CTA
        public static Element BackCTA => new Element(By.XPath("//button[@data-qa='bbnav-navBack']"));

        // Choice Group
        public static ChoiceGroup WhereDoesYourBusChoices => new ChoiceGroup(_whereDoesYourBusElements);
        private static Dictionary<string, Element> _whereDoesYourBusElements => new Dictionary<string, Element>()
        {
            { "i run my business out of my home", RunMyBusOutOfMyHomeCTA },
            { "i lease a space from others", LeaseSpaceFromOthersCTA },
            { "i work at a job site", WorkJobSiteCTA },
            { "i run my business from property i own", RunMyBusFromProOwnCTA },
            { "i own a property & lease to others", OwnPropertyAndLeaseOthersCTA }
        };
    }
}