using System;
using System.Collections.Generic;
using System.Text;
using ApolloQA.Source.Helpers;
using ApolloQA.Source.Driver;

namespace ApolloQA.Pages.Organization
{
    public class Organization_Page
    {

        public static string URL_PATH = "/organization/{organizationId}";

        public static string GetURL(int quoteID) => Functions.ParseURL(URL_PATH, ("organizationId", quoteID.ToString()));
        public static void Navigate(int quoteID) => UserActions.Navigate(GetURL(quoteID));


    }
}
