using System;
using System.Collections.Generic;
using System.Text;
using ApolloQA.Source.Driver;
using ApolloQA.Source.Helpers;

namespace ApolloQA.Pages.Quote
{
    class Quote_BusinessInformation_Page
    {
        public static string URL_PATH = "/quote/{quoteID}/section/{sectionID}";

        public static string GetURL(int quoteID, int sectionID) => Functions.ParseURL(URL_PATH, ("quoteID", quoteID.ToString()), ("sectionID", sectionID.ToString())  );
        public static void Navigate(int quoteID, int sectionID) => UserActions.Navigate(GetURL(quoteID, sectionID));

        public static Element Score => new Element("//mat-card-title[text()='National Credit File']/following-sibling::mat-card-content[contains(text(), 'Score:')]");

    }
}
