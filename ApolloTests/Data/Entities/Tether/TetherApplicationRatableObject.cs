using ApolloTests.Data.Entities.Context;
using ApolloTests.Data.Entities.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApolloTests.Data.Entities.Tether
{
    [Table("TetherApplicationRatableObject", Schema ="tether")]
    public class TetherApplicationRatableObject : BaseEntityEF
    {

        public TetherApplicationRatableObject(SQLContext context) : base(context) { }

        public long TetherId { get; set; }
        public virtual Tether Tether { get; set; }
        public long? ApplicationId { get; set; }
        public long? RatableObjectId { get; set; }
        [ListenForChanges]
        public virtual int? TetherStatusTypeId { get; set; }
        public TetherStatusType TetherStatusType => (TetherStatusType)(TetherStatusTypeId?? throw new Exception());
        public DateTimeOffset? InsertDateTime { get; set; }
        public String? InsertedBy { get; set; }
        public long? InsertedByPersonId { get; set; }
        public DateTimeOffset? UpdateDateTime { get; set; }
        public String? UpdatedBy { get; set; }
        public long? UpdatedByPersonId { get; set; }
        public int? SourceSystemId { get; set; }
        public String? SourceSystemKey { get; set; }
        public int? StatusId { get; set; }
    }
}
