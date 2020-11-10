using System;
using System.Collections.Generic;
using System.Text;
using ApolloQA.Source.Driver;
using ApolloQA.Source.Helpers;

namespace ApolloQA.Pages.Quote
{
    class Quote_Page
    {
        public static string URL_PATH = "/quote/{quoteID}";

        public static string GetURL(int quoteID) => Functions.ParseURL(URL_PATH, ("quoteID", quoteID.ToString()));
        public static void Navigate(int quoteID) => UserActions.Navigate(GetURL(quoteID));

        public static Element GetHeaderField(string DisplayName)
        {
            return new Element($"//bh-quote-header//*[contains(text(), '{DisplayName}')]//preceding-sibling::div/descendant::*");
        }

        public static Element LeftSiveNavBar => new Element("//bh-left-navbar //mat-sidenav //mat-nav-list //*/a");

    }
}
