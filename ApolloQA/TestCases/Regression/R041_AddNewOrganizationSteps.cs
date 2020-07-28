using ApolloQA.Pages.Organization;
using ApolloQA.Pages.Shared;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ApolloQA.TestCases.Regression
{
    [Binding]
    public class R041_AddNewOrganizationSteps
    {

        private IWebDriver driver;
        MainNavBar mainNavBar;
        OrganizationGrid organizationGrid;
        OrganizationInsert organizationInsert;
        Toaster toaster;

        public R041_AddNewOrganizationSteps(IWebDriver driver)
        {
            this.driver = driver;
            mainNavBar = new MainNavBar(driver);
            organizationGrid = new OrganizationGrid(driver);
            organizationInsert = new OrganizationInsert(driver);
            toaster = new Toaster(driver);
        }
        [When(@"I user enter all info into Organization Insert")]
        public void WhenIUserEnterAllInfoIntoOrganizationInsert(Table table)
        {
            var detail = table.CreateDynamicSet();
            foreach (var details in detail)
            {
                organizationInsert.EnterInput("name", details.Name);
                organizationInsert.EnterInput("dba", details.DBA);
                organizationInsert.EnterInput("businessphone", details.Phone.ToString());
                organizationInsert.EnterInput("businessemail", details.Email);
                organizationInsert.EnterInput("businesswebsite", details.Website);
                organizationInsert.EnterInput("yearstarted", details.YearStarted.ToString());
                organizationInsert.EnterInput("yearownership", details.YearOwnership.ToString());
                organizationInsert.EnterSelect("orgtype", details.OrgType);
                organizationInsert.EnterSelect("taxtype", details.TaxType);
                organizationInsert.EnterInput("taxid", details.TaxNo.ToString());
                organizationInsert.EnterSelect("industrytype", details.IndustryType);
                organizationInsert.EnterSelect("subtype", details.SubType);
                organizationInsert.EnterSelect("class", details.Class);
            }
        }
        
        [Then(@"Organization with those inputs is added and confirmed via toast")]
        public void ThenOrganizationWithThoseInputsIsAddedAndConfirmedViaToast()
        {
            organizationInsert.ClickSubmitButton();
        }
    }
}

/*
case "name": return inputName;
                case "dba": return inputDBA;
                case "taxid": return inputTaxID;
                case "businessphone": return inputBusPhone ;
                case "businessemail": return inputBusEmail;
                case "businesswebsite": return inputBusWeb;
                case "description": return inputDesc;
                case "yearstarted": return inputYearStarted;
                case "yearownership": return inputYearOwnsership;
                case "orgtype": return selectOrgType;
                case "taxtype": return selectTaxType;
                case "industrytype": return selectIndustryType;
                case "subtype": return selectSubType;
                case "class": return selectClass;
                default: return null;
| Name             | DBA  | OrgType     | TaxType | TaxNo      | Phone        | Email                 | Website    | IndustryType | SubType   | Class      | YearStarted | YearOwnership | Desc    |

*/