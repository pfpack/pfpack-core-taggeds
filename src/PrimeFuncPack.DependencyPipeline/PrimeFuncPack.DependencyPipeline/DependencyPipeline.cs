#nullable enable

using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PrimeFuncPack.DependencyPipeline.Tests")]

namespace PrimeFuncPack.DependencyPipeline
{
    public static class DependencyPipeline
    {
        public static IDependencyPipeline<T> Start<T>(
            in Resolver<T> resolver)
            =>
            resolver switch
            {
                null => throw new ArgumentNullException(nameof(resolver)),
                _ => new ImplDependencyPipeline<T>(resolver)
            };
    }
}
