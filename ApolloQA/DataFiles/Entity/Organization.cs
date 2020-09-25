using System;
using System.Collections.Generic;
using System.Text;
using ApolloQA.Driver;
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
            body.filter = new JObject();
            body.filter[$"{filterName}"] = filterValue;
            body.loadChildren = true;

            dynamic response = Setup.api.POST($"/organization/search", body);
            if (response.info.totalRecords != 1)
            {
                throw new InvalidOperationException($"The provided filter {filterName}:{filterValue} retuned {response.info.totalRecords} records but this constructor expects 1");
            }

            this.Id = response.results[0].id;

        }


        public dynamic GetProperties()
        {
            return Setup.api.GET($"/organization/{Id}");
        }

    }
}
