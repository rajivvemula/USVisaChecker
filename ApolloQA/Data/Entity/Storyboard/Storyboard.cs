using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApolloQA.Source.Helpers;
using Newtonsoft.Json.Linq;

namespace ApolloQA.Data.Entity.Storyboard
{
    public class Storyboard
    {
        public int Id;

        public Storyboard(int Id)
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
            return RestAPI.GET($"/storyboard/{Id}");
        }
        public dynamic GetProperty(String propertyName)
        {
            var property = this.GetProperties()[propertyName];
            return property == null ? "" : property;
        }

        public List<String> GetSortedSectionNames()
        {

            var result = SQL.executeQuery(@"
            SELECT 
            SectionName
            FROM [question].[StoryboardSection]  SS
            LEFT JOIN Question.QuestionSection QS on QS.Id = SS.SectionId
            where SS.StoryboardId = @StoryboardId 
            Order By SS.SortOrder
            ;", ("@StoryboardId", this.Id));

            return result.Select(it => (String)it["SectionName"]).ToList();
        }

        public List<Section> Sections
        {

            get
            {

                var result = SQL.executeQuery(@"
                SELECT 
                QS.Id
                FROM [question].[StoryboardSection]  SS
                LEFT JOIN Question.QuestionSection QS on QS.Id = SS.SectionId
                where SS.StoryboardId = @StoryboardId 
                Order By SS.SortOrder
                ;", ("@StoryboardId", this.Id));


                return result.Select(it => new Section((int)it["Id"])).ToList();
            }
        }

    }
}
