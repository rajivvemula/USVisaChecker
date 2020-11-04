using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json.Linq;
using ApolloQA.Source.Helpers;

namespace ApolloQA.Data.Entity
{
    public class Quote
    {
        public readonly int Id;

        public Quote(int Id) {
            this.Id = Id;
        }
        public dynamic this[String propertyName]
        {
            get
            {


                var method = this.GetType().GetProperty(propertyName);
                if (method != null)
                {
                    return method.GetGetMethod().Invoke(this, null);

                }
                else
                {
                    return GetProperty(propertyName);
                }
            }
        }
        public static Quote GetLatestQuote()
        {
            return new Quote((int)Cosmos.GetQuery("Application", "SELECT * FROM c ORDER BY c._ts DESC OFFSET 0 LIMIT 1").Result[0]["Id"]);
        }
        public dynamic GetProperties()
        {
            return RestAPI.GET($"/application/{this.Id}");
        }
        public dynamic GetProperty(String propertyName)
        {
            var property = this.GetProperties()[propertyName];
            return property == null ? "" : property;
        }

        public dynamic GetVehicleTypeRisk()
        {
            int riskTypeId = 1;

            return RestAPI.GET($"/application/{this.Id}/risktype/{riskTypeId}");
        }
        public List<Vehicle> GetVehicles()
        {
            return ((JArray)GetVehicleTypeRisk().risks).Select(risk => risk).ToList<dynamic>().Select(risk => new Vehicle(risk.risk.id.ToObject<int>())).ToList<Vehicle>();
        }
        public dynamic GetDriverTypeRisk()
        {
            int riskTypeId = 2;

            return RestAPI.GET($"/application/{this.Id}/risktype/{riskTypeId}");
        }
        public Organization Organization
        {

            get
            {
                try
                {
                    return new Organization("PartyId", this.GetProperties().insuredPartyId.Value.ToString());
                }
                catch (Exception exception)
                {
                    throw new Exception($"error constructing Organization with the following params 1=PartyId 2={this.GetProperties()?.insuredPartyId?.Value?.ToString()}");
                }
            }
        }

    }
}
