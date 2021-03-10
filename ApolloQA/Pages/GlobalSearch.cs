using ApolloQA.Source.Driver;


namespace ApolloQA.Pages
{
    class GlobalSearch
    {
        public static Element SearchInput => new Element("//input[@data-placeholder='Search here']");
        public static Element SearchResult => new Element("(//div[@class='outer-info ng-star-inserted'])[1]");

        public static Element SearchResultLabel(int position=1) => new Element($"(//div[@class='outer-info ng-star-inserted'])[{position}] //div[@class='line-label']");

        public static Element SearchResultLastLabel = new Element("(//div[@class='line-label'])[last()]");
        public static Element SearchResultDescription => new Element("(//div[@class='outer-info ng-star-inserted'])[1] //div[@class='line-description ng-star-inserted']");
        public static Element NoResultsFound => new Element("//span[@class='mat-option-text'] //*[contains(text(), 'No results found')]");
        public static Element Searching => new Element("//span[@class='mat-option-text'] //*[contains(text(), 'Searching...')]");
    }
}