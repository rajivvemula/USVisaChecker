using System;
using System.Collections.Generic;
using System.Text;
using ApolloQA.Driver;
using ApolloQA.Helpers;
using Newtonsoft.Json.Linq;

namespace ApolloQA.DataFiles.Entity
{
    public class Organization
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
        public String InsurranceScoreTier
        {
            get
            {
                var partyID = this["partyId"];
                var nfcSearchBody = new JObject();
                nfcSearchBody.Add("pageSize", 1);
                nfcSearchBody.Add("orderBy", "ScoreDate");
                nfcSearchBody.Add("sortOrder", 1);

                dynamic nfcResponse = Setup.api.POST($"/party/{partyID}/ncf/search", nfcSearchBody);

                if(nfcResponse.info.totalRecords ==0)
                {
                    return null;
                }
                else
                {
                    var VehicleSearchBody = new JObject();

                    VehicleSearchBody.Add("currentPage", 0);
                    VehicleSearchBody.Add("filters", new JObject("CurrentVehiclesRisksPartyFilter", "\"{\"PartyId\":"+partyID+"}\""));
                    VehicleSearchBody.Add("loadChildren", true);


                    int fleetSize = Setup.api.POST("/vehicle/search", VehicleSearchBody).info.totalRecords;
                    int score = int.Parse(nfcResponse.results[0].rawScore);
                    String type = this.TypeName;

                    const int numberOfColumns = 6;
                    const int itemsToIgnoreTop = 1;


                    foreach(Dictionary<String, String>row in Engine.getTable("CT.2"))
                    {
                        Console.WriteLine("Row: ->");
                        foreach (var column in row)
                        {
                            Console.Write($"{column.Key}:{column.Value}, ");

                        }

                        if (Functions.parseRatingFactorNumericalValues(row["Fleet Size Lower Bound"]) <= fleetSize &&
                            Functions.parseRatingFactorNumericalValues(row["Fleet Size Upper Bound"]) >= fleetSize &&
                            Functions.parseRatingFactorNumericalValues(row["Insurance Score Lower Bound"]) <= score &&
                            Functions.parseRatingFactorNumericalValues(row["Insurance Score Upper Bound"]) >= score &&
                            row["Organization Type"] == type
                            )
                        {
                            return row["Insurance Score Tier"];
                        }
                    }
                    return null;

                }
            }
        }

    }
}
