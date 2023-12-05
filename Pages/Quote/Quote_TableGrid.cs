using System.Collections.Generic;
using HitachiQA.Driver;

namespace ApolloQAAutomation.Pages.Quote
{
    public sealed class Quote_TableGrid
    {
        /**************************************
        *                                    *
        *        QUOTE GRID COLUMNS          *
        *                                    *
        **************************************/
        public static Element QuoteNo => new("//datatable-header-cell[@title='Quote No.']");
        public static Element NamedInsured => new("//datatable-header-cell[@title='Named Insured']");
        public static Element DBA => new("//datatable-header-cell[@title='DBA']");
        public static Element QuoteStatus => new("//datatable-header-cell[@title='Quote Status']");
        public static Element PolicyPeriod => new("//datatable-header-cell[@title='Policy Period']");
        public static Element LOB => new("//datatable-header-cell[@title='LOB']");
        public static Element StateRegion => new("//datatable-header-cell[@title='State/Region']");
        public static Element QuotedAnnualPremium => new("//datatable-header-cell[@title='Quoted Annual Premium']");

        public static Element NewQuoteBtn => new("//button[.//span[contains(text(),'New')]]");

        public static List<Element> QuoteGridColumns = new()
        {
            QuoteNo,
            NamedInsured,
            DBA,
            QuoteStatus,
            PolicyPeriod,
            LOB,
            StateRegion,
            QuotedAnnualPremium
        };
    }
}