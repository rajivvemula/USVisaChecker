using System;
using System.Collections.Generic;
using System.Linq;
using HitachiQA.Driver;
using HitachiQA.Driver.Input;
using HitachiQA.Helpers;

namespace BiBerkLOB.Source.Driver.Input;

public class NoInput : InputSection
{
    private Element[] _elements;

    public NoInput(params Element[] elements)
    {
        _elements = elements;
    }

    public override void AssertCoreElements(int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        foreach (var element in _elements)
        {
            element.AssertElementIsVisible(waitSeconds);
        }
    }

    public override void EnterResponse(object answer, int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        // do nothing
    }

    public override bool IsResponseCurrentlyEqualTo(object answer)
    {
        // do nothing
        return true;
    }
}