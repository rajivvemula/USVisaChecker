
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Globalization;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using Microsoft.EntityFrameworkCore.Proxies.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ApolloTests.Data.EntityFramework.Proxy
{

    public class ProxiesOptionsExtension : IDbContextOptionsExtension
    {
        private DbContextOptionsExtensionInfo? _info;
        private bool _useLazyLoadingProxies;
        private bool _useChangeTrackingProxies;
        private bool _checkEquality;


        public ProxiesOptionsExtension()
        {
        }

        protected ProxiesOptionsExtension(ProxiesOptionsExtension copyFrom)
        {
            _useLazyLoadingProxies = copyFrom._useLazyLoadingProxies;
            _useChangeTrackingProxies = copyFrom._useChangeTrackingProxies;
            _checkEquality = copyFrom._checkEquality;
        }


        public virtual DbContextOptionsExtensionInfo Info
            => _info ??= new ExtensionInfo(this);


        protected virtual ProxiesOptionsExtension Clone()
            => new(this);

        public virtual bool UseLazyLoadingProxies
            => _useLazyLoadingProxies;


        public virtual bool UseChangeTrackingProxies
            => _useChangeTrackingProxies;


        public virtual bool CheckEquality
            => _checkEquality;

        /// <summary>

        public virtual bool UseProxies
            => UseLazyLoadingProxies || UseChangeTrackingProxies;


        public virtual ProxiesOptionsExtension WithLazyLoading(bool useLazyLoadingProxies = true)
        {
            var clone = Clone();

            clone._useLazyLoadingProxies = useLazyLoadingProxies;

            return clone;
        }

        public virtual ProxiesOptionsExtension WithChangeTracking(bool useChangeTrackingProxies = true, bool checkEquality = true)
        {
            var clone = Clone();

            clone._useChangeTrackingProxies = useChangeTrackingProxies;
            clone._checkEquality = checkEquality;

            return clone;
        }


        public virtual void Validate(IDbContextOptions options)
        {
            if (UseProxies)
            {
                var internalServiceProvider = options.FindExtension<CoreOptionsExtension>()?.InternalServiceProvider;
                if (internalServiceProvider != null)
                {
                    using var scope = internalServiceProvider.CreateScope();
                    var conventionPlugins = scope.ServiceProvider.GetService<IEnumerable<IConventionSetPlugin>>();
                    if (conventionPlugins?.Any(s => s is ProxiesConventionSetPlugin) == false)
                    {
                        throw new InvalidOperationException(ProxiesStrings.ProxyServicesMissing);
                    }
                }
            }
        }

        public virtual void ApplyServices(IServiceCollection services)
         => services.AddEntityFrameworkProxies();

        private sealed class ExtensionInfo : DbContextOptionsExtensionInfo
        {
            private string? _logFragment;

            public ExtensionInfo(IDbContextOptionsExtension extension)
                : base(extension)
            {
            }

            private new ProxiesOptionsExtension Extension
                => (ProxiesOptionsExtension)base.Extension;

            public override bool IsDatabaseProvider
                => false;

            public override string LogFragment
                => _logFragment ??= Extension.UseLazyLoadingProxies && Extension.UseChangeTrackingProxies
                    ? "using lazy loading and change tracking proxies "
                    : Extension.UseLazyLoadingProxies
                        ? "using lazy loading proxies "
                        : Extension.UseChangeTrackingProxies
                            ? "using change tracking proxies "
                            : "";

            public override int GetServiceProviderHashCode()
            {
                var hashCode = new HashCode();
                hashCode.Add(Extension.UseLazyLoadingProxies);
                hashCode.Add(Extension.UseChangeTrackingProxies);
                hashCode.Add(Extension.CheckEquality);
                return hashCode.ToHashCode();
            }

            public override bool ShouldUseSameServiceProvider(DbContextOptionsExtensionInfo other)
                => other is ExtensionInfo otherInfo
                    && Extension.UseLazyLoadingProxies == otherInfo.Extension.UseLazyLoadingProxies
                    && Extension.UseChangeTrackingProxies == otherInfo.Extension.UseChangeTrackingProxies
                    && Extension.CheckEquality == otherInfo.Extension.CheckEquality;

            public override void PopulateDebugInfo(IDictionary<string, string> debugInfo)
            {
                debugInfo["Proxies:" + nameof(ProxiesExtensions.UseLazyLoadingProxies)]
                    = (Extension._useLazyLoadingProxies ? 541 : 0).ToString(CultureInfo.InvariantCulture);

                debugInfo["Proxies:" + nameof(ProxiesExtensions.UseChangeTrackingProxies)]
                    = (Extension._useChangeTrackingProxies ? 541 : 0).ToString(CultureInfo.InvariantCulture);
            }
        }
    }
}
