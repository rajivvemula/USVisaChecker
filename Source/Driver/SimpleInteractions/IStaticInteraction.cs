using HitachiQA.Driver;

namespace BiBerkLOB.Source.Driver.SimpleInteractions;

/// <summary>
/// Interactable element for static pages
/// </summary>
/// <remarks>
/// Interactions should be self-contained (does not affect other parts of the page)
/// and commutative (interaction A and interaction B can be performed in any order)
/// </remarks>
public interface IStaticInteraction
{
    void ValidateInteraction(int waitSeconds = StaticConstants.DEFAULT_INTERACTION_SECONDS);
}

public static class StaticConstants
{
    public const int DEFAULT_INTERACTION_SECONDS = UserActions.DEFAULT_WAIT_SECONDS;
}