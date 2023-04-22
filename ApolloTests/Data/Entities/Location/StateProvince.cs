using ApolloTests.Data.EntityBuilder;
using ApolloTests.Data.Entities.Context;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApolloTests.Data.Entities.Location
{
    [Table("StateProvince", Schema = "location")]
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class StateProvince : BaseEntityEF
    {
        public StateProvince()
        {

        }
        public StateProvince(SQLContext ctx) : base(ctx) { }

        [JsonProperty("id")]
        public new int? Id { get; set; }

        [HydratorAttr("StateCode")]
        [JsonProperty("code")]
        public string Code { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public string Description { get; set; }

        [JsonIgnore]
        public DateTimeOffset TimeFrom { get; set; }

        [JsonIgnore]
        public DateTimeOffset TimeTo { get; set; }
    }
}
