using ApolloTests.Data.EntityBuilder.Models;
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
        public List<Risk> Self { get; }
        [JsonIgnore]
        public uint NumberOfRisks
        {
            get
            {
                return (uint)Self.Count;
            }
            set
            {
                if (NumberOfRisks > value)
                {
                    while (Self.Count != value)
                    {
                        Self.RemoveAt(Self.Count - 1);
                    }
                }
                else
                {

                    while (NumberOfRisks != value)
                    {
                        var riskType = DefaultSectionRisk[Section];
                        Self.Add(new Risk(riskType));
                    }
                }
            }
        }


        private static readonly Dictionary<Section, RiskType> DefaultSectionRisk = new()
        {
            { Section.Vehicles, RiskType.Vehicle},
            { Section.Drivers, RiskType.Driver}

        };
    }
}
