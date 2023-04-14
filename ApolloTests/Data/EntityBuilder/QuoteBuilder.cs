using ApolloTests.Data.Entities;
using ApolloTests.Data.Entity;
using ApolloTests.Data.EntityBuilder.Models;
using ApolloTests.Data.EntityBuilder.SectionBuilders;
using ApolloTests.Data.EntityBuilder.SectionBuilders.BOP;
using ApolloTests.Data.EntityBuilder.SectionBuilders.CA;
using ApolloTests.Data.Rating;
using HitachiQA.Helpers;
using Newtonsoft.Json.Linq;

namespace ApolloTests.Data.EntityBuilder
{

    /// 
    /// 
    /// This class creates a quote in apollo, SectionBuilders can be used to enter inputs to each section
    ///        
    /// 
    /// 1. On initialize, the constructor initializes all sections regardless of LOB
    /// 2. the constructor also selects the relevant keyword depending on the coverage in it's parameter 
    /// 3. once initialized, then the developer/user can make all desired modifications to the defaults
    /// 4. Build()  Optional: forceQuotedStatus: if true, and quote was referred or declient, the funciton will take quote through workflow until quoted (Default: true)
    /// 5. Quote is created in Apollo
    ///     1. Interpreter is initialized to hydrate properties see HydratorUtil.cs for detailed documentation
    ///     2. set variables relevant to the LOB (IndustryClassTaxonomyId vs BuildingGroupId)
    ///     3. set the rest of the variables (Effective Date, LOB)
    ///     4. hydrate QuoteCreate object
    ///     5. store the rest of the relevant datapoints
    /// 6. depending on the LOB, run each section's send strategy
    ///     1. each Section Builder has a SendStrategy function enforce by inheriting from IBuilder interface
    ///     2. Hydrator is used to load dynamic data into the models
    ///         note: the hydrator goes through state changes for questions as well
    ///     3. Load any relevant information (Eg., randomly generated Valid VIN Number)
    ///     4. convert the Model into JSON and send it to the appropiate endpoint
    ///     
    /// 7. Summary is posted
    /// 8. Assert rating was successful
    /// 9. if Build(forceQuotedStatus=true) & quote is not quoted
    ///     1. Quote is referred to underwriting
    ///     2. Quote proposal is generated
    /// 
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
        public QuoteBuilder(Line line, string state, List<CoverageType>? coverageTypes=null)
        {
            coverageTypes ??= new();
            this.State = state;
            this.Line = line;

            //
            // 1. On initialize, the constructor initializes all sections regardless of LOB
            //
            #region Initialize all sections
            this.QuoteCreateBody = new();
            this.Vehicles = new(this);
            this.Drivers = new(this);
            this.Modifiers_CA = new(this);

            this.PriorClaims= new(this);
            this.Locations= new(this);
            this.Tools= new(this);
            this.Modifiers_BOP = new(this);           

            this.Operations = new(this);
            this.PolicyCoverages = new(this);
            this.PolicyAddlInterest = new(this);
            #endregion

            //
            // 2. the constructor also selects the relevant keyword depending on the coverage in it's parameter 
            //
            //iterate through each coverage type in this builder and make sure to meet the necesary condition
            foreach (var cov in coverageTypes)
            {
                switch (line.LineEnum)
                {
                    case Lines.BusinessOwner:
                        throw new NotImplementedException($"{line.Name} Coverage assignment for BOP needs to be implemented");
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
                        }
                        break;
                }
            }
            //by default accounting services keyword is loaded
            ClassCodeKeyword ??= KeywordMappingUtil.GetUsingKeywordName(line, "Accounting Services");

