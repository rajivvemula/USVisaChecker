using ApolloQA.Source.Driver;

namespace ApolloQA.Pages
{
    class ClaimsFNOLGrid
    {
        public static Element managerDashboardButton => new Element("//*//mat-sidenav-container//*//div[1]/div[1]/button");
        public static Element AdjusterDasbhoardButton => new Element("//*//mat-sidenav-container//*//div[1]/div[2]/button");
        public static Element addNewFNOLButton => new Element("//button[@type='button' and @aria-label='New FNOL']");
        public static Element PendingFNOL => new Element("(//*[@class='datatable-row-center datatable-row-group ng-star-inserted' and //*[contains(text(), 'Pending')]])[1] //*[2]//*//span//a[@role='button']");
        public static Element ClaimHeader => new Element("//bh-claim-header");
        public static Element OpenClaim => new Element("(//a[@role='button' and @class='nav-link'])[1]");
    }
}
