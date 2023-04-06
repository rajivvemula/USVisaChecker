using ApolloTests.Data.Entities;
using ApolloTests.Data.Entity;
using HitachiQA.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ApolloTests.Data.Form
{
    public class Form:BaseEntity
    {
        private static readonly List<Form> FormsCA = JsonConvert.DeserializeObject<List<Form>>(File.ReadAllText("Data/Forms/CommercialAutoLOB.json"))?? throw new NullReferenceException("loading FormsCA returned null");
        private static readonly List<Form> FormsBP = JsonConvert.DeserializeObject<List<Form>>(File.ReadAllText("Data/Forms/BusinessOwnerLOB.json")) ?? throw new NullReferenceException("loading FormsBP returned null");

        public static List<Form> GetForms(Line LOB)
        {
            var forms= LOB.Id switch
            {
                7 => FormsCA,
                3 => FormsBP,
                _ => throw new NotImplementedException($"Line ={LOB.Name} not implemented"),
            };
           
            return forms;
        }
       

        private string? _Name = null;
        public string name
        {
            get
            {
                try
                {
                    return _Name ??= SQL.executeQuery(@$"SELECT TOP(1) Name
                                                FROM [document].[GhostDraftTemplateForm] 
                                                where Code ='{code}' AND LineId = {Line.Id} order by Id desc; ")[0]["Name"];
                }
                catch
                {
                    Log.Error($"Error retrieving Name for form code: {code}");
                    throw;
                }
            }
        }
        public string code;
        public Condition condition;
        public string? displayTitle;
        private Line? _line = null;
        public Line Line {
            get{
                _line.NullGuard();
                return _line;
            } 
            set {
                this._line= value;
            }
        }
        public List<Recipient> Recipients { get
            {
                var res = Cosmos.GetQuery("FormsServiceRule", $"SELECT * FROM c where ARRAY_CONTAINS(c.Forms, {{GhostDraftTemplateFormCode:\"{this.code}\"}}, true)").Result;
                if(res.Any())
                {
                    var obj = res[0];
                    var recipients = (JArray?)((JArray?)obj?["Forms"]??throw new Exception("recipient's form was null")).First(it => it.Value<string>("GhostDraftTemplateFormCode") == code)?["Recipients"];
                    return recipients?.Select(it => it.ToObject<Recipient>() ?? throw new ArgumentNullException()).ToList()?? throw new Exception("Recipients were null");
                }
                else
                {
                    //if no recipients found, we default to insurred
                    return new List<Recipient>() { new Recipient() { Id=0, DeliveryMethodIdsInternal="1,2", FormsServiceRuleFormEntityId=0, RecipientRoleTypeId=10006 } };
                }
            } 
        }

        private long? _Id = null;
        public long Id
        {
            get
            {
                return _Id ??= (long)SQL.executeQuery($"SELECT Id FROM [document].[Form] WHERE code = {this.code}")[0]["Id"] ;

            }
        }

        private string? _Edition = null;
        public string Edition
        {
            get
            {
                try
                {
                    return _Edition ??= SQL.executeQuery(@$"SELECT TOP(1) Edition, EditionDate
                                                FROM [document].[GhostDraftTemplateForm] 
                                                where Code ='{code}' AND LineId = {Line.Id} order by Id desc; ")[0]["Edition"];
                }
                catch {
                    Log.Error($"Error retrieving edition for form code: {code}");
                    throw;
                }
            }
        }

        private DateTime? _EditionDate = null;

        public DateTime EditionDate 
        {
            get
            {
                try
                {
                     return _EditionDate ??= (DateTime)SQL.executeQuery(@$"SELECT TOP(1) Edition, EditionDate
                                                FROM [document].[GhostDraftTemplateForm] 
                                                where Code ='{code}' AND LineId = {Line.Id} order by Id desc; ")[0]["EditionDate"];
                }
                catch
                {
                    Log.Error($"Error retrieving edition date for form code: {code}");
                    throw;
                }
            }
        }

       
        public Form(string name, string code, Condition condition, string? displayTitle)
        {
            this.code = code;
            //this.condition = condition?.ToObject<Condition>() ?? new Condition();
            this.condition = condition;
            this.displayTitle = displayTitle;
        }


        //static funciton in order to access any form using it's code (forms' unique identifier)
        public static Form GetForm(Line line, string code, string name="")
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
            if(form.condition == null)
            {
                form.condition = new Condition();
            }

            if(form.Recipients.Any(it => it.RecipientTypeCode != "INSURED"))
            {
                form.condition.recipients = form.Recipients.Where(it=>it.RecipientRoleTypeId!=-1).Select(it => it.RecipientTypeCode).Distinct().ToList();
            }
            form.Line = line;
            form.condition.Form = form;

            return form;
        }

    }
}
