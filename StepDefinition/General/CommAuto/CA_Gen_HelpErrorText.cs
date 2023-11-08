using BiBerkLOB.Pages.CommAuto;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using BiBerkLOB.Pages;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation.Models;
using HitachiQA.Driver;
using HitachiQA.Helpers;
using TechTalk.SpecFlow;
using System.Xml.Linq;
using Microsoft.Azure.Cosmos;

namespace BiBerkLOB.StepDefinition.General.CommAuto;

[Binding]
public sealed class CA_Gen_HelpErrorText
{
    private const string ERROR_TYPE = "Error";
    private const string HELP_TYPE = "Help";
    private readonly CAHelpAndErrorAutomation _automation;

    public CA_Gen_HelpErrorText(CAHelpAndErrorAutomationFactory factory)
    {
        _automation = factory.CreateAutomation();
    }

    [Then(@"user verifies the help and error text of the Start Your Quote page")]
    public void ThenUserVerifiesTheHelpAndErrorTextOfTheStartYourQuotePage()
    {
        CA_PreIntroductionPage.AnotherNameYes.Click();
        CA_PreIntroductionPage.LetsGoCTA.Click();
        CA_PreIntroductionPage.NameOfBusinessError.AssertElementIsVisible();
        CA_PreIntroductionPage.AnotherNameHelper.Click();
        CA_PreIntroductionPage.AnotherNameHelperText.AssertElementIsVisible();
        CA_PreIntroductionPage.AnotherNameHelperX.Click();
        CA_PreIntroductionPage.OtherBusinessNameError.AssertElementIsVisible();
        CA_PreIntroductionPage.PleaseFixErrorTxt.AssertElementIsVisible();
        CA_PreIntroductionPage.OneOrMoreQuestionsTxt.AssertElementIsVisible();
    }

    [Then(@"user verifies each help and error element on the CA Operations page for the following questions:")]
    public void ThenUserVerifiesHelpAndErrorText(Table helpAndErrorTable)
    {
        CA_OperationsPage.LetsContinueCTA.Click();
        CA_OperationsPage.PleaseFixErrors.AssertElementIsVisible();
        CA_OperationsPage.OneOrMoreInvalid.AssertElementIsVisible();

        var selectors = new HelpAndErrorSelectors()
        {
            ErrorTextSelector = CA_OperationsPage.GetErrorText,
            HelpIconSelector = CA_OperationsPage.GetHelpIcon,
            HelpTextSelector = CA_OperationsPage.GetHelpText,
            HelpExitSelector = CA_OperationsPage.GetHelpX,
        };
        VerifyHelpAndErrorTable(helpAndErrorTable, selectors);
    }

    [Then(@"user verifies the focus on the first error from the Operations Page")]
    public void ThenUserVerifiesTheFocusOnTheFirstErrorFromTheOperationsPage()
    {
        CA_OperationsPage.LetsContinueCTA.Click();
        CA_OperationsPage.FirstErrorMsg.AssertIsElementVisibleInViewport();
    }

    [Then(@"user verifies the following front end help and error text of the Vehicle Page:")]
    public void ThenUserVerifiesTheFollowingHelpAndErrorTextOfTheVehiclePage(Table helpAndErrorTable)
    {
        CA_VehiclesPage.LetsContinueCTA.Click();
        CA_VehiclesPage.PleaseFixFollowingError.AssertElementIsVisible();
        CA_VehiclesPage.OneOrMoreQuestionError.AssertElementIsVisible();

        var selectors = new HelpAndErrorSelectors()
        {
            ErrorTextSelector = CA_VehiclesPage.GetFrontEndErrorText,
            HelpIconSelector = CA_VehiclesPage.GetFrontEndHelpIcon,
            HelpTextSelector = CA_VehiclesPage.GetFrontEndHelpText,
            HelpExitSelector = CA_VehiclesPage.GetFrontEndHelpExit
        };
        VerifyHelpAndErrorTable(helpAndErrorTable, selectors);
    }

