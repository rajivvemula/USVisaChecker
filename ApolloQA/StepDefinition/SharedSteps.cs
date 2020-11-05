using System;
using TechTalk.SpecFlow;
using ApolloQA.Pages;
namespace ApolloQA.StepDefinition
{
    [Binding]
    public class SharedSteps
    {
        [When(@"user clicks (.*) Button")]
        public void WhenUserClicksButton(string buttonName)
        {
            Shared.GetButton(buttonName).Click();
        }
    }
}
