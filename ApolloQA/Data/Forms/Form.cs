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
        public static readonly List<Form> Forms = JsonConvert.DeserializeObject<List<Form>>(File.ReadAllText(Path.Combine($"{Source.Driver.Setup.SourceDir}", "Data/Forms/Forms.json")));

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
                return _Edition ??= SQL.executeQuery(@$"SELECT TOP(1) Edition
                                                FROM [document].[GhostDraftTemplateForm] 
                                                where Code ='{code}' order by Id desc; ")[0]["Edition"];

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
        public static Form GetForm(string code)
        {
            var form = Forms.FirstOrDefault(it => it.code == code);

            if (form == null)
            {
                throw new KeyNotFoundException($"Form with code {code} was not found in ./Data/Forms/Forms.json");
            }
            if(form.condition == null)
            {
                form.condition = new Condition();
            }
            return form;
        }

    }
}
