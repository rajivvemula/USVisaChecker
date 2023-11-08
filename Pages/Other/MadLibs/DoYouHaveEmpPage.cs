using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiBerkLOB.Pages
{
    class DoYouHaveEmpPage : Reusable_PurchasePath
    {
        //Small Business Insurance
        public static Element SmallBusInsTitle => new Element(By.XPath("//h1[@data-qa='page-title']"));
        // Do you have any employees?
        public static Element DoYouHaveEmpQST => new Element(By.XPath("//label[@data-qa='employeeButtonList-label']"));

        // Yes, I have employees
        public static Element YesIhaveCTA => new Element(By.XPath("//button[@data-qa='yes-employees-button']"));

        // No, just the owner(s)
        public static Element NoJustTheOwnerCTA => new Element(By.XPath("//button[@data-qa='no-employees-button']"));
        
        public static Element HaveEmployeesHelper => new Element(By.XPath("//button[@data-qa='buttonShowHelpToggle-employeeButtonList']"));
        public static Element HaveEmployeesHelperText => new Element(By.XPath("//p[@data-qa='bbHelpText-employeeButtonList-label']"));
        public static Element HaveEmployeesHelperX => new Element(By.XPath("//button[@data-qa='buttonClose-bbHelpText-employeeButtonList']"));
        public static Element HaveEmployeesError => new Element(By.XPath("//mat-error[@data-qa='employeeButtonList-error']"));

        // Next CTA
        public static Element NextCTA  => new Element(By.XPath("//button[@data-qa='bbnav-navNext-tablet']"));

        // Back CTA
        public static Element BackCTA => new Element(By.XPath("//button[@data-qa='bbnav-navBack']"));
        // Button Groups
        public static YesOrNoGroup DoYouHaveEmpGroup => new YesOrNoGroup(YesIhaveCTA, NoJustTheOwnerCTA);
    }
}
