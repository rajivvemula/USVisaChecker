using System;
using System.Collections.Generic;
using System.Text;
using ApolloQA.Source.Driver;


namespace ApolloQA.Pages.Quote
{
    class Quote_Page
    {
        public static string URL_PATH = "/quote/{quoteID}";
        public static void navigate(int quoteID) => UserActions.Navigate(URL_PATH, ("quoteID" , quoteID.ToString()));

        public static Element BusinessName => new Element("//bh-input-autocomplete[@name='businessName']/..");
        public static Element LineOfBusiness => new Element("//mat-select[@name='lineOfBusiness']/..");
        public static Element PolicyEffectiveDate => new Element("//input[@name='policyEffectiveDate']");
        public static Element PolicyExpirationDate => new Element("//input[@name='policyExpirationDate']");
        public static Element SubmitButton => new Element("//button[@aria-label='Submit']");

        public static Element loadingSpinner => new Element("//bh-mat-spinner-overlay/*");
        public static Element toastMessage => new Element("//div[@class='toast-content']/descendant::*");

    }
}
