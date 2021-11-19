using System;
using TechTalk.SpecFlow;
using ApolloQA.Data.Form;
using System.Collections.Generic;
using ApolloQA.Data.Entity;
using ApolloQA.Source.Helpers;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Linq;
using System.IO;
using System.Text;
using ApolloQA.Source.Driver;

namespace ApolloQA.StepDefinition.Forms
{
    [Binding]
    public class FormsGenerateSteps
    {
        //LOB = Commercial Auto
        public const int LineId = 7;
        public string code,
               name;
        public Form form;
        public string documentName;
        public int documentGenerationRequestId;
        public JObject documentObj;

        public Data.Entity.Policy policy;

        [Given(@"condition for form with code '(.*)' and '(.*)' is met")]
        public void GivenConditionForFormWithCodeAndStateIsMet(string code, string name)
        {
            this.code = code;
            this.name = name;

        

            this.form  = Form.GetForm(code);
            //matching policy from the form
            this.policy = this.form.condition.GetValidPolicy(true);
        }

        private DocGenBody _body;
        [When(@"user attempts to generate form")]
        public void WhenUserAttemptsToGenerateForm()
        {
            this.documentName = $"AutomationForms ({Functions.GetRandomInteger(10000)}) - {this.name.Trim('-').Trim()}";

            var ratableObjectId = this.form.condition.endorsement ? (dynamic)this.policy.GetDraftEndorsements().Last().GetRatableObject().Id : null;

            DocGenBody body = new DocGenBody()
            {
                documentName = this.documentName,
                entityId = policy.Id,
                entityType = policy.EntityTypeId,
                lineId = LineId,
                ratableObjectId = ratableObjectId,
                requestedForms = new RequestedForms()
                {
                    forms = new List<FormObj>() {
                        new FormObj()
                        {
                            edition = this.form.Edition,
                            line ="Commercial Auto",
                            name = this.name.Trim('-').Trim(),
                            sortOrder = 1
                        }
                    }
                },
                templateName = "generate-document-v2",
               /* workflowPlanName = Environment.GetEnvironmentVariable(Environment.GetEnvironmentVariable("GHOSTDRAFT_WORKFLOW_PLAN_SECRETNAME")),
                workflowServiceName = Environment.GetEnvironmentVariable(Environment.GetEnvironmentVariable("GHOSTDRAFT_WORKFLOW_SERVICE_SECRETNAME")),*/


            };
            _body = body;
            var docGenResponse  = RestAPI.POST("/documentgenerationrequest", body);


            //File.WriteAllText(Directory.GetCurrentDirectory() + "testForms.json", JObject.FromObject(body).ToString());

            this.documentGenerationRequestId = docGenResponse.id;

        }
        dynamic formFilePath;
        [Then(@"form should be generated successfully")]
        public void ThenFormShouldBeGeneratedSuccessfully()
        {
            Log.Info($"Form Generated: \nDocumentName: {this.documentName} \nFormName: {this.form.name} \nCode: {this.form.code}");
            Log.Info($"At: {Environment.GetEnvironmentVariable("HOST")}/policy/{this.policy.Id}/document");


            var body = new JObject()
            {   
                {"filters", new JObject()
                    {
                        { "RelatedEntityId",this.policy.Id },
                        {  "RelatedEntityTypeId", this.policy.EntityTypeId} 
                    }
                
                },
                //{ "init", null },
                { "orderBy", "insertDateTime" },
                { "sortOrder", 1 },
            };





            //Log.Debug($"documents {documents}");
            var counter = 0;
            while(this.documentObj == null)
            {
                counter++;
                Thread.Sleep(counter * 3000);
                JArray documents = RestAPI.POST("/documentmetadata/search", body).results;
                this.documentObj = (JObject)documents.FirstOrDefault(it => it["documentGenerationRequestId"].ToObject<int>() == documentGenerationRequestId);
                if(counter>5)
                {
                    break;
                }
            }
            if(this.documentObj == null)
            {
                Log.Debug(JObject.FromObject(this._body));
                throw new Exception($"Doc: {name} Code: {code} was not generated");
            }
                
            
            try
            {
                formFilePath = RestAPI.GET($"document/{documentObj["id"]}");
            }
            catch(Exception)
            {
                Thread.Sleep(5000);
                formFilePath = RestAPI.GET($"document/{documentObj["id"]}");
            }



           
            var data = new Dictionary<string, string>() { 
                { "Name",  this.name.Trim().Trim('-') },
                { "DocumentName", this.documentName },
                { "PolicyId", this.policy.Id.ToString() },
                { "URL", $"{Environment.GetEnvironmentVariable("HOST")}/policy/{this.policy.Id}/document/{documentObj["id"]}"}
            };

            Functions.WriteToCSV("FormData.csv", new List<Dictionary<string, string>>() { data });


        }

