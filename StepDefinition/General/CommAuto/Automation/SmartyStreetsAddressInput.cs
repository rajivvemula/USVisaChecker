using System;
using BiBerkLOB.Pages;
using BiBerkLOB.Source.Driver;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation.Models;
using HitachiQA.Driver;
using HitachiQA.Driver.Input;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation;

public class SmartyStreetsAddressInput : InputSection
{
    // using nullable because some address components aren't editable/present
    private readonly InputSection? _addressLine1;
    private readonly InputSection? _addressLine2;
    private readonly InputSection? _city;
    private readonly InputSection? _state;
    private readonly InputSection? _zipCode;

    private readonly Element _loadingBar;
    private readonly Element _suggestBoxTitle;
    private readonly Element _asEnteredBtn;
    private readonly Element _suggestedBtn;

    public SmartyStreetsAddressInput(SmartyStreetAddressElements elements)
    {
        _addressLine1 = elements.AddressLine1;
        _addressLine2 = elements.AddressLine2;
        _city = elements.City;
        _state = elements.State;
        _zipCode = elements.ZipCode;

        _loadingBar = elements.LoadingBar;
        _suggestBoxTitle = elements.SuggestionBoxTitle;
        _asEnteredBtn = elements.AsEnteredBtn;
        _suggestedBtn = elements.SuggestedBtn;
    }

    // Only assert if it's defined
    // (ex: if you don't put a zip code section, it's not checked)
    public override void AssertCoreElements(int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        _addressLine1?.AssertAllElements(waitSeconds);
        _addressLine2?.AssertAllElements(waitSeconds);
        _city?.AssertAllElements(waitSeconds);
        _state?.AssertAllElements(waitSeconds);
        _zipCode?.AssertAllElements(waitSeconds);
    }
    
    // Address is taken as source of truth
    // (ex: if "state" is not defined, assume input doesn't exist; if it is defined, it must be there
    public override void EnterResponse(object answer, int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        var smartyAddress = ParseResponse(answer);

        EnterAddressValuesThatExist(smartyAddress, waitSeconds);
        WaitForApiCall(smartyAddress);
        MakeSuggestionSelection(smartyAddress);
    }

    private void EnterAddressValuesThatExist(SmartyStreetsInputResponse smartyAddress, int waitSeconds)
    {
        // only answer address section if defined in response
        if (smartyAddress.Address.Line1 != null)
        {
            _addressLine1!.EnterResponse(smartyAddress.Address.Line1, waitSeconds);
        }

        if (smartyAddress.Address.Line2 != null)
        {
            _addressLine2!.EnterResponse(smartyAddress.Address.Line2, waitSeconds);
        }

        if (smartyAddress.Address.City != null)
        {
            _city!.EnterResponse(smartyAddress.Address.City, waitSeconds);
        }

        if (smartyAddress.Address.State != null)
        {
            _state!.EnterResponse(smartyAddress.Address.State, waitSeconds);
        }

        if (smartyAddress.Address.ZipCode != null)
        {
            _zipCode!.EnterResponse(smartyAddress.Address.ZipCode, waitSeconds);
        }
    }

    private void WaitForApiCall(SmartyStreetsInputResponse smartyAddress)
    {
        //check loading bar (loading may be too fast to catch it), then wait for loading to finish
        _loadingBar.AssertElementIsVisible(5, true);
        _loadingBar.AssertElementNotPresent();

        //if we're going to answer the suggestion box, assert that it actually appears
        if (smartyAddress.Suggestion != SmartyStreetsSuggestion.NoAction)
        {
            _suggestBoxTitle.AssertElementIsVisible(3);
        }
    }

    private void MakeSuggestionSelection(SmartyStreetsInputResponse smartyAddress)
    {
        const int buttonWait = 1;
        switch (smartyAddress.Suggestion)
        {
            case SmartyStreetsSuggestion.NoAction:
                return;
            case SmartyStreetsSuggestion.AsEntered:
                _asEnteredBtn.Click(buttonWait);
                return;
            case SmartyStreetsSuggestion.Suggested:
                _suggestedBtn.Click(buttonWait);
                return;
        }
    }

    // both address and definition must match
    // (ex: if address has state but no state section defined, return false)
    // (ex: if address does not have state but state is defined, return false)
    // (ex: if address has state and state section is defined, return true if section matches address)
    // (ex: if address has no state and state section not defined, return true if everything else matches)
    public override bool IsResponseCurrentlyEqualTo(object answer)
    {
        var smartyAddress = ParseResponse(answer);

        bool matches = true;
        matches = matches && ExpectedValueMatchesInputValue(smartyAddress.Address.Line1, _addressLine1);
        matches = matches && ExpectedValueMatchesInputValue(smartyAddress.Address.Line2, _addressLine2);
        matches = matches && ExpectedValueMatchesInputValue(smartyAddress.Address.City, _city);
        matches = matches && ExpectedValueMatchesInputValue(smartyAddress.Address.State, _state);
        matches = matches && ExpectedValueMatchesInputValue(smartyAddress.Address.ZipCode, _zipCode);

        return matches;
    }

    /// <summary>
    /// Determines if input has expected value if both exist,
    /// or ensures that elements are defined for expected values
    /// </summary>
    /// <param name="value">Expected value of input</param>
    /// <param name="input">Input to read value from</param>
    /// <returns>
    /// true if both params are null or if input value matches defined value<br/>
    /// false if value is defined (expected) and input is null or input is defined and value is null (not expected)
    /// </returns>
    private bool ExpectedValueMatchesInputValue(object value, InputSection input)
    {
        return (value, input) switch
        {
            // both are null, therefore element doesn't exist and don't expect value
            (null, null) => true,
            // one is null, therefore either input is being given null value or expect value for nonexistent input
            (null, _) or (_, null) => false,
            // value and input exist, therefore check input for value
            (_, _) => input.IsResponseCurrentlyEqualTo(value)
        };
    }

    private SmartyStreetsInputResponse ParseResponse(object answer)
    {
        if (answer.GetType() != typeof(SmartyStreetsInputResponse))
        {
            throw new ArgumentException($"Smarty Streets address forms take '{nameof(Address)}' as responses");
        }

        return (SmartyStreetsInputResponse)answer;
    }
}