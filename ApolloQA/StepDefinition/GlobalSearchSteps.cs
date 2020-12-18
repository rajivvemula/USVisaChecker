using ApolloQA.Pages;
using ApolloQA.Source.Driver;
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
                    GlobalSearch.SearchResult.assertElementIsVisible();
                    var EntityType = GlobalSearch.SearchResultLabel.GetElementText();
                    Assert.TextContains(EntityType, "Policy");
                    break;
                case "ENTITYNAME":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("Policy 10130-167");
                    GlobalSearch.SearchResult.assertElementIsVisible();
                    var EntityName = GlobalSearch.SearchResultLabel.GetElementText();
                    Assert.TextContains(EntityName, "Policy 10130-167");
                    break;
                case "ENTITYNUMBER":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("10130-167");
                    GlobalSearch.SearchResult.assertElementIsVisible();
                    var EntityNumber = GlobalSearch.SearchResultLabel.GetElementText();
                    Assert.TextContains(EntityNumber, "10130-167");
                    break;
                case "TYPEDESCRIPTION":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("Claim");
                    GlobalSearch.SearchResult.assertElementIsVisible();
                    var TypeDescription = GlobalSearch.SearchResultLabel.GetElementText();
                    Assert.TextContains(TypeDescription, "FNOL");
                    break;
                case "STATUSDESCRIPTION":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("Policy");
                    GlobalSearch.SearchResult.assertElementIsVisible();
                    var StatusDescription = GlobalSearch.SearchResultDescription.GetElementText();
                    Assert.TextContains(StatusDescription, "Pre-Submission");
                    break;
                case "SOURCESYSTEM":
                    // This search should always be null
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("Policy");
                    GlobalSearch.SearchResult.assertElementIsVisible();
                    var sourceSystem = GlobalSearch.SearchResultDescription.GetElementText();
                    Assert.AreNotEqual(sourceSystem, "SourceSystem");
                    var systemSource = GlobalSearch.SearchResultLabel.GetElementText();
                    Assert.AreNotEqual(systemSource, "SourceSystem");
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("SourceSystem");
                    GlobalSearch.NoResultsFound.assertElementIsVisible();
                    break;
                case "POLICYHOLDERNAME":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("a master organization");
                    GlobalSearch.SearchResult.assertElementIsVisible();
                    var policyNameHolder = GlobalSearch.SearchResultLabel.GetElementText();
                    Assert.TextContains(policyNameHolder, "Agency A Master Organization");
                    var policyHolderName = GlobalSearch.SearchResultDescription.GetElementText();
                    Assert.TextContains(policyHolderName, "Organization");
                    break;
                case "AGENCYORGANIZATION":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("Acme Agency Child");
                    GlobalSearch.SearchResult.assertElementIsVisible();
                    var agencyOrganization = GlobalSearch.SearchResultLabel.GetElementText();
                    Assert.TextContains(agencyOrganization, "Agency Ace Agency");
                    break;
                case "CARRIERORGANIZATION":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("Berkshire Hathaway Direct Insurance Company");
                    GlobalSearch.SearchResult.assertElementIsVisible();
                    var carrierOrganization = GlobalSearch.SearchResultDescription.GetElementText();
                    Assert.TextContains(carrierOrganization, "Berkshire Hathaway Direct Insurance Company");
                    break;
                case "UNDERWRITERNAME":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("ApolloTestUserG301");
                    GlobalSearch.SearchResult.assertElementIsVisible();
                    var underwriterName = GlobalSearch.SearchResultLabel.GetElementText();
                    Assert.TextContains(underwriterName, "FNOL");
                    break;
                case "ADJUSTERNAME":
                    // Should always return null
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("Adjuster");
                    GlobalSearch.NoResultsFound.assertElementIsVisible();
                    break;
                case "TAXIDLASTFOUR":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("9824");
                    GlobalSearch.SearchResult.assertElementIsVisible();
                    var taxID = GlobalSearch.SearchResultLabel.GetElementText();
                    Assert.AreNotEqual(taxID, "Insured Smoke Test407");
                    break;
                case "VALIDPOLICYNUMBER":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("10130-167");
                    GlobalSearch.SearchResult.assertElementIsVisible();
                    var policyNumber = GlobalSearch.SearchResultLabel.GetElementText();
                    Assert.TextContains(policyNumber, "Policy 10130-167");
                    break;
                case "VALIDQUOTENUMBER":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("10028");
                    GlobalSearch.SearchResult.assertElementIsVisible();
                    var quoteNumber = GlobalSearch.SearchResultLabel.GetElementText();
                    Assert.TextContains(quoteNumber, "Quote 10028");
                    break;
                case "VALIDCLAIMNUMBER":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("100009");
                    GlobalSearch.SearchResult.assertElementIsVisible();
                    var claimNumber = GlobalSearch.SearchResultLabel.GetElementText();
                    Assert.TextContains(claimNumber, "FNOL 100009");
                    break;
                default:
                    throw new Exception($"Search Text {SearchText} not found.");
            }
        }
    }
}
