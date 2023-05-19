using ApolloTests.Data.EntityBuilder.Models;
using ApolloTests.Data.EntityBuilder.SectionBuilders;
using ApolloTests.Data.EntityBuilder.SectionBuilders.BOP;
using ApolloTests.Data.EntityBuilder.SectionBuilders.CA;
using ApolloTests.Data.Entities;
using ApolloTests.Data.Entities.Context;
using ApolloTests.Data.Entities.Coverage;
using ApolloTests.Data.Entities.Enums;
using ApolloTests.Data.Entities.Reference;
using ApolloTests.Data.Rating;
using HitachiQA.Helpers;
using Newtonsoft.Json;
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
        public Data.Entities.Quote? Quote { get; set; }
        public Line Line { get; set; }
        public string State { get; set; } = "IL";
        public KeywordMappingUtil ClassCodeKeyword { get; set; }
        public DateTimeOffset EffectiveDate { get; set; } = DateTimeOffset.Now.AddDays(1);
        public DateTimeOffset ExpirationDate { get; set; } = DateTimeOffset.Now.AddDays(1).AddYears(1);

        public HydratorUtil Hydrator = new HydratorUtil();

        public IObjectContainer ObjectContainer { get; }
        public CosmosContext CosmosContext { get; }
        public SQLContext SQLContext { get; }

        /// <summary>
        /// Main Constructor
        /// </summary>
        public QuoteBuilder(IObjectContainer OC, LineEnum line, string state, List<string>? coverageTypes=null)
        {
            ObjectContainer = OC;
            CosmosContext = OC.Resolve<CosmosContext>();
            SQLContext = OC.Resolve<SQLContext>();
            coverageTypes ??= new();
            State = state;
            Line = this.SQLContext.Line.Find((int)line);

            //
            // 1. On initialize, the constructor initializes all sections regardless of LOB
            //
            #region Initialize all sections
            Vehicles = new(this);
            Drivers = new(this);
            Modifiers_CA = new(this);

            PriorClaims = new(this);
            Locations = new(this);
            Tools = new(this);
            Modifiers_BOP = new(this);           

            Operations = new(this);
            PolicyCoverages = new(this);
            PolicyAddlInterest = new(this);
            #endregion

            //
            // 2. the constructor also selects the relevant keyword depending on the coverage in it's parameter 
            //
            //iterate through each coverage type in this builder and make sure to meet the necesary condition
            foreach (var cov in coverageTypes)
            {
                switch (line)
                {
                    case LineEnum.BusinessOwner:
                        throw new NotImplementedException($"{Line.Name} Coverage assignment for BOP needs to be implemented");
                    //break;
                    case LineEnum.CommercialAuto:

                        if(!PolicyCoverages.Any(x=> x.CoverageType.TypeName==cov))
                        {
                            PolicyCoverages.Add(cov);
                        }
                        switch (cov)
                        {
                            case CoverageType.TRAILER_INTERCHANGE:
                                Vehicles[0].Vehicle.GrossVehicleWeight = "30000";
                                break;

                            case CoverageType.IN_TOW:
                                ClassCodeKeyword ??= KeywordMappingUtil.GetUsingKeywordName(line, "Towing Services");
                                break;

                            case CoverageType.CARGO:
                                ClassCodeKeyword ??= KeywordMappingUtil.GetUsingKeywordName(line, "Fulfillment Center");
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
            HydrateNewQuoteObject();

            //
            // 3. once initialized, then the developer/user can make all desired modifications to the defaults
            //

        }
        #region Secondary Constructors
        public QuoteBuilder(IObjectContainer OC, LineEnum line, string state, KeywordMappingUtil classCodeKeyword) : this(OC, line, state, new List<string> { classCodeKeyword.CoverageType ?? CoverageType.BIPD })
        {
            ClassCodeKeyword = classCodeKeyword;
            HydrateNewQuoteObject();

        }
        public QuoteBuilder(IObjectContainer OC, LineEnum line, string state, string algorithmCode) : this(OC, line, state, KeywordMappingUtil.GetUsingAlgorithmCode(line, algorithmCode, state)) { }

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
            CreateQuote();
            

            //
            // 6. depending on the LOB, run each section's send strategy
            //
            switch (Line.Id)
            {
                case (int)LineEnum.CommercialAuto:
                    RunAllSendStrategies_CA();

                    break;
                case (int)LineEnum.BusinessOwner:
                    RunAllSendStrategies_BOP();

                    break;
                default: throw new NotImplementedException();
            }
            
            var summary = this.Quote.PostSummary();

            summary.NullGuard();
            Log.Debug("Quote Id: " + Quote.Id);
            Log.Debug("Rating Group Id (rating worksheet): \n" + $"{Environment.GetEnvironmentVariable("HOST")}/rating/ratings-worksheet/" + (summary?["ratingGroupId"] ?? "null") + "\n");
            if (summary?["errors"]?.Count() > 0 || summary?["ratingResponses"] == null)
            {
                Log.Critical(summary);
                throw Functions.HandleFailure($"Premium generation was unsuccessful Quote: {Quote.Id} Premium: " + summary?["ratingResponses"]);
            }

            if (Quote.ApplicationStatusKey != 4000 && forceQuotedStatus)
            {
                Quote.ReferToUnderwriting();

                Quote.GenerateProposal();
            }


            Quote = this.CosmosContext.Quotes.First(it=> it.Id== Quote.Id);

            return Quote;
        }

        public void HydrateNewQuoteObject()
        {
            //
            //    1. Interpreter is initialized to hydrate properties see HydratorUtil.cs for detailed documentation
            //    2. set variables relevant to the LOB (IndustryClassTaxonomyId vs BuildingGroupId)
            //
            this.Hydrator.Interpreter.SetVariable("KeywordId", this.ClassCodeKeyword.KeywordId);
            switch (this.Line.LineEnum)
            {
                case LineEnum.CommercialAuto:
                    this.Hydrator.Interpreter.SetVariable("IndustryClassTaxonomyClassName", this.ClassCodeKeyword.TaxonomyName);
                    this.Hydrator.Interpreter.SetVariable("IndustryClassTaxonomyId", this.ClassCodeKeyword.IndustryClassTaxonomyId);
                    break;
                case LineEnum.BusinessOwner:
                    this.Hydrator.Interpreter.SetVariable("BuildingGroupId", (int)this.ClassCodeKeyword.BuildingGroup);
                    break;
                default: throw new NotImplementedException();
            }

            //
            //     3. set the rest of the variables (Effective Date, LOB)
            //
            this.Hydrator.Interpreter.SetVariable("OrganizationName", $"Automation API org Run:{Main.RunId}-{DateTimeOffset.Now.ToUnixTimeMilliseconds()}");
            this.Hydrator.Interpreter.SetVariable("LineId", this.Line.Id);
            this.Hydrator.Interpreter.SetVariable("SubLineId", this.Line.Id);
            this.Hydrator.Interpreter.SetVariable("EffectiveDate", this.EffectiveDate);
            this.Hydrator.Interpreter.SetVariable("ExpirationDate", this.ExpirationDate);
            String addressObjStr = new StreamReader($"Data/EntityBuilder/Entities/CreateAddress/{this.State.ToUpper()}.json").ReadToEnd();
            var addressObj = JObject.Parse(addressObjStr);
            this.Hydrator.Interpreter.SetVariable("AddressObject", addressObj);

            //
            //     4. hydrate QuoteCreate object
            //
            Quote = new Quote();
            this.Hydrator.Quote = Quote;
            this.Hydrator.Hydrate(Quote);
        }

        public Quote CreateQuote()
        {
            
            JObject response = RestAPI.POST("/quote/create", this.Quote) ?? throw new NullReferenceException();
            try
            {
                JObject app = this.Cosmos.GetQuery($"Application", $"select * from c where c.Id = {response.Value<long>("id")}").Result[0];
                Log.Info(app);
                Quote = CosmosContext.Quotes.First(it => it.Id == response.Value<long>("id"));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving application from cosmos: {response.Value<long>("id")}\n", ex);
            }
            this.Hydrator.Quote = Quote;

            //
            //     5. store the rest of the relevant datapoints
            //
            this.Hydrator.Interpreter.SetVariable("ApplicationId", Quote.Id);
            this.Hydrator.Interpreter.SetVariable("QuoteId", Quote.Id);
            this.Hydrator.Interpreter.SetVariable("StateCode", this.State);
            this.Hydrator.Interpreter.SetVariable("PhysicalAddressId", response["addressIds"][0]);
            this.Hydrator.Interpreter.SetVariable("GoverningStateId", response["governingStateId"]);
            this.Hydrator.Interpreter.SetVariable("Quote", Quote);
            Log.Info($"Created quote: {Quote.Id}");
            Log.Info($"Insured: { Quote.BusinessInformation.Name}");
            return Quote;
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
            CheckIfRatesAreLoaded(State);
            Quote.NullGuard();
            this.Vehicles.RunSendStrategy(Quote);
            this.Drivers.RunSendStrategy(Quote);
            this.Operations.RunSendStrategy(Quote);
            this.PolicyCoverages.RunSendStrategy(Quote);
            this.Modifiers_CA.RunSendStrategy(Quote);
            this.PolicyAddlInterest.RunSendStrategy(Quote);
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
            Quote.NullGuard();
            this.PriorClaims.RunSendStrategy(Quote);
            this.Locations.RunSendStrategy(Quote);
            this.Tools.RunSendStrategy(Quote);    
            this.Operations.RunSendStrategy(Quote);
            this.PolicyCoverages.RunSendStrategy(Quote);
            this.Modifiers_BOP.RunSendStrategy(Quote);
            this.PolicyAddlInterest.RunSendStrategy(Quote);
        }

        private void CheckIfRatesAreLoaded(string stateCode)
        {
            var result = SQL.executeQuery(@"
                                select s.[Code], rt.[Name]
                            FROM [rating].[ReferenceTable] rt
                            LEFT JOIN [rating].[ReferenceTableStateProvince] sp on sp.ReferenceTableId = rt.Id
                            LEFT JOIN [location].[StateProvince] s on s.Id = sp.StateProvinceId
                            WHERE rt.Name like 'AT.1' 
                            AND s.[Code]=@stateCode
                        ", ("@stateCode", stateCode));
            if(!result.Any())
            {
                throw new Exception($"Rates tables are not loaded for state: {stateCode}");
            }
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
