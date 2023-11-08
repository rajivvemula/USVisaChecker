using System.Collections.Generic;
using DocumentFormat.OpenXml.Office2010.ExcelAc;

namespace HitachiQA.Driver.Input;

/// <summary>
/// Abstract representation of an input: must be defined using concrete implementation
/// </summary>
public abstract class InputSection
{
    protected const int DEFAULT_INPUT_WAIT_SECONDS = UserActions.DEFAULT_WAIT_SECONDS;

    public virtual void AssertAllElements(int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        AssertCoreElements(waitSeconds);
    }

    public abstract void AssertCoreElements(int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS);
    public abstract void EnterResponse(object answer, int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS);
    public abstract bool IsResponseCurrentlyEqualTo(object answer);

    public virtual InputSection CoreInput => this;
}