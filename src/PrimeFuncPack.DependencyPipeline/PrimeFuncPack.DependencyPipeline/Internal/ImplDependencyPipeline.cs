#nullable enable

using System;

namespace PrimeFuncPack.DependencyPipeline
{
    internal sealed class ImplDependencyPipeline<T> : IDependencyPipeline<T>
    {
        private readonly Resolver<T> resolver;

        public ImplDependencyPipeline(in Resolver<T> resolver)
            => this.resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));

        T IDependencyPipeline<T>.Resolve(in IServiceProvider serviceProvider)
            =>
            serviceProvider switch
            {
                not null => resolver.Invoke(serviceProvider),
                null => throw new ArgumentNullException(nameof(serviceProvider))
            };
    }
}
