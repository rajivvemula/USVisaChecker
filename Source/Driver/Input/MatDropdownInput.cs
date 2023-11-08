using System;

namespace HitachiQA.Driver.Input;

/// <summary>
/// Represents a dropdown using angular component
/// </summary>
public class MatDropdownInput : InputSection
{
    private Element _matDropdown;
    public MatDropdownInput(Element matDropdown)
    {
        _matDropdown = matDropdown;
    }

    public override void AssertCoreElements(int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        _matDropdown.AssertElementIsVisible(waitSeconds);
    }

    public override void EnterResponse(object answer, int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        if (answer is int index)
        {
            _matDropdown.SelectMatDropdownOptionByIndex(index);
        }
        else
        {
            _matDropdown.SelectMatDropdownOptionByText(answer.ToString());
        }
    }

    public override bool IsResponseCurrentlyEqualTo(object answer)
    {
        return _matDropdown.GetInnerText() == answer.ToString();
    }
}