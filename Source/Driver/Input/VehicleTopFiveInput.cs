using HitachiQA.Driver;
using HitachiQA.Driver.Input;

namespace BiBerkLOB.Source.Driver.Input;

public class VehicleTopFiveInput : InputSection
{
    private ChoiceGroup _vehicles;
    private ChoiceGroup _vehiclesValues;
    private Element _otherBtn;
    public const string OTHER_OPTION = "Other";

    public VehicleTopFiveInput(ChoiceGroup vehicles, ChoiceGroup vehiclesValues, Element otherBtn)
    {
        _vehicles = vehicles;
        _vehiclesValues = vehiclesValues;
        _otherBtn = otherBtn;
    }

    public override void AssertCoreElements(int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        _vehicles.AssertAllButtons(waitSeconds);
        _otherBtn.AssertElementIsVisible(waitSeconds);
    }

    public override void EnterResponse(object answer, int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        var option = answer.ToString();
        if (answer.ToString() == OTHER_OPTION)
        {
            _otherBtn.Click(waitSeconds);
            return;
        }
        if (!_vehiclesValues.GetChoice(option).IsSelected(waitSeconds))
        {
            _vehicles.ClickChoice(option);
        }
    }

    public override bool IsResponseCurrentlyEqualTo(object answer)
    {
        if (answer.ToString() == OTHER_OPTION)
        {
            return _otherBtn.IsSelected(1);
        }

        return _vehicles.GetChoice(answer.ToString()).IsSelected(1);
    }
}