using ApolloQA.Data.Entity;
using ApolloQA.Pages;
using ApolloQA.Source.Driver;
using ApolloQA.Source.Helpers;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace ApolloQA.StepDefinition
{
    [Binding]
    public class GlobalSearchSteps
    {
        public IWebDriver driver;

        public GlobalSearchSteps(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        [Given(@"user validates search for '(.*)'")]
        public void GivenUserValidatesSearchFor(string SearchText)
        {
            switch (SearchText.ToUpper())
            {
                case "ENTITYTYPE":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("Policy");
                    GlobalSearch.SearchResult.WaitUntilClickable();
                    GlobalSearch.GetResultText("Policy").assertElementIsVisible();
                    break;
                case "ENTITYNAME":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    var policy = Data.Entity.Policy.GetLatestPolicy();
                    GlobalSearch.SearchInput.setText($"Policy {policy.PolicyNumber}");
                    GlobalSearch.SearchResult.WaitUntilClickable();
                    GlobalSearch.GetResultText($"Policy {policy.PolicyNumber}").assertElementIsVisible();
                    break;
                case "ENTITYNUMBER":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("0010001-01-CA");
                    GlobalSearch.SearchResult.WaitUntilClickable();
                    GlobalSearch.GetResultText("0010001-01-CA").assertElementIsVisible();
                    break;
                case "TYPEDESCRIPTION":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("Claim 0010001-01-CA");
                    GlobalSearch.SearchResult.WaitUntilClickable();
                    GlobalSearch.GetResultText("Claim").assertElementIsVisible();
                    break;
                case "STATUSDESCRIPTION":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("Policy");
                    GlobalSearch.SearchResult.WaitUntilClickable();
                    if (GlobalSearch.GetResultText("Issued - biBERK").assertElementIsVisible(10, true) == false)
                    {
                        GlobalSearch.GetResultText("Cancelled - biBERK").assertElementIsVisible();
                    }
                    break;
                case "SOURCESYSTEM":
                    // This search should always be null
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("SourceSystem");
                    GlobalSearch.GetResultText("SourceSystem").assertElementNotPresent(5, true);
                    GlobalSearch.NoResultsFound.WaitUntilClickable();
                    GlobalSearch.NoResultsFound.assertElementIsVisible();
                    break;
                case "POLICYHOLDERNAME":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("Alex Towing Services");
                    GlobalSearch.SearchResult.WaitUntilClickable();
                    GlobalSearch.GetResultText("Alex Towing Services").assertElementIsVisible();
                    break;
                case "AGENCYORGANIZATION":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("biBERK");
                    GlobalSearch.SearchResult.WaitUntilClickable();
                    GlobalSearch.GetResultText("biBERK").assertElementIsVisible();
                    break;
                case "CARRIERORGANIZATION":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("Berkshire Hathaway Direct Insurance Company");
                    GlobalSearch.SearchResult.WaitUntilClickable();
                    GlobalSearch.GetResultText("Berkshire Hathaway Direct Insurance Company").assertElementIsVisible();
                    break;
                case "UNDERWRITERNAME":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("ApolloTestUserG301");
                    GlobalSearch.SearchResult.WaitUntilClickable();
                    GlobalSearch.GetResultText("FNOL").assertElementIsVisible();
                    break;
                case "ADJUSTERNAME":
                    // Should always return null
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("Adjuster");
                    try { GlobalSearch.NoResultsFound.assertElementIsVisible(); }
                    catch { GlobalSearch.GetResultText("Organization").assertElementIsVisible(); }
                    break;
                case "TAXIDLASTFOUR":
                    UserActions.Refresh();
                    var org = Organization.GetLatestOrganization();
                    org.TaxId = ("33-" + Functions.GetRandomInteger(10000000).ToString());
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText(org.TaxId);
                    GlobalSearch.SearchResult.WaitUntilClickable();
                    GlobalSearch.GetResultText("Organization").assertElementIsVisible();
                    break;
                case "VALIDPOLICYNUMBER":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    var PolNum = Data.Entity.Policy.GetLatestPolicy();
                    GlobalSearch.SearchInput.setText($"{PolNum.PolicyNumber}");
                    GlobalSearch.SearchResult.assertElementIsVisible();
                    GlobalSearch.SearchResult.WaitUntilClickable();
                    GlobalSearch.GetResultText("Policy").assertElementIsVisible();
                    break;
                case "VALIDQUOTENUMBER":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    var Quote = Data.Entity.Quote.GetLatestQuote();
                    GlobalSearch.SearchInput.setText(Quote.ApplicationNumber);
                    GlobalSearch.SearchResult.WaitUntilClickable();
                    GlobalSearch.GetResultText($"Quote {Quote.ApplicationNumber}").assertElementIsVisible();
                    break;
                case "VALIDCLAIMNUMBER":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("Claim");
                    GlobalSearch.SearchResult.WaitUntilClickable();
                    GlobalSearch.GetResultText("Claim").assertElementIsVisible();
                    break;
                case "VALIDFNOLNUMBER":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("Fnol");
                    GlobalSearch.SearchResult.WaitUntilClickable();
                    GlobalSearch.GetResultText("FNOL").assertElementIsVisible();
                    break;
                default:
                    throw new Exception($"Search Text {SearchText} not found.");
            }
        }
    }
}
