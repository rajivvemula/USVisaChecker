using System;
using HitachiQA.Driver;
using HitachiQA.Driver.Input;

namespace BiBerkLOB.Source.Driver.Input;

public class StateInputDecorator : InputSectionExtrasDecorator
{
    private readonly StateInputStrategy _strategy;

    public StateInputDecorator(InputSection wrappedInput, StateInputStrategy strategy) : base(wrappedInput)
    {
        _strategy = strategy;
    }

    public override void AssertWrappedElements(int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        //no extra elements
    }

    public override void EnterResponse(object answer, int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        var state = ParseResponse(answer);
        switch (_strategy)
        {
            case StateInputStrategy.Abbreviation:
                base.EnterResponse(state.Abbreviation, waitSeconds);
                return;
            case StateInputStrategy.Name:
                base.EnterResponse(state.Name, waitSeconds);
                return;
            default: throw new ArgumentOutOfRangeException("Invalid state answering strategy");
        }
    }

    private State ParseResponse(object answer)
    {
        if (answer.GetType() != typeof(State))
        {
            throw new ArgumentException("State input requires a State object");
        }
        return (State)answer;
    }
}

public enum StateInputStrategy
{
    Abbreviation, Name
}