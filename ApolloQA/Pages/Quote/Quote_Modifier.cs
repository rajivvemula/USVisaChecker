using ApolloQA.Source.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Quote
{
    class Quote_Modifier
    {
        public static Element MODExp = new Element("//mat-card[*/*/*/h2[text()='Experience Rating']] //div[@class='factor'][2] //input");
        public static Element MODMan = new Element("//mat-card[*/*/*/h2[text()='Management']] //div[@class='factor'][2] //input");
        public static Element MODEmp = new Element("//mat-card[*/*/*/h2[text()='Employees']] //div[@class='factor'][2] //input");
        public static Element MODEquip = new Element("//mat-card[*/*/*/h2[text()='Equipment']] //div[@class='factor'][2] //input");
        public static Element MODSafety = new Element("//mat-card[*/*/*/h2[text()='Safety Organization']] //div[@class='factor'][2] //input");
        public static Element MODClass = new Element("//mat-card[*/*/*/h2[text()='Classification']] //div[@class='factor'][2] //input");
        public static Element MODTotal = new Element("//div[@class='question-text-total'] /..//div[@class='factor'][3]");
    }
}
