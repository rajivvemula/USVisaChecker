using ApolloTests.Data.Entities;
using ApolloTests.Data.EntityFramework.Context;
using HitachiQA.Helpers;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ApolloTests.Data.Entity.Claim;

namespace ApolloTests.Data.EntityFramework
{
    public class Claim : BaseEntity
    {
        public CosmosContext Context { get; }
        public SQLContext SQLContext { get; }
        public Claim(CosmosContext context)
        {
            Context = context;
            this.SQLContext = context.SQLContext;

        }
        [Key]
        public string id { get; set; }
        public long Id { get; set; }
        public string ApplicationNumber { get; set; }
        [Required]
        public string Discriminator { get; set; }
        public long _ts { get; set; }

        

        public dynamic this[String propertyName]
        {
            get
            {
                var method = this.GetType().GetProperty(propertyName);
                if (method != null)
                {
                    return method.GetGetMethod()?.Invoke(this, null) ?? throw new Exception();

                }
                else
                {
                    return GetProperty(propertyName);
                }
            }
        }

        //public static Claim GetLatestClaim()
        //{
        //    return new Claim((int)Cosmos.GetQuery("Claim", "SELECT * FROM c ORDER BY c._ts DESC OFFSET 0 LIMIT 1").ElementAt(0)["Id"]);
        //}

        public dynamic GetProperties()
        {
            return Cosmos.GetQuery("Claim", $"SELECT * FROM c WHERE c.Id = {this.Id} OFFSET 0 LIMIT 1").Result.ElementAt(0);
        }
        public dynamic GetProperty(String propertyName)
        {
            var property = this.GetProperties()[propertyName];
            return property == null ? "" : property;
        }

        private String? _ClaimNumber { get; set; } = null;
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

