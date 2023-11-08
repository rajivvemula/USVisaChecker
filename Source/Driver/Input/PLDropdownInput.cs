using DocumentFormat.OpenXml.Office.CustomUI;
using HitachiQA.Driver;
using HitachiQA.Driver.Input;
using HitachiQA.Helpers;

namespace BiBerkLOB.Source.Driver.Input;

public class PLDropdownInput : InputSection
{
    private Element _dropdown;

    public PLDropdownInput(Element dropdown)
    {
        _dropdown = dropdown;
    }

    public override void AssertCoreElements(int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        _dropdown.AssertElementIsVisible(waitSeconds);
    }

    public override void EnterResponse(object answer, int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        var xpath = Functions.GetElementXPath(_dropdown.locator);
        var option = new Element($"{xpath}//following-sibling::ul//li//span[text()='{answer}']");

        AutomationHelper.RetryUntilSucceeded(() =>
        {
            _dropdown.Click(2);
            option.AssertElementIsVisible(2);
            option.Click(1);
        }, waitSeconds);
    }

    public override bool IsResponseCurrentlyEqualTo(object answer)
    {
        return _dropdown.GetAttribute("value") == answer.ToString();
    }
}