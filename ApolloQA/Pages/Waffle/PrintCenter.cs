using System;
using System.Collections.Generic;
using System.Text;
using ApolloQA.Source.Driver;
using ApolloQA.Source.Helpers;

namespace ApolloQA.Pages
{
    class PrintCenter
    {

        public static Element WaffleMenuOptionPrintCenter => new Element("//a[@href='/print-center']");
        public static Element PrintCenterGridLastItem => new Element("(//div[@class='datatable-row-center datatable-row-group ng-star-inserted'])[last()] //*[@role='button']");

    }
}
