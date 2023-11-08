using System;

namespace HitachiQA.Driver.Input;

/// <summary>
/// Represents single check box toggle using built in HTML element
/// </summary>
public class HtmlCheckBoxToggleInput : InputSection
{
    private Element _checkBox;

    public HtmlCheckBoxToggleInput(Element checkBox)
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
        return _checkBox.IsSelected() == shouldBeChecked;
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
            _checkBox.ClickIfNotSelected(waitSeconds);
            return;
        }
        _checkBox.ClickIfSelected(waitSeconds);
    }
}