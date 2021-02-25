using System;
using System.Collections.Generic;
using System.Linq;
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

        public static Organization GetLatestOrganization()
        {
            return new Organization((int)SQL.executeQuery("SELECT TOP (1) org.Id FROM [party].[Organization] org " +
                "LEFT JOIN party.OrganizationType OrgType ON org.OrganizationTypeId = OrgType.id " +
                "WHERE orgType.Name = 'Insured' and org.StatusId = 0 ORDER BY Id Desc;")[0]["Id"]);
        }

        public Organization(String filterName, String filterValue )
        {

            dynamic body = new JObject();
            body.filters = new JObject();
            body.filters[$"{filterName}"] = filterValue;
            body.filters["EntityStatusComplexFilter"] = "{\"StatusIds\":[0,2,1]}";
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
            try
            {
                return RestAPI.GET($"/organization/{Id}");
            }
            catch(Exception ex)
            {
                Log.Warn($"GET /organization/{Id} threw Exception");
                throw ex;
            }
        }

        public dynamic GetProperty(String propertyName)
        {
            var property = this.GetProperties()[propertyName];
            return property == null ? "" : property;

            
        }

        public int PartyId
        {
            get
            {
                return (int)this.GetProperty("partyId");
            }
        }
        public List<Address> Addresses
        {
            get
            {
                var AddressSearchBody = new JObject();

                AddressSearchBody.Add("currentPage", 0);
                AddressSearchBody.Add("filters", new JObject());
                ((JObject)AddressSearchBody["filters"]).Add("OrganizationAddressFilter", "{\"PartyId\":" + this["partyId"] + "}");
                AddressSearchBody.Add("loadChildren", true);
                AddressSearchBody.Add("pageSize", 50);
                return ((JArray)RestAPI.POST("/address/search", AddressSearchBody)?["results"]).Select(it => new Address(it)).ToList();

            }
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
                dynamic phone = phones.Find(it => it?["phoneType"]?["code"] == "BUSINESS");
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
                dynamic site = sites.Find(it => it?["internetType"]?["code"] == "WEBSITE");
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


        public int? InsuranceScore
        {
            get
            {
                var response = Cosmos.GetQuery("NcfResponse", $"SELECT * FROM c where c.PartyId = {this["partyId"]} ORDER BY c._ts DESC OFFSET 0 LIMIT 1").Result;

                return response.Count > 0 ? response[0]["RawScore"] : null;
                
            }
        }


       

    }
}
