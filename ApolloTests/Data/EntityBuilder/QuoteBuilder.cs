using ApolloTests.Data.Entities;
using ApolloTests.Data.Entity;
using ApolloTests.Data.EntityBuilder.Models;
using ApolloTests.Data.EntityBuilder.SectionBuilders.BP;
using ApolloTests.Data.EntityBuilder.SectionBuilders.CA;
using ApolloTests.Data.Rating;
using HitachiQA.Helpers;
using Newtonsoft.Json.Linq;

namespace ApolloTests.Data.EntityBuilder
{
    public class QuoteBuilder : BaseEntity
    {
        public Line Line { get; set; }
        public string State { get; set; } = "IL";
        public KeywordMappingUtil ClassCodeKeyword { get; set; }
        public DateTimeOffset EffectiveDate { get; set; } = DateTimeOffset.Now.AddDays(1);
        public DateTimeOffset ExpirationDate { get; set; } = DateTimeOffset.Now.AddDays(1).AddYears(1);

        public HydratorUtil Hydrator = new HydratorUtil();

        public Entity.Quote? QuoteEntity=null;

        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="state"></param>
        /// <param name="coverageTypes"></param>
        public QuoteBuilder(Line line, string state, List<CoverageType>? coverageTypes=null)
        {
            coverageTypes ??= new();
            this.State = state;
            this.Line = line;
            

            this.QuoteCreate = new();
            this.Vehicles = new(this);
            this.Drivers = new(this);
            
            this.PriorClaims= new(this);
            this.Locations= new(this);

            this.Operations = new(this);
            this.PolicyCoverages = new(this);
            this.Modifiers = new(this);
            this.PolicyAddlInterest = new(this);

            foreach (var cov in coverageTypes)
            {
                switch (line.LineEnum)
                {
                    case Lines.BusinessOwner:
                        throw new NotImplementedException($"{line.Name} Coverage assignment for BOP implemented");
                    //break;
                    case Lines.CommercialAuto:

                        PolicyCoverages.Add(cov);
                        switch (cov.Name)
                        {
                            case CoverageType.TRAILER_INTERCHANGE:
                                Vehicles[0].Vehicle.grossVehicleWeight = "30000";
                                break;

                            case CoverageType.IN_TOW:
                                ClassCodeKeyword ??= KeywordMappingUtil.GetUsingKeywordName(line, "Towing Services");
                                break;

                            case CoverageType.CARGO:
                                ClassCodeKeyword ??= KeywordMappingUtil.GetUsingKeywordName(line, "Towing Services");
                                break;

                            case CoverageType.RENTAL_REIMBURSEMENT:
                                Vehicles[0].AddCollision = true;
                                break;

                            default:
                                //this.ClassCodeKeyword ??= ClassCodeKeyword.GetUsingKeywordName("Accounting Services");
                                break;
                        }


                        break;
                }
            }

            ClassCodeKeyword ??= KeywordMappingUtil.GetUsingKeywordName(line, "Accounting Services");




        }


        public QuoteBuilder(Line line, string state, KeywordMappingUtil classCodeKeyword) : this(line, state, classCodeKeyword.coverage ?? new CoverageType("BIPD"))
        {
            State = state;
            ClassCodeKeyword = classCodeKeyword;
        }
        public QuoteBuilder(Line line, string state, string algorithmCode) : this(line, state, KeywordMappingUtil.GetUsingAlgorithmCode(line, algorithmCode, state)) { }

        public QuoteBuilder(Line line, string state, CoverageType coverageType) : this(line, state, new List<CoverageType>() { coverageType }) { }

        public QuoteCreate QuoteCreate;

        #region CA Builders
        public VehiclesBuilder Vehicles;
        public DriversBuilder Drivers;
        #endregion

        #region BOP Builders
        public PriorClaimsBuilder PriorClaims ;
        public LocationsBuilder Locations;
        #endregion

        public OperationsBuilder Operations;
        public PolicyCoveragesBuilder PolicyCoverages;
        public ModifiersBuilder Modifiers;
        public PolicyAddnlIntrestBuilder PolicyAddlInterest;
         

