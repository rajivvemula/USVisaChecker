using ApolloQA.Data.Entity;
using ApolloQA.Source.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ApolloQA.Data.Form
{
    public class Form
    {
        public static readonly JArray Forms = JsonConvert.DeserializeObject<JArray>(File.ReadAllText(Path.Combine($"{Source.Driver.Setup.SourceDir}", "Data/Forms/Forms.json")));

        public string name;
        public string code;
        public Condition condition;
        public string displayTitle;

        //doesn't seem to be needed.
        //public long Id => SQL.executeQuery($"SELECT Id FROM [document].[Form] WHERE code = {this.code}")[0]["Id"];
        public string Edition => SQL.executeQuery(@$"SELECT TOP(1) Edition
                                                      FROM [document].[GhostDraftTemplateForm] 
                                                      where Code ='{code}' order by Id asc; ")[0]["Edition"];
       


       
        public Form(string name, string code, JToken condition, string? displayTitle)
        {
            this.name = name;
            this.code = code;
            this.condition = condition?.ToObject<Condition>() ?? new Condition();
            this.displayTitle = displayTitle;
        }


        //static funciton in order to access any form using it's code (forms' unique identifier)
        public static Form GetForm(string code)
        {
            var form = (JObject)Forms.FirstOrDefault(it => it["code"]?.ToString() == code);

            if (form == null)
            {
                throw new KeyNotFoundException($"Form with code {code} was not found in ./Data/Forms/Forms.json");
            }
            return new Form(form.GetValue("name")?.ToString(),
                            form.GetValue("code")?.ToString(), 
                            form.GetValue("condition"),
                            form.GetValue("displayTitle")?.ToString());
        }

    }
}
