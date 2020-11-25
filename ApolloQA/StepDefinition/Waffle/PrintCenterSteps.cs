using TechTalk.SpecFlow;
using ApolloQA.Source.Helpers;
using ApolloQA.Source.Driver;
namespace ApolloQA.Features.Waffle

{
    [Binding]
    public class PrintCenterSteps
    {
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
            Pages.PrintCenter.PrintCenterGridLastItem.Click();
        }
        
        /*[Then(@"User should be redirected to Print Center Page")]
        public void ThenUserShouldBeRedirectedToPrintCenterPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"User Clicks on the Last Queue name in Print Center table")]
        public void ThenUserClicksOnTheLastQueueNameInPrintCenterTable()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"User should see all the job associated to this Queue")]
        public void ThenUserShouldSeeAllTheJobAssociatedToThisQueue()
        {
            ScenarioContext.Current.Pending();
        }*/
    }
}
