using System;
using BiBerkLOB.Pages;
using BiBerkLOB.Pages.CommAuto;
using HitachiQA.Driver;
using HitachiQA.Driver.Input;

namespace BiBerkLOB.Source.Driver.Input;

public class YearMakeModelInput : InputSection
{
    private Element _year;
    private Element _make;
    private Element _modelDropdown;
    private Element _modelTextbox;
    private Element _loadingIndicator;

    public YearMakeModelInput(Element year, Element make, Element modelDropdown, Element modelTextbox, Element loadingIndicator)
    {
        _year = year;
        _make = make;
        _modelDropdown = modelDropdown;
        _modelTextbox = modelTextbox;
        _loadingIndicator = loadingIndicator;
    }

    public override void AssertCoreElements(int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        _year.AssertElementIsVisible(waitSeconds);
        _make.AssertElementIsVisible(waitSeconds);
        _modelDropdown.AssertElementIsVisible(waitSeconds);
    }

    public override void EnterResponse(object answer, int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        var vehicle = ParseResponse(answer);

        if (string.IsNullOrEmpty(vehicle.Year))
        {
            return;
        }
        _year.SetText(vehicle.Year, waitSeconds);
        WaitForSpinner();

        if (string.IsNullOrEmpty(vehicle.Make))
        {
            return;
        }
        _make.SelectMatDropdownOptionByText(vehicle.Make);
        WaitForSpinner();

        if (string.IsNullOrEmpty(vehicle.Model))
        {
            return;
        }
        if (vehicle.EnterModelManually)
        {
            _modelDropdown.SelectMatDropdownOptionByText("I can't find my model");
            _modelTextbox.SetText(vehicle.Model, waitSeconds);
        }
        else
        {
            _modelDropdown.SelectMatDropdownOptionByText(vehicle.Model);
        }
    }

    public override bool IsResponseCurrentlyEqualTo(object answer)
    {
        var vehicle = ParseResponse(answer);

        bool ymkIsCorrect = false;

        ymkIsCorrect = _year.GetTextFieldValue() == vehicle.Year;
        if (string.IsNullOrEmpty(vehicle.Make)) 
        {
            return ymkIsCorrect;
        }

        ymkIsCorrect = _make.GetInnerText() == vehicle.Make;
        if (string.IsNullOrEmpty(vehicle.Model))
        {
            return ymkIsCorrect;
        }

        if (vehicle.EnterModelManually)
        {
            ymkIsCorrect = _modelTextbox.GetTextFieldValue(1) == vehicle.Model;
        }
        else
        {
            ymkIsCorrect = _modelDropdown.GetInnerText() == vehicle.Model;
        }
        return ymkIsCorrect;
    }

    private static YearMakeModel ParseResponse(object answer)
    {
        if (answer is not YearMakeModel)
        {
            throw new ArgumentException($"Please use a {typeof(YearMakeModel)} to submit year, make, and model");
        }

        var vehicle = (YearMakeModel)answer;
        return vehicle;
    }

    private void WaitForSpinner()
    {
        // check for loading indicator, may not assert if loading is faster than automation
        // then make sure loading is finished
        _loadingIndicator.AssertElementIsPresent(5, true);
        _loadingIndicator.AssertElementNotPresent();
    }
}

public class YearMakeModel
{
    public string Year { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public bool EnterModelManually { get; set; }
}