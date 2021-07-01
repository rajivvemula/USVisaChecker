using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

        //This function cannot be executed asynchronous (parallel)
        //Because we would get the same name for both threads
        //
        //Mutex: basically acquires ownership of the MUTEX_ORG_NEXTVALIDNAME mutex at the operating system level
        // enforcing that this mutex must be released before any other thread acquires it
        // learn more: https://docs.microsoft.com/en-us/dotnet/api/system.threading.mutex?view=net-5.0
        public static String GetNextValidName(String name, out Mutex mutex)
        {
            if(Mutex.TryOpenExisting("MUTEX_ORG_NEXTVALIDNAME", out mutex))
            {
                mutex.WaitOne();
            }
            else
            {
                mutex = new Mutex(true, "MUTEX_ORG_NEXTVALIDNAME");
            }
            var result = SQL.executeQuery("SELECT [Name] FROM [party].[Organization] Where [Name] Like 'Automation API org%';");

            if(result.Count() ==0)
            {
                return name;
            }
            
            IEnumerable<string> names = result.Select(it => ((string)it["Name"]));
            if (!names.Contains($"{name} (1)"))
            {
                return $"{name} (1)";
            }

            IEnumerable<int> numbers = names.Where(name=> name.Contains('('))
                                            .Select(name =>
                                                         int.Parse(
                                                         string.Join("", name.Substring(name.IndexOf('('))
                                                         .Where(Char.IsDigit)
                                                   )));
            return $"{name} ({numbers.Max() + 1})";
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

        public void SetProperty(String propertyName, dynamic value)
        {
            SQL.executeQuery($"UPDATE party.Organization SET {propertyName} = @value WHERE Id={this.Id}", (("@value", value)));
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

            set
            {
                SetProperty("TaxId", value);
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

        public Rating.ClassCodeKeyword ClassCodeKeyword
        {
            get
            {
                return Rating.ClassCodeKeyword.GetUsingKeywordId(this.KeywordId);
            }
        }

        public String KeywordName
        {
            get
            {
                return this?["keyword"]?["name"];
            }
        }
        public String KeywordId
        {
            get
            {
                return this?["keyword"]?["id"];
            }
        }
        public String ClassTaxonomyName
        {
            get
            {
                return this?["keyword"]?["industryClassTaxonomyClassName"];
            }
        }
        public String ClassTaxonomyId
        {
            get
            {
                return this?["keyword"]?["industryClassTaxonomyId"];
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
                var response = Cosmos.GetQuery("NcfResponse", $"SELECT * FROM c where c.PartyId = {this["partyId"]} ORDER BY c._ts DESC OFFSET 0 LIMIT 1");

                return response.Any() ? response.ElementAt(0)["RawScore"] : null;
                
            }
        }

    }
}
