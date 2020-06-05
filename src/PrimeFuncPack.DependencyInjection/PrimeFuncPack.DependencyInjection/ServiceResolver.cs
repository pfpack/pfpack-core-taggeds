#nullable enable

using System;

namespace PrimeFuncPack.DependencyInjection
{
    public delegate TService ServiceResolver<out TService>(IServiceProvider serviceProvider)
        where TService : class;
}
