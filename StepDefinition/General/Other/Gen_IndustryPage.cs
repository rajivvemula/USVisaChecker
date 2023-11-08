using HitachiQA.Driver;
using HitachiQA.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.Other.Industries
{
    [Binding]
    public sealed class Gen_IndustryPage
    {
        private string _parsedIndustry;

        [When(@"user validates the (.*) industry page")]
        public void WhenUserValidatesTheIndustryPage(string industry)
        {
            _parsedIndustry = GetParsedIndustryName(industry);

            AutomationHelper.ValidateElements(IndustryPageElements);
        }

        public string GetParsedIndustryName(string industry)
        {
            Regex regex = new Regex(@"\w+");
            var parsedIndustryArr = regex.Matches(industry);

            return string.Join("-", parsedIndustryArr.ToList()).ToLower();
        }

        public List<Element> IndustryPageElements => new List<Element>
        {
            IndustryPage.InsuranceTitle(_parsedIndustry),
            IndustryPage.MainParagraph,
            IndustryPage.GetAQuoteBtn
        };
    }
}
