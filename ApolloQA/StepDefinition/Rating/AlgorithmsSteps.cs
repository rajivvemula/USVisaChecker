using System;
using TechTalk.SpecFlow;
using ApolloQA.Source.Helpers;
using ApolloQA.Data.Rating;
using System.Collections.Generic;

namespace ApolloQA.StepDefinition.Rating
{
    [Binding]
    public class AlgorithmsSteps
    {
        [Given(@"quote for '(.*)' and '(.*)' is set to Quoted")]
        public void GivenQuoteForIsSetToQuoted(string state, string algorithmCode)
        {
            var classCodeKeyword = ClassCodeKeyword.GetUsingAlgorithmCode(algorithmCode, state);

            Functions.GetQuotedQuoteThroughAPI(classCodeKeyword);

            double totalTime = 0;
            foreach(var timespan in RestAPI.timeSpans)
            {
                Log.Debug($"[{timespan.seconds.ToString("0.0000")}] [{timespan.key}]");
                totalTime += timespan.seconds;
            }

            Log.Debug("Total Time spent on API " + totalTime.ToString("0.0000"));
        }


        [Given(@"quote for Keyword '(.*)' in (.*) is set to Quoted")]
        public void GivenQuoteForKeywordInIsSetToQuoted(string Keyword, string state)
        {
            var classCodeKeyword = ClassCodeKeyword.GetUsingKeywordName(Keyword);

            Functions.GetQuotedQuoteThroughAPI(classCodeKeyword);

            double totalTime = 0;
            foreach (var timespan in RestAPI.timeSpans)
            {
                Log.Debug($"[{timespan.seconds.ToString("0.0000")}] [{timespan.key}]");
                totalTime += timespan.seconds;
            }

            Log.Debug("Total Time spent on API " + totalTime.ToString("0.0000"));

        }


    }
}
