using ApolloTests.Data.Entities.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApolloTests.Data.Entities.Coverage
{
    [Table("LimitDeductible", Schema = "coverage")]
    public class LimitDeductible: BaseEntityEF
    {
        public LimitDeductible(SQLContext context) : base(context) { }

        public string Value { get; set; }
        public string DisplayName { get; set; }

        public long CoverageTypeId { get; set; }

        public virtual CoverageType CoverageType { get; set; }

    }
}
