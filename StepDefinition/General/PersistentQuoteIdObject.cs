using BiBerkLOB.Source.Helpers;
using HitachiQA;

namespace BiBerkLOB.StepDefinition.General;

[ResettableContextObject]
public class PersistentQuoteIdObject : IDataSource
{
    public string LOB { get; set; }
    public string QuoteId { get; set; }
    public string State { get; set; }
    public string Industry { get; set; }
    public string SaveReason { get; set; }

    public string ToDataString()
    {
        if (!string.IsNullOrEmpty(SaveReason))
        {
            return $"({SaveReason}) {FormattedQuoteId}";
        }
        return FormattedQuoteId;
    }

    private string FormattedQuoteId => $"{Industry} {LOB} Quote ID in {State}: {QuoteId}";
}