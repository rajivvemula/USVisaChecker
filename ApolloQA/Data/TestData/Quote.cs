using ApolloQA.Source.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApolloQA.Data.TestData
{
    class Quote
    {
        public static Entity.Quote CreateQuote()
        {
            var body = Tools.GetObject("QuoteCreate");
            var response = RestAPI.POST("/quote/create", body);

            Tools.interpreter.SetVariable("ApplicationId", response.id);
            Tools.interpreter.SetVariable("QuoteId", response.id);

            Tools.interpreter.SetVariable("VehicleSectionId", ((JArray)response.sections).FirstOrDefault(it=> (String)((JObject)it)["sectionName"]== "Vehicles")["id"]);
            Tools.interpreter.SetVariable("DriverSectionId", ((JArray)response.sections).FirstOrDefault(it => (String)((JObject)it)["sectionName"] == "Drivers")["id"]);

            var body2 = Tools.GetObject("QuoteCreatePhysicalAddress");
            var response2 = RestAPI.PATCH($"/quote/{response.id}", body2);

            return new Entity.Quote((int)response.id);
        }
        public static Entity.Vehicle CreateVehicle()
        {
            var body = Tools.GetObject("Quote_CreateVehicle");
            var response = RestAPI.POST("/vehicle", body);
            Tools.interpreter.SetVariable("VehicleRiskId", response.riskId);

            return new Entity.Vehicle((int)response.id);
        }
        public static dynamic AddVehicleToQuote(Entity.Quote quote)
        {
            var body = Tools.GetObject("Quote_AddVehicle");
            
            var response = RestAPI.POST($"quote/{quote.Id}/risk", body);

            return response;
        }

        public static JObject CreateDriver()
        {
            var body = Tools.GetObject("Quote_CreateDriver");
            var response = RestAPI.POST("/driver", body);
            Tools.interpreter.SetVariable("DriverRiskId", response.riskId);

            return response;
        }
        public static dynamic AddDriverToQuote(Entity.Quote quote)
        {
            var body = Tools.GetObject("Quote_AddDriver");
            var response = RestAPI.POST($"quote/{quote.Id}/risk", body);

            return response;
        }
        public static JObject AnswerOperationQuestions(Entity.Quote quote)
        {
            var body = Tools.GetObject("Quote_Operations");
            var response = RestAPI.POST($"quote/{quote.Id}/sections/{quote.Storyboard.Sections.Find(it=>it.Name=="Operations").Id}/answers", body);

            return response;
        }
        public static JObject AddPolicyCoverages(Entity.Quote quote)
        {
            var body = Tools.GetObject("Quote_Coverages");
            var response = RestAPI.POST($"quote/{quote.Id}/limits", body);

            return response;
        }

        public static JObject GetSummary(Entity.Quote quote)
        {
            var response = RestAPI.POST($"quote/{quote.Id}/summary", "");
            return response;
        }
    }
}
