using System;

namespace HitachiQA.Driver.Input;

/// <summary>
/// Represents list of options where only one choice can be selected
/// </summary>
public class SingleChoiceGroupInput : InputSection
{
    private ChoiceGroup _choiceGroup;
    private Func<Element, bool> _isSelectedPredicate;

    public SingleChoiceGroupInput(ChoiceGroup choiceGroup)
    {
        _choiceGroup = choiceGroup;
        _isSelectedPredicate = el => el.IsSelected(1);
    }

    public SingleChoiceGroupInput(ChoiceGroup choiceGroup, Func<Element, bool> isSelectedPredicate)
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
        _choiceGroup.ClickChoice(answer.ToString(), waitSeconds);
    }

    public override bool IsResponseCurrentlyEqualTo(object answer)
    {
        var selectedChoices = _choiceGroup.GetSelectedChoices(_isSelectedPredicate);
        return selectedChoices.Length == 1 && selectedChoices[0] == answer.ToString();
    }
}