using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ApolloQA.Data.Entity;
using DynamicExpresso;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ApolloQA.Source.Helpers;
namespace ApolloQA.Data.TestData
{
    public class Organization
    {
        public static Entity.Organization CreateOrganization()
        {
            var body = Tools.GetObject("OrgCreate");
            var response  = RestAPI.POST("apollo/organization", body);
            Tools.interpreter.SetVariable("OrganizationId", response.id);
            Tools.interpreter.SetVariable("OrganizationPartyId", response.partyId);

            return new Entity.Organization((int)response.id);
        }
        public static Entity.Address OrganizationAddAddress(Entity.Organization org)
        {
            var body = Tools.GetObject("OrgAddAddress");
            var response = RestAPI.POST("address/900/"+org.PartyId, body);
            Tools.interpreter.SetVariable("PhysicalAddressId", response.id);
            return new Address((int)response.id);
        }




    }
}

