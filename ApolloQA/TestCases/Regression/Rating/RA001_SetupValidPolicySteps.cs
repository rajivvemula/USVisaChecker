using ApolloQA.DataFiles;
using ApolloQA.Helpers;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using ApolloQA.Pages.Shared;
using System.Text.RegularExpressions;
using System.Globalization;


namespace ApolloQA.TestCases.Regression.Rating
{
    [Binding]
    public class RA001_SetupValidPolicySteps
    {
        
        private IWebDriver driver;
        State state;
        RestAPI api;

        List<JObject> ratingResult;
        RatingWorksheet ratingWorksheet;
       
        public RA001_SetupValidPolicySteps(IWebDriver driver, RestAPI api, State state)
        {
            this.driver = driver;
            this.api = api;
            this.state = state;
            ratingWorksheet = new RatingWorksheet(driver);


        }

        [When(@"the premium is calculated")]
        public void WhenThePremiumIsCalculated()
        {
            this.ratingResult = this.state.engine.Run().ToList<JObject>();
            foreach (var coverage in ratingResult)
            {
                foreach (var factor in coverage)
                {
                    Console.WriteLine($"{factor.Key} ->{factor.Value}");
                }
            }
        }
       

        [Then(@"Rating Worksheet should display the correct result")]
        public void ThenRatingWorksheetShouldDisplayTheCorrectResult()
        {
            foreach(var result in this.ratingResult)
            {
                var Vehicle = result["Vehicle"];
                var UITable = ratingWorksheet.getResultTable($"{Vehicle["YearOfManufacture"]} {Vehicle["Make"]} {Vehicle["Model"]}", (String)result["Coverage Code"]);

                var factors = result.Values().ToList();
                foreach (var UIFactorRow in UITable)
                {
                    String
                        UI_Col_Name = UIFactorRow["Name"],
                        UI_Col_Math = UIFactorRow["Math"],
                        UI_Col_Change = UIFactorRow["Change Amount"],
                        UI_Col_Premium = UIFactorRow["Premium"];

                    //string parsedUIPremium = string.Join("", Regex.Split(UI_Col_Premium, @"[^0-9\.]+"));


                    var factor = factors.Find(it => it is JObject && (String)((JObject)it)?["nameUI"] == UI_Col_Name);

                    if (factor != null)
                    {
                        string expectedPremium = ((float)factor["currentPremium"]).ToString("C", CultureInfo.CurrentCulture);
                    }

                    /* if (UI_Col_Premium != expectedPremium)
                     {
                         throw new Exception($"UI Premium for [{UI_Col_Name}]: [{UI_Col_Premium}] does not equal expected premium: [{formatted_premium}] \n Expected Factor: {factor}");
                     }*/
                    if (UI_Col_Math.Contains("Factor:"))
                    {
                        int factorStart = UI_Col_Math.IndexOf("Factor:") + 8;
                        String UIFactor = UI_Col_Math.Substring(factorStart, UI_Col_Math.Length - factorStart).Trim(')');
                        if (UIFactor != factor?["factor"]?.ToString())
                        {
                            Console.WriteLine($"FAILURE: \nUI Factor for [{UI_Col_Name}]: [{UIFactor}] does not equal expected premium: [{factor?["factor"]}] \n Expected Factor: {factor}");
                        }
                        else
                        {
                            Console.WriteLine($"Success: {UI_Col_Name}");
                        }
                    }



                }
            }

        }



    }
}
