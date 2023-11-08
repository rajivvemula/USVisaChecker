using System;
using System.Linq;

namespace HitachiQA;

public class AssemblyScanner
{
    /// <summary>
    /// Returns types in the project that meet the predicate
    /// </summary>
    /// <param name="predicate">Boolean predicate to filter types by</param>
    /// <returns></returns>
    public static Type[] GetTypesWhere(Func<Type, bool> predicate)
    {
        return typeof(AssemblyScanner).Assembly.GetTypes()
            .Where(predicate)
            .ToArray();
    }
}