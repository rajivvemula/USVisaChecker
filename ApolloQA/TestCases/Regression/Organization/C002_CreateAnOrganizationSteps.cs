using ApolloQA.DataFiles;
using ApolloQA.Helpers;
using ApolloQA.Pages.Organization;
using ApolloQA.Pages.Shared;
using ApolloQA.Workflows;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ApolloQA.TestCases.Regression.Organization
{
    [Binding]
    public class C002_CreateAnOrganizationSteps
    {
        private IWebDriver driver;
        CreateOrganization createOrg;
        Random rnd;
        State state;
        OrganizationInformation organizationInformation;

        string orgName;
        string taxName;

        public C002_CreateAnOrganizationSteps(IWebDriver driver, State state)
        {
            this.driver = driver;
            this.state = state;
            createOrg = new CreateOrganization(driver);
            rnd = new Random();
            organizationInformation = new OrganizationInformation(driver);
        }

        [When(@"User creates an Organization")]
        public void WhenUserCreatesAnOrganization(Table table)
        {
            

            var details = table.CreateDynamicSet();
            foreach (var detail in details)
            {
                
                if(detail.Name == "Smoke Test")
                {
                    string orgRND = rnd.Next(100, 900).ToString();
                    orgName = detail.Name + orgRND;
                } else { orgName = detail.Name; };
                
                if(detail.TaxIDNo = "Random")
                {
                    string taxRND = rnd.Next(100, 900).ToString();
                    taxName = "12-4489" + taxRND;
                } else { taxName = detail.TaxIDNo.ToString(); };


                createOrg.NewOrg(
                    orgName,
                    detail.DBA,
                    detail.BusPhone.ToString(),
                    detail.BusEmail,
                    detail.BusWeb,
                    detail.YearStart.ToString(),
                    detail.YearOwn.ToString(),
                    detail.OrgType,
                    detail.TaxType,
                    detail.Keyword,
                    taxName
                    );
                state.createdOrgName = orgName;
                state.createOrgsList.Add(new IOrganization()
                {
                    Name = orgName,
                    DBA = detail.DBA,
                    BusPhone = detail.BusPhone.ToString(),
                    BusEmail = detail.BusEmail,
                    BusWeb = detail.BusWeb,
                    YearStart =  detail.YearStart.ToString(),
                    YearOwn = detail.YearOwn.ToString(),
                    OrgType = detail.OrgType,
                    TaxType = detail.TaxType,
                    Keyword = detail.Keyword,
                    TaxIdNo = taxName

                });
                state.taxName = taxName;
            }
        }

        [Then(@"Verify organization is created")]
        public void ThenVerifyOrganizationIsCreated()
        {
            Assert.That(() => driver.Title, Does.Contain("Organization Details").After(3).Seconds.PollEvery(250).MilliSeconds, "Organization was not created");
            Assert.That(() => organizationInformation.inputName.Text, Does.Contain(state.createdOrgName).After(3).Seconds.PollEvery(250).MilliSeconds, "Organization was not created");

        }

    }
}
