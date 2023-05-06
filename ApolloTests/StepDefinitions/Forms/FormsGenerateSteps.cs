using System;
using TechTalk.SpecFlow;
using ApolloTests.Data.Form;
using HitachiQA.Helpers;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;
using Polly;
using Newtonsoft.Json;
using HitachiQA.Hooks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApolloTests.Data.Entities.Context;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechTalk.SpecFlow.UnitTestProvider;

namespace ApolloTests.StepDefinition.Forms
{
    [Binding]
    public class FormsGenerateSteps
    {
        //LOB = Commercial Auto
        public int LineId = 7;
        public string? code,
               name;
        public Form? Form;

        private RestAPI RestAPI;
        private SQL SQL;
        private IConfiguration Configuration;
        private TestContext TestContext;
        private FormTestContext? Context;
        private MiscHook MiscHook;
        private CosmosContext CosmosContext;
        private SQLContext SQLContext;
        private IUnitTestRuntimeProvider RuntimeProvider;

        private IObjectContainer ObjectContainer;
        public FormsGenerateSteps(RestAPI restAPI, IConfiguration config, SQL SQL, TestContext TC, MiscHook miscHook, IObjectContainer objectContainer)
        {
            this.RestAPI = restAPI;
            this.SQL= SQL;
            this.Configuration = config;
            this.TestContext= TC;
            this.MiscHook = miscHook;
            this.CosmosContext= objectContainer.Resolve<CosmosContext>();
            this.SQLContext = objectContainer.Resolve<SQLContext>();
            this.RuntimeProvider = objectContainer.Resolve<IUnitTestRuntimeProvider>();
            this.ObjectContainer = objectContainer;
            Log.Info(TC.Properties);

        }

        [Given(@"condition for form with code '([^']*)' and '([^']*)' and lineId=(.*) is met")]
        public void GivenConditionForFormWithCodeAndStateIsMet(string code, string name, int LineId)
        {
            this.code = code;
            this.name = name;
            this.LineId = LineId;
            var line = SQLContext.Line.Find(LineId);
            this.Form = Form.GetForm(line, code, name);
            string? testPointConfiguration = (string?)TestContext.Properties["__Tfs_TestConfigurationName__"];
            bool useNewEntities = testPointConfiguration?.Contains("FORM_CREATE_NEW_ENTITIES") == true;
            if(bool.TryParse(Configuration.GetVariable("FORM_CREATE_NEW_ENTITIES", true), out bool createNew))
            {
                useNewEntities = createNew;
            }
            Data.Entities.Policy policy = null;
            try
            {
                policy = this.Form.condition.GetValidPolicy(useNewEntities, ObjectContainer);
                
            }
            catch(Exception ex)
            {
                var msg = $"error creating/retireving policy for form: {code}  - {name} in line {LineId}";
                throw new Exception(msg, ex);
            }
            if (policy == null)
            {
                RuntimeProvider.TestInconclusive($"No policy was found for form: {code}  - {name} in line {LineId}");
            }
            this.Context = new FormTestContext(Form, policy);

        }

        [When(@"user attempts to generate form")]
        public void WhenUserAttemptsToGenerateForm()
        {

            foreach (var test in this.Context?.Tests ?? throw new NullReferenceException())
            {
                var docGenResponse = RestAPI.POST("/documentgeneration", test?.body);
                ((bool)docGenResponse).Should().Be(true, "this request should return true");
            }
            
        }


