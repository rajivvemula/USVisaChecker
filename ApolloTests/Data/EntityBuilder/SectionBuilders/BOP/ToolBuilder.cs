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

namespace ApolloTests.Data.EntityBuilder.SectionBuilders.BOP
{
    public class ToolBuilder : List<Tool>, IBuilder
    {
        public Section Section => Section.Tools;

        public QuoteBuilder Builder { get; }

        public HydratorUtil Hydrator => Builder.Hydrator;

        public ToolBuilder(QuoteBuilder builder)
        {
            Builder = builder;
            this.AddOne();
        }
        public JToken RunSendStrategy(Entity.Quote quote)
        {
            Hydrator.CurrentSection = Section;
            var result = new JArray();
            foreach (var tool in this)
            {
                Hydrator.CurrentAnswers = tool.QuestionAnswers;
                Hydrator.CurrentEntity = tool;
                Hydrator.Hydrate(tool);
                bool response = Builder.RestAPI.POST($"/quote/{quote.Id}/tool", new JArray { tool.ToJToken() });
                result.Add(response);
            }
            return result;


        }
        public void AddOne() => this.Add(new Tool());
    }
}
