using System;

namespace ApolloQA.Data.TestData.Params
{
    public class QuentionAnswerParamBase
    {
        public string GetAnswer(string alias)
        {
            foreach (var prop in GetType().GetProperties())
            {
                var propertyAlias = (QuestionAnswer)prop.GetGetMethod().Invoke(this, null);
                if (propertyAlias._alias == alias)
                {
                    return propertyAlias._response;
                }
            }

            return string.Empty;
        }
        public void SetAnswer(string alias, string value)
        {
            foreach (var prop in GetType().GetProperties())
            {
                var propertyAlias = (QuestionAnswer)prop.GetGetMethod().Invoke(this, null);
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