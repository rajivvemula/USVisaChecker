using ApolloQA.Source.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages
{
    class BusinessInformation
    {
        public static Element businessEmailAddressField => new Element("//input[@name='orgEmailAddress']");
    }
}
