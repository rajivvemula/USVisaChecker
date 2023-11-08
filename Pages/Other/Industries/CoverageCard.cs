using BiBerkLOB.Source.Driver;
using BiBerkLOB.StepDefinition.General;
using HitachiQA;
using HitachiQA.Driver;
using OpenQA.Selenium;

namespace BiBerkLOB.Pages.Other.Industries;

public class CoverageCard
{
    public Element Title { get; private set; }
    public Element Body { get; private set; }
    public Element CTAButton { get; private set; }

    private string _lobSlug;
    
    public CoverageCard(CoverageType coverageType, string lobSlug)
    {
        var lob = coverageType.ToString().ToLower();

        Title = new Element(By.XPath($"//h3[contains(@data-qa,'lob-cards-{lob}-header')]"));
        Body = new Element(By.XPath($"//p[@class='lob-cards-{lob}-text']"));
        CTAButton = new Element(By.XPath($"//a[contains(@data-qa,'lob-cards-{lob}-button')]"));

        _lobSlug = lobSlug;
    }

    public void AssertCardIsVisible()
    {
        Title.AssertElementIsVisible(StaticPageValidator.STATIC_PAGE_WAIT);
        Body.AssertElementIsVisible(StaticPageValidator.STATIC_PAGE_WAIT);
        CTAButton.AssertElementIsVisible(StaticPageValidator.STATIC_PAGE_WAIT);
        Assert.TextContains(CTAButton.GetAttribute("href"), _lobSlug);
    }

    public void AssertCardIsNotVisible()
    {
        Title.AssertElementNotPresent(StaticPageValidator.STATIC_PAGE_WAIT);
        Body.AssertElementNotPresent(StaticPageValidator.STATIC_PAGE_WAIT);
        CTAButton.AssertElementNotPresent(StaticPageValidator.STATIC_PAGE_WAIT);
    }
}