    [Then(@"user verifies the following Apollo help and error text of the Vehicle Page:")]
    public void ThenUserVerifiesTheFollowingApolloHelpAndErrorTextOfTheVehiclePage(Table helpAndErrorTable)
    {
        CA_VehiclesPage.LetsContinueCTA.Click();
        CA_VehiclesPage.PleaseFixFollowingError.AssertElementIsVisible();
        CA_VehiclesPage.OneOrMoreQuestionError.AssertElementIsVisible();

        var selectors = new HelpAndErrorSelectors()
        {
            ErrorTextSelector = CA_VehiclesPage.GetApolloErrorText,
            HelpIconSelector = CA_VehiclesPage.GetApolloHelpIcon,
            HelpTextSelector = CA_VehiclesPage.GetApolloHelpText,
            HelpExitSelector = CA_VehiclesPage.GetApolloHelpExit
        };
        VerifyHelpAndErrorTable(helpAndErrorTable, selectors);
    }

    [Then(@"user verifies each error element on the CA Driver Incidents page for the following questions:")]
    public void ThenUserVerifiesIncidentsErrorText(Table errorTable)
    {
        CA_DriverIncidentsPage.LetsContinueCTA.Click();
        CA_DriverIncidentsPage.PleaseFixErrors.AssertElementIsVisible();
        CA_DriverIncidentsPage.OneOrMoreInvalid.AssertElementIsVisible();

        // intended to find error elements on first incident panel
        var selectors = new HelpAndErrorSelectors()
        {
            ErrorTextSelector = alias => CA_DriverIncidentsPage.ApolloErrorText(alias, 0)
        };
        VerifyErrorText(errorTable.Rows.Select(row => row["Question Alias"]), selectors);
    }

    [Then(@"user verifies each help element on the CA Driver Incidents page for the following questions:")]
    public void ThenUserVerifiesIncidentsHelpText(Table helpTable)
    {
        CA_DriversPage.LetsContinueCTA.Click();
        CA_DriversPage.PleaseFixErrors.AssertElementIsVisible();
        CA_DriversPage.OneOrMoreInvalid.AssertElementIsVisible();
        // intended to find error elements on first incident panel
        var selectors = new HelpAndErrorSelectors()
        {
            HelpIconSelector = alias => CA_DriverIncidentsPage.ApolloHelpIcon(alias, 0),
            HelpTextSelector = alias => CA_DriverIncidentsPage.ApolloHelpText(alias, 0),
            HelpExitSelector = alias => CA_DriverIncidentsPage.ApolloHelpX(alias, 0)
        };
        VerifyHelpText(helpTable.Rows.Select(row => row["Question Alias"]), selectors);
    }

    [Then(@"user verifies the following front end help and error element on the CA Drivers page:")]
    public void ThenUserVerifiesFEDriversErrorText(Table helpAndErrorTable)
    {
        CA_DriversPage.LetsContinueCTA.Click();
        CA_DriversPage.PleaseFixErrors.AssertElementIsVisible();
        CA_DriversPage.OneOrMoreInvalid.AssertElementIsVisible();

        //intended to find help and error elements for first driver panel
        var selectors = new HelpAndErrorSelectors()
        {
            ErrorTextSelector = alias => CA_DriversPage.GetFrontEndErrorText(alias, 0),
            HelpIconSelector = alias => CA_DriversPage.GetFrontEndHelpIcon(alias, 0),
            HelpTextSelector = alias => CA_DriversPage.GetFrontEndHelpText(alias, 0),
            HelpExitSelector = alias => CA_DriversPage.GetFrontEndHelpExit(alias, 0)
        };
        VerifyHelpAndErrorTable(helpAndErrorTable, selectors);
    }

    [Then(@"user verifies the following Apollo help and error element on the CA Drivers page:")]
    public void ThenUserVerifiesApolloDriversErrorText(Table helpAndErrorTable)
    {
        //intended to find help and error elements for first driver panel
        var selectors = new HelpAndErrorSelectors()
        {
            ErrorTextSelector = alias => CA_DriversPage.GetApolloErrorText(alias, 0),
            HelpIconSelector = alias => CA_DriversPage.GetApolloHelpIcon(alias, 0),
            HelpTextSelector = alias => CA_DriversPage.GetApolloHelpText(alias, 0),
            HelpExitSelector = alias => CA_DriversPage.GetApolloHelpExit(alias, 0)
        };
        VerifyHelpAndErrorTable(helpAndErrorTable, selectors);
    }

