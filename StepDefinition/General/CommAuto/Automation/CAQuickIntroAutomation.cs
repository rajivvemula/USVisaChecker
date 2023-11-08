using BiBerkLOB.Pages.CommAuto;
using BiBerkLOB.Pages;
using BiBerkLOB.Source.Driver;
using System.Text.RegularExpressions;
using System;
using System.Linq;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation.Models;
using HitachiQA;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation;

public class CAQuickIntroAutomation
{
    private readonly CASummaryObject _caSummaryObject;

    public CAQuickIntroAutomation(CASummaryObject caSummaryObject)
    {
        _caSummaryObject = caSummaryObject;
    }

    public void EnterYearBusinessStarted(string yearBusStarted)
    {
        CA_IntroductionPage.BusinessStartedInput.AssertAllElements();
        CA_IntroductionPage.BusinessStartedInput.EnterResponse(yearBusStarted);
        _caSummaryObject.YearBusStarted = yearBusStarted;
    }

    public void SelectBusinessStructure(string optionDisplayText)
    {
        CA_IntroductionPage.BusinessStructuredInput.AssertAllElements();
        CA_IntroductionPage.BusinessStructuredInput.EnterResponse(optionDisplayText);
        _caSummaryObject.HowBusStructured = optionDisplayText;
    }

    public void SelectGovernmentEntityType(string govEntityType)
    {
        CA_IntroductionPage.GovTypeInput.AssertAllElements(4);
        CA_IntroductionPage.GovTypeInput.EnterResponse(govEntityType);
        _caSummaryObject.GovEntityType = govEntityType;
    }

    public void EnterBusinessAddress(Address address, string suggestion)
    {
        var response = GenerateSmartyResponse(address, suggestion);
        CA_IntroductionPage.BusinessAddressInput.EnterResponse(response);

        _caSummaryObject.BusinessAddress = address;
        _caSummaryObject.BusinessAddressUsedSuggested = (response.Suggestion == SmartyStreetsSuggestion.Suggested);
        RetrieveStateAndZipFromBusinessAddress(_caSummaryObject.BusinessAddress);
    }

    /// <summary>
    /// Retrieves state and zip from page and saves it to an existing Address object
    /// </summary>
    /// <param name="address">Object to save state/zip to</param>
    public void RetrieveStateAndZipFromBusinessAddress(Address address)
    {
        //The state in this field powers state-specific coverages
        //ie: UM/UIM vs UM
        var stateZip = CA_IntroductionPage.BusinessAddressStateCommaZip
            .GetInnerText()
            .Replace(" ", "")
            .Split(",");

        var state = State.FromAny(stateZip[0]);
        var zip = stateZip[1];

        address.State = state;
        address.ZipCode = zip;
    }

    public void ToggleMailingAddressCheckbox(bool useBusinessAsMailAddress)
    {
        CA_IntroductionPage.UseAsMailingAddressInput.AssertAllElements();
        //the checkbox is for if you *don't* have a different address
        CA_IntroductionPage.UseAsMailingAddressInput.EnterResponse(useBusinessAsMailAddress);
        _caSummaryObject.UseBusinessAsMailingAddress = useBusinessAsMailAddress;
    }

    public void EnterMailingAddress(Address address, string suggestion)
    {
        var response = GenerateSmartyResponse(address, suggestion);

        CA_IntroductionPage.MailingAddressInput.EnterResponse(response);

        //set Summary Object to have the Mailing Address
        _caSummaryObject.MailingAddress = address;
        _caSummaryObject.MailingAddressUsedSuggested = (response.Suggestion == SmartyStreetsSuggestion.Suggested);
    }

    public void ClickContinue()
    {
        CA_IntroductionPage.LetsContinueCTA.Click();
    }

    public void ValidateStepper()
    {
        Reusable_PurchasePath.CAStepper_1Coverage_Current.AssertElementIsVisible();
        Reusable_PurchasePath.CAStepper_1Coverage_Past.AssertElementNotPresent(2);
        Reusable_PurchasePath.CAStepper_2Operations_Before.AssertElementIsVisible();
        Reusable_PurchasePath.CAStepper_2Operations_Current.AssertElementNotPresent(2);
        Reusable_PurchasePath.CAStepper_2Operations_Past.AssertElementNotPresent(2);
        Reusable_PurchasePath.CAStepper_3AboutYou_Before.AssertElementIsVisible();
        Reusable_PurchasePath.CAStepper_3AboutYou_Current.AssertElementNotPresent(2);
        Reusable_PurchasePath.CAStepper_3AboutYou_Past.AssertElementNotPresent(2);
        Reusable_PurchasePath.CAStepper_4Summary_Before.AssertElementIsVisible();
        Reusable_PurchasePath.CAStepper_4Summary_Current.AssertElementNotPresent(2);
        Reusable_PurchasePath.CAStepper_5Quote_Before.AssertElementIsVisible();
        Reusable_PurchasePath.CAStepper_6Purchase_Before.AssertElementIsVisible();
    }

    public void AssertQuoteIdIsVisible()
    {
        CA_PreIntroductionPage.CAQuoteID.AssertElementIsVisible();

        //check that there is a quote number after the first part of the element
        string value = CA_PreIntroductionPage.CAQuoteID.GetAttribute("innerText");
        Assert.IsTrue(TextMatchesQuoteIdPattern(value));
    }

    private bool TextMatchesQuoteIdPattern(string value)
    {
        Regex rgx = new Regex("[A-z ]*: [0-9]*");
        return rgx.IsMatch(value);
    }

    private SmartyStreetsInputResponse GenerateSmartyResponse(Address address, string suggestion)
    {
        return new SmartyStreetsInputResponse()
        {
            Address = address,
            Suggestion = suggestion != null
                ? ParseTableValueToSuggestion(suggestion)
                : SmartyStreetsSuggestion.NoAction
        };
    }

    private SmartyStreetsSuggestion ParseTableValueToSuggestion(string value)
    {
        switch (value)
        {
            case "":
                return SmartyStreetsSuggestion.NoAction;
            case "Original":
                return SmartyStreetsSuggestion.AsEntered;
            case "Suggested":
                return SmartyStreetsSuggestion.Suggested;
        }

        throw new ArgumentException($"'{value}' could not be mapped to a suggestion choice");
    }

}