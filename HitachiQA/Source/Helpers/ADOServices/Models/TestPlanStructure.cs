using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HitachiQA.Source.Helpers.ADOServices.TestSuiteService;

namespace HitachiQA.Source.Helpers.ADOServices.Models
{
    public class TestPlanStructure
    {
        [JsonProperty("environments")]
        public List<string> Environments { get; set; }

        [JsonProperty("suites")]
        public List<TestSuite> Suites { get; set; }
    }

 

}