    [Then(@"user verifies the appearance of the help text on the Quote Page")]
    public void ThenUserVerifiesTheAppearanceOfTheHelpTextOnTheQuotePage()
    {
        AutomationHelper.ValidateElements(CA_QuoteSummaryPage.ErrorElements);
    }

    [Then(@"user verifies the help and error text of the contact details page")]
    public void ThenUserVerifiesTheHelpAndErrorTextOfTheContactDetailsPage()
    {
        CA_ContactDetailsPage.BusinessHasAccntMngInput.EnterResponse(true);
        CA_ContactDetailsPage.LetsWrapThisUpCTA.Click();
        AutomationHelper.ValidateElements(CA_ContactDetailsPage.ErrorElements);
    }

    [Then(@"user verifies each error element on the CA Introduction page")]
    public void ThenUserVerifiesEachErrorElementOnTheCAIntroductionPage()
    {
        CA_IntroductionPage.UseAsMailingAddressChkbox.Click();
        CA_IntroductionPage.MailingAddressInput.AssertAllElements();
        CA_IntroductionPage.LetsContinueCTA.Click();
        foreach (var error in IntroDefaultErrors)
        {
            error.AssertElementIsVisible();
        }
        CA_IntroductionPage.BusinessStructuredDD.SelectMatDropdownOptionByText("Government Entity");
        CA_IntroductionPage.GovTypeError.AssertElementIsVisible();
    }

    [Then(@"user verifies each help text element on the CA Introduction page")]
    public void ThenUserVerifiesEachHelpTextElementOnTheCAIntroductionPage()
    {
        foreach (var element in IntroHelpElements)
        {
            element.AssertElementIsVisible();
            element.Click();
        }
    }
   
    [Then(@"user verifies the CA save for later (.*) modal error message appears")]
    public void ThenUserVerifiesTheSaveForLaterModalErrorMesaages(string ModalType)
    {
        AutomationHelper.WaitForLoading();
        SaveForLater_Modal.SflSaveBTN.Click();
        if (ModalType == "regular")
        {
            AutomationHelper.ValidateElements(SaveForLater_Modal.SFLModalElements);
            SaveForLater_Modal.SflEmailTxtbox.SetText("a");
            SaveForLater_Modal.SflPhoneTxtbox.Click();
            SaveForLater_Modal.SflEmailError.AssertElementIsVisible();
            SaveForLater_Modal.SflEmailError.AssertElementInnerTextEquals("Please enter more characters.");
            SaveForLater_Modal.SflEmailTxtbox.SetText("a@b.c");
            SaveForLater_Modal.SflEmailError.AssertElementInnerTextEquals("Please enter a valid email address (example: jonsmith@email.com), it's required.");
            SaveForLater_Modal.SflPhoneTxtbox.SetText("123456789");
            SaveForLater_Modal.SflPhoneError.AssertElementIsVisible();
            SaveForLater_Modal.SflPhoneError.AssertElementInnerTextEquals("Please enter more characters.");
            SaveForLater_Modal.SflFirstNameTxtbox.SetText("F");
            SaveForLater_Modal.SflLastNameTxtbox.SetText("L");
            SaveForLater_Modal.SflNameError.AssertElementIsVisible();
            SaveForLater_Modal.SflNameError.AssertElementInnerTextEquals("Valid entry is between 2 and 25 alpha characters including hyphen, apostrophe, spaces.. please re-enter.");
            SaveForLater_Modal.SfLSeeYouLaterTxtbox.SetText("test");
            SaveForLater_Modal.SfLSeeYouLaterError.AssertElementIsVisible();
            SaveForLater_Modal.SfLSeeYouLaterError.AssertElementInnerTextEquals("Please enter a valid email address.");

        }
        else if (ModalType == "slim")
        {
            AutomationHelper.ValidateElements(SaveForLater_Modal.SfLSlimModalElements);
            SaveForLater_Modal.SfLSeeYouLaterEmailCancel.Click();
            SaveForLater_Modal.SfLSeeYouLaterTxtbox.SetText("check");
            SaveForLater_Modal.SfLMatHint.Click();
            SaveForLater_Modal.SfLSeeYouLaterError.AssertElementIsVisible();
            SaveForLater_Modal.SfLSeeYouLaterError.AssertElementInnerTextEquals("Please enter a valid email address.");
        }
        SaveForLater_Modal.SfLSeeYouLaterHelperX.Click();
    }

