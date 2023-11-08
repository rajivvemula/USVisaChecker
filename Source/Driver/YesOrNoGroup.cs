using System.Collections.Generic;

namespace HitachiQA.Driver;

public class YesOrNoGroup : ChoiceGroup
{
    private const int DEFAULT_WAIT_SECONDS = UserActions.DEFAULT_WAIT_SECONDS;

    private const string _yes = "Yes";
    private const string _no = "No";

    /// <summary>
    /// Creates a yes/no group of elements
    /// </summary>
    /// <param name="yesChoice">"Yes" option element</param>
    /// <param name="noChoice">"No" option element</param>
    public YesOrNoGroup(Element yesChoice, Element noChoice) 
        : base(new Dictionary<string, Element>() { {_yes, yesChoice}, {_no, noChoice} }) 
    { }

    /// <summary>
    /// Clicks "Yes" option if condition is true, or "No" option otherwise
    /// </summary>
    /// <param name="yesCondition">Condition to click "Yes" option</param>
    /// <param name="waitSeconds">How long to retry clicking before failing</param>
    /// <param name="optional">If failed, determines if method should throw error</param>
    public void ClickChoiceFromCondition(bool yesCondition, int waitSeconds = DEFAULT_WAIT_SECONDS, bool optional = false)
    {
        if (yesCondition)
        {
            ClickChoice(_yes, waitSeconds, optional);
        }
        else
        {
            ClickChoice(_no, waitSeconds, optional);
        }
    }

    /// <summary>
    /// Clicks the "Yes" option
    /// </summary>
    /// <param name="waitSeconds">How long to retry clicking before failing</param>
    /// <param name="optional">If failed, determines if method should throw error</param>
    public void ClickYes(int waitSeconds = DEFAULT_WAIT_SECONDS, bool optional = false)
    {
        ClickChoiceFromCondition(true);
    }

    /// <summary>
    /// Clicks the "No" option
    /// </summary>
    /// <param name="waitSeconds">How long to retry clicking before failing</param>
    /// <param name="optional">If failed, determines if method should throw error</param>
    public void ClickNo(int waitSeconds = DEFAULT_WAIT_SECONDS, bool optional = false)
    {
        ClickChoiceFromCondition(false);
    }
}