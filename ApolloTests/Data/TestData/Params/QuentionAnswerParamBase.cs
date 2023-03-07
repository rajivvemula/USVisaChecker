using HitachiQA.Helpers;
using System;

namespace ApolloTests.Data.TestData.Params
{
    public class QuentionAnswerParamBase
    {
        public QuestionAnswer GetAnswer(string alias)
        {
            foreach (var prop in GetType().GetProperties())
            {
                var questionAnswer = (QuestionAnswer?)prop.GetGetMethod()?.Invoke(this, null);
                questionAnswer.NullGuard();
                if (questionAnswer._alias == alias)
                {
                    return questionAnswer;
                }
            }

            return new QuestionAnswer(alias, string.Empty);
        }
        public void SetAnswer(string alias, string value)
        {
            foreach (var prop in GetType().GetProperties())
            {
                var propertyAlias = (QuestionAnswer?)prop.GetGetMethod()?.Invoke(this, null);
                propertyAlias.NullGuard();

                if (propertyAlias._alias == alias)
                {
                    propertyAlias._response = value;
                    return;
                }
            }
            throw new Exception($"Alias [{alias}] was not found");
        }
    }
}