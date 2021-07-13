using ApolloQA.Pages;
using ApolloQA.Source.Helpers;
using Entity_Quote = ApolloQA.Data.Entity.Quote;
using Entity_Tether = ApolloQA.Data.Entity.Tether;
using System;
using TechTalk.SpecFlow;
using ApolloQA.Source.Driver;

namespace ApolloQA.StepDefinition.Quote
{
    [Binding]
    public class Qoute_NCFSteps
    {

        long quoteTetherID;
        int NCFRequestID;
        string creditScore;

        [When(@"User selects latest Quote through API")]
        public void WhenUserSelectsLatestQuoteThroughAPI()
        {
            var QuotedQUote = Functions.GetQuotedQuoteThroughAPI();

            Log.Info(QuotedQUote.Id);
            var TetherIDQuote = Entity_Tether.GetTether(QuotedQUote.Id);
            Log.Info(TetherIDQuote.Id);
            quoteTetherID = TetherIDQuote.Id;
            
            UserActions.Navigate($"quote/{QuotedQUote.Id}/section/9000");
        }


        [When(@"User enters contact information for NCF")]
        public void WhenUserEntersContactInformationForNCF()
        {

            Shared.GetField("First Name", "input").setText("Caldwell");
            Shared.GetField("Last Name", "input").setText("Cahill");
            Shared.GetField("Address 1", "input").setText("763 E AUTUMN FIELD DR");
            Shared.GetField("City", "input").setText("Sandy");
            Shared.GetDropdownField("State").SelectMatDropdownOptionByText("UT");
            Shared.GetField("Zip", "input").setText("84094");

        }
        
        [Then(@"User Verify CosmosDB contains a record within Ncfrequest")]
        public void ThenUserVerifyCosmosDBContainsARecordWithinNcfrequest()
        {
            var NCFiD = Entity_Quote.GetNCFRequest(quoteTetherID);
            Log.Info(NCFiD);
            NCFRequestID = NCFiD;

        }
        
        [Then(@"User Verify CosmosDB contains a record within Ncfresponse")]
        public void ThenUserVerifyCosmosDBContainsARecordWithinNcfresponse()
        {
            var incomingResponse = Entity_Quote.GetNCFRResponse(NCFRequestID);
            Log.Info(incomingResponse);
            creditScore = incomingResponse;



        }

        [Then(@"User verifies that A credit score is displayed in Business Information")]
        public void ThenUserVerifiesThatACreditScoreIsDisplayedInBusinessInformation()
        {
            Element cardContent = new Element($"//mat-card-content[text()=' Score: {creditScore} ']");
            bool checkScoreDisplayed = cardContent.assertElementIsVisible();
            Assert.IsTrue(checkScoreDisplayed);
        }


        //Summary > Rating Worksheet > Insurance Score Tier Factor > 

        [Then(@"User Verify correct score is displayed in rating worksheet")]
        public void ThenUserVerifyCorrectScoreIsDisplayedInRatingWorksheet()
        {

            string currentHandle = Setup.driver.CurrentWindowHandle;
            Log.Info(currentHandle);
            Setup.driver.SwitchTo().Window(Setup.driver.WindowHandles[1]);
            var detailButton = new Element("//span[@title='Insurance Score Tier Factor']/../../../datatable-body-cell[5]//button[1]");
            bool detailButtonCheck =  detailButton.assertElementIsPresent();
            if (detailButtonCheck)
            {
                 detailButton.Click();
            }




            
            Element altAB = new Element("//div[@class='cdk-overlay-container']//*/span[text()='InsuranceScoreTier']//..//../following-sibling::datatable-body-cell//div//span");
            string AbValue = altAB.GetElementText();
            Assert.TextContains(AbValue, "AB");

            Log.Info(Assert.AreNotEqual("ABNH", AbValue));
            Assert.AreNotEqual("ABNH", AbValue);
        }

    }
}
