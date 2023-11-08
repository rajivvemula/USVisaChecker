using System;

namespace HitachiQA.Driver.Input;

/// <summary>
/// Represents a date input with built in date picking/validation
/// </summary>
public class DatePickerInput : InputSection
{
    private IDatePicker _datePicker;
    public DatePickerInput(IDatePicker datePicker)
    {
        _datePicker = datePicker;
    }

    public override void AssertCoreElements(int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        _datePicker.AssertIsVisible(waitSeconds);
    }

    public override void EnterResponse(object answer, int waitSeconds = DEFAULT_INPUT_WAIT_SECONDS)
    {
        if (answer == null)
        {
            _datePicker.EnterDefaultDate();
            return;
        }

        var toSelect = ParseResponse(answer);
        if (toSelect == null)
        {
            _datePicker.EnterDefaultDate();
            return;
        }
        _datePicker.SelectDate(toSelect.Value);
    }

    public override bool IsResponseCurrentlyEqualTo(object answer)
    {
        var date = ParseResponse(answer).Value;
        return _datePicker.GetDateValue() == date;
    }

    private DateTime? ParseResponse(object answer)
    {
        if (answer is string dateString)
        {
            if (string.IsNullOrEmpty(dateString))
            {
                return null;
            }

            return DateTime.Parse(dateString);
        }
        else if (answer is DateTime dateTime)
        {
            return dateTime;
        }
        else if (answer is TimeSpan timeSpan)
        {
            return DateTime.Now.Add(timeSpan);
        }
        throw new ArgumentException($"Can't determine date from {answer.GetType()} answer: '{answer.ToString()}'");
    }
}