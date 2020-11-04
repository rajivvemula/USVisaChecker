using ApolloQA.Source.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages
{
    class WaffleMenu
    {
        public static Element underwritingButton => new Element("//*[contains(text(), 'Underwriting')]");
        public static Element billingButton => new Element("//*[contains(text(), 'Billing')]");
        public static Element administrationButton => new Element("//*[contains(text(), 'Administration')]");
        public static Element collectionsCenterButton => new Element("//*[contains(text(), 'Collections Center')]");
        public static Element printCenterButton => new Element("//*[contains(text(), 'Print Center')]");
        public static Element claimsButton => new Element("//*[contains(text(), 'Claim')]");
    }
}
