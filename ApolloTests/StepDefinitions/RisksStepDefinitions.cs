using ApolloTests.Data.Entities;
using ApolloTests.Data.Entities.Context;
using ApolloTests.Data.Entities.Risk;
using ApolloTests.Data.EntityBuilder;
using ApolloTests.Data.EntityBuilder.SectionBuilders;
using HitachiQA.Helpers;
using HitachiQA.Source.Helpers;
using System;
using TechTalk.SpecFlow;

namespace ApolloTests.StepDefinitions
{
    [Binding]
    public class RisksStepDefinitions
    {
        private CosmosContext CosmosContext;
        private SQLContext SQLContext;
        private RestAPI RestAPI;
        private SharedData Shared;
        private IObjectContainer ObjectContainer;

        public RisksStepDefinitions(IObjectContainer container)
        {
            ObjectContainer = container;
            CosmosContext = container.Resolve<CosmosContext>();
            SQLContext = container.Resolve<SQLContext>();
            RestAPI = container.Resolve<RestAPI>();
            Shared = container.Resolve<SharedData>();


        }
        [Given(@"new quote is created for '([^']*)'")]
        public void GivenNewQuoteIsCreatedFor(string subLineCode)
        {
            var subLine = SQLContext.SubLine.First(it=> it.Code == subLineCode.ToUpper());
            var quoteBuilder = new QuoteBuilder(ObjectContainer, subLine.ParentLine.LineEnum, "IL");
            quoteBuilder.Quote.SubLineId = subLine.Id;
            var createdQuote = quoteBuilder.CreateQuote();
            Shared.SetValue("Quote", "Builder", quoteBuilder);
            Shared.SetValue("Quote", "Quote", createdQuote);
            

        }


        [Given(@"user adds '([^']*)' '([^']*)' risks to the quote")]
        public void GivenUserAddsARiskToTheQuote(uint numberOfRisks, string riskType)
        {
            var builder = Shared.GetValue<QuoteBuilder>("Quote", "Builder");

            switch (riskType.ToLower())
            {
                case "location":
                    builder.Locations.NumberOfLocations= numberOfRisks;
                    (builder.Locations as IBuilder).RunSendStrategy();
                    break;
                case "building":
                    builder.Locations.NumberOfLocations = numberOfRisks;
                    (builder.Locations as IBuilder).RunSendStrategy();
                    break;
                default: throw new NotImplementedException($"GivenUserAddsARiskToTheQuote for RiskType: {riskType}");

            }
        }

        [When(@"user removes the previously added '([^']*)'")]
        public void WhenUserRemovesThePreviouslyAddedRisk(RiskTypeEnum riskType)
        {
            var quote = Shared.GetValue<Quote>("Quote", "Quote");
            var locations = quote.GetLocations();
            var buildings = quote.GetBuildings();
            Shared.SetValue("Quote", "locationCount", new RiskCount() { RiskType = riskType, OldCount = (uint)locations.Count });
            Shared.SetValue("Quote", "buildingCount", new RiskCount() { RiskType = riskType, OldCount = (uint)buildings.Count });

            List<RiskBase> risks = GetRisks(riskType);
            Log.Info($"/quote/{quote.Id}/risk/{risks.Last().Id}");
            RestAPI.SEND(HttpMethod.Delete, $"/quote/{quote.Id}/risk/{risks.Last().Id}", null);
        }

        [Then(@"assert business rule around deleting related risks if '([^']*)' '([^']*)' risk was deleted")]
        public void ThenAssertBusinessRuleAroundDeletingRelatedRisksIfRiskWasDeleted(uint deletedRiskCount, RiskTypeEnum riskType)
        {
            var locationCount = Shared.GetValue<RiskCount>("Quote", "locationCount");
            var buildingCount = Shared.GetValue<RiskCount>("Quote", "buildingCount");

            var quote = Shared.GetValue<Quote>("Quote", "Quote");
            locationCount.NewCount = (uint)quote.GetLocations().Count;
            buildingCount.NewCount = (uint)quote.GetBuildings().Count;
            

            switch(riskType)
            {
                case RiskTypeEnum.Location:
                    if (quote.SubLineId == (long)SubLineEnum.GeneralLiability){
                        locationCount.ExpectedCount = locationCount.OldCount - deletedRiskCount;
                        buildingCount.ExpectedCount = buildingCount.OldCount - deletedRiskCount;
                    } else {
                        locationCount.ExpectedCount = locationCount.OldCount - deletedRiskCount;
                        buildingCount.ExpectedCount = buildingCount.OldCount;
                    }
                    break;
                case RiskTypeEnum.Building:
                    if (quote.SubLineId == (long)SubLineEnum.GeneralLiability) {
                        locationCount.ExpectedCount = locationCount.OldCount - deletedRiskCount;
                        buildingCount.ExpectedCount = buildingCount.OldCount - deletedRiskCount;
                    } else {
                        locationCount.ExpectedCount = locationCount.OldCount;
                        buildingCount.ExpectedCount = buildingCount.OldCount - deletedRiskCount;
                    }
                    break;

                default: throw new NotImplementedException(riskType.ToString());
            }
            locationCount.AssertCount();
            buildingCount.AssertCount();


            //Log.Info(RestAPI.timeSpans);
            
        }

        private class RiskCount
        {
            public RiskTypeEnum RiskType { get; set; }
            public uint NewCount { get; set; }
            public uint OldCount { get; set; }
            public uint ExpectedCount { get; set; }

            public void AssertCount() => NewCount.Should().Be(ExpectedCount, $"RiskType: {RiskType} original count: {OldCount}");

        }

        private List<RiskBase> GetRisks(RiskTypeEnum riskType)
        {
            var quote = Shared.GetValue<Quote>("Quote", "Quote");
            var locations = quote.GetLocations();
            var buildings = quote.GetBuildings();


            List<RiskBase> risks;
            switch (riskType)
            {
                case RiskTypeEnum.Location:
                    risks = locations.Select(it => (RiskBase)it).ToList();
                    break;
                case RiskTypeEnum.Building:
                    risks = buildings.Select(it => (RiskBase)it).ToList();
                    break;
                default: throw new NotImplementedException(riskType.ToString());
            }
            return risks;
        }

    }
}
