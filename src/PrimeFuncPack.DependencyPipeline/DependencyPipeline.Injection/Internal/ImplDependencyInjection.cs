#nullable enable

using Microsoft.Extensions.DependencyInjection;
using System;

namespace PrimeFuncPack.DependencyPipeline
{
    internal sealed class ImplDependencyInjection<TService> : IDependencyInjection<TService>
        where TService : class
    {
        private readonly IServiceCollection services;
        private readonly Resolver<TService> resolver;

        public ImplDependencyInjection(
            in IServiceCollection services,
            in Resolver<TService> resolver)
        {
            this.services = services ?? throw new ArgumentNullException(nameof(services));
            this.resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
        }

        IServiceCollection IDependencyInjection<TService>.Services
            => services;

        TService IDependencyInjection<TService>.Resolve(IServiceProvider serviceProvider)
            => resolver.Invoke(serviceProvider);
    }
}
