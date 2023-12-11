namespace HitachiQA.Driver.Input;

/// <summary>
/// Wraps input to assert the help text associated with it
/// </summary>
public class HelpTextInputDecorator : InputSectionExtrasDecorator
{
    private readonly Element _helpTrigger;
    private readonly Element _helpText;
    private readonly Element? _closeBtn;

    public HelpTextInputDecorator(InputSection input, Element helpTrigger, Element helpText, Element closeBtn = null) : base(input)
    {
        _helpTrigger = helpTrigger;
        _helpText = helpText;
        _closeBtn = closeBtn;
    }
    
    public override void AssertWrappedElements(int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        _helpTrigger.Click(waitSeconds);
        _helpText.AssertElementIsVisible(waitSeconds);
        _closeBtn?.Click(waitSeconds);
    }
}