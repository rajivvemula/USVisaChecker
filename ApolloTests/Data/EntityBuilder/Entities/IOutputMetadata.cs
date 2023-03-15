using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApolloTests.Data.EntityBuilder.Entities
{
    public interface IOutputMetadata : IEntityBase
    {
        public abstract List<QuestionResponse> QuestionResponses { get; set; }

        public object? GetQuestionResponse(string questionAlias)
        {

            var questionResponse = QuestionResponses?.FirstOrDefault(it => it.questionAlias == questionAlias);

            if (questionResponse == null)
            {
                Log.Debug($"{questionAlias}returned null");
                return null;
            }
            else
            {
                Log.Debug($"{questionAlias} returned {questionResponse.response ?? "response is null"}");
                return questionResponse.response;
            }
        }
    }
}