        public Entity.Quote CreateQuote()
        {
            //Builder.Hydrator.Interpreter.Reference(typeof(QuoteBuilder));
            //Builder.Hydrator.Interpreter.Reference(typeof(Limit));
            //Builder.Hydrator.Interpreter.Reference(typeof(Risk));
            //Builder.Hydrator.Interpreter.Reference(typeof(Risk));

            this.Hydrator.Interpreter.SetVariable("KeywordId", this.ClassCodeKeyword.KeywordId);
            switch(this.Line.LineEnum)
            {
                case Lines.CommercialAuto:
                    this.Hydrator.Interpreter.SetVariable("IndustryClassTaxonomyClassName", this.ClassCodeKeyword.TaxonomyName);
                    this.Hydrator.Interpreter.SetVariable("IndustryClassTaxonomyId", this.ClassCodeKeyword.IndustryClassTaxonomyId);
                    break;
                case Lines.BusinessOwner:
                    this.Hydrator.Interpreter.SetVariable("BuildingGroupId", (int)this.ClassCodeKeyword.BuildingGroup);
                    break;
                default: throw new NotImplementedException();
            }

           
            this.Hydrator.Interpreter.SetVariable("OrganizationName", $"Automation API org {DateTimeOffset.Now.ToUnixTimeMilliseconds()}");
            this.Hydrator.Interpreter.SetVariable("LineId", this.Line.Id);
            this.Hydrator.Interpreter.SetVariable("SubLineId", this.Line.Id);
            this.Hydrator.Interpreter.SetVariable("EffectiveDate", this.EffectiveDate);
            this.Hydrator.Interpreter.SetVariable("ExpirationDate", this.ExpirationDate);
            String jsonString = new StreamReader($"Data/EntityBuilder/Entities/CreateAddress/{this.State.ToUpper()}.json").ReadToEnd();
            var addressObj = JObject.Parse(jsonString);
            this.Hydrator.Interpreter.SetVariable("AddressObject", addressObj);

            this.Hydrator.Hydrate(this.QuoteCreate);
            dynamic response = RestAPI.POST("/quote/create", this.QuoteCreate) ?? throw new NullReferenceException();


            this.Hydrator.Interpreter.SetVariable("ApplicationId", response.id);
            this.Hydrator.Interpreter.SetVariable("QuoteId", response.id);
            this.Hydrator.Interpreter.SetVariable("StateCode", this.State);
            this.Hydrator.Interpreter.SetVariable("PhysicalAddressId", response["addressIds"][0]);
            this.Hydrator.Interpreter.SetVariable("GoverningStateId", response["governingStateId"]);

            var quote = new Quote((int)response.id);
            this.Hydrator.Interpreter.SetVariable("Quote", quote);
            this.Hydrator.Quote = quote;
            return quote;
        }




        /// <summary>
        /// Build this quoteBuilder as a quote in Apollo
        /// </summary>
        /// <param name="forceQuotedStatus">if true and quote is referred or declined it will refer to underwriting and generate proposal to get it to quoted</param>
        /// <returns></returns>
        public Quote Build(bool forceQuotedStatus=true)
        {
            this.QuoteEntity ??= CreateQuote();
            switch(Line.Id)
            {
                case (long)Lines.CommercialAuto:
                    RunAllSendStrategies_CA();

                    break;
                case (long)Lines.BusinessOwner:
                    RunAllSendStrategies_BOP();

                    break;
                default: throw new NotImplementedException();
            }

            var summary = this.QuoteEntity.PostSummary();

            summary.NullGuard();
            Log.Debug("Quote Id: " + QuoteEntity.Id);
            Log.Debug("Rating Group Id (rating worksheet): \n" + $"{Environment.GetEnvironmentVariable("HOST")}/rating/ratings-worksheet/" + (summary?["ratingGroupId"] ?? "null") + "\n");
            if (summary?["errors"]?.Count() > 0 || summary?["ratingResponses"] == null)
            {
                Log.Critical(summary);
                throw Functions.HandleFailure($"Premium generation was unsuccessful Quote: {QuoteEntity.Id} Premium: " + summary?["ratingResponses"]);
            }

            if (QuoteEntity["ApplicationStatusKey"] != 4000 && forceQuotedStatus)
            {
                QuoteEntity.ReferToUnderwriting();

                QuoteEntity.GenerateProposal();
            }

            return this.QuoteEntity;
        }

        private void RunAllSendStrategies_CA()
        {
            QuoteEntity.NullGuard();
            this.Vehicles.RunSendStrategy(QuoteEntity);
            this.Drivers.RunSendStrategy(QuoteEntity);
            this.Operations.RunSendStrategy(QuoteEntity);
            this.PolicyCoverages.RunSendStrategy(QuoteEntity);
            this.Modifiers.RunSendStrategy(QuoteEntity);
            this.PolicyAddlInterest.RunSendStrategy(QuoteEntity);
        }

        private void RunAllSendStrategies_BOP()
        {
            QuoteEntity.NullGuard();
            this.PriorClaims.RunSendStrategy(QuoteEntity);
            this.Locations.RunSendStrategy(QuoteEntity);
            this.Operations.RunSendStrategy(QuoteEntity);
            this.PolicyCoverages.RunSendStrategy(QuoteEntity);
            this.Modifiers.RunSendStrategy(QuoteEntity);
            this.PolicyAddlInterest.RunSendStrategy(QuoteEntity);
        }

    }


    public enum Section
    {
        Vehicles,
        Drivers,
        Operations,
        PolicyCoverages,
        Modifiers,
        PolicyAddlInterest,
        Contacts,

        PriorClaims,
        Locations,

    }
}
