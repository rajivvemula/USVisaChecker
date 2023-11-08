using OpenQA.Selenium;

namespace HitachiQA.Driver.Input;

/// <summary>
/// Adjusts text box strategy to unfocus after entering when it is required
/// </summary>
public class TextBoxInputUnfocusDecorator : TextBoxInput
{
    public TextBoxInputUnfocusDecorator(Element textBox) : base(textBox)
    {
    }

    public override void EnterResponse(object answer, int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        base.EnterResponse(answer.ToString() + Keys.Tab, waitSeconds);
    }
}