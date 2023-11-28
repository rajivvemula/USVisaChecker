using HitachiQA.Driver;
using HitachiQA.Helpers;

namespace BiBerkLOB.Source.Driver;

public class LoadingRequirements
{
    private readonly Element[] _requiredElements;

    public LoadingRequirements(params Element[] requiredElements)
    {
        _requiredElements = requiredElements;
    }
    
    public void AssertLegacy(int waitSeconds = UserActions.DEFAULT_PAGE_WAIT_SECONDS)
    {
        AutomationHelper.LegacyWaitForLoading(waitSeconds);
        AssertRequiredElements(waitSeconds);
    }

    public void AssertInWC(int waitSeconds = UserActions.DEFAULT_PAGE_WAIT_SECONDS)
    {
        AutomationHelper.WaitForWCLoading(waitSeconds);
        AssertRequiredElements(waitSeconds);
    }

    public void Assert(int waitSeconds = UserActions.DEFAULT_PAGE_WAIT_SECONDS)
    {
        AutomationHelper.WaitForLoading(waitSeconds);
        AssertRequiredElements(waitSeconds);
    }

    private void AssertRequiredElements(int waitSeconds)
    {
        foreach (var requiredElement in _requiredElements)
        {
            requiredElement.AssertElementIsVisible(waitSeconds);
        }
    }
}