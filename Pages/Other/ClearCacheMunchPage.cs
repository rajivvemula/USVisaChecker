using HitachiQA.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages
{
    [Binding]
    public sealed class ClearCacheMunchPage
    {
        public static Element MunchTitle => new Element("//h3[contains(text(),'Your cookies have been devoured.')]");

        public static Element MegaMunchButton => new Element("//button[@class='btn-cta au-target' and @click.trigger='mega()']");

        public static Element returnToHomePageButton => new Element("//button[@class='btn-cta au-target' and @click.trigger='goHome()']");
    }
}