        [Then(@"form shouldn't be blank")]
        public void ThenFormShouldnTBeBlank()
        {
            var formFile = Functions.parsePDF(formFilePath);
            //Log.Debug(formFile);
            Assert.IsTrue(formFile.Length > 10);
        }

        private static Dictionary<string, string> Code_Name = new Dictionary<string, string>();

        [Given(@"current tested forms are loaded from Forms Generate Feature")]
        public static void GivenCurrentTestedFormsAreLoadedFromFormsGenerateFeature()
        {
            string FILEPATH = Path.Combine(Setup.SourceDir, "Features\\Forms\\FormsGenerate.feature");

            using (StreamReader sr = new StreamReader(FILEPATH))
            {
                string line;
                // Read and display lines from the file until the end of
                // the file is reached.
                while ((line = sr.ReadLine()?.Trim()) != null)
                {
                    if (line.StartsWith("#|") || line.StartsWith('|'))
                    {
                        var temp = line.Substring(line.StartsWith('|') ? 1:2);
                        var Code = temp.Substring(0, temp.IndexOf('|')).Trim();
                        if(Code == "code")
                        {
                            Log.Debug("continue;");
                            continue;
                        }
                        temp = temp.Substring(temp.IndexOf('|') + 1);
                        var Name = temp.Substring(0, temp.IndexOf('|')).Trim();

                        try
                        {
                            Code_Name.Add(Code, Name);

                        }
                        catch(Exception)
                        {
                            Log.Error($"Error adding form with Code: {Code} Name: {Name}");
                            throw;
                        }
                    }

                }
            }

            
        }

        private static Dictionary<string, string> missingFromScripts = new Dictionary<string, string>();
        private static Dictionary<string, (string Feature, string System)> unmatchedName = new Dictionary<string, (string,string)>();


        [When(@"compared to the forms in the system")]
        public static void WhenComparedToTheFormsInTheSystem()
        {
            var systemForms =SQL.executeQuery(@$"SELECT Code, [Name], Id
                                                FROM [document].[GhostDraftTemplateForm]
                                                Where StatusId !=1
                                                order by Id desc;");
            
            foreach (var SystemForm in systemForms)
            {
                var systemCode = SystemForm["Code"];
                var systemName = SystemForm["Name"];


                if(!Code_Name.ContainsKey(systemCode))
                {
                    missingFromScripts.Add(systemCode, systemName);
                    continue;
                }
                var FeatureForm = Code_Name.First(it => it.Key == systemCode);
                var featureFormName = FeatureForm.Value;

                if (featureFormName != systemName)
                {
                    try
                    {
                        unmatchedName.Add((string)systemCode, ((string)featureFormName, (string)systemName));

                    }
                    catch(Exception)
                    {
                        Log.Debug($"Error Adding incorrect Name for \nCode: [{systemCode}] \nSystemName: [{systemName}] \nFeatureFormName: [{featureFormName}]");
                        throw;
                    }
                }

            }

        }

        [Then(@"output forms that are existing in the system but not in Forms Generate")]
        public static void ThenOutputFormsThatAreExistingInTheSystemButNotInFormsGenerate()
        {
            if (missingFromScripts.Count > 0)
                Log.Info("(blank)\n\n\n");
                Log.Info("missing From Scripts:");

            foreach (var item in missingFromScripts)
            {
                Log.Info($"Code: {item.Key}");
                Log.Info($"Name: {item.Value}\n");

            }
            if (unmatchedName.Count > 0)
                Log.Info("(blank)\n\n\n");
                Log.Info("Unmatched Names:");

            foreach (var item in unmatchedName)
            {
                Log.Info($"Code: {item.Key}");
                Log.Info($"Name in Feature: {item.Value.Feature}");
                Log.Info($"Name in System : {item.Value.System}\n");

            }
            if (missingFromScripts.Count>0 || unmatchedName.Count>0)
            {
                throw new Exception("The Form Generation feature is missing forms or mismatched names");
            }
           

        }
    }
    public class DocGenBody
    {
        public int entityType { get; set; }
        public object entityId { get; set; }
        public object ratableObjectId { get; set; }
        public string templateName { get; set; }
        public string documentName { get; set; }
        public int insertedById { get; set; }
       /* public string workflowServiceName { get; set; }
        public string workflowPlanName { get; set; }*/
        public int lineId { get; set; }
        public RequestedForms requestedForms { get; set; }
    }

    public class RequestedForms
    {
        public List<FormObj> forms { get; set; }
    }
    public class FormObj
    {
        public string edition { get; set; }
        public string line { get; set; }
        public string name { get; set; }
        public int sortOrder { get; set; }
    }


   


}
