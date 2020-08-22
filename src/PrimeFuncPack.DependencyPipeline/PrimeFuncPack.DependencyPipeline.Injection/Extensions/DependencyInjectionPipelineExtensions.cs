#nullable enable

using Microsoft.Extensions.DependencyInjection;
using System;

namespace PrimeFuncPack.DependencyPipeline.Extensions
{
    public static class DependencyInjectionPipelineExtensions
    {
        public static IDependencyPipeline<TService> InjectSingleton<TService>(
            this IDependencyPipeline<TService> sourcePipeline,
            in IServiceCollection services)
            where TService : class
        {
            _ = sourcePipeline ?? throw new ArgumentNullException(nameof(sourcePipeline));
            _ = services ?? throw new ArgumentNullException(nameof(services));

            return services.AddSingleton(sp => sourcePipeline.Resolve(sp)) switch
            {
                _ => new RegisteredDependencyPipeline<TService>()
            };
        }

        public static IDependencyPipeline<TService> InjectScoped<TService>(
            this IDependencyPipeline<TService> sourcePipeline,
            in IServiceCollection services)
            where TService : class
        {
            _ = sourcePipeline ?? throw new ArgumentNullException(nameof(sourcePipeline));
            _ = services ?? throw new ArgumentNullException(nameof(services));

            return services.AddScoped(sp => sourcePipeline.Resolve(sp)) switch
            {
                _ => new RegisteredDependencyPipeline<TService>()
            };
        }

        public static IDependencyPipeline<TService> InjectTransient<TService>(
            this IDependencyPipeline<TService> sourcePipeline,
            in IServiceCollection services)
            where TService : class
        {
            _ = sourcePipeline ?? throw new ArgumentNullException(nameof(sourcePipeline));
            _ = services ?? throw new ArgumentNullException(nameof(services));

            return services.AddTransient(sp => sourcePipeline.Resolve(sp)) switch
            {
                _ => new RegisteredDependencyPipeline<TService>()
            };
        }
    }
}
