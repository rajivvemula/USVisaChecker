using ApolloQA.Helpers;
using ApolloQA.Pages.Organization;
using ApolloQA.Pages.Shared;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ApolloQA.Workflows
{
    class CreateOrganization
    {
        private IWebDriver driver;
        Buttons button;
        MainNavBar mainNavBar;
        OrganizationGrid organizationGrid;
        OrganizationInsert organizationInsert;
        Components helper;

        public CreateOrganization(IWebDriver driver)
        {
            this.driver = driver;
            button = new Buttons(driver);
            mainNavBar = new MainNavBar(driver);
            organizationGrid = new OrganizationGrid(driver);
            organizationInsert = new OrganizationInsert(driver);
            helper = new Components(driver);
        }

        public void NewOrg(string orgName, string dba, string phone, string email, string web, string yearS, string yearO, string corp, string taxType, string keyword, string taxid )
        {
            mainNavBar.ClickOrganizationTab();
            //Assert.IsTrue(driver.Title.Contains("Insert Organization"), "Didn't get to Insert Organization Screen");
            Assert.That(() => driver.Title, Is.EqualTo("Organization").After(3).Seconds.PollEvery(250).MilliSeconds, "Didn't get to Insert Organization Screen");
            //Click New Button
            organizationGrid.ClickNewButton();
            Assert.That(() => driver.Title, Is.EqualTo("Insert Organization").After(3).Seconds.PollEvery(250).MilliSeconds, "Unable To Click New Button");



            //Input
            helper.EnterInput(organizationInsert.inputName, orgName);
            helper.EnterInput(organizationInsert.inputDBA, dba);
            helper.EnterInput(organizationInsert.inputBusPhone, phone);
            helper.EnterInput(organizationInsert.inputBusEmail, email);
            helper.EnterInput(organizationInsert.inputBusWeb, web);
            helper.EnterInput(organizationInsert.inputYearStarted, yearS);
            helper.EnterInput(organizationInsert.inputYearOwnsership, yearO);
            helper.EnterSelect(organizationInsert.selectOrgType, corp);
            helper.EnterSelect(organizationInsert.selectTaxType, taxType);
            helper.EnterInput(organizationInsert.keywordCode, keyword);
            organizationInsert.keywordCode.SendKeys(Keys.Enter);
            helper.EnterInput(organizationInsert.inputTaxID, taxid);

            Thread.Sleep(3000);

            organizationInsert.ClickSubmitButton();

        }
    }
}
