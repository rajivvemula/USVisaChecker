using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ApolloTests.Data.EntityBuilder.Models.Risks;

namespace ApolloTests.Data.EntityBuilder.Entities
{
    public class Driver : IRiskEntity, IEntityBase
    {

        [JsonIgnore]
        public RiskType RiskType => RiskType.Driver;

        [JsonIgnore]
        Risk? IRiskEntity.Risk { get; set; }

        public Driver(Risk risk)
        {
            ((IRiskEntity)this).SetRisk(risk);
        }
        public Driver() { }

        public Person person { get; set; } = new Person();

        public DateTime dateOfBirth { get; set; } = new DateTime(1965, 10, 26, 04, 00, 00);

        [HydratorAttr("GoverningStateId")]
        public long? stateProvinceId { get; set; }

        public StateProvince stateProvince { get; set; } = new StateProvince();

        [HydratorAttr("LicenseNumber")]
        public string licenseNo { get; set; } = string.Empty;

        public int statusId { get; set; } = 0;


        public class PrimaryName
        {
            public string given { get; set; } = "Miguel";

            public string middle { get; set; } = string.Empty;

            public string surName { get; set; } = "Acosta";

            public string suffix { get; set; } = string.Empty;
        }

        public class Person
        {
            public PrimaryName primaryName { get; set; } = new PrimaryName();
        }

        public class StateProvince
        {
            [HydratorAttr("StateCode")]
            public string? code { get; set; } 
        }

       

    }


}
