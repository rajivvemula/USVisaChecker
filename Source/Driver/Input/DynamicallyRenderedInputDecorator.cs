using System.Threading;
using HitachiQA;
using HitachiQA.Driver;
using HitachiQA.Driver.Input;

namespace BiBerkLOB.Source.Driver.Input;

/// <summary>
/// Wraps an input section that is rendered dynamically within the page<br/>
/// it appears in, accounting for network calls to question engine when interacting.
/// </summary>
public class DynamicallyRenderedInputDecorator : InputSectionExtrasDecorator
{
    private readonly InflightStatusChecker _statusChecker;
    private readonly int _maxSeconds;

    public DynamicallyRenderedInputDecorator(InputSection wrappedInput, Element inflightElement, int maxSecondsWait) : base(wrappedInput)
    {
        _statusChecker = new InflightStatusChecker(inflightElement);
        _maxSeconds = maxSecondsWait;
    }

    public override void AssertWrappedElements(int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        WaitForInflightCalls();
    }

    public override void EnterResponse(object answer, int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        WaitForInflightCalls();
        base.EnterResponse(answer, waitSeconds);
    }

    private void WaitForInflightCalls()
    {
        Assert.IsTrue(_statusChecker.IsPresentInDOM());
        if(_statusChecker.IsInflight())
        {
            UserActions.WaitUntil(() => !_statusChecker.IsInflight(), _maxSeconds);
            Thread.Sleep(100); //tiny buffer between call finish and automation kick in
        }
    }
}