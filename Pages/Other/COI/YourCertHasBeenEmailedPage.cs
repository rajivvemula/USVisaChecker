using HitachiQA.Driver;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace BiBerkLOB.Pages.Other.COI
{
    public sealed class YourCertHasBeenEmailedPage
    {
        public static Element YourCertHasBeenEmailedTitle => new Element(By.XPath("//h1[@data-qa='certificate-header']"));
        public static Element YourCertHasBeenEmailedCopy => new Element(By.XPath("//p[@data-qa='certificate-subheader']"));


        public static List<Element> YourCertHasBeenEmailedElements = new List<Element>
        {
            YourCertHasBeenEmailedTitle,
            YourCertHasBeenEmailedCopy
        };
    }
}