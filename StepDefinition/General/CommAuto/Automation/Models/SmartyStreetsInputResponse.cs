using BiBerkLOB.Source.Driver;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation.Models;

public class SmartyStreetsInputResponse
{
    public Address Address { get; set; }
    public SmartyStreetsSuggestion Suggestion { get; set; }
}

public enum SmartyStreetsSuggestion
{
    NoAction, AsEntered, Suggested
}