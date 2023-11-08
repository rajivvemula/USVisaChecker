namespace HitachiQA.Driver.Input;

/// <summary>
/// Abstract wrapper for input to cover extra elements related to the input
/// </summary>
public abstract class InputSectionExtrasDecorator : InputSection
{
    public override InputSection CoreInput => _wrappedInput.CoreInput;
    private InputSection _wrappedInput;

    protected InputSectionExtrasDecorator(InputSection wrappedInput)
    {
        _wrappedInput = wrappedInput;
    }

    public override void AssertCoreElements(int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        _wrappedInput.CoreInput.AssertCoreElements(waitSeconds);
    }

    public override void EnterResponse(object answer, int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        _wrappedInput.CoreInput.EnterResponse(answer, waitSeconds);
    }

    public override void AssertAllElements(int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        AssertWrappedElements(waitSeconds);
        _wrappedInput.AssertAllElements(waitSeconds);
    }

    public override bool IsResponseCurrentlyEqualTo(object answer)
    {
        return _wrappedInput.CoreInput.IsResponseCurrentlyEqualTo(answer);
    }

    public abstract void AssertWrappedElements(int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS);
}