        [Then(@"form should be generated successfully")]
        public void ThenFormShouldBeGeneratedSuccessfully()
        {
            Log.Info($"At: {Environment.GetEnvironmentVariable("HOST")}/policy/{this.Context?.Policy.Id}/document");


            var searchBody = new JObject()
            {
                {"filters", new JObject(){
                    {"EntityReference", new JObject()
                        {
                            { "EntityId",this.Context?.Policy.Id.ToString() },
                            { "EntityTypeId", this.Context?.Policy.EntityTypeId},
                            { "SearchType", 1}
                        }.ToString(Newtonsoft.Json.Formatting.None)
                    }
                }
                },
                //{ "init", null },
                { "orderBy", "insertDateTime" },
                { "sortOrder", 1 },
                { "pageSize", 1000 }
            };

            var retries = Polly.Policy.HandleResult<bool>(false)
                .WaitAndRetry(new[]
                    {
                    TimeSpan.FromSeconds(5),
                    TimeSpan.FromSeconds(3),
                    TimeSpan.FromSeconds(2),
                    TimeSpan.FromSeconds(5),
                    TimeSpan.FromSeconds(5),
                    TimeSpan.FromSeconds(5),
                    TimeSpan.FromSeconds(5)
                    }
                );
            //give it 3 seconds to procees before checking
            Thread.Sleep(3000);
            foreach (var test in this.Context?.Tests ?? throw new Exception())
            {
                var docGenRequestId = test.docGenResponseID;

                var errorMsg = $"Document was not generated \nDocumentName: {test.documentName} \nFormName: {name} \nCode: {code} \nEdition: {Form?.Edition}  \n At: {Environment.GetEnvironmentVariable("HOST")}/policy/{this.Context.Policy.Id}/document";


                //Log.Info($"Form Generated: \nDocumentName: {requestedDoc.documentName} \nFormName: {this.form.name} \nCode: {this.form.code}\n Recipient: {this.form.Recipients.First(it=> it.RecipientRoleTypeId == requestedDoc.recipientRoleTypeId).RecipientTypeName}");
                
                JObject? documentObj =null;
                retries.Execute(() =>
                {
                    JArray? documents = RestAPI.POST("/documentmetadata/search", searchBody)?.results;
                    documents.NullGuard();
                    documentObj = (JObject?)documents.FirstOrDefault(it => it.Value<string>("originalFileName")?.Contains(test.guid.ToString()) ?? false);

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
            foreach(var test in this.Context?.Tests?? throw new NullReferenceException())
            {
                test.filePath.NullGuard("if document generated successfully, filepath should be loaded in the test object");
                string formFile = Functions.ParsePDF(test.filePath);
                Log.Info($"Filepath: {test.filePath}");
                if (formFile.Length < 10)
                {
                    test.error = $"Document was blank \nDocument: {test.documentName} \nCode: {code} \nEdition: {Form?.Edition}  \n At: {Environment.GetEnvironmentVariable("HOST")}/policy/{Context?.Policy.Id}/document";
                }
            }
            ThrowErrorsIfAny();


        }

        public void ThrowErrorsIfAny()
        {
            if(this.Context?.Tests.Any(it=> it.error!=null)?? false)
            {
#if DEBUG
                    throw new Exception(string.Join("\n\n\n", this.Context.Tests.Where(it=>it.error!=null).Select(it=> $"body: {it.body}\n{it.error}")));
#else
                    throw new Exception(string.Join("\n\n\n", this.Context.Tests.Where(it=>it.error!=null).Select(it=> $"{it.error}")));
#endif
            }
        }

        private static Dictionary<string, string> Code_Name = new Dictionary<string, string>();

        [Given(@"current tested forms are loaded from Forms Generate Feature")]
        public static void GivenCurrentTestedFormsAreLoadedFromFormsGenerateFeature()
        {
            string FILEPATH = Path.Combine("../../../", "Features\\Forms\\FormsGenerate.feature");

            using (StreamReader sr = new StreamReader(FILEPATH))
            {
                string? line;
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

    public class FormTestContext
    {
        public Form Form;
        public Data.Entities.Policy Policy;
        public List<Test> Tests;

        public FormTestContext(Form form, Data.Entities.Policy policy)
        {
            this.Form = form;
            this.Policy = policy;

            this.Tests = form.Recipients.Select(it => new Test(this.Form, this.Policy, it)).ToList();
            
        }
        public class Test
        {
            public Test(Form form, Data.Entities.Policy policy, Recipient recipient)
            {
                this.guid = Guid.NewGuid();
                this.documentName = $"[{recipient.RecipientTypeCode}] [{form.Edition}] {form.name} {guid}";
                this.Recipient = recipient;
                this.body = this.GetDocGenBody(form, policy, recipient);
               
            }
            public Recipient Recipient;
            public DocGenBody? body;
            public long docGenResponseID;
            public string documentName;
            public string? error;
            public string? filePath;
            public Guid guid;

            private DocGenBody GetDocGenBody(Form form, Data.Entities.Policy policy, Recipient recipient)
            {
                long? ratableObjectId = null;

                if (form.condition.endorsement)
                {
                    var endorsement = policy.GetDraftEndorsements().Last();
                    var ratableObject = endorsement.RatableObject;
                    if(ratableObject==null)
                    {
                        endorsement.GetSummary();
                        ratableObject = endorsement.RatableObject;
                    }
                    ratableObject.NullGuard($"RatableObject under policy: {policy.Id}");
                    ratableObjectId = ratableObject.Id;
                }

                return new DocGenBody()
                {
                    documentName = documentName,
                    entityId = policy.Id,
                    entityType = policy.EntityTypeId,
                    lineId = 7,
                    ratableObjectId = ratableObjectId,
                    insertedById = 10008,
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
                    recipientRoleTypeId = recipient.RecipientRoleTypeId == -1 ? null: recipient.RecipientRoleTypeId
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
        public int? recipientRoleTypeId { get; set; }
        public GhostDraftRequest? ghostDraftRequest { get; set; }
        public int generationEvent { get; set; } = 4;

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
