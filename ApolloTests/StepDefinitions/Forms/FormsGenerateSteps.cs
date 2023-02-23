﻿using System;
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
using DocumentFormat.OpenXml.Wordprocessing;
using Newtonsoft.Json;

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

        private RestAPI RestAPI;
        private SQL SQL;
        private IConfiguration Configuration;
        private TestContext TestContext;
        private FormContext Context;


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
            this.Context = new FormContext(form);

            //matching policy from the form

        }

        [When(@"user attempts to generate form")]
        public void WhenUserAttemptsToGenerateForm()
        {
           
            foreach(var test in this.Context.Tests)
            {
                var docGenResponse = RestAPI.POST("/documentgeneration", test.body);
                ((bool)docGenResponse).Should().Be(true, "this request should return true");
                //var res = (JObject)docGenResponse;
                //Log.Error(res);
                //test.docGenResponseID = res.Value<long>("id");
            }
            
        }


        [Then(@"form should be generated successfully")]
        public void ThenFormShouldBeGeneratedSuccessfully()
        {
            Log.Info($"At: {Environment.GetEnvironmentVariable("HOST")}/policy/{this.Context.Policy.Id}/document");


            var body = new JObject()
            {
                {"filters", new JObject(){
                    {"EntityReference", new JObject()
                        {
                            { "EntityId",this.Context.Policy.Id.ToString() },
                            { "EntityTypeId", this.Context.Policy.EntityTypeId},
                            { "SearchType", this.Context.Policy.EntityTypeId}
                        }.ToString(Newtonsoft.Json.Formatting.None)
                    }
                }
                },
                //{ "init", null },
                { "orderBy", "insertDateTime" },
                { "sortOrder", 1 },
            };
            var retries = Policy.HandleResult<bool>(false)
                .WaitAndRetry(new[]
                    {
                    TimeSpan.FromSeconds(3),
                    TimeSpan.FromSeconds(5),
                    TimeSpan.FromSeconds(10),
                    TimeSpan.FromSeconds(15)
                    }
                );

            foreach (var test in this.Context.Tests)
            {
                var docGenRequestId = test.docGenResponseID;

                var errorMsg = $"Document was not generated \nDocumentName: {test.documentName} \nFormName: {name} \nCode: {code} \nEdition: {form.Edition}  \n At: {Environment.GetEnvironmentVariable("HOST")}/policy/{this.Context.Policy.Id}/document";


                //Log.Info($"Form Generated: \nDocumentName: {requestedDoc.documentName} \nFormName: {this.form.name} \nCode: {this.form.code}\n Recipient: {this.form.Recipients.First(it=> it.RecipientRoleTypeId == requestedDoc.recipientRoleTypeId).RecipientTypeName}");

                JObject documentObj =null;
                retries.Execute(() =>
                {
                    JArray documents = RestAPI.POST("/documentmetadata/search", body).results;
                    documentObj = (JObject)documents.FirstOrDefault(it => it.Value<string>("originalFileName").Contains(test.guid.ToString()));

                    if (documentObj != null)
                    {
                        test.error = null;
                        return true;
                    }
                    test.error=errorMsg;
                    return false;


                });

                if (documentObj != null)
                {
                    dynamic? formFilePath = null;
                    try
                    {
                        formFilePath = RestAPI.GET($"document/{documentObj["id"]}");
                        test.filePath =  formFilePath;

                    }
                    catch (Exception)
                    {
                        Thread.Sleep(5000);
                        formFilePath = RestAPI.GET($"document/{documentObj["id"]}");
                        test.filePath = formFilePath;

                    }
                    TestContext.AddResultFile(formFilePath);
                }
            }
            ThrowErrorsIfAny();

        }


        [Then(@"form shouldn't be blank")]
        public void ThenFormShouldnTBeBlank()
        {
            foreach(var test in this.Context.Tests)
            {
                test.filePath.NullGuard("if document generated successfully, filepath should be loaded in the test object");
                string formFile = Functions.parsePDF(test.filePath);
                Log.Info($"Filepath: {test.filePath}");
                if (formFile.Length < 10)
                {
                    test.error = $"Document was blank \nDocument: {test.documentName} \nCode: {code} \nEdition: {form.Edition}  \n At: {Environment.GetEnvironmentVariable("HOST")}/policy/{Context.Policy.Id}/document";
                }
            }
            ThrowErrorsIfAny();


        }

        public void ThrowErrorsIfAny()
        {
            if(this.Context.Tests.Any(it=> it.error!=null))
            {
                throw new Exception(string.Join("\n\n\n", this.Context.Tests.Where(it=>it.error!=null).Select(it=> $"{it.error}")));
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

    public class FormContext
    {
        public Form Form;
        public Data.Entity.Policy Policy;
        public List<Test> Tests;

        public FormContext(Form form)
        {
            this.Form = form;
            this.Policy = this.Form.condition.GetValidPolicy(false);

            this.Tests = form.Recipients.Select(it => new Test(this.Form, this.Policy, it)).ToList();
            
        }
        public class Test
        {
            public Test(Form form, Data.Entity.Policy policy, Recipient recipient)
            {
                this.guid = Guid.NewGuid();
                this.documentName = $"[{recipient.RecipientTypeCode}] [{form.Edition}] {form.name} {guid}";
                this.Recipient = recipient;
                this.LoadBody(form, policy, recipient);

               
            }
            public Recipient Recipient;
            public DocGenBody body;
            public long docGenResponseID;
            public string documentName;
            public string? error;
            public string? filePath;
            public Guid guid;

            private void LoadBody(Form form, Data.Entity.Policy policy, Recipient recipient)
            {
                long? ratableObjectId = null;

                if (form.condition.endorsement)
                {
                    var endorsement = policy.GetDraftEndorsements().Last();
                    var ratableObject = endorsement.GetRatableObject();
                    ratableObject.NullGuard($"RatableObject under policy: {policy.Id}");
                    ratableObjectId = ratableObject.Id;
                }

                this.body = new DocGenBody()
                {
                    documentName = documentName,
                    entityId = policy.Id,
                    entityType = policy.EntityTypeId,
                    lineId = 7,
                    ratableObjectId = ratableObjectId,
                    insertedById= 10008,
                    ghostDraftRequest = new GhostDraftRequest()
                    {
                        forms = new List<FormObj>() {
                            new FormObj()
                            {
                                name = form.name,
                                edition = form.Edition,
                                sortOrder = 1,
                                editionDate = form.EditionDate,
                                line = "Commercial Auto"
                            }
                        }
                    },
                    templateName = "generate-document-v2",
                    recipientRoleTypeId = recipient.RecipientRoleTypeId
                    //workflowPlanName = Configuration.GetVariable("GHOSTDRAFT_WORKFLOW_PLAN"),
                    //workflowServiceName = Configuration.GetVariable("GHOSTDRAFT_WORKFLOW_SERVICE"),


                };
            }

        }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
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
        public int recipientRoleTypeId { get; set; }
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
        public DateTime? editionDate { get; set; }
        public int? sortOrder { get; set; }

        public override string ToString()
        {
            return this.ToObject<string>();
        }
    }

}
