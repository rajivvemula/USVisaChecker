using HitachiQA.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApolloTests.Data.EntityBuilder.QuestionAnswers
{
    public abstract class AnswersBase
    {
        /// <summary>
        /// Retrieves all quesiton answer properties in the current object (whatever object implements this class)
        /// </summary>
        private IEnumerable<PropertyInfo> QuestionAnswers => GetType().GetProperties().Where(prop => prop.PropertyType == typeof(QuestionAnswer));
        public QuestionAnswer GetAnswer(string alias)
        {
            foreach (var prop in this.QuestionAnswers)
            {
                var questionAnswer = (QuestionAnswer?)prop.GetGetMethod()?.Invoke(this, null);
                questionAnswer.NullGuard();
                if (questionAnswer._alias == alias)
                {
                    var att = prop.GetCustomAttribute<HydratorAttr>();
                    if (att != null)
                    {
                        questionAnswer.AsJsonStr = att.AsJsonStr;
                        questionAnswer.variableName= att.Name;
                        questionAnswer.targetType = att.TargetType;
                    }
                    return questionAnswer;
                }
            }
            Log.Info($"response for quesiton with alias {alias} not found Default=string.empty");

            return new QuestionAnswer(alias, "");

        }
        public void SetAnswer(string alias, object? value)
        {
            foreach (var prop in this.QuestionAnswers)
            {
                var propertyAlias = (QuestionAnswer?)prop.GetGetMethod()?.Invoke(this, null);
                propertyAlias.NullGuard();

                if (propertyAlias._alias == alias)
                {
                    propertyAlias._response = value;
                    return;
                }
            }
            throw new MissingMemberException(GetType().FullName + $" needs to implement a member for {alias}");
        }
    }
}
