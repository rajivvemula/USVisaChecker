using ApolloTests.Data.Entities;
using DocumentFormat.OpenXml;
using HitachiQA.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApolloTests.Data.EntityFramework.Location
{
    [Table("Address", Schema = "location")]
    public class Address : BaseEntity
    {
        public long Id { get; set; }

        public int AddressTypeId { get; set; }

        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string MinorMunicipality { get; set; }

        public string MajorMunicipality { get; set; }

        public int StateProvinceId { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public string PostalCode { get; set; }

        public string CountyName { get; set; }

        public string CountyFips { get; set; }

        public long? SmartyStreetDocumentId { get; set; }

        public int? SmartyStreetDocumentIndex { get; set; }

        public string Tags { get; set; }

        public long InsertedByPersonId { get; set; }

        public long? UpdatedByPersonId { get; set; }

        public string InsertedBy { get; set; }

        public DateTimeOffset InsertDateTime { get; set; }

        public DateTimeOffset? UpdateDateTime { get; set; }

        public string UpdatedBy { get; set; }

        public int SourceSystemId { get; set; }

        public string SourceSystemKey { get; set; }

        public int StatusId { get; set; }

        public string LogicId { get; set; }

        public string Version { get; set; }

        public string City
        {
            get
            {
                return MajorMunicipality;
            }
            set
            {
                MajorMunicipality = value;
            }
        }

        public int StateId
        {
            get
            {
                return StateProvinceId;
            }
            set
            {
                StateProvinceId = value;
            }
        }
        public string StateName
        {
            get
            {
                return SQL.executeQuery(@$"SELECT Name  
                                     FROM [location].[StateProvince]
                                     Where Id='{StateProvinceId}';")[0]["Name"];
            }
        }
        public string StateCode
        {
            get
            {
                return SQL.executeQuery(@$"SELECT Code  
                                     FROM [location].[StateProvince]
                                     Where Id='{StateProvinceId}';")[0]["Code"];
            }
        }
        public string ToString()
        {
            StringBuilder address = new StringBuilder();
            address.Append(Line1)
                   .Append(Line2 == null || Line2?.Length == 0 ? "" : " ")
                   .Append(Line2)
                   .Append(", ")
                   .Append(City)
                   .Append(", ")
                   .Append(StateCode)
                   .Append(", ")
                   .Append(PostalCode)
                   ;
            return address.ToString();
        }
        public string ToString(bool IncludeCountryName, bool IncludeCountryCode = false)
        {
            if (IncludeCountryName)
            {
                StringBuilder address = new StringBuilder();
                address.Append(Line1)
                       .Append(Line2 == null || Line2?.Length == 0 ? "" : " ")
                       .Append(Line2)
                       .Append(", ")
                       .Append(City)
                       .Append(", ")
                       .Append(StateCode)
                       .Append(", ")
                       .Append(this.Country.Name)
                       .Append(", ")
                       .Append(PostalCode)
                       ;
                return address.ToString();
            }
            else if (IncludeCountryCode)
            {
                StringBuilder address = new StringBuilder();
                address.Append(Line1)
                       .Append(Line2 == null || Line2?.Length == 0 ? "" : " ")
                       .Append(Line2)
                       .Append(", ")
                       .Append(City)
                       .Append(", ")
                       .Append(StateCode)
                       .Append(", ")
                       .Append(this.Country.Code)
                       .Append(", ")
                       .Append(PostalCode)
                       ;
                return address.ToString();
            }
            else
            {
                return ToString();
            }
        }

    }


}
