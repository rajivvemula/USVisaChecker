﻿using ApolloQA.Source.Driver;
using ApolloQA.Source.Helpers;

namespace ApolloQA.Pages
{
    class Quote_Page
    {
        public static string URL_PATH = "/quote/{quoteID}";

        public static string GetURL(long quoteID) => Functions.ParseURL(URL_PATH, ("quoteID", quoteID.ToString()));
        public static void Navigate(long quoteID) => UserActions.Navigate(GetURL(quoteID));

        public static string URL_PATH_SECTION = "/quote/{quoteID}/section/{sectionID}";
        public static string GetURL(long quoteID, long sectionID) => Functions.ParseURL(URL_PATH_SECTION, ("quoteID", quoteID.ToString()), ("sectionID", sectionID.ToString()));
        public static void Navigate(long quoteID, long sectionID) => UserActions.Navigate(GetURL(quoteID, sectionID));


        public static Element GetHeaderField(string DisplayName)
        {
            return new Element($"//bh-header//*[contains(text(), '{DisplayName}')]//preceding-sibling::div/descendant::*");
        }

        public static Element LeftSiveNavBar => new Element("//bh-left-navbar //mat-sidenav //mat-nav-list //*/a");

    }
}
