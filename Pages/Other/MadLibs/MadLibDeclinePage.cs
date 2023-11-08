using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HitachiQA.Driver;
using OpenQA.Selenium;
namespace BiBerkLOB.Pages.Other.MadLibs
{
     class MadLibDeclinePage
    {
        public static Element declinePagetitle => new Element(By.XPath("//h1[@data-qa='page-title']"));
        public static Element declinePagesubtext => new Element(By.XPath("//h5[@data-qa='page-sub-title']"));
        public static Element contactTivlyPhone => new Element(By.XPath("//a[@data-qa='contact-phone-tivly']"));
        public static Element getTivlyQuote => new Element(By.XPath("//button[@data-qa='buttonGetTivlyQuote']"));

    }
}