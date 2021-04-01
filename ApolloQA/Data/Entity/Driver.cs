using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json.Linq;
using ApolloQA.Source.Driver;
using ApolloQA.Source.Helpers;

namespace ApolloQA.Data.Entity
{
    public class Driver
    {
        public readonly long Id;

        public Driver(int Id)
        {
            this.Id = Id;

        }
        public Driver(long Id)
        {
            this.Id = Id;

        }

        public dynamic this[String propertyName] { get { return this.GetProperty(propertyName); }
        }
        public dynamic GetProperty(String propertyName)
        {
            var property = this.GetProperties()[propertyName];
            return property is DBNull ? null : property;
        }
        public Dictionary<String, dynamic> GetProperties()
        {
            return SQL.executeQuery("SELECT *  FROM [risk].[Driver] where Id = @Id;", (("@Id", $"{this.Id}")))[0];
        }
        public void SetProperties(params (String key, dynamic value)[] fields)
        {
            var fieldMap = new Dictionary<String, dynamic>();
            String keyValue = "";
            for (int i = 0; i < fields.Length; i++)
            {
                keyValue += $" {fields[i].key} = @{fields[i].key}";

                fieldMap.Add($"@{fields[i].key}", fields[i].value);
            }

            fieldMap.Add("@Id", $"{this.Id}");

            SQL.executeQuery($"UPDATE risk.Driver SET {keyValue} where Id=@Id;", fieldMap.Select(field => (field.Key, field.Value)).ToArray())    ;

        }

        private long? _RiskId { get; set; }
        public long RiskId
        {
            get
            {
                if(_RiskId == null)
                {
                    _RiskId = this.GetProperty("RiskId");
                }
                return (long)_RiskId;
            }
        }
        public long PersonId
        {
            get
            {
                return this.GetProperty("PersonId");
            }
        }
        public DateTimeOffset DateOfBirth
        {
            get
            {
                return this.GetProperty("DateOfBirth");
            }
        }
        public string LicenseNo
        {
            get
            {
                return this.GetProperty("LicenseNo");
            }
        }
        public DateTimeOffset LicenseExpirationDate
        {
            get
            {
                return this.GetProperty("LicenseExpirationDate");
            }
        }

        public dynamic GetQuestionResponse(Quote quote, string alias)
        {
            var risks = (JArray)quote.GetProperty("risks");
            var risk = risks.FirstOrDefault(it => it["riskId"].ToObject<long>() == this.RiskId);

            foreach (JObject response in risk["outputMetadata"]["QuestionResponses"])
            {
                if (response["questionAlias"].ToString() == alias)
                {
                    return ((JValue)response["response"]).Value;
                }
            }
            return null;
        }


    }
}
