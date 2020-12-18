using ApolloQA.Source.Driver;

namespace ApolloQA.Pages
{
    class PrintCenter
    {

        public static Element WaffleMenuOptionPrintCenter => new Element("//a[@href='/print-center']");
        public static Element PrintCenterDashboard = new Element("//*[contains(text(), ' Dashboard ')]");
        public static Element PrintCenterHeader = new Element("//*[contains(text(), 'Print Center')]");

        public static Element PrintCenterGridLastItem => new Element("(//div[@class='datatable-row-center datatable-row-group ng-star-inserted'])[last()] //*[@role='button']");



    }
}
