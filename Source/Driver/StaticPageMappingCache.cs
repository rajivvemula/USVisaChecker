using System.Collections.Generic;
using System.Threading;
using System;
using System.Linq;
using System.Reflection;
using BiBerkLOB.Pages;
using BiBerkLOB.Pages.Other;
using HitachiQA;

namespace BiBerkLOB.Source.Driver;
/// <summary>
/// Scans the project for mapping files of static pages
/// </summary>
public class StaticPageMappingCache
{
    // thread lock to limit assembly scanning to one time by the first thread that requires it
    private static SemaphoreSlim _assemblyScanLock = new SemaphoreSlim(1, 1);
    // the cached pool of mapping types when the assembly is scanned for all static page mappings
    private static Dictionary<string, Type> _cachedStaticPageMappings = null;

    /// <summary>
    /// Gets the mapping class associated with a static page name
    /// </summary>
    /// <param name="pageName">
    /// The name given by the [StaticPageName] attribute
    /// </param>
    /// <returns>
    /// The static page mapping type (class) that has the static page name
    /// </returns>
    public static Type GetMappingFromName(string pageName)
    {
        EnsureStaticPageMappingsRetrieved();
        return _cachedStaticPageMappings[pageName];
    }

    private static void EnsureStaticPageMappingsRetrieved()
    {
        _assemblyScanLock.Wait(); 
        if (_cachedStaticPageMappings == null)
        {
            _cachedStaticPageMappings = GetStaticPageMappingsFromAssembly();
        }
        _assemblyScanLock.Release();
    }

    private static Dictionary<string, Type> GetStaticPageMappingsFromAssembly()
    {
        // references this project as an assembly and gets all classes
        // that are IStaticPage and have defined [StaticPageName]
        return AssemblyScanner.GetTypesWhere(TypeIsFormattedStaticPageMapping)
            .ToDictionary(mapping => mapping.GetCustomAttribute<StaticPageNameAttribute>(false).Name);
    }

    private static bool TypeIsFormattedStaticPageMapping(Type type)
    {
        return type.GetInterfaces().Contains(typeof(IStaticPage)) 
               && type.GetCustomAttribute<StaticPageNameAttribute>(false) != null;
    }
}