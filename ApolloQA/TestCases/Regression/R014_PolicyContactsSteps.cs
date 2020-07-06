using ApolloQA.Pages.Policy;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace ApolloQA.TestCases.Regression
{
    [Binding]
    public class R014_PolicyContactsSteps
    {

        public IWebDriver driver;
        PolicyContacts policyContacts;
        PolicyMain policyMain;

        public R014_PolicyContactsSteps(IWebDriver Driver)
        {
            driver = Driver;
            policyContacts = new PolicyContacts(Driver);
            policyMain = new PolicyMain(Driver);
        }

        [Given(@"User is shown the Contact Insert screen")]
        public void GivenUserIsShownTheContactInsertScreen()
        {
            //string breadCrumb = policyMain.CheckLastBreadCrumb("Insert");
            //Assert.AreEqual(breadCrumb, "Insert");
        }
        
        [When(@"User Click Add New Contact Button")]
        public void WhenUserClickAddNewContactButton()
        {
            policyContacts.ClickAddContact();
        }
        
        [When(@"User selects the contact party role dropdown")]
        public void WhenUserSelectsTheContactPartyRoleDropdown()
        {
            policyContacts.partyRole.Click();
        }
        
        [When(@"User inputs value in First Name")]
        public void WhenUserInputsValueInFirstName()
        {
            policyContacts.EnterFirstName("testFirst");
        }
        
        [When(@"User inputs value in Middle Name")]
        public void WhenUserInputsValueInMiddleName()
        {
            policyContacts.EnterMiddleName("testMiddle");
        }
        
        [When(@"User inputs value in Last Name")]
        public void WhenUserInputsValueInLastName()
        {
            policyContacts.EnterLastName("testLast");
        }
        
        [When(@"User inputs value in Suffix Name")]
        public void WhenUserInputsValueInSuffixName()
        {
            policyContacts.EnterSuffixName("testSuffix");
        }
        
        [When(@"User inputs value in Email Name")]
        public void WhenUserInputsValueInEmailName()
        {
            
            policyContacts.EnterEmail("test@gmail.com");
        }
        
        [When(@"User inputs value in non valid Email Name")]
        public void WhenUserInputsValueInNonValidEmailName()
        {
            policyContacts.inputEmail.Clear();
            policyContacts.EnterEmail("testgmail");
        }
        
        [When(@"User inputs value in Job Title")]
        public void WhenUserInputsValueInJobTitle()
        {
            policyContacts.EnterJobTitle("testJob");
        }
        
        [When(@"User inputs value in Company")]
        public void WhenUserInputsValueInCompany()
        {
            policyContacts.EnterCompany("testCompany");
        }
        
        [When(@"User inputs value in Internet Address")]
        public void WhenUserInputsValueInInternetAddress()
        {
            policyContacts.EnterInternet("testAdd");
        }
        
        [When(@"User inputs value in Remarks")]
        public void WhenUserInputsValueInRemarks()
        {
            policyContacts.EnterRemarks("testRemark");
        }
        
        [When(@"User selects the contact Phone Type dropdown")]
        public void WhenUserSelectsTheContactPhoneTypeDropdown()
        {
            //ScenarioContext.Current.Pending();
        }
        
        [When(@"User inputs value in Phone Number")]
        public void WhenUserInputsValueInPhoneNumber()
        {
            policyContacts.EnterPhoneNumber("1231231234");
        }
        
        [When(@"User inputs value in a letter in Phone Number Input")]
        public void WhenUserInputsValueInALetterInPhoneNumberInput()
        {
            policyContacts.inputPhoneNumber.Clear();
            policyContacts.EnterPhoneNumber("ABC");
        }
        
        [Then(@"User is shown the Contact Insert Screen")]
        public void ThenUserIsShownTheContactInsertScreen()
        {
            //string breadCrumb = policyMain.CheckLastBreadCrumb("Insert");
            //Assert.AreEqual(breadCrumb, "Insert");
        }
        
        [Then(@"Expected input labels for Contact Insert are there")]
        public void ThenExpectedInputLabelsForContactInsertAreThere()
        {
            foreach (string i in policyContacts.contactLabels)
            {
                bool verifyRole = policyContacts.CheckLabel(i);
                Assert.AreEqual(verifyRole, true);
            }
        }
        
        [Then(@"User is shown all the values for Contact Party Role dropdown")]
        public void ThenUserIsShownAllTheValuesForContactPartyRoleDropdown()
        {
            foreach (string i in policyContacts.partyDropDownValues)
            {
                bool verifyRole = policyContacts.CheckDropDownValue(i);
                Assert.AreEqual(verifyRole, true);
            }
        }
        
        [Then(@"Contact party role select is a required value")]
        public void ThenContactPartyRoleSelectIsARequiredValue()
        {
            string aria = policyContacts.partyRole.GetAttribute("aria-required");
            Assert.AreEqual(aria, "true");
        }
        
        [Then(@"First Name Input accepts the value")]
        public void ThenFirstNameInputAcceptsTheValue()
        {
            string value = policyContacts.GetFirstName();
            Assert.AreEqual(value, "testFirst");
        }
        
        [Then(@"First Name input is a required value")]
        public void ThenFirstNameInputIsARequiredValue()
        {
            string aria = policyContacts.inputFirstName.GetAttribute("aria-required");
            Assert.AreEqual(aria, "true");
        }
        
        [Then(@"Middle Name Input accepts the value")]
        public void ThenMiddleNameInputAcceptsTheValue()
        {
            string value = policyContacts.GetMiddleName();
            Assert.AreEqual(value, "testMiddle");
        }
        
        [Then(@"Last Name Input accepts the value")]
        public void ThenLastNameInputAcceptsTheValue()
        {
            string value = policyContacts.GetLastName();
            Assert.AreEqual(value, "testLast");
        }
        
        [Then(@"Last Name input is a required value")]
        public void ThenLastNameInputIsARequiredValue()
        {
            string aria = policyContacts.inputLastName.GetAttribute("aria-required");
            Assert.AreEqual(aria, "true");
        }
        
        [Then(@"Suffix Name Input accepts the value")]
        public void ThenSuffixNameInputAcceptsTheValue()
        {
            string value = policyContacts.GetSuffixName();
            Assert.AreEqual(value,"testSuffix");
        }
        
        [Then(@"Email Name Input accepts the value")]
        public void ThenEmailNameInputAcceptsTheValue()
        {
            string value = policyContacts.GetEmail();
            Assert.AreEqual(value, "test@gmail.com");
        }
        
        [Then(@"Email Name input is a required value")]
        public void ThenEmailNameInputIsARequiredValue()
        {
            string aria = policyContacts.inputEmail.GetAttribute("aria-required");
            Assert.AreEqual(aria, "true");
        }
        
        [Then(@"Email is invalid error is shown")]
        public void ThenEmailIsInvalidErrorIsShown()
        {
            bool verifyValue = policyContacts.CheckEmailError();
            Assert.IsTrue(verifyValue);
        }
        
        [Then(@"Job Title Input accepts the value")]
        public void ThenJobTitleInputAcceptsTheValue()
        {
            string value = policyContacts.GetJobTitle();
            Assert.AreEqual(value, "testJob");
        }
        
        [Then(@"Company Input accepts the value")]
        public void ThenCompanyInputAcceptsTheValue()
        {
            string value = policyContacts.GetCompany();
            Assert.AreEqual(value, "testCompany");
        }
        
        [Then(@"Internet Address Input accepts the value")]
        public void ThenInternetAddressInputAcceptsTheValue()
        {
            string value = policyContacts.GetInternet();
            Assert.AreEqual(value, "testAdd");
        }
        
        [Then(@"Remarks Input accepts the value")]
        public void ThenRemarksInputAcceptsTheValue()
        {
            string value = policyContacts.GetRemarks();
            Assert.AreEqual(value, "testRemark");
        }
        
        [Then(@"User is shown all the values for Phone Type dropdown")]
        public void ThenUserIsShownAllTheValuesForPhoneTypeDropdown()
        {
            //ScenarioContext.Current.Pending();
        }
        
        [Then(@"Verify Phone Type select is a required value")]
        public void ThenVerifyPhoneTypeSelectIsARequiredValue()
        {
            //ScenarioContext.Current.Pending();
        }
        
        [Then(@"Phone Number Input accepts the value")]
        public void ThenPhoneNumberInputAcceptsTheValue()
        {
            string value = policyContacts.GetPhoneNumber();
            Assert.AreEqual(value, "(123) 123-1234");
        }
        
        [Then(@"Phone Number Input is blank")]
        public void ThenPhoneNumberInputIsBlank()
        {
            string value = policyContacts.GetPhoneNumber();
            Assert.AreEqual(value, "(___) ___-____");
        }
    }
}
