using System;
using System.Collections.Generic;
using System.Text;
using ApolloQA.Source.Driver;
using ApolloQA.Source.Helpers;

namespace ApolloQA.Pages.Quote
{
    public class Quote_Summary
    {
        public static Element TotalPremiumInput = new Element("//mat-form-field[descendant::*[text()='Total Premium']] //input");
    }
}
