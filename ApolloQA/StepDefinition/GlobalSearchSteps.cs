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
                    GlobalSearch.GetResultText("Policy").assertElementIsVisible();
                    break;
                case "ENTITYNAME":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    var policy = Data.Entity.Policy.GetLatestPolicy();
                    GlobalSearch.SearchInput.setText($"Policy {policy.PolicyNumber}");
                    GlobalSearch.GetResultText($"Policy {policy.PolicyNumber}").assertElementIsVisible();
                    break;
                case "ENTITYNUMBER":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("0010001-01-CA");
                    GlobalSearch.GetResultText("0010001-01-CA").assertElementIsVisible();
                    break;
                case "TYPEDESCRIPTION":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("Claim 0010001-01-CA");
                    GlobalSearch.GetResultText("Claim").assertElementIsVisible();
                    break;
                case "STATUSDESCRIPTION":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("Policy");
                    if(GlobalSearch.GetResultText("Issued - biBERK").assertElementIsVisible(10, true) == false)
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
                    GlobalSearch.NoResultsFound.assertElementIsVisible();
                    break;
                case "POLICYHOLDERNAME":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("Alex Towing Services");
                    GlobalSearch.GetResultText("Alex Towing Services").assertElementIsVisible();
                    break;
                case "AGENCYORGANIZATION":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("biBERK");
                    GlobalSearch.GetResultText("biBERK").assertElementIsVisible();
                    break;
                case "CARRIERORGANIZATION":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("Berkshire Hathaway Direct Insurance Company");
                    GlobalSearch.GetResultText("Berkshire Hathaway Direct Insurance Company").assertElementIsVisible();
                    break;
                case "UNDERWRITERNAME":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("ApolloTestUserG301");
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
                    GlobalSearch.GetResultText("Organization").assertElementIsVisible();
                    break;
                case "VALIDPOLICYNUMBER":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    var PolNum = Data.Entity.Policy.GetLatestPolicy();
                    GlobalSearch.SearchInput.setText($"{PolNum.PolicyNumber}");
                    GlobalSearch.SearchResult.assertElementIsVisible();
                    GlobalSearch.GetResultText("Policy").assertElementIsVisible();
                    break;
                case "VALIDQUOTENUMBER":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    var Quote = Data.Entity.Quote.GetLatestQuote();
                    GlobalSearch.SearchInput.setText(Quote.ApplicationNumber);
                    GlobalSearch.GetResultText($"Quote {Quote.ApplicationNumber}").assertElementIsVisible();
                    break;
                case "VALIDCLAIMNUMBER":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("Claim");
                    GlobalSearch.GetResultText("Claim").assertElementIsVisible();
                    break;
                case "VALIDFNOLNUMBER":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("Fnol");
                    GlobalSearch.GetResultText("FNOL").assertElementIsVisible();
                    break;
                default:
                    throw new Exception($"Search Text {SearchText} not found.");
            }
        }
    }
}
