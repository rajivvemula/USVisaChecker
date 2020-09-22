using ApolloQA.DataFiles;
using ApolloQA.Helpers;
using ApolloQA.Pages.Fnol;
using ApolloQA.Pages.Shared;
using Microsoft.Azure.Cosmos;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ApolloQA.TestCases.Regression.FNOL
{
    [Binding]
    public class F002_CreateAnFNOLSteps
    {
        private IWebDriver driver;
        Random rnd;
        State state;
        MainNavBar mainNavBar;
        FNOLInsert fnolInsert;
        Components helper;
        Toaster toaster;
        Cosmos cosmos;

        
        public F002_CreateAnFNOLSteps(IWebDriver driver, State state, CosmosClient cosmosClient)
        {
            this.driver = driver;
            this.state = state;
            rnd = new Random();
            mainNavBar = new MainNavBar(driver);
            fnolInsert = new FNOLInsert(driver);
            helper = new Components(driver);
            toaster = new Toaster(driver);
            cosmos = new Cosmos(cosmosClient);
        }

        [When(@"User creates a FNOL")]
        public void WhenUserCreatesAFNOL(Table table)
        {
            string FirstName = "";
            string LastName = "";
            //Navigate Home and CLick Add New FNol Via Navbar
            mainNavBar.HomeIcon.Click();
            Assert.That(() => driver.Title, Does.Contain("Home").After(3).Seconds.PollEvery(250).MilliSeconds, "Unable To Navigate To Home");
            mainNavBar.AddIcon.Click();
            mainNavBar.addFnolButton.Click();
            Assert.That(() => driver.Title, Does.Contain("Insert First Notice of Loss").After(3).Seconds.PollEvery(250).MilliSeconds, "Unable To Click Add New FNOl Button In Navbar/Navigate to FNOL Insert");
            
            var details = table.CreateDynamicSet();
            foreach (var detail in details)
            {
                helper.EnterSelect(fnolInsert.receivedSelect, detail.Received);
                helper.EnterSelect(fnolInsert.relatedClaim, detail.Related);
                helper.EnterInput(fnolInsert.inputFirstName, detail.First);
                helper.EnterInput(fnolInsert.inputLastName, detail.Last);
                helper.EnterInput(fnolInsert.inputSuffixName, detail.Suffix);
                helper.EnterInput(fnolInsert.inputEmail, detail.Email);
                helper.EnterSelect(fnolInsert.phoneSelect, detail.PhoneType);
                helper.EnterInput(fnolInsert.inputPhoneNumber, detail.PhoneNumber.ToString());
                helper.EnterSelect(fnolInsert.claimCategory, detail.ClaimCategory);
                helper.EnterInput(fnolInsert.lossDescInput, detail.LossDesc);
                fnolInsert.sameAsCheckbox.Click();
                helper.EnterSelect(fnolInsert.policeInvolved, detail.Police);
                helper.EnterInput(fnolInsert.policeName, detail.PoliceName);
                helper.EnterInput(fnolInsert.policeNumber, detail.PoliceNumber.ToString());
                helper.EnterSelect(fnolInsert.fireInvolved, detail.Fire);
                helper.EnterInput(fnolInsert.fireName, detail.FireName);
                helper.EnterInput(fnolInsert.fireNumber, detail.FireNumber.ToString());

                FirstName = detail.First;
                LastName = detail.Last;
            }

            Assert.That(() => fnolInsert.inputFirstName.GetAttribute("value"), Does.Contain(FirstName).After(3).Seconds.PollEvery(250).MilliSeconds, "Unable to enter correct First Name");
            Assert.That(() => fnolInsert.inputLastName.GetAttribute("value"), Does.Contain(LastName).After(1).Seconds.PollEvery(250).MilliSeconds, "Unable to enter correct Last Name");

            fnolInsert.submitButton.Click();
        }
        
        [Then(@"Verify FNOL is created")]
        public async Task ThenVerifyFNOLIsCreatedAsync()
        {
            string createdClaimID;
            string verifyToast = toaster.GetToastTitle();
            Assert.That(verifyToast, Does.Contain("was successfully saved."), "FNOL was not created");
            string[] words = verifyToast.Split(' ');
            string claimNumber = words[1].Substring(1, 6);
            createdClaimID = claimNumber;
            string verifyCosmosClaim = "SELECT * FROM c WHERE c.ClaimNumber = '" + createdClaimID + "'";
            bool IDFound = await cosmos.GetQuery("Claim", verifyCosmosClaim);
            Console.WriteLine(IDFound);
            Assert.IsTrue(IDFound, "A matching claim was not found in cosmos db");
        }
    }
}
