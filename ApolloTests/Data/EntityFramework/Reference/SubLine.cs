using ApolloTests.Data.Entities;
using DocumentFormat.OpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApolloTests.Data.EntityFramework.Reference
{
    [Table("SubLine", Schema = "reference")]
    public class SubLine : BaseEntity
    {
        public int Id { get; set; }

        public int ParentLineId { get; set; }

        public virtual Line ParentLine { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool? IsDefault { get; set; }

        public DateTimeOffset TimeFrom { get; set; }

        public DateTimeOffset TimeTo { get; set; }

        public long InsertedByPersonId { get; set; }

        public DateTimeOffset InsertDateTime { get; set; }

        public string InsertedBy { get; set; }

        public long? UpdatedByPersonId { get; set; }

        public DateTimeOffset? UpdateDateTime { get; set; }

        public string UpdatedBy { get; set; }

        public int? SourceSystemId { get; set; }

        public string? SourceSystemKey { get; set; }

        public int StatusId { get; set; }


    }

}
