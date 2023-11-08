using HitachiQA.Driver;
using HitachiQA.Driver.Input;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation.Models;

public class SmartyStreetAddressElements
{
    public InputSection? AddressLine1 { get; init; } = null;
    public InputSection? AddressLine2 { get; init; } = null;
    public InputSection? City { get; init; } = null;
    public InputSection? State { get; init; } = null;
    public InputSection? ZipCode { get; init; } = null;

    public Element LoadingBar { get; init; }
    public Element SuggestionBoxTitle { get; init; }
    public Element AsEnteredBtn { get; init; }
    public Element SuggestedBtn { get; init; }
}