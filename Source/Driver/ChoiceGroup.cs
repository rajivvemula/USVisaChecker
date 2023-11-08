using System;
using System.Collections.Generic;

namespace HitachiQA.Driver;

public class ChoiceGroup
{
    private const int DEFAULT_WAIT_SECONDS = UserActions.DEFAULT_WAIT_SECONDS;

    private IChoicePicker _choices;
    private bool _choicesMayAlreadyBeSelected;

    /// <summary>
    /// A group of related elements to choose from.
    /// </summary>
    /// <param name="choices">Dictionary of elements with unique names as reference id</param>
    public ChoiceGroup(Dictionary<string, Element> choices)
    {
        _choices = new DictionaryChoicePicker(choices);
    }

    /// <summary>
    /// A group of related elements to choose from.
    /// </summary>
    /// <param name="choiceSelector">Delegate method for getting an element from a string</param>
    public ChoiceGroup(Func<string, Element> choiceSelector, SelectionDomain domain = null)
    {
        _choices = new SelectionMethodChoicePicker(choiceSelector, domain);
    }

    public ChoiceGroup MayAlreadyBeSelected()
    {
        _choicesMayAlreadyBeSelected = true;
        return this;
    }

    /// <summary>
    /// Clicks on the element associated with the choice name
    /// </summary>
    /// <param name="choice">Choice name id of element</param>
    /// <param name="waitSeconds">How long to retry clicking before failing</param>
    /// <param name="optional">If failed, determines if method should throw error</param>
    /// <exception cref="ArgumentException"></exception>
    public void ClickChoice(string choice, int waitSeconds = DEFAULT_WAIT_SECONDS, bool optional = false)
    {
        try
        {
            var choiceToClick = _choices.GetChoice(choice);
            if (_choicesMayAlreadyBeSelected)
            {
                choiceToClick.ClickIfNotSelected(waitSeconds);
            }
            else
            {
                choiceToClick.Click(waitSeconds, optional);
            }
        }
        catch (Exception)
        {
            if (optional)
            {
                Log.Warn($"Error skipped at choice selection for '{choice}'");
                return;
            }
            throw;
        }
    }

    public Element GetChoice(string choice)
    {
        return _choices.GetChoice(choice);
    }

    public void AssertAllButtons(int waitSeconds = DEFAULT_WAIT_SECONDS)
    {
        _choices.AssertChoices(waitSeconds);
    }

    public string[] GetSelectedChoices(Func<Element, bool> isSelectedMethod)
    {
        return _choices.GetSelectedChoices(isSelectedMethod);
    }
}