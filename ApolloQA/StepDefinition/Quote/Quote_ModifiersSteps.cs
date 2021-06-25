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

        [Then(@"User verifies the Upper Boundaries for (.*)")]
        public void ThenUserVerifiesTheUpperBoundariesForIL(string state)
        {
            foreach (var item in ModifiersValues)
            {
                var row = GetStateModifier(state, item.ToUpper());
                Log.Debug(row);
                Element MODFactor = new Element($"//mat-card[*/*/*/h2[text()='{item}']] //div[@class='factor'][2] //input");
                if (MODFactor.assertElementIsPresent(30))
	            {           
                    MODFactor.clearTextField();
                    MODFactor.setText(row["Maximum Schedule Rating Credit"]);
                    Element ModTotal = new Element($"//mat-card[*/*/*/h2[text()='{item}']] //div[@class='factor'][3]");
                    string ModTotalValue = ModTotal.GetInnerText();
                    Assert.TextContains(ModTotalValue.Remove(ModTotalValue.Length - 2, 1), row["Maximum Schedule Rating Credit"]);

	            }

            }
        }

        [Then(@"User verifies the Lower Boundaries for (.*)")]
        public void ThenUserVerifiesTheLowerBoundariesForIL(string state)
        {
            foreach (var item in ModifiersValues)
            {
                var row = GetStateModifier(state, item.ToUpper());
                Log.Debug(row);
                Element MODFactor = new Element($"//mat-card[*/*/*/h2[text()='{item}']] //div[@class='factor'][2] //input");
                 if (MODFactor.assertElementIsPresent(30))
	            {     
                    MODFactor.clearTextField();
                    MODFactor.setText(row["Maximum Schedule Rating Credit"]);
                    Element ModTotal = new Element($"//mat-card[*/*/*/h2[text()='{item}']] //div[@class='factor'][3]");
                    string ModTotalValue = ModTotal.GetInnerText();
                    Assert.TextContains(ModTotalValue.Remove(ModTotalValue.Length - 2, 1), row["Maximum Schedule Rating Credit"]);
                }
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

        [Then(@"User verifies the percentage values are displayed correctly for (.*)")]
        public void ThenUserVerifiesThePercentageValuesAreDisplayedCorrectlyForIL(string state)
        {
            foreach (var item in ModifiersValues)
            {
                var row = GetStateModifier(state, item.ToUpper());
                string NoDecimal = row["Maximum Schedule Rating Credit"].Remove(2, 3);
                Element MODFactor = new Element($"//mat-card[*/*/*/h2[text()='{item}']] //span[normalize-space(text())='(-{NoDecimal} to {NoDecimal})']");
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


        string[] ModifiersValues = { "Management", "Employees", "Equipment", "Safety Organization", "Classification" };
        public static dynamic GetStateModifier(string state, string category)
        {
            var st1Table = Data.Rating.Engine.getTable("ST.1", state);
            var classificationRow = st1Table.Find(row => row["Schedule Rating Category"] == category);
            return classificationRow;
        }
    }
}
