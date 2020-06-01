#nullable enable

using Microsoft.Extensions.DependencyInjection;
using System;

namespace PrimeFuncPack.DependencyInjection
{
    internal sealed class DefaultServiceBuilder<TService> : IServiceBuilder<TService>
        where TService : class
    {
        private readonly IServiceCollection services;
        private readonly ServiceResolver<TService> serviceResolver;

        public DefaultServiceBuilder(in IServiceCollection services, in ServiceResolver<TService> serviceResolver)
        {
            this.services = services ?? throw new ArgumentNullException(nameof(services));
            this.serviceResolver = serviceResolver ?? throw new ArgumentNullException(nameof(serviceResolver));
        }

        IServiceCollection IServiceCollectionProvider.Services
            => services;

        TService IServiceBuilder<TService>.Build(IServiceProvider serviceProvider)
            => serviceResolver.Invoke(serviceProvider);
    }
}
