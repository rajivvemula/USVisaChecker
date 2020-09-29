﻿using System;
using System.Collections.Generic;
using System.Text;
using ApolloQA.Driver;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace ApolloQA.DataFiles.Entity
{
    class Policy
    {
        private readonly int Id;

        public Policy(int Id)
        {
            this.Id = Id;

        }
        public dynamic this[String propertyName]
        {
            get {

                
                var method = this.GetType().GetProperty(propertyName);
                if (method != null)
                {
                    return method.GetGetMethod().Invoke(this,null);

                }
                else
                {
                    return GetProperty(propertyName);
                }
            }
        }

        public dynamic GetProperties()
        {
            return Setup.api.GET($"/policy/{Id}");
        }
        public dynamic GetProperty(String propertyName)
        {
            var property = this.GetProperties()[propertyName];
            return property == null ? "" : property;
        }

        public List<dynamic> GetCoverages()
        {
            return ((JArray)this.GetProperties().coverages).Select(coverage => coverage).ToList<dynamic>();
        }
        public List<String> GetCoverageCodes()
        {
            return GetCoverages().Select(coverage => (String)coverage["associatedCoverage"]["coverageCode"]).ToList<String>();


        }
        public Application GetApplication()
        {
            return new Application(GetProperties()["applicationId"].ToObject<int>());
        }

        public Organization Organization{ get
            {
                try
                {
                    return new Organization("PartyId", this.GetProperties().insuredPartyId.Value.ToString());
                }
                catch(Exception e)
                {
                    throw new Exception($"error constructing Organization with the following params 1=PartyId 2={this.GetProperties()?.insuredPartyId?.Value?.ToString()}");
                }
            }
        }
    }
}
