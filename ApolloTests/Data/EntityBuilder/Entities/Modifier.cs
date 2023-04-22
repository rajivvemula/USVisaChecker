using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApolloTests.Data.EntityBuilder.Entities
{
    public class Modifier 
    {
     
        [JsonIgnore]
        public string ModifierCode { get; set; }

        [HydratorAttr("Quote.GetModifierId(self.ModifierCode)")]
        public long id { get; set; }

        [HydratorAttr("ApplicationId")]
        public string? applicationId { get; set; }

        public JObject? ratingModifierCategorySubtypeCode { get; set; }

        [HydratorAttr("Quote.GetRatingModifierId(self.ModifierCode)")]
        public long ratingModifierId { get; set; }

        [JsonProperty("actionResults")]
        public List<JObject> ActionResults { get; set; }

        [JsonProperty("totalActionResultPercentage")]
        public decimal TotalActionResultPercentage { get; set; }

        [JsonProperty("adjustmentPercentage")]
        public decimal? AdjustmentPercentage { get; set; }

        [JsonProperty("adjustmentJustification")]
        public string? AdjustmentJustification { get; set; }

        [JsonProperty("totalPercentage")]
        public decimal TotalPercentage { get; set; }

        [JsonProperty("totalFactor")]
        public decimal TotalFactor { get; set; }

        public Modifier(string modifierCode)
        {
            this.ModifierCode = modifierCode;
            ActionResults = new List<JObject>();
            TotalActionResultPercentage = 0;
            AdjustmentPercentage = null;
            AdjustmentJustification = null;
            TotalPercentage = 0;
            TotalFactor = 0;
        }

        public void Add(decimal UWJudgementFactor)
        {
            AdjustmentPercentage ??= 0;
            AdjustmentPercentage += UWJudgementFactor;
        }

    }
}
