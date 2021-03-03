using ApolloQA.Data.Entity;
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
                    var policy = Policy.GetLatestPolicy();
                    GlobalSearch.SearchInput.setText($"Policy {policy.PolicyNumber}");
                    GlobalSearch.SearchResult.assertElementIsVisible();
                    var EntityName = GlobalSearch.SearchResultLabel.GetElementText();
                    Assert.TextContains(EntityName, $"Policy {policy.PolicyNumber}");
                    break;
                case "ENTITYNUMBER":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("0010001-01-CA");
                    GlobalSearch.SearchResult.assertElementIsVisible();
                    var EntityNumber = GlobalSearch.SearchResultLabel.GetElementText();
                    Assert.TextContains(EntityNumber, "0010001-01-CA");
                    break;
                case "TYPEDESCRIPTION":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("Claim");
                    GlobalSearch.SearchResult.assertElementIsVisible();
                    var TypeDescription = GlobalSearch.SearchResultLabel.GetElementText();
                    Assert.SoftAreEqual(TypeDescription, "Claim 0010001-01-CA");
                    break;
                case "STATUSDESCRIPTION":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("Policy");
                    GlobalSearch.SearchResult.assertElementIsVisible();
                    var StatusDescription = GlobalSearch.SearchResultDescription.GetElementText();
                    switch (StatusDescription)
                    {
                        case "Issued - biBERK":
                            Assert.TextContains(StatusDescription, "Issued - biBERK");
                            break;
                        case "Bound - biBERK":
                            Assert.TextContains(StatusDescription, "Bound - biBERK");
                            break;
                        case "Cancelled - biBERK":
                            Assert.TextContains(StatusDescription, "Cancelled - biBERK");
                            break;
                    }
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
                    var OrgName = Organization.GetLatestOrganization();
                    GlobalSearch.SearchInput.setText($"{OrgName.Name}");
                    GlobalSearch.SearchResult.assertElementIsVisible();
                    var policyNameHolder = GlobalSearch.SearchResultLabel.GetElementText();
                    Assert.TextContains(policyNameHolder, $"{OrgName.Name}");
                    var policyHolderName = GlobalSearch.SearchResultDescription.GetElementText();
                    Assert.TextContains(policyHolderName, "Organization");
                    break;
                case "AGENCYORGANIZATION":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("biBERK");
                    GlobalSearch.SearchResult.assertElementIsVisible();
                    var agencyOrganization = GlobalSearch.SearchResultLabel.GetElementText();
                    Assert.TextContains(agencyOrganization, "biBERK");
                    break;
                case "CARRIERORGANIZATION":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText("Berkshire Hathaway Direct Insurance Company");
                    GlobalSearch.SearchResult.assertElementIsVisible();
                    var carrierOrganization = GlobalSearch.SearchResultLabel.GetElementText();
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
                    var org = Organization.GetLatestOrganization();
                    GlobalSearch.SearchInput.clearTextField();
                    GlobalSearch.SearchInput.setText(org.TaxId.Substring(6, 4));
                    GlobalSearch.SearchResult.assertElementIsVisible();
                    var name = GlobalSearch.SearchResultLabel.GetElementText();
                    Assert.TextContains(name, $"{org.Name}");
                    break;
                case "VALIDPOLICYNUMBER":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    var PolNum = Policy.GetLatestPolicy();
                    GlobalSearch.SearchInput.setText($"{PolNum.PolicyNumber}");
                    GlobalSearch.SearchResult.assertElementIsVisible();
                    var Entity = GlobalSearch.SearchResultLabel.GetElementText();
                    Assert.TextContains(Entity, $"{PolNum.PolicyNumber}");
                    break;
                case "VALIDQUOTENUMBER":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    var Quote = Data.Entity.Quote.GetLatestQuote();
                    GlobalSearch.SearchInput.setText(Quote.ApplicationNumber);
                    GlobalSearch.SearchResult.assertElementIsVisible();
                    var quoteNumber = GlobalSearch.SearchResultLabel.GetElementText();
                    Assert.TextContains(quoteNumber, $"Quote {Quote.ApplicationNumber}");
                    break;
                case "VALIDCLAIMNUMBER":
                    UserActions.Refresh();
                    GlobalSearch.SearchInput.clearTextField();
                    var claim = Data.Entity.Claim.GetClaim();
                    GlobalSearch.SearchInput.setText($"{claim.ClaimNumber}");
                    GlobalSearch.SearchResult.assertElementIsVisible();
                    var claimNumber = GlobalSearch.SearchResultLabel.GetElementText();
                    Assert.TextContains(claimNumber, $"Claim {claim.ClaimNumber}");
                    break;
                default:
                    throw new Exception($"Search Text {SearchText} not found.");
            }
        }
    }
}