            //
            // 3. once initialized, then the developer/user can make all desired modifications to the defaults
            //

        }
        #region Secondary Constructors
        public QuoteBuilder(Line line, string state, KeywordMappingUtil classCodeKeyword) : this(line, state, classCodeKeyword.coverage ?? new CoverageType("BIPD"))
        {
            State = state;
            ClassCodeKeyword = classCodeKeyword;
        }
        public QuoteBuilder(Line line, string state, string algorithmCode) : this(line, state, KeywordMappingUtil.GetUsingAlgorithmCode(line, algorithmCode, state)) { }

        public QuoteBuilder(Line line, string state, CoverageType coverageType) : this(line, state, new List<CoverageType>() { coverageType }) { }
        #endregion



        #region Builders
        #region CA Builders
        public VehiclesBuilder Vehicles;
        public DriversBuilder Drivers;
        public ModifiersBuilder_CA Modifiers_CA;

        #endregion CA Builders

        #region BOP Builders
        public PriorClaimsBuilder PriorClaims ;
        public LocationsBuilder Locations;
        public ToolBuilder Tools;
        public ModifiersBuilder_BOP Modifiers_BOP;

        #endregion BOP/GL Builders

        public OperationsBuilder Operations;
        public PolicyCoveragesBuilder PolicyCoverages;
        public PolicyAddnlIntrestBuilder PolicyAddlInterest;
        #endregion Builders



        /// <summary>
        /// Build this quoteBuilder as a quote in Apollo
        /// </summary>
        /// <param name="forceQuotedStatus">if true and quote is referred or declined it will refer to underwriting and generate proposal to get it to quoted</param>
        /// <returns>Quote object representing the newly created Quote in Apollo</returns>
        
        // 4. Build()
        public Quote Build(bool forceQuotedStatus = true)
        {   //
            // 5. Quote is created in Apollo
            //
            this.QuoteEntity ??= CreateQuote();

            //
            // 6. depending on the LOB, run each section's send strategy
            //
            switch (Line.Id)
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


        public QuoteCreate QuoteCreateBody;

        public Entity.Quote CreateQuote()
        {
            //
            //    1. Interpreter is initialized to hydrate properties see HydratorUtil.cs for detailed documentation
            //    2. set variables relevant to the LOB (IndustryClassTaxonomyId vs BuildingGroupId)
            //
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

            //
            //     3. set the rest of the variables (Effective Date, LOB)
            //
            this.Hydrator.Interpreter.SetVariable("OrganizationName", $"Automation API org {DateTimeOffset.Now.ToUnixTimeMilliseconds()}");
            this.Hydrator.Interpreter.SetVariable("LineId", this.Line.Id);
            this.Hydrator.Interpreter.SetVariable("SubLineId", this.Line.Id);
            this.Hydrator.Interpreter.SetVariable("EffectiveDate", this.EffectiveDate);
            this.Hydrator.Interpreter.SetVariable("ExpirationDate", this.ExpirationDate);
            String jsonString = new StreamReader($"Data/EntityBuilder/Entities/CreateAddress/{this.State.ToUpper()}.json").ReadToEnd();
            var addressObj = JObject.Parse(jsonString);
            this.Hydrator.Interpreter.SetVariable("AddressObject", addressObj);
            
            //
            //     4. hydrate QuoteCreate object
            //
            this.Hydrator.Hydrate(this.QuoteCreateBody);
            dynamic response = RestAPI.POST("/quote/create", this.QuoteCreateBody) ?? throw new NullReferenceException();

            //
            //     5. store the rest of the relevant datapoints
            //
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






        //
        //     1. each Section Builder has a SendStrategy function enforce by inheriting from IBuilder interface
        //     2. Hydrator is used to load dynamic data into the models
        //         note: the hydrator goes through state changes for questions as well
        //     3. Load any relevant information (Eg., randomly generated Valid VIN Number)
        //     4. convert the Model into JSON and send it to the appropiate endpoint
        //     
        private void RunAllSendStrategies_CA()
        {
            QuoteEntity.NullGuard();
            this.Vehicles.RunSendStrategy(QuoteEntity);
            this.Drivers.RunSendStrategy(QuoteEntity);
            this.Operations.RunSendStrategy(QuoteEntity);
            this.PolicyCoverages.RunSendStrategy(QuoteEntity);
            this.Modifiers_CA.RunSendStrategy(QuoteEntity);
            this.PolicyAddlInterest.RunSendStrategy(QuoteEntity);
        }

        //
        //     1. each Section Builder has a SendStrategy function enforce by inheriting from IBuilder interface
        //     2. Hydrator is used to load dynamic data into the models
        //         note: the hydrator goes through state changes for questions as well
        //     3. Load any relevant information (Eg., randomly generated Valid VIN Number)
        //     4. convert the Model into JSON and send it to the appropiate endpoint
        //     
        private void RunAllSendStrategies_BOP()
        {
            QuoteEntity.NullGuard();
            this.PriorClaims.RunSendStrategy(QuoteEntity);
            this.Locations.RunSendStrategy(QuoteEntity);
            this.Tools.RunSendStrategy(QuoteEntity);    
            this.Operations.RunSendStrategy(QuoteEntity);
            this.PolicyCoverages.RunSendStrategy(QuoteEntity);
            this.Modifiers_BOP.RunSendStrategy(QuoteEntity);
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
        Tools,
        AdditionalInterests

    }
}
