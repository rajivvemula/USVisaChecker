using ApolloQA.Source.Driver;
using ApolloQA.Source.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ApolloQA.Data.Rating
{
    public class Factor
    {
        private static readonly dynamic Factors = JsonConvert.DeserializeObject<JObject>(new StreamReader(Path.Combine($"{Source.Driver.Setup.SourceDir}", "Data/Rating/Factors.json")).ReadToEnd());

        public readonly string Name;
        public readonly IEnumerable<string> NameUI;
        public IEnumerable<KnownField> KnownFields;
        public readonly bool CustomCalculation;


        public Factor(string name, IEnumerable<string> nameUI, IEnumerable<KnownField> knownFields, bool? CustomCalculation=false)
        {
            this.Name = name;
            this.NameUI = nameUI;
            this.KnownFields = knownFields;
            this.CustomCalculation = CustomCalculation ?? false;
        }
        public static Factor GetFactor(string name)
        {
            var _factor = GetFactors().Find(it => it.Name == name);

            if (_factor == null) { throw new KeyNotFoundException($"Factor: {name} did not exist in  DataFiles/Rating/Factors.json"); }

            return _factor;


        }

        private static List<Factor> _factors = new List<Factor>();
        public static List<Factor> GetFactors()
        {
            if(_factors.Count == 0)
            {
                foreach (var factor in Factors)
                {
                    if (factor.Value.KnownFields == null) { throw new KeyNotFoundException($"Factor: \n{factor}\n did not have source property in DataFiles/Rating/Factors.json"); }

                    _factors.Add(new Factor(factor.Name, 
                                            factor.Value.nameUI.ToObject<IEnumerable<string>>(), 
                                            ((JArray)factor.Value.KnownFields).Select(it=>KnownField.GetKnownField(it.ToString())),
                                            (bool?)factor.Value.CustomCalculation
                                            ));

                }
            }
            return _factors;
           
        }

        public Resolvable GetResolvable(Engine engine)
        {
            return new Resolvable(engine, this);
        }

        public override string ToString()
        {
            return Name;
        }
        public class Resolvable
        {
            private readonly Factor Factor;
            private readonly Engine Engine;
            public List<KnownField.Resolvable> KnownFields;
            public JObject matchedRow;
            public string Name
            {
                get => Factor.Name;
                set
                {
                    if (Factor == null)
                    {
                        Factor.GetFactor(value);
                    }
                }
            }
            public IEnumerable<string> NameUI => Factor.NameUI;

            public bool CustomCalculation => Factor.CustomCalculation;

            public Resolvable(Engine engine, Factor factor)
            {
                this.Factor = factor;
                this.Engine = engine;
            }

            public JObject Resolve()
            {
                loadResolvedKnownFields();

                return JObject.FromObject(this);

            }

            private void loadResolvedKnownFields()
            {

                this.KnownFields = new List<KnownField.Resolvable>();
                if (this.Factor.KnownFields == null) { throw new KeyNotFoundException($"Factor Name: [{this.Factor}] did not have any known fields in DataFiles/Rating/Factors.json"); }

                foreach (var knownField in this.Factor.KnownFields)
                {
                    KnownField.Resolvable resolvable = knownField.GetResolvable(this.Engine);

                    resolvable.Resolve();

                    this.KnownFields.Add(resolvable);
                }
            }
        }
    }   
    
}
