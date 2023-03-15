using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApolloTests.Data.EntityBuilder.Entities
{
    public class Modifier : IEntityBase
    {
        public Modifier(string modifierCode)
        {
            this.ModifierCode = modifierCode;
        }
        [JsonIgnore]
        public string ModifierCode { get; set; }

        [HydratorAttr("Quote.GetModifierId(self.ModifierCode)")]
        public long id { get; set; }

        [HydratorAttr("ApplicationId")]
        public string? applicationId { get; set; }

        public JObject? ratingModifierCategorySubtypeCode { get; set; }

        [HydratorAttr("Quote.GetRatingModifierId(self.ModifierCode)")]
        public long ratingModifierId { get; set; }

        public List<JObject> actionResults { get; set; } = new List<JObject>();

        public decimal totalActionResultPercentage { get; set; } = 0;

        public decimal adjustmentPercentage { get; set; } = 0;

        public JObject? adjustmentJustification { get; set; }

        public decimal totalPercentage { get; set; } = 0;

        public decimal totalFactor { get; set; } = 0;

        public void Add(decimal UWJudgementFactor)
        {
            adjustmentPercentage += UWJudgementFactor;
        }

    }
}
