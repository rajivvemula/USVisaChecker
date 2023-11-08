using BiBerkLOB.Pages;
using System.Text.RegularExpressions;
using BiBerkLOB.Pages.CommAuto;
using BiBerkLOB.Pages.Other.MadLibs;
using BiBerkLOB.Pages.PL;
using BiBerkLOB.Pages.WC;
using BiBerkLOB.StepDefinition.General;

namespace BiBerkLOB.Source.Helpers
{
    public class QuoteIDRetriever
    {
        private readonly CASummaryObject _caSummaryObject;
        private readonly WCYourQuoteObject _wcQuoteObject;
        private PLSummaryObject _plSummaryObject;
        private readonly MadLibsSummaryObject _MadLibsSummaryObject;
        private readonly PersistentQuoteIdObject _persistentQuoteId;

        public QuoteIDRetriever(CASummaryObject caSummaryObject, WCYourQuoteObject wcQuoteObject, PLSummaryObject plSummaryObject, MadLibsSummaryObject MadLibsSummaryObject, PersistentQuoteIdObject persistentQuoteId)
        {
            _caSummaryObject = caSummaryObject;
            _wcQuoteObject = wcQuoteObject;
            _plSummaryObject = plSummaryObject;
            _MadLibsSummaryObject = MadLibsSummaryObject;
            _persistentQuoteId = persistentQuoteId;
        }

        //pull the quoteid off the page, make sure it's in proper format
        //save off the quoteid for later comparison
        public string CaptureQuoteIdFromRibbonText()
        {
            var quoteIdText = _MadLibsSummaryObject.LOB?.ToLower() switch
            {
                "ca" => Reusable_PurchasePath.YourCommAutoQuoteID.GetInnerText(),
                "wc" => Reusable_PurchasePath.YourWCQuoteID.GetInnerText(),
                "pl" => Reusable_PurchasePath.YourPLQuoteID.GetInnerText(),
                "bop" => null, // Need to add QuoteID for BOP
                _ => "Undefined LOB",
            };

            var indexOfNumber = quoteIdText.IndexOfAny("0123456789".ToCharArray());
            return quoteIdText[indexOfNumber..].Trim();
        }

        public string GetLOBQuoteID()
        {
            if (_persistentQuoteId.QuoteId != null)
                return _persistentQuoteId.ToDataString();
            else
                return LOBQuoteID();
        }

        private string LOBQuoteID()
        {
            return "QuoteID : " + _MadLibsSummaryObject.LOB?.ToLower() switch
            {
                "ca" => _caSummaryObject.QuoteID,
                "wc" => _wcQuoteObject.QuoteID,
                "pl" => _plSummaryObject.QuoteID,
                "bop" => null, // Need to add QuoteID for BOP
                _ => "Undefined LOB",
            };
        }
    }
}

