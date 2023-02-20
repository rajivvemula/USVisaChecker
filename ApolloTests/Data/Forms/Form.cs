using ApolloTests.Data.Entities;
using ApolloTests.Data.Entity;
using HitachiQA.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ApolloTests.Data.Form
{
    public class Form:BaseEntity
    {
        public static readonly List<Form> Forms = JsonConvert.DeserializeObject<List<Form>>(File.ReadAllText("Data/Forms/Forms.json"));

        public string name;
        public string code;
        public Condition condition;
        public string displayTitle;

        private long? _Id = null;
        public long Id
        {
            get
            {
                return _Id ??= (long)SQL.executeQuery($"SELECT Id FROM [document].[Form] WHERE code = {this.code}")[0]["Id"] ;

            }
        }

        private string _Edition = null;
        public string Edition
        {
            get
            {
                try
                {
                    return _Edition ??= SQL.executeQuery(@$"SELECT TOP(1) Edition, EditionDate
                                                FROM [document].[GhostDraftTemplateForm] 
                                                where Code ='{code}' AND LineId = 7 order by Id desc; ")[0]["Edition"];
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
                                                where Code ='{code}' AND LineId = 7 order by Id desc; ")[0]["EditionDate"];
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
            this.name = name;
            this.code = code;
            //this.condition = condition?.ToObject<Condition>() ?? new Condition();
            this.condition = condition;
            this.displayTitle = displayTitle;
        }


        //static funciton in order to access any form using it's code (forms' unique identifier)
        public static Form GetForm(string code, string name="")
        {
            var form = Forms.FirstOrDefault(it => it.code == code);

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
                throw new KeyNotFoundException($"Form with code {code} was not found in ./Data/Forms/Forms.json {addition}");


            }
            if(form.condition == null)
            {
                form.condition = new Condition();
            }
            return form;
        }

    }
}
