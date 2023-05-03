using ApolloTests.Data.EntityBuilder.Entities;
using ApolloTests.Data.EntityBuilder.Models;
using ApolloTests.Data.Entities.Risk;
using HitachiQA.Helpers;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace ApolloTests.Data.EntityBuilder.SectionBuilders.CA
{
    public class VehiclesBuilder : List<VehicleRisk>, IRiskBuilder
    {
  
        public QuoteBuilder Builder { get; }
        public Section Section => Section.Vehicles;
        public HydratorUtil Hydrator => Builder.Hydrator;
        public uint NumberOfRisks
        {
            get => (uint)Count;
            set => this.SetNumberOfRisks(value);
        }
        public VehiclesBuilder(QuoteBuilder Builder)
        {
            this.Builder = Builder;
            this.AddOne();
        }
        public JToken RunSendStrategy(Data.Entities.Quote quote)   
        {
            Hydrator.Interpreter.SetVariable("ClassCode", this.Builder.ClassCodeKeyword.ClassCode);

            Builder.Hydrator.CurrentSection = this.Section;

            JArray result = new JArray();
            foreach(var risk in this)
            {
                Hydrator.Interpreter.SetVariable("VinNumber", Functions.GetRandomVIN(this.Builder.RestAPI));
                Builder.Hydrator.CurrentEntity = risk.Vehicle;
                Builder.Hydrator.CurrentAnswers = risk.QuestionAnswers;
    
                Hydrator.Hydrate(risk);
                var body = new JArray(risk.ToJObject());

                JArray? riskResponse = this.Builder.RestAPI.POST($"quote/{quote.Id}/risk", body)??throw new NullReferenceException();
                result.Add(riskResponse.ElementAt(0));

                risk.LoadEntityObject((JObject)riskResponse.ElementAt(0)["risk"]);
                var vehicleRisksAcross = Builder.PolicyCoverages.Where(it => it.CoverageType.isVehicleLevel);
                risk.RiskLimits.AddRange(vehicleRisksAcross);
                var limitsBody = risk.RiskLimits.ToJArray();

                JToken riskLimitRes = this.Builder.RestAPI.POST($"quote/{quote.Id}/risk/{risk.Vehicle.RiskId}/limits", limitsBody) ?? throw new NullReferenceException();
                result.Add(riskLimitRes);
            }

            return result;
        }

        public void AddOne() => Add(new VehicleRisk(Builder));
    }
}
