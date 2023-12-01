using System;
using ApolloQAAutomation.Pages;
using HitachiQA.Driver;
using HitachiQA.Helpers;
using TechTalk.SpecFlow;

namespace ApolloQAAutomation.StepDefinition
{
    [Binding]
    public sealed class Apollo_GeneralUISteps
    {      
        [Given(@"user is successfully logged into Apollo")]
        public void GivenUserIsSuccessfullyLoggedIntoApollo()
        {
            var userName = Environment.GetEnvironmentVariable("ApolloUsername");
            var password = Environment.GetEnvironmentVariable("TestPassword2");
            var url = Environment.GetEnvironmentVariable("APOLLO_HOST");

            UserActions.Navigate(url);
            Apollo_LoginPage.UsernameTextField.SetText(userName);

            //Next button
            Apollo_LoginPage.SubmitButton.Click();
            UserActions.WaitForNetworkIdle();
            Apollo_LoginPage.PasswordTextField.SetText(password);

            //Sign in button
            Apollo_LoginPage.SubmitButton.Click();

            //Yes (stay signed in)
            if (Apollo_LoginPage.SubmitButton.GetAttribute("value") == "Sign in")
            {
                throw new Exception($"Sign In Failed, UI Message: {Apollo_LoginPage.PasswordError.GetElementText()}");
            }
            Apollo_LoginPage.SubmitButton.Click();
        }

        [Then(@"user see the Apollo HomePage")]
        public void ThenUserSeeTheApolloHomePage()
        {
            AutomationHelper.ValidateElements(Apollo_HomePage.HeaderElements);
        }

    }
}
