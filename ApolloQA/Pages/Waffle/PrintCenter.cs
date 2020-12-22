using System;
using System.Collections.Generic;
using System.Text;
using ApolloQA.Source.Driver;
using ApolloQA.Source.Helpers;
using ApolloQA.Pages;

namespace ApolloQA.Pages
{
    class PrintCenter
    {

        public static Element WaffleMenuOptionPrintCenter => new Element("//a[@href='/print-center']");
        public static Element PrintCenterDashboard = new Element("//*[contains(text(), ' Dashboard ')]");
        public static Element PrintCenterHeader = new Element("//*[contains(text(), 'Print Center')]");
        public static Element PrintCenterGridLastItem => new Element("(//div[@class='datatable-row-center datatable-row-group ng-star-inserted'])[last()] //*[@role='button']");
        public static Element PrintCenterGridLastItemRelease = new Element ("(//div[@class='datatable-row-center datatable-row-group ng-star-inserted'])[last()] //datatable-body-cell[4]/div/a");
       //This element is used for both schedule and cancelschedule
        public static Element PrintCenterGridLastItemScheduleORCancelSche = new Element("(//div[@class='datatable-row-center datatable-row-group ng-star-inserted'])[last()] //datatable-body-cell[5]/div/a");

        public static Element PrintCenterGridJobSchedulePopupTime = new Element("//mat-dialog-container //bh-schedule-printing //div //form //mat-form-field[2]//*/input");
        public static Element PrintCenterPopupSchedulebutton = new Element("//mat-dialog-container //bh-schedule-printing //div //form //section //button[1] //span[1]");
        public static Element PrintCenterNotes = new Element("(//div[@class='datatable-row-center datatable-row-group ng-star-inserted'])[last()] //datatable-body-cell[6]/div/span");

        public static Element PrintCenterJobQueueHeader = new Element("//div[@class='print-center-job-queue-container']//h2");
        public static Element PrintCenterJobQueueLastItemRelease = new Element("(//div[@class='datatable-row-center datatable-row-group ng-star-inserted'])[last()] //datatable-body-cell[5]/div/a");
        public static Element PrintCenterJobQueueLastItemHoldOrStopHold = new Element("(//div[@class='datatable-row-center datatable-row-group ng-star-inserted'])[last()] //datatable-body-cell[6]/div/a");
        public static Element PrintCenterJobQueueLastItemDelete = new Element("(//div[@class='datatable-row-center datatable-row-group ng-star-inserted'])[last()] //datatable-body-cell[7]/div/a");
        public static Element toastMessage => new Element("//div[@class='toast-content']/descendant::*");


    }

}
