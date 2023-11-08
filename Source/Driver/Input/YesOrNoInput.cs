using System;
using BiBerkLOB.Source.Helpers;
using BiBerkLOB.StepDefinition.General.GenAutomation;
using HitachiQA.Helpers;

namespace HitachiQA.Driver.Input;

/// <summary>
/// Represents input with binary yes/no choice
/// </summary>
public class YesOrNoInput : InputSection
{
    private YesOrNoGroup _yesOrNo;
    private Func<Element, bool> _isSelectedPredicate;

    public YesOrNoInput(YesOrNoGroup yesOrNo, Func<Element, bool> isSelectedPredicate = null)
    {
        _yesOrNo = yesOrNo;
        _isSelectedPredicate = isSelectedPredicate ?? (el => el.IsSelected());
    }

    public YesOrNoInput(Element yesChoice, Element noChoice, Func<Element, bool> isSelectedPredicate = null)
    {
        _yesOrNo = new YesOrNoGroup(yesChoice, noChoice);
        _isSelectedPredicate = isSelectedPredicate ?? (el => el.IsSelected());
    }

    public override void AssertCoreElements(int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        _yesOrNo.AssertAllButtons(waitSeconds);
    }

    public override void EnterResponse(object answer, int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        var isYes = ParseResponse(answer);
        _yesOrNo.ClickChoiceFromCondition(isYes);
    }

    public override bool IsResponseCurrentlyEqualTo(object answer)
    {
        var isYes = ParseResponse(answer);
        return _isSelectedPredicate(_yesOrNo.GetChoice(isYes ? "Yes" : "No"));
    }

    private static bool ParseResponse(object answer)
    {
        if (answer is string yesOrNoStr)
        {
            return Functions.ConvertYesOrNoStringToBool(yesOrNoStr);
        }
        if (answer is bool yesOrNoBool)
        {
            return yesOrNoBool;
        }
        throw new ArgumentException($"Can't determine how to answer yes/no question from {answer.GetType()} answer: {answer.ToString()}");
        
    }
}