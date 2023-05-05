using BoDi;
using DocumentFormat.OpenXml.EMMA;
using HitachiQA.Helpers;
using LivingDoc.Dtos;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using TechTalk.SpecFlow;

namespace HitachiQA.Hooks
{
    [Binding]
    public class MiscHook : HookBase
    {

        private TestContext TestContext;
        public MiscHook(IObjectContainer oc, FeatureContext fc, IConfiguration config, TestContext tc) : base(oc, fc, config)
        {
            this.TestContext = tc;
        }
        public ScenarioStatus? CurrentScenarioStatus => GetStatuses()?.FirstOrDefault(it => it.scenarioName == TestContext.TestName);

        [BeforeTestRun]
        public static void CreateRunId()
        {
            var runId = Main.Configuration.GetVariable("test.RunId");
            if(string.IsNullOrWhiteSpace(runId))
            {
                runId = DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();
                Main.Configuration["test.RunId"] = runId;
            }
            Main.RunId = runId;
        }

        [AfterScenario]
        public static void initialize(TestContext testContext)
        {
            var scenarioName = testContext.TestName;
            SetStatus(scenarioName, new Outcome(testContext.CurrentTestOutcome));
            

        }
        const string SCENARIOSTATUS = "APOLLOTESTS_SCENARIOSTATUS";
        const string MUTEXNAME = SCENARIOSTATUS + "SETTER";

        private static void SetStatus(string scenarioName, Outcome newOutcome)
        {
            if (Mutex.TryOpenExisting(MUTEXNAME, out Mutex? mutex))
            {
                mutex.WaitOne();
            }
            else
                mutex = new Mutex(true, MUTEXNAME);

            try
            {
                var currentStatuses = GetStatuses();
                currentStatuses ??= new List<ScenarioStatus>();
                var targetStatus = currentStatuses.FirstOrDefault(it => it.scenarioName == scenarioName);
                if (targetStatus == null)
                {
                    targetStatus = new ScenarioStatus(scenarioName);
                    currentStatuses.Add(targetStatus);
                }
                targetStatus.outcomes.Add(newOutcome);

                currentStatuses.ForEach(s => s.outcomes.RemoveAll(it => (DateTime.Now - it.TimeStamp).TotalDays > 1));
                currentStatuses.RemoveAll(s => !s.outcomes.Any());

                Environment.SetEnvironmentVariable(SCENARIOSTATUS, JArray.FromObject(currentStatuses).ToString(Newtonsoft.Json.Formatting.None), EnvironmentVariableTarget.User);
            }
            finally
            {
                mutex.ReleaseMutex();
            }
           
        }
        private static List<ScenarioStatus>? GetStatuses()
        {
            if (Mutex.TryOpenExisting(MUTEXNAME, out Mutex? mutex))
            {
                mutex.WaitOne();
                mutex.ReleaseMutex();
            }
           

            var statusStr = Environment.GetEnvironmentVariable(SCENARIOSTATUS, EnvironmentVariableTarget.User);
            if(string.IsNullOrWhiteSpace(statusStr))
            {
                return null;
            }
            try
            {
                return JArray.Parse(statusStr).ToObject<List<ScenarioStatus>>();
            }
            catch(Exception)
            {
                return null;
            }


        }

        public class ScenarioStatus
        {
            public ScenarioStatus(string scenarioName)
            {
                this.scenarioName = scenarioName;
            }
            public string scenarioName;
            public List<Outcome> outcomes = new List<Outcome>();


        }
        public class Outcome
        {
            public bool error;
            public DateTimeOffset TimeStamp;
            public Outcome(UnitTestOutcome outcome)
            {
                error = outcome != UnitTestOutcome.Passed;
                TimeStamp = DateTimeOffset.Now;
            }
            
        }

    }
}
