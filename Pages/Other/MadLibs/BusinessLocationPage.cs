using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiBerkLOB.Pages
{
    class BusinessLocationPage : Reusable_PurchasePath
    {
        // Where is your business located?
        public static Element WhereIsYourBusLocatedQst => new Element(By.XPath("//label[@data-qa='zipCode-label']"));

        // ZIP Code Field
        public static Element ZIPCodeTxtbox => new Element(By.XPath("//input[@data-qa='zipCode-zipCodeControl-zipcode']"));
        public static Element WhereIsYourBusLocatedTxtBelow => new Element(By.XPath("//mat-hint[@data-qa='zip-hint']"));
        public static Element WhereIsYourBusLocatedError => new Element(By.XPath("//mat-hint[@data-qa='zip-hint-with-error']"));

        // Next CTA
        public static Element NextCTA => new Element(By.XPath("//button[@data-qa='bbnav-navNext-tablet']"));

        // Back CTA
        public static Element BackCTA => new Element(By.XPath("//button[@data-qa='bbnav-navBack']"));

    }
}
