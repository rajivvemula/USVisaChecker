using ApolloTests.Data.EntityBuilder.Entities;
using ApolloTests.Data.EntityBuilder.Models;
using ApolloTests.Data.Entities.Risk;
using DocumentFormat.OpenXml.Wordprocessing;
using HitachiQA.Helpers;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace ApolloTests.Data.EntityBuilder.SectionBuilders.CA
{
    public class LocationsBuilder : Dictionary<LocationRisk, List<BuildingRisk>>, IRiskBuilder
    {
  
        public QuoteBuilder Builder { get; }
        public Section Section => Section.Locations;
        public HydratorUtil Hydrator => Builder.Hydrator;
        public uint NumberOfRisks
        {
            get => throw new InvalidOperationException("Please use NumberOfLocations or NumberOfBuildings");
            set => throw new InvalidOperationException("Please use NumberOfLocations or NumberOfBuildings");
        }
        public uint NumberOfLocations
        {
            get => (uint)this.Count;
            set
            {
                if (NumberOfLocations > value)
                {
                    while (NumberOfLocations != value)
                    {
                        this.Remove(this.Last().Key);
                    }
                }
                else
                {

                    while (NumberOfLocations != value)
                    {
                        this.AddOneLocation();
                    }
                }
            }
        }
        public uint NumberOfBuildings
        {
            get => (uint)this.Values.Select(building => building).Count();
            set
            {
                if (NumberOfBuildings > value)
                {
                    while (NumberOfBuildings != value)
                    {
                        this.Last().Value.Remove(this.Last().Value.Last());
                    }
                }
                else
                {
                    while (this.Values.Select(it=>it.Count).Sum()!= value)
                    {
                        this.AddOneBuilding();
                    }
                }
            }
        }

        public LocationsBuilder(QuoteBuilder Builder)
        {
            this.Builder = Builder;
            this.AddOne();
        }
        public JToken RunSendStrategy(Data.Entities.Quote quote)
        {
            Hydrator.Interpreter.SetVariable("ClassCode", this.Builder.ClassCodeKeyword.ClassCode);

            Builder.Hydrator.CurrentSection = this.Section;

            JArray result = new();
            foreach(var location in this)
            {
                var locationRisk = location.Key;
                Hydrator.Interpreter.SetVariable("LocationRisk", locationRisk);

                Builder.Hydrator.CurrentEntity = locationRisk.Location;
                Builder.Hydrator.CurrentAnswers = locationRisk.QuestionAnswers;
                Hydrator.Hydrate(locationRisk);
               
                var locationBody = new JArray(locationRisk.ToJObject());
                JArray? locationRes = this.Builder.RestAPI.POST($"quote/{quote.Id}/risk", locationBody) ?? throw new NullReferenceException();
                result.Add(locationRes.ElementAt(0));
                Hydrator.Interpreter.SetVariable("LocationRiskResponse", locationRes.ElementAt(0));
                locationRisk.LoadEntityObject((JObject)locationRes.ElementAt(0));


                if (quote.SubLineId != (long)SubLineEnum.GeneralLiability)
                {
                    foreach (var buildingRisk in location.Value)
                    {
                        Hydrator.Interpreter.SetVariable("BuildingRisk", buildingRisk);

                        Builder.Hydrator.CurrentEntity = buildingRisk.Building;
                        Builder.Hydrator.CurrentAnswers = buildingRisk.QuestionAnswers;
                        Hydrator.Hydrate(buildingRisk);
                        var buildingBody = new JArray(buildingRisk.ToJObject());
                        JArray? buildingRes = this.Builder.RestAPI.POST($"quote/{quote.Id}/risk", buildingBody) ?? throw new NullReferenceException();
                        result.Add(buildingRes.ElementAt(0));
                        buildingRisk.LoadEntityObject((JObject)buildingRes.ElementAt(0));

                    }
                }

            }

            return result;
        }

        public void AddOneLocation() => this.Add(new LocationRisk(true), new List<BuildingRisk>());
        public void AddOneBuilding()
        {
            if (this.NumberOfLocations == 0)
                this.Add(new LocationRisk(true), new List<BuildingRisk> { new BuildingRisk(true) });
            else
                this.Last().Value.Add(new BuildingRisk(true));
        }

        public void AddOne() => AddOneBuilding();

        public void RemoveAt(int index) => this.Last().Value.RemoveAt(index);
    }
}
