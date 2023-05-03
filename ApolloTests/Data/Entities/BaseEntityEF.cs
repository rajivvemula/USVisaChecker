using ApolloTests.Data.Entities.Context;
using ApolloTests.Data.EntityBuilder;
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
        public virtual long Id { get; set; }

        public BaseEntityEF(CosmosContext context) : base(context) { }
        public BaseEntityEF(SQLContext context) : base(context) { }
        public BaseEntityEF(QuoteBuilder builder) : base(builder) { }
        public BaseEntityEF() { }

        public void Reload() => Context.Entry(this).Reload();



    }
}
