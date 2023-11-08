using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using BiBerkLOB.Pages.Other;
using BiBerkLOB.Source.Helpers.RetryPolicy;
using HitachiQA;
using TechTalk.SpecFlow;
using NUnitAssert = NUnit.Framework.Assert;

namespace BiBerkLOB.StepDefinition.MetaTestSteps;

[Binding]
public class ResettingTestSteps
{
    private Type[] _resettables;

    public ResettingTestSteps(RetryConfiguration retryConfig)
    {
        // this allows the test to show specific error message
        retryConfig.OverrideRetrySetting(false);
    }

    [Given("this is a resetting test")]
    public void FillResetCollection()
    {
        _resettables = AssemblyScanner.GetTypesWhere(type => type.GetCustomAttribute<ResettableContextObjectAttribute>(false) != null);
        
    }

    [Then("resettables should have valid defaults")]
    public void TestResettables()
    {
        foreach (var resettable in _resettables)
        {
            var properties = resettable.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var propertyInfo in properties.Where(prop => prop.GetCustomAttributes() is not DoNotResetAttribute))
            {
                var propertyAttributes = propertyInfo.GetCustomAttributes();
                var defaultValueAttr = (DefaultValueAttribute)propertyAttributes.SingleOrDefault(attr => attr is DefaultValueAttribute);

                var expectedPropertyType = propertyInfo.PropertyType;

                var defaultValue = defaultValueAttr != null ? defaultValueAttr.Value
                    : expectedPropertyType.IsValueType ? Activator.CreateInstance(expectedPropertyType)
                    : null;

                if (defaultValue == null)
                {
                    AssertNullDefaultIsAllowed(resettable, propertyInfo, expectedPropertyType);
                }
                else
                {
                    AssertDefaultValueIsExpectedType(resettable, propertyInfo, defaultValue, expectedPropertyType);
                }
            }
        }
    }

    private static void AssertNullDefaultIsAllowed(Type resettable, PropertyInfo propertyInfo, Type expectedPropertyType)
    {
        try
        {
            Assert.IsTrue(!expectedPropertyType.IsValueType || expectedPropertyType.GetGenericTypeDefinition() == typeof(Nullable<>));
        }
        catch
        {
            NUnitAssert.Fail(
                $"'{resettable.Name}' had a null default value for property '{propertyInfo.Name}'" +
                $"\r\n\tType {expectedPropertyType} does not accept null values" +
                $"\r\nPlease use the default for {expectedPropertyType} or remove [DefaultValue] attribute");
        }
    }

    private static void AssertDefaultValueIsExpectedType(Type resettable, PropertyInfo propertyInfo, object defaultValue, Type expectedPropertyType)
    {
        var actualType = defaultValue.GetType();
        try
        {
            Assert.AreEqual(actualType, expectedPropertyType);
        }
        catch
        {
            NUnitAssert.Fail(
                $"'{resettable.Name}' default type mismatch for property '{propertyInfo.Name}':" +
                $"\r\n\tExpected type {expectedPropertyType}" +
                $"\r\n\tConfigured Type {actualType}\r\n" +
                $"Reconfigure [DefaultValue] to be {expectedPropertyType}");
        }
    }
}