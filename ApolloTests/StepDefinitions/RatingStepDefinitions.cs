using ApolloTests.Data.Entities.Coverage;
using ApolloTests.Data.Entities;
using System;
using TechTalk.SpecFlow;
using ApolloTests.Data.EntityBuilder;
using ApolloTests.Data.Entities.Context;
using HitachiQA.Helpers;
using HitachiQA.Source.Helpers;
using ApolloTests.Data.Entities.Reference;
using ApolloTests.Data.Rating;
using Newtonsoft.Json.Linq;
using ApolloTests.Data.Entities.Risk;
using Newtonsoft.Json;
using System.Web;

namespace ApolloTests.StepDefinitions
{
    [Binding]
    public class RatingStepDefinitions
    {
        private CosmosContext CosmosContext;
        private SQLContext SQLContext;
        private RestAPI RestAPI;
        private SharedData Shared;
        private IObjectContainer ObjectContainer;

        public RatingStepDefinitions(IObjectContainer container)
        {
            ObjectContainer = container;
            CosmosContext = container.Resolve<CosmosContext>();
            SQLContext = container.Resolve<SQLContext>();
            RestAPI = container.Resolve<RestAPI>();
            Shared = container.Resolve<SharedData>();
        }




        [Given(@"quote for LineId=(.*) state '([^']*)' and '([^']*)' is set to Quoted")]
        public void GivenQuoteForLineIdStateAndIsSetToQuoted(LineEnum line, string stateCode, string algorithmCode_CoverageName)
        {
            QuoteBuilder quoteBuilder;
            var coverage = CoverageType.GetCoverageType(SQLContext, algorithmCode_CoverageName);
            
            if (coverage!=null)
            {
                quoteBuilder = new QuoteBuilder(ObjectContainer, line, stateCode, new List<string>() { algorithmCode_CoverageName });
            }
            else
            {
                quoteBuilder = new QuoteBuilder(ObjectContainer, line, stateCode, algorithmCode_CoverageName);
            }
            quoteBuilder.Quote.RatableObjectEffectiveDate = DateTimeOffset.Parse("06/02/2023");
            quoteBuilder.Quote.RatableObjectExpirationDate = DateTimeOffset.Parse("06/02/2024");

            //md modifiers not implemented yet
            if(stateCode != "MD")
            {
                quoteBuilder.Modifiers_CA.experienceModifier.AdjustmentPercentage = 10m;
                quoteBuilder.Modifiers_CA.scheduleModifiers.EMPLOYEES.AdjustmentPercentage = 1m;
                quoteBuilder.Modifiers_CA.scheduleModifiers.CLASSIFICATION.AdjustmentPercentage = 1m;
                quoteBuilder.Modifiers_CA.scheduleModifiers.EQUIPMENT.AdjustmentPercentage = 1m;
                quoteBuilder.Modifiers_CA.scheduleModifiers.SAFETYORGANIZATION.AdjustmentPercentage = 1m;
                quoteBuilder.Modifiers_CA.scheduleModifiers.MANAGEMENT.AdjustmentPercentage = 1m;
            }
            

            var quote = quoteBuilder.Build();
            Shared.SetValue("Quote", "Quote", quote);

            foreach(var output in quote.Tether.CurrentPolicy.RatingGroup)
            {
                var targetFound = output["results"].Any(it => it.Value<string>("coverageName") == algorithmCode_CoverageName || it.Value<string>("coverageType") == algorithmCode_CoverageName);
                if(!targetFound)
                {
                    throw new Exception($"target Algorithm or Coverage was not found in the resulting output for \nQuote: {quote.Id} \nRating Package: {output["ratingPackageName"]}\n Algorithm or Coverage: {algorithmCode_CoverageName}");
                }
            }
        }

        [Given(@"quote with Id (.*) is loaded")]
        public void GivenQuoteWithIdIsLoaded(long QuoteId)
        {
            var quote = CosmosContext.Quotes.First(it=> it.Id == QuoteId);
            Log.Debug("Rating Group Id (rating worksheet): \n" + $"{Environment.GetEnvironmentVariable("HOST")}/rating/ratings-worksheet/" + quote.RatableObject.LatestRatingResponseGroupId);

            Shared.SetValue("Quote", "Quote", quote);

        }

        [When(@"expected values are gathered")]
        public void WhenExpectedValuesAreGathered()
        {
            var quote = Shared.GetValue<Quote>("Quote", "Quote");

            
            var expected = new Engine(quote).Run();
            Shared.SetValue("Quote", "ExpectedRatingOutput", expected);

           

        }

