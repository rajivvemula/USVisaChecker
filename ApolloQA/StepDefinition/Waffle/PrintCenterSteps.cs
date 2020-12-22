using TechTalk.SpecFlow;
using ApolloQA.Source.Helpers;
using System;
using Azure;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;

namespace ApolloQA.Features.Waffle

{
    [Binding]
    public class PrintCenterSteps
    {

        public IWebDriver driver;

        PrintCenterSteps(IWebDriver _driver)
        {
            this.driver = _driver;
        }


        public string QA2baseURL = "https://bibaoqa2-printermanagementfunction.azurewebsites.net/api/printer/queue/job";
        public string QA2Bodydata = "{\"printerQueueId\":2000," + "\"documentId\":10013," + "\"pageCount\":2," + "\"isHeld\":false}";
        public string QA1baseURL = "https://bibaoqa-printermanagementfunction.azurewebsites.net/api/printer/queue/job";
        public string QA1Bodydata = "{\"printerQueueId\":9001," + "\"documentId\":10789," + "\"pageCount\":2," + "\"isHeld\":false}";

        JObject JsonData = new JObject();

        [When(@"User adds data to printcenter queue")]
        public void WhenUserAddsDataToPrintcenterQueue()
        {

            String URL = driver.Url;
            if (URL.Contains("bibaoqa2-printermanagementfunction"))
            {
                JsonData = JObject.Parse(QA2Bodydata);
                dynamic response = RestAPI.POST(QA2baseURL, JsonData);
                Console.WriteLine("response:" + response);
            }

            if (URL.Contains("bibaoqa-printermanagementfunction"))
            {
                JsonData = JObject.Parse(QA1Bodydata);
                dynamic response = RestAPI.POST(QA1baseURL, JsonData);
                Console.WriteLine("response:" + response);
            }


        }

       [When(@"user navigates to Printcenter Page by accessing Waffle")]
        public void WhenUserNavigatesToPrintcenterPageByAccessingWaffle()
        {
            Pages.Home.WaffleGridButton.Click();

    }

        [When(@"User Clicks Print Center Link")]
        public void WhenUserClicksPrintCenterLink()
        {
            Pages.PrintCenter.WaffleMenuOptionPrintCenter.Click();
        }
        
        [Then(@"User should be redirected to Print Center Page")]
        public void ThenUserShouldBeRedirectedToPrintCenterPage()
        {
            Pages.PrintCenter.PrintCenterHeader.assertElementInnerTextEquals("Print Center");
        }
        
        [Then(@"User Clicks on the Last Queue name in Print Center table")]
        public void ThenUserClicksOnTheLastQueueNameInPrintCenterTable()
        {
            Pages.PrintCenter.PrintCenterGridLastItem.Click();
        }

        [Then(@"User should see all the job associated to this Queue")]
        public void ThenUsershouldseeallthejobassociatedtothisQueue()
        {
            string text = Pages.PrintCenter.PrintCenterJobQueueHeader.GetElementText();
            Console.WriteLine(text);

        }
        [Then(@"User clicks Dashboard")]
        public void ThenUserClicksDashboard()
        {
            Pages.PrintCenter.PrintCenterDashboard.Click();
        }

        [Then(@"User clicks Schedule link from the last queue name")]
        public void ThenUserClicksScheduleLinkFromTheLastQueueName()
        {
            Pages.PrintCenter.PrintCenterGridLastItemScheduleORCancelSche.Click();
        }

        [Then(@"User Enter time on schedule pop-up")]
        public void ThenUserEnterTimeOnSchedulePop_Up()
        {
            Pages.PrintCenter.PrintCenterGridJobSchedulePopupTime.setText("10:10AM");
        }

        [Then(@"User Click Schedule button")]
        public void ThenUserClickScheduleButton()
        {
            Pages.PrintCenter.PrintCenterPopupSchedulebutton.Click();
            System.Threading.Thread.Sleep(2000);
            var toastMessage = Pages.Quote.Quote_Create_Page.toastMessage.GetInnerText();
            Assert.TextContains(toastMessage, "updated");
            //Console.WriteLine(toastMessage);
        }

        [Then(@"User Verifies the notes")]
         public void ThenUserVerifiesTheNotes()
         {
            string Notes = Pages.PrintCenter.PrintCenterNotes.GetElementText();
            Console.WriteLine(Notes);
            System.Threading.Thread.Sleep(2000);
        }

        [Then(@"User clicks Cancel Schedule link from the last queue name")]
        public void ThenUserClicksCancelScheduleLinkFromTheLastQueueName()
        {
            Pages.PrintCenter.PrintCenterGridLastItemScheduleORCancelSche.Click();
            System.Threading.Thread.Sleep(2000);
            var toastMessage = Pages.Quote.Quote_Create_Page.toastMessage.GetInnerText();
            Assert.TextContains(toastMessage, "cancelled");
        }

        [Then(@"User clicks Release button from the last queue name")]
         public void ThenUserClicksReleaseButtonFromTheLastQueueName()
         {
             Pages.PrintCenter.PrintCenterJobQueueLastItemRelease.Click();
            var toastMessage = Pages.Quote.Quote_Create_Page.toastMessage.GetInnerText();
            Assert.TextContains(toastMessage, "released");
            System.Threading.Thread.Sleep(2000);
        }

        [Then(@"User Click Delete button from the last queue name")]
        public void ThenUserClickDeleteButtonFromTheLastQueueName()
        {
            Pages.PrintCenter.PrintCenterJobQueueLastItemDelete.Click();
            var toastMessage = Pages.Quote.Quote_Create_Page.toastMessage.GetInnerText();
            Assert.TextContains(toastMessage, "deleted");
        } 

        [Then(@"User Clicks Hold link")]
        public void ThenUserClicksHoldLink()
        {
            Pages.PrintCenter.PrintCenterJobQueueLastItemHoldOrStopHold.Click();
            var toastMessage = Pages.Quote.Quote_Create_Page.toastMessage.GetInnerText();
            Assert.TextContains(toastMessage, "held");
            System.Threading.Thread.Sleep(2000);
        }

        [Then(@"User verifies link renamed to Stop Hold")]
        public void ThenUserVerifiesLinkRenamedToStopHold()
        {
            Pages.PrintCenter.PrintCenterJobQueueLastItemHoldOrStopHold.assertElementInnerTextEquals("Stop Hold");       
          
        }

         [Then(@"User clicks Stop Hold link")]
         public void ThenUserClicksStopHoldLink()
         {
            Pages.PrintCenter.PrintCenterJobQueueLastItemHoldOrStopHold.Click();
        }

        [Then(@"User Verifies link renamed to Hold")]
         public void ThenUserVerifiesLinkRenamedToHold()
         {
            Pages.PrintCenter.PrintCenterJobQueueLastItemHoldOrStopHold.assertElementInnerTextEquals("Hold");
            var toastMessage = Pages.Quote.Quote_Create_Page.toastMessage.GetInnerText();
            Assert.TextContains(toastMessage, "removed from hold");
        } 



    }
}

