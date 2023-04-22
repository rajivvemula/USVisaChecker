using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Proxies.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HitachiQA.Helpers;

namespace ApolloTests.Data.Entities.Proxy
{
    public class ProxiesConventionSetPlugin : IConventionSetPlugin
    {
        private readonly IDbContextOptions _options;

        /// <summary>
        ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
        ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
        ///     any release. You should only use it directly in your code with extreme caution and knowing that
        ///     doing so can result in application failures when updating to a new Entity Framework Core release.
        /// </summary>
        public ProxiesConventionSetPlugin(
            IDbContextOptions options,
            LazyLoaderParameterBindingFactoryDependencies lazyLoaderParameterBindingFactoryDependencies,
            ProviderConventionSetBuilderDependencies conventionSetBuilderDependencies)
        {
            _options = options;
            LazyLoaderParameterBindingFactoryDependencies = lazyLoaderParameterBindingFactoryDependencies;
            ConventionSetBuilderDependencies = conventionSetBuilderDependencies;
        }

        /// <summary>
        ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
        ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
        ///     any release. You should only use it directly in your code with extreme caution and knowing that
        ///     doing so can result in application failures when updating to a new Entity Framework Core release.
        /// </summary>
        protected virtual ProviderConventionSetBuilderDependencies ConventionSetBuilderDependencies { get; }

        /// <summary>
        ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
        ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
        ///     any release. You should only use it directly in your code with extreme caution and knowing that
        ///     doing so can result in application failures when updating to a new Entity Framework Core release.
        /// </summary>
        protected virtual LazyLoaderParameterBindingFactoryDependencies LazyLoaderParameterBindingFactoryDependencies { get; }

        /// <summary>
        ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
        ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
        ///     any release. You should only use it directly in your code with extreme caution and knowing that
        ///     doing so can result in application failures when updating to a new Entity Framework Core release.
        /// </summary>
        public virtual ConventionSet ModifyConventions(ConventionSet conventionSet)
        {
            var extension = _options.FindExtension<ProxiesOptionsExtension>();
            extension.NullGuard();
            ConventionSet.AddAfter(
                conventionSet.ModelInitializedConventions,
                new ProxyChangeTrackingConvention(extension),
                typeof(DbSetFindingConvention));

            conventionSet.Add(
                new ProxyBindingRewriter(
                    extension,
                    LazyLoaderParameterBindingFactoryDependencies,
                    ConventionSetBuilderDependencies));

            return conventionSet;
        }
    }
}
