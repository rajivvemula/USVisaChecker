using TechTalk.SpecFlow;
using ApolloQA.Source.Helpers;
using ApolloQA.Source.Driver;
namespace ApolloQA.Features.Waffle

{
    [Binding]
    public class PrintCenterSteps
    {
        public string Header = "Print Center";

        [When(@"user navigates to Printcenter Page by accessing Waffle")]
        public void WhenUserNavigatesToPrintcenterPageByAccessingWaffle()
        {
           // System.Threading.Thread.Sleep(1000);
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
            Pages.PrintCenter.PrintCenterHeader.assertElementInnerTextEquals(Header);
        }
        
        [Then(@"User Clicks on the Last Queue name in Print Center table")]
        public void ThenUserClicksOnTheLastQueueNameInPrintCenterTable()
        {
            Pages.PrintCenter.PrintCenterGridLastItem.Click();
            Pages.PrintCenter.PrintCenterDashboard.Click();
        }

        /*[Then(@"User should see all the job associated to this Queue")]
        public void ThenUserShouldSeeAllTheJobAssociatedToThisQueue()
        {
            ScenarioContext.Current.Pending();
        }*/
    }
}
