#nullable enable

using Microsoft.Extensions.DependencyInjection;
using System;

namespace PrimeFuncPack
{
    public static class DependencyPipelineInjectionExtensions
    {
        public static DependencyPipeline<TService> InjectSingleton<TService>(
            this DependencyPipeline<TService> sourcePipeline,
            in IServiceCollection services)
            where TService : class
        {
            _ = sourcePipeline ?? throw new ArgumentNullException(nameof(sourcePipeline));
            _ = services ?? throw new ArgumentNullException(nameof(services));

            return services.AddSingleton(sourcePipeline.Resolve) switch
            {
                _ => InjectedDependencyPipeline.ContinueFromServiceProvider<TService>()
            };
        }

        public static DependencyPipeline<TService> InjectScoped<TService>(
            this DependencyPipeline<TService> sourcePipeline,
            in IServiceCollection services)
            where TService : class
        {
            _ = sourcePipeline ?? throw new ArgumentNullException(nameof(sourcePipeline));
            _ = services ?? throw new ArgumentNullException(nameof(services));

            return services.AddScoped(sourcePipeline.Resolve) switch
            {
                _ => InjectedDependencyPipeline.ContinueFromServiceProvider<TService>()
            };
        }

        public static DependencyPipeline<TService> InjectTransient<TService>(
            this DependencyPipeline<TService> sourcePipeline,
            in IServiceCollection services)
            where TService : class
        {
            _ = sourcePipeline ?? throw new ArgumentNullException(nameof(sourcePipeline));
            _ = services ?? throw new ArgumentNullException(nameof(services));

            return services.AddTransient(sourcePipeline.Resolve) switch
            {
                _ => InjectedDependencyPipeline.ContinueFromServiceProvider<TService>()
            };
        }
    }
}
