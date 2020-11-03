using System;
using ApolloQA.Source.Driver;
using OpenQA.Selenium;

namespace ApolloQA.Pages
{
    class TopNavBar
    {
        public static Element homeButton => new Element("/html/body/bh-app/mat-sidenav-container/mat-sidenav-content/bh-top-navbar/mat-toolbar/fa-icon/svg/path");
        public static Element OrganizationButton = new Element("/html/body/bh-app/mat-sidenav-container/mat-sidenav-content/bh-top-navbar/mat-toolbar/div[1]/div[1]/button");
        public static Element quoteButton = new Element("/html/body/bh-app/mat-sidenav-container/mat-sidenav-content/bh-top-navbar/mat-toolbar/div[1]/div[2]/button");
        public static Element policyButton = new Element("/html/body/bh-app/mat-sidenav-container/mat-sidenav-content/bh-top-navbar/mat-toolbar/div[1]/div[3]/button");
        public static Element searchField = new Element(By.Id("mat-input-0"));
        public static Element orderByDropdown = new Element("//select[@role='listbox']");
        public static Element orderByDropdownLastUpdate = new Element("//option[@mat-option-text=' Last Updated ']");
        public static Element orderByDropdownRelevance = new Element("//option[@mat-option-text='Relevance ']");
        public static Element userToImpersonateButton = new Element("/html/body/bh-app/mat-sidenav-container/mat-sidenav-content/bh-top-navbar/mat-toolbar/div[2]/button");
        public static Element recentHistoryButton = new Element("/html/body/bh-app/mat-sidenav-container/mat-sidenav-content/bh-top-navbar/mat-toolbar/div[2]/bh-recent-history/button");
        public static Element menuTriggerButton = new Element("/html/body/bh-app/mat-sidenav-container/mat-sidenav-content/bh-top-navbar/mat-toolbar/div[2]/bh-add-object-component/button");
        public static Element userProfileButton = new Element("/html/body/bh-app/mat-sidenav-container/mat-sidenav-content/bh-top-navbar/mat-toolbar/div[2]/bh-user-profile/button");
        public static Element WaffleGridButton = new Element("/html/body/bh-app/mat-sidenav-container/mat-sidenav-content/bh-top-navbar/mat-toolbar/div[3]/mat-icon");
    }
}
