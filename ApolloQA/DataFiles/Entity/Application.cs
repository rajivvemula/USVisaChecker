using System;
using System.Collections.Generic;
using System.Text;
using ApolloQA.Driver;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace ApolloQA.DataFiles.Entity
{
    class Application
    {
        private readonly int Id;

        public Application(int Id) {
            this.Id = Id;
        }
        public dynamic GetProperties()
        {
            return Setup.api.GET($"/application/{this.Id}");
        }
        public dynamic GetVehicleTypeRisk()
        {
            int riskTypeId = 1;

            return Setup.api.GET($"/application/{this.Id}/risktype/{riskTypeId}");
        }
        public List<Vehicle> GetVehicles()
        {
            return ((JArray)GetVehicleTypeRisk().risks).Select(risk => risk).ToList<dynamic>().Select(risk => new Vehicle(risk.risk.id.ToObject<int>())).ToList<Vehicle>();
        }
        public dynamic GetDriverTypeRisk()
        {
            int riskTypeId = 2;

            return Setup.api.GET($"/application/{this.Id}/risktype/{riskTypeId}");
        }
    }
}
