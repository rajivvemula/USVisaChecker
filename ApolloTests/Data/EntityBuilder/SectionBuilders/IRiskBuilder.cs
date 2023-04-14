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
        /// <summary>
        /// Implementation:
        /// <code>
        ///public uint NumberOfRisks
        ///{
        ///    get => (uint) Count;
        ///    set => this.SetNumberOfRisks(value);
        ///}
        /// </code>
        /// </summary>
        [JsonIgnore]
        public uint NumberOfRisks { get; set; }

        /// <summary>
        /// Implementation:
        /// <code>
        /// public void AddOne() => Add(new VehicleRisk());
        /// </code>
        /// </summary>
        public void AddOne();


        /// <summary>
        /// Implementation (optional, this is for special cases like BOP.Locationbuilder):
        /// <code>
        ///  public void RemoveAt(int index) => this.Last().Value.RemoveAt(index);
        /// </code>
        /// </summary>
        public void RemoveAt(int index);
    }
}
