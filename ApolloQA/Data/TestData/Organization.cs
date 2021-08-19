using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ApolloQA.Data.Entity;
using DynamicExpresso;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ApolloQA.Source.Helpers;
using ApolloQA.Data.Rating;
using System.Threading;

namespace ApolloQA.Data.TestData
{
    public class Organization
    {
        public Entity.Organization organization;
        public Parser parser;
        public List<Address> addresses = new List<Address>();
        public ClassCodeKeyword classCodeKeyword;

        public Organization(Entity.Organization org)
        {
            organization = org;
            this.classCodeKeyword = organization.ClassCodeKeyword;
            parser = new Parser();
            hydrateTool();
        }
        public Organization(Entity.Organization org, Parser parser)
        {
            organization = org;
            this.classCodeKeyword = organization.ClassCodeKeyword;
            this.parser = parser;
            hydrateTool();

        }
        public Organization(ClassCodeKeyword classCodeKeyword)
        {
            parser = new Parser();
            this.classCodeKeyword = classCodeKeyword;
            this.CreateOrganization();

        }
        public Organization()
        {
            parser = new Parser();
            this.CreateOrganization();
        }
        public Organization(Parser parser)
        {
            this.parser = parser;
            this.CreateOrganization();
        }


        public Entity.Organization CreateOrganization()
        {
            
            parser.interpreter.SetVariable("KeywordId", this.classCodeKeyword.KeywordId);
            parser.interpreter.SetVariable("IndustryClassTaxonomy", this.classCodeKeyword.TaxonomyName);
            parser.interpreter.SetVariable("IndustryClassTaxonomyId", this.classCodeKeyword.IndustryClassTaxonomyId);

            //see Entity.Organization.GetNextValidName to learn more about mutex
            parser.interpreter.SetVariable("OrganizationName", Entity.Organization.GetNextValidName("Automation API org", out Mutex mutex));

            Log.Debug("Keyword: "+this.classCodeKeyword.KeywordName);
            var body = parser.GetObject("OrgCreate");
            var response  = RestAPI.POST("apollo/organization", body);

            mutex.ReleaseMutex();


            this.organization= new Entity.Organization((int)response.id);
            this.classCodeKeyword = organization.ClassCodeKeyword;
            hydrateTool();
            return organization;
        }
        public void OrganizationAddAddress(string state = "IL")
        {
            var body = parser.GetObject($"OrgCreateAddress/{state.ToUpper()}");
            var response = RestAPI.POST("address/900/"+organization.PartyId, body);

            addresses.Add(new Address((int)response.id));
        }
        private void hydrateTool()
        {
            parser.interpreter.SetVariable("OrganizationId", organization.Id);
            parser.interpreter.SetVariable("OrganizationPartyId", organization.PartyId);
            parser.interpreter.SetVariable("KeywordId", this.classCodeKeyword.KeywordId);
            parser.interpreter.SetVariable("IndustryClassTaxonomy", this.classCodeKeyword.TaxonomyName);
            parser.interpreter.SetVariable("IndustryClassTaxonomyId", this.classCodeKeyword.IndustryClassTaxonomyId);

        }

    }
}

