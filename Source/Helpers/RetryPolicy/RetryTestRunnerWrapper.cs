using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HitachiQA;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Source.Helpers.RetryPolicy;

public class RetryTestRunnerWrapper
{
    public Exception ExceptionThatTriggeredRetry { get; private set; }

    private bool HasRetriedTooManyTimes => _currentRetryCount >= _retryConfig.MaxNumRetries;
    private bool ScenarioHasNotErrored => _testRunner.ScenarioContext.ScenarioExecutionStatus != ScenarioExecutionStatus.TestError;
    
    private readonly List<StepListItem> _previousSteps = new List<StepListItem>();
    private int _currentRetryCount;
    private int _stepUnstableCounter;
    
    private readonly ITestRunner _testRunner;
    private readonly RetryConfiguration _retryConfig;

    public RetryTestRunnerWrapper(ITestRunner testRunner, RetryConfiguration config)
    {
        _testRunner = testRunner;
        _retryConfig = config;
    }

    public void ResetRetryTrackers()
    {
        _previousSteps.Clear();
        _currentRetryCount = 0;
    }

    public void SetTestResetForRetry(Action resetAction)
    {
        _retryConfig.TestResetAction = resetAction;
    }

    public void CheckScenarioStatusAndRetryIfNecessary()
    {
        if (ScenarioHasNotErrored || HasRetriedTooManyTimes
                || CurrentErrorDisallowsRetry(_testRunner.ScenarioContext.TestError))
        {
            return;
        }

        ExceptionThatTriggeredRetry = _testRunner.ScenarioContext.TestError;
        ResetScenarioContext();
        _retryConfig.TestResetAction();
        _currentRetryCount++;
        
        Log.Warn($"Error occurred in execution, attempt retry #{_currentRetryCount}");
        Log.Separator();

        var stepsToReplay = CopyStepsForReplayThenClear();
        foreach (var stepListItem in stepsToReplay)
        {
            var stepRetryArgs = stepListItem.Args;
            
            var text = stepRetryArgs.Text;
            var multilineTextArgument = stepRetryArgs.MultilineTextArgument;
            var tableArgument = stepRetryArgs.TableArgument;
            var keyword = stepRetryArgs.Keyword;

            stepListItem.Method.Invoke(_testRunner, new object[]{ text, multilineTextArgument, tableArgument, keyword });
        }
    }

    public void AddStepAndArgumentsForPotentialRetry(string stepMethodName, StepRetryArgs stepArgs)
    {
        _previousSteps.Add(new StepListItem()
        {
            Method = _testRunner.GetType().GetMethod(stepMethodName),
            Args = stepArgs
        });
    }

    public void FlagNextStepAsUnstable()
    {
        // the step that calls this method will be evaluated for
        // instability and therefore needs to flag 2 steps to carry over
        _stepUnstableCounter = 2;
    }

    private bool CurrentErrorDisallowsRetry(Exception exception)
    {
        bool currentStepIsUnstable = IsCurrentStepUnstable();
        SetNextStepStability();

        if (currentStepIsUnstable)
        {
            return false;
        }

        var currentErrorDisallowsRetry = _retryConfig.DisallowedRetryErrors.Any(exType => exType == exception.GetType());
        return currentErrorDisallowsRetry;
    }

    private bool IsCurrentStepUnstable()
    {
        return _stepUnstableCounter > 0;
    }

    private void SetNextStepStability()
    {
        _stepUnstableCounter--;
    }

    private StepListItem[] CopyStepsForReplayThenClear()
    {
        var copy = _previousSteps.ToArray();
        _previousSteps.Clear();
        return copy;
    }

    private void ResetScenarioContext()
    {
        typeof(ScenarioContext).GetProperty(nameof(ScenarioContext.ScenarioExecutionStatus))
            .SetValue(_testRunner.ScenarioContext, ScenarioExecutionStatus.OK);
        typeof(ScenarioContext).GetProperty(nameof(ScenarioContext.TestError))
            .SetValue(_testRunner.ScenarioContext, null);
    }

    private class StepListItem
    {
        public MethodInfo Method { get; init; }
        public StepRetryArgs Args { get; init; }
    }
}