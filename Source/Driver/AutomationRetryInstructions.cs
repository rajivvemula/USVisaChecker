using System;
using System.Collections.Generic;
using System.Threading;
using HitachiQA;
using HitachiQA.Driver;

namespace BiBerkLOB.Source.Driver;

public class AutomationRetryInstructions
{
    public const int DEFAULT_RETRY_WAIT_SECONDS = 5;

    public List<Func<bool>> _steps;
    private string _name;

    private AutomationRetryInstructions(string name)
    {
        _steps = new List<Func<bool>>();
        _name = name;
    }
    
    public static AutomationRetryInstructions Init(string name)
    {
        return new AutomationRetryInstructions(name);
    }

    public AutomationRetryInstructions First(Action firstAction)
    {
        _steps.Clear();
        _steps.Add(() =>
        {
            firstAction();
            return true;
        });
        return this;
    }

    public AutomationRetryInstructions Then(Action nextAction)
    {
        _steps.Add(() =>
        {
            nextAction();
            return true;
        });
        return this;
    }

    public AutomationRetryInstructions ThenShould(Func<bool> predicate)
    {
        _steps.Add(predicate);
        return this;
    }

    [Obsolete("Method exists as last resort, avoid using")]
    public AutomationRetryInstructions ThenSleepFor(int milliseconds)
    {
        _steps.Add(() =>
        {
            Thread.Sleep(milliseconds);
            return true;
        });
        return this;
    }

    public bool GetResultFromAutomation()
    {
        Log.Debug($"doing {_name}");
        int i = 0;
        foreach (var step in _steps)
        {
            Log.Debug($"doing step {++i}");
            if (!step())
            {
                return false;
            }
        }

        return true;
    }

    public override string ToString()
    {
        return _name;
    }
}