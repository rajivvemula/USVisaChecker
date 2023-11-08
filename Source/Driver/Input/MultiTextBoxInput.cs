using System;
using System.Collections.Generic;
using System.Linq;
using BiBerkLOB.Source.Helpers;
using BiBerkLOB.StepDefinition.General.GenAutomation;
using HitachiQA.Helpers;

namespace HitachiQA.Driver.Input;

/// <summary>
/// Represents input where multiple textboxes are meant to be filled
/// </summary>
public class MultiTextBoxInput : InputSection
{
    private Element[] _orderedTextBoxList;

    public MultiTextBoxInput(params Element[] orderedTextBoxList)
    {
        _orderedTextBoxList = orderedTextBoxList;
    }

    public override void AssertCoreElements(int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        foreach (var textBox in _orderedTextBoxList)
        {
            textBox.AssertElementIsVisible(waitSeconds);
        }
    }

    public override void EnterResponse(object answer, int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        var answerList = ParseResponse(answer).ToArray();
        
        if (answerList.Length != _orderedTextBoxList.Length)
        {
            throw new ArgumentException($"This question has {_orderedTextBoxList.Length} textboxes but only {answerList.Length} answer(s) were provided");
        }

        for (int i = 0; i < answerList.Length; i++)
        {
            _orderedTextBoxList[i].SetText(answerList[i], waitSeconds);
        }
    }

    public override bool IsResponseCurrentlyEqualTo(object answer)
    {
        var answerList = ParseResponse(answer).ToArray();

        if (answerList.Length != _orderedTextBoxList.Length)
        {
            throw new ArgumentException($"This question has {_orderedTextBoxList.Length} textboxes but only {answerList.Length} answer(s) were provided");
        }

        for (int i = 0; i < answerList.Length; i++)
        {
            if (_orderedTextBoxList[i].GetTextFieldValue(1) != answerList[i])
            {
                return false;
            }
        }

        return true;
    }

    private IEnumerable<string> ParseResponse(object answer)
    {
        if (answer is IEnumerable<string> enumerable)
        {
            return enumerable;
        }
        return Functions.ParseSemicolonSeparatedList(answer.ToString());
    }
}