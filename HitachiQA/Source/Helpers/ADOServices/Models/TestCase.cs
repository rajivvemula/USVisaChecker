using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium.DevTools.V102.Debugger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iText.IO.Codec.TiffWriter;

namespace HitachiQA.Source.Helpers.ADOServices.Models
{
    public class TestCase
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string MethodFullName { get; set; }
        public List<string> Tags { get; set; }

        public string FeatureTitle { get; set; }

        public string GetFieldVal(string fieldName) {
            return AddNewOperations.First(op => op.Path.EndsWith(fieldName)).Value;
        }
        public string[] FieldNames => AddNewOperations.Select(it => it.Path.Split('/').Last()).ToArray();


        public List<Operation> AddNewOperations  => new List<Operation>() { 
            new Operation(){ Op = "add", Path = "/fields/System.Title", Value = Name },
            new Operation(){ Op = "add", Path = "/fields/System.Tags", Value = string.Join("; ", Tags) },
            new Operation(){ Op = "add", Path = "/fields/Microsoft.VSTS.TCM.AutomatedTestName", Value = MethodFullName },
            new Operation(){ Op = "add", Path = "/fields/Microsoft.VSTS.TCM.AutomatedTestStorage", Value = "ApolloTests.dll" },
            new Operation(){ Op = "add", Path = "/fields/Microsoft.VSTS.TCM.AutomatedTestId", Value = Guid.NewGuid().ToString() },
            new Operation(){ Op = "add", Path = "/fields/Microsoft.VSTS.TCM.AutomationStatus", Value = "Automated" }

        };

        public bool CheckIfFieldsMatchWorkItem(JToken workItem)
        {
            var valueDiffers = false;
            foreach(var fieldName in FieldNames)
            {
                switch(fieldName)
                {
                    case "Microsoft.VSTS.TCM.AutomatedTestId":
                        break;
                    case "System.Tags":
                        var mustHaves = GetFieldVal(fieldName).Split("; ").ToList();
                        var existingTags = workItem["fields"].Value<string>(fieldName).Split("; ");
                        mustHaves.RemoveAll(it=> existingTags.Contains(it));
                        valueDiffers = mustHaves.Count > 0;
                        if (valueDiffers)
                        {
                            Log.Info(fieldName + " => " + workItem["fields"].Value<string>(fieldName));
                            Log.Info(fieldName + " => " + GetFieldVal(fieldName) + "\n\n");
                        }
                        break;
                    default:
                        valueDiffers = workItem["fields"].Value<string>(fieldName) != GetFieldVal(fieldName);
                        if (valueDiffers)
                        {
                            Log.Info(fieldName + " => " + workItem["fields"].Value<string>(fieldName));
                            Log.Info(fieldName + " => " + GetFieldVal(fieldName) + "\n\n");
                        }
                        break;

                }
                if (valueDiffers)
                    break;
            }
            return valueDiffers;
            
        }


        public JObject? WorkItem { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Operation
    {
        [JsonProperty("op")]
        public string Op { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("from")]
        public object From { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        //public override string ToString()
        //{
        //    return JObject.FromObject(this).ToString();
        //}
    }
}
