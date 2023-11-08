using System;

namespace HitachiQA.Driver;

public class TextEnterDatePicker : IDatePicker
{
    private readonly Element _dateTextBox;
    private readonly Action<Element, string> _setMethod;

    public TextEnterDatePicker(Element dateTextBox, bool exitFocusOnComplete = false)
    {
        _dateTextBox = dateTextBox;
        if (exitFocusOnComplete)
        {
            _setMethod = (el, date) => el.SetTextAndUnfocus(date);
        }
        else
        {
            _setMethod = (el, date) => el.SetText(date);
        }
    }

    public void EnterDefaultDate()
    {
        _setMethod(_dateTextBox, DateTime.Now.ToString("d"));
    }

    public void SelectDate(string dateString)
    {
        _setMethod(_dateTextBox, dateString);
    }

    public void SelectDate(DateTime date)
    {
        _setMethod(_dateTextBox, date.ToString("d"));
    }

    public void AssertIsVisible(int waitSeconds = DatePickerConstants.DEFAULT_WAIT_SECONDS)
    {
        _dateTextBox.AssertElementIsVisible(waitSeconds);
    }

    public string GetDateString(int waitSeconds = DatePickerConstants.DEFAULT_WAIT_SECONDS) 
    {
        return _dateTextBox.GetAttribute("value");
    }

    public DateTime GetDateValue(int waitSeconds = DatePickerConstants.DEFAULT_WAIT_SECONDS)
    {
        return DateTime.Parse(_dateTextBox.GetAttribute("value"));
    }
}