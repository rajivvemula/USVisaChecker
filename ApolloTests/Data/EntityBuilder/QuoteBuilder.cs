using ApolloTests.Data.Entities;
using ApolloTests.Data.Entity;
using ApolloTests.Data.EntityBuilder.Models;
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
        public ClassCodeKeyword ClassCodeKeyword { get; set; }
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

            this.QuoteCreate = new();
            this.Vehicles = new(this);
            this.Drivers = new(this);
            this.Operations = new(this);
            this.PolicyCoverages = new(this);
            this.Modifiers = new(this);
            this.PolicyAddlInterest = new(this);

            this.Line = line;
            switch (line.Id)
            {
                case (long)Line.LineEnum.BusinessOwner:
                    throw new NotImplementedException($"{line.Name} Quote Builder not implemented");
                //break;
                case (long)Line.LineEnum.CommercialAuto:

                    break;
            }
            State = state;

            foreach (var cov in coverageTypes)
            {
                PolicyCoverages.Add(cov);
                switch (cov.Name)
                {
                    case CoverageType.TRAILER_INTERCHANGE:
                        Vehicles[0].Vehicle.grossVehicleWeight = "30000";
                        break;

                    case CoverageType.IN_TOW:
                        ClassCodeKeyword ??= ClassCodeKeyword.GetUsingKeywordName("Towing Services");
                        break;

                    case CoverageType.CARGO:
                        ClassCodeKeyword ??= ClassCodeKeyword.GetUsingKeywordName("Towing Services");
                        break;

                    case CoverageType.RENTAL_REIMBURSEMENT:
                        Vehicles[0].AddCollision = true;
                        break;

                    default:
                        //this.ClassCodeKeyword ??= ClassCodeKeyword.GetUsingKeywordName("Accounting Services");
                        break;
                }

            }
            


            ClassCodeKeyword ??= ClassCodeKeyword.GetUsingKeywordName("Accounting Services");
        }


        public QuoteBuilder(Line line, string state, ClassCodeKeyword classCodeKeyword) : this(line, state, classCodeKeyword.coverage ?? new CoverageType("BIPD"))
        {
            State = state;
            ClassCodeKeyword = classCodeKeyword;
        }
        public QuoteBuilder(Line line, string state, string algorithmCode) : this(line, state, ClassCodeKeyword.GetUsingAlgorithmCode(algorithmCode, state)) { }

        public QuoteBuilder(Line line, string state, CoverageType coverageType) : this(line, state, new List<CoverageType>() { coverageType }) { }

        public QuoteCreate QuoteCreate;
        public VehiclesBuilder Vehicles;
        public DriversBuilder Drivers;
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
            this.Hydrator.Interpreter.SetVariable("IndustryClassTaxonomyClassName", this.ClassCodeKeyword.TaxonomyName);
            this.Hydrator.Interpreter.SetVariable("IndustryClassTaxonomyId", this.ClassCodeKeyword.IndustryClassTaxonomyId);
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
        /// <param name="forceQuoted">if true and quote is referred or declined it will refer to underwriting and generate proposal to get it to quoted</param>
        /// <returns></returns>
        public Quote Build(bool forceQuoted=true)
        {
            this.QuoteEntity ??= CreateQuote();
            this.Vehicles.RunSendStrategy(QuoteEntity);
            this.Drivers.RunSendStrategy(QuoteEntity);
            this.Operations.RunSendStrategy(QuoteEntity);
            this.PolicyCoverages.RunSendStrategy(QuoteEntity);
            this.Modifiers.RunSendStrategy(QuoteEntity);
            this.PolicyAddlInterest.RunSendStrategy(QuoteEntity);

            var summary = this.QuoteEntity.PostSummary();

            summary.NullGuard();
            Log.Debug("Quote Id: " + QuoteEntity.Id);
            Log.Debug("Rating Group Id (rating worksheet): \n" + $"{Environment.GetEnvironmentVariable("HOST")}/rating/ratings-worksheet/" + (summary?["ratingGroupId"] ?? "null") + "\n");
            if (summary?["errors"]?.Count() > 0 || summary?["ratingResponses"] == null)
            {
                Log.Critical(summary);
                throw Functions.HandleFailure($"Premium generation was unsuccessful Quote: {QuoteEntity.Id} Premium: " + summary?["ratingResponses"]);
            }

            if (QuoteEntity["ApplicationStatusKey"] != 4000 && forceQuoted)
            {
                QuoteEntity.ReferToUnderwriting();

                QuoteEntity.GenerateProposal();
            }

            return this.QuoteEntity;
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
        Contacts
    }
}
