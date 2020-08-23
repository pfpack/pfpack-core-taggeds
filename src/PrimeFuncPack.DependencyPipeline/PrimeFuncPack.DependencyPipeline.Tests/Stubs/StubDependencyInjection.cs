#nullable enable

using Microsoft.Extensions.DependencyInjection;
using PrimeFuncPack.UnitTest.Moq;
using System;

namespace PrimeFuncPack.DependencyPipeline.Tests.Stubs
{
    internal sealed class StubDependencyInjection<TService> : IDependencyInjection<TService>
        where TService : class
    {
        private readonly IServiceCollection services;
        private readonly IResolver<TService> resolver;

        public StubDependencyInjection(
            in IServiceCollection services,
            in IResolver<TService> resolver)
        {
            this.services = services;
            this.resolver = resolver;
        }

        IServiceCollection IDependencyInjection<TService>.Services
            => services;

        TService IDependencyInjection<TService>.Resolve(IServiceProvider serviceProvider)
            => resolver.Resolve(serviceProvider);
    }
}
