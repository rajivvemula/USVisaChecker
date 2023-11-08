using DocumentFormat.OpenXml.Vml.Office;
using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiBerkLOB.Pages.Other.FAQs
{
    public class BaseFAQPage
    {
        //Frequently Asked Questions title
        //Missing a data-qa attribute
        public static Element FAQTitle => new Element(By.XPath("//div[contains(@class, 'h2') and text()='Frequently Asked Questions' ]"));

        //Search bar
        //Missing a data-qa attribute
        public static Element SearchBar => new Element(By.XPath("//input[@name='search']"));
    }
}