        [Then(@"expected values should match the system output")]
        public void ThenExpectedValuesShouldMatchTheSystemOutput()
        {
            var quote = Shared.GetValue<Quote>("Quote", "Quote");
            var expected = Shared.GetValue<RatingOutput> ("Quote", "ExpectedRatingOutput");

            JArray actual = quote.Tether.CurrentPolicy.RatingGroup;
            List<string> errors = new List<string>();

            foreach (var expectedResult in expected.Results)
            {
                JObject actualResult;
                if (expectedResult.Vehicle!=null)
                {
                    var vehicle = expectedResult.Vehicle;

                    actualResult = (JObject)actual[0]["results"].FirstOrDefault(it => it["entityKey"].ToString() == $"VehicleEntity|{vehicle.Id}" &&
                                                                                         it["coverageName"].ToString().StartsWith(expectedResult.CoverageCode) &&
                                                                                         it["coverageType"].ToString() == expectedResult.CoverageName
                                                                                 );

                    if (actualResult == null)
                    {
                        //throw new Exception($"Expected Results for Vehicle id: {vehicle.Id} | {vehicle} & Coverage Code: { expectedResult.CoverageCode} were not found the worksheet");
                        errors.Add($"Expected Results for Vehicle id: {vehicle.Id} | {vehicle} & Coverage Code: {expectedResult.CoverageCode} were not found the worksheet");
                        continue;
                    }
                }
                else
                {
                    actualResult = (JObject)actual[0]["results"].FirstOrDefault(it => it["moniker"].ToString() == expectedResult.CoverageName.ToString());
                }

                if (actualResult.Value<decimal>("premium") != expectedResult.TotalPremium)
                {
                    errors.Add($"Expected Premium: {expectedResult.TotalPremium} does not equal actual Premium: {actualResult["premium"]} for Vehicle: {actualResult["moniker"]} & Coverage Code: {expectedResult.CoverageCode}");
                }

                var expectedFactors = expectedResult.Factors;
                var actualFactors = (JArray)actualResult["ruleResults"];
                foreach (var expectedFactor in expectedFactors)
                {
                    var nameUI = expectedFactor.NameUI;

                    if (expectedFactor.displayOnly)
                    {
                        continue;
                    }

                    if (!nameUI.Any())
                    {
                        continue;
                    }
                    var actualFactor = actualFactors.FirstOrDefault(actual => nameUI.Contains(actual["rule"]["Label"].ToString()));

                    if (actualFactor == null)
                    {
                        errors.Add($"Expected Factor with Names: [{string.Join(", ", nameUI)}] was not found in the rating worksheet labels for {actualResult["moniker"]} & {expectedResult.CoverageCode}");
                        continue;
                    }

                    string mathOperation = actualFactor["mathOperation"].ToString();

                    if (nameUI.Contains("Policy Term Factor"))
                    {
                        if (!mathOperation.Contains(expectedFactor.parsedValue))
                        {
                            errors.Add($"Expected Factor Value for {expectedFactor.FullName} value: {expectedFactor.parsedValue} did not match value in {mathOperation}");
                        }

                        continue;
                    }

                    decimal factorValue;

                    if (string.IsNullOrWhiteSpace(mathOperation))
                    {
                        if (expectedFactor.Value == 1)
                        {
                            continue;
                        }
                        var msg = $"Expected Factor Value for factor {expectedFactor.FullName} value: {expectedFactor.Value} did not equal (blank)";
                        expectedFactor.Warning = msg;
                        errors.Add(msg);
                        continue;
                    }

                    try
                    {
                        if (mathOperation.Contains("StatedValue"))
                        {
                            factorValue = decimal.Parse(mathOperation.Substring(mathOperation.IndexOf(":") + 1).Trim().Trim(')'));
                        }
                        else if(mathOperation.Contains("Base Amount"))
                        {
                            string baseAmountString = mathOperation.Substring(mathOperation.IndexOf("Base Amount:") + "Base Amount:".Length).Trim(')');
                            factorValue = decimal.Parse(baseAmountString);

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
                        errors.Add($"Error parsing Factor Math Operation Name: {expectedFactor.FullName} mathOperation: {mathOperation}");
                        continue;
                    }

                    if (factorValue != expectedFactor.Value)
                    {
                        errors.Add($"Expected Factor Value for factor {expectedFactor.FullName} value: {expectedFactor.Value} did not equal {factorValue}");
                    }
                }


            }
            Log.Debug(errors);
            var exceptionErrors = errors.Where(it => it.Contains("Expected Premium") || it.Contains("Expected Results"));
            if (exceptionErrors.Any())
            {
                expected.Errors.AddRange(exceptionErrors);
                expected.generateReport();
                throw new Exception(string.Join("\n", exceptionErrors));
            }
            expected.generateReport();

        }




    }
}
