using System;
using System.Linq;
using BiBerkLOB.Source.Helpers;
using BiBerkLOB.StepDefinition.General.GenAutomation;
using HitachiQA.Helpers;

namespace HitachiQA.Driver.Input;

/// <summary>
/// Represents a list of options where any number/combination can be selected as a valid option
/// </summary>
public class MultiChoiceGroupInput : InputSection
{
    private ChoiceGroup _choiceGroup;
    private Func<Element, bool> _isSelectedPredicate;

    public MultiChoiceGroupInput(ChoiceGroup choiceGroup)
    {
        _choiceGroup = choiceGroup;
        _isSelectedPredicate = el => el.IsSelected(1);
    }

    public MultiChoiceGroupInput(ChoiceGroup choiceGroup, Func<Element, bool> isSelectedPredicate)
    {
        _choiceGroup = choiceGroup;
        _isSelectedPredicate = isSelectedPredicate;
    }

    public override void AssertCoreElements(int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        _choiceGroup.AssertAllButtons(waitSeconds);
    }

    public override void EnterResponse(object answer, int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        var answerList = Functions.ParseSemicolonSeparatedList((string)answer);
        foreach (var choice in answerList)
        {
            _choiceGroup.ClickChoice(choice);
        }
    }

    public override bool IsResponseCurrentlyEqualTo(object answer)
    {
        var expected = Functions.ParseSemicolonSeparatedList((string)answer).ToArray();
        var selected = _choiceGroup.GetSelectedChoices(_isSelectedPredicate);
        return selected.Length == expected.Length 
               && expected.All(e => selected.Contains(e))
               && selected.All(s => expected.Contains(s));
    }
}