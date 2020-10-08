using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json.Linq;
using ApolloQA.Driver;
using ApolloQA.Helpers;

namespace ApolloQA.DataFiles.Entity
{
    class Vehicle
    {
        private readonly int Id;

        public Vehicle(int Id)
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
            return SQL.executeQuery("SELECT *  FROM [risk].[Vehicle] where Id = @Id;", (("@Id", $"{this.Id}")))[0];
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

            SQL.executeQuery($"UPDATE risk.Vehicle SET {keyValue} where Id=@Id;", fieldMap.Select(field => (field.Key, field.Value)).ToArray())    ;

        }

        public String? ClassCode { get
            {
                return this["ClassCode"];

            } 
        }
        public int? RadiusOfOperation
        {
            get
            {
                var value = this["RadiusOfOperation"];
                if (value != null)
                {
                    return int.Parse(value);
                }
                return null;
            }
        }
        public int? YearOfManufacture
        {
            get
            {
                return this["YearOfManufacture"];
                
            }
        }
        public int? Territory
        {
            get
            {
                var zip = this["ZipCode"]?.ToString();

                var data = Engine.getTable("TT.1");


                if (int.TryParse(data.Find(row => row["Zip Code"] == zip)?["Territory"], out int value))
                { return value; }

                return null;               

            }
        }
    }
}
