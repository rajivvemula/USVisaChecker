using System.Collections.Generic;
using HitachiQA.Driver;

namespace ApolloQAAutomation.Pages
{
    public sealed class Apollo_HomePage
    {
        /**************************************
        *                                    *
        *        HEADER ELEMENTS             *
        *                                    *
        **************************************/

        public static Element ApolloIcon => new("//fa-icon[@routerlink='home']");
        public static Element HeaderQuoteBtn => new("//a[@href='/quote']");
        public static Element HeaderPolicyBtn => new("//a[@href='/policy']");
        public static Element HeaderRenewalBtn => new("//a[@href='/renewal']");
        public static Element HeaderBillingBtn => new("//a[@href='/billing']");
        public static Element HeaderSearchBtn => new("(//a[@href='/advancedsearch'])[1]");
        public static Element HeaderSearchInput => new("//input[@data-qa='searchKeyword-input']");
        public static Element HeaderSearchKeywordIcon => new("//div[@data-qa='searchKeyword-icon']");
        public static Element HeaderNotificationsBtn => new("//button[.//mat-icon[text()='notifications']]");
        public static Element HeaderAddBtn => new("//button[.//mat-icon[text()='add']]");
        public static Element HeaderPersonBtn => new("//button[.//mat-icon[text()='person']]");
        public static Element HeaderAppsBtn => new("(//div[contains(.//mat-icon, 'apps')])[1]");

        // Your Details
        public static Element YourDetailsHeader => new("//h3[text()='Your Details']");
        public static Element YourDetailsEmail => new("//h3[contains(text(), 'Your Details')]/following::p[contains(text(),'Email')]");
        public static Element YourDetailsFirstName => new("//h3[contains(text(), 'Your Details')]/following::p[contains(text(),'First Name')]");
        public static Element YourDetailsLastName => new("//h3[contains(text(), 'Your Details')]/following::p[contains(text(),'Last Name')]");

        // User Roles
        public static Element UserRolesHeader => new("//h3[contains(text(), 'User Roles')]");

        //Your User Profile
        public static Element YourUserProfileHeader => new("//h3[text()='Your User Profile']");

        public static List<Element> HeaderElements = new()
        {
            ApolloIcon, 
            HeaderQuoteBtn, 
            HeaderPolicyBtn, 
            HeaderRenewalBtn, 
            HeaderSearchBtn, 
            HeaderSearchInput, 
            HeaderSearchKeywordIcon, 
            HeaderNotificationsBtn, 
            HeaderAddBtn, 
            HeaderPersonBtn, 
            HeaderAppsBtn,
            YourDetailsHeader,
            YourDetailsEmail,
            YourDetailsFirstName,
            YourDetailsLastName,
            UserRolesHeader,
            YourUserProfileHeader
        };
    }
}