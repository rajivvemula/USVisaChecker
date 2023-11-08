using HitachiQA.Driver;
using OpenQA.Selenium;

namespace BiBerkLOB.Pages.Other.States;

public class StatePage
{
    // Heading banner
    public static Element PageTitle(string pageTitle) => new Element(By.XPath($"//h1[contains(@data-qa,'{pageTitle.ToLower()}-business-insurance')]"));
    public static Element GetAQuoteBtn => new Element(By.XPath("//button[contains(@data-qa,'page-banner-button')]"));
    public static Element MainParagraph => new Element(By.XPath("//p[contains(@data-qa,'lob-cards-main-text')]"));
}