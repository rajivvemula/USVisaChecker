namespace HitachiQA.Driver.Input;

/// <summary>
/// Represents a dropdown using HTML standard &lt;select&gt; tag
/// </summary>
public class HtmlDropdownInput : InputSection
{
    private Element _dropdown;
    
    public HtmlDropdownInput(Element dropdown)
    {
        _dropdown = dropdown;
    }

    public override void AssertCoreElements(int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        _dropdown.AssertElementIsVisible(waitSeconds);
    }

    public override void EnterResponse(object answer, int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        _dropdown.SelectDropdownOptionByText(answer.ToString());
    }

    public override bool IsResponseCurrentlyEqualTo(object answer)
    {
        return _dropdown.GetSelectDropdownSelection() == answer.ToString();
    }
}