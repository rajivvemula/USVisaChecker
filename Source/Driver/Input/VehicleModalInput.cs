using System;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation.Models;
using HitachiQA.Driver;
using HitachiQA.Driver.Input;

namespace BiBerkLOB.Source.Driver.Input;

public class VehicleModalInput : InputSection
{
    private Element _exitBtn;
    private ChoiceGroup _accordion;
    private ChoiceGroup _buttonChoices;
    private ChoiceGroup _buttonValues;

    public VehicleModalInput(Element exit, ChoiceGroup accordion, ChoiceGroup buttonChoices, ChoiceGroup buttonValues)
    {
        _exitBtn = exit;
        _accordion = accordion;
        _buttonChoices = buttonChoices;
        _buttonValues = buttonValues;
    }

    public override void AssertCoreElements(int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        _exitBtn.AssertElementIsVisible(waitSeconds);
    }

    public override void EnterResponse(object answer, int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        var vehicleType = ParseResponse(answer);
        
        _accordion.ClickChoice(vehicleType.Category.Label, 5);
        if (_buttonValues.GetChoice(vehicleType.ToString()).IsSelected(waitSeconds))
        {
            _exitBtn.Click(waitSeconds);
            return;
        }
        _buttonChoices.ClickChoice(vehicleType.ToString(), waitSeconds);
    }

    public override bool IsResponseCurrentlyEqualTo(object answer)
    {
        var vehicleType = ParseResponse(answer);

        _accordion.ClickChoice(vehicleType.Category.Label, 5);
        var choiceSelected = _buttonValues.GetChoice(vehicleType.ToString()).IsSelected(1);
        _exitBtn.Click(1);
        
        return choiceSelected;
    }

    private static VehicleType ParseResponse(object answer)
    {
        if (answer is string code)
        {
            return new VehicleType(code);
        }
        if (answer is VehicleType type)
        {
            return type;
        }

        throw new ArgumentException("Vehicle type response should be either code as a string or VehicleType instance");
    }
}