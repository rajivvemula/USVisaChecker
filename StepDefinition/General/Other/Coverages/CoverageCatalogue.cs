using HitachiQA.Driver;
using System.Text.RegularExpressions;
using BiBerkLOB.Source.Helpers;
using BiBerkLOB.StepDefinition.General.GenAutomation;
using HitachiQA.Helpers;

namespace BiBerkLOB.StepDefinition.General.Other.Coverages
{
    public class CoverageCatalogue
    {
        public int Count;
        public Element ListElement;

        public CoverageCatalogue(Element listElement,int count) 
        {
            ListElement = listElement;
            Count = count;
        }

        public void ValidateListItems() 
        {
            for (int i = 1; i < Count; i++)
            {
                var path = AutomationHelper.GetElementXPath(ListElement);
                var listItemPath = $"({path}//li)[{i}]";
                var listItem = new Element(listItemPath);

                listItem.AssertElementIsVisible();
            }
        }
    }
}
