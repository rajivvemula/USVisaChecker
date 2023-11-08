using HitachiQA.Driver;
using OpenQA.Selenium;

namespace BiBerkLOB.Pages.Other.Industries;

public class IndustryPage
{
    // Heading banner
    public static Element InsuranceTitle(string parsedIndustry) => new Element(By.XPath($"//h1[contains(@data-qa,'{parsedIndustry}-insurance')]"));
    public static Element MainParagraph => new Element(By.XPath("//div[@data-qa='page-banner-subtitle']"));
    public static Element GetAQuoteBtn => new Element(By.XPath("//button[contains(@data-qa,'page-banner-button')]"));
}