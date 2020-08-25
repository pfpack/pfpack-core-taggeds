#nullable enable

using PrimeFuncPack.DependencyPipeline;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PrimeFuncPack.DependencyPipeline.Tests")]

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static IDependencyInjection<TService> UseInjection<TService>(
            this IDependencyPipeline<TService> sourcePipeline,
            in IServiceCollection services)
            where TService : class
        {
            _ = sourcePipeline ?? throw new ArgumentNullException(nameof(sourcePipeline));
            _ = services ?? throw new ArgumentNullException(nameof(services));

            return new ImplDependencyInjection<TService>(services, sourcePipeline.Resolve);
        }
    }
}
