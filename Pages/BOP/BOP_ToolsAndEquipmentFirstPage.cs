using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BiBerkLOB.Source.Driver;
using BiBerkLOB.Source.Driver.Input;

using HitachiQA.Driver.Input;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.BOP
{
    public sealed class BOP_ToolsAndEquipmentFirstPage
    {

        //Header
        public static Element ToolsEquipmentHeader => new Element(By.XPath("//h1[@data-qa='Tools-label']"));
        public static Element ToolsEquipmentText => new Element(By.XPath("//h6[@data-qa='Tools-sub-label']"));

        //Questions
        //Do you want to insure any individual tools or equipment that are valued over $2,000? 
        public static Element Tools2000QST => new Element(By.XPath("//label[@data-qa='_apollo_Tools2000-label']"));
        public static Element Tools2000YesButton => new Element(By.XPath("//button[@data-qa='_apollo_Tools2000-8035-yes-button']"));
        public static Element Tools2000NoButton => new Element(By.XPath("//button[@data-qa='_apollo_Tools2000-8035-no-button']"));
        public static InputSection Tools2000Input => new YesOrNoInput(Tools2000YesButton, Tools2000NoButton).AsAQuestion(Tools2000QST);
        public static Element Tools2000ErrorMsg => new Element(By.XPath("//bb-error-message[@data-qa='_apollo_Tools2000-errorMessage']"));

    }
}
