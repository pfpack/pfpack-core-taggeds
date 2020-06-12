#nullable enable

using PrimeFuncPack.DependencyInjection;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionBuilderExtensions
    {
        public static IServiceBuilder<TService> UseBuilder<TService>(
            this IServiceCollection services,
            in ServiceResolver<TService> serviceResolver)
            where TService : class
            => new DefaultServiceBuilder<TService>(services, serviceResolver);

        public static TServiceCollectionProvider Do<TServiceCollectionProvider>(
            this TServiceCollectionProvider provider,
            in Action<TServiceCollectionProvider> action)
            where TServiceCollectionProvider : notnull, IServiceCollectionProvider
        {
            if (provider is null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            action.Invoke(provider);
            return provider;
        }

        public static TResultProvider Pipe<TSourceProvider, TResultProvider>(
            this TSourceProvider provider,
            in Func<TSourceProvider, TResultProvider> pipe)
            where TSourceProvider : notnull, IServiceCollectionProvider
            where TResultProvider : notnull, IServiceCollectionProvider
        {
            if (provider is null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            if (pipe is null)
            {
                throw new ArgumentNullException(nameof(pipe));
            }

            return pipe.Invoke(provider);
        }
    }
}
