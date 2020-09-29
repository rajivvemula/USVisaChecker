using System;
using System.Collections.Generic;
using System.Text;
using ApolloQA.Driver;
using ApolloQA.Helpers;
using Newtonsoft.Json.Linq;

namespace ApolloQA.DataFiles.Entity
{
    class Organization
    {

        private readonly int Id;

        public Organization(int Id)
        {
            this.Id = Id;

        }

        public Organization(String filterName, String filterValue )
        {

            dynamic body = new JObject();
            body.filters = new JObject();
            body.filters[$"{filterName}"] = filterValue;
            body.loadChildren = true;

            dynamic response = Setup.api.POST($"/organization/search", body);
            if (response.info.totalRecords != 1)
            {
                throw new InvalidOperationException($"The provided filter {filterName}:{filterValue} retuned {response.info.totalRecords} records but this constructor expects 1");
            }

            this.Id = response.results[0].id;

        }
        public dynamic this[String propertyName]
        {
            get
            {
                var method = this.GetType().GetProperty(propertyName);
                if (method != null)
                {
                    return method.GetGetMethod().Invoke(this,null);

                }
                else
                {
                    return this.GetProperty(propertyName);
                }
            }
        }


        public dynamic GetProperties()
        {
            return Setup.api.GET($"/organization/{Id}");
        }

        public dynamic GetProperty(String propertyName)
        {
            var property = this.GetProperties()[propertyName];
            return property == null ? "" : property;

            
        }

        public String TypeName
        {
            get
            {
                var typeID = this["businessTypeEntityId"].ToString();
                List<dynamic> list = Setup.api.GET("/config/lookup/4").ToObject<List<dynamic>>();

                return (String)list.Find(type => type.id == typeID).name;
            }
        } 

    }
}
