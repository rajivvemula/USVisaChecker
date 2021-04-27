using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json.Linq;
using ApolloQA.Source.Driver;
using ApolloQA.Source.Helpers;

namespace ApolloQA.Data.Entity
{
    public class Vehicle
    {
        public readonly long Id;

        public Vehicle(int Id)
        {
            this.Id = Id;

        }
        public Vehicle(long Id)
        {
            this.Id = Id;

        }
        public override string ToString()
        {
      
            return $"{YearOfManufacture} {Make}{ (String.IsNullOrEmpty(Model) ? "" : $" {Model}") }";
        }
        public dynamic this[String propertyName] { get { return this.GetProperty(propertyName); }
        }
        public dynamic GetProperty(String propertyName)
        {
            try
            {
                var property = this.GetProperties()[propertyName];
                return property is DBNull ? null : property;
            }
            catch(KeyNotFoundException ex)
            {
                Log.Error($"Id: {this.Id}");
                Log.Error(this.GetProperties().Select(it => $"{it.Key}, {it.Value}"));
                throw ex;
            }
           
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

        public string Make
        {
            get
            {
                return this.GetProperty("Make");
            }
        }
        public string Model
        {
            get
            {
                return this.GetProperty("Model");
            }
        }


        private long? _RiskId;
        public long RiskId
        {
            get
            {
                if (_RiskId == null)
                {
                    _RiskId = this.GetProperty("RiskId");
                }
                return (long)_RiskId;
            }
        }
        public string ClassCode { get
            {
                return this.GetProperty("ClassCode");
            }
            set
            {
                SetProperties(("ClassCode", value));
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
            set
            {
                SetProperties(("RadiusOfOperation", value));
            }
        }
        public int? YearOfManufacture
        {
            get
            {
                return this["YearOfManufacture"];
            }
            set
            {
                SetProperties(("YearOfManufacture", value));
            }
        }

        public string TypeName
        {
            get
            {
               return (String)SQL.executeQuery(@" SELECT Name 
                                     FROM risk.VehicleType VT
                                     LEFT JOIN risk.Vehicle V ON V.TypeId = VT.id
                                     WHERE V.Id = @Id;", (("@Id", $"{this.Id}")))[0]["Name"];
            }
        }
        public int GrossVehicleWeight
        {
            get
            {
                return int.Parse(this.GetProperty("GrossVehicleWeight"));
            }
        }

        public int SeatingCapacity
        {
            get
            {
                var value = (string?) this.GetProperty("SeatingCapacity");

                if(string.IsNullOrWhiteSpace(value))
                {
                    return 0; 
                }
                return int.Parse(value);
            }
        }
        public decimal? StatedValue
        {
            get
            {
                return this.GetProperty("StatedAmount");
            }
        }
        public bool AntiTheft
        {
            get
            {
                return this.GetProperty("Antitheft")??false;
            }
        }
        public bool SafetyFeatures
        {
            get
            {
                return this.GetProperty("SafetyFeatures")??false;
            }
        }
    }
}
