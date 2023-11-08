using System;
using HitachiQA;
using HitachiQA.Helpers;
using TechTalk.SpecFlow;

namespace BiBerkLOB.StepDefinition.MetaTestSteps;

[Binding]
public class FunctionsDateTimeSteps
{
    private static readonly TimeZoneInfo TimeZoneOverride = TimeZoneInfo.FindSystemTimeZoneById(Environment.GetEnvironmentVariable("TIMEZONE_OVERRIDE"));

    private DateTime _setDate;
    private DateTime _setDateUtc;
    private int _numToAdd;
    private string _unit;

    private DateTime _result;

    [Given(@"the date is set to (\d+/\d+/\d+) and the time is set to (\d+:\d+:\d+\.{0,1}\d*) from the overriden timezone")]
    public void GivenDateIsSetTimezone(string date, string time)
    {
        var datePart = DateTime.Parse(date);
        var timePart = DateTime.Parse(time);
        var kind = DateTimeKind.Unspecified;

        var dateTimeFromTimezone = CombineDateAndTimeForKind(datePart, timePart, kind);
        _setDate = dateTimeFromTimezone;
        _setDateUtc = TimeZoneInfo.ConvertTimeToUtc(dateTimeFromTimezone, TimeZoneOverride);
    }

    [Given(@"the date is set to (\d+/\d+/\d+) and the time is set to (\d+:\d+:\d+\.{0,1}\d*) from the system timezone")]
    public void GivenDateIsSetLocal(string date, string time)
    {
        var datePart = DateTime.Parse(date);
        var timePart = DateTime.Parse(time);
        var kind = DateTimeKind.Local;

        var dateTimeLocal = CombineDateAndTimeForKind(datePart, timePart, kind);
        _setDate = dateTimeLocal;
        _setDateUtc = TimeZoneInfo.ConvertTimeToUtc(dateTimeLocal);
    }

    [Given(@"the date is set to (\d+/\d+/\d+) and the time is set to (\d+:\d+:\d+\.{0,1}\d*) in UTC")]
    public void GivenDateIsSetUtc(string date, string time)
    {
        var datePart = DateTime.Parse(date);
        var timePart = DateTime.Parse(time);
        var kind = DateTimeKind.Utc;

        var dateTimeUtc = CombineDateAndTimeForKind(datePart, timePart, kind);
        _setDate = dateTimeUtc;
        _setDateUtc = dateTimeUtc;
    }

    private static DateTime CombineDateAndTimeForKind(DateTime datePart, DateTime timePart, DateTimeKind kind)
    {
        var dateTimeUtc = new DateTime(datePart.Year, datePart.Month, datePart.Day, timePart.Hour, timePart.Minute,
            timePart.Second, kind: kind);
        return dateTimeUtc;
    }


    [When(@"code gets (.*) (day|days|month|months|year|years) from now")]
    public void WhenCodeGetsDaysFromNow(int num, string unit)
    {
        _numToAdd = num;
        _unit = unit switch
        {
            "day" or "days" => "d",
            "month" or "months" => "m",
            "year" or "years" => "y"
        };

        _setDate = DateTime.UtcNow;
        _setDateUtc = DateTime.UtcNow;
        _result = Functions.GetDifferentDateFromNow(_numToAdd, _unit);
    }

    [When(@"code gets (.*) (day|days|month|months|year|years) from set date")]
    public void WhenCodeGetsDaysFromSetDate(int num, string unit)
    {
        _numToAdd = num;
        _unit = unit switch
        {
            "day" or "days" => "d",
            "month" or "months" => "m",
            "year" or "years" => "y"
        };
        
        _result = Functions.GetDifferentDateFrom(_setDate, _numToAdd, _unit);
    }

    [Then(@"the returned date/time should be in the overridden timezone")]
    public void ThenTheReturnedDateTimeShouldBeInTheOverriddenTimezone()
    {
        Assert.AreNotEqual(_result.Kind, DateTimeKind.Utc);

        var utcResult = TimeZoneInfo.ConvertTimeToUtc(_result, TimeZoneOverride);
        var timezoneAfterUtcResult = TimeZoneInfo.ConvertTimeFromUtc(utcResult, TimeZoneOverride);

        Assert.AreEqual(_result, timezoneAfterUtcResult);
    }

    [Then(@"the expected date/time should be approximately correct")]
    public void ThenTheExpectedDateTimeShouldBeApproxCorrect()
    {
        // range comparison due to version that uses "now" required to get time at point of call
        AssertResult(false);
    }

    [Then(@"the expected date/time should be correct")]
    public void ThenTheExpectedDateTimeShouldBeCorrect()
    {
        AssertResult(true);
    }

    private void AssertResult(bool strictEquality)
    {
        var setDateInTimezone = TimeZoneInfo.ConvertTimeFromUtc(_setDateUtc, TimeZoneOverride);
        var expected = _unit switch
        {
            "d" => setDateInTimezone.AddDays(_numToAdd),
            "m" => setDateInTimezone.AddMonths(_numToAdd),
            "y" => setDateInTimezone.AddYears(_numToAdd)
        };

        if (strictEquality)
        {
            Assert.AreEqual(_result, expected);
        }
        else
        {
            AssertDatesAreLessThanHalfSecondApart(_result, expected);
        }
    }

    private void AssertDatesAreLessThanHalfSecondApart(DateTime actual, DateTime expected)
    {
        var diff = actual - expected;
        Assert.IsTrue(diff.Duration() < TimeSpan.FromMilliseconds(500));
    }
}