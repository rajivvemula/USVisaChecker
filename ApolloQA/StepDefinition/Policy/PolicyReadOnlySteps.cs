using ApolloQA.Pages;
using ApolloQA.Source.Driver;
using System;
using System.Diagnostics;
using TechTalk.SpecFlow;

namespace ApolloQA.StepDefinition.Policy
{
    [Binding]
    public class PolicyReadOnlySteps
    {

        public static Data.Entity.Policy _pol;
        public static Data.Entity.Policy _polCan;

        [When(@"user clicks on (.*) Sidetab")]
        public void WhenUserClicksOnSidetab(string sidetab)
        {
            Shared.GetLeftSideTab(sidetab).Click();
            Shared.GetButton("Continue anyway").TryClick(1);
        }

        [When(@"User Navigates to Policy latest issued")]
        public void WhenUserNavigatesToPolicyLatestIssued()
        {
            _pol = Data.Entity.Policy.GetLatestPolicy();
            long policyNumber = _pol.Id;

            UserActions.Navigate($"/policy/{policyNumber}");
        }


        [Then(@"User verifies that inputs are disabled and no text can be entered in (.*)")]
        public void ThenUserVerifiesThatInputsAreDisabledAndNoTextCanBeEnteredInBusinessInformation(string tab)
        {
            switch (tab)
            {
                case "Business Information":
                    
                    foreach (string item in businessInfo)
                    {
                        string value = Shared.GetInputField(item).GetAttribute("readonly");
                        Assert.TextContains(value, "true");
                        Log.Info(value);
                    }
                    
                    //Assert.IsTrue(MODFactor);
                    break;
                case "Operations":
                    CheckInputCheckox();
                    break;
                case "Policy Coverages":

                    CheckInputCheckox();
                    CheckInputSelects();
                    break;
                case "Modifiers":

                    CheckInputCheckox();
                    //Factors
                    var factorList = new Element("//input [@maxlength = '6']").GetIsDisabledBulk();
                    Log.Info(factorList);
                    factorList.ForEach(x => Assert.IsTrue(x));
                    //Justification
                    var justList = new Element("//mat-label[normalize-space(text())='Justification']/../../preceding-sibling::input").GetIsDisabledBulk();
                    Log.Info(justList);
                    justList.ForEach(x => Assert.IsTrue(x));
                    break;
                case "Summary":

                    CheckInputCheckox();
                    break;
                default:
                    break;


            }
        }

        ////mat-checkbox 

        [Then(@"User verifies no buttons are enabled in (.*)")]
        public void ThenUserVerifiesNoButtonsAreEnabledInBusinessInformation(string tab)
        {
            switch (tab)
            {
                case "Business Information":
                    bool MODFactor = new Element("//button[./*[normalize-space(text())='Save']]").assertElementIsPresent();
                    Assert.IsTrue(MODFactor);
                    break;
                default:
                    bool elementSave = new Element("//button[./*[normalize-space(text())='Save']]").assertElementNotPresent();
                    Assert.IsTrue(elementSave);
                    bool elementNext = new Element("//button[./*[normalize-space(text())='Next']]").assertElementNotPresent();
                    Assert.IsTrue(elementSave);
                    break;
                    

            }
        }

        
        [Then(@"User verifies that ellipsis does not contain editable options")]
        public void ThenUserVerifiesThatEllipsisDoesNotContainEditableOptions()
        {
            Home.ellipsisButton.Click();
            Element MODFactor = new Element("//div [@class='cdk-overlay-container']//div//div/div//div");
            string checkEdit = MODFactor.GetInnerText();
            bool containedit = checkEdit.Contains("Edit");
            Assert.IsFalse(containedit);
            

        }
        
        [Then(@"User verifies that ellipsis does not contain deleteable options")]
        public void ThenUserVerifiesThatEllipsisDoesNotContainDeleteableOptions()
        {
            Element MODFactor = new Element("//div [@class='cdk-overlay-container']//div//div/div//div");
            string checkEdit = MODFactor.GetInnerText();
            bool containedit = checkEdit.Contains("Delete");
            Assert.IsFalse(containedit);
        }
        
        [Then(@"User selects different mailing address option")]
        public void ThenUserSelectsDifferentMailingAddressOption()
        {
            Shared.GetCheckbox("Select if Separate Mailing Address").Click();
        }
        
        [Then(@"User verifies that dropdown is interactable and contains Add Address Button")]
        public void ThenUserVerifiesThatDropdownIsInteractableAndContainsAddAddressButton()
        {
            Shared.GetDropdownField("Mailing Address").Click();
            Shared.GetButton("Add Address").assertElementIsVisible();
        }

        [Then(@"User verify contact button is present")]
        public void ThenUserVerifyContactButtonIsPresent()
        {
            bool MODFactor = new Element("//button[./*[normalize-space(text())='Contact']]").assertElementIsPresent();
            Assert.IsTrue(MODFactor);
            Shared.GetButton("Contact").Click();
            Shared.GetInputField("Notes").setText("Test");
            string noteText = Shared.GetInputField("Notes").GetInnerText();
        }

        string[] businessInfo = { "Line of Business", "Producer", "Effective Date", "Named Insured", 
            "Organization Type", "Tax ID Type", "Business Email Address", "Business Phone No", "Business Website", "Keyword", "Class Taxonomy", "Year Business Started", "Year Ownership Started" };

        public void CheckInputCheckox() {

            var checkboxesList = new Element("//*[@class = 'mat-radio-outer-circle']").GetIsDisabledBulk();
            Log.Info(checkboxesList);
            checkboxesList.ForEach(x => Assert.IsFalse(x));

        }
        public void CheckInputSelects()
        {

            var checkboxesList = new Element("//mat-checkbox").GetIsDisabledBulk();
            Log.Info(checkboxesList);
            checkboxesList.ForEach(x => Assert.IsFalse(x));

        }

    }
}
