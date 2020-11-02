using ApolloQA.Source.Driver;
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
