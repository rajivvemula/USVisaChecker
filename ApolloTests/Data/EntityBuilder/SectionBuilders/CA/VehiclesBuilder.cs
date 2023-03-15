using ApolloTests.Data.EntityBuilder.Entities;
using ApolloTests.Data.EntityBuilder.Models;
using HitachiQA.Helpers;
using Newtonsoft.Json.Linq;


namespace ApolloTests.Data.EntityBuilder.SectionBuilders.CA
{
    public class VehiclesBuilder : List<Risk>, IRiskBuilder
    {
        public VehiclesBuilder(QuoteBuilder Builder)
        {
            this.Builder = Builder;
            this.Add(new Risk(RiskType.Vehicle));
        }
        public QuoteBuilder Builder { get; }
        public List<Risk> Self => this;
        public Section Section => Section.Vehicles;
        public HydratorUtil Hydrator => Builder.Hydrator;

        public JToken RunSendStrategy(Entity.Quote quote)   
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

                risk.LoadEntityObject((JObject)riskResponse.ElementAt(0));
                var limitsBody = risk.RiskLimits.ToJArray();

                JToken riskLimitRes = this.Builder.RestAPI.POST($"quote/{quote.Id}/risk/{risk.Vehicle.riskId}/limits", limitsBody) ?? throw new NullReferenceException();
                result.Add(riskLimitRes);
            }

            return result;
        }

        
    }
}
