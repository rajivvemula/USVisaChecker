using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using BoDi;
using HitachiQA;

namespace BiBerkLOB.Source.Helpers.RetryPolicy;

public class ContextObjectResetter
{

    private readonly IObjectContainer _container;

    public ContextObjectResetter(IObjectContainer container)
    {
        _container = container;
    }

    public void ResetContextObjects()
    {
        var toReset = AssemblyScanner.GetTypesWhere(type => type.GetCustomAttribute<ResettableContextObjectAttribute>() != null);

        foreach (var contextType in toReset)
        {
            ResetObject(_container.Resolve(contextType));
        }
    }

    // Takes any object (ideally, plain old CLR) and resets the public instance properties to defaults
    // Custom defaults can be set with [DefaultValue] attribute
    // Any property with a .Clear() method should have the [Clearable] attribute
    private void ResetObject(object toReset)
    {
        Log.Info($"Resetting following object: {toReset.GetType().Name}");
        var type = toReset.GetType();

        var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
        foreach (var propertyInfo in properties.Where(prop => prop.GetCustomAttributes() is not DoNotResetAttribute))
        {
            var propertyAttributes = propertyInfo.GetCustomAttributes();

            if (propertyAttributes.Any(attr => attr is ClearableAttribute))
            {
                dynamic clearable = propertyInfo.GetValue(toReset);
                clearable?.Clear();
            }
            else
            {
                var defaultValueAttr =
                    (DefaultValueAttribute)propertyAttributes.SingleOrDefault(attr => attr is DefaultValueAttribute);

                var defaultValue = defaultValueAttr != null ? defaultValueAttr.Value
                    : propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType)
                    : null;

                propertyInfo.SetValue(toReset, defaultValue);
            }
        }
    }
}