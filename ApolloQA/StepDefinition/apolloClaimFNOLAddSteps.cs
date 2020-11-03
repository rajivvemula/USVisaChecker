using ApolloQA.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ApolloQA.StepDefinition
{
    [Binding]
    public sealed class apolloClaimFNOLAddSteps
    {
        public IWebDriver driver;


        apolloClaimFNOLAddSteps(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        [Then(@"user verifies '(.*)' is not an option")]
        public void ThenUserVerifiesIsNotAnOption(string text)
        {
            Occurrence.howWasNoticeReceivedDropdown.Click();
            Occurrence.receivedByCarrierPigeonOption.assertElementIsVisible();
            //will need to be "assertElementNotVisible" when option is removed
        }
    }
}
