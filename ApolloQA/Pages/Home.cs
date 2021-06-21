using ApolloQA.Source.Driver;

namespace ApolloQA.Pages
{
    class Home 
    {
        public static string URL_PATH = "/home";
        public static void navigate() => UserActions.Navigate(URL_PATH);

        public static Element ApolloIcon => new Element("//fa-icon[@routerlink='home']");
        public static Element OrganizationButton = new Element("//*[contains(text(), ' Organization ')]");
        public static Element quoteButton = new Element("//*[contains(text(), ' Quote ')]");
        public static Element policyButton = new Element("//*[contains(text(), ' Policy ')]");
        public static Element searchField = new Element("//input[@data-placeholder='Search here']");
        public static Element orderByDropdown = new Element("//*[@name='orderBy']");
        public static Element userToImpersonateButton = new Element("//button[@title='Choose user to impersonate']");
        public static Element recentHistoryButton = new Element("//*[contains(text(), 'history')]");
        public static Element notificationsButton = new Element("//*[contains(text(), 'notifications')]");
        public static Element menuAddButton = new Element("//mat-icon[contains(text(), 'add')]");
        public static Element userProfileButton = new Element("//mat-icon[contains(text(), 'person')]");
        public static Element ellipsisButton = new Element("//mat-icon[contains(text(), 'more_vert')]");
        public static Element WaffleGridButton = new Element("//mat-icon[contains(text(), ' apps ')]");
    }
}

