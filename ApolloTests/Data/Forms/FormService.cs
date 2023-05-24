using ApolloTests.Data.Entities;
using ApolloTests.Data.Entities.Reference;
using Newtonsoft.Json;

namespace ApolloTests.Data.Forms
{
    public class FormService : BaseEntity
    {
        private List<Form> FormsCA { get; }
        private List<Form> FormsBP { get; }
        public FormService(IObjectContainer OC) : base(OC)
        {
            FormsCA = JsonConvert.DeserializeObject<List<Form>>(File.ReadAllText("Data/Forms/CommercialAutoLOB.json")) ?? throw new NullReferenceException("loading FormsCA returned null");
            FormsCA.ForEach(it => { 
                it.LoadOC(OC);
                it.condition ??= new Condition();
                it.condition.LoadOC(OC);
            });

            FormsBP = JsonConvert.DeserializeObject<List<Form>>(File.ReadAllText("Data/Forms/BusinessOwnerLOB.json")) ?? throw new NullReferenceException("loading FormsBP returned null");
            FormsBP.ForEach(it => {
                it.LoadOC(OC);
                it.condition ??= new Condition();
                it.condition.LoadOC(OC);
            });
        }

        public List<Form> GetForms(Line LOB)
        {
            var forms = LOB.Id switch
            {
                7 => FormsCA,
                3 => FormsBP,
                _ => throw new NotImplementedException($"Line ={LOB.Name} not implemented"),
            };

            return forms;
        }

        public Form GetForm(Line line, string code, string name = "")
        {
            var form = GetForms(line).FirstOrDefault(it => it.code == code);

            if (form == null)
            {
                string addition = $@"

                    {{
                        ""code"": ""{code}"",
                        ""name"": ""{name}"",
                        ""condition"": {{
                          ""stateCode"": ""statecode""
                        }}
                    }},

                    ==== or (if no condition) ====
                    {{
                        ""code"": ""{code}"",
                        ""name"": ""{name}"",
                    }},
                ";
                throw new KeyNotFoundException($"Form with code {code} was not found in ./Data/Forms/FormsLine{line.Id}.json {addition}");


            }

            if (form.Recipients.Any(it => it.RecipientTypeCode != "INSURED"))
            {
                form.condition.recipients = form.Recipients.Where(it => it.RecipientRoleTypeId != -1).Select(it => it.RecipientTypeCode).Distinct().ToList();
            }
            form.Line = line;
            form.condition.Form = form;

            return form;
        }
    }
}
