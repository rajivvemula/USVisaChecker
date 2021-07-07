using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json.Linq;
using ApolloQA.Source.Helpers;

namespace ApolloQA.Data.Entity
{
    public class Claim
    {
        public readonly int Id;

        public Claim(int Id)
        {
            this.Id = Id;
        }

        public Claim(string property, int value)
        {
            this.Id = (int)Cosmos.GetQuery("Claim", $"SELECT * FROM c Where c.{property}={value} ORDER BY c._ts DESC OFFSET 0 LIMIT 1").ElementAt(0)["Id"];

        }

        public Claim(string property, string value)
        {
            this.Id = (int)Cosmos.GetQuery("Claim", $"SELECT * FROM c Where c.{property}='{value}' ORDER BY c._ts DESC OFFSET 0 LIMIT 1").ElementAt(0)["Id"];

        }

        public dynamic this[String propertyName]
        {
            get
            {
                var method = this.GetType().GetProperty(propertyName);
                if (method != null)
                {
                    return method.GetGetMethod().Invoke(this, null);

                }
                else
                {
                    return GetProperty(propertyName);
                }
            }
        }

        public static Claim GetLatestClaim()
        {
            return new Claim((int)Cosmos.GetQuery("Claim", "SELECT * FROM c ORDER BY c._ts DESC OFFSET 0 LIMIT 1").ElementAt(0)["Id"]);
        }

        public dynamic GetProperties()
        {
            return Cosmos.GetQuery("Claim", $"SELECT * FROM c WHERE c.Id = {this.Id} OFFSET 0 LIMIT 1").ElementAt(0);
        }
        public dynamic GetProperty(String propertyName)
        {
            var property = this.GetProperties()[propertyName];
            return property == null ? "" : property;
        }

        private String _ClaimNumber { get; set; }
        public string ClaimNumber
        {
            get
            {
                return _ClaimNumber ??= GetProperty("claimNumber");
            }
        }

        public bool isFNOL
        {
            get
            {
                return GetProperty("ClaimStateId") == 0 ? true : false;
            }
        }
    }
}
