using ApolloQA.Data.Rating;
using ApolloQA.Source.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApolloQA.Data.TestData
{

    //Quote API Manager
    public class Quote
    {
        public Entity.Quote quoteEntity;

        Organization organization;
        Parser parser;

        List<JObject> vehicles = new List<JObject>();
        List<JObject> drivers = new List<JObject>();

        string state;

        List<Entity.CoverageType> coverages;
        public Quote(int quoteId)
        {
            parser = new Parser();
            quoteEntity = new Entity.Quote(quoteId);
            organization = new Organization(quoteEntity.Organization, parser);

        }
        public Quote(Organization organization, List<Entity.CoverageType> coverageTypes) : this(organization, "IL", coverageTypes) { }

        public Quote(Organization organization, string state, List<Entity.CoverageType> coverageTypes)
        {
            this.organization = organization;
            this.parser = organization.parser;
            this.coverages = coverageTypes;
            this.state = state;
            CreateQuote(state);
        }
        public Quote(Organization organization, string state)
        {
            this.organization = organization;
            this.parser = organization.parser;
            this.state = state;
            CreateQuote(state);
        }

        private JObject CreateQuote(string state="IL")
        {
            parser.interpreter.SetVariable("TomorrowDate", DateTime.Now.AddDays(30).ToString("O"));
            parser.interpreter.SetVariable("YearLaterDate", DateTime.Now.AddDays(30).AddYears(1).ToString("O"));

            var body = parser.GetObject("QuoteCreate");
            var response = RestAPI.POST("/quote/create", body);

            parser.interpreter.SetVariable("ApplicationId", response.id);
            parser.interpreter.SetVariable("QuoteId", response.id);
            parser.interpreter.SetVariable("StateCode", state);


            this.quoteEntity = new Entity.Quote((int)response.id);

            if(quoteEntity.Organization.Addresses is var orgAddresses && 
                orgAddresses.Count>0 &&
                orgAddresses.Find(it => it.StateCode == state.ToUpper()) is var address && 
                address!= null)
            {
                parser.interpreter.SetVariable("PhysicalAddressId", address.Id);
                parser.interpreter.SetVariable("GoverningStateId", address.StateId);

            }
            else
            {
                organization.OrganizationAddAddress(state);
                parser.interpreter.SetVariable("PhysicalAddressId", organization.addresses[0].Id);
                parser.interpreter.SetVariable("GoverningStateId", organization.addresses[0].StateId);

            }
            var body2 = parser.GetObject("QuoteCreatePhysicalAddress");
  
            var response2 = RestAPI.PATCH($"/quote/{response.id}", body2);
           
            parser.interpreter.SetVariable("PhysicalAddressId", organization.addresses[0].Id);

            return response2;
        }
        public Entity.Vehicle CreateVehicle()
        {
            parser.interpreter.SetVariable("VinNumber", Functions.GetRandomVIN());
            parser.interpreter.SetVariable("ClassCode", organization.classCodeKeyword.ClassCode);

            //Log.Debug("class code: " + organization.classCodeKeyword.ClassCode);


            var body = parser.GetObject("Quote_CreateVehicle");

            //Log.Debug("create: " + body);

            var response = RestAPI.POST("/vehicle", body);
            parser.interpreter.SetVariable("VehicleRiskId", response.riskId);
            vehicles.Add(response);
            return new Entity.Vehicle((int)response.id);
        }
        public dynamic AddVehicleToQuote()
        {
            if(vehicles.Count<1)
            {
                CreateVehicle();
            }

            var body = parser.GetObject("Quote_AddVehicle");

            ((JObject)((JArray)body)[0]["outputMetadata"]).Add("QuestionResponses", AnswersHydrator.Vehicles(quoteEntity, vehicles[0]));

            //Log.Info("add vehicle to quote: " + body);

            var response = RestAPI.POST($"quote/{quoteEntity.Id}/risk", body);

            return response;
        }

        public dynamic AddVehicleToQuote(JObject vehicle)
        {
            vehicles.Add(vehicle);
            return AddVehicleToQuote();
        }
        public dynamic AddVehicleCoverage()
        {
            return AddVehicleCoverage(vehicles[0]);
        }
        public dynamic AddVehicleCoverage(JObject vehicle)
        {
            var body = new JArray();
            foreach (var coverage in coverages)
            {
                if (coverage.isVehicleLevel)
                {
                    parser.interpreter.SetVariable("CoverageTypeId", coverage.Id);
                    body.Merge(parser.GetObject($"Quote_Coverages/{coverage.Name}"));
                }
            }

            var response = RestAPI.POST($"quote/{quoteEntity.Id}/risk/{vehicle["riskId"]}/limits", body);

            return response;
        }

        public JObject CreateDriver()
        {
            parser.interpreter.SetVariable("LicenseNumber", Functions.GetValidDriverLicense(state));
            var body = parser.GetObject("Quote_CreateDriver");
            var response = RestAPI.POST("/driver", body);
            parser.interpreter.SetVariable("DriverRiskId", response.riskId);
            drivers.Add(response);
            return response;
        }
        public dynamic AddDriverToQuote()
        {
            if (drivers.Count < 1)
            {
                CreateDriver();
            }

            var body = parser.GetObject("Quote_AddDriver");

            ((JObject)((JArray)body)[0]["outputMetadata"]).Add("QuestionResponses", AnswersHydrator.Drivers(quoteEntity, drivers[0]));

            var response = RestAPI.POST($"quote/{quoteEntity.Id}/risk", body);

            return response;
        }
        public dynamic AddDriverToQuote(JObject driver)
        {
            drivers.Add(driver);
            return AddDriverToQuote();
        }
        public JObject AnswerOperationQuestions()
        {
            var body = AnswersHydrator.Operations(quoteEntity);
            //Log.Info($"operations Body: {body}");
            var response = RestAPI.POST($"quote/{quoteEntity.Id}/sections/{quoteEntity.Storyboard.GetSection("Operations").Id}/answers", body);

            return response;
        }
        public JObject AddPolicyCoverages()
        {
            var body = new JArray();
            foreach (var coverage in coverages)
            {
                if(!coverage.isVehicleLevel)
                {
                    parser.interpreter.SetVariable("CoverageTypeId", coverage.Id);
                    body.Merge(parser.GetObject($"Quote_Coverages/{coverage.Name}"));
                }
            }
            //Log.Debug("coverage: "+body);
            var response = RestAPI.POST($"quote/{quoteEntity.Id}/limits", body);

            return response;
        }

        public JObject PostSummary()
        {
            return quoteEntity.PostSummary();
        }
    }
}
