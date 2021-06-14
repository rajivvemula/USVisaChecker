using System;
using System.Collections.Generic;
using System.Text;
using ApolloQA.Source.Helpers;
namespace ApolloQA.Data.Entity.Question
{
    public class Question
    {
        public long Id;

        public Question(int Id)
        {
            this.Id = Id;
        }
        public Question(long Id)
        {
            this.Id = Id;
        }
        public Question(string alias)
        {
            var id = SQL.executeQuery($"select Id from question.QuestionDefinition where Alias = 'WebForcedReferral' ;")[0]["Id"];
            this.Id = id;
        }
        public dynamic this[String propertyName]
        {
            get
            {
                var method = this.GetType().GetProperty(propertyName);
                if (method != null)
                {
                    return method.GetGetMethod().Invoke(this, null);

                }
                else
                {
                    return GetProperty(propertyName);
                }
            }
        }
        public dynamic GetProperties()
        {
            return SQL.executeQuery("select * from question.QuestionDefinition where Id = @Id", ("@Id", this.Id))[0];
        }
        public dynamic GetProperty(String propertyName)
        {
            var property = this.GetProperties()[propertyName];
            return property == null ? "" : property;
        }

        public string QuestionText
        {
            get
            {
                return this.GetProperty("QuestionText");
            }
        }
        public string Alias
        {
            get
            {
                return this.GetProperty("Alias");
            }
        }

    }
}
