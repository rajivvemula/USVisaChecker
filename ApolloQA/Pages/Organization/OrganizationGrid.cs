using ApolloQA.Source.Driver;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages
{
    class OrganizationGrid
    {
        public static Element addNewButton => new Element("/html/body/bh-app/mat-sidenav-container/mat-sidenav-content/div/bh-organization-list/div/div/button");
    }
}
