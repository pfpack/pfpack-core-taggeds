#nullable enable

using System;
using static System.FormattableString;

namespace PrimeFuncPack.DependencyPipeline
{
    internal sealed class RegisteredDependencyPipeline<T> : IDependencyPipeline<T>
    {
        T IDependencyPipeline<T>.Resolve(IServiceProvider serviceProvider)
            =>
            serviceProvider switch
            {
                not null => ResolveImpl(serviceProvider),
                _ => throw new ArgumentNullException(nameof(serviceProvider))
            };

        private T ResolveImpl(in IServiceProvider serviceProvider)
            =>
            serviceProvider.GetService(typeof(T)) switch
            {
                T service => service,
                _ => throw new InvalidOperationException(Invariant($"Instance of type '{typeof(T).FullName}' can't be resolved."))
            };
    }
}
