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
    public class WhereDoesBus_OwnLease : Reusable_PurchasePath
    {
        public static Element DoesBusOwnOrLeaseTitle => new Element(By.XPath("//h1[@data-qa='page-title']"));
        public static Element DoesBusOwnOrLeaseQST => new Element(By.XPath("//label[@data-qa='leaseItemTypes-label']"));
        public static Element DoesBusOwnOrLeaseChbox_Vehicles => new Element(By.XPath("//mat-checkbox[@data-qa='leaseItemTypes-0-checkbox']"));
        public static Element DoesBusOwnOrLeaseChboxLabel_Vehicles => new Element(By.XPath("//span[@data-qa='leaseItemTypes-checkbox-label-0']"));
        public static Element DoesBusOwnOrLeaseChkbox_Furniture => new Element(By.XPath("//mat-checkbox[@data-qa='leaseItemTypes-1-checkbox']"));
        public static Element DoesBusOwnOrLeaseChkboxLabel_Furniture => new Element(By.XPath("//span[@data-qa='leaseItemTypes-checkbox-label-1']"));    
        public static Element DoesBusOwnOrLeaseChkbox_InventoryOrStock => new Element(By.XPath("//mat-checkbox[@data-qa='leaseItemTypes-2-checkbox']"));
        public static Element DoesBusOwnOrLeaseChkboxLabel_InventoryOrStock => new Element(By.XPath("//span[@data-qa='leaseItemTypes-checkbox-label-2']"));
        public static Element DoesBusOwnOrLeaseChkbox_ToolsOrEquip => new Element(By.XPath("//mat-checkbox[@data-qa='leaseItemTypes-3-checkbox']"));
        public static Element DoesBusOwnOrLeaseChkboxLabel_ToolsOrEquip => new Element(By.XPath("//span[@data-qa='leaseItemTypes-checkbox-label-3']"));
        public static Element DoesBusOwnOrLeaseHelper => new Element(By.XPath("//button[@data-qa='buttonShowHelpToggle-leaseItemTypes']"));
        public static Element DoesBusOwnOrLeaseHelperText => new Element(By.XPath("//p[@data-qa='bbHelpText-leaseItemTypes-label']"));
        public static Element DoesBusOwnOrLeaseHelperX => new Element(By.XPath("//button[@data-qa='buttonClose-bbHelpText-leaseItemTypes']"));

        /*
        * Page CTA
        */
        public static Element NextCTA => new Element(By.XPath("//button[@data-qa='bbnav-navNext-tablet']"));
        public static Element BackCTA => new Element(By.XPath("//button[@data-qa='bbnav-navBack']"));
        /*
         * Choice Group
         */

        public static ChoiceGroup DoesBusOwnOrLeaseChoices => new ChoiceGroup(_ownOrLeaseElements);
        private static Dictionary<string, Element> _ownOrLeaseElements = new Dictionary<string, Element>()
        {
            { "Vehicles", DoesBusOwnOrLeaseChbox_Vehicles },
            { "Furniture", DoesBusOwnOrLeaseChkbox_Furniture },
            { "Inventory or Stock", DoesBusOwnOrLeaseChkbox_InventoryOrStock },
            { "Tools or Equipment", DoesBusOwnOrLeaseChkbox_ToolsOrEquip  }
        };
    }
}
