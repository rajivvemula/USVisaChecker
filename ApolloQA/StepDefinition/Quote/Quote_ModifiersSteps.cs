using ApolloQA.Pages;
using ApolloQA.Pages.Quote;
using ApolloQA.Source.Driver;
using ApolloQA.Source.Helpers;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace ApolloQA.StepDefinition.Quote
{
    [Binding]
    public class Quote_ModifiersSteps
    {
        [Then(@"User Verifies all inputs are interactable")]
        public void ThenUserVerifiesAllInputsAreInteractable()
        {
            Quote_Modifier.MODExp.Click();
            Quote_Modifier.MODExp.setText("5");
            Quote_Modifier.MODMan.setText("5");
            Quote_Modifier.MODEmp.setText("5");
            Quote_Modifier.MODEquip.setText("5");
            Quote_Modifier.MODSafety.setText("5");
            Quote_Modifier.MODClass.setText("5");
        }

        [Then(@"User verifies the Upper Boundaries for IL")]
        public void ThenUserVerifiesTheUpperBoundariesForIL()
        {
            foreach (var item in ModValues)
            {
                Element MODFactor = new Element($"//mat-card[*/*/*/h2[text()='{item.Key}']] //div[@class='factor'][2] //input");
                MODFactor.clearTextField();
                MODFactor.setText(item.Value.ToString());
                Element ModTotal = new Element($"//mat-card[*/*/*/h2[text()='{item.Key}']] //div[@class='factor'][3] ");
                string ModTotalValue = ModTotal.GetInnerText();
                Assert.TextContains(ModTotalValue, item.Value.ToString());

            }
        }

        [Then(@"User verifies the Lower Boundaries for IL")]
        public void ThenUserVerifiesTheLowerBoundariesForIL()
        {
            foreach (var item in ModValues)
            {
                Element MODFactor = new Element($"//mat-card[*/*/*/h2[text()='{item.Key}']] //div[@class='factor'][2] //input");
                MODFactor.clearTextField();
                string newItemValue = item.Value.ToString();
                MODFactor.setText(newItemValue);
                Element ModTotal = new Element($"//mat-card[*/*/*/h2[text()='{item.Key}']] //div[@class='factor'][3]");
                string ModTotalValue = ModTotal.GetInnerText();
                Assert.TextContains(ModTotalValue, newItemValue);
            }
        }

        [Then(@"User verifies the Modifier Total percentage is correct")]
        public void ThenUserVerifiesTheModifierTotalPercentageIsCorrect()
        {
            string totalCheck = Quote_Modifier.MODTotal.GetInnerText();

            Assert.TextContains(totalCheck, "25.000%");
        }

        [Then(@"User verifies unable to click next when past max percentage boundary")]
        public void ThenUserVerifiesUnableToClickNextWhenPastMaxPercentageBoundary()
        {
            Quote_Modifier.MODExp.clearTextField();
            Quote_Modifier.MODExp.setText("60");
            bool checkButton = Shared.GetButton("Next").IsDisabled;
            Assert.IsTrue(checkButton);


        }

        [Then(@"User enters max values for each modifier")]
        public void ThenUserEntersMaxValuesForEachModifier()
        {
            Quote_Modifier.MODExp.Click();
            Quote_Modifier.MODExp.setText("5");
            Quote_Modifier.MODMan.setText("5");
            Quote_Modifier.MODEmp.setText("5");
            Quote_Modifier.MODEquip.setText("5");
            Quote_Modifier.MODSafety.setText("5");
            Quote_Modifier.MODClass.setText("5");

        }

        [Then(@"User verifies the percentage values are displayed correctly")]
        public void ThenUserVerifiesThePercentageValuesAreDisplayedCorrectly()
        {
            foreach (var item in ModValues)
            {
                Element MODFactor = new Element($"//mat-card[*/*/*/h2[text()='{item.Key}']] //span[normalize-space(text())='(-{item.Value}% to {item.Value}%)']");
                bool assertPresent = MODFactor.assertElementIsVisible();

                Assert.IsTrue(assertPresent);
            }
        }


        [Then(@"User verifies max values are retained for each modifier")]
        public void ThenUserVerifiesMaxValuesAreRetainedForEachModifier()
        {
            string totalCheck = Quote_Modifier.MODTotal.GetInnerText();
            Assert.TextContains(totalCheck, "25.000");
        }
        public static Dictionary<string, int> ModValues = new Dictionary<string, int>()
        {
            {"Experience Rating", 25 },
            {"Management", 40 },
            {"Employees", 40 },
            {"Equipment", 40 },
            {"Safety Organization", 40 },
            {"Classification", 40 }

        };
    }
}
