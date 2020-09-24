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

        public dynamic getProperties()
        {
            return Setup.api.GET($"/policy/{Id}");
        }

        public List<dynamic> getCoverages()
        {
            return ((JArray)this.getProperties().coverages).Select(coverage => coverage ).ToList<dynamic>();
        }
        public List<String> getCoverageCodes()
        {
            return getCoverages().Select( coverage => (String)coverage["associatedCoverage"]["coverageCode"]  ).ToList<String>();


        }
        public Application getApplication()
        {
            return new Application(getProperties()["applicationId"]);
        }
        public Organization getOrganization()
        {
            return new Organization("PartyId", getProperties().insurredPartyId.ToString());
        }
    }
}
