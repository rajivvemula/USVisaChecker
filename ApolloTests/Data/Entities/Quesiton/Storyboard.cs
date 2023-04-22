using ApolloTests.Data.Entities.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApolloTests.Data.Entities.Quesiton
{
    [Table("Storyboard", Schema = "question")]
    public class Storyboard : BaseEntityEF
    {
        public Storyboard(SQLContext ctx) : base(ctx)
        {

        }
        public string Name { get; set; }

        public int LineId { get; set; }

        public long CarrierPartyId { get; set; }

        public string Condition { get; set; }

        public DateTimeOffset TimeFrom { get; set; }

        public DateTimeOffset TimeTo { get; set; }

        [NotMapped]
        public List<Section> Sections => StoryboardSections.OrderBy(it=> it.SortOrder).Select(it => it.Sections).ToList();

        public virtual List<StoryboardSection> StoryboardSections { get; set; }

        public Section GetSection(long Id)=> StoryboardSections.First(it=>it.SectionId== Id).Sections;
        public Section GetSection(string Name) => Sections.OrderBy(it=> it.SectionGroupName).First(it => it.SectionName == Name);


    }
}
