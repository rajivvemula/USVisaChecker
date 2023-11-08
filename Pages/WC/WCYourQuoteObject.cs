using HitachiQA;
using System.ComponentModel;

namespace BiBerkLOB.Pages.WC
{
    [ResettableContextObject]
    public sealed class WCYourQuoteObject
    {
        public int IncludedOfficers { get; set; }
        public int ExcludedOfficers { get; set; }
        [DefaultValue("")] public string State { get; set; } = "";
        [DefaultValue("")] public string PaymentOption { get; set; } = "";
        [DefaultValue("")] public string QuoteID { get; set; } = "";
    }
}