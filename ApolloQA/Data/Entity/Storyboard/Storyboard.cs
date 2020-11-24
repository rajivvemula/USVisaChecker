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
            int[] qslcIds = ((JArray)this["questionSectionLineClassificationIds"]).ToObject<int[]>();

            var result = SQL.executeQuery(@"
            select QS.SectionName
            from [question].[QuestionSectionLineClassification] qslc
            LEFT JOIN question.QuestionSection QS ON QS.Id = qslc.QuestionSectionId
            WHERE qslc.Id IN ( @QSLC_Id ) 
            ORDER BY qslc.SortOrder
            ;", ("@QSLC_Id", qslcIds));

            return result.Select(it => (String)it["SectionName"]).ToList();
        }

        public List<Section> Sections
        {

            get
            {

                int[] qslcIds = ((JArray)this["questionSectionLineClassificationIds"]).ToObject<int[]>();

                var result = SQL.executeQuery(@"
                select QS.Id
                from [question].[QuestionSectionLineClassification] qslc
                LEFT JOIN question.QuestionSection QS ON QS.Id = qslc.QuestionSectionId
                WHERE qslc.Id IN ( @QSLC_Id ) 
                ORDER BY qslc.SortOrder
                ;", ("@QSLC_Id", qslcIds));

                return result.Select(it => new Section((int)it["Id"])).ToList();
            }
        }

    }
}
