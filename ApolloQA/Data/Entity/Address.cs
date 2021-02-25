using System;
using System.Collections.Generic;
using System.Text;
using ApolloQA.Source.Helpers;
using Newtonsoft.Json.Linq;

namespace ApolloQA.Data.Entity
{
    public class Address
    {

        public String Street1;
        public String Street2;
        public String City;
        public String StateCode;
        public String PostalCode;
        public String CountryName;
        public String CountryCode;
        public int? Id;

        public Address(String Street1, String Street2, String City, String StateCode, String PostalCode, String CountryName)
        {
            this.Street1 = Street1;
            this.Street2 = Street2;
            this.City = City;
            this.StateCode = StateCode;
            this.PostalCode = PostalCode;
            this.CountryName = CountryName;
         
        }
        public Address(String Street1, String City, String StateCode, String PostalCode, String CountryName)
        {
            this.Street1 = Street1;
            this.City = City;
            this.StateCode = StateCode;
            this.PostalCode = PostalCode;
            this.CountryName = CountryName;
        }

        public Address(int location_Address_ID)
        {
            var address = SQL.executeQuery(@"SELECT la.[Id]
		                                                ,[AddressTypeId]
		                                                ,[Line1]
		                                                ,[Line2]
		                                                ,[MajorMunicipality]
		                                                ,[StateProvinceId]
		                                                ,[CountryId]
		                                                ,[PostalCode]
		                                                ,[CountyName]
		                                                ,[CountyFips]
		                                                ,lsp.Name as StateName
		                                                ,lsp.Code as StateCode
		                                                ,lc.Name as CountryName
		                                                FROM [location].[Address] la
		                                                LEFT JOIN location.StateProvince lsp on lsp.Id = la.StateProvinceId 
		                                                LEFT JOIN location.Country lc on lc.Id = la.CountryId
		                                                where la.Id = @ID;", ("@ID", location_Address_ID))[0];

            this.Street1 = address["Line1"] is DBNull ? null : address["Line1"];
            this.Street2 = address["Line2"] is DBNull ? null : address["Line2"];
            this.City = address["MajorMunicipality"] is DBNull ? null: address["MajorMunicipality"];
            this.StateCode = address["StateCode"] is DBNull ? null: address["StateCode"];
            this.PostalCode = address["PostalCode"] is DBNull ? null: address["PostalCode"];
            this.CountryName = address["CountryName"] is DBNull ? null : address["CountryName"];
            this.Id = location_Address_ID;


        }

        public Address(dynamic address)
        {

            this.Street1 = address["line1"];
            this.Street2 = address["line2"];
            this.City = address["majorMunicipality"];
            this.StateCode =address["stateProvince"]["code"];
            this.PostalCode = address["postalCode"];
            this.CountryName = address["country"]["name"];
            this.Id = address["id"];


        }





        override
        public String ToString()
        {
            StringBuilder address = new StringBuilder();
            address.Append(this.Street1)
                   .Append(this.Street2 == null || this.Street2?.Length == 0 ? "" : " ")
                   .Append(this.Street2)
                   .Append(", ")
                   .Append(this.City)
                   .Append(", ")
                   .Append(this.StateCode)
                   .Append(", ")
                   .Append(this.PostalCode)
                   ;
            return address.ToString();
        }
        public String ToString(bool IncludeCountryName, bool IncludeCountryCode = false)
        {
            if(IncludeCountryName)
            {
                StringBuilder address = new StringBuilder();
                address.Append(this.Street1)
                       .Append(this.Street2 == null || this.Street2?.Length == 0 ? "" : " ")
                       .Append(this.Street2)
                       .Append(", ")
                       .Append(this.City)
                       .Append(", ")
                       .Append(this.StateCode)
                       .Append(", ")
                       .Append(this.CountryName)
                       .Append(", ")
                       .Append(this.PostalCode)
                       ;
                return address.ToString();
            }
            else if(IncludeCountryCode)
            {
                StringBuilder address = new StringBuilder();
                address.Append(this.Street1)
                       .Append(this.Street2 == null || this.Street2?.Length == 0? "" : " ")
                       .Append(this.Street2)
                       .Append(", ")
                       .Append(this.City)
                       .Append(", ")
                       .Append(this.StateCode)
                       .Append(", ")
                       .Append(this.CountryCode)
                       .Append(", ")
                       .Append(this.PostalCode)
                       ;
                return address.ToString();
            }
            else
            {
                return this.ToString();
            }
        }


    }
}
