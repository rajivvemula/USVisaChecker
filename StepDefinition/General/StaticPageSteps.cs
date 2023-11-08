using BiBerkLOB.Source.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiBerkLOB.Pages;
using BiBerkLOB.Pages.Other.Industries;
using BiBerkLOB.Source.Helpers;
using BiBerkLOB.StepDefinition.General.GenAutomation;
using HitachiQA;
using HitachiQA.Driver;
using HitachiQA.Helpers;
using TechTalk.SpecFlow;

namespace BiBerkLOB.StepDefinition.General
{
    [Binding]
    public sealed class StaticPageSteps
    {
        private readonly StaticPageValidator _validator;
        private readonly ExpectedCoverageCards _expectedCoverages;

        public StaticPageSteps(StaticPageValidator validator, ExpectedCoverageCards expectedCoverages)
        {
            _validator = validator;
            _expectedCoverages = expectedCoverages;
        }

        [Then(@"user validates the static page: (.*)")]
        public void ValidateStaticPage(string pageName)
        {
            _validator.ValidateStaticPage(pageName);
        }
   
        [Then(@"user validates coverages cards: (.*)")]
        public void ThenUserValidatesLOBCards(string coverages)
        {
            var expectedCoveragesList = Functions.ParseSemicolonSeparatedList(coverages);
            _expectedCoverages.Coverages.AddRange(expectedCoveragesList.Select(cov => Enum.Parse<CoverageType>(cov)));

            foreach (var coverage in Enum.GetValues<CoverageType>())
            {
                if (_expectedCoverages.Coverages.Contains(coverage))
                {
                    CoverageCardMap.LobCards[coverage].AssertCardIsVisible();
                }
                else
                {
                    CoverageCardMap.LobCards[coverage].AssertCardIsNotVisible();
                }
            }
        }

        [Then(@"user sees links in the following coverages: (.*)")]
        public void ThenUserSeesLinksInTheFollowingLobs(string coverages)
        {
            var linkedCoverageSections = Functions.ParseSemicolonSeparatedList(coverages);
            foreach (var expectedLob in _expectedCoverages.Coverages)
            {
                var paragraph = CoverageCardMap.LobCards[expectedLob].Body;
                var numLinks = CountLinksInParagraph(paragraph);
                if (linkedCoverageSections.Contains(expectedLob.ToString()))
                {
                    Assert.AreNotEqual(numLinks, 0);
                    ValidateLinks(numLinks, paragraph);
                }
                else
                {
                    Assert.AreEqual(numLinks, 0);
                }
            }
        }

        private static void ValidateLinks(int numLinks, Element paragraph)
        {
            for (int i = 1; i <= numLinks; i++)
            {
                var linkXpath = $"({AutomationHelper.GetElementXPath(paragraph)}//a)[{i}]";
                var linkElement = new Element(linkXpath);

                linkElement.Click();
                Reusable_PurchasePath.Logo.AssertElementIsVisible();
                Reusable_PurchasePath.Error404.AssertElementNotPresent(StaticPageValidator.STATIC_PAGE_WAIT);
                Setup.driver.Navigate().Back();
            }
        }

        private int CountLinksInParagraph(Element paragraph)
        {
            int count = 0;
            bool stillCounting = true;
            do
            {
                var linkXpath = $"({AutomationHelper.GetElementXPath(paragraph)}//a)[{count + 1}]";
                var linkElement = new Element(linkXpath);
                
                stillCounting = linkElement.AssertElementIsVisible(StaticPageValidator.STATIC_PAGE_WAIT, true);
                
                if (stillCounting)
                {
                    count++;
                }
            } while (stillCounting);
            return count;
        }
    }
}
