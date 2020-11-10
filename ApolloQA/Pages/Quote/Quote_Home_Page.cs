using System;
using System.Collections.Generic;
using System.Text;
using ApolloQA.Source.Driver;


namespace ApolloQA.Pages.Quote
{
    class Quote_Home_Page
    {
        public static string URL_PATH = "/quote";
        public static void navigate() => UserActions.Navigate(URL_PATH);

        public static Element NewButton => new Element("//button[span/text()=' New ']");

    }
}
