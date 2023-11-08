using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiBerkLOB.Pages.Other
{
    public sealed class TermsAndConditionsPage
    {
        public static Element HeaderLabel => new Element(By.XPath("//h1[@data-qa='terms']"));
    }
}