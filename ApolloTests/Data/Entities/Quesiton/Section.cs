using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApolloTests.Data.Entities.Quesiton
{
    [Table("QuestionSection", Schema = "question")]
    public class Section
    {
        public long Id { get; set; }

        public string ShortName { get; set; }

        public string SectionName { get; set; }

        public string SectionDescription { get; set; }

        public string SectionGroupName { get; set; }

        public string SectionHeader { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string VisibilityProperties { get; set; }

        public string NextButton { get; set; }

        public int? SortOrder { get; set; }

        public string VisibilityConditions { get; set; }

        public bool RequiresSpecialRendering { get; set; }

        public string SpecialRenderingType { get; set; }

        public string AdditionalProperties { get; set; }

        public int? EntityTypeId { get; set; }
    }
}
