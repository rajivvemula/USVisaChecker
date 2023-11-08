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
    public sealed class BOP_ToolsandEquipmentSecondPage
    {
        public static Element ItemLabel => new Element(By.XPath("//h6[@data-qa='ITEM-label']"));
        public static Element ItemDescriptionLabel(int count) => new Element(By.XPath($"//label[@data-qa='_apollo_ToolDesc_{count}-label']"));
        public static Element ItemDescriptionTextBox(int count) => new Element(By.XPath($"//input[@data-qa='_apollo_ToolDesc_{count}']"));
        public static Element ItemDescriptionHintText(int count) => new Element(By.XPath($"//mat-hint[@data-qa='_apollo_ToolDesc_{count}-hint']"));
        public static Element ItemDescriptionErrorMessage(int count) => new Element(By.XPath($"//bb-error-message[@data-qa='_apollo_ToolDesc_{count}-errorMessage']"));
        public static Element TotalCostToReplaceLabel(int count) => new Element(By.XPath($"//label[@data-qa='_apollo_ToolReplacementCost_{count}-label'"));
        public static Element TotalCostToReplaceTextBox(int count) => new Element(By.XPath($"//label[@data-qa='_apollo_ToolReplacementCost_{count}-label'"));
        public static Element TotalCostToReplaceErrorMessage(int count) => new Element(By.XPath($"//bb-error-message[@data-qa='_apollo_ToolReplacementCost_{count}-errorMessage']"));
        public static Element TotalCostToReplaceHintText(int count) => new Element(By.XPath($"//mat-hint[@data-qa='_apollo_ToolReplacementCost_{count}-hint']"));
        public static Element AddItemPanel => new Element(By.XPath("//bb-add-panel[@data-qa='Item-addPanel']"));
        public static Element ExpandItemPanelHeader => new Element(By.XPath("//mat-expansion-panel-header[@data-qa='ITEM - Test-expansion-panel-label']"));
        public static Element RemoveItemPanel => new Element(By.XPath("//bb-remove-panel[@data-qa='ITEM - Test-Remove-button']"));
    }
}
