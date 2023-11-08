using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages
{
    
    class LossControlPage
    {
        public static Element TitleLossControl => new Element(By.XPath("//h1[@class = 'center h2']"));
        public static Element OnlineSafetyTraining => new Element(By.XPath("//h2[contains(text(),'Online Safety Training')]"));
    }
}
