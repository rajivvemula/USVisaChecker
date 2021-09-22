using System;
using TechTalk.SpecFlow;
using ApolloQA.Source.Helpers;
using ApolloQA.Data.Rating;
using EntityQuote = ApolloQA.Data.Entity.Quote;
using ApolloQA.Data.Entity;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace ApolloQA.StepDefinition.Rating
{
    [Binding]
    public class AlgorithmsSteps
    {
        public EntityQuote quote;
        private JArray Actual;
        private List<JObject> Expected;

        [Given(@"quote for '(.*)' and '(.*)' is set to Quoted")]
        public void GivenQuoteForIsSetToQuoted(string state, string algorithmCode)
        {

            var classCodeKeyword = ClassCodeKeyword.GetUsingAlgorithmCode(algorithmCode, state);

            quote = Functions.GetQuotedQuoteThroughAPI(classCodeKeyword, state);


        }


        [Given(@"quote for Keyword '(.*)' in (.*) is set to Quoted")]
        public void GivenQuoteForKeywordInIsSetToQuoted(string Keyword, string state)
        {
            var classCodeKeyword = ClassCodeKeyword.GetUsingKeywordName(Keyword);

            Functions.GetQuotedQuoteThroughAPI(classCodeKeyword, state);


        }

        [Given(@"quote with Id (.*) is loaded")]
        public void GivenQuoteWithIdIsLoaded(int QuoteId)
        {
            quote = new EntityQuote(QuoteId);



        }


        [When(@"expected values are gathered")]
        public void WhenExpectedValuesAreGathered()
        {
            Expected = new Engine(quote).Run();
            Log.Debug($"{JArray.FromObject(Expected)}");
        }

        List<string> errors = new List<string>();
        [Then(@"expected values should match the system output")]
        public void ThenExpectedValuesShouldMatchTheSystemOutput()
        {
            this.Actual = quote.GetCurrentRatableObject().RatingGroup;


            foreach(JObject expectedResult in this.Expected)
            {
                var vehicle = new Vehicle(expectedResult["Vehicle"]["Id"].ToObject<int>());

                var actualResult = (JObject)Actual[0]["results"].FirstOrDefault(it => it["entityKey"].ToString() == $"VehicleEntity|{vehicle.Id}" && 
                                                                                     it["coverageName"].ToString().ToLower().Contains(expectedResult["CoverageCode"].ToString().ToLower())
                                                                              );

                if(actualResult == null)
                {
                    //throw new Exception($"Expected Results for Vehicle id: {vehicle.Id} | {vehicle} & Coverage Code: { expectedResult["CoverageCode"]} were not found the worksheet");
                    errors.Add($"Expected Results for Vehicle id: {vehicle.Id} | {vehicle} & Coverage Code: { expectedResult["CoverageCode"]} were not found the worksheet");
                    continue;
                }
                if (actualResult["premium"].ToObject<decimal>() != expectedResult["TotalPremium"].ToObject<decimal>())
                {
                    errors.Add($"Expected Premium: { expectedResult["TotalPremium"]} does not equal actual Premium: {actualResult["premium"]} for Vehicle: {vehicle.ToString()} & Coverage Code: { expectedResult["CoverageCode"]}");
                }

                var expectedFactors = (JObject)expectedResult["Factors"];
                var actualFactors = (JArray)actualResult["ruleResults"];
                foreach(var item in expectedFactors)
                {
                    var expectedFactor = item.Value;
                    var nameUI = ((JArray)expectedFactor["NameUI"]).ToObject<List<string>>();

                    if(expectedFactor?["displayOnly"] is var displayOnly && displayOnly!= null && displayOnly.ToObject<bool>())
                    {
                        continue;
                    }

                    if(!nameUI.Any())
                    {
                        continue;
                    }
                    var actualFactor = actualFactors.FirstOrDefault(actual => nameUI.Contains(actual["rule"]["Label"].ToString()));

                    if(actualFactor == null)
                    {
                        errors.Add($"Expected Factor with Names: [{string.Join(", ", nameUI)}] was not found in the rating worksheet labels for {vehicle} & {expectedResult["CoverageCode"]}");
                        continue;
                    }


                    string mathOperation = actualFactor["mathOperation"].ToString();

                    if (nameUI.Contains("Policy Term Factor"))
                    {
                        if (!mathOperation.Contains(expectedFactor["parsedValue"].ToString()))
                        {
                            errors.Add($"Expected Factor Value for {item.Key} value: {expectedFactor["parsedValue"]} did not match value in {mathOperation}");
                        }


                        continue;
                    }

                    decimal factorValue;

                    if(string.IsNullOrWhiteSpace(mathOperation))
                    {
                        if(expectedFactor["Value"].ToObject<decimal>() == 1)
                        {
                            continue;
                        }

                        errors.Add($"Expected Factor Value for factor {item.Key} value: {expectedFactor["Value"]} did not equal (blank)");
                        continue;
                    }

                    try
                    {
                        if (mathOperation.Contains("StatedValue"))
                        {                            
                            factorValue = decimal.Parse(mathOperation.Substring(mathOperation.IndexOf(":")+1).Trim().Trim(')'));
                        }
                        else
                        {
                            string factorString = mathOperation.Substring(mathOperation.IndexOf("Factor:") + 8);
                            factorString = factorString.Substring(0, factorString.IndexOf(')'));

                            factorValue = decimal.Parse(factorString);
                        }
                    }
                    catch
                    {
                        errors.Add($"Error parsing Factor Math Operation Name: {item.Key} mathOperation: {mathOperation}");
                        continue;
                    }

                    
                    if (factorValue != expectedFactor["Value"].ToObject<decimal>())
                    {
                        errors.Add($"Expected Factor Value for factor {item.Key} value: {expectedFactor["Value"]} did not equal {factorValue}");
                    }
                   
                }


            }
            Log.Debug(errors);

            if(errors.Find(it=> it.Contains("Expected Premium") || it.Contains("Expected Results")) is var error && error!= null)
            {
                Functions.handleFailure(error);
            }
/*            foreach (var item in Expected)
            {
                Log.Debug(item);
            }*/
        }


        [Then(@"USDOT with criteria is found")]
        public void ThenUSDOTWithCriteriaIsFound()
        {
            string state = "IL";
            //string keyword = "C";
            for (char letter = 'A'; letter <= 'Z'; letter++)
            {
                string keyword = letter.ToString();
                string keywordMatches = (string)RestAPI.GET($"http://safer.fmcsa.dot.gov/keywordx.asp?searchstring=%2A{keyword}%2A&SEARCHTYPE=", null);

                keywordMatches = keywordMatches.Substring(keywordMatches.IndexOf("<!--<table>-->"));

                string[] keywordMatchesRows = keywordMatches.Split("<!--<table>-->");

                Dictionary<string, string> businessPages = new Dictionary<string, string>();
                foreach (var tr in keywordMatchesRows)
                {
                    if (tr.Contains($", {state}"))
                    {
                        var href = tr.Substring(tr.IndexOf("href=") + 6);
                        href = href.Substring(0, href.IndexOf("\">"));

                        var businessName = tr.Substring(tr.IndexOf(href) + href.Length + 2);

                        businessName = businessName.Substring(0, businessName.IndexOf("</a>"));

                        businessPages.Add(businessName, href);
                    }
                }

                foreach (var business in businessPages)
                {
                    string businessPage = (string)RestAPI.GET($"http://safer.fmcsa.dot.gov/{business.Value}", null);

                    string usDot = businessPage.Substring(businessPage.IndexOf("USDOT Number: ") + 14);
                    usDot = usDot.Substring(0, usDot.IndexOf("<br>"));
                    Log.Debug($"USDOT [{usDot}]");

                    var CabResponse = Functions.GetCAB(int.Parse(usDot));


                    //conditions
                    if (((JArray)CabResponse.contact.addresses).Select(it => it["st"]?.ToString() == state).Count() > 0)
                    {
                        Log.Debug("matching state");
                    }
                    if (CabResponse.events?.inspections?.OOS?.tot > 2)
                    {
                        Log.Debug("matching inspections");
                        letter = 'Z';
                        break;
                    }
                    Log.Debug("\n\n");

                }
            }

        }

    }
}
