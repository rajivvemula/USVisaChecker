using System;
using System.Collections.Generic;
using System.Text;
using ApolloTests.Data.Entities;
using HitachiQA.Helpers;
namespace ApolloTests.Data.Entity.Question
{
    public class Section:BaseEntity
    {
        public long Id;

        public Section(int Id)
        {
            this.Id = Id;
        }
        public Section(long Id)
        {
            this.Id = Id;
        }

        public dynamic this[String propertyName]
        {
            get
            {
                var method = this.GetType().GetProperty(propertyName);
                if (method != null)
                {
                    return method.GetGetMethod()?.Invoke(this, null) ?? throw new NullReferenceException();

                }
                else
                {
                    return GetProperty(propertyName);
                }
            }
        }
        public dynamic GetProperties()
        {
            return SQL.executeQuery("select * from question.QuestionSection where Id = @Id", ("@Id", this.Id))[0];
        }
        public dynamic GetProperty(String propertyName)
        {
            var property = this.GetProperties()[propertyName];
            return property == null ? "" : property;
        }

        public string Name
        {
            get
            {
                return this["SectionName"];
            }
        }

    }
}
