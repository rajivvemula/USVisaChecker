using Castle.DynamicProxy;
using HitachiQA.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ApolloTests.Data.EntityFramework
{
    /// <summary>
    /// In order to listen to any changes in the database:
    /// 1.) the property should be virtual 
    /// 2.) ListenForChanges attribute should be in the property
    /// </summary>
    public class ListenForChangesAttribute : Attribute { }

    public class PropertyInterceptor : IInterceptor
    {
        public virtual void Intercept(IInvocation invocation)
        {
            var instance = invocation.InvocationTarget;
            var invocationProp = instance.GetType().GetProperty(invocation.Method.Name.Substring(4));
            invocationProp.NullGuard($"prop: {invocation.Method.Name.Substring(4)} not found");
            var attribute = invocationProp.GetCustomAttribute<ListenForChangesAttribute>();
            if (attribute != null)
            {
                Log.Debug($"ListenForChanges @ {invocation.Method.Name}");
                var contextProp = instance.GetType().GetProperty("Context");
                contextProp.NullGuard($"in order to listen for changes {invocation.TargetType.Name} must have a Context property");

                var context = (DbContext?)contextProp.GetGetMethod()?.Invoke(instance, null);
                context.NullGuard();
                context.Entry(instance).Reload();
            }

            invocation.Proceed();
        }
    }

}
