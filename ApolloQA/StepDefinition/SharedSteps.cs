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

        [When(@"user clicks '(.*)' icon button")]
        public void WhenUserClicksIconButton(string iconButton)
        {
            Shared.GetIconButton(iconButton).Click();
        }

        [When(@"user clicks (.*) right menu button")]
        public void WhenUserClicksRightMenuButton(string rightMenuButton)
        {
            Shared.GetRightSideTab(rightMenuButton).Click();
        }
    }
}
