using ApolloTests.Data.Entities.Context;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApolloTests.Data.Entities
{
    public abstract class BaseEntityEF : BaseEntity
    {
        [NotMapped]
        [JsonIgnore]
        public dynamic? this[String propertyName]
        {
            get
            {
                var method = this.GetType().GetProperty(propertyName);
                if (method != null)
                {
                    return method.GetGetMethod()?.Invoke(this, null);
                }
                throw new KeyNotFoundException($"PropertyName: {propertyName} not found in {this.GetType().Name}");
            }
        }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonIgnore]
        public CosmosContext ContextCosmos { get; }

        [JsonIgnore]
        public SQLContext ContextSQL { get; }

        [JsonIgnore]
        public ApolloContext Context { get; }

        public BaseEntityEF(CosmosContext context)
        {
            Context = context;
            ContextCosmos = context.CosmosContext;
            ContextSQL = context.SQLContext;
        }
        public BaseEntityEF(SQLContext context)
        {
            Context = context;
            ContextCosmos = context.CosmosContext;
            ContextSQL = context.SQLContext;

        }

        public void Reload() => Context.Entry(this).Reload();

        public BaseEntityEF()
        {

        }


    }
}
