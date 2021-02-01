using System;
using TechTalk.SpecFlow;
using ApolloQA.Pages.Quote;
using ApolloQA.Source.Helpers;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Globalization;
using ApolloQA.Source.Driver;

namespace ApolloQA.StepDefinition.Quote
{
    [Binding]
    public class Quote_PremiumCalculationSteps
    {
        public static readonly List<string> 
            ratingFactorsWhitelist = new List<string>() { 
                                                          "Fleet Driver Rating Plan",
                                                          "Increased Limit Factor",
                                                          "Schedule Rating",
                                                          "Experience Rating"
                                                        };
        public static List<JObject> ratingResult;
        public static SharedSteps STEPS= new SharedSteps();

        [Given(@"user is in the Rating Worksheet Page")]
        public void GivenUserIsInTheRatingWorksheetPage()
        {
            if(Functions.GetCurrentURL().Contains("ratings-worksheet"))
            {
                return;
            }
            else if (Functions.GetCurrentURL().Contains("section"))
            {
                var urlPath = Functions.GetCurrentURLPath();

                var sectionID = int.Parse(urlPath.Substring(urlPath.IndexOf("section/") + 8, 4));

                if(new Data.Entity.Storyboard.Section(sectionID).Name!="Summary")
                {
                    STEPS.WhenUserClicksSidetab("Summary");
                    STEPS.WhenUserWaitsForSpinnerToDissappearForSeconds(120);

                }


                STEPS.WhenUserClicksButton("View Rating Worksheet");
            }
            else
            {

                new BiberkLoginSteps().GivenUserIsSuccessfullyLoggedIntoBiberk();
                new Quote_GeneralSteps().GivenUserNavigatesToQuote("latest");
                STEPS.WhenUserClicksSidetab("Summary");
                STEPS.WhenUserWaitsForSpinnerToDissappearForSeconds(120);
                STEPS.WhenUserClicksButton("View Rating Worksheet");

            }
        }



        [Then(@"the premium should be calculated")]
        public void ThenThePremiumShouldBeCalculated()
        {
            string premium = Quote_Summary.TotalPremiumInput.getTextFieldText();
            
            if(!int.TryParse(string.Join("", premium.Where(Char.IsDigit)), out int result) || result<1)
            {
                Functions.handleFailure($"Premium was not calculated - Result: {premium}"); 
            }
            Log.Info($"Success - Resulting Premium: {premium}");

        }

        [Then(@"Rating Worksheet should display the correct result")]
        public void ThenRatingWorksheetShouldDisplayTheCorrectResult()
        {

            string currentURL = Functions.GetCurrentURLPath();
         
            string startingWithID = currentURL.Substring(currentURL.IndexOf("quote/") + 6);
            string IDstr = startingWithID.Substring(0, startingWithID.IndexOf("/"));

            var quote = new Data.Entity.Quote(int.Parse(IDstr));

            var engine = new Data.Engine(quote);

            ratingResult = engine.Run().ToList<JObject>();
            TestRatingWorksheet();
        }

        private void TestRatingWorksheet()
        {
            List<String> failures = new List<string>();
            foreach (var result in ratingResult)
            {
                Log.Debug(result);
                var Vehicle = result["Vehicle"];
                var Year = Vehicle["YearOfManufacture"];
                var Make = Vehicle["Make"];
                var Model = Vehicle["Model"]?.ToString();
                Element table = new RatingWorksheet.Risk($"{Year} {Make}{ (String.IsNullOrEmpty(Model) ?"": $" {Model}") }", (String)result["CoverageCode"]).DataTable;
                var UITable = table.parseUITable();

                
                var factors = result.Values().ToList();

/*                if (UITable.Count() <=1)
                {
                    throw Functions.handleFailure($"Empty table - {table.ToString()} ");
                }*/
                foreach (var UIFactorRow in UITable)
                {

                    String
                        UI_Col_Name = UIFactorRow["Name"],
                        UI_Col_Math = UIFactorRow["Math"],
                        UI_Col_Change = UIFactorRow["Change Amount"],
                        UI_Col_Premium = UIFactorRow["Premium"];

                    if(UI_Col_Name.Contains("Base Rate Factor"))
                    {
                        UI_Col_Name = "Base Rate Factor";
                    }

                    var factor = factors.Find(it => it is JObject && it?["nameUI"] != null && ((JArray)it?["nameUI"]).ToObject<List<String>>().Contains(UI_Col_Name));

                    if (factor != null)
                    {
                        string expectedPremium = ((decimal)factor["currentPremium"]).ToString("C", CultureInfo.CurrentCulture);
                    }

                    /* if (UI_Col_Premium != expectedPremium)
                     {
                         throw new Exception($"UI Premium for [{UI_Col_Name}]: [{UI_Col_Premium}] does not equal expected premium: [{formatted_premium}] \n Expected Factor: {factor}");
                     }*/

                    

                    if (!ratingFactorsWhitelist.Contains(UI_Col_Name) && UI_Col_Math.Contains("Factor:"))
                    {
                        int factorStart = UI_Col_Math.IndexOf("Factor:") + 8;
                        String UIFactor = UI_Col_Math.Substring(factorStart, UI_Col_Math.Length - factorStart).Trim(')');
                        String expectedFactor = factor?["factor"]?.ToString().TrimEnd('0').TrimEnd('.');
                        if (UIFactor != expectedFactor)
                        {
                            String error = $"FAILURE: \nUI Factor for [{UI_Col_Name}]: [{UIFactor}] does not equal expected premium: [{expectedFactor}] \n Expected Factor: {factor}\n\n";
                            Log.Info($"Failure: {UI_Col_Name}\n");

                            failures.Add(error);
                        }
                        else
                        {
                            Log.Info($"Success: {UI_Col_Name}\n");
                        }
                    }
                    else
                    {
                        Log.Debug($"Skipped: Name: {UI_Col_Name}  Math: {UI_Col_Math} \n");
                    }



                }

            }
            if(failures.Any())
            {
                Functions.handleFailure(new Exception(string.Join("\n\n", failures)));
            }
        }
    }
}
