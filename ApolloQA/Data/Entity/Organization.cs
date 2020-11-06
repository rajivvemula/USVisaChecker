using System;
using System.Collections.Generic;
using System.Text;
using ApolloQA.Source.Driver;
using ApolloQA.Source.Helpers;
using Newtonsoft.Json.Linq;

namespace ApolloQA.Data.Entity
{
    public class Organization
    {

        public readonly int Id;

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

            dynamic response = RestAPI.POST($"/organization/search", body);
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
            return RestAPI.GET($"/organization/{Id}");
        }

        public dynamic GetProperty(String propertyName)
        {
            var property = this.GetProperties()[propertyName];
            return property == null ? "" : property;

            
        }

        public String Name
        {
            get
            {
                return this["name"];
            }
        }
        public String DBA
        {
            get
            {
                return this["dba"];
            }
        }
        public String TypeName
        {
            get
            {
                var typeID = this["businessTypeEntityId"].ToString();
                List<dynamic> list = RestAPI.GET("/config/lookup/4").ToObject<List<dynamic>>();

                return (String)list.Find(type => type.id == typeID).name;
            }
        }
        public String TaxIdType
        {
            get
            {
                var taxTypeId = this["taxTypeId"];
                return TaxIDTypeName[(int)taxTypeId.Value];
            }
        }
        private static Dictionary<int, string> TaxIDTypeName = new Dictionary<int, string>()
        {
            {0, "FEIN" },
            {1, "SSN" }
        };
        public String TaxId
        {
            get
            {
                return this["taxId"];
            }
        }
        public String Description
        {
            get
            {
                return this["description"];
            }
        }
        public String BusinessPhoneNumber
        {
            get
            {
                List<dynamic> phones = ((JArray)this["phones"]).ToObject<List<dynamic>>();
                dynamic phone = phones.Find(it => it?["phoneType"]?["Code"] == "BUSINESS");
                return phone?["number"];
            }
        }
        public String BusinessEmailAddress
        {
            get
            {
                return this["primaryEmail"]?["address"];
            }
        }
        public String BusinessWebsite
        {
            get
            {
                List<dynamic> sites = ((JArray)this["sites"]).ToObject<List<dynamic>>();
                dynamic site = sites.Find(it => it?["internetType"]?["Code"] == "WEBSITE");
                return site?["address"];
            }
        }

        public String KeywordName
        {
            get
            {
                return this?["keyword"]?["name"];
            }
        }
        public String ClassTaxonomyName
        {
            get
            {
                return this?["keyword"]?["industryClassTaxonomyClassName"];
            }
        }

        public int? YearOwnershipStarted
        {
            get
            {
                return this?["yearOwnershipStarted"];
            }
        }
        public int? YearBusinessStarted
        {
            get
            {
                return this?["yearBusinessStarted"];
            }
        }


        public int? InsurranceScore
        {
            get
            {
                var response = Cosmos.GetQuery("NcfResponse", "SELECT * FROM c where c.PartyId = 10247 ORDER BY c._ts DESC OFFSET 0 LIMIT 1").Result;

                return response.Count > 0 ? response[0]["RawScore"] : null;
                
            }
        }


        public String InsurranceScoreTier
        {
            get
            {
                    int? score = this.InsurranceScore;
                    if(score == null)
                    {
                        return null;
                    }
                    var VehicleSearchBody = new JObject();

                    VehicleSearchBody.Add("currentPage", 0);
                    VehicleSearchBody.Add("filters", new JObject("CurrentVehiclesRisksPartyFilter", "\"{\"PartyId\":"+ this["partyId"] + "}\""));
                    VehicleSearchBody.Add("loadChildren", true);


                    int fleetSize = RestAPI.POST("/vehicle/search", VehicleSearchBody).info.totalRecords;
                    String type = this.TypeName;


                    foreach(Dictionary<String, String>row in Engine.getTable("CT.2"))
                    {

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
