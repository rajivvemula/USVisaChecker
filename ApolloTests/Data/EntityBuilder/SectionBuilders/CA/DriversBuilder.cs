using ApolloTests.Data.EntityBuilder.Models;
using HitachiQA.Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApolloTests.Data.EntityBuilder.SectionBuilders.CA
{
    public class DriversBuilder : List<Risk>, IRiskBuilder
    {
        public List<Risk> Self => this;
        public Section Section => Section.Drivers;

        public QuoteBuilder Builder { get; }
        public HydratorUtil Hydrator => Builder.Hydrator;

        public DriversBuilder(QuoteBuilder quoteBuilder)
        {
            Builder = quoteBuilder;
            Add(new Risk(RiskType.Driver));
        }

        public JToken RunSendStrategy(Entity.Quote quote)
        {
            JArray result = new JArray();
            Hydrator.CurrentSection = Section;

            foreach (var risk in this)
            {
                Hydrator.Interpreter.SetVariable("LicenseNumber", Functions.GetValidDriverLicense(Builder.State));
                Builder.Hydrator.CurrentEntity = risk.Driver;
                Builder.Hydrator.CurrentAnswers = risk.QuestionAnswers;

                Hydrator.Hydrate(risk);
                var body = new JArray(risk.ToJObject());

                JArray response = Builder.RestAPI.POST($"quote/{quote.Id}/risk", body) ?? throw new NullReferenceException();
                result.Add(response.ElementAt(0));
                risk.LoadEntityObject((JObject)response.ElementAt(0));

            }

            return result;
        }

    }
}
