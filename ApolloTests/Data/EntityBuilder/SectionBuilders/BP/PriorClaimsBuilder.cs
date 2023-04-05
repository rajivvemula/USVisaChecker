using ApolloTests.Data.Entity;
using ApolloTests.Data.EntityBuilder.Entities;
using ApolloTests.Data.EntityBuilder.Models;
using DocumentFormat.OpenXml.Wordprocessing;
using HitachiQA.Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApolloTests.Data.EntityBuilder.SectionBuilders.BP
{
    public class PriorClaimsBuilder : List<PriorClaim>, IBuilder
    {
        public Section Section => Section.PriorClaims;

        public QuoteBuilder Builder { get; }

        public HydratorUtil Hydrator => Builder.Hydrator;

        public PriorClaimsBuilder(QuoteBuilder builder)
        {
            Builder = builder;
            this.AddOne();
        }
        public JToken RunSendStrategy(Entity.Quote quote)
        {
            Hydrator.CurrentSection = Section;
            var result = new JArray();
            foreach (var priorClaim in this)
            {
                Hydrator.CurrentAnswers = priorClaim.QuestionAnswers;
                Hydrator.CurrentEntity = priorClaim;
                Hydrator.Hydrate(priorClaim);
                bool response = Builder.RestAPI.POST($"/quote/{quote.Id}/priorClaim", new JArray { priorClaim.ToJToken() });
                result.Add(response);
            }
            return result;


        }
        public void AddOne() => this.Add(new PriorClaim());
    }
}
