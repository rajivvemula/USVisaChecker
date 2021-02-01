﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json.Linq;
using ApolloQA.Source.Helpers;
using ApolloQA.Data.Entity.Storyboard;
namespace ApolloQA.Data.Entity
{
    public class Quote
    {
        public readonly int Id;

        public Quote(int Id) {
            this.Id = Id;
        }
        public Quote(string property,  int value)
        {
            this.Id = (int)Cosmos.GetQuery("Application", $"SELECT * FROM c Where c.{property}={value} ORDER BY c._ts DESC OFFSET 0 LIMIT 1").Result[0]["Id"];

        }
        public Quote(string property, string value)
        {
            this.Id = (int)Cosmos.GetQuery("Application", $"SELECT * FROM c Where c.{property}='{value}' ORDER BY c._ts DESC OFFSET 0 LIMIT 1").Result[0]["Id"];

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
            return RestAPI.GET($"/quote/{this.Id}");
        }
        public dynamic GetProperty(String propertyName)
        {
            var property = this.GetProperties()[propertyName];
            return property == null ? "" : property;
        }

        //Policy caching for better performance
        private Policy _Policy = null;
        public Policy GetPolicy()
        {
            if(_Policy == null)
            {
                _Policy = new Policy((int)GetProperties().issuedPolicyId);
            }
            return _Policy;
        }
        public JArray getCoverages()
        {
           return this.GetPolicy().getCoverages();
        }
        public List<String> getCoverageCodes(Vehicle risk)
        {
            return this.GetPolicy().getCoverageCodes(risk);


        }
        public dynamic GetVehicleTypeRisk()
        {
            int riskTypeId = 1;

            return RestAPI.GET($"/quote/{this.Id}/risktype/{riskTypeId}");
        }
        public List<Vehicle> GetVehicles()
        {
            return ((JArray)GetVehicleTypeRisk().risks).Select(risk => risk).ToList<dynamic>().Select(risk => new Vehicle(risk.risk.id.ToObject<int>())).ToList<Vehicle>();
        }
        public dynamic GetDriverTypeRisk()
        {
            int riskTypeId = 2;

            return RestAPI.GET($"/quote/{this.Id}/risktype/{riskTypeId}");
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
                    Log.Critical(exception.ToString());
                    Log.Critical(exception.Message);
                    Log.Critical(exception.StackTrace);
                    throw new Exception($"error constructing Organization with the following params 1=PartyId 2={this.GetProperties()?.insuredPartyId?.Value?.ToString()}");
                }
            }
        }

        public Storyboard.Storyboard Storyboard
        {
            get
            {
                Log.Debug($"Get Storyboard for Quote ID: {this.Id}");
                int storyBoardId = Cosmos.GetQuery("Application", $"SELECT * FROM c WHERE c.Id = {this.Id}").Result[0]["StoryboardId"];
                return new Storyboard.Storyboard(storyBoardId);
            }
        }

        public string CoveredAutos
        {
            get
            {
                return this.GetPolicy().CoveredAutos;
            }
        }

        public String MotorCarrierFiling
        {
            get
            {
                return this.GetPolicy().MotorCarrierFiling;
            }
        }
        public Boolean AccidentPreventionCredit
        {
            get
            {
                return this.GetPolicy().AccidentPreventionCredit;
            }

        }
        public String BillingType
        {
            get
            {
                return this.GetPolicy().BillingType;
            }
        }
        public String PaymentPlan
        {
            get
            {
                return this.GetPolicy().PaymentPlan;
            }
        }
        public String isEft
        {
            get
            {
                return this.GetPolicy().isEft;
            }

        }
        public int? RadiusOfOperation
        {
            get
            {
                return this.GetPolicy().RadiusOfOperation;
            }
        }

    }
}
