namespace HitachiQA.Driver.Input;

/// <summary>
/// Represents basic textbox input
/// </summary>
public class TextBoxInput : InputSection
{
    private Element _textBox;
    public TextBoxInput(Element textBox)
    {
        _textBox = textBox;
    }

    public override void AssertCoreElements(int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        _textBox.AssertElementIsVisible(waitSeconds);
    }

    public override void EnterResponse(object answer, int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        _textBox.SetText(answer.ToString(), waitSeconds);
    }

    public override bool IsResponseCurrentlyEqualTo(object answer)
    {
        return _textBox.GetTextFieldValue(1) == answer.ToString();
    }
}