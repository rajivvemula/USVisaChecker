using HitachiQA.Driver;

namespace BiBerkLOB.Source.Driver;

/// <summary>
/// Uses a DOM element that exposes network call status<br/>
/// to determine if the app is loading in the background
/// </summary>
public class InflightStatusChecker
{
    /// <summary>
    /// Current reasonable estimate for max time page should respond for dynamic questions <br/>
    /// THIS SHOULD NOT BE LONG! IF IT IS TAKING LONGER, TELL DARWIN
    /// </summary>
    public const int EXPECTED_MAX_SECONDS = 5;

    private Element _inflightElement;

    /// <param name="inflightElement">
    /// Element with data-stchg attribute to monitor
    /// </param>
    public InflightStatusChecker(Element inflightElement)
    {
        _inflightElement = inflightElement;
    }

    /// <summary>
    /// Checks if monitored element is present in markup
    /// </summary>
    /// <returns>
    /// True if element is in markup, false otherwise
    /// </returns>
    public bool IsPresentInDOM()
    {
        return _inflightElement.AssertElementIsPresent(1, true);
    }

    /// <summary>
    /// Checks if app is waiting on background network call
    /// </summary>
    /// <returns>
    /// The data-stchg value of the monitored element
    /// </returns>
    public bool IsInflight()
    {
        return bool.Parse(_inflightElement.GetAttribute("data-stchg"));
    }
}