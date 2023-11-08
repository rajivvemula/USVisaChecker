using System;
using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using HitachiQA.Driver;
using static IdentityModel.ClaimComparer;

namespace HitachiQA.Driver;

public interface IChoicePicker
{
    Element GetChoice(string choiceId);
    void AssertChoices(int waitSeconds = UserActions.DEFAULT_WAIT_SECONDS);
    string[] GetSelectedChoices(Func<Element, bool> isSelectedMethod);
}

public class DictionaryChoicePicker : IChoicePicker
{
    private Dictionary<string, Element> _choices;

    public DictionaryChoicePicker(Dictionary<string, Element> choices)
    {
        _choices = choices;
    }

    public Element GetChoice(string choiceId)
    {
        if (!_choices.ContainsKey(choiceId))
        {
            throw new ArgumentException($"'{choiceId}' is not a valid choice for this group");
        }

        return _choices[choiceId];
    }

    public void AssertChoices(int waitSeconds = UserActions.DEFAULT_WAIT_SECONDS)
    {
        foreach (var (_, element) in _choices)
        {
            element.AssertElementIsVisible();
        }
    }

    public string[] GetSelectedChoices(Func<Element, bool> isSelectedMethod)
    {
        return _choices.Where(kvp => isSelectedMethod(kvp.Value))
            .Select(kvp => kvp.Key)
            .ToArray();
    }
}

public class SelectionMethodChoicePicker : IChoicePicker
{
    private Func<string, Element> _selector;
    private SelectionDomain _domain;

    public SelectionMethodChoicePicker(Func<string, Element> selector, SelectionDomain domain = null)
    {
        _selector = selector;
        _domain = domain;
    }

    public Element GetChoice(string choiceId)
    {
        return _selector(choiceId);
    }

    public void AssertChoices(int waitSeconds = UserActions.DEFAULT_WAIT_SECONDS)
    {
        if (_domain == null || _domain.IsEmpty())
        {
            Log.Warn("NO DOMAIN IS SET, THIS NEEDS IMMEDIATE ATTENTION");
            return;
        }

        foreach (var choice in _domain.Domain)
        {
            _selector(choice).AssertElementIsVisible(waitSeconds);
        }
    }

    public string[] GetSelectedChoices(Func<Element, bool> isSelectedMethod)
    {
        if (_domain == null || _domain.IsEmpty())
        {
            throw new Exception("Selection method did not set a domain");
        }

        return _domain.Domain
            .Where(choice => isSelectedMethod(_selector(choice)))
            .ToArray();
    }
}

public class SelectionDomain
{
    public string[] Domain { get; private set; }

    public SelectionDomain(params string[] domain)
    {
        Domain = domain;
    }

    public bool IsEmpty()
    {
        return Domain.Length == 0;
    }
}