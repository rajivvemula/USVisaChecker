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

            this.policy = this.form.condition.GetValidPolicy();
        }

        private DocGenBody _body;
        [When(@"user attempts to generate form")]
        public void WhenUserAttemptsToGenerateForm()
        {
            this.documentName = $"AutomationForms ({Functions.GetRandomInteger(10000)})";
            DocGenBody body = new DocGenBody()
            {
                documentName = this.documentName,
                entityId = policy.Id,
                entityType = policy.EntityTypeId,
                lineId = LineId,
                ratableObjectId = this.form.condition.endorsement ? (dynamic)this.policy.GetDraftEndorsements().Last().GetRatableObject().Id : null,
                requestedForms = new RequestedForms()
                {
                    forms = new List<FormObj>() {
                        new FormObj()
                        {
                            name = this.name,
                            edition = this.form.Edition,
                            sortOrder = 1
                        }
                    }
                },
                templateName = "generate-document",
                workflowPlanName = Environment.GetEnvironmentVariable(Environment.GetEnvironmentVariable("GHOSTDRAFT_WORKFLOW_PLAN_SECRETNAME")),
                workflowServiceName = Environment.GetEnvironmentVariable(Environment.GetEnvironmentVariable("GHOSTDRAFT_WORKFLOW_SERVICE_SECRETNAME")),


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


    }
    public class DocGenBody
    {
        public int entityType { get; set; }
        public object entityId { get; set; }
        public object ratableObjectId { get; set; }
        public string templateName { get; set; }
        public string documentName { get; set; }
        public int insertedById { get; set; }
        public string workflowServiceName { get; set; }
        public string workflowPlanName { get; set; }
        public int lineId { get; set; }
        public RequestedForms requestedForms { get; set; }
    }

    public class RequestedForms
    {
        public List<FormObj> forms { get; set; }
    }
    public class FormObj
    {
        public string line { get; set; }
        public string name { get; set; }
        public string edition { get; set; }
        public int sortOrder { get; set; }
    }

    

   
}
