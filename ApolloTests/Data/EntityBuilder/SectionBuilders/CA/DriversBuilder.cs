using ApolloTests.Data.Entities.Risk;
using HitachiQA.Helpers;
using Newtonsoft.Json.Linq;


namespace ApolloTests.Data.EntityBuilder.SectionBuilders.CA
{
    public class DriversBuilder : List<DriverRisk>, IRiskBuilder
    {
        public Section Section => Section.Drivers;
        public QuoteBuilder Builder { get; }
        public HydratorUtil Hydrator => Builder.Hydrator;

        public uint NumberOfRisks
        {
            get => (uint)Count;
            set => this.SetNumberOfRisks(value);
        }

        public DriversBuilder(QuoteBuilder quoteBuilder)
        {
            Builder = quoteBuilder;
            this.AddOne();
        }

        public JToken RunSendStrategy(Data.Entities.Quote quote)
        {
            JArray result = new JArray();
            Hydrator.CurrentSection = Section;

            foreach (var risk in this)
            {
                Hydrator.Interpreter.SetVariable("LicenseNumber", Functions.GetValidDriverLicense(Builder.State));
                Builder.Hydrator.CurrentEntity = risk.Driver;
                Builder.Hydrator.CurrentAnswers = risk.QuestionAnswers;

                Hydrator.Hydrate(risk);
                var body = new JArray(risk.ToJObject());

                JArray response = Builder.RestAPI.POST($"quote/{quote.Id}/risk", body) ?? throw new NullReferenceException();
                result.Add(response.ElementAt(0));
                risk.LoadEntityObject((JObject)response.ElementAt(0));

            }

            return result;
        }

        public void AddOne() => Add(new DriverRisk(true));
       
    }
}