    [Then(@"user verifies each error element on the CA purchase page")]
    public void ThenUserVerifiesEachErrorElementOnTheCAPurchasePage()
    {
        CA_PurchaseYourPlanPage.PayCTA.Click();
        ValidateInnerTextOfElements(CA_PurchaseYourPlanPage.ErrorElements);
    }

    [Then(@"user verifies each help text element on the CA purchase page")]
    public void ThenUserVerifiesEachHelpTextElementOnTheCAPurchasePage()
    {
        SelectElements(CA_PurchaseYourPlanPage.HelpElements);
        ValidateInnerTextOfElements(CA_PurchaseYourPlanPage.HelpTextElements);
    }

    private void VerifyHelpAndErrorTable(Table helpAndErrorTable, HelpAndErrorSelectors selectors)
    {
        var errorRows = helpAndErrorTable.Rows.Where(row => row["Type"] == ERROR_TYPE);
        var helpRows = helpAndErrorTable.Rows.Where(row => row["Type"] == HELP_TYPE);

        VerifyErrorText(errorRows.Select(row => row["Question Alias"]), selectors);
        VerifyHelpText(helpRows.Select(row => row["Question Alias"]), selectors);
    }

    private void VerifyErrorText(IEnumerable<string> questionAliases, HelpAndErrorSelectors selectors)
    {
        foreach (var questionAlias in questionAliases)
        {
            _automation.VerifyErrorText(selectors.ErrorTextSelector(questionAlias));
        }
    }

    private void VerifyHelpText(IEnumerable<string> questionAliases, HelpAndErrorSelectors selectors)
    {
        foreach (var questionAlias in questionAliases)
        {
            _automation.VerifyHelpText(selectors.HelpIconSelector(questionAlias),
                selectors.HelpTextSelector(questionAlias),
                selectors.HelpExitSelector(questionAlias));
        }
    }

    private void SelectElements(List<Element> Elements)
    {
        foreach (var element in Elements)
        {
            element.AssertElementIsVisible();
            element.Click();
        }
    }

    private void ValidateInnerTextOfElements(Dictionary<Element, string> Elements)
    {
        foreach (var element in Elements)
        {
            element.Key.AssertElementIsVisible();
            element.Key.AssertElementInnerTextEquals(element.Value);
        }
    }

    public List<Element> IntroDefaultErrors = new List<Element>
    {
        CA_IntroductionPage.BusinessStartedError,
        CA_IntroductionPage.BusinessStructuredError,
        CA_IntroductionPage.BusinessAddressAddress1Error,
        CA_IntroductionPage.BusinessAddressCityError,
        CA_IntroductionPage.MailingAddressAddress1Error,
        CA_IntroductionPage.MailingAddressZipError,
        CA_IntroductionPage.MailingAddressCityError,
        CA_IntroductionPage.MailingAddressStateError,
        CA_IntroductionPage.PleaseFixErrors,
        CA_IntroductionPage.OneOrMoreInvalid,
    };

    public List<Element> IntroHelpElements = new List<Element>
    {
        CA_IntroductionPage.BusinessStartedHelper,
        CA_IntroductionPage.BusinessStartedHelperText,
        CA_IntroductionPage.BusinessStartedHelperX,
        CA_IntroductionPage.BusinessStructuredHelper,
        CA_IntroductionPage.BusinessStructuredHelperText,
        CA_IntroductionPage.BusinessStructuredHelperX,
    };
}