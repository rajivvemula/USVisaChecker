using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BiBerkLOB.Pages.Other;
using BiBerkLOB.Source.Driver.SimpleInteractions;
using FluentAssertions.Execution;
using HitachiQA;
using HitachiQA.Driver;
using MSAssert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace BiBerkLOB.Source.Driver;

public class StaticPageValidator
{
    public const int STATIC_PAGE_WAIT = 1;
    
    private readonly List<string> _validationFailureMessages = new List<string>();

    public void ValidateStaticPage(string pageName, bool scanInherited = false)
    {
        var mapping = StaticPageMappingCache.GetMappingFromName(pageName);
        AssertMappingIsFormatted(mapping, scanInherited);

        _validationFailureMessages.Clear();
        
        ValidateStaticElements(mapping, scanInherited);
        ValidateStaticInteractions(mapping, scanInherited);
        ValidateIndexedStaticElements(mapping, scanInherited);

        if (_validationFailureMessages.Any())
        {
            var failList = string.Join('\n', _validationFailureMessages);
            MSAssert.Fail("The static page failed validation due to the following:\n" + failList);
        }
    }

    private void ValidateIndexedStaticElements(Type mapping, bool scanInherited)
    {
        var failedIndexMethods = new List<MethodInfo>();

        // retrieve static mappings of the form "Element MappingName(int)"
        var bindingFlags = GetBindingFlags(scanInherited);
        var indexMethods = mapping.GetMethods(bindingFlags)
            .Where(MethodIsAnElementIndexer);

        foreach (var indexMethod in indexMethods)
        {
            var range = indexMethod.GetCustomAttribute<IndexRangeAttribute>();
            bool oneIndexIsMissing = false;
            for (int i = range.Minimum; i <= range.Maximum; i++)
            {
                try
                {
                    var element = (Element)indexMethod.Invoke(null, new object[] { i });
                    element.AssertElementIsVisible(STATIC_PAGE_WAIT);
                }
                catch (Exception)
                {
                    Log.Error($"{GetMethodFullName(indexMethod)}({i}) was not visible");
                    oneIndexIsMissing = true;
                }
            }
            if (oneIndexIsMissing)
            {
                failedIndexMethods.Add(indexMethod);
            }
            
        }

        var failedIndexMessages = failedIndexMethods
            .Select(e => $"Indexed Element {GetMethodFullName(e)} failed (check log)");
        _validationFailureMessages.AddRange(failedIndexMessages);
    }

    private void ValidateStaticInteractions(Type mapping, bool scanInherited)
    {
        var failedInteraction = new List<PropertyInfo>();

        // retrieve static IStaticInteractions (or static properties that
        // implement IStaticInteraction) from mapping class
        var bindingFlags = GetBindingFlags(scanInherited);
        var interactions = mapping.GetProperties(bindingFlags)
            .Where(p => TypeIsAStaticInteraction(p.PropertyType));
        
        foreach (var interactionProperty in interactions)
        {
            try
            {
                var interaction = (IStaticInteraction)interactionProperty.GetValue(null);
                interaction.ValidateInteraction(STATIC_PAGE_WAIT);
            }
            catch (Exception ex)
            {
                var fullPropName = GetPropertyFullName(interactionProperty);
                Log.Error($"Interaction '{fullPropName}' failed: {ex.Message}");
                failedInteraction.Add(interactionProperty);
            }
        }

        var failedInteractionMessages = failedInteraction
            .Select(i => $"Interaction {GetPropertyFullName(i)} failed to execute (check log)");
        _validationFailureMessages.AddRange(failedInteractionMessages);
    }

    private void ValidateStaticElements(Type mapping, bool scanInherited)
    {
        var failedElements = new List<PropertyInfo>();

        // retrieve static Element properties from the mapping class
        var bindingFlags = GetBindingFlags(scanInherited);
        var elements = mapping.GetProperties(bindingFlags)
            .Where(p => p.PropertyType == typeof(Element));

        foreach (var elementProperty in elements)
        {
            try
            {
                var element = (Element)elementProperty.GetValue(null);
                element.ScrollIntoView();
                element.AssertElementIsVisible(STATIC_PAGE_WAIT);
            }
            catch
            {
                var fullPropName = GetPropertyFullName(elementProperty);
                Log.Error($"Element: {fullPropName} was not visible");
                failedElements.Add(elementProperty);
            }
        }

        var failedElementMessages = failedElements.Select(e => $"Element {GetPropertyFullName(e)} was not visible");
        _validationFailureMessages.AddRange(failedElementMessages);
    }

    private static bool TypeIsAStaticInteraction(Type type)
    {
        return type == typeof(IStaticInteraction) || type.GetInterfaces().Contains(typeof(IStaticInteraction));
    }

    private static bool MethodIsAnElementIndexer(MethodInfo method)
    {
        return method.ReturnType == typeof(Element)
               && method.GetParameters().Length == 1
               && method.GetParameters()[0].ParameterType == typeof(int);
    }

    private static void AssertMappingIsFormatted(Type mapping, bool scanInherited)
    {
        var bindingFlags = GetBindingFlags(scanInherited);
        var indexers = mapping.GetMethods(bindingFlags)
            .Where(MethodIsAnElementIndexer);

        var indexersWithoutRanges = new List<MethodInfo>();
        foreach (var indexer in indexers)
        {
            var range = indexer.GetCustomAttribute<IndexRangeAttribute>();
            if (range == null)
            {
                indexersWithoutRanges.Add(indexer);
            }
        }
        if (indexersWithoutRanges.Count > 0)
        {
            var message = "The following Element indexers do not have an IndexRange attribute:\n" + string.Join("\n", indexersWithoutRanges);
            throw new Exception(message);
        }
    }

    private static string GetPropertyFullName(PropertyInfo property)
    {
        return $"{property.DeclaringType.FullName}.{property.Name}";
    }

    private static string GetMethodFullName(MethodInfo method)
    {
        return $"{method.DeclaringType.FullName}.{method.Name}";
    }

    private static BindingFlags GetBindingFlags(bool scanInherited)
    {
        BindingFlags bindingFlags;
        if (scanInherited)
        {
            bindingFlags = BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy;
        }
        else
        {
            bindingFlags = BindingFlags.Public | BindingFlags.Static;
        }

        return bindingFlags;
    }
}