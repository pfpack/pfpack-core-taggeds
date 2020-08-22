#nullable enable

using System;

namespace PrimeFuncPack.DependencyPipeline
{
    public delegate T Resolver<out T>(IServiceProvider serviceProvider);
}
