using ApolloQA.Source.Driver;

namespace ApolloQA.Pages
{
    class Quote_BusinessInformation_Page
    {
        public static string URL_PATH = "/quote/{quoteID}/section/{sectionID}";

        public static string GetURL(int quoteID, long sectionID) => Quote_Page.GetURL(quoteID, sectionID);
        public static void Navigate(int quoteID, long sectionID) => Quote_Page.Navigate(quoteID, sectionID);

        public static Element Score => new Element("//mat-card-title[text()='National Credit File']/following-sibling::mat-card-content[contains(text(), 'Score:')]");

    }
}
