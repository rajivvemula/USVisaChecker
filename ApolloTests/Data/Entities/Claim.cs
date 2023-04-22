using ApolloTests.Data.Entities.Context;
using HitachiQA.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApolloTests.Data.Entities
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

        [JsonProperty("claimNumber")]
        public string ClaimNumber { get; set; }

        [JsonProperty("ClaimStateId")]
        public int ClaimStateId { get; set; }

        public bool isFNOL => ClaimStateId == 0 ? true : false;

    }

}

