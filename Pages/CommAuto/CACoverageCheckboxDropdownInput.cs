using HitachiQA.Driver;
using HitachiQA.Driver.Input;

namespace BiBerkLOB.Pages.CommAuto;

public class CACoverageCheckboxDropdownInput : InputSection
{
    private readonly Element _checkbox;
    private readonly Element _dropdown;

    public CACoverageCheckboxDropdownInput(Element checkbox, Element dropdown)
    {
        _checkbox = checkbox;
        _dropdown = dropdown;
    }

    public override void AssertCoreElements(int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        _checkbox.AssertElementIsVisible(waitSeconds);
        _checkbox.Click();
        _dropdown.AssertElementIsVisible(waitSeconds);
        _checkbox.Click();
    }

    public override void EnterResponse(object answer, int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        _checkbox.Click(waitSeconds);
        _dropdown.SelectMatDropdownOptionByText(answer.ToString());
    }

    public override bool IsResponseCurrentlyEqualTo(object answer)
    {
        return _dropdown.GetInnerText() == answer.ToString();
    }
}