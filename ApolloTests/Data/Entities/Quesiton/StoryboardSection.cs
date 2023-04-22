using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApolloTests.Data.Entities.Quesiton
{
    [Table("StoryboardSection", Schema = "question")]
    public class StoryboardSection
    {
        public long Id { get; set; }

        public long StoryboardId { get; set; }

        public virtual Storyboard Storyboard{ get; set; }

        public long SectionId { get; set; }

        public virtual Section Sections { get; set; }

        public long? DependsOnSectionId { get; set; }

        public int? SortOrder { get; set; }

        public string Condition { get; set; }


    }
}
