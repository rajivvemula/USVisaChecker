using ApolloQA.Source.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages
{
    class ClaimsFNOLGrid
    {
        public static Element managerDashboardButton => new Element("/html/body/bh-app/mat-sidenav-container/mat-sidenav-content/bh-top-navbar/mat-toolbar/div[1]/div[1]/button");
        public static Element AdjusterDasbhoardButton => new Element("/html/body/bh-app/mat-sidenav-container/mat-sidenav-content/bh-top-navbar/mat-toolbar/div[1]/div[2]/button");
        public static Element addNewFNOLButton => new Element("/html/body/bh-app/mat-sidenav-container/mat-sidenav-content/div/bh-manager-dashboard/div/div[2]/button");
    }
}
