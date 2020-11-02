using ApolloQA.Source.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages
{
    class WaffleMenu
    {
        public static Element underwritingButton => new Element("/html/body/bh-app/mat-sidenav-container/mat-sidenav/div/bh-side-navbar/mat-nav-list/a[1]");
        public static Element billingButton => new Element("/html/body/bh-app/mat-sidenav-container/mat-sidenav/div/bh-side-navbar/mat-nav-list/a[2]");
        public static Element administrationButton => new Element("/html/body/bh-app/mat-sidenav-container/mat-sidenav/div/bh-side-navbar/mat-nav-list/a[3]");
        public static Element collectionsCenterButton => new Element("/html/body/bh-app/mat-sidenav-container/mat-sidenav/div/bh-side-navbar/mat-nav-list/a[4]");
        public static Element printCenterButton => new Element("/html/body/bh-app/mat-sidenav-container/mat-sidenav/div/bh-side-navbar/mat-nav-list/a[5]");
        public static Element claimsButton => new Element("body > bh-app > mat-sidenav-container > mat-sidenav > div > bh-side-navbar > mat-nav-list > a:nth-child(6)");
    }
}
