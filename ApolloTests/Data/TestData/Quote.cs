using ApolloTests.Data.Entities;
using ApolloTests.Data.TestData;
using ApolloTests.Data.TestData.Params;
using Gherkin;
using HitachiQA.Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ApolloTests.Data.TestData
{
    /// <summary>
    /// Quote API Manager
    /// </summary>
    public class Quote : BaseEntity
    {
        public Entity.Quote quoteEntity;

        public Parser _parser;

        public QuoteParam QuoteParam { get; set; }

        public Quote(QuoteParam quoteParam)
        {
            QuoteParam = quoteParam;
            _parser = new Parser();
            CreateQuote(QuoteParam.State);
        }

        public Quote(int quoteId)
        {
            _parser = new Parser();
            quoteEntity = new Entity.Quote(quoteId);
            QuoteParam.Organization = new Organization(quoteEntity.Organization, _parser);
        }

        public Quote(Organization organization, List<Entity.CoverageType> coverageTypes) : this(organization, "IL", coverageTypes)
        {
        }

        public Quote(Organization organization, string state, List<Entity.CoverageType> coverageTypes)
        {
            QuoteParam.Organization = organization;
            _parser = organization.parser;
            QuoteParam.LimitParam.Limits.AddRange(coverageTypes.Select(it => new LimitParam(it)));
            QuoteParam.State = state;
            CreateQuote(state);
        }

        public Quote(Organization organization, string state)
        {
            QuoteParam.Organization = organization;
            _parser = organization.parser;
            QuoteParam.State = state;
            CreateQuote(state);
        }

        public Entity.Quote GetQuotedQuoteThroughAPI()
        {
            AddVehicleToQuote();
            AddVehicleCoverage();

            AddDriverToQuote();

            AnswerOperationQuestions();

            AddPolicyCoverages();

            AddModifiers();

            var summary = PostSummary();

            Log.Debug("Quote Id: " + quoteEntity.Id);
            Log.Debug("Rating Group Id (rating worksheet): \n" + $"{Environment.GetEnvironmentVariable("HOST")}/rating/ratings-worksheet/" + (summary?["ratingGroupId"] ?? "null") + "\n");
            if (summary["errors"].Count() > 0 || summary?["ratingResponses"] == null)
            {
                Log.Critical(summary);
                throw Functions.handleFailure($"Premium generation was unsuccessful Quote: {quoteEntity.Id} Premium: " + summary?["ratingResponses"]);
            }

            if (quoteEntity["ApplicationStatusKey"] != 4000)
            {
                quoteEntity.ReferToUnderwriting();

                quoteEntity.GenerateProposal();
            }

            return quoteEntity;
        }

        private JObject CreateQuote(string state = "IL")
        {
            Mutex? mutex = null;
            dynamic response;
            try
            {
                _parser.interpreter.SetVariable("KeywordId", QuoteParam.ClassCodeKeyword.KeywordId);
                _parser.interpreter.SetVariable("IndustryClassTaxonomyClassName", QuoteParam.ClassCodeKeyword.TaxonomyName);
                _parser.interpreter.SetVariable("IndustryClassTaxonomyId", QuoteParam.ClassCodeKeyword.IndustryClassTaxonomyId);
                _parser.interpreter.SetVariable("OrganizationName", Entity.Organization.GetNextValidName("Automation API org", out mutex));


                _parser.interpreter.SetVariable("EffectiveDate", QuoteParam.RatableObjectEffectiveDate.ToString("O"));
                _parser.interpreter.SetVariable("ExpirationDate", QuoteParam.RatableObjectExpirationDate.ToString("O"));
                _parser.interpreter.SetVariable("AddressObject", _parser.GetObject($"OrgCreateAddress/{state.ToUpper()}"));

                var body = _parser.GetObject("QuoteCreate");
                response = RestAPI.POST("/quote/create", body);
            }
            finally{ mutex?.ReleaseMutex(); }

            _parser.interpreter.SetVariable("ApplicationId", response.id);
            _parser.interpreter.SetVariable("QuoteId", response.id);
            _parser.interpreter.SetVariable("StateCode", state);
            _parser.interpreter.SetVariable("PhysicalAddressId", response["addressIds"][0]);
            _parser.interpreter.SetVariable("GoverningStateId", response["governingStateId"]);

            quoteEntity = new Entity.Quote((int)response.id);
            _parser.interpreter.SetVariable("Quote", quoteEntity);

            return response;
        }

        [Obsolete("We no longer create a risks in the organization level, AddVehicleToQuote replaces this")]
        public List<Entity.Vehicle> CreateVehicles()
        {
            var vehiclesToReturn = new List<Entity.Vehicle>();

            for (int i = 0; i < Math.Max(QuoteParam.VehicleParam.NumberOfVehicles, QuoteParam.VehicleParam.Vehicles.Count); i++)
            {
                _parser.interpreter.SetVariable("VinNumber", Functions.GetRandomVIN());
                _parser.interpreter.SetVariable("ClassCode", QuoteParam.Organization.classCodeKeyword.ClassCode);

                var vehicleParam = QuoteParam.VehicleParam.Vehicles.ElementAtOrDefault(i);

                if (vehicleParam == null)
                {
                    //means NumberOfVehicles is greater than VehicleParam list count
                    //thus create and add new vehicle to VehicleParam
                    throw new NotImplementedException();
                }

                var body = _parser.Hydrate<VehicleParam.RiskObject.VehicleObject>(vehicleParam.Object);

                var response = RestAPI.POST("/vehicle", body);

                ((JObject)response).Add("classCode", QuoteParam.Organization.classCodeKeyword.ClassCode);

                QuoteParam.VehicleParam.Vehicles[i].LoadJObject(response);

                vehiclesToReturn.Add(new Entity.Vehicle((string)response.id));
            }

            return vehiclesToReturn;
        }

        public dynamic AddVehicleToQuote()
        {
            var body = new List<VehicleParam.RiskObject>();

            _parser.interpreter.SetVariable("ClassCode", this.QuoteParam.ClassCodeKeyword.ClassCode);

            foreach (var vehicle in QuoteParam.VehicleParam.Vehicles)
            {
                _parser.interpreter.SetVariable("VinNumber", Functions.GetRandomVIN());
                var vehicleRiskBody = _parser.Hydrate<VehicleParam.RiskObject>(vehicle.Risk);
                
                var parkingAddress = this.quoteEntity.PrimaryAddress;
                vehicle.VehicleQuentionAnswerParam.DefaultVehicleClassCode._response = this.QuoteParam.ClassCodeKeyword.ClassCode;
                vehicle.VehicleQuentionAnswerParam.VehicleParkingAddrsIn._response = parkingAddress.StateCode;
                vehicle.VehicleQuentionAnswerParam.TrailerParkingAddrsIn._response = parkingAddress.StateCode;


                vehicle.NullGuard();
                var hydratedAnswers = AnswersHydrator.Vehicles(
                        quoteEntity,
                        vehicle.Object.ToJObject(),
                        vehicle.VehicleQuentionAnswerParam
                        ).ToObject<List<VehicleParam.RiskObject.QuestionRespons>>();
                hydratedAnswers.NullGuard();
                vehicleRiskBody.outputMetadata.QuestionResponses = hydratedAnswers;

                body.Add(vehicleRiskBody);
            }

            var response = RestAPI.POST($"quote/{quoteEntity.Id}/risk", body);

            for (int i = 0; i<response.Count; i++)
            {
                var riskResponse = response[i];
                QuoteParam.VehicleParam.Vehicles[i].LoadJObject(riskResponse["vehicle"]);
            }

            return response;
        }

        public dynamic AddVehicleToQuote(JObject vehicle)
        {
            QuoteParam.VehicleParam.Add(vehicle);
            return AddVehicleToQuote();
        }

        public dynamic AddVehicleCoverage()
        {
            return AddVehicleCoverage(QuoteParam.VehicleParam.Vehicles);
        }

        public dynamic AddVehicleCoverage(List<VehicleParam> vehicles)
        {
            var vehiclesCoverage = new List<dynamic>();
            foreach (var vehicle in vehicles)
            {
                var body = new JArray();
                vehicle.LimitParams.AddRange(QuoteParam.LimitParam.Limits);

                foreach (var limit in vehicle.LimitParams)
                {
                    if (limit.CoverageType.isVehicleLevel && body.FirstOrDefault(it=> it["coverageTypeId"].ToObject<long>() == limit.CoverageType.Id) == null)
                    {
                        //this.parser.interpreter.SetVariable("CoverageTypeId", limit.CoverageType.Id);

                        body.Add(JObject.FromObject(limit.Object));
                    }
                }

                var response = RestAPI.POST($"quote/{quoteEntity.Id}/risk/{vehicle.Object.riskId}/limits", body);

                vehiclesCoverage.Add(response);
            }

            return vehiclesCoverage;
        }

        [Obsolete("We no longer create a risks in the organization level, AddDriverToQuote replaces this")]
        public List<Entity.Driver> CreateDrivers()
        {
            var driversToReturn = new List<Entity.Driver>();

            for (int i = 0; i < Math.Max(QuoteParam.DriverParam.NumberOfDrivers, QuoteParam.DriverParam.Drivers.Count); i++)
            {
                _parser.interpreter.SetVariable("LicenseNumber", Functions.GetValidDriverLicense(QuoteParam.State));

                var driverParam = QuoteParam.DriverParam.Drivers.ElementAtOrDefault(i);

                if (driverParam == null)
                {
                    // means NumberOfDrivers is greater than DriverParam list count
                    // thus create and add new driver to DriverParam
                    throw new NotImplementedException();
                }

                var body = _parser.Hydrate<DriverParam.RiskObject.DriverObject>(driverParam.Object);

                var response = RestAPI.POST("/driver", body);

                _parser.interpreter.SetVariable("DriverRiskId", response.riskId);

                QuoteParam.DriverParam.Drivers[i].LoadJObject(response);

                driversToReturn.Add(new Entity.Driver((int)response.id));
            }

            return driversToReturn;
        }

        public dynamic AddDriverToQuote()
        {
            var body = new List<DriverParam.RiskObject>();

            foreach (var driver in QuoteParam.DriverParam.Drivers)
            {
                _parser.interpreter.SetVariable("LicenseNumber", Functions.GetValidDriverLicense(QuoteParam.State));

                var driverRiskBody = _parser.Hydrate<DriverParam.RiskObject>(driver.Risk);

                var hydratedAnswers = AnswersHydrator.Drivers(
                        quoteEntity,
                        driver.Object.ToJObject(),
                        driver.DriverQuentionAnswerParam
                        ).ToObject<List<DriverParam.RiskObject.QuestionRespons>>();
                hydratedAnswers.NullGuard();
                driverRiskBody.outputMetadata.QuestionResponses = hydratedAnswers;
                   

                body.Add(driverRiskBody);
            }

            var response = RestAPI.POST($"quote/{quoteEntity.Id}/risk", body);
            for (int i = 0; i < response.Count; i++)
            {
                var riskResponse = response[i];
                QuoteParam.VehicleParam.Vehicles[i].LoadJObject(riskResponse["driver"]);
            }

            return response;
        }

        public dynamic AddDriverToQuote(JObject driver)
        {
            QuoteParam.DriverParam.Add(driver);
            return AddDriverToQuote();
        }

        public JObject AnswerOperationQuestions()
        {
            var body = AnswersHydrator.Operations(quoteEntity, QuoteParam.QuoteQuentionAnswerParam);

            var response = RestAPI.POST($"quote/{quoteEntity.Id}/sections/{quoteEntity.Storyboard.GetSection("Operations").Id}/answers", body);

            return response;
        }

        public JObject AddPolicyCoverages()
        {
            var body = new JArray();
            foreach (var limit in QuoteParam.LimitParam.Limits)
            {
                if (!limit.CoverageType.isVehicleLevel)
                {
                    limit.Object.questionResponses
                        = AnswersHydrator.PolicyCoverages(quoteEntity, limit.ToJObject(), limit.PolicyCoverageQuestionAnswerParam);

                    body.Add(JObject.FromObject(limit.Object));
                }
            }

            var response = RestAPI.POST($"quote/{quoteEntity.Id}/limits", body);

            return response;
        }

        public JObject AddModifiers()
        {
            var body = _parser.Hydrate<ModifierParam.ModifierObject>(QuoteParam.ModifierParam.Modifiers.Object);

            var response = RestAPI.PATCH($"/quote/{quoteEntity.Id}", body);

            return response;
        }

        public JObject PostSummary()
        {
            return quoteEntity.PostSummary();
        }
    }
}