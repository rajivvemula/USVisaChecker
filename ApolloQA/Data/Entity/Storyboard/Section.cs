using System;
using System.Collections.Generic;
using System.Text;
using ApolloQA.Source.Helpers;
namespace ApolloQA.Data.Entity.Storyboard
{
    public class Section
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
