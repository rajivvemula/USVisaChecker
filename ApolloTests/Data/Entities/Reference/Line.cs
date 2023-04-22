using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApolloTests.Data.Entities.Reference
{
    [Table("Line", Schema = "reference")]
    public class Line : BaseEntity
    {
        public int Id { get; set; }

        [NotMapped]
        [JsonIgnore]
        public LineEnum LineEnum => (LineEnum)Id;

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

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

        public bool CalculateDistanceToCoast { get; set; }

        public virtual List<SubLine> SubLines { get; set; }

    }


}
