namespace HitachiQA.Driver.Input;

/// <summary>
/// Wraps input to assert any extra text around related to the section
/// </summary>
public class ExtraTextInputDecorator : InputSectionExtrasDecorator
{
    private Element[] _extraTextElements;
    public ExtraTextInputDecorator(InputSection input, params Element[] extraTextElements) : base(input)
    {
        _extraTextElements = extraTextElements;
    }

    public override void AssertWrappedElements(int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        foreach (var text in _extraTextElements)
        {
            text.AssertElementIsVisible(waitSeconds);
        }
    }
}