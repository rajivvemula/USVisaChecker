﻿using ApolloQA.Source.Driver;

namespace ApolloQA.Pages
{
    class OrganizationGrid
    {
        public static Element addNewButton => new Element("//button[@aria-label='Add Master Organization']");
        public static Element skipToLastButton => new Element("//a[@role='button' and @aria-label='go to last page']");
        public static Element theTestOrg => new Element("//span[@title='TheTestOrg' and contains(text(), 'TheTestOrg')]");
        public static Element theTestOrgId => new Element("(//div[@class='datatable-row-center datatable-row-group ng-star-inserted'])[last()] //*[@role='button']");
        public static Element gridButton => new Element("(//button[@class='mat-focus-indicator mat-menu-trigger grid-more-button mat-icon-button mat-button-base'])[1]");
        public static Element gridDeleteButton = new Element("//button[@role='menuitem' and contains(text(), 'Delete')]");
        public static Element confirmGridDeleteButton = new Element("//button[@color='warn']");
    }
}
