using System;
using System.Collections.Generic;
using System.Linq;
using BiBerkLOB.Source.Driver;
using BiBerkLOB.Source.Helpers.RetryPolicy;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BiBerkLOB.StepDefinition.MetaTestSteps
{
    [Binding]
    public sealed class RetryStepDefinitions
    {
        private readonly string _consistentErrorMessage = "An error occurred and will always occur";

        private List<StepResult> _failedSteps = new();
        private bool _continueForTestFail;
        private bool _continueForBlacklistedTestFail;
        
        private int _tryCount;

        private RetryConfiguration _retryConfiguration;

        public RetryStepDefinitions(RetryConfiguration retryConfiguration)
        {
            _retryConfiguration = retryConfiguration;
        }

        [Given(@"override retry config to allow retries")]
        public void GivenOverrideRetryConfigToAllowRetries()
        {
            _retryConfiguration.OverrideRetrySetting(true);
        }
        
        [Given(@"test tracks try count")]
        public void GivenTestTracksTryCount()
        {
            _tryCount++;
        }

        [When(@"test suddenly fails on first run")]
        public void GivenTestSuddenlyFailsOnFirstRun()
        {
            if (_tryCount <= 1)
            {
                throw new Exception("random error broke first run");
            }
        }

        [When(@"test has no issues")]
        public void WhenTestHasNoIssues()
        {
            DoSomethingSafe();
        }

        [Then(@"everything is fine")]
        public void ThenEverythingIsFine()
        {
            DoSomethingSafe();
        }

        [When(@"test fails consistently")]
        public void WhenTestFailsConsistently()
        {
            _continueForTestFail = true;
            throw new Exception(_consistentErrorMessage);
        }

        [When(@"test fails once in a way that shouldn't retry")]
        public void WhenTestFailsOnceInAWayThatShouldntRetry()
        {
            _continueForBlacklistedTestFail = true;
            if(_tryCount <= 1)
            {
                throw new AlwaysFailException(_consistentErrorMessage);
            }
        }

        [Then(@"test should normally fail")]
        public void ThenTestShouldNormallyFail()
        {
            Assert.AreEqual(1, _failedSteps.Count);
            var failedStep = _failedSteps[0];
            Assert.IsTrue(failedStep.ScenarioExecutionStatus == ScenarioExecutionStatus.TestError);
            Assert.AreEqual(_consistentErrorMessage, failedStep.TestError.Message);
        }

        [Then(@"test should run following number of times: (.*)")]
        public void ThenTestShouldRunFollowingNumberOfTimes(int expectedTryCount)
        {
            Assert.AreEqual(expectedTryCount, _tryCount);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _tryCount = 0;
        }
        /*
        * ================================================================
        * Hooks for unique steps to test retries
        * "TrackFailingSteps" tag should not be used for normal QA testing
        * ================================================================
        */
        [BeforeScenario("TrackFailingSteps")]
        public void InitializeFailCheck()
        {
            _failedSteps.Clear();
        }

        [BeforeStep("TrackFailingSteps")]
        public void ClearFailTracking()
        {
            _continueForTestFail = false;
            _continueForBlacklistedTestFail = false;
        }

        [AfterStep("TrackFailingSteps")]
        public void CheckForFailAndMoveOn(ScenarioContext scenarioContext)
        {
            if (!StepFlaggedAnIntendedFailure())
            {
                return;
            }
            
            if (scenarioContext.ScenarioExecutionStatus != ScenarioExecutionStatus.OK)
            {
                _failedSteps.Add(new StepResult()
                {
                    StepInfo = scenarioContext.StepContext.StepInfo,
                    ScenarioExecutionStatus = scenarioContext.ScenarioExecutionStatus,
                    TestError = scenarioContext.TestError
                });

                ResetScenarioContext(scenarioContext);
            }
        }

        private bool StepFlaggedAnIntendedFailure()
        {
            bool[] intendedFailureFlags = new[] { _continueForTestFail, _continueForBlacklistedTestFail };
            return intendedFailureFlags.Any(flag => flag);
        }

        private static void DoSomethingSafe()
        {
            Assert.AreEqual(1, 1);
        }

        private static void ResetScenarioContext(ScenarioContext scenarioContext)
        {
            typeof(ScenarioContext).GetProperty(nameof(ScenarioContext.ScenarioExecutionStatus))
                .SetValue(scenarioContext, ScenarioExecutionStatus.OK);
            typeof(ScenarioContext).GetProperty(nameof(ScenarioContext.TestError))
                .SetValue(scenarioContext, null);
        }

        private class StepResult
        {
            public StepInfo StepInfo { get; set; }
            public ScenarioExecutionStatus ScenarioExecutionStatus { get; set; }
            public Exception TestError { get; set; }
        }
    }
}