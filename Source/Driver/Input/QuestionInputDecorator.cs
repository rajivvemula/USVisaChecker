namespace HitachiQA.Driver.Input;

/// <summary>
/// Wraps input with question text
/// </summary>
public class QuestionInputDecorator : InputSectionExtrasDecorator
{
    private Element _questionText;

    public QuestionInputDecorator(InputSection wrappedInput, Element questionText) : base(wrappedInput)
    {
        _questionText = questionText;
    }

    public override void AssertWrappedElements(int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        _questionText.AssertElementIsVisible(waitSeconds);
    }
}