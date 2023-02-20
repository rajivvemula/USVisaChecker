using System;
using TechTalk.SpecFlow;
using ApolloTests.Data.Form;
//using ApolloTests.Data.Entity;
using HitachiQA.Helpers;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Linq;
using System.IO;
using System.Text;
using HitachiQA;
using Microsoft.Extensions.Configuration;
using Polly;

namespace ApolloTests.StepDefinition.Forms
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
        private RestAPI RestAPI;
        private SQL SQL;
        private IConfiguration Configuration;
        private TestContext TestContext;
        public FormsGenerateSteps(RestAPI restAPI, IConfiguration config, SQL SQL, TestContext TC)
        {
            this.RestAPI = restAPI;
            this.SQL= SQL;
            this.Configuration = config;
            this.TestContext= TC;


        }
        [Given(@"condition for form with code '(.*)' and '(.*)' is met")]
        public void GivenConditionForFormWithCodeAndStateIsMet(string code, string name)
        {
            this.code = code;
            this.name = name;



            this.form = Form.GetForm(code, name);
            //matching policy from the form

            this.policy = this.form.condition.GetValidPolicy(false);
        }

        private DocGenBody _body;
        [When(@"user attempts to generate form")]
        public void WhenUserAttemptsToGenerateForm()
        {
            this.documentName = $"Test({Functions.GetRandomInteger(10000)}) [{this.form.Edition}] {this.name}";
            object ratableObjectId = null;
            if(this.form.condition.endorsement)
            {
                var endorsement = this.policy.GetDraftEndorsements().Last();
                var ratableObject = endorsement.GetRatableObject();
                ratableObject.NullGuard($"RatableObject under policy: {this.policy.Id}");
                ratableObjectId = ratableObject.Id;
            }
            DocGenBody body = new DocGenBody()
            {
                documentName = this.documentName,
                entityId = policy.Id,
                entityType = policy.EntityTypeId,
                lineId = LineId,
                ratableObjectId = ratableObjectId,
                ghostDraftRequest = new GhostDraftRequest()
                {
                    forms = new List<FormObj>() {
                        new FormObj()
                        {
                            name = this.name,
                            edition = this.form.Edition,
                            sortOrder = 1,
                            editionDate = this.form.EditionDate.ToString("O"),  
                            line = "Commercial Auto"
                        }
                    }
                },
                templateName = "generate-document-v2",
                //workflowPlanName = Configuration.GetVariable("GHOSTDRAFT_WORKFLOW_PLAN"),
                //workflowServiceName = Configuration.GetVariable("GHOSTDRAFT_WORKFLOW_SERVICE"),


            };
            _body = body;
            var docGenResponse = RestAPI.POST("/documentgenerationrequest", body);
            Log.Info(JToken.FromObject(body));

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
                {"filters", new JObject(){
                    {"EntityReference", new JObject()
                        {
                            { "EntityId",this.policy.Id.ToString() },
                            { "EntityTypeId", this.policy.EntityTypeId},
                            { "SearchType", this.policy.EntityTypeId}
                        }.ToString(Newtonsoft.Json.Formatting.None)
                    }
                }
                },
                //{ "init", null },
                { "orderBy", "insertDateTime" },
                { "sortOrder", 1 },
            };




            //check out Polly
            //Log.Debug($"documents {documents}");
            var retries = Policy.Handle<Exception>()
                .WaitAndRetry(new[]
                    {
                    TimeSpan.FromSeconds(3),
                    TimeSpan.FromSeconds(5),
                    TimeSpan.FromSeconds(10),
                    TimeSpan.FromSeconds(15)
                    }
                );

            try
            {
                retries.Execute(() =>
                {
                    JArray documents = RestAPI.POST("/documentmetadata/search", body).results;
                    this.documentObj = (JObject)documents.FirstOrDefault(it => it["documentGenerationRequestId"].ToObject<int>() == documentGenerationRequestId);
                    if(this.documentObj== null)
                    {
                        throw new Exception($"Document was not generated \nDocument: {name} \nCode: {code} \nEdition: {form.Edition}  \n At: {Environment.GetEnvironmentVariable("HOST")}/policy/{this.policy.Id}/document");
                    }
                });
            }
            catch(Exception) {
                Log.Error(JObject.FromObject(this._body));
                throw;
            }

            try
            {
                formFilePath = RestAPI.GET($"document/{documentObj["id"]}");
            }
            catch (Exception)
            {
                Thread.Sleep(5000);
                formFilePath = RestAPI.GET($"document/{documentObj["id"]}");
            }
            TestContext.AddResultFile( formFilePath );




        }

        [Then(@"form shouldn't be blank")]
        public void ThenFormShouldnTBeBlank()
        {
            string formFile = Functions.parsePDF(formFilePath);
            Log.Info($"Filepath: {formFilePath}");
            if(formFile.Length<10)
            {
                throw new Exception($"Document was blank \nDocument: {name} \nCode: {code} \nEdition: {form.Edition}  \n At: {Environment.GetEnvironmentVariable("HOST")}/policy/{this.policy.Id}/document");
            }
        }

        private static Dictionary<string, string> Code_Name = new Dictionary<string, string>();

        [Given(@"current tested forms are loaded from Forms Generate Feature")]
        public static void GivenCurrentTestedFormsAreLoadedFromFormsGenerateFeature()
        {
            string FILEPATH = Path.Combine("../../../", "Features\\Forms\\FormsGenerate.feature");

            using (StreamReader sr = new StreamReader(FILEPATH))
            {
                string line;
                // Read and display lines from the file until the end of
                // the file is reached.
                while ((line = sr.ReadLine()?.Trim()) != null)
                {
                    if (line.StartsWith("#|") || line.StartsWith('|'))
                    {
                        var temp = line.Substring(line.StartsWith('|') ? 1 : 2);
                        var Code = temp.Substring(0, temp.IndexOf('|')).Trim();
                        if (Code == "code")
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
                        catch (Exception)
                        {
                            Log.Error($"Error adding form with Code: {Code} Name: {Name}");
                            throw;
                        }
                    }

                }
            }


        }

        private static Dictionary<string, string> missingFromScripts = new Dictionary<string, string>();
        private static Dictionary<string, (string Feature, string System)> unmatchedName = new Dictionary<string, (string, string)>();


        [When(@"compared to the forms in the system")]
        public void WhenComparedToTheFormsInTheSystem()
        {
            var systemForms = SQL.executeQuery(@$"SELECT Code, [Name], Id
                                                FROM [document].[GhostDraftTemplateForm]
                                                Where StatusId !=1 and LineId=7
                                                order by Id desc;");

            foreach (var SystemForm in systemForms)
            {
                var systemCode = SystemForm["Code"];
                var systemName = SystemForm["Name"];


                if (!Code_Name.ContainsKey(systemCode))
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
                    catch (Exception)
                    {
                        Log.Debug($"Error Adding incorrect Name for \nCode: [{systemCode}] \nSystemName: [{systemName}] \nFeatureFormName: [{featureFormName}]");
                        throw;
                    }
                }

            }

        }

        [Then(@"output forms that are existing in the system but not in Forms Generate")]
        public void ThenOutputFormsThatAreExistingInTheSystemButNotInFormsGenerate()
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
            if (missingFromScripts.Count > 0 || unmatchedName.Count > 0)
            {
                throw new Exception("The Form Generation feature is missing forms or mismatched names count: "+ (missingFromScripts.Count+unmatchedName.Count));
            }


        }
    }


    public class DocGenBody
    {
        public int entityType { get; set; }
        public object? entityId { get; set; }
        public object? ratableObjectId { get; set; }
        public string? templateName { get; set; }
        public string? documentName { get; set; }
        public int insertedById { get; set; } 
        public string? workflowServiceName { get; set; }
        public string? workflowPlanName { get; set; }
        public int lineId { get; set; }
        public GhostDraftRequest? ghostDraftRequest { get; set; }

        public override string ToString()
        {
            return this.ToObject<string>();
        }

    }

    public class GhostDraftRequest
    {
        public List<FormObj>? forms { get; set; }

        public override string ToString()
        {
            return this.ToObject<string>();
        }
    }
    public class FormObj
    {
        public string? line { get; set; }
        public string? name { get; set; }
        public string? edition { get; set; }
        public string? editionDate { get; set; }
        public int? sortOrder { get; set; }

        public override string ToString()
        {
            return this.ToObject<string>();
        }
    }

}
