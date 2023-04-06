using ApolloTests.Data.EntityBuilder.Models.Risks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApolloTests.Data.EntityBuilder.SectionBuilders
{
    public interface IRiskBuilder : IBuilder
    {

        [JsonIgnore]
        public uint NumberOfRisks { get; set; }

        public void AddOne();

        public void RemoveAt(int index);

        public static readonly Dictionary<Section, RiskType> DefaultSectionRisk = new()
        {
            { Section.Vehicles, RiskType.Vehicle},
            { Section.Drivers, RiskType.Driver}

        };
    }
}
