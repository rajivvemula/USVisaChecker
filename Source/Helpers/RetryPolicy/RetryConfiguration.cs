using System;
using BiBerkLOB.Source.Driver;

namespace BiBerkLOB.Source.Helpers.RetryPolicy;

public class RetryConfiguration
{
    private const int MAX_NUM_RETRIES_IF_ENABLED = 1;

    public int MaxNumRetries
    {
        get
        {
            if (_override.HasValue)
            {
                return _override.Value ? MAX_NUM_RETRIES_IF_ENABLED : 0;
            }
            return IsRetryEnabled() ? MAX_NUM_RETRIES_IF_ENABLED : 0;
        }
    }

    public Action TestResetAction { get; set; } = () => { };
    // add to array as new errors are decided to blacklist
    public readonly Type[] DisallowedRetryErrors =
    {
        typeof(AlwaysFailException)
    };

    private bool? _override;

    public virtual bool IsRetryEnabled()
    {
        var envVar = Environment.GetEnvironmentVariable("ENABLE_RETRIES", EnvironmentVariableTarget.Process);
        return bool.Parse(envVar);
    }

    // NOTE: only intended for testing retry logic in any environment/pipeline
    public void OverrideRetrySetting(bool @override)
    {
        _override = @override;
    }

    public void ClearOverride()
    {
        _override = null;
    }
}