using BiBerkLOB.Source.Driver.Input;

namespace HitachiQA.Driver.Input;

// Helper methods to generate decorator objects
public static class InputHelperExtensions
{
    /// <summary>
    /// Wraps the given input section with question text
    /// </summary>
    public static QuestionInputDecorator AsAQuestion(this InputSection input, Element questionText)
    {
        return new QuestionInputDecorator(input, questionText);
    }

    /// <summary>
    /// Wraps the given input section with extra text (ie: hints)
    /// </summary>
    public static ExtraTextInputDecorator WithExtraText(this InputSection input, params Element[] extraText)
    {
        return new ExtraTextInputDecorator(input, extraText);
    }

    /// <summary>
    /// Wraps the given input section with help text (icon trigger, text, and exit button if applicable)
    /// </summary>
    public static HelpTextInputDecorator WithHelpText(this InputSection input, Element helpTrigger, Element helpText, Element closeBtn = null)
    {
        return new HelpTextInputDecorator(input, helpTrigger, helpText, closeBtn);
    }

    /// <summary>
    /// Wraps the dynamically rendered input section affected by previous questions within page
    /// </summary>
    public static DynamicallyRenderedInputDecorator IsDynamicallyRendered(this InputSection input, Element inflightElement, int maxSecondsWait)
    {
        return new DynamicallyRenderedInputDecorator(input, inflightElement, maxSecondsWait);
    }

    public static StateInputDecorator TakesAStateAsInput(this InputSection input, StateInputStrategy strategy)
    {
        return new StateInputDecorator(input, strategy);
    }
}