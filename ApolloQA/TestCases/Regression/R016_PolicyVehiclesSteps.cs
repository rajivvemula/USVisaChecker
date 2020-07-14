using ApolloQA.Pages.Policy;
using ApolloQA.Pages.Shared;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ApolloQA.TestCases.Regression
{
    [Binding]
    public class R016_PolicyVehiclesSteps
    {

        public IWebDriver driver;
        PolicyMain policyMain;
        AddVehicle addVehicle;
        PolicyVehicle policyVehicle;

        public R016_PolicyVehiclesSteps(IWebDriver Driver)
        {
            driver = Driver;
            policyMain = new PolicyMain(Driver);
            addVehicle = new AddVehicle(Driver);
            policyVehicle = new PolicyVehicle(Driver);
        }

        [When(@"User Click on Add New Vehicle")]
        public void WhenUserClickOnAddNewVehicle()
        {
            policyVehicle.ClickNewVehicle();
        }
        
        [When(@"User enter (.*) for (.*)")]
        public void WhenUserEnterForVIN(string value, string input)
        {
            addVehicle.EnterInput(input, value);
        }
        
        [When(@"User clicks on (.*) in Add New Vehicle Modal")]
        public void WhenUserClicksOnStateInAddNewVehicleModal(string select)
        {
            addVehicle.ClickSelect(select);
        }

        [When(@"User inputs a class, appropriate values are seen")]
        public void WhenUserInputsAClassAppropriateValuesAreSeen(Table table)
        {
            var detail = table.CreateDynamicSet();
            foreach (var details in detail)
            {
                addVehicle.EnterInput("Code", details.Code.ToString());
                addVehicle.inputCode.SendKeys(Keys.Enter);
                string valueCode = addVehicle.GetValue("Code");
                Assert.AreEqual(valueCode, details.Value.ToString());
                string valueGroup = addVehicle.GetValue("Rating Group");
                Assert.AreEqual(valueGroup, details.Group);
                string valuePlan = addVehicle.GetValue("Rating Plan");
                Assert.AreEqual(valuePlan, details.Plan);
                string valueLimit = addVehicle.GetValue("Limit");
                Assert.AreEqual(valueLimit, details.Limit);

            }
        }


        [Then(@"User is shown the Add New Vehicle Modal")]
        public void ThenUserIsShownTheAddNewVehicleModal()
        {
            bool title = policyVehicle.CheckModalTitle();
            Assert.IsTrue(title);
        }
        
        [Then(@"User should see (.*) For that (.*)")]
        public void ThenUserShouldSeeForThatVIN(string value, string input)
        {
            string verifyValue = addVehicle.GetValue(input);
            Assert.AreEqual(verifyValue, value);
        }
        
        [Then(@"User is required to have values for the (.*) as (.*)")]
        public void ThenUserIsRequiredToHaveValuesForTheVINAsTrue(string input, string required)
        {
            string verifyReq = addVehicle.GetRequired(input);
            Assert.AreEqual(verifyReq, required);
        }
        
        [Then(@"User should see all values to be present in (.*)")]
        public void ThenUserShouldSeeAllValuesToBePresentInState(string select)
        {
            foreach (string i in addVehicle.dropValues[select])
            {
                bool verifyRole = addVehicle.CheckDropDownValue(i);
                Assert.AreEqual(verifyRole, true);
            }
        }
        
        [Then(@"User is required to have Select values for the (.*) as (.*)")]
        public void ThenUserIsRequiredToHaveValuesForTheState(string select, string required)
        {
            string verifyReq = addVehicle.GetSelectRequired(select);
            Assert.AreEqual(verifyReq, required);
        }
    }
}
