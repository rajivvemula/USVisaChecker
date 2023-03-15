using ApolloTests.Data.EntityBuilder.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApolloTests.Data.EntityBuilder.Entities
{
    public interface IRiskEntity
    {
          
        [JsonIgnore]
        public abstract IOutputMetadata OutputMetadata { get; set; }

        [JsonIgnore]
        public RiskType RiskType { get; }

        public Risk GetRisk();

        public JObject ToJObject()
        {
            return JObject.FromObject(this);
        }

        public string? ToString()
        {
            if (this == null)
                return null;
            return JObject.FromObject(this).ToString();
        }

    }

}
