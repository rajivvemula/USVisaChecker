using System;
using System.Collections.Generic;
using System.Text;
using ApolloQA.Source.Driver;
using ApolloQA.Source.Helpers;

namespace ApolloQA.Pages
{
    class Quote_Drivers
    {
        public static Element ExpandAllButton => new Element("//button//*[contains(text(), ' Expand All ')]");
        public static Element ExpandedInfo => new Element("//*[@style='padding-left: 35px; flex-direction: row; box-sizing: border-box; display: flex;']");
        public static Element CollapseAllButton => new Element("//button//*[contains(text(), ' Collapse All ')]");
    }
}
