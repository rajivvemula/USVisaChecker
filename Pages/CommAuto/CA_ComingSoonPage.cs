using DocumentFormat.OpenXml.Office2010.ExcelAc;
using HitachiQA.Driver;
using OpenQA.Selenium;
using System.Collections.Generic;
using BiBerkLOB.Pages.Other;

namespace BiBerkLOB.Pages.CommAuto
{
    [StaticPageName("Coming Soon")]
    public sealed class CA_ComingSoonPage : IStaticPage
    {
        public static Element ComingSoonTitle => new Element(By.XPath("//h2[@data-qa='more-info-label']"));
        public static Element ComingSoonReturnCTA => new Element(By.XPath("//a[@data-qa='basic-header-text-button']"));
    }
}