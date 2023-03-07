using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json.Linq;
using HitachiQA.Driver;
using HitachiQA.Helpers;
using ApolloTests.Data.Entities;

namespace ApolloTests.Data.Entity
{
    public class Vehicle:BaseEntity
    {
        public readonly string Id;

        public Vehicle(string Id)
        {
            this.Id = Id;

        }
        public override string ToString()
        {
      
            return $"{YearOfManufacture} {Make}{ (String.IsNullOrEmpty(Model) ? "" : $" {Model}") }";
        }
        public dynamic? this[String propertyName] { get { return this.GetProperty(propertyName); }
        }
        public dynamic? GetProperty(String propertyName)
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
            return Cosmos.GetQuery("Tether", $"SELECT * FROM c where c.Vehicle.Id = \"{this.Id}\" ORDER BY c._ts DESC").Result[0]["Vehicle"].ToObject<Dictionary<String, dynamic>>();
        }
        public void SetProperties(params (String key, dynamic value)[] fields)
        {
            throw new NotImplementedException("Need to implement this funciton for Cosmos (maybe through API)");
            //var fieldMap = new Dictionary<String, dynamic>();
            //String keyValue = "";
            //for (int i = 0; i < fields.Length; i++)
            //{
            //    keyValue += $" {fields[i].key} = @{fields[i].key}";

            //    fieldMap.Add($"@{fields[i].key}", fields[i].value);
            //}

            //fieldMap.Add("@Id", $"{this.Id}");

            //SQL.executeQuery($"UPDATE risk.Vehicle SET {keyValue} where Id=@Id;", fieldMap.Select(field => (field.Key, field.Value)).ToArray())    ;

        }
        public bool IsNonPowered()
        {
           return  new List<string>{ "Trailer", "Semi-Trailer" }.Contains(this.TypeName);
        }
        public string Make
        {
            get
            {
                return this.GetProperty("Make") ?? throw new NullReferenceException();
            }
        }
        public string Model
        {
            get
            {
                return this.GetProperty("Model") ?? throw new NullReferenceException();
            }
        }
        public string VinNumber
        {
            get
            {
                return this.GetProperty("VinNumber") ?? throw new NullReferenceException();
            }
            set
            {
                this.SetProperties(("VinNumber", value));
            }
        }

        private long? _RiskId;
        public long RiskId
        {
            get
            {
                if (_RiskId == null)
                {
                    _RiskId = this.GetProperty("RiskId") ?? throw new NullReferenceException();
                }
                return (long)_RiskId;
            }
        }
        public string ClassCode { get
            {
                return this.GetProperty("ClassCode") ?? throw new NullReferenceException();
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
                SetProperties(("RadiusOfOperation", value?? throw new NullReferenceException()));
            }
        }
        public int YearOfManufacture
        {
            get
            {
                return this["YearOfManufacture"]?? throw new NullReferenceException();
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
                                     WHERE VT.Id = @Id;", (("@Id", $"{this.TypeId}")))[0]["Name"];
            }
        }
        public long TypeId
        {
            get
            {
                return this["TypeId"];
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
        public decimal? StatedAmount
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
        public int BodySubCategoryTypeId
        {
            get
            {
                return this.GetProperty(nameof(BodySubCategoryTypeId));
            }
        }
        public int BodyCategoryTypeId
        {
            get
            {
                return this.GetProperty(nameof(BodyCategoryTypeId));
            }
        }
    }
}
