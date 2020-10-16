using ApolloQA.DataFiles;
using ApolloQA.Helpers;
using ApolloQA.Pages.Application;
using ApolloQA.Pages.Shared;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression.Application
{
    [Binding]
    public class D003_ApplicationInformationSteps
    {
        private IWebDriver driver;
        Buttons button;
        Components components;
        Inputs inputs;
        BusinessInformation busInfo;
        State state;



        public D003_ApplicationInformationSteps(IWebDriver driver, State state)
        {
            this.driver = driver;
            this.state = state;
            button = new Buttons(driver);
            components = new Components(driver);
            busInfo = new BusinessInformation(driver);
            inputs = new Inputs(driver);
        }

        [Then(@"Verify organization (.*) has correct values in business information")]
        public void ThenVerifyOrganizationHasCorrectValues(string orgName)
        {
            int index = state.createOrgsList.FindIndex(a => a.Name.Contains(orgName));
            Assert.That(() => busInfo.businessName.GetAttribute("value"), Does.Contain(state.createOrgsList[index].Name).After(3).Seconds.PollEvery(250).MilliSeconds, "Organization Name is not matching");
            Assert.That(() => busInfo.selectOrgType.GetAttribute("value"), Does.Contain(state.createOrgsList[index].OrgType).After(3).Seconds.PollEvery(250).MilliSeconds, "Organization Type is not matching");
            Assert.That(() => busInfo.inputTaxType.GetAttribute("value"), Does.Contain(state.createOrgsList[index].TaxType).After(3).Seconds.PollEvery(250).MilliSeconds, "Organization Tax Type is not matching");
            Assert.That(() => busInfo.taxNo.GetAttribute("value"), Does.Contain(state.createOrgsList[index].TaxIdNo).After(3).Seconds.PollEvery(250).MilliSeconds, "Organization Tax No is not matching");
            Assert.That(() => busInfo.inputBusPhone.GetAttribute("value"), Does.Contain(state.createOrgsList[index].BusPhone).After(3).Seconds.PollEvery(250).MilliSeconds, "Organization Phone is not matching");
            Assert.That(() => busInfo.inputBusWebsite.GetAttribute("value"), Does.Contain(state.createOrgsList[index].BusWeb).After(3).Seconds.PollEvery(250).MilliSeconds, "Organization website is not matching");
            Assert.That(() => busInfo.inputBusEmail.GetAttribute("value"), Does.Contain(state.createOrgsList[index].BusEmail).After(3).Seconds.PollEvery(250).MilliSeconds, "Organization email is not matching");
            Assert.That(() => busInfo.inputYearStart.GetAttribute("value"), Does.Contain(state.createOrgsList[index].YearStart).After(3).Seconds.PollEvery(250).MilliSeconds, "Organization Year Start is not matching");
            Assert.That(() => busInfo.inputYearOwn.GetAttribute("value"), Does.Contain(state.createOrgsList[index].YearOwn).After(3).Seconds.PollEvery(250).MilliSeconds, "Organization Year Own is not matching");
        }
    }
}
