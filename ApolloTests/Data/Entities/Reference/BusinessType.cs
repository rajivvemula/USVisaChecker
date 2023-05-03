using ApolloTests.Data.Entities.Context;
using HitachiQA.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApolloTests.Data.Entities
{
    [Table("BusinessType", Schema = "reference")]
    public class BusinessType : BaseEntityEF
    {

        public BusinessType(SQLContext context) : base(context)
        {

        }
        [Key]
        public new int? Id { get; set; }

        public string? Code { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

    }

}

