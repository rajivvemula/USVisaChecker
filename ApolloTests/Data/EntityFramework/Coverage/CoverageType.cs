using Polly;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using ApolloTests.Data.Entities;
using Newtonsoft.Json;
using ApolloTests.Data.EntityFramework.Tether;

namespace ApolloTests.Data.EntityFramework.Coverage
{
    [Table("CoverageType", Schema = "coverage")]
    public class CoverageType : BaseEntity
    {
        public long Id { get; set; }

        public int LineId { get; set; }

        public string TypeName { get; set; }

        public string Aliases { get; set; }

        public int SortOrder { get; set; }

        public string Description { get; set; }

        public string InsertedBy { get; set; }

        public DateTimeOffset InsertDateTime { get; set; }

        public long InsertedByPersonId { get; set; }

        public string UpdatedBy { get; set; }

        public DateTimeOffset? UpdateDateTime { get; set; }

        public long? UpdatedByPersonId { get; set; }

        public int SourceSystemId { get; set; }

        public string SourceSystemKey { get; set; }

        public int? StatusId { get; set; }
    }
}
