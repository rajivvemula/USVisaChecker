using HitachiQA.Driver;
using HitachiQA.Driver.Input;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiBerkLOB.Pages.Other.BSP
{
    public class BSP_Reusable
    {
        // Header
        public static Element SearchBox => new Element(By.XPath("//input[@data-qa='searchbox-input']"));
        public static Element SearchBoxPolicyNumberButton => new Element(By.XPath("//label[@data-qa='policynumber-search-label']"));
        public static Element ActivityHeader => new Element(By.XPath("//h1[text()='Activity']"));
        public static Element NoRecordsAvailable => new Element(By.XPath("//span[text()='No records available.']"));
        public static InputSection SearchBoxInput =>
            new TextBoxInput(SearchBox);
        public static Element SettingsIcon => new Element(By.XPath("//a[@data-qa='sidenav-settings']"));
    }
}