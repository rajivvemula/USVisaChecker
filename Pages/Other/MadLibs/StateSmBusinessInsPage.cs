using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages
{
    
    class StateSmBusinessInsPage : Reusable_PurchasePath
    {
        public static Element getTitleOfStatePage(string stateSelected)
        {
            return new Element(By.XPath("//h1[contains(text(), '" + stateSelected + " Small Business Insurance')]"));
        }
        public static Element subTitleOfStatePage => new Element(By.XPath("//h5[contains(text(), 'Simple and easy insurance for your small business.')]"));
    }
}
