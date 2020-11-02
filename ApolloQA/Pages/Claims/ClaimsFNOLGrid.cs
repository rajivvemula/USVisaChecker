using ApolloQA.Source.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages
{
    class ClaimsFNOLGrid
    {
        public static Element managerDashboardButton => new Element("//*//mat-sidenav-container//*//div[1]/div[1]/button");
        public static Element AdjusterDasbhoardButton => new Element("//*//mat-sidenav-container//*//div[1]/div[2]/button");
        public static Element addNewFNOLButton => new Element("//button[@type='button' and @aria-label='New FNOL']");
    }
}
