using System;
using HitachiQA.Helpers;

namespace HitachiQA.Driver.Input;

/// <summary>
/// Represents single check box toggle using Angular
/// </summary>
public class MatCheckBoxToggleInput : InputSection
{
    private Element _checkBox;

    public MatCheckBoxToggleInput(Element checkBox)
    {
        _checkBox = checkBox;
    }

    public override void AssertCoreElements(int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        _checkBox.AssertElementIsVisible(waitSeconds);
    }

    public override void EnterResponse(object answer, int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        if (answer == null)
        {
            return;
        }

        var shouldBeChecked = ParseResponse(answer);
        EnsureCheckBoxToggleIsSet(shouldBeChecked, waitSeconds);
    }

    public override bool IsResponseCurrentlyEqualTo(object answer)
    {
        var shouldBeChecked = ParseResponse(answer);
        return AriaChecked() == shouldBeChecked;
    }

    private bool ParseResponse(object response)
    {
        if (response is bool flag)
        {
            return flag;
        }
        if (response is string trueOrFalse)
        {
            return bool.Parse(trueOrFalse);
        }
        throw new ArgumentException($"{response.ToString()} could not be determined as true or false");
    }

    private void EnsureCheckBoxToggleIsSet(bool shouldBeChecked, int waitSeconds)
    {
        if (shouldBeChecked)
        {
            ClickCheckboxIfNotSelected(waitSeconds);
            return;
        }
        ClickCheckboxIfSelected(waitSeconds);
    }

    private void ClickCheckboxIfNotSelected(int waitSeconds)
    {
        if (!AriaChecked())
        {
            _checkBox.Click(waitSeconds);
        }
    }

    private void ClickCheckboxIfSelected(int waitSeconds)
    {
        if (AriaChecked())
        {
            _checkBox.Click(waitSeconds);
        }
    }

    private bool AriaChecked()
    {
        var input = new Element(AutomationHelper.GetElementXPath(_checkBox) + "//input[contains(@class,'checkbox--selected')]");
        return input.GetCountOfElements()>0;
    }
}