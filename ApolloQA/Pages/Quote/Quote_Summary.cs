using System;
using System.Collections.Generic;
using System.Text;
using ApolloQA.Source.Driver;
using ApolloQA.Source.Helpers;

namespace ApolloQA.Pages.Quote
{
    public class Quote_Summary
    {
        public static Element PremiumMonthly = new Element("//mat-card[descendant::*[text()='Monthly']] //*[@class='premium-display']");
        public static Element PremiumYearly = new Element("//mat-card[descendant::*[text()='Yearly']] //*[@class='premium-display']");

    }
}
