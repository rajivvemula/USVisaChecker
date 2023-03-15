using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApolloTests.Data.EntityBuilder.Entities
{
    public interface IEntityBase
    {
        public JObject ToJObject()
        {
            return JObject.FromObject(this);
        }

        public string? ToString()
        {
            return JObject.FromObject(this).ToString();
        }
    }
}
