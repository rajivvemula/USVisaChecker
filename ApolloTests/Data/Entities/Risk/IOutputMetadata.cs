using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApolloTests.Data.EntityBuilder.Entities;

namespace ApolloTests.Data.Entities.Risk
{
    public interface IOutputMetadata
    {
        public abstract List<QuestionResponse> QuestionResponses { get; set; }

        public string GetQuestionResponse(string questionAlias)
        {

            var questionResponse = QuestionResponses?.FirstOrDefault(it => it.QuestionAlias == questionAlias);

            if (questionResponse == null)
            {
                Log.Debug($"{questionAlias}returned null");
                return null;
            }
            else
            {
                Log.Debug($"{questionAlias} returned {questionResponse.Response ?? "response is null"}");
                return questionResponse.Response;
            }
        }
    }
}
