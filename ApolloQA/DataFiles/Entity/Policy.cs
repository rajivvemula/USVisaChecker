using System;
using System.Collections.Generic;
using System.Text;
using ApolloQA.Driver;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace ApolloQA.DataFiles.Entity
{
    class Policy
    {
        private readonly int Id;

        public Policy(int Id)
        {
            this.Id = Id;

        }

        public dynamic GetProperties()
        {
            return Setup.api.GET($"/policy/{Id}");
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
        public Organization getOrganization()
        {
            return new Organization("PartyId", GetProperties().insurredPartyId.ToString());
        }
    }
}
