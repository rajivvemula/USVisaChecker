using System;

namespace HitachiQA.Driver;

public interface IDatePicker
{
    void EnterDefaultDate();
    void SelectDate(string dateString);
    void SelectDate(DateTime date);
    void AssertIsVisible(int waitSeconds = DatePickerConstants.DEFAULT_WAIT_SECONDS);
    string GetDateString(int waitSeconds = DatePickerConstants.DEFAULT_WAIT_SECONDS);
    DateTime GetDateValue(int waitSeconds = DatePickerConstants.DEFAULT_WAIT_SECONDS);
}

public static class DatePickerConstants
{
    public const int DEFAULT_WAIT_SECONDS = UserActions.DEFAULT_WAIT_SECONDS;
}