using HitachiQA;
using System;
using System.Collections.Generic;
using BiBerkLOB.Pages.Other;
using TechTalk.SpecFlow;
using System.Linq;
using System.Reflection;
using System.Xml.XPath;
using HitachiQA.Driver;

namespace BiBerkLOB.StepDefinition.MetaTestSteps;

[Binding]
public sealed class MappingTestSteps
{
    private Dictionary<string, Type> _mappings;

    [Given("this is a mapping test")]
    public void FillMappingDictionary()
    {
        _mappings = GetMappingDictionary();
    }

    [Then("the (.*) mapping should compile")]
    public void TestMappings(string mappingName)
    {
        var mapping = _mappings[mappingName];
        var elements = mapping.GetProperties(BindingFlags.Static | BindingFlags.Public)
            .Where(prop => prop.PropertyType == typeof(Element));

        var failures = new List<MappingErrorMessage>();

        foreach (var element in elements)
        {
            try
            {
                element.GetValue(null);
            }
            catch (Exception ex)
            {
                failures.Add(new MappingErrorMessage()
                {
                    Element = element,
                    Exception = ex
                });
            }
        }

        if (failures.Count > 0)
        {
            var messageList = string.Join("\r\n", failures.Select(f => $"{f.Element.Name}: {f.Exception.Message}"));
            throw new Exception("The following mappings are improperly formatted:\r\n" + messageList);
        }
    }

    private static Dictionary<string, Type> GetMappingDictionary()
    {
        // references this project as an assembly and gets all classes
        // that are IStaticPage and have defined [StaticPageName]
        return AssemblyScanner.GetTypesWhere(TypeIsMappingFile)
            .ToDictionary(GetMappingName);
    }

    private static string GetMappingName(Type mapping)
    {
        var attr = (MappingAttribute)mapping.GetCustomAttributes().FirstOrDefault(attr => attr is MappingAttribute);
        return attr?.Name;
    }

    private static bool TypeIsMappingFile(Type type)
    {
        return type.GetCustomAttribute<MappingAttribute>(false) != null;
    }

    private class MappingErrorMessage
    {
        public PropertyInfo Element { get; set; }
        public Exception Exception { get; set; }
    